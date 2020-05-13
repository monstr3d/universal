using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using BaseTypes;
using BaseTypes.Interfaces;
using BaseTypes.Attributes;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI;

using SerializationInterface;

using DataPerformer.Interfaces;

namespace DynamicAtmosphere.MSISE.Wrapper
{
    /// <summary>
    /// Dynamic atmosphere (MSISE)/ Integrated version
    /// </summary>
    [Serializable()]
    public class Atmosphere : MSISE.Atmosphere,
        ICategoryObject, ISerializable, IObjectTransformer,
        IPropertiesEditor, ISeparatedAssemblyEditedObject,
        IAlias, IAliasConsumer
    {
        #region Fields

        private object obj;

        private byte[] assemblyBytes;

        ISeparatedPropertyEditor editor;

        IAlias alias;

        double[] vector = new double[3];

        double[] temperature = new double[2];

        double[] density = new double[9];

        Dictionary<string, Tuple<object, Action<object>, Func<object>>> dAlias;

        event Action<IAlias, string> onChange = (IAlias a, string n) => { };

        const Double type = 0;

        #region Static Fields

        static private readonly string[] sins = new string[] { "Time", "X", "Y", "Z" };

        static private readonly string[] sous = new string[] { "Density", "Temperature" };
 
        static private Dictionary<int, Tuple<string, object>>[] types;

        #endregion

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Atmosphere()
        {
            Init();
            f107 = 150;
            f107A = 140;
            ap = 6;
            for (int i = 0; i < ap_a.Length; i++)
            {
                ap_a[i] = 6;
            }
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Atmosphere(SerializationInfo info, StreamingContext context)
        {
            Init();
            (this as IPropertiesEditor).Properties =
                 info.Deserialize<object>("Properties");
        }

        /// <summary>
        /// Static constructor
        /// </summary>
        static Atmosphere()
        {

            types = new Dictionary<int, Tuple<string, object>>[]
            {
                new Dictionary<int, Tuple<string, object>>()
                {
                    {0, new Tuple<string, object>(sins[0], FixedTypes.DateTimeType)},
                    {1, new Tuple<string, object>(sins[1], FixedTypes.Double)},
                    {2, new Tuple<string, object>(sins[2], FixedTypes.Double)},
                    {3, new Tuple<string, object>(sins[3], FixedTypes.Double)},
                },
                new Dictionary<int, Tuple<string, object>>()
                {

                                  {0, new Tuple<string, object>(sous[0], new ArrayReturnType(FixedTypes.Double, new int[]{9}, false))},
                                  {1, new Tuple<string, object>(sous[1], new ArrayReturnType(FixedTypes.Double, new int[]{2}, false))},
                 }

            };
        }


        #endregion

        #region ICategoryObject Members

        object IAssociatedObject.Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
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
                Tuple<byte[], PhysicalUnitTypeAttribute, double, double, double, double[], int[]>
                    tuple =
                    new Tuple<byte[], PhysicalUnitTypeAttribute, double, double, double, double[], int[]>
                    (assemblyBytes, physicalType, f107A, f107, ap, ap_a, switches);

                return tuple;
            }
            set
            {
                Tuple<byte[], PhysicalUnitTypeAttribute, double, double, double, double[], int[]>
                    tuple = value as
                    Tuple<byte[], PhysicalUnitTypeAttribute, double, double, double, double[], int[]>;
                assemblyBytes = tuple.Item1;
                (this as IPhysicalUnitTypeAttribute).PhysicalUnitTypeAttribute = tuple.Item2;
                f107A = tuple.Item3;
                f107 = tuple.Item4;
                ap = tuple.Item5;
                ap_a = tuple.Item6;
                Switches = tuple.Item7;
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
            return types[0][i].Item2;
        }

        object IObjectTransformer.GetOutputType(int i)
        {
            return types[1][i].Item2;
        }

        void IObjectTransformer.Calculate(object[] input, object[] output)
        {
            DateTime time = (DateTime)input[0];
            for (int i = 0; i < 3; i++)
            {
                vector[i] = (double)input[i + 1];
            }
            Calculate(time, vector, density, temperature);
            output[0] = density;
            output[1] = temperature;
        }

        #endregion

        #region ISeparatedAssemblyEditedObject Members

        byte[] ISeparatedAssemblyEditedObject.AssemblyBytes
        {
            get
            {
                return assemblyBytes;
            }
            set
            {
                assemblyBytes = value;
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
            get { return dAlias.Keys.ToList<string>(); }
        }

        object IAlias.this[string name]
        {
            get
            {
                return dAlias[name].Item3();
            }
            set
            {
                dAlias[name].Item2(value);
            }
        }

        object IAlias.GetType(string name)
        {
            return dAlias[name].Item1;
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
            if (alias == null)
            {
                return;
            }
            if (this.alias != null)
            {
                throw new Exception("Alias already exixts");
            }
            this.alias = alias;
            Change(alias, null);
            
            //=============== Export of event handler  ==================
            alias.OnChange += Change;
        }

        void IAliasConsumer.Remove(IAlias alias)
        {
            alias.OnChange -= Change;
            this.alias = null;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Alias
        /// </summary>
        public IAlias Alias
        {
            get
            {
                return alias;
            }
        }

        #endregion

        #region Private Memders

        void Change(IAlias alias, string name)
        {
            // ================ Import of parameters ==================
            IAlias al = this;
            List<string> own = al.AliasNames.ToList<string>();
            List<string> external = alias.AliasNames.ToList<string>();
            for (int i = 0; i < external.Count; i++)
            {
                string n = external[i];
                if (dAlias.ContainsKey(n))
                {
                    if (al.GetType(n).Equals(alias.GetType(n)))
                    {
                        al[n] = alias[n];
                    }
                }
            }
            if (!external.Contains("Ap_a") & external.Contains("Ap"))
            {
                if (alias.GetType("Ap").Equals((double)0))
                {
                    double x = (double)alias["Ap"];
                    for (int i = 0; i < ap_a.Length; i++)
                    {
                        ap_a[i] = x;
                    }
                }
            }
        }


        void Init()
        {
            double a = 0;
            dAlias = new Dictionary<string, Tuple<object, Action<object>, Func<object>>>()
            {
                 {"F10_7", new Tuple<object, Action<object>, Func<object>>(0, 
                     (object o) => {f107 = (double)o;}, () => { return f107;})}, 
                 {"F10_7A", new Tuple<object, Action<object>, Func<object>>(0, 
                     (object o) => {f107A = (double)o;}, () => { return f107A;})}, 
                 {"Ap", new Tuple<object, Action<object>, Func<object>>(0, 
                     (object o) => {ap = (double)o;}, () => { return ap;})}, 
               {"Ap_a", new Tuple<object, Action<object>, Func<object>>(new ArrayReturnType(a, new int[]{ 7}, false),
                     (object o) => {ap_a = (double[])o;}, () => { return ap_a;})}, 
             };
        }

        #endregion

    }
}
