using DataSetService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
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
        /// Computation of differences
        /// </summary>
        /// <param name="newVersion">New version</param>
        /// <param name="oldVersion">Old version</param>
        /// <returns>Difference</returns>
        public static DataSet ComputateDiff(this DataSet newVersion, DataSet oldVersion)
        {
            DataSet diff = null;
            oldVersion.Merge(newVersion);
            bool foundChanges = oldVersion.HasChanges();
            if (foundChanges)
            {
                diff = oldVersion.GetChanges();
            }
            return diff;
        }

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

        /// <summary>
        /// Converter of connection string
        /// </summary>
        public static IConnectionStringConverter ConnectionStringConverter
        {
            get;
            set;
        }

        /// <summary>
        /// Sets converter
        /// </summary>
        /// <param name="connectionStringConverter">The conveter to set</param>
        public static void Set(this IConnectionStringConverter connectionStringConverter)
        {
            ConnectionStringConverter = connectionStringConverter;
        }



        /// <summary>
        /// Converts connection string
        /// </summary>
        /// <param name="value">Old value</param>
        /// <returns>New value</returns>
        public static string ConvertConnectionString(this string value)
        {
            var c = ConnectionStringConverter;
            return (c != null) ? c.Convert(value) : value;
        }
    }
}
