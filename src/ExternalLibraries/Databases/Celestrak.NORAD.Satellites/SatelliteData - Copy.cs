using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Reflection;

using CategoryTheory;

using BaseTypes;
using BaseTypes.Interfaces;
using BaseTypes.Attributes;

using Diagram.UI;
using Diagram.UI.Interfaces;

using SerializationInterface;

using DataPerformer.Interfaces;

using Event.Interfaces;


namespace Celestrak.NORAD.Satellites
{
    /// <summary>
    /// Data of satellite
    /// </summary>
    [Serializable()]
    [PhysicalUnitType(AngleType = AngleType.Degree, LengthType = LengthType.Meter,
        MassType = MassType.Kilogram, TimeType = TimeType.Day)]
    public class SatelliteData : CategoryObject, IChildrenObject, IMeasurements, IPropertiesEditor,
        ISeparatedAssemblyEditedObject, IAlias, ISerializable, IPhysicalUnitAlias, IEventHandler
    {

        #region Fields

        public const double EarthMass = 5.9736E24;
   

        string text;

        event Action<string> onChangeUrl = (string url) => { };

        event Action<string> onChangeSatellite = (string satellite) => { };

        ISeparatedPropertyEditor editor;

        Tuple<DateTime, string, string, string[], Dictionary<string, object[]>, byte[], byte[]> tuple =
            new Tuple<DateTime, string, string, string[], Dictionary<string, object[]>, byte[], byte[]>(
                DateTime.Now, "", "", new string[0], new Dictionary<string, object[]>(), null, null);

        Dictionary<string, object> aliases = new Dictionary<string, object>();

        private static readonly TimeSpan day = new TimeSpan(1, 0, 0, 0, 0);

        IMeasurement[] measurements = new IMeasurement[0];

   
        /// <summary>
        /// Change alias event
        /// </summary>
        event Action<IAlias, string> onChange = (IAlias a, string name) => { };

        IAssociatedObject[] children;


        /// <summary>
        /// Add event 
        /// </summary>
        event Action<IEvent> onAddEvent = (IEvent e) => { };

        /// <summary>
        /// Remove event
        /// </summary>
        event Action<IEvent> onRemoveEvent = (IEvent e) => { };

        List<IEvent> events = new List<IEvent>();
  
        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="str">String argument</param>
        public SatelliteData(string str)
        {
            Type t = Type.GetType(str);
            if (t != null)
            {

                ConstructorInfo c = t.GetConstructor(new Type[0]);
                IAssociatedObject ao = c.Invoke(new object[0]) as IAssociatedObject;
                if (ao is ISeparatedAssemblyEditedObject)
                {
                    (ao as ISeparatedAssemblyEditedObject).FirstLoad();
                }
                children = new IAssociatedObject[] { ao };
                Post();
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        SatelliteData()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SatelliteData(SerializationInfo info, StreamingContext context)
        {
            (this as IPropertiesEditor).Properties =
                info.Deserialize<object>("Properties");
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
                tuple =
                    new Tuple<DateTime, string, string, string[], Dictionary<string, object[]>, byte[], byte[]>(
                    tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, value, tuple.Item7);
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

        #region IPropertiesEditor Members

        object IPropertiesEditor.Editor
        {
            get { return this.GetEditor(); }
        }

        object IPropertiesEditor.Properties
        {
            get
            {
                if (children != null)
                {
                     tuple =
                        new Tuple<DateTime, string, string, string[], Dictionary<string, object[]>, byte[], byte[]>(
                            tuple.Item1, tuple.Item2, tuple.Item3,
                            tuple.Item4, tuple.Item5, tuple.Item6, children.Serialize());

                }
                return tuple;
            }
            set
            {
                tuple = value as
                    Tuple<DateTime, string, string, string[], Dictionary<string, object[]>, byte[], byte[]>;
                if (tuple.Item7 != null)
                {
                    children = tuple.Item7.Deserialize<IAssociatedObject[]>();
                }
                CreateAliases();
                Post();
            }
        }

        #endregion

        #region IAlias Members

        IList<string> IAlias.AliasNames
        {
            get { return StaticExtensionCelestrakNORADSatellites.AliasNames.Keys.ToList<string>(); }
        }

        object IAlias.this[string name]
        {
            get
            {
                return aliases[name];
            }
            set
            {
            }
        }

        object IAlias.GetType(string name)
        {
            if (name.Equals("Epoch"))
            {
              return  FixedTypes.DateTimeType;
            }
            return FixedTypes.Double;
        }


        event Action<IAlias, string> IAlias.OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
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

        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                TimeSpan ts = (DateTime.Now - tuple.Item1);
                if (ts < day)
                {
                    return true;
                }
                return true;
            }
            set
            {
            }
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<object>("Properties", (this as IPropertiesEditor).Properties);
        }

        #endregion

        #region IChildrenObject Members

        IAssociatedObject[] IChildrenObject.Children
        {
            get { return children; }
        }

        #endregion

        #region IPhysicalUnitAlias Members

        Dictionary<Type, int> IPhysicalUnitAlias.this[string name]
        {
            get 
            {
                if (StaticExtensionCelestrakNORADSatellites.AliasNames.ContainsKey(name))
                {
                    return StaticExtensionCelestrakNORADSatellites.AliasNames[name];
                }
                return null;
            }
        }

        #endregion

        #region IEventHandler Members

        void IEventHandler.Add(IEvent ev)
        {
            ev.Event += Event;
            events.Add(ev);
            onAddEvent(ev);
        }

        void IEventHandler.Remove(IEvent ev)
        {
            ev.Event -= Event;
            events.Remove(ev);
            onRemoveEvent(ev);
        }

        public IEnumerable<IEvent> Events
        {
            get { return events; }
        }

        event Action<IEvent> IEventHandler.OnAdd
        {
            add { onAddEvent += value; }
            remove { onAddEvent -= value; }
        }

        event Action<IEvent> IEventHandler.OnRemove
        {
            add { onRemoveEvent += value; }
            remove { onRemoveEvent -= value; }
        }

        #endregion
 
        #region Public

        /// <summary>
        /// Data context
        /// </summary>
        public object DataConext
        {
            get
            {
                if (tuple.Item3.Length == 0)
                {
                    return null;
                }
                List<int> n = StaticExtensionCelestrakNORADSatellites.Nums;
                List<string> ls = StaticExtensionCelestrakNORADSatellites.Full;
                Dictionary<string, object[]> d = tuple.Item5;
                List<Row> l = new List<Row>();
                foreach (int i in n)
                {
                    string s = ls[i];
                    l.Add(new Row { Number = (i + 1), Name = s, Value = (d[s][1] + "") });
                }
                return l;
            }
        }

        /// <summary>
        /// Url of satellite list
        /// </summary>
        public string Url
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
                try
                {
                    text = "";
                    WebRequest req = WebRequest.Create(value);
                    WebResponse resp = req.GetResponse();
                    List<string> l = new List<string>();
                    using (TextReader reader = new StreamReader(resp.GetResponseStream()))
                    {
                        while (true)
                        {
                            string s = reader.ReadLine();
                            if (s == null)
                            {
                                break;
                            }
                            text += s + "\n";
                            string st = reader.ReadLine();
                            text += st + "\n";
                            int[] num = new int[] { 3, 7 };
                            st = st.Substring(num);
                            l.Add(s + " " + st);
                            for (int i = 0; i < 1; i++)
                            {
                                text += reader.ReadLine() + "\n";
                            }
                        }
                    }
                    tuple = new Tuple<DateTime, string, string, string[], Dictionary<string, object[]>, byte[], byte[]>(
                        DateTime.Now, value, tuple.Item3, l.ToArray(), tuple.Item5, tuple.Item6, tuple.Item7);
                    onChangeUrl(value);
                 }
                catch (Exception exception)
                {
                    exception.ShowError(10);
                }
            }
        }

