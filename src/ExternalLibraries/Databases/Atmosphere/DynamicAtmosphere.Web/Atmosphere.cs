using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DynamicAtmosphere.Web
{
    
    /// <summary>
    /// Atmospheric parameters from sites
    /// http://www.spaceweather.ca/data-donnee/sol_flux/sx-5-mavg-eng.php
    /// http://www.nwra.com/spawx/env_latest.html
    /// </summary>
    public class Atmosphere
    {
        #region Fields

        double f107;

        double f107A;

        double ap;

        event Action<Exception> onException = (Exception exception) => { };

        //private static cha

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Atmosphere()
        {
            Refresh();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Solar 10.7 cm flux current value
        /// </summary>
        public double F107
        {
            get
            {
                return f107;
            }
        }

        /// <summary>
        /// Three month average of Solar 10.7 cm flux
        /// </summary>
        public double F107A
        {
            get
            {
                return f107A;
            }
        }

        /// <summary>
        /// Geomagnetic Disturbance Index
        /// </summary>
        public double Ap
        {
            get
            {
                return ap;
            }
        }

        /// <summary>
        /// Refreshs itself
        /// </summary>
        public void Refresh()
        {
            try
            {
                WebRequest req =
                    WebRequest.Create("http://www.spaceweather.ca/data-donnee/sol_flux/sx-5-mavg-eng.php");
                WebResponse resp = req.GetResponse();
                using (TextReader reader = new StreamReader(resp.GetResponseStream()))
                {

                    double a = 0;
                    string s1 = "";
                    List<string> l = new List<string>();
                    while (true)
                    {
                        string s = reader.ReadLine();
                        l.Add(s);
                        if (s.ToLower().Contains("</table>"))
                        {
                            int i = l.Count - 1;
                            for (; ; i--)
                            {
                                if (l[i].Contains("<tr>"))
                                {
                                    break;
                                }
                            }
                            i += 3;
                            for (int j = 0; j < 3; j++)
                            {
                                string sss = l[i + j];
                                sss = sss.Substring(sss.IndexOf("<td>") + 4);
                                sss = sss.Replace("</td>", "").Trim();
                                a += Double.Parse(sss, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                            }
                            f107A = a / 3;
                            break;
                        }
                        if (s == null)
                        {
                            break;
                        }
                        s1 = s;
                    }
                }
            }
      
           catch (Exception exception)
            {
                onException(exception);
           }
            try
            {
                WebRequest req =
                   WebRequest.Create("http://www.nwra.com/spawx/env_latest.html");
                WebResponse resp = req.GetResponse();
                using (TextReader r = new StreamReader(resp.GetResponseStream()))
                {
                    while (true)
                    {
                        string s = r.ReadLine();
                        if (s == null)
                        {
                            break;
                        }
                        if (s.Contains("F10.7:"))
                        {
                            string[] ss = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            f107 = Double.Parse(ss[ss.Length - 2], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        }
                        if (s.Contains("Ap(est):"))
                        {
                            string[] ss = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            ap = Double.Parse(ss[ss.Length - 2], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                onException(exception);
            }
        }


        /// <summary>
        /// On exception error
        /// </summary>
        public event Action<Exception> OnException
        {
            add { onException += value; }
            remove { onException -= value; }
        }

        #endregion

    }
}
