using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;
using Diagram.UI;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

namespace DataPerformer
{
    /// <summary>
    /// Iterator of series
    /// </summary>
    [Serializable()]
    public class SeriesIterator : Series, IDataConsumer, INamedCoordinates, IIteratorConsumer, IPostSetArrow
    {
        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        /// <summary>
        /// Measurements of coordinates
        /// </summary>
        protected IMeasurement[] coordinates = new IMeasurement[2];

        /// <summary>
        /// List of iterators
        /// </summary>
        protected List<IIterator> iterators = new List<IIterator>();

        List<IMeasurements> measurementsData = new List<IMeasurements>();

        #endregion

        #region Ctors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SeriesIterator()
        {
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SeriesIterator(SerializationInfo info, StreamingContext context)
        {
            x = info.GetValue("X", typeof(string)) as string;
            y = info.GetValue("Y", typeof(string)) as string;
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", x, typeof(string));
            info.AddValue("Y", y, typeof(string));
        }

        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            measurementsData.Add(measurements);
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            measurementsData.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            foreach (IMeasurements m in measurementsData)
            {
                m.UpdateMeasurements();
            }
        }

        int IDataConsumer.Count
        {
            get { return measurementsData.Count; }
        }

        IMeasurements IDataConsumer.this[int n]
        {
            get { return measurementsData[n]; }
        }

        void IDataConsumer.Reset()
        {
            this.FullReset();
        }

        event Action IDataConsumer.OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        #endregion

        #region INamedCoordinates Members

        IList<string> INamedCoordinates.GetNames(string coordinateName)
        {
            return this.Names;
        }

        string INamedCoordinates.X
        {
            get { return this.X; }
        }

        string INamedCoordinates.Y
        {
            get { return this.Y; }
        }

        void INamedCoordinates.Set(string x, string y)
        {
            this.Set(x, y);
        }

        void INamedCoordinates.Update()
        {
        }


        #endregion
 
        #region IIteratorConsumer Members

        void IIteratorConsumer.Add(IIterator iterator)
        {
            iterators.Add(iterator);
        }

        void IIteratorConsumer.Remove(IIterator iterator)
        {
            iterators.Remove(iterator);
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Set();
            Post();
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Sets names of variables
        /// </summary>
        /// <param name="x">The X - coordinate name</param>
        /// <param name="y">The Y - coordinate name</param>
        public void Set(string x, string y)
        {
            this.x = x;
            this.y = y;
            Set();
        }

        /// <summary>
        /// Names of variables
        /// </summary>
        public IList<string> Names
        {
            get
            {
                Double a = 0;
                IList<string> l = this.GetAllMeasurementsType(a);
                return l;
            }
        }

        /// <summary>
        /// Sets all own settings
        /// </summary>
        protected void Set()
        {
            points = new List<double[]>();
            List<IIterator> iter = iterators;
            if (iter.Count == 0)
            {
                iter = new List<IIterator>();
                this.GetIterators(iter);
            }
            IDataConsumer consumer = this;
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i];
                IAssociatedObject ao = m as IAssociatedObject;
                string on = this.GetRelativeName(ao) + ".";
                for (int j = 0; j < m.Count; j++)
                {
                    IMeasurement mea = m[j];
                    string s = on + mea.Name;
                    if (s.Equals(x))
                    {
                        coordinates[0] = mea;
                        continue;
                    }
                    if (s.Equals(y))
                    {
                        coordinates[1] = mea;
                    }
                }
            }
            foreach (IMeasurement m in coordinates)
            {
                if (m == null)
                {
                    return;
                }
            }

            foreach (IIterator it in iter)
            {
                it.Reset();
            }
            while (true)
            {
                consumer.Reset();
                consumer.UpdateChildrenData();
                object ox = coordinates[0].Parameter();
                if (ox is DBNull | ox == null)
                {
                    goto iterate;
                }
                object oy = coordinates[1].Parameter();
                if (oy is DBNull | oy == null)
                {
                    goto iterate;
                }
                double xx = (double)ox;
                double yy = (double)oy;
                points.Add(new double[] { xx, yy });
            iterate:
                foreach (IIterator it in iter)
                {
                    if (!it.Next())
                    {
                        goto fin;
                    }
                }
            }
        fin:
            return;
        }

        /// <summary>
        /// Names of measurements
        /// </summary>
        public List<string> AllMeasurements
        {
            get
            {
                Double a = 0;
                IDataConsumer c = this;
                List<string> list = new List<string>();
                for (int i = 0; i < c.Count; i++)
                {
                    IMeasurements m = c[i];
                    IAssociatedObject ao = m as IAssociatedObject;
                    string on = this.GetRelativeName(ao) + ".";
                    for (int j = 0; j < m.Count; j++)
                    {
                        IMeasurement mea = m[j];
                        if (mea.Type.Equals(a))
                        {
                            string s = on + mea.Name;
                            list.Add(s);
                        }
                    }
                }
                return list;
            }
        }



        #endregion

    }
}
