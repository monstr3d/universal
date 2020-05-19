using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Diagram.UI;
using System.Reflection;
using CategoryTheory;

namespace Http.Meteo
{
    [InitAssembly]
    public static class StaticExtensionMeteo
    {
        internal static double ToDouble(this string str)
        {
            try
            {
                return double.Parse(
                str.Replace(".",
                System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            }
            catch (Exception)
            {
                ("Illegal double value: " + str).Show(); 
            }
            return 0;
        }

        internal static string Substring(this string str, string sub)
        {
            return str.Substring(str.ToLower().IndexOf(sub) + sub.Length);
        }

        internal static string Limit(this string str, string sub = "<")
        {
            return str.Substring(0, str.IndexOf(sub));
        }

        internal static IEnumerable<string> ToEnumerabe(this TextReader reader)
        {
            while (true)
            {
                yield return reader.ReadLine();
            }
        }

        /// <summary>
        /// First
        /// </summary>
        static bool first = true;

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        static StaticExtensionMeteo()
        {
            new Replace();
        }

        class Replace : Diagram.UI.Interfaces.IReplaceAssembly
        {
            internal Replace()
            {
                this.Add();
            }

            #region IReplaceAssembly Members

            Assembly Diagram.UI.Interfaces.IReplaceAssembly.Replace(Assembly assembly)
            {
                string[] ass = new string[] {"Http.Meteo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Http.Meteo, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null",
                    "Http.Meteo, Version=1.0.0.2, Culture=neutral, PublicKeyToken=null" };
                for (int i = 0; i < ass.Length; i++)
                {
                    if (assembly.FullName.Equals(ass[i]))
                    {
                        return typeof(Services.MeteoService).Assembly;
                    }
                }
                return null;
            }

            #endregion
        }


    }
}
