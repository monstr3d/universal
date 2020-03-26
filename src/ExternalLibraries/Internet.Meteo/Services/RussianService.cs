using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Reflection;

using CategoryTheory;
using Diagram.UI;
using DataPerformer.Interfaces;
using DataPerformer;
using Diagram.UI.Interfaces;
using DataPerformer.Portable.Measurements;

namespace Internet.Meteo.Services
{
    public partial class RussianService : CategoryObject, 
        IPropertiesEditor, IMeasurements, ISeparatedAssemblyEditedObject
    {
        #region Fields

        DateTime dt;
 
        string town;

        string windDirection;

        double windAngle;

        string clouds;

        double temperature;

        double windVelocity;

        double pressure;

        double humidity;

        string special;

   
        IMeasurement[] measurements;

  
        static Assembly ass;

        IPropertiesEditor prop;

        object[] ob = new object[10];

        ISeparatedPropertyEditor editor;

        public static readonly Dictionary<string, double> windAngles = new Dictionary<string, double>()
        {
           {"С", 0},
           {"C-B", 0.25 * Math.PI},
           {"B", 0.5 * Math.PI},
           {"Ю-B", 0.75 * Math.PI},
           {"Ю", Math.PI},
           {"Ю-З", 1.25 * Math.PI},
           {"З", 1.5 * Math.PI},
           {"C-З", 1.75 * Math.PI},
         };

        #endregion

        #region Ctor


        /// <summary>
        /// Default constructor
        /// </summary>
        public RussianService()
        {
           CreateMeasurements();
            if (town == null)
            {
                return;
            }
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
                    ob = new object[] { (this as ISeparatedAssemblyEditedObject).AssemblyBytes, 
                        dt, town, windDirection, clouds, temperature, windVelocity, pressure,
                        humidity, special};
                    return ob;
            }
            set
            {
                ob = value as object[];
                dt = (DateTime)ob[1];
                Town = ob[2] + "";
                windDirection = ob[3] + "";
                clouds = ob[4] + "";
                temperature = (double)ob[5];
                windVelocity = (double)ob[6];
                pressure = (double)ob[7];
                humidity = (double)ob[8];
                special = ob[9] + "";
                SetWindAngle();
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
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        #endregion

        #region Members

        #region Public

        public Dictionary<string, string> TownURL
        {
            get
            {
                return townURL;
            }
        }

        public string Url
        {
            get
            {
                if (town == null)
                {
                    return null;
                }
                return "http://www.meteo.ru" + TownURL[town];
            }
        }

        public string Town
        {
            get
            {
                return town;
            }
            set
            {
                DateTime time = DateTime.Now;
                if (value != null & town != null)
                {
                    if (value.Equals(town) & (dt - time) < new TimeSpan(0, 0, 0, 1, 1))
                    {
                        return;
                    }
                }
                town = value;
                try
                {
                    WebRequest req = WebRequest.Create(Url);
                    req.Timeout = 10000;
                    WebResponse rs = req.GetResponse();

                    TextReader r = new StreamReader(rs.GetResponseStream(), Encoding.GetEncoding(1251), true);
                    while (true)
                    {
                        string s = r.ReadLine();
                        if (s == null)
                        {
                            break;
                        }
                        if (s.Contains("class=weather_cl"))
                        {
                            s = s.Substring(s.IndexOf("class=weather_cl"));
                            {
                                s = s.Substring(s.IndexOf("alt=") + 4);
                                clouds = s.Substring(0, s.IndexOf("width"));
                                s = s.Substring(s.IndexOf(">") + 1);
                                string temp = s.Substring(0, s.IndexOf(" "));
                                temperature = temp.ToDouble();
                                s = s.Substring(s.IndexOf("Ветер"));
                                s = s.Substring(s.IndexOf("<b>") + 3);
                                windDirection = s.Substring(0, s.IndexOf("</b>"));
                                s = s.Substring(s.IndexOf("<b>") + 3);
                                temp = s.Substring(0, s.IndexOf(" "));
                                windVelocity = temp.ToDouble();
                                s = s.Substring(s.IndexOf("Давление"));
                                s = s.Substring(s.IndexOf("<b>") + 3);
                                pressure = s.Substring(0, s.IndexOf("&")).ToDouble();
                                s = s.Substring("Влажность");
                                s = s.Substring("<b>");
                                humidity = s.Limit("%").ToDouble();
                                s = s.Substring("Особые явления:");
                                s = s.Substring("<b>");
                                special = s.Limit("</b>");
                                SetWindAngle();
                                break;

                            }
                        }
                        //  w.WriteLine(s);
                    }
                    //}
                }
                catch (Exception ex)
                {
                    ("Bad Internet connection to METEO.RU. Error: " +
                      ex.Message).Show(10);
                }
            }
        }


        #endregion

        #region Private

 
 
        void SetWindAngle()
        {
            if (windAngles.ContainsKey(windDirection))
            {
                windAngle = windAngles[windDirection];
            }
        }

        void CreateMeasurements()
        {
            Func<object>[] func = new Func<object>[]
            {
                () => {return windDirection;},
                () => {return windAngle;},
                () => {return clouds;},
               () => {return temperature;},
                 () => {return windVelocity;},
                () => {return pressure;},
                () => {return humidity;},
                () => {return special;}
              };

            string[] names = new string[]
        {
            "Направление ветра",
          "Угол направления ветра (рад)",
          "Облачнсть",
          "Темпрература, град С",
          "Скорость ветра м/c",
          "Давление мм рт ст",
          "Влажность %",
          "Особые условия",
        };

            double a = 0;
            object[] types = new object[]
        {
        "",
         a,
       "",
        a,
        a,
        a,
        a,
        "",
        };
            List<IMeasurement>  l = new List<IMeasurement>();

            for (int i = 0; i < func.Length; i++)
            {
                l.Add(new Measurement(types[i], func[i], names[i])); 
            }
            measurements = l.ToArray();
        }

  

        #endregion

        #endregion

        #region ISeparatedAssemblyEditedObject Members

        byte[] ISeparatedAssemblyEditedObject.AssemblyBytes
        {
            get
            {
                return ob[0] as byte[];
            }
            set
            {
                ob[0] = value;
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
            (this as ISeparatedAssemblyEditedObject).AssemblyBytes = null;
            this.LoadAssembly();
        }

        #endregion
    }
}