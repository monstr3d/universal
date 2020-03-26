using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace DataSetService
{

    /// <summary>
    /// Table
    /// </summary>
    public interface ITable
    {

        /// <summary>
        /// Columns' dictionary
        /// </summary>
        Dictionary<string, IColumn> Columns
        {
            get;
        }

        /// <summary>
        /// X - coordinate
        /// </summary>
        int X
        {
            get;
            set;
        }

        /// <summary>
        /// Y - coordinate
        /// </summary>
        int Y
        {
            get;
            set;
        }


        /// <summary>
        /// Table
        /// </summary>
        DataTable Table
        {
            get;
            set;
        }


        /// <summary>
        /// Table name
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Desktop
        /// </summary>
        IDataSetDesktop Desktop
        {
            get;
            set;
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        void Remove();


    }

    /// <summary>
    /// Column
    /// </summary>
    public interface IColumn
    {
        /// <summary>
        /// Partent table
        /// </summary>
        ITable Table
        {
            get;
            set;
        }

        /// <summary>
        /// Column name
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Data column
        /// </summary>
        DataColumn Column
        {
            get;
            set;
        }

        /// <summary>
        /// The "is marked" sign
        /// </summary>
        bool IsMarked
        {
            get;
            set;
        }

        /// <summary>
        /// Column type
        /// </summary>
        string Type
        {
            get;
            set;
        }

        /// <summary>
        /// The "is nullable" sign
        /// </summary>
        bool IsNullable
        {
            get;
            set;
        }

        /// <summary>
        /// The "is null" sign
        /// </summary>
        bool IsNull
        {
            get;
            set;
        }

        /// <summary>
        /// Modifier
        /// </summary>
        string Modifier
        {
            get;
            set;
        }

        /// <summary>
        /// Value
        /// </summary>
        string Value
        {
            get;
            set;
        }

        /// <summary>
        /// Length
        /// </summary>
        int Length
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Chooser of data set factory
    /// </summary>
    public interface IDataSetFactoryChooser
    {
        /// <summary>
        /// Names of factories
        /// </summary>
        string[] Names
        {
            get;
        }

        /// <summary>
        /// Gets facroty by name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The factory</returns>
        IDataSetFactory this[string name]
        {
            get;
        }
    }

    /// <summary>
    /// Factory for data set desktop
    /// </summary>
    public interface IDataSetDesktopFactory
    {
        /// <summary>
        /// Creates default column
        /// </summary>
        IColumn Column
        {
            get;
        }

        /// <summary>
        /// Creates default table
        /// </summary>
        ITable Table
        {
            get;
        }

        /// <summary>
        /// Creates default desktop
        /// </summary>
        IDataSetDesktop Desktop
        {
            get;
        }

        /// <summary>
        /// Creates default link
        /// </summary>
        ILink Link
        {
            get;
        }

        /// <summary>
        /// Copies sesktop
        /// </summary>
        /// <param name="desktop">Prototype</param>
        /// <returns>A copy</returns>
        IDataSetDesktop Copy(IDataSetDesktop desktop);

        /// <summary>
        /// Creares desktop from data set
        /// </summary>
        /// <param name="dataSet">The data set</param>
        /// <returns>The desktop</returns>
        IDataSetDesktop Create(DataSet dataSet);

        /// <summary>
        /// Sets data set to desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="dataSet">The data set</param>
        void Set(IDataSetDesktop desktop, DataSet dataSet);

        /// <summary>
        /// Gets modifiers
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Modifiers</returns>
        string[] GetModifiers(string type);
    }

    /// <summary>
    /// Data set consumer
    /// </summary>
    public interface IDataSetConsumer
    {
        /// <summary>
        /// Adds data set
        /// </summary>
        /// <param name="dataSet">Data set to add</param>
        void Add(DataSet dataSet);

        /// <summary>
        /// Removes data set
        /// </summary>
        /// <param name="dataSet">Data set to remove</param>
        void Remove(DataSet dataSet);

        /// <summary>
        /// Factory
        /// </summary>
        IDataSetFactory Factory
        {
            get;
            set;
        }

        /// <summary>
        /// Add event
        /// </summary>
        event Action<DataSet> OnAdd;

        /// <summary>
        /// Add event
        /// </summary>
        event Action<DataSet> OnRemome;


    }

    /// <summary>
    /// Factory for creating data set metatata from connection
    /// </summary>
    public interface IDataSetFactory
    {
        /// <summary>
        /// Name of factory
        /// </summary>
        string FactoryName
        {
            get;
        }

        /// <summary>
        /// Creates connection
        /// </summary>
        DbConnection Connection
        {
            get;
        }

        /// <summary>
        /// Command
        /// </summary>
        DbCommand Command
        {
            get;
        }

        /// <summary>
        /// Gets metadata data set from connection
        /// </summary>
        /// <param name="connection">The connection</param>
        /// <returns>The metadata data set</returns>
        DataSet GetData(DbConnection connection);

        /// <summary>
        /// Gets metadata data set from connection string
        /// </summary>
        /// <param name="connectionString">The connection</param>
        /// <returns>The metadata data set</returns>
        DataSet GetData(string connectionString);

        /// <summary>
        /// Data adapter
        /// </summary>
        IDbDataAdapter Adapter
        {
            get;
        }

        /// <summary>
        /// Creates type from metadata row
        /// </summary>
        /// <param name="row">The metadata row</param>
        /// <returns>The type</returns>
        Type GetTypeFromRow(DataRow row);

        /// <summary>
        /// Table name in metadata
        /// </summary>
        string TableName
        {
            get;
        }

        /// <summary>
        /// Column name in metadata
        /// </summary>
        string ColumnName
        {
            get;
        }

        /// <summary>
        /// Is nullable in metadata
        /// </summary>
        string IsNullable
        {
            get;
        }

        /// <summary>
        /// Gets string representation of type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The string representation</returns>
        string GetStringFromType(Type type);

        /// <summary>
        /// Generates statement from desktop 
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>The statement</returns>
        string GenerateStatement(IDataSetDesktop desktop);

        /// <summary>
        /// Gets object type
        /// </summary>
        /// <param name="column">Column</param>
        /// <returns>The type</returns>
        object GetObjectType(DataColumn column);

        /// <summary>
        /// Generates script
        /// </summary>
        /// <param name="column">Column</param>
        /// <returns>Script</returns>
        string GenerateScript(IColumn column);

        /// <summary>
        /// Generates create script
        /// </summary>
        /// <param name="table">Table</param>
        /// <returns>Script lines</returns>
        List<string> GenerateScript(ITable table);

        /// <summary>
        /// Generates creation script from metadata
        /// </summary>
        /// <param name="metaData">Meatadata data set</param>
        /// <returns>Creation script</returns>
        List<string> GenerateScript(DataSet metaData);

    }

    /// <summary>
    /// Provider of data set
    /// </summary>
    public interface IDataSetProvider
    {
        /// <summary>
        /// Provided data set
        /// </summary>
        DataSet DataSet
        {
            get;
        }

        /// <summary>
        /// Factory. This object can be null. It is not null for databases (SQL Server, Oracle, ...)
        /// </summary>
        IDataSetFactory Factory
        {
            get;
            set;
        }

        /// <summary>
        /// Change event
        /// </summary>
        event Action<DataSet> Change;
    }

    /// <summary>
    /// Factory of data set provider
    /// </summary>
    public interface IDataSetPoviderFactory
    {
        /// <summary>
        /// Name
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Gets data
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>Data</returns>
        DataSet GetData(string url);

        /// <summary>
        /// Change event
        /// </summary>
        event Action<string> Change;
    }

    /// <summary>
    /// Link between two columns
    /// </summary>
    public interface ILink
    {
        /// <summary>
        /// Source column
        /// </summary>
        IColumn Source
        {
            get;
            set;
        }

        /// <summary>
        /// Target column
        /// </summary>
        IColumn Target
        {
            get;
            set;
        }

        /// <summary>
        /// Desktop
        /// </summary>
        IDataSetDesktop Desktop
        {
            get;
            set;
        }

        /// <summary>
        /// Name of source table
        /// </summary>
        string SourceTable
        {
            get;
            set;
        }

        /// <summary>
        /// Name of target table
        /// </summary>
        string TargetTable
        {
            get;
            set;
        }


        /// <summary>
        /// Name of source column
        /// </summary>
        string SourceColumn
        {
            get;
            set;
        }

        /// <summary>
        /// Name of target column
        /// </summary>
        string TargetColumn
        {
            get;
            set;
        }

        /// <summary>
        /// The "is marked" sign
        /// </summary>
        bool IsMarked
        {
            get;
            set;
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        void Remove();
    }

    /// <summary>
    /// Desktop of data set
    /// </summary>
    public interface IDataSetDesktop
    {
        /// <summary>
        /// Dictionary of tables
        /// </summary>
        Dictionary<string, ITable> Tables
        {
            get;
        }

        /// <summary>
        /// Links
        /// </summary>
        List<ILink> Links
        {
            get;
        }

        /// <summary>
        /// Removes table
        /// </summary>
        /// <param name="table">Table for removing</param>
        void Remove(ITable table);

        /// <summary>
        /// Removes linlk
        /// </summary>
        /// <param name="link">Link for removing</param>
        void Remove(ILink link);
    }

    /// <summary>
    /// Factory of query
    /// </summary>
    public interface IQueryFactory
    {
        /// <summary>
        /// Gets SQL query from desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>The query</returns>
        string GetQuery(IDataSetDesktop desktop);
    }

    


}
