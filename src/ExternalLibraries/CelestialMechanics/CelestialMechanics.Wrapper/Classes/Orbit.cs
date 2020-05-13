using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using BaseTypes;
using BaseTypes.Interfaces;
using BaseTypes.Attributes;

using Diagram.UI;
using Diagram.UI.Interfaces;


using SerializationInterface;

using DataPerformer.Interfaces;
using DataPerformer;

using Event.Interfaces;
using Event.Portable.Interfaces;

namespace CelestialMechanics.Wrapper.Classes
{
    /// <summary>
    /// Orbit
    /// </summary>
    [Serializable()]
    public class Orbit : CategoryObject, IObjectTransformer,
        IPhysicalUnitTypeAttribute, IAliasConsumer, IPropertiesEditor,
        ISeparatedAssemblyEditedObject, IAlias, ISerializable, IRealtimeStart,  IAddRemove, IPostSetArrow
    {

        #region Fields


        Action<object> addAction = (object obj) => { };

        Action<object> removeAction = (object obj) => { };

        /// <summary>
        /// Gravity constant physical unit dictionary
        /// </summary>
        private static readonly Dictionary<Type, int> GravityConstUnit =
            new Dictionary<Type, int>()
            {
              {typeof(LengthType), 3},
             {typeof(MassType), -1},
             {typeof(TimeType), -2},
            };


        private static readonly PhysicalUnitTypeAttribute StandardGravityConstUnit =
            new PhysicalUnitTypeAttribute();

        private static readonly PhysicalUnitTypeAttribute DayUnit =
         new PhysicalUnitTypeAttribute(timeType: TimeType.Day);


        private Tuple<TransfomationType, PhysicalUnitTypeAttribute,
       bool, double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>> tuple =
   new Tuple<TransfomationType, PhysicalUnitTypeAttribute,
       bool, double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>>(TransfomationType.TimeToMotion,
       new PhysicalUnitTypeAttribute(timeType: TimeType.Day),
       true, 5.9736E24, new double[] { 7047892.6, 0.0015709, 1.71, 4.71, 3.22, 5.84 }, null, DateTime.Now,
       new Tuple<Dictionary<int, string>, double[]>(new Dictionary<int, string>(), new double[2]));

        Dictionary<int, Tuple<IAlias, string>> connect = new Dictionary<int, Tuple<IAlias, string>>();

        ISeparatedPropertyEditor editor;

        List<IAlias> measuremets = new List<IAlias>();

        static private readonly Dictionary<TransfomationType, string[]> inputs =
       new Dictionary<TransfomationType, string[]>()
            {
               { TransfomationType.TimeToMotion,  new string[] { "Date Time" }},
               { TransfomationType.ParametersToObtit, 
                   new string[] { "x", "y", "z", "Vx", "Vy", "Vz", "Date Time"  }},
              { TransfomationType.OrbitToParameters,
                   new string[] { 
                                     "Pericenter Distance",
        "Eccentricity",
        "Inclination",
        "Ascending Node",
        "Argument Of Periapsis",
        "Mean Anomaly At Epoch",
        "Epoch"
  }}
            };

        static private readonly Dictionary<TransfomationType, string[]> outputs =
 new Dictionary<TransfomationType, string[]>()
            {
               { TransfomationType.TimeToMotion,  new string[] { "x", "y", "z", "Vx", "Vy", "Vz" }},
              { TransfomationType.ParametersToObtit,
                   new string[] { 
                                     "Pericenter Distance",
        "Eccentricity",
        "Inclination",
        "Ascending Node",
        "Argument Of Periapsis",
        "Mean Anomaly At Epoch",
        "Period"
  }},
              { TransfomationType.OrbitToParameters, 
                   new string[] { "x", "y", "z", "Vx", "Vy", "Vz", "Date Time"  }}
             };
        internal static readonly Dictionary<string, Dictionary<Type, int>> AliasNames =
  new Dictionary<string, Dictionary<Type, int>>()
       {
            {"Eccentricity", null},
            {"Inclination", new Dictionary<Type, int>(){{typeof(AngleType), 1}}},
            {"Ascending Node",  new Dictionary<Type, int>(){{typeof(AngleType), 1}}},
            {"Argument Of Periapsis",  new Dictionary<Type, int>(){{typeof(AngleType), 1}}},
            {"Mean Anomaly At Epoch",  new Dictionary<Type, int>(){{typeof(AngleType), 1}}},
            {"FD MeanMotion", null},
            {"SD MeanMotion", null},
            {"Mean Motion", new Dictionary<Type, int>{{typeof(AngleType), 1}, {typeof(TimeType), -1}}},
            {"Mass", new Dictionary<Type, int>(){{typeof(MassType), 1}}},
            {"Epoch",  null}
        };


        private static readonly Dictionary<TransfomationType, object[]> inputTypes =
            new Dictionary<TransfomationType, object[]>()
            {
                { TransfomationType.TimeToMotion,  new object[] { FixedTypes.DateTimeType }},
               { TransfomationType.ParametersToObtit, 
                   new object[] { 
                       FixedTypes.Double, FixedTypes.Double,
                       FixedTypes.Double, FixedTypes.Double,
                       FixedTypes.Double, FixedTypes.Double,
                       FixedTypes.DateTimeType }},
              { TransfomationType.OrbitToParameters,new object[] { FixedTypes.Double, FixedTypes.Double,
                       FixedTypes.Double, FixedTypes.Double,
                       FixedTypes.Double, FixedTypes.Double,
                       FixedTypes.DateTimeType }}
           };


        private static readonly Dictionary<TransfomationType, object[]> outputTypes =
         new Dictionary<TransfomationType, object[]>()
         {
               { TransfomationType.TimeToMotion,  new object[] 
{
               FixedTypes.Double, FixedTypes.Double,
                       FixedTypes.Double, FixedTypes.Double,
                       FixedTypes.Double, FixedTypes.Double}
                       },
              { TransfomationType.ParametersToObtit,
                   new object[] {
               FixedTypes.Double, FixedTypes.Double,
                       FixedTypes.Double, FixedTypes.Double,
                       FixedTypes.Double, FixedTypes.Double, FixedTypes.DateTimeType}
                      
},
               { TransfomationType.OrbitToParameters, 
                   new object[] {
               FixedTypes.Double, FixedTypes.Double,
                       FixedTypes.Double, FixedTypes.Double,
                       FixedTypes.Double, FixedTypes.Double, FixedTypes.DateTimeType}}
         };


        double[] position = new double[3];

        double[] velocity = new double[3];

        IAlias alias;

        protected CelestialMechanics.Orbit orbit;

        static private readonly string[] aliases = new string[]
            {
                "Pericenter Distance",
        "Eccentricity",
        "Inclination",
        "Ascending Node",
        "Argument Of Periapsis",
        "Mean Anomaly At Epoch",
        "Period",
        "Mean Motion",
        "Mass",
        "Epoch"
              };

        const string Epoch = "Epoch";


        double[] vector = new double[6];


        Func<DateTime, double> calculateTime;

        Dictionary<TransfomationType, Action<object[], object[]>> functions;

        event Action<IAlias, string> onChange = (IAlias alias, string name) => { };

        private static List<string> aliasList;


        private double firstDer;

        private double secondDer;

        private Dictionary<IAlias, Dictionary<string, object[]>> exports =
            new Dictionary<IAlias, Dictionary<string, object[]>>();

        private object[] outputBuffer = new object[6];

        bool isSerialized = false;

        double timeCoefficient = 1;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor by string
        /// </summary>
        /// <param name="str">String</param>
        public Orbit(string str)
            : this()
        {
            CreateOrbit();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Orbit()
        {
            calculateTime = CalculateTime;
            functions = new Dictionary<TransfomationType, Action<object[], object[]>>()
            {
                {TransfomationType.TimeToMotion, TimeToMotion},
                {TransfomationType.OrbitToParameters, OrbitToParameters},
                {TransfomationType.ParametersToObtit, ParametersToObtit}
            };
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Orbit(SerializationInfo info, StreamingContext context)
            : this()
        {
            (this as IPropertiesEditor).Properties =
                info.Deserialize<object>("Properties");
            isSerialized = true;
        }

        static Orbit()
        {
            aliasList = aliases.ToList<string>();
            aliasList.Add(Epoch);
        }


        #endregion

        #region IObjectTransformer Members

        string[] IObjectTransformer.Input
        {
            get { return inputs[tuple.Item1]; }
        }

        string[] IObjectTransformer.Output
        {
            get { return outputs[tuple.Item1]; }
        }

        object IObjectTransformer.GetInputType(int i)
        {
            return inputTypes[tuple.Item1][i];
        }

        object IObjectTransformer.GetOutputType(int i)
        {
            return outputTypes[tuple.Item1][i];
        }

        void IObjectTransformer.Calculate(object[] input, object[] output)
        {
            functions[tuple.Item1](input, output);
        }

        #endregion

        #region IAlias Members

        IList<string> IAlias.AliasNames
        {
            get { return aliases.ToList<string>(); }
        }

        object IAlias.this[string name]
        {
            get
            {
                int k = aliasList.IndexOf(name);
                if (k < 6)
                {
                    return tuple.Item5[k];
                }
                if (k == 6)
                {
                    return orbit.Period;
                }
                if (k == 7)
                {
                    return AngleType.Circle.Convert(tuple.Item2.AngleType, (1 / orbit.Period));
                }
                if (k == 8)
                {
                    return tuple.Item3;
                }
                return tuple.Item7;
            }
            set
            {
                int k = aliasList.IndexOf(name);
                if (k < 6)
                {
                    tuple.Item5[k] = (double)value;
                    Tuple = tuple;
                    return;
                }
                if (k == 8)
                {
                    Tuple =
                        new Tuple<TransfomationType, PhysicalUnitTypeAttribute, bool, double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>>
                        (tuple.Item1, tuple.Item2, tuple.Item3, (double)value,
                        tuple.Item5, tuple.Item6, tuple.Item7, tuple.Rest);
                    return;
                }
                if (k == 9)
                {
                    Tuple =
                         new Tuple<TransfomationType, PhysicalUnitTypeAttribute, bool, double, double[], byte[], DateTime,
                            Tuple<Dictionary<int, string>, double[]>>
                         (tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4,
                         tuple.Item5, tuple.Item6, (DateTime)value, tuple.Rest);
                    return;
                }
                throw new Exception("Illegal setting of orbita \"" + name + "\" alias");
            }
        }

        object IAlias.GetType(string name)
        {
            if (name.Equals(Epoch))
            {
                return FixedTypes.DateTimeType;
            }
            return FixedTypes.Double;
        }

        event Action<IAlias, string> IAlias.OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        #endregion

        #region IPhysicalUnitTypeAttribute Members

        PhysicalUnitTypeAttribute IPhysicalUnitTypeAttribute.PhysicalUnitTypeAttribute
        {
            get
            {
                return tuple.Item2;
            }
            set
            {
                if (tuple.Item2.Equals(value))
                {
                    return;
                }
                Dictionary<string, double> d = this.ConvertPhysicalUnits(tuple.Item2,
                    value);
                double[] p = tuple.Item5;
                for (int i = 0; i < 6; i++)
                {
                    p[i] = d[aliases[i]];
                }
                Tuple =
                    new Tuple<TransfomationType, PhysicalUnitTypeAttribute,
                    bool, double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>>
                    (tuple.Item1, value, tuple.Item3,
                    (double)d["Mass"], p, tuple.Item6, tuple.Item7, tuple.Rest);
            }
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
            alias.OnChange += Change;
        }

        void IAliasConsumer.Remove(IAlias alias)
        {
            if (alias != this.alias)
            {
                throw new Exception("Alias does not same");
            }
            alias.OnChange -= Change;
            this.alias = null;
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
                return Tuple;
            }
            set
            {
                Tuple = value as Tuple<TransfomationType, PhysicalUnitTypeAttribute,
            bool, double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>>;
            }
        }

        #endregion

        #region ISeparatedAssemblyEditedObject Members

        byte[] ISeparatedAssemblyEditedObject.AssemblyBytes
        {
            get
            {
                return tuple.Item6;
            }
            set
            {
                tuple = new Tuple<TransfomationType, PhysicalUnitTypeAttribute,
              bool, double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>>(tuple.Item1,
                 tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5,
                 value, tuple.Item7, tuple.Rest);

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

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<object>("Properties", (this as IPropertiesEditor).Properties);
        }

        #endregion

        #region IRealTimeStartStop Members

        Dictionary<IAlias, Dictionary<string, object[]>> IRealtimeStart.StartAlias
        {
            get
            {
                exports.Clear();
                TimeToMotion(DateTime.Now, outputBuffer);
                foreach (int key in connect.Keys)
                {
                    Tuple<IAlias, string> t = connect[key];
                    IAlias al = t.Item1;
                    Dictionary<string, object[]> d;
                    if (exports.ContainsKey(al))
                    {
                        d = exports[al];
                    }
                    else
                    {
                        d = new Dictionary<string, object[]>();
                        exports[al] = d;
                    }
                    d[t.Item2] = new object[] { outputBuffer[key], null };
                }
                return exports;
            }
        }

        bool IRealtimeStart.IsEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Exports
        /// </summary>
        public List<string> Exports
        {
            get
            {
                List<string> l = new List<string>();
                if (tuple.Item1 != TransfomationType.TimeToMotion)
                {
                    return l;
                }
                double a = 0;
                foreach (IAlias alias in measuremets)
                {
                    string n = this.GetRelativeName(alias as IAssociatedObject) + '.';
                    IList<string> an = alias.AliasNames;
                    foreach (string key in an)
                    {
                        if (alias.GetType(key).Equals(a))
                        {
                            l.Add(n + key);
                        }
                    }
                }
                return l;
            }
        }

        #endregion

        #region IAddRemove Members

        void IAddRemove.Add(object obj)
        {
            measuremets.Add(obj as IAlias);
            addAction(obj);
        }

        void IAddRemove.Remove(object obj)
        {
            measuremets.Remove(obj as IAlias);
            removeAction(obj);
        }

        Type IAddRemove.Type
        {
            get { return typeof(IAlias); }
        }

        event Action<object> IAddRemove.AddAction
        {
            add { addAction += value; }
            remove { addAction -= value; }
        }

        event Action<object> IAddRemove.RemoveAction
        {
            add { removeAction += value; }
            remove { removeAction -= value; }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            if (isSerialized)
            {
                FindAliases();
                isSerialized = false;
            }
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

        /// <summary>
        /// Tuple of parameters
        /// </summary>
        public Tuple<TransfomationType, PhysicalUnitTypeAttribute,
            bool, double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>> Tuple
        {
            get
            {
                return tuple;
            }
            set
            {
                tuple = value;
                CreateOrbit();
                FindAliases();
            }
        }


        public void OrbitToParameters(
             double pericenterDistance,
            double eccentricity,
            double inclination,
            double ascendingNode,
            double argOfPeriapsis,
            double meanAnomalyAtEpoch,
            double period,
            DateTime epoch,
           DateTime time,
            double[] vector)
        {

            CelestialMechanics.Orbit o =
                new EllipticalOrbit(pericenterDistance,
                    eccentricity, inclination, ascendingNode,
                    argOfPeriapsis, meanAnomalyAtEpoch, period, epoch.DateTimeToDay());
            o.vectorAtTime(time.DateTimeToDay(), vector);
        }

        public void SetMotionParameters(double[] motionParameters, DateTime time)
        {
            double pericenterDistance;
            double eccentricity;
            double inclination;
            double ascendingNode;
            double argOfPeriapsis;
            double meanAnomalyAtEpoch;
            double period;
            Array.Copy(motionParameters, position, 3);
            Array.Copy(motionParameters, 3, velocity, 0, 3);
            EllipticalOrbit.StateVectorToOrbit(position, velocity, GravityConst,
               time.DateTimeToDay(), out eccentricity,
               out pericenterDistance,
                                out inclination,
                                out ascendingNode,
                                out argOfPeriapsis,
                                out meanAnomalyAtEpoch,
                                out period);
            double[] x = tuple.Item5;
            x[0] = pericenterDistance;
            x[1] = eccentricity;
            x[2] = inclination;
            x[3] = ascendingNode;
            x[4] = argOfPeriapsis;
            x[5] = meanAnomalyAtEpoch;
            Tuple = new Tuple<TransfomationType, PhysicalUnitTypeAttribute, bool, double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>>
            (tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4,
            tuple.Item5, tuple.Item6, time, tuple.Rest);
        }


        public void SetOrbitElements(double pericenterDistance,
                                  double eccentricity,
                                  double inclination,
                                  double ascendingNode,
                                  double argOfPeriapsis,
                                  double meanAnomalyAtEpoch,
                                  double period,
                                  DateTime epoch)
        {
            double[] x = tuple.Item5;
            x[0] = pericenterDistance;
            x[1] = eccentricity;
            x[2] = inclination;
            x[3] = ascendingNode;
            x[4] = argOfPeriapsis;
            x[5] = meanAnomalyAtEpoch;
            Tuple = new Tuple<TransfomationType, PhysicalUnitTypeAttribute, bool, double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>>
                     (tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4,
                     tuple.Item5, tuple.Item6, epoch, tuple.Rest);
        }

        /// <summary>
        /// Gets motion parameters
        /// </summary>
        /// <param name="vector">Vector of motion parameters</param>
        public void GetMotionParameters(double[] vector)
        {
            orbit.vectorAtTime(tuple.Item7.DateTimeToDay(), vector);
        }

        /// <summary>
        /// Creates orbit
        /// </summary>
        public void CreateOrbit()
        {
            ChangeOrbitPrivate();
            onChange(this, null);
        }

        /// <summary>
        /// Period
        /// </summary>
        public double Period
        {
            get
            {
                return orbit.Period;
            }
        }

        #endregion

        #region Private Members


        private void ChangeOrbitPrivate()
        {
            timeCoefficient = TimeType.Day.Convert(tuple.Item2.TimeType, 1);
            double[] or = tuple.Item5;
            double period = EllipticalOrbit.PeriodFromPericenterDistance(GravityConst, or[1], or[0]);
            double epoch = tuple.Item7.DateTimeToDay();
            PhysicalUnitTypeAttribute attr = tuple.Item2;
            orbit = new EllipticalOrbit(or[0], or[1], attr.ToRadians(or[2]),
                attr.ToRadians(or[3]), attr.ToRadians(or[4]), attr.ToRadians(or[5]), period, epoch);
            double[] d = tuple.Rest.Item2;
            if (d[0] == 0)
            {
                calculateTime = CalculateTime;
            }
            else
            {
                double meanMotion = (2.0 * Math.PI) / orbit.Period;
                firstDer = meanMotion * d[0];
                if (d[1] == 0)
                {
                    calculateTime = CalculateTimeFD;
                }
                else
                {
                    secondDer = meanMotion * d[1];
                    calculateTime = CalculateTimeSD;
                }
            }

        }


        void FindAliases()
        {
            connect.Clear();
            Dictionary<int, string> d = tuple.Rest.Item1;
            foreach (int key in d.Keys)
            {
                string sn = d[key];
                string a = sn.Substring(0, sn.LastIndexOf('.'));
                string n = sn.Substring(a.Length + 1);
                foreach (IAlias al in measuremets)
                {
                    if (this.GetRelativeName(al as IAssociatedObject).Equals(a))
                    {
                        connect[key] = new Tuple<IAlias, string>(al, n);
                    }
                }
            }
        }


        double CalculateTime(DateTime dt)
        {
            return (dt - tuple.Item7).TotalDays;
        }

        double CalculateTimeFD(DateTime dt)
        {
            double d = (dt - tuple.Item7).TotalDays;
            return d + firstDer * d * d;
        }

        double CalculateTimeSD(DateTime dt)
        {
            double d = (dt - tuple.Item7).TotalDays;
            double d2 = d * d;
            return d + firstDer * d2 + secondDer * d2 * d;
        }

        double GravityConst
        {
            get
            {
                double m = tuple.Item4;
                PhysicalUnitTypeAttribute at = tuple.Item2;
                double k =
                   tuple.Item2.Coefficient(StandardGravityConstUnit, GravityConstUnit);
                return m * k * Astro.G;
            }
        }

    

        void TimeToMotion(DateTime dt, object[] output)
        {
            double d = timeCoefficient * calculateTime(dt);
            orbit.vectorAtTime(d, vector);
            for (int i = 0; i < 6; i++)
            {
                output[i] = vector[i];
            }
        }


        void TimeToMotion(object[] input, object[] output)
        {
            TimeToMotion((DateTime)input[0], output);
        }

        void ParametersToObtit(object[] input, object[] output)
        {
            DateTime dt = (DateTime)input[6];
            double time = dt.DateTimeToDay();
            for (int i = 0; i < 3; i++)
            {
                position[i] = (double)input[i];
                velocity[i] = (double)input[i + 3];
            }
            double pericenterDistance;
            double eccentricity;
            double inclination;
            double ascendingNode;
            double argOfPeriapsis;
            double meanAnomalyAtEpoch;
            double period;
            EllipticalOrbit.StateVectorToOrbit(position, velocity, GravityConst,
               time, out eccentricity,
               out pericenterDistance,
                                out inclination,
                                out ascendingNode,
                                out argOfPeriapsis,
                                out meanAnomalyAtEpoch,
                                out period);

            output[0] = pericenterDistance;
            output[1] = eccentricity;
            output[2] = inclination;
            output[3] = ascendingNode;
            output[4] = argOfPeriapsis;
            output[5] = meanAnomalyAtEpoch;
            output[6] = period;

        }

        void OrbitToParameters(object[] input, object[] output)
        {
            double pericenterDistance = (double)input[0];
            double eccentricity = (double)input[1];
            double inclination = (double)input[2];
            double ascendingNode = (double)input[3];
            double argOfPeriapsis = (double)input[4];
            double meanAnomalyAtEpoch = (double)input[5];
            double period = (double)input[6];
            DateTime epoch = (DateTime)input[7];
            DateTime time = (DateTime)input[8];
            OrbitToParameters(pericenterDistance, eccentricity, inclination, ascendingNode,
                argOfPeriapsis, meanAnomalyAtEpoch, period, epoch, time, vector);
            for (int i = 0; i < 6; i++)
            {
                output[i] = vector[i];
            }
        }


        #endregion

        #region Event handlers

        void Change(IAlias alias, string name)
        {
            PhysicalUnitTypeAttribute source = StaticExtensionBaseTypesExtended.GetPhysicalType(alias);

            IList<string> l = alias.AliasNames;
            try
            {
                Dictionary<string, double> d =
                   alias.ConvertPhysicalUnits(source, tuple.Item2);
                double[] p = tuple.Item5;
                foreach (string key in d.Keys)
                {
                    int k = aliasList.IndexOf(key);
                    if ((k >= 0) & (k < 6))
                    {
                        p[k] = d[key];
                    }
                }
                double period = 2 * Math.PI / d["Mean Motion"];
                p[0] = EllipticalOrbit.PericenterDistanceFromPeriod(GravityConst, d["Eccentricity"], period);
                double[] der = tuple.Rest.Item2;
                string[] str = new string[] { "FD MeanMotion", "SD MeanMotion" };
                for (int i = 0; i < str.Length; i++)
                {
                    string key = str[i];
                    der[i] = d.ContainsKey(key) ? (double)d[key] : 0;
                }
                Tuple = new Tuple<TransfomationType, PhysicalUnitTypeAttribute, bool,
                   double, double[], byte[], DateTime, Tuple<Dictionary<int, string>, double[]>>(
                   tuple.Item1, tuple.Item2, tuple.Item3, d["Mass"], p, tuple.Item6,
                   (DateTime)alias[Epoch], tuple.Rest);
                ChangeOrbitPrivate();
            }
            catch (Exception)
            {
            }
        }

        #endregion

    }

    /// <summary>
    /// Transformation type
    /// </summary>
    public enum TransfomationType
    {
        TimeToMotion,
        ParametersToObtit,
        OrbitToParameters
    }
}
