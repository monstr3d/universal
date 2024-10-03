using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using Diagram.UI;

namespace DataSetService
{
    /// <summary>
    /// Performer of data set factory
    /// </summary>
    public class DataSetFactoryPerformer
    {
        #region Fields

        static private string[][] mod = null;

        #endregion


        #region Public Members

        /// <summary>
        /// Copies table with help of factory
        /// </summary>
        /// <param name="table">The table</param>
        /// <param name="factoty">The factory</param>
        /// <returns>Table copy</returns>
        public static ITable Copy(ITable table, IDataSetDesktopFactory factoty)
        {
            ITable t = factoty.Table;
            t.Name = table.Name;
            t.X = table.X;
            t.Y = table.Y;
            foreach (string name in table.Columns.Keys)
            {
                IColumn c = table.Columns[name];
                IColumn col = factoty.Column;
                t.Columns[name] = col;
                col.Column = c.Column;
                col.IsMarked = c.IsMarked;
                col.Table = t;
                col.Type = c.Type;
                col.IsNullable = c.IsNullable;
                col.IsNull = c.IsNull;
                col.Modifier = c.Modifier;
                col.Length = c.Length;
                col.Value = c.Value;
                col.Name = name;
            }
            return t;
        }

        /// <summary>
        /// Copies desktop with help of factory
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="factory">The factory</param>
        /// <returns>Desktop copy</returns>
        public static IDataSetDesktop Copy(IDataSetDesktop desktop, IDataSetDesktopFactory factory)
        {
            IDataSetDesktop d = factory.Desktop;
            Dictionary<string, Dictionary<string, IColumn>> dictionary = new Dictionary<string, Dictionary<string, IColumn>>();
            foreach (string name in desktop.Tables.Keys)
            {
                ITable t = Copy(desktop.Tables[name], factory);
                d.Tables[name] = t;
                t.Desktop = d;
            }
            foreach (ITable t in d.Tables.Values)
            {
                Dictionary<string, IColumn> dic = new Dictionary<string, IColumn>();
                dictionary[t.Name] = dic;
                foreach (IColumn c in t.Columns.Values)
                {
                    dic[c.Name] = c;
                }
            }
            foreach (ILink link in desktop.Links)
            {
                ILink l = factory.Link;
                l.Desktop = d;
                l.IsMarked = link.IsMarked;
                l.SourceTable = link.SourceTable;
                l.TargetTable = link.TargetTable;
                l.SourceColumn = link.SourceColumn;
                l.TargetColumn = link.TargetColumn;
                l.Source = dictionary[l.SourceTable][l.SourceColumn];
                l.Target = dictionary[l.TargetTable][l.TargetColumn];
                if (!d.Links.Contains(l))
                {
                    d.Links.Add(l);
                }
            }

            return d;
        }

        /// <summary>
        /// Creates table from DataTable prototype
        /// </summary>
        /// <param name="dataTable">The prototype</param>
        /// <param name="factory">The factory</param>
        /// <returns>The table</returns>
        public static ITable Create(DataTable dataTable, IDataSetDesktopFactory factory)
        {
            ITable table = factory.Table;
            table.Name = dataTable.TableName;
            table.Table = dataTable;
            foreach (DataColumn col in dataTable.Columns)
            {
                IColumn c = factory.Column;
                string name = col.ColumnName;
                c.Column = col;
                c.Table = table;
                c.Type = col.DataType + "";
                c.IsNullable = col.AllowDBNull;
                try
                {
                    c.Length = col.MaxLength;
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                }
                c.Name = name;
                table.Columns[name] = c;
            }
            return table;
        }

        /// <summary>
        /// Creates desktop from prototype
        /// </summary>
        /// <param name="dataSet">Prototype</param>
        /// <param name="factory">Factory</param>
        /// <returns>Desktop</returns>
        public static IDataSetDesktop Create(DataSet dataSet, IDataSetDesktopFactory factory)
        {
            IDataSetDesktop d = factory.Desktop;
            foreach (DataTable table in dataSet.Tables)
            {
                ITable t = Create(table, factory);
                d.Tables[t.Name] = t;
                t.Desktop = d;
            }
            return d;
        }

        /// <summary>
        /// Sets data to table
        /// </summary>
        /// <param name="dataTable">The data</param>
        /// <param name="table">The table</param>
        public static void Set(DataTable dataTable, ITable table)
        {
            table.Table = dataTable;
            table.Name = dataTable.TableName;
            foreach (DataColumn c in dataTable.Columns)
            {
                string name = c.ColumnName;
                table.Columns[name].Column = c;
                table.Columns[name].Type = c.DataType + "";
            }
        }

        /// <summary>
        /// Sets data to desktop
        /// </summary>
        /// <param name="dataSet">Data set</param>
        /// <param name="desktop">Desktop</param>
        public static void Set(DataSet dataSet, IDataSetDesktop desktop)
        {
            foreach (DataTable t in dataSet.Tables)
            {
                string name = t.TableName;
                ITable table = desktop.Tables[name];
            }
        }

        /// <summary>
        /// Gets modifiers from string  type representation
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string[] GetModifiers(string type)
        {
            if (type.Equals("System.Char[]"))
            {
                return Modf[2];
            }
            if (type.Equals("System.Double") | type.Equals("System.Int32"))
            {
                return Modf[1];
            }
            return Modf[0];
        }

        #endregion

        #region Private Members

        static private string[][] Modf
        {
            get
            {
                if (mod != null)
                {
                    return mod;
                }
                mod = new string[3][];
                mod[0] = new string[] { "=" };
                mod[1] = new string[] { "=", ">", "<" };
                mod[2] = new string[] { "=", "LIKE" };
                return mod;
            }
        }

        #endregion

    }
}
