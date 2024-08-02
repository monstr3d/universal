using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;



namespace Http.Meteo
{
    /// <summary>
    /// Meteorological service
    /// </summary>
    public abstract class MeteoService 
    {
        #region Fields

        protected IEnumerator<string> enumerable;

        public readonly double a = 0;

     

        protected int nBuffer;

        private Action action;



        protected  DateTime nextTime = DateTime.Now;



        static public readonly string[] names = new string[]
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


        static public readonly string[] tags = new string[]
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




        static public readonly object[] types = new object[]
        {
           (double)0,
         (double)0,
        (double)0,
        (double)0,
        "",
        "",
        (double)0,
        (double)0,
        (double)0,
       (double)0
        };

        protected object[] values;

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
                enumerable = (new List<string>(ss) as IEnumerable<string>).GetEnumerator();
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
            ShowMessage("Http Error: url=" + Url + " " + sp + "");
          
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

        protected abstract void ShowMessage(string msg);

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
            { (double)0, GetDouble},
            {"", GetString}
        };

        protected abstract void UpdateText();

        protected void Update()
        {
            try
            {
                WebRequest req = WebRequest.Create(Url);
                //   req.Proxy.Credentials =
                //       new NetworkCredential(Properties.Settings.Default.username,
                //       Properties.Settings.Default.password, Properties.Settings.Default.domain);
                req.Timeout = 10000;
                WebResponse rs = req.GetResponse();
                enumerable = new StreamReader(rs.GetResponseStream(), Encoding.GetEncoding(1251), true).ToEnumerabe().GetEnumerator();
                UpdateText();
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        protected abstract void ShowError(Exception exception);
 

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

 
        void AsyncUpdate()
        {
            var t = new Task(Update);
            t.GetAwaiter().OnCompleted(ProcessCallback);
            t.Start();
        }

        void ProcessCallback()
        {
            action();
        }


  
        #endregion

        #endregion

    }
}

