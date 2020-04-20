using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;

using Diagram.UI;

using BaseTypes;

using DataPerformer.Interfaces;
using DataPerformer.Portable;


namespace DataPerformer
{
    /// <summary>
    /// Transformer of objects
    /// </summary>
    [Serializable()]
    public class ObjectTransformer : CategoryObject, ISerializable, 
        IDataConsumer, IMeasurements, IPostSetArrow, IObjectTransformerConsumer
    {

        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        /// <summary>
        /// This object as IObjectTransformer
        /// </summary>
        protected IObjectTransformer transformer;

        /// <summary>
        /// Input
        /// </summary>
        protected object[] input;

        /// <summary>
        /// Output measurements
        /// </summary>
        protected IMeasurement[] outMea;

        /// <summary>
        /// Input measurements
        /// </summary>
        protected IMeasurement[] inMea;

        /// <summary>
        /// Input objects
        /// </summary>
        protected object[] inO;

        /// <summary>
        /// Output objects
        /// </summary>
        protected object[] outO;

        /// <summary>
        /// Single output
        /// </summary>
        protected object[] outS;

        /// <summary>
        /// Single input
        /// </summary>
        protected object[] inS;

        /// <summary>
        /// The "is updated" sign
        /// </summary>
        protected bool isUpdated = false;

       /// <summary>
       /// External measurements
       /// </summary>
        protected List<IMeasurements> mea = new List<IMeasurements>();

        /// <summary>
        /// Links to variables
        /// </summary>
        protected Dictionary<string, string> links = new Dictionary<string, string>();

        /// <summary>
        /// Providers of measurements
        /// </summary>
        protected List<IMeasurements> providers;

        private Action act; 

        private IDataConsumer cons;

        private ArrayReturnType art;

        /// <summary>
        /// Is serialized sign
        /// </summary>
        private bool isSerialized = false;

  
        #endregion

        #region Constructros

        /// <summary>
        /// Default constructor
        /// </summary>
        public ObjectTransformer()
        {
            cons = this;
            act = () => 
            {
                transformer.Calculate(inO, outO);
            };
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public ObjectTransformer(SerializationInfo info, StreamingContext context)
            : this()
        {
            isSerialized = true;
            links = info.GetValue("Links", typeof(Dictionary<string, string>))
                as Dictionary<string, string>;
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Links", links, typeof(Dictionary<string, string>));
        }

        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            mea.Add(measurements);
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            mea.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            try
            {
                foreach (IMeasurements m in mea)
                {
                    m.UpdateMeasurements();
                }
            }
            catch (Exception e)
            {
                e.ShowError(10);
                this.Throw(e);
            }
        }

        int IDataConsumer.Count
        {
            get { return mea.Count; }
        }

        IMeasurements IDataConsumer.this[int n]
        {
            get { return mea[n]; }
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

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return outMea.Length; }
        }

