using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Data.Odbc;
using System.Data.SqlClient;


using DataSetService;




namespace ODBCTableProvider
{
    /// <summary>
    /// Sasic dataset factory
    /// </summary>
    public class ODBCDataSetFactory :  IDataSetFactory
    {

        #region Fields

        static private Dictionary<string, IDataSetFactory> factories = new Dictionary<string, IDataSetFactory>();
 
        private static Dictionary<string, string> serverDictionary = new Dictionary<string,string>();

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly ODBCDataSetFactory Singleton = new ODBCDataSetFactory();

        #endregion

        #region Ctor

        private ODBCDataSetFactory()
        {
        }

        #endregion

        #region IDataSetFactory Members

        /// <summary>
        /// Name of factory
        /// </summary>
        string IDataSetFactory.FactoryName
        {
            get
            {
                return "ODBC";
            }
        }

        /// <summary>
        /// Creates connection
        /// </summary>
        public System.Data.Common.DbConnection Connection
        {
            get
            {
                return new OdbcConnection();

            }
        }

        /// <summary>
        /// Command
        /// </summary>
        public System.Data.Common.DbCommand Command
        {
            get
            {
                return new OdbcCommand();
            }
        }

        /// <summary>
        /// Gets metadata data set from connection
        /// </summary>
        /// <param name="connection">The connection</param>
        /// <returns>The metadata data set</returns>
        public DataSet GetData(System.Data.Common.DbConnection connection)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Gets metadata data set from connection string
        /// </summary>
        /// <param name="connectionString">The connection</param>
        /// <returns>The metadata data set</returns>
        public DataSet GetData(string connectionString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Data adapter
        /// </summary>
        public IDbDataAdapter Adapter
        {
            get
            {
                return new OdbcDataAdapter();
            }
        }

        /// <summary>
        /// Creates type from metadata row
        /// </summary>
        /// <param name="row">The metadata row</param>
        /// <returns>The type</returns>
        public Type GetTypeFromRow(DataRow row)
        {
            return null;
        }

        /// <summary>
        /// Table name in metadata
        /// </summary>
        public string TableName
        {
            get
            {
                return "TABLE_NAME";
            }
        }
   
        /// <summary>
        /// Column name in metadata
        /// </summary>
        public string ColumnName
        {
            get
            {
                return "COLUMN_NAME";
            }
        }

        /// <summary>
        /// Is nullable in metadata
        /// </summary>
        public string IsNullable
        {
            get
            {
                return "IS_NULLABLE";
            }
        }

        /// <summary>
        /// Gets string representation of type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The string representation</returns>
        public string GetStringFromType(Type type)
        {
            return type + "";
        }

        /// <summary>
        /// Generates statement from desktop 
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>The statement</returns>
        public string GenerateStatement(IDataSetDesktop desktop)
        {
            return AbstractDataSetDesktop.GenerateStandardStatement(desktop);
        }

        /// <summary>
        /// Gets object type
        /// </summary>
        /// <param name="column">Column</param>
        /// <returns>The type</returns>
        public object GetObjectType(DataColumn column)
        {
            return column.GetColumnType();
        }

        /// <summary>
        /// Gets modifiers
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Modifiers</returns>
        public string[] GetModifiers(string type)
        {
            return DataSetFactoryPerformer.GetModifiers(type);
        }

        /// <summary>
        /// Generates script
        /// </summary>
        /// <param name="column">Column</param>
        /// <returns>Script</returns>
        public string GenerateScript(IColumn column)
        {
            return column.GenerateScript();
        }

        /// <summary>
        /// Generates create script
        /// </summary>
        /// <param name="table">Table</param>
        /// <returns>Script lines</returns>
        public List<string> GenerateScript(ITable table)
        {
            return table.GenerateScript(this);
        }

        /// <summary>
        /// Generates creation script from metadata
        /// </summary>
        /// <param name="metaData">Meatadata data set</param>
        /// <returns>Creation script</returns>
        public List<string> GenerateScript(DataSet metaData)
        {
            return null;
        }

        #endregion
    }

    /// <summary>
    /// Factory of SQL Server
    /// </summary>
    public class SQLServerFactory : IDataSetFactory
    {
        #region Fields
        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly SQLServerFactory Singleton = new SQLServerFactory();

        #endregion

        #region Ctor

        private SQLServerFactory()
        {
        }

        #endregion

        #region IDataSetFactory Members

        /// <summary>
        /// Name of factory
        /// </summary>
        string IDataSetFactory.FactoryName
        {
            get
            {
                return "SQL Server";
            }
        }

        /// <summary>
        /// Creates connection
        /// </summary>
        System.Data.Common.DbConnection IDataSetFactory.Connection
        {
            get
            {
                return new SqlConnection();
            }
        }

        /// <summary>
        /// Command
        /// </summary>
        System.Data.Common.DbCommand IDataSetFactory.Command
        {
            get
            {
                return new SqlCommand();
            }
        }

