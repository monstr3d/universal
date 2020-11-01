using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using DataSetService;

namespace DataSetSerializable
{
    /// <summary>
    /// Serializable table
    /// </summary>
    [SerializableAttribute()]
    public class TableSerializable : AbstractTable, ISerializable
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TableSerializable()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public TableSerializable(SerializationInfo info, StreamingContext context)
        {
            x = (int) info.GetValue("X", typeof(int));
            y = (int) info.GetValue("Y", typeof(int));
            name = info.GetValue("Name", typeof(string)) + "";
            try
            {
                columns = info.GetValue("Columns", typeof(Dictionary<string, IColumn>)) as Dictionary<string, IColumn>;
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", x);
            info.AddValue("Y", y);
            info.AddValue("Name", name);
            info.AddValue("Columns", columns);
        }

        #endregion

    }

    /// <summary>
    /// Sertializable limk
    /// </summary>
    [SerializableAttribute()]
    public class LinkSerializable : AbstractLink, ISerializable
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        internal LinkSerializable()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public LinkSerializable(SerializationInfo info, StreamingContext context)
        {
            sourceTable = info.GetValue("SourceTable", typeof(string)) + "";
            targetTable = info.GetValue("TargetTable", typeof(string)) + "";
            sourceColumn = info.GetValue("SourceColumn", typeof(string)) + "";
            targetColumn = info.GetValue("TargetColumn", typeof(string)) + "";
            isMarked = (bool)info.GetValue("IsMarked", typeof(bool));

        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SourceTable", sourceTable);
            info.AddValue("TargetTable", targetTable);
            info.AddValue("SourceColumn", sourceColumn);
            info.AddValue("TargetColumn", targetColumn);
            info.AddValue("IsMarked", isMarked);
        }

        #endregion
    }

    /// <summary>
    /// Serializable column
    /// </summary>
    [SerializableAttribute()]
    public class ColumnSerializable : AbstractColumn, ISerializable
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ColumnSerializable()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public ColumnSerializable(SerializationInfo info, StreamingContext context)
        {
            name = info.GetValue("Name", typeof(string)) + "";
            isMarked = (bool)info.GetValue("IsMarked", typeof(bool));
            try
            {
                type = info.GetValue("Type", typeof(string)) + "";
                isNullable = (bool)info.GetValue("IsNullable", typeof(bool));
                isNull = (bool)info.GetValue("IsNull", typeof(bool));
                modifier = info.GetValue("Modifier", typeof(string)) + "";
                val = info.GetValue("Value", typeof(string)) + "";
                length = (int)info.GetValue("Length", typeof(int));
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", name);
            info.AddValue("IsMarked", isMarked);
            if (type != null)
            {
                info.AddValue("Type", type);
            }
            info.AddValue("IsNullable", isNullable, typeof(bool));
            info.AddValue("IsNull", isNull, typeof(bool));
            info.AddValue("Modifier", modifier, typeof(string));
            info.AddValue("Value", val, typeof(string));
            info.AddValue("Length", length, typeof(int));
        }

        #endregion

    }

    /// <summary>
    /// Serializable desktop
    /// </summary>
    [SerializableAttribute()]
    public class DataDesktopSerializable : AbstractDataSetDesktop, ISerializable
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataDesktopSerializable()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public DataDesktopSerializable(SerializationInfo info, StreamingContext context)
        {
            try
            {
                tables = info.GetValue("Tables", typeof(Dictionary<string, ITable>)) as Dictionary<string, ITable>;
                links = info.GetValue("Links", typeof(List<ILink>)) as List<ILink>;
                foreach (ITable table in tables.Values)
                {
                    table.Desktop = this;
                }
                foreach (ILink link in links)
                {
                    link.Desktop = this;
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Overriden


        /// <summary>
        /// Creates default column
        /// </summary>
        public override IColumn Column
        {
            get
            {
                return new ColumnSerializable();
            }
        }

        /// <summary>
        /// Creates default table
        /// </summary>
        public override ITable Table
        {
            get
            {
                return new TableSerializable();
            }
        }

        /// <summary>
        /// Creates default link
        /// </summary>
        public override ILink Link
        {
            get
            {
                return new LinkSerializable();
            }
        }


        /// <summary>
        /// Creates default desktop
        /// </summary>
        public override IDataSetDesktop Desktop
        {
            get
            {
                return new DataDesktopSerializable();
            }
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Tables", tables);
            info.AddValue("Links", links);
        }

        #endregion
    }
}
