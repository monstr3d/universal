using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using BaseTypes;

namespace Diagram.UI
{
    /// <summary>
    /// Performer of static operations
    /// </summary>
    public static class StaticExtensionDiagramUIExtended
    {

        #region Public Members



        /// <summary>
        /// Initialization
        /// </summary>
        public static void Init()
        {
        }

        /// <summary>
        /// Conversion of physical units
        /// </summary>
        /// <param name="alias">Alias</param>
        /// <param name="source">Source</param>
        /// <param name="target">Target</param>
        public static void ConvertPhysicalUnitsAlias
           (this IAlias alias, BaseTypes.Attributes.PhysicalUnitTypeAttribute source,
           BaseTypes.Attributes.PhysicalUnitTypeAttribute target)
        {
            Dictionary<string, double> d = ConvertPhysicalUnits(alias, source, target);
            foreach (string key in d.Keys)
            {
                alias[key] = d[key];

            }
        }

        /// <summary>
        /// Set aliases of desktop
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="document">Document</param>
        public static void SetAliases(this IDesktop desktop, XmlDocument document)
        {
            XmlNodeList nl = document.GetElementsByTagName("Aliases");
            if (nl.Count == 0)
            {
                return;
            }
            nl = nl[0].ChildNodes;
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (XmlElement el in nl)
            {
                foreach (XmlElement e in el.ChildNodes)
                {
                    d[e.Name] = e.InnerText;
                }
                desktop.SetAliasValue(d["Name"], d["Value"].FromString(d["Type"]));
            }
        }



        /// <summary>
        /// Conversion of physical units
        /// </summary>
        /// <param name="alias">Alias</param>
        /// <param name="source">Source</param>
        /// <param name="target">Target</param>
        /// <returns>Conversion result</returns>
        public static Dictionary<string, double> ConvertPhysicalUnits
            (this IAlias alias, BaseTypes.Attributes.PhysicalUnitTypeAttribute source,
            BaseTypes.Attributes.PhysicalUnitTypeAttribute target)
        {
            Dictionary<string, double> d = new Dictionary<string, double>();
            BaseTypes.Interfaces.IPhysicalUnitAlias a = alias as
                BaseTypes.Interfaces.IPhysicalUnitAlias;
            IList<string> l = alias.AliasNames;
            foreach (string key in l)
            {
                if (!l.Contains(key))
                {
                    continue;
                }
                object t = alias.GetType(key);
                if (!t.Equals(BaseTypes.FixedTypes.Double))
                {
                    continue;
                }
                double x = (double)alias[key];
                Dictionary<Type, int> dt = a[key];
                if (dt != null)
                {
                    x *=
                        BaseTypes.StaticExtensionBaseTypes.Coefficient(source,
                        target, dt);
                }
                d[key] = x;
            }
            return d;
        }



        /// <summary>
        /// Create nodes from Xml element
        /// </summary>
        /// <param name="doc">Parent document</param>
        /// <param name="element">Element</param>
        /// <param name="tag">Tag</param>
        /// <param name="table">Table</param>
        public static void CreateNodes(this XmlDocument doc, XmlElement element, string tag, DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                XmlElement e = doc.CreateElement(tag);
                element.AppendChild(e);
                foreach (DataColumn c in table.Columns)
                {
                    string n = c.ColumnName;
                    XmlAttribute attr = doc.CreateAttribute(n);
                    attr.Value = row[n] + "";
                    e.Attributes.Append(attr);
                }
            }
        }


        /// <summary>
        /// Creates table from XML element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="tag">Tag name</param>
        /// <param name="attributes">Attributes those correspond to columns</param>
        /// <param name="types">Types of columns</param>
        /// <returns>The table</returns>
        public static DataTable CreateTable(this XmlElement element, string tag, string[] attributes, Type[] types)
        {
            DataTable table = new DataTable(tag);
            for (int i = 0; i < attributes.Length; i++)
            {
                table.Columns.Add(attributes[i], types[i]);
            }
            XmlNodeList list = element.GetElementsByTagName(tag);
            foreach (XmlElement e in list)
            {
                object[] o = new object[attributes.Length];
                for (int i = 0; i < attributes.Length; i++)
                {
                    string s = e.Attributes[attributes[i]].Value;
                    o[i] = Create(s, types[i]);
                }
                table.Rows.Add(o);
            }
            return table;
        }


        /// <summary>
        /// Creates table from Xml element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="tag">Tag</param>
        /// <param name="attributes">Attributes</param>
        /// <returns>The table</returns>
        public static DataTable CreateTable(this XmlElement element, string tag, string[] attributes)
        {
            DataTable table = new DataTable(tag);
            foreach (string attr in attributes)
            {
                table.Columns.Add(attr, "".GetType());
            }
            XmlNodeList list = element.GetElementsByTagName(tag);
            foreach (XmlElement e in list)
            {
                object[] o = new object[attributes.Length];
                for (int i = 0; i < attributes.Length; i++)
                {
                    o[i] = e.Attributes[attributes[i]].Value;
                }
                table.Rows.Add(o);
            }
            return table;
        }

        /// <summary>
        /// Gets texts of elements
        /// </summary>
        /// <param name="element">Parent none</param>
        /// <param name="tag">Tag name</param>
        /// <returns>List of texts</returns>
        public static List<string> GetTexts(this XmlElement element, string tag)
        {
            List<string> l = new List<string>();
            XmlNodeList list = element.GetElementsByTagName(tag);
            foreach (XmlNode node in list)
            {
                l.Add(node.InnerText);
            }
            return l;
        }

        /// <summary>
        /// Sets texts to childen elements
        /// </summary>
        /// <param name="doc">Parent document</param>
        /// <param name="element">Parent element</param>
        /// <param name="tag">Tag name</param>
        /// <param name="list">List</param>
        public static void SetTexts(this XmlDocument doc, XmlElement element, string tag, List<string> list)
        {
            foreach (string s in list)
            {
                XmlElement e = doc.CreateElement(tag);
                e.InnerText = s;
                element.AppendChild(e);
            }
        }




        #endregion

        #region Private Membres



        static StaticExtensionDiagramUIExtended()
        {
        }

        /// <summary>
        /// Creates default object from string
        /// </summary>
        /// <param name="s">The string</param>
        /// <param name="type">Type of object</param>
        /// <returns>The object</returns>
        private static object Create(this string s, Type type)
        {
            if (type.Equals(typeof(string)))
            {
                return s;
            }
            if (type.Equals(typeof(int)))
            {
                return Int32.Parse(s);
            }
            return null;
        }



        #endregion

    }
}
