using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;

using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

using Motion6D.Interfaces;



namespace InterfaceOpenGL
{
    /// <summary>
    /// Deformed Shape
    /// </summary>
    [Serializable()]
    public class DeformedShapeGL : ShapeGL, IDataConsumer, IVisibleConsumer, IPostSetArrow
    {
        #region Fields


        #region Add Remove Events

        /// <summary>
        /// Add event
        /// </summary>
        event Action<IVisible> onAdd = (IVisible v) => { };

        /// <summary>
        /// Remove event
        /// </summary>
        event Action<IVisible> onRemove = (IVisible v) => { };

        /// <summary>
        /// Post event
        /// </summary>
        event Action<IVisible> onPost = (IVisible v) => { };

        #endregion


        private ShapeGL source;

        private IMeasurement[] m = new IMeasurement[3];

        private AlName[] al = new AlName[3];

        private IList<IMeasurements> measurements = new List<IMeasurements>();

        private string[] output = new string[3];

        private string[] input = new string[3];

        #endregion

        #region Ctor

        internal DeformedShapeGL()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DeformedShapeGL(SerializationInfo info, StreamingContext context)
        {
            input = info.GetValue("Input", typeof(string[])) as string[];
            output = info.GetValue("Output", typeof(string[])) as string[];
        }

        #endregion

        #region Overriden Members

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Input", input, typeof(string[]));
            info.AddValue("Output", output, typeof(string[]));
        }


        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            foreach (IMeasurements m in measurements)
            {
                m.UpdateMeasurements();
            }
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
            this.FullReset();
        }

        event Action IDataConsumer.OnChangeInput
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }


        #endregion

        #region IVisibleConsumer Members

        void IVisibleConsumer.Add(IVisible visible)
        {
            if (source != null)
            {
                throw new Exception("Source already exists");
            }
            source = visible as ShapeGL;
            onAdd(visible);
        }

        void IVisibleConsumer.Remove(IVisible visible)
        {
            source = null;
            facetCoordinates = null;
            onRemove(visible);
        }

        void IVisibleConsumer.Post(IVisible visible)
        {
            onPost(visible);
        }

        event Action<IVisible> IVisibleConsumer.OnAdd
        {
            add { onAdd += value; }
            remove { onAdd -= value; }
        }

        event Action<IVisible> IVisibleConsumer.OnRemove
        {
            add { onRemove += value; }
            remove { onRemove -= value; }
        }

        event Action<IVisible> IVisibleConsumer.OnPost
        {
            add { onPost += value; }
            remove { onPost -= value; }
        }


        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            All();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Input and output data
        /// </summary>
        public string[][] Data
        {
            get
            {
                return new string[][] { input, output };
            }
            set
            {
                input = value[0];
                output = value[1];
                All();
            }
        }

        #endregion

        #region Private Members

        void All()
        {
            Find();
            Create();
        }

        bool Find()
        {
            IDataConsumer cons = this;
            foreach (string s in input)
            {
                if (s == null)
                {
                    return false;
                }
            }
            foreach (string s in output)
            {
                if (s == null)
                {
                    return false;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                object[] o = cons.FindAlias(input[i]);
                IAlias a = o[0] as IAlias;
                string n = o[1] as string;
                AlName an = new AlName();
                an.alias = a;
                an.name = n;
                al[i] = an;
            }
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = this.FindMeasurement(output[i], true);
            }
            return true;
        }


        private void Create()
        {
            if (source == null)
            {
                return;
            }
            IDataConsumer cons = this;
            if (source == null)
            {
                return;
            }
            if (source.facetCoordinates == null)
            {
                return;
            }
            facetNumber = source.facetNumber;
            facetCoordinates = new double[12 * facetNumber];
            foreach (AlName an in al)
            {
                if (an.alias == null)
                {
                    return;
                }
                if (an.name == null)
                {
                    return;
                }
            }
            foreach (IMeasurement mea in m)
            {
                if (mea == null)
                {
                    return;
                }
            }
            for (int i = 0; i < facetNumber; i++)
            {
                int j = 12 * i;
                for (int k = 0; k < 3; k++)
                {
                    int jj = j + 3 * k;
                    for (int l = 0; l < 3; l++)
                    {
                        al[l].alias[al[l].name] = source.facetCoordinates[jj + l];
                    }
                    cons.UpdateChildrenData();
                    for (int l = 0; l < 3; l++)
                    {
                        facetCoordinates[jj + l] = (double)m[l].Parameter();
                    }
                    this.FullReset();
                }
            }
            shape.Set(facetNumber, facetCoordinates);
        }


        #endregion

        #region Auxilary class
        struct AlName
        {
            internal IAlias alias;
            internal string name;
        }
        #endregion


    }
}
