using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSetService
{

    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionDataSetService
    {
        /// <summary>
        /// Generates script
        /// </summary>
        /// <param name="column">Data column</param>
        /// <returns>Script</returns>
        public static string GenerateScript(this IColumn column)
        {
            string t = column.Type;
            string s = "";
            if (t.Equals("System.Double"))
            {
                s += "float(53)";
            }
            if (t.Equals("System.Guid"))
            {
                s += "uniqueidentifier";
            }
            if (t.Equals("System.Int32"))
            {
                s += "int";
            }
            if (t.Equals("System.String"))
            {
                s += "char(";
                s += column.Length + ")";
            }
            s += " ";
            if (column.IsNullable)
            {
                s += "NULL";
            }
            else
            {
                s += "NOT NULL";
            }
            return s;
        }

        /// <summary>
        /// Generates script
        /// </summary>
        /// <param name="table">Table</param>
        /// <param name="factory">Factory</param>
        /// <returns>Script</returns>
        public static List<string> GenerateScript(this ITable table, IDataSetFactory factory)
        {
            List<string> l = new List<string>();
            l.Add("CREATE TABLE dbo." + table.Name);
            l.Add("(");
            Dictionary<string, IColumn> d = table.Columns;
            int n = 0;
            foreach (string key in d.Keys)
            {
                string s = key + " " + factory.GenerateScript(d[key]);
                ++n;
                if (n < d.Count)
                {
                    s += ",";
                }
                l.Add(s);
            }
            l.Add(");");
            return l;
        }

        /// <summary>
        /// Gets type of column
        /// </summary>
        /// <param name="column">Column</param>
        /// <returns>Type</returns>
        public static object GetColumnType(this System.Data.DataColumn column)
        {
            Double a = 0;
            string s = "";
            Type t = column.DataType;
            if (t.Equals(typeof(Double)))
            {
                return a;
            }
            if (t.Equals(typeof(string)))
            {
                return s;
            }
            return null;

        }
    }
}
