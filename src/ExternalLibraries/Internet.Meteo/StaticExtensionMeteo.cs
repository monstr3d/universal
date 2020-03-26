using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CategoryTheory;
using Diagram.UI;

namespace Internet.Meteo
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionMeteo
    {
        internal static double ToDouble(this string str)
        {
            return Double.Parse(
            str.Replace(".", 
            System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
        }

        internal static string Substring(this string str, string sub)
        {
            return str.Substring(str.IndexOf(sub) + sub.Length);
        }
        
        internal static string Limit(this string str, string sub)
        {
            return str.Substring(0, str.IndexOf(sub));
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
                if (assembly.FullName.Contains("Internet.Meteo"))
                {
                    return typeof(StaticExtensionMeteo).Assembly;
                }
                return null;
            }

            #endregion
        }

 
    }
}
