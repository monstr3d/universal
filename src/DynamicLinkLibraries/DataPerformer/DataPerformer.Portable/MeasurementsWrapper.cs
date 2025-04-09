using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;
using DataPerformer.Interfaces;
using NamedTree;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Wrapper of measurements
    /// </summary>
    public class MeasurementsWrapper : IAssociatedObject, IMeasurements,
          IStarted
    {

        #region Fields

        private IMeasurement[] measurements;

        private IMeasurements[] mea;

        private bool isUpdated;

        IAssociatedObject associated;


        #endregion

        #region Ctor

        private MeasurementsWrapper(IAssociatedObject associated)
        {
            this.associated = associated;
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return measurements.Length; }
        }

        IMeasurement IMeasurements.this[int number]
        {
            get { return measurements[number]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            foreach (IMeasurements m in mea)
            {
                m.IsUpdated = false;
                m.UpdateMeasurements();
            }
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return isUpdated;
            }
            set
            {
                isUpdated = value;
            }
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
        //*/

        #region IStarted Members

        void IStarted.Start(double time)
        {
            foreach (IMeasurements m in mea)
            {
                if (m is IStarted)
                {
                    IStarted st = m as IStarted;
                    st.Start(time);
                }
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Count of measurements
        /// </summary>
        public int Count
        {
            get
            {
                return mea.Length;
            }
        }

        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => measurements;

        /// <summary>
        /// Access to measurements
        /// </summary>
        /// <param name="number">Number of measurements</param>
        /// <returns>The measurements</returns>
        public IMeasurements this[int number]
        {
            get
            {
                return mea[number];
            }
        }

        /// <summary>
        /// Creates measurements
        /// </summary>
        /// <param name="obj">Associated object</param>
        /// <returns>Measurements</returns>
        static internal IMeasurements Create(IAssociatedObject obj)
        {
            return Get(null, obj, obj);
        }

        #endregion

        #region Private Members


        private static IMeasurements Get(IMeasurements master,
           IAssociatedObject root, IAssociatedObject obj)
        {
            IMeasurements res = null;
            if (obj is IMeasurements)
            {
                res = obj as IMeasurements;
            }
            res = Create(root, master, res);
            if (obj is IChildren<IAssociatedObject> co)
            {
                IAssociatedObject[] ch = co.Children.ToArray();
                if (ch != null)
                {
                    foreach (IAssociatedObject ao in ch)
                    {
                        res = Get(res, root, ao);
                    }
                }
            }
            return res;
        }


        private static IMeasurements Create(IAssociatedObject root,
            IMeasurements master,
            IMeasurements slave)
        {
            if (master == null)
            {
                return slave;
            }
            if (slave == null)
            {
                return master;
            }
            if (master is MeasurementsWrapper)
            {
                MeasurementsWrapper mw = master as MeasurementsWrapper;
                mw.Add(slave);
                return mw;
            }
            MeasurementsWrapper wrapper = new MeasurementsWrapper(root);
            wrapper.Add(master);
            wrapper.Add(slave);
            return wrapper;
        }

        private void Add(IMeasurements measurements)
        {
            List<IMeasurements> l = new List<IMeasurements>();
            if (mea != null)
            {
                l.AddRange(mea);
            }
            l.Add(measurements);
            mea = l.ToArray();
            List<IMeasurement> m = new List<IMeasurement>();
            if (this.measurements != null)
            {
                m.AddRange(this.measurements);
            }
            int n = measurements.Count;
            for (int i = 0; i < n; i++)
            {
                m.Add(measurements[i]);
            }
            this.measurements = m.ToArray();
        }

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
            var l = new List<IMeasurement>(measurements);
            l.Add(child);
            measurements = l.ToArray();
            throw new ErrorHandler.OwnException();

        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
            var l = new List<IMeasurement>(measurements);
            l.Remove(child);
            measurements = l.ToArray();
        }

        #endregion

    }
}