        /// <summary>
        /// Gets metadata data set from connection
        /// </summary>
        /// <param name="connection">The connection</param>
        /// <returns>The metadata data set</returns>
        DataSet IDataSetFactory.GetData(System.Data.Common.DbConnection connection)
        {
            DataSet s = new DataSet();
            connection.Open();
            DataTable table = connection.GetSchema("Columns");
            connection.Close();
            Dictionary<string, Dictionary<string, DataRow>> dic = DataSetFactoryChooser.GetTables("TABLE_NAME", "COLUMN_NAME", table);
            foreach (string name in dic.Keys)
            {
                Dictionary<string, DataRow> d = dic[name];
                DataTable dt = new DataTable();
                dt.TableName = name;
                int length = 1;
                foreach (string cn in d.Keys)
                {
                    DataRow row = d[cn];
                    string ty = row["DATA_TYPE"] + "";
                    object o = null;
                    if (ty.Equals("uniqueidentifier"))
                    {
                        o = new Guid();
                    }
                    if (ty.Equals("image"))
                    {
                        o = new byte[2];
                    }
                    if (ty.Equals("nvarchar"))
                    {
                        string str = "";
                        o = str;
                    }
                    if (ty.Equals("varchar"))
                    {
                        o = new char[2];
                    }
                    if (ty.Equals("char"))
                    {
                        o = new char[2];
                        length = (int)row["CHARACTER_MAXIMUM_LENGTH"];
                    }
                    if (ty.Equals("bigint"))
                    {
                        long a = 0;
                        o = a;
                    }
                    if (ty.Equals("int"))
                    {
                        int a = 0;
                        o = a;
                    }
                    if (ty.Equals("datetime"))
                    {
                        o = new DateTime();
                    }
                    if (ty.Equals("float"))
                    {
                        byte prec = (byte) row["NUMERIC_PRECISION"];
                        if (prec == 53)
                        {
                            double a = 0;
                            o = a;
                        }
                    }
                    if (o != null)
                    {
                        Type type = o.GetType();
                        if (o is char[])
                        {
                            type = "".GetType();
                        }
                        DataColumn col = new DataColumn();
                        col.ColumnName = cn;
                        col.DataType = type;
                        string on = row["IS_NULLABLE"] + "";
                        col.AllowDBNull = on.Equals("YES");
                        try
                        {
                            col.MaxLength = length;
                        }
                        catch (Exception)
                        {
                        }
                        dt.Columns.Add(col);
                    }
                }
                s.Tables.Add(dt);
            }
            return s;
        }

        /// <summary>
        /// Gets metadata data set from connection string
        /// </summary>
        /// <param name="connectionString">The connection</param>
        /// <returns>The metadata data set</returns>
        DataSet IDataSetFactory.GetData(string connectionString)
        {
            IDataSetFactory f = this;
            System.Data.Common.DbConnection connection = f.Connection;
            connection.ConnectionString = connectionString;
            DataSet s = new DataSet();
            connection.Open();
            DataTable table = connection.GetSchema("Columns");
            s.Tables.Add(table);
            return s;
        }

        /// <summary>
        /// Data adapter
        /// </summary>
        IDbDataAdapter IDataSetFactory.Adapter
        {
            get
            {
                return new SqlDataAdapter();
            }
        }

        /// <summary>
        /// Creates type from metadata row
        /// </summary>
        /// <param name="row">The metadata row</param>
        /// <returns>The type</returns>
        public Type GetTypeFromRow(DataRow row)
        {
            return null;
        }

        /// <summary>
        /// Table name in metadata
        /// </summary>
        public string TableName
        {
            get
            {
                return "TABLE_NAME";
            }
        }

        /// <summary>
        /// Column name in metadata
        /// </summary>
        public string ColumnName
        {
            get
            {
                return "COLUMN_NAME";
            }
        }

        /// <summary>
        /// Is nullable in metadata
        /// </summary>
        public string IsNullable
        {
            get
            {
                return "IS_NULLABLE";
            }
        }

        /// <summary>
        /// Gets string representation of type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The string representation</returns>
        public string GetStringFromType(Type type)
        {
            return type + "";
        }

        /// <summary>
        /// Generates statement from desktop 
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>The statement</returns>
        public string GenerateStatement(IDataSetDesktop desktop)
        {
            return AbstractDataSetDesktop.GenerateStandardStatement(desktop);
        }

        /// <summary>
        /// Gets object type
        /// </summary>
        /// <param name="column">Column</param>
        /// <returns>The type</returns>
        public object GetObjectType(DataColumn column)
        {
            return column.GetColumnType();
        }

        /// <summary>
        /// Gets modifiers
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Modifiers</returns>
        public string[] GetModifiers(string type)
        {
            return DataSetFactoryPerformer.GetModifiers(type);
        }

        /// <summary>
        /// Generates script
        /// </summary>
        /// <param name="column">Column</param>
        /// <returns>Script</returns>
        public string GenerateScript(IColumn column)
        {
            return column.GenerateScript();
        }


        /// <summary>
        /// Generates create script
        /// </summary>
        /// <param name="table">Table</param>
        /// <returns>Script lines</returns>
        public List<string> GenerateScript(ITable table)
        {
            return table.GenerateScript(this);
        }

        /// <summary>
        /// Generates creation script from metadata
        /// </summary>
        /// <param name="metaData">Meatadata data set</param>
        /// <returns>Creation script</returns>
        public List<string> GenerateScript(DataSet metaData)
        {
            return null;
        }

        #endregion
    }
}
