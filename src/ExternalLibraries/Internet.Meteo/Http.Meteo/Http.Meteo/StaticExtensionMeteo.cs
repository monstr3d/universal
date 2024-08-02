using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Reflection;

namespace Http.Meteo
{
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
        }

 

    }
}
