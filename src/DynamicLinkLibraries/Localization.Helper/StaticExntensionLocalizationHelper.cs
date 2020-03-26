using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Localization.Helper
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExntensionLocalizationHelper
    {

        /// <summary>
        /// Decimal separator
        /// </summary>
        static public readonly string DecimalSeparator =
            System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        
        /// <summary>
        /// Converts string to double
        /// </summary>
        /// <param name="str">The string</param>
        /// <returns>The double</returns>
        public static double Convert(this string str)
        {
            string s = str.Replace(".", DecimalSeparator);
            return Double.Parse(s);
        }

        /// <summary>
        /// Converts double to string
        /// </summary>
        /// <param name="x">The double</param>
        /// <returns>The string</returns>
        public static string Convert(this double x)
        {
            string s = x + "";
            return s.Replace(DecimalSeparator, ".");
        }
    }
}
