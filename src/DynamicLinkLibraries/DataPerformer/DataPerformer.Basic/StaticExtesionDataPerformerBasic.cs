using Localization.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;


namespace DataPerformer.Basic
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtesionDataPerformerBasic
    {
        /// <summary>
        /// Value tag
        /// </summary>
        static public readonly string Value = "Value";


 
        /// <summary>
        /// Appends double value
        /// </summary>
        /// <param name="doc">Document</param>
        /// <param name="e">Element</param>
        /// <param name="value">Value</param>
        /// <returns>Value element</returns>
        public static XmlElement AppendValue(this XmlDocument doc, XmlElement e, double value)
        {
            XmlElement et = doc.CreateElement(Value);
            e.AppendChild(et);
            et.InnerText = value.Convert();
            return et;
        }

    }
}
