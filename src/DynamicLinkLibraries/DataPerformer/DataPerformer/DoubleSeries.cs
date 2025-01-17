using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;

using BaseTypes;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using ErrorHandler;

namespace DataPerformer
{
    /// <summary>
    /// Combination of two series
    /// </summary>
    [Serializable()]
    public class DoubleSeries : Series, IDataConsumer, INamedCoordinates, IPostSetArrow
    {
        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        /// <summary>
        /// Coordinate measurements
        /// </summary>
        protected IMeasurement[] coordinates = new IMeasurement[2];


        List<IMeasurements> measurementsData = new List<IMeasurements>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DoubleSeries()
        {
           
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DoubleSeries(SerializationInfo info, StreamingContext context)
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

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            try
            {
                Set();
                Post();
            }
            catch (Exception exception)
            {
                exception.ShowError(10);
            }
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
        /// Names of measurements
        /// </summary>
        public IList<string> Names
        {
            get
            {
                Double a = 0;
                List<string> names = new List<string>();
                IDataConsumer c = this;
                for (int i = 0; i < c.Count; i++)
                {
                    IMeasurements mea = c[i];
                    IAssociatedObject ao = mea as IAssociatedObject;
                    string s = this.GetRelativeName(ao) + ".";
                    for (int j = 0; j < mea.Count; j++)
                    {
                        IMeasurement m = mea[j];
                        object rt = m.Type;
                        if (!(rt is ArrayReturnType))
                        {
                            continue;
                        }
                        ArrayReturnType art = rt as ArrayReturnType;
                        if (!art.ElementType.Equals(a))
                        {
                            continue;
                        }
                        if (art.Dimension.Length != 1)
                        {
                            continue;
                        }
                        string name = s + m.Name;
                        names.Add(name);
                    }
                }
                return names;
            }
        }

        /// <summary>
        /// Sets all its settings
        /// </summary>
        protected void Set()
        {
            points = new List<double[]>();
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
            consumer.UpdateAll();
            object ox = coordinates[0].Parameter();
            if (ox is DBNull | ox == null)
            {
                return;
            }
            object oy = coordinates[1].Parameter();
            if (oy is DBNull | oy == null)
            {
                return;
            }
            Array ax = ox as Array;
            Array ay = oy as Array;
            for (int i = 0; i < ax.GetLength(0) & i < ay.GetLength(0); i++)
            {
                double xx = (double)ax.GetValue(i);
                double yy = (double)ay.GetValue(i);
                points.Add(new double[] { xx, yy });
            }
        }

    /*    public List<string> AllMeasurements
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
                    string on = PureDesktop.GetRelativeName(this, ao) + ".";
                    for (int j = 0; j < m.Count; j++)
                    {
                        IMeasure mea = m[j];
                        if (mea.Type.Equals(a))
                        {
                            string s = on + mea.Name;
                            list.Add(s);
                        }
                    }
                }
                return list;
            }
        }*/



        #endregion

    }
}
