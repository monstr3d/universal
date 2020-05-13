using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI;

using SerializationInterface;

using DataPerformer.Interfaces;

namespace DynamicAtmosphere.Wrapper
{
    /// <summary>
    /// Atmosphere. Integrated version
    /// </summary>
    [Serializable()]
    public class Atmosphere : CategoryObject, IObjectTransformer, 
        IPropertiesEditor, ISeparatedAssemblyEditedObject,
        IAlias, IAliasConsumer, ISerializable
    {
        #region Fields

        Tuple<byte[], int[]> tuple = new Tuple<byte[], int[]>(null, new int[] { 150, 6, 140 });


        private static readonly Dictionary<string, int> dNames = new Dictionary<string, int>()
        {
            {"F10_7", 0}, { "Ap", 1} , {"F10_7A", 2}
        };

        DynamicAtmosphere.Atmosphere atmosphere = 
            new DynamicAtmosphere.Atmosphere();

        event Action<IAlias, string>  onChange = (IAlias alias, string name) => {};

        private double[] xout = new double[3];

        ISeparatedPropertyEditor editor;

        static private readonly string[] sins = new string[] { "t", "x", "y", "z" };

        static private readonly string[] sous = new string[] { "Density" };

  
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Atmosphere()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Atmosphere(SerializationInfo info, StreamingContext context)
        {
            (this as IPropertiesEditor).Properties =
                 info.Deserialize<object>("Properties");
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<object>("Properties", (this as IPropertiesEditor).Properties);
        }

        #endregion

        #region IPropertiesEditor Members

        object IPropertiesEditor.Editor
        {
            get { return this.GetEditor(); }
        }

        object IPropertiesEditor.Properties
        {
            get
            {
                return tuple;
            }
            set
            {
                tuple = value as Tuple<byte[], int[]>;
                Set();
            }
        }

        #endregion

        #region IObjectTransformer Members

        string[] IObjectTransformer.Input
        {
            get { return sins; }
        }

        string[] IObjectTransformer.Output
        {
            get { return sous; }
        }

        object IObjectTransformer.GetInputType(int i)
        {
            if (i == 0)
            {
                return BaseTypes.FixedTypes.DateTimeType;
            }
             return (double)0;
        }

        object IObjectTransformer.GetOutputType(int i)
        {
            return (double)0;
        }

        void IObjectTransformer.Calculate(object[] input, object[] output)
        {
            DateTime t = (DateTime)input[0];
            for (int i = 0; i < 3; i++)
            {
                xout[i] = (double)input[i + 1];
            }
            double rho = atmosphere.Density(t, xout);
            output[0] = rho;
        }

        #endregion

        #region ISeparatedAssemblyEditedObject Members

        byte[] ISeparatedAssemblyEditedObject.AssemblyBytes
        {
            get
            {
                return tuple.Item1;
            }
            set
            {
                tuple = new Tuple<byte[], int[]>(value, tuple.Item2);
            }
        }

        ISeparatedPropertyEditor ISeparatedAssemblyEditedObject.Editor
        {
            get
            {
                return editor;
            }
            set
            {
                editor = value;
            }
        }

        void ISeparatedAssemblyEditedObject.FirstLoad()
        {
            this.LoadAssembly();
        }

        #endregion

        #region IAlias Members

        IList<string> IAlias.AliasNames
        {
            get { return dNames.Keys.ToList<string>(); }
        }

        object IAlias.this[string name]
        {
            get
            {
                return tuple.Item2[dNames[name]];
            }
            set
            {
                tuple.Item2[dNames[name]] = (int)value;
                Set();
            }
        }

        object IAlias.GetType(string name)
        {
            return (int)0;
        }

        event Action<IAlias, string> IAlias.OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        #endregion

        #region IAliasConsumer Members

        void IAliasConsumer.Add(IAlias alias)
        {
            Change(alias, null);
            alias.OnChange += Change;
        }

        void IAliasConsumer.Remove(IAlias alias)
        {
            alias.OnChange -= Change;
        }

        #endregion

        #region Private Members

        private void Set()
        {
            atmosphere.If = tuple.Item2;
        }

        void Change(IAlias alias, string name)
        {
            IAlias al = this;
            List<string> own = al.AliasNames.ToList<string>();
            List<string> external = alias.AliasNames.ToList<string>();
            for (int i = 0; i < external.Count; i++)
            {
                string n = external[i];
                if (own.Contains(n))
                {
                    int k = own.IndexOf(n);
                    object t = alias.GetType(n);
                    object o = alias[n];
                    if (t.Equals((int)0))
                    {
                       al[n] = o;
                       continue;
                    }
                    if (t.Equals((double)0))
                    {
                        double x = (double)o;
                        al[n] = (int)x;
                    }
                }
            }
        }

        #endregion

    }
}