        /// <summary>
        /// Satellites
        /// </summary>
        public string[] Satellites
        {
            get
            {
                return tuple.Item4;
            }
        }

        /// <summary>
        /// Satellite
        /// </summary>
        public string Satellite
        {
            get
            {
                return tuple.Item3;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                if (tuple.Item3.Equals(value))
                {
                    return;
                }
                try
                {
                    Load(value);
                }
                catch (Exception exception)
                {
                    exception.ShowError(10);
                }
            }
        }


        /// <summary>
        /// Text
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
        }

        public event Action<string> OnChangeUrl
        {
            add { onChangeUrl += value; }
            remove { onChangeUrl -= value; }
        }

        public event Action<string> OnChangeSatellite
        {
            add { onChangeSatellite += value; }
            remove { onChangeSatellite -= value; }
        }


        #endregion

        #region Private

        void Event()
        {
            onChange(this, null);
        }

        void CreateAliases()
        {

            Dictionary<string, object[]> d = tuple.Item5;
            List<string>[] l = StaticExtensionCelestrakNORADSatellites.List;
            int year = 2000 + (int)d[l[0][4]][1];
            DateTime dt = new DateTime(year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            double time = dt.DateTimeToDay() + (double)d[l[0][5]][1] - 1.5;
            DateTime epoch = time.DayToDateTime();

            List<string> ap = StaticExtensionCelestrakNORADSatellites.ListAlias;
            Dictionary<string, string> p = StaticExtensionCelestrakNORADSatellites.AliasesParametes;
            foreach (string n in p.Keys)
            {
                string v = p[n];
                int k = ap.IndexOf(v);
                if (k >= 9)
                {
                    continue;
                }
                double a = (double)d[n][1];
                aliases[v] = a;
            }
            aliases["Mean Motion"] = 360 * (double)aliases["Mean Motion"];
            aliases[ap[9]] = EarthMass;
            aliases[ap[10]] = epoch;
        }      

        void Load(string satellite)
        {
            Dictionary<string, object[]> dmea = new Dictionary<string, object[]>();

            WebRequest req = WebRequest.Create(tuple.Item2);
            WebResponse resp = req.GetResponse();
            List<string>[] ldd = StaticExtensionCelestrakNORADSatellites.List;
            Dictionary<int, Tuple<int[], object>>[] ddd =
                StaticExtensionCelestrakNORADSatellites.Dictionary;
            bool suc = false;
            text = "";
            List<string> sats = new List<string>();
            Dictionary<string, object[]> dt = tuple.Item5;
            using (TextReader reader = new StreamReader(resp.GetResponseStream()))
            {
                while (true)
                {
                    string s = reader.ReadLine();
                    if (s == null)
                    {
                        break;
                    }
                    text += s + "\n";
                    string[] ss = new string[3] { s, null, null };
                    for (int i = 1; i < 3; i++)
                    {
                        ss[i] = reader.ReadLine();
                        text = ss[i] + "\n";
                    }
                    string sat = ss[0] + " " + ss[1].Substring(new int[] { 3, 7 });
                    sats.Add(sat);
                    if (sat.Equals(satellite))
                    {
                        dt = new Dictionary<string, object[]>();
                        List<IMeasurement> l = new List<IMeasurement>();
                        for (int i = 0; i < 2; i++)
                        {
                            List<string> ld = ldd[i];
                            Dictionary<int, Tuple<int[], object>> dd = ddd[i];
                            s = ss[i + 1];
                            text += s + "\n";
                            for (int j = 0; j < ld.Count; j++)
                            {
                                string name = ld[j];
                                Tuple<int[], object> t = dd[j];
                                string sn = "s" + (l.Count + 1);
                                object ret = s.ToObject(t.Item1, t.Item2);
                                IMeasurement m = null;
                                object type = t.Item2;
                                if (type.Equals((double)0))
                                {
                                    m = new ConstMeasure(sn, (double)ret);
                                }
                                else
                                {
                                    m = new Measure(sn, type, ret);
                                }
                                l.Add(m);
                                dt[name] = new object[] { type, ret };
                            }

                        }
                        suc = true;
                        measurements = l.ToArray();
                    }
                    else
                    {
                        //!!! TEMP sats.Add(sat);
                    }
                }
                if (!suc)
                {
                    throw new Exception("Satellite \"" + satellite + " does not exist");
                }
                tuple = new Tuple<DateTime, string,
                    string, string[], Dictionary<string, object[]>, byte[], byte[]>(
                 DateTime.Now, tuple.Item2, satellite, sats.ToArray(), dt, tuple.Item6, tuple.Item7);
                CreateAliases();
                onChangeSatellite(tuple.Item3);
                onChange(this, null);
            }
        }

        void Post()
        {
            if (children != null)
            {
                if (children[0] is IAliasConsumer)
                {
                    (children[0] as IAliasConsumer).Add(this);
                }
            }
        }

        #endregion

        #region Classes

        /// <summary>
        /// Table row
        /// </summary>
        public class Row
        {
            public int Number { get; set; }
            public string Name { set; get; }
            public string Value { set; get; }
        }

        #region Constant Measure


        class ConstMeasure : IMeasurement, IDerivation
        {
            private static readonly ConstMeasure Zero = new ConstMeasure("", 0);

            const Double t = 0;
            private double c;
            const double z = 0;
            string name;


            public ConstMeasure(string name, double c)
            {
                this.c = c;
                this.name = name;
            }

            #region IMeasure Members

            Func<object> IMeasurement.Parameter
            {
                get { return Get; }
            }

            string IMeasurement.Name
            {
                get { return name; }
            }

            object IMeasurement.Type
            {
                get { return (double)0; }
            }

            #endregion


            #region IDerivation Members

            IMeasurement IDerivation.Derivation
            {
                get { return Zero; }
            }

            #endregion

            object Get()
            {
                return c;
            }
        }

        #endregion

        #region Measure

        class Measure : IMeasurement
        {
            #region Fields

            string name;

            object type;

            object value;

            #endregion

            #region Ctor

            internal Measure(string name, object type, object value)
            {
                this.name = name;
                this.type = type;
                this.value = value;
            }

            #endregion

            #region IMeasure Members

            Func<object> IMeasurement.Parameter
            {
                get { return Get; }
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


            object Get()
            {
                return value;
            }


        #endregion
  
        }

        #endregion

    }
}