        IMeasurement IMeasurements.this[int n]
        {
            get { return outMea[n]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            try
            {
                if (isUpdated)
                {
                    return;
                }
                for (int i = 0; i < inO.Length; i++)
                {
                    inO[i] = inMea[i].Parameter();
                }
                act();
                isUpdated = true;
            }
            catch (Exception e)
            {
                e.ShowError(10);
                this.Throw(e);
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

        #region IObjectTransformerConsumer Members

        void IObjectTransformerConsumer.Add(IObjectTransformer transformer)
        {
            if (this.transformer != null)
            {
                throw new Exception();
            }
            this.transformer = transformer;
            InitTransformer();

        }

        void IObjectTransformerConsumer.Remove(IObjectTransformer transformer)
        {
            this.transformer = null;
        }

        #endregion

        #region IPostSetArrow Members

        /// <summary>
        /// The operation that performs after arrows setting
        /// </summary>
        public void PostSetArrow()
        {
            isSerialized = false;
            InitTransformer();
            Links = links;
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Child transformer
        /// </summary>
        public IObjectTransformer Transformer
        {
            get
            {
                return transformer;
            }
        }

        /// <summary>
        /// Dictionary of links
        /// </summary>
        public Dictionary<string, string> Links
        {
            get
            {
                return links;
            }
            set
            {
                if (inO.Length != value.Count)
                {
                    this.Throw(new Exception("Undefined input"));
                }
                SetLinks(value);
                links = value;
            }
        }

        /// <summary>
        /// List of all measurements
        /// </summary>
        public List<string> AllMeasurements
        {
            get
            {
                IDataConsumer c = this;
                List<string> list = new List<string>();
                for (int i = 0; i < c.Count; i++)
                {
                    IMeasurements m = c[i];
                    IAssociatedObject ao = m as IAssociatedObject;
                    string on = this.GetRelativeName(ao) + ".";
                    for (int j = 0; j < m.Count; j++)
                    {
                        string s = on + m[j].Name;
                        list.Add(s);
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// Sets links
        /// </summary>
        /// <param name="links">Dictionary of links</param>
        protected void SetLinks(Dictionary<string, string> links)
        {
            art = null;
            act = () => 
            {
                transformer.Calculate(inO, outO);
            };
            Dictionary<string, int> d = new Dictionary<string, int>();
            string[] inst = transformer.Input;
            for (int i = 0; i < inst.Length; i++)
            {
                d[inst[i]] = i;
            }
            foreach (string key in links.Keys)
            {
                int n = d[key];
                object type = transformer.GetInputType(n);
                string val = links[key];
                IMeasurement m = Find(val);
                if (!type.Equals(m.Type))
                {
                    if (m.Type is ArrayReturnType)
                    {
                        art = m.Type as ArrayReturnType;
                        if (!art.ElementType.Equals(type))
                        {
                            this.Throw(new Exception("Illegal type"));
                        }
                    }
                }
                inMea[n] = m;
            }
            if (art != null)
            {
                CreateAction();
            }
        }

        /// <summary>
        /// Finds measure by name
        /// </summary>
        /// <param name="name">Measure name</param>
        /// <returns>The measure</returns>
        protected IMeasurement Find(string name)
        {
            int n = name.LastIndexOf(".");
            if (n < 0)
            {
                return null;
            }
            string cn = name.Substring(0, n);
            string suff = name.Substring(n + 1);
            for (int i = 0; i < mea.Count; i++)
            {
                IMeasurements m = mea[i];
                IAssociatedObject ao = m as IAssociatedObject;
                string na = this.GetRelativeName(ao);
                if (cn.Equals(na))
                {
                    for (int j = 0; j < m.Count; j++)
                    {
                        IMeasurement ms = m[j];
                        if (suff.Equals(ms.Name))
                        {
                            return ms;
                        }
                    }
                }
            }
            return null;
        }


        /// <summary>
        /// Initialization
        /// </summary>
        protected void InitTransformer()
        {
            if (isSerialized)
            {
                return;
            }
            string[] outS = transformer.Output;
            if (outO == null)
            {
                outO = new object[outS.Length];
            }
            if (outO.Length != outS.Length)
            {
                outO = new object[outS.Length];
            }
            outMea = new IMeasurement[outO.Length];
            inMea = new IMeasurement[transformer.Input.Length];
            inO = new object[inMea.Length];
            CreateOutput();
       }


        private void CreateOutput()
        {
            string[] outS = transformer.Output;
            for (int i = 0; i < outS.Length; i++)
            {
                string name = outS[i];
                object type = GetOutputType(i);
                outMea[i] = new TransMeasurement(i, outO, name, type);
            }
        }

        private object GetOutputType(int i)
        {
            if (art == null)
            {
                return transformer.GetOutputType(i);
            }
            return new ArrayReturnType(transformer.GetOutputType(i), art.Dimension, true);
       }

        void CreateAction()
        {
            int[] dim = art.Dimension;
            inS = new object[transformer.Input.Length];
            outS = new object[transformer.Output.Length];
            for (int i = 0; i < outO.Length; i++)
            {
                outO[i] = new object[dim[0]];
            }
            act = ArrayAction;
            CreateOutput();
        }


        void ArrayAction()
        {
            int[] dim = art.Dimension;
            for (int i = 0; i < dim[0]; i++)
            {
                for (int j = 0; j < inO.Length; j++)
                {
                    object ob = inMea[j].Parameter();
                    if (ob is Array)
                    {
                        Array arr = ob as Array;
                        inS[j] = arr.GetValue(i);
                    }
                    else
                    {
                        inS[j] = ob;
                    }
                }
                transformer.Calculate(inS, outS);
                for (int j = 0; j < outS.Length; j++)
                {
                    Array ar = outO[j] as Array;
                    ar.SetValue(outS[j], i);
                }
            }
        }



        #endregion

        #region Transtitional Measurement Class

        class TransMeasurement : IMeasurement
        {
            int n;
            object[] outO;
            string name;
            object type;

            Func<object> par;

            internal TransMeasurement(int n, object[] outO, string name, object type)
            {
                this.n = n;
                this.outO = outO;
                this.name = name;
                this.type = type;
                par = () => { return outO[n]; };
            }

 
            #region IMeasurement Members

            Func<object> IMeasurement.Parameter
            {
                get { return par; }
            }

            string IMeasurement.Name
            {
                get { return name; }
            }

            object IMeasurement.Type
            {
                get { return type; }
            }

            #endregion
        }

        #endregion

    }
}
