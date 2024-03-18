using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;
using DataPerformer.Interfaces;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Wrapper of data consumers
    /// </summary>
    public class DataConsumerWrapper : IAssociatedObject, IDataConsumer
    {

        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };

        IDataConsumer[] consumers;

        IAssociatedObject associated;

        #endregion

        #region Ctor

        private DataConsumerWrapper(IAssociatedObject associated)
        {
            this.associated = associated;
        }

        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
        {
            get
            {
                return associated.Object;
            }
            set
            {
            }
        }

        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            foreach (IDataConsumer c in consumers)
            {
                c.Add(measurements);
            }
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            foreach (IDataConsumer c in consumers)
            {
                c.Remove(measurements);
            }
        }

        void IDataConsumer.UpdateChildrenData()
        {
            consumers[0].UpdateChildrenData();
        }

        int IDataConsumer.Count
        {
            get { return consumers[0].Count; }
        }

        IMeasurements IDataConsumer.this[int number]
        {
            get { return consumers[0][number]; }
        }

        void IDataConsumer.Reset()
        {
            consumers[0].Reset();
        }

        event Action IDataConsumer.OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Crates data consumer from accociated object
        /// </summary>
        /// <param name="obj">Accociated object</param>
        /// <returns>Data consumer</returns>
        static internal IDataConsumer Create(IAssociatedObject obj)
        {
            return Get(null, obj, obj);
        }


        #endregion

        #region Private Members

        private static IDataConsumer Get(IDataConsumer master,
            IAssociatedObject root, IAssociatedObject obj)
        {
            IDataConsumer res = null;
            if (obj is IDataConsumer)
            {
                res = obj as IDataConsumer;
            }
            res = Create(root, master, res);
            if (obj is IChildrenObject)
            {
                IChildrenObject co = obj as IChildrenObject;
                IAssociatedObject[] ch = co.Children;
                foreach (IAssociatedObject ao in ch)
                {
                    res = Get(res, root, ao);
                }
            }
            return res;
        }


        private static IDataConsumer Create(IAssociatedObject root,
            IDataConsumer master, IDataConsumer slave)
        {
            if (master == null)
            {
                return slave;
            }
            if (slave == null)
            {
                return master;
            }
            if (master is DataConsumerWrapper)
            {
                DataConsumerWrapper dw = master as DataConsumerWrapper;
                dw.Add(slave);
                return dw;
            }
            DataConsumerWrapper wrapper = new DataConsumerWrapper(root);
            wrapper.Add(master);
            wrapper.Add(slave);
            return wrapper;
        }


        private void Add(IDataConsumer consumer)
        {
            List<IDataConsumer> l = new List<IDataConsumer>();
            if (consumers != null)
            {
                l.AddRange(consumers);
            }
            l.Add(consumer);
            consumers = l.ToArray();
        }

        #endregion
    }
}
