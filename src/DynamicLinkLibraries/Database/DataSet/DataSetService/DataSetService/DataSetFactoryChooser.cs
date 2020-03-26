using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DataSetService
{
    /// <summary>
    /// Chooser of data set factory
    /// </summary>
    public abstract class DataSetFactoryChooser : IDataSetFactoryChooser
    {
        /// <summary>
        /// Global chooser
        /// </summary>
        static private IDataSetFactoryChooser chooser;

        /// <summary>
        /// Global chooser
        /// </summary>
        static public IDataSetFactoryChooser Chooser
        {
            get
            {
                return chooser;
            }
            set
            {
                chooser = value;
            }
        }

        /// <summary>
        /// Gets facroty by name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The factory</returns>
        public abstract IDataSetFactory this[string name]
        {
            get;
        }

        /// <summary>
        /// Names of factories
        /// </summary>
        public abstract string[] Names
        {
            get;
        }

        /// <summary>
        /// Cratefes dictionary of rows from data table
        /// </summary>
        /// <param name="tableCol">Table name</param>
        /// <param name="colCol">Colunm name</param>
        /// <param name="table">The table</param>
        /// <returns>Dictionary of rows</returns>
        static public Dictionary<string, Dictionary<string, DataRow>> GetTables(string tableCol, string colCol, DataTable table)
        {
            Dictionary<string, Dictionary<string, DataRow>> d = new Dictionary<string, Dictionary<string, DataRow>>();
            foreach (DataRow row in table.Rows)
            {
                string tn = row[tableCol] + "";
                Dictionary<string, DataRow> c = null;
                if (d.ContainsKey(tn))
                {
                    c = d[tn];
                }
                else
                {
                    c = new Dictionary<string, DataRow>();
                    d[tn] = c;
                }
                string cn = row[colCol] + "";
                c[cn] = row;
            }
            return d;
        }

        /// <summary>
        /// Gets standard data set
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <param name="colName">Column name</param>
        /// <param name="table">Table</param>
        /// <param name="factory">Factory</param>
        /// <returns>Standard data set</returns>
        static public DataSet GetStandardDataSet(string tableName, string colName, DataTable table, IDataSetFactory factory)
        {
            Dictionary<string, Dictionary<string, DataRow>> dicT = GetTables(tableName, colName, table);
            DataSet ds = new DataSet();
            foreach (string tn in dicT.Keys)
            {
                DataTable dt = new DataTable(tn);
                ds.Tables.Add(dt);
                Dictionary<string, DataRow> dicC = dicT[tn];
                foreach (string cn in dicC.Keys)
                {
                    DataRow row = dicC[cn];
                    Type type = factory.GetTypeFromRow(row);
                    if (type == null)
                    {
                        continue;
                    }
                    DataColumn col = new DataColumn(cn, type);
                    dt.Columns.Add(col);
                }
            }
            return ds;
        }
    }
}
