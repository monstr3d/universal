using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Net;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;


using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using SerializationInterface;

using DataPerformer.Interfaces;
using DataPerformer;

using Event.Interfaces;
using DataPerformer.Portable.Measurements;

namespace Http.Meteo.Services
{
    /// <summary>
    /// Meteorological service
    /// </summary>
    [Serializable()]
    public partial class MeteoService : CategoryObject, ISerializable,
        IPropertiesEditor, IMeasurements, ISeparatedAssemblyEditedObject
    {
        #region Fields

        IEnumerator<string> enumerable;

        IMeasurement[] measurements;
        const Double a = 0;

        int nBuffer;

        ISeparatedPropertyEditor editor;

        private event Action action = () => { };

        DateTime nextTime = DateTime.Now;



        static private readonly string[] names = new string[]
        {
            "Atmospheric pressure, mm mer col",
            "Temperature, °C",
            "Temperature min, °C",
           "Temperature max, °C",
           "Comments",
            "Wind direction",
            "Wind direction angle (radians)",
 "Wind speed, m/s",
 "The general nebulosity value",
 "Horizontal visibility, km"
        };


        static private readonly string[] tags = new string[]
        {
            "Atmospheric pressure",
            "Temperature",
            "Temperature min",
           "Temperature max",
           "Comments",
            "Wind direction",
 "Wind speed, m/s",
 "The general nebulosity value",
 "Horizontal visibility, km"
        };




        static private readonly object[] types = new object[]
        {
            a,
         a,
        a,
        a,
        "",
        "",
        a,
        a,
        a,
        a
        };

        object[] values;

        string html;

        /// <summary>
        ///Rough estimation of wind direction angle dictionary
        /// </summary>
        public static readonly Dictionary<string, double> windAngles = new Dictionary<string, double>()
        {
           {"N", 0},
           {"N-E", 0.25 * Math.PI},
           {"E", 0.5 * Math.PI},
           {"S-E", 0.75 * Math.PI},
           {"S", Math.PI},
           {"S-W", 1.25 * Math.PI},
           {"W", 1.5 * Math.PI},
           {"N-W", 1.75 * Math.PI},
         };

        #endregion

        #region Ctor

        public MeteoService()
        {
            values = new object[types.Length + 3];
            nBuffer = values.Length - 1;
            values[0] = "http://wmc.meteoinfo.ru/weather/russia";
            values[1] = new TimeSpan(1, 0, 0);
            values[values.Length - 1] = null;
            Array.Copy(types, 0, values, 2, types.Length);
            CreateMeasurements();
        }

        /// <summary>
        /// Deserilaization constructor
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        protected MeteoService(SerializationInfo info, StreamingContext context)
        {
            values = info.Deserialize<object[]>("Properties");
            nBuffer = values.Length - 1;
            CreateMeasurements();
            Update();
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<object[]>("Properties", values);
        }

        #endregion

        #region IPropertiesEditor Members

        object IPropertiesEditor.Editor
        {
            get
            {
                return this.GetEditor();
            }
        }

        object IPropertiesEditor.Properties
        {
            get
            {
                return values;
            }
            set
            {
                values = value as object[];
                Update();
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
            DateTime now = DateTime.Now;
            if (now > nextTime)
            {
                Update();
            }
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return DateTime.Now < nextTime;
            }
            set
            {
            }
        }

        #endregion

        #region ISeparatedAssemblyEditedObject Members

        byte[] ISeparatedAssemblyEditedObject.AssemblyBytes
        {
            get
            {
                return values[nBuffer] as byte[];
            }
            set
            {
                values[nBuffer] = value;
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

        /// <summary>
        /// First load
        /// </summary>
        void ISeparatedAssemblyEditedObject.FirstLoad()
        {
            (this as ISeparatedAssemblyEditedObject).AssemblyBytes = null;
            this.LoadAssembly();
        }

        #endregion

        #region Members

        #region Public Members

        /// <summary>
        /// Time span
        /// </summary>
        public TimeSpan TimeSpan
        {
            get
            {
                if (!values[1].GetType().Equals(typeof(TimeSpan)))
                {
                    values[1] = new TimeSpan(1, 0, 0);
                }
                return (TimeSpan)values[1];
            }
            set
            {
                values[1] = value;
            }
        }


        public string Html
        {
            set
            {
                html = value;
                string[] ss = value.Split("\n".ToCharArray());
                enumerable = ((new List<string>(ss)) as IEnumerable<string>).GetEnumerator();
                UpdateText();
            }
        }


        public string Url
        {
            get
            {
                return values[0] + "";
            }
            set
            {
                if (value.Equals(values[0]))
                {
                    return;
                }
                values[0] = value;
                if (html == null)
                {
                    Update();
                }
            }
        }

        #endregion

        #region Private Members 

        bool Find(string str)
        {
            string sp = "";
            while (true)
            {
                string s = enumerable.Current;
                if (s == null)
                {
                    break;
                }
                if (s.Contains(str))
                {
                    enumerable.MoveNext();
                    return true;
                }
                sp = s;
                enumerable.MoveNext();
            }
            ("Http Error: url=" + Url + " " + sp + "").Show();
            return false;
        }

        const string pc = "<td class=pogodacell>";

        static double GetDouble(string str)
        {
            string s = str.Substring("<td class=pogodacell>");
            if (s.IndexOf("<b>") == 0)
            {
                s = s.Substring("<b>");
            }
            return s.Limit().ToDouble();
        }

        static object GetDouble(IEnumerator<string> enu)
        {
            double x = 0;
            while (true)
            {
                string s = enu.Current;
                if (s == null)
                {
                    break;
                }
                if (s.ToLower().Contains(pc))
                {
                    x = GetDouble(s);
                    break;
                }
                enu.MoveNext();
            }
            return x;
        }

        static object GetString(IEnumerator<string> enu)
        {

            while (true)
            {
                string s = enu.Current;
                enu.MoveNext();
                if (s.ToLower().Contains(pc))
                {
                    return s.Substring("<td class=pogodacell>").Limit();
                }
                if (s == null)
                {
                    return "";
                }
            }
            return "";
        }


        static private readonly Dictionary<object, Func<IEnumerator<string>, object>> df =
            new Dictionary<object, Func<IEnumerator<string>, object>>()
        {
            { a, GetDouble},
            {"", GetString}
        };

        void UpdateText()
        {
            enumerable.MoveNext();
            try
            {
                int i = 0;
                int j = 2;
                foreach (IMeasurement m in measurements)
                {
                    if (m.Name.Equals(names[6]))
                    {
                        ++j;
                        continue;
                    }
                    if (!Find(tags[i]))
                    {
                        return;
                    }
                    object t = m.Type;
                    Func<IEnumerator<string>, object> f = df[t];
                    values[i + j] = f(enumerable);
                    ++i;
                }
                SetWindAngle();
                nextTime = DateTime.Now + TimeSpan;
            }
            catch (Exception ex)
            {
                ("Http Error: url=" + Url + " Error code: " + ex.Message + "").Show();
            }
        }

        void Update()
        {
            try
            {
                WebRequest req = WebRequest.Create(Url);
                req.Proxy.Credentials =
                    new NetworkCredential(Properties.Settings.Default.username, 
                    Properties.Settings.Default.password, Properties.Settings.Default.domain);
                req.Timeout = 10000;
                WebResponse rs = req.GetResponse();
                enumerable = (new StreamReader(rs.GetResponseStream(), Encoding.GetEncoding(1251), true)).ToEnumerabe().GetEnumerator();
                UpdateText();
            }
            catch (Exception exception)
            {
                exception.ShowError();
                return;
                ("Bad Internet connection to Hydrometeorological Center of Russia. Error: " +
                    exception.Message).Show(10);
            }
        }

        /// <summary>
        ///Rough estimation of wind direction angle
        /// </summary>
        void SetWindAngle()
        {
            string d = values[7] + "";
            if (windAngles.ContainsKey(d))
            {
                values[8] = windAngles[d];
            }
        }

        void CreateMeasurements()
        {
            List<IMeasurement> l = new List<IMeasurement>();
            for (int i = 0; i < types.Length; i++)
            {
                int[] k = new int[] { i + 2 };
                Func<object> f = () => { return values[k[0]]; };
                l.Add(new Measurement(types[i], f, names[i]));
            }
            measurements = l.ToArray();
        }

        void AsyncUpdate()
        {
            AsyncCallback ac = new AsyncCallback(ProcessCallback);
            Action a = Update;
            IAsyncResult ar = a.BeginInvoke(ac, null);
        }

        void ProcessCallback(IAsyncResult ar)
        {
            action();
        }


        static MeteoService()
        {
        }

        #endregion

        #endregion

    }
}

