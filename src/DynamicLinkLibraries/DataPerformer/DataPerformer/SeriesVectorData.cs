using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using BaseTypes;
using CategoryTheory;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using Diagram.UI;
using ErrorHandler;
using NamedTree;

namespace DataPerformer
{
    /// <summary>
    /// Vector series
    /// </summary>
    [Serializable()]
    public class SeriesVectorData : Series, IDataConsumer, INamedCoordinates, IPostSetArrow
    {
        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        IMeasurement xm;

        IMeasurement ym;

        List<IMeasurements> measurements = new List<IMeasurements>();

 
 
        new const Double a = 0;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SeriesVectorData()
        {
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SeriesVectorData(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
 
        #region IDataConsumer Members

        void IChildren<IMeasurements>.AddChild(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
        }

        void IChildren<IMeasurements>.RemoveChild(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            measurements.UpdateMeasurements(true);
        }

        int IDataConsumer.Count
        {
            get { return measurements.Count; }
        }

        IMeasurements IDataConsumer.this[int n]
        {
            get { return measurements[n]; }
        }

        void IDataConsumer.Reset()
        {
        }

        event Action IDataConsumer.OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        #endregion

        #region IPostSetArrow Members

        /// <summary>
        /// The operation that performs after arrows setting
        /// </summary>
        public void PostSetArrow()
        {
            xm = this.FindMeasurement(X, true);
            ym = this.FindMeasurement(Y, true);
        }

        #endregion

        #region Members

        /// <summary>
        /// List of measurements
        /// </summary>
        public List<string> Measurements
        {
            get
            {
                List<string> l = new List<string>();
                Dictionary<string, object> d = this.GetAllMeasurementsType();
                foreach (string s in d.Keys)
                {
                    object t = d[s];
                    if (!(t is ArrayReturnType))
                    {
                        continue;
                    }
                    ArrayReturnType at = t as ArrayReturnType;
                    if (at.ElementType.Equals(a))
                    {
                        l.Add(s);
                    }
                }
                return l;
            }
        }

        /// <summary>
        /// Sets measurements
        /// </summary>
        /// <param name="x">Abscissa</param>
        /// <param name="y">Ordinate</param>
        public void Set(string x, string y)
        {
            X = x;
            Y = y;
            PostSetArrow();
        }

        /// <summary>
        /// Updates itself
        /// </summary>
        public void Update()
        {
            points.Clear();
            if ((xm == null) | (ym == null))
            {
                return;
            }
            this.FullReset();
            IDataConsumer dc = this;
            dc.UpdateChildrenData();
            object ox = xm.Parameter();
            object oy = ym.Parameter();
            try
            {

            double[] x = ox as double[];
                 if (x == null)
                {
                    object[] obx = ox as object[];
                    x = new double[obx.Length];
                    for (int i = 0; i < x.Length; i++)
                    {
                        x[i] = (double)obx[i];
                    }
                }
                double[] y = oy as double[];
                if (y == null)
                {
                    object[] oby = oy as object[];
                    y = new double[oby.Length];
                    for (int i = 0; i < y.Length; i++)
                    {
                        y[i] = (double)oby[i];
                    }
                }
  
            if (x == null | y == null)
            {
                return;
            }
            int n = x.Length;
            if (y.Length < n)
            {
                n = y.Length;
            }
            for (int i = 0; i < n; i++)
            {
                double[] p = new double[] { x[i], y[i] };
                points.Add(p);
            }
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }

        #endregion

        #region INamedCoordinates Members

        IList<string> INamedCoordinates.GetNames(string coordinateName)
        {
            return Measurements;
        }

        string INamedCoordinates.X
        {
            get 
            {
                Series s = this;
                return s.X;
            }
        }

        string INamedCoordinates.Y
        {
            get 
            {
                Series s = this;
                return s.Y;
            }
        }

        IEnumerable<IMeasurements> IChildren<IMeasurements>.Children => measurements;

        void INamedCoordinates.Set(string x, string y)
        {
            X = x;
            Y = y;
            PostSetArrow();
            Update();
        }

        #endregion
    }
}
