using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;


using CategoryTheory;

using Diagram.UI;

namespace DataSetService
{
    /// <summary>
    /// Wrapper of statement
    /// </summary>
    [Serializable()]
    public class StatementWrapper : AbstractDataProvider, IDisposable
    {

        #region Fields

        /// <summary>
        /// Name of factory
        /// </summary>
        protected string factoryName;

        /// <summary>
        /// Database command
        /// </summary>
        protected DbCommand command;
 
        /// <summary>
        /// Database connection
        /// </summary>
        protected DbConnection connection;

        /// <summary>
        /// Data adapter
        /// </summary>
        private IDbDataAdapter adapter;

        /// <summary>
        /// Data set
        /// </summary>
        private DataSet dataSet;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constuctor
        /// </summary>
        public StatementWrapper()
        {
        
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private StatementWrapper(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            factoryName = info.GetValue("FactoryName", typeof(string)) + "";
            Init(info, context);
        }


        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("FactoryName", factoryName);
        }

        #endregion

        #region Members
        
        /// <summary>
        /// Schema of dataset
        /// </summary>
        public DataSet Schema
        {
            get
            {
                IDataSetFactory factory = DataSetFactoryChooser.Chooser[factoryName];
                DbConnection connection = factory.Connection;
                connection.ConnectionString = connectionString.ConvertConnectionString();
                return factory.GetData(connection);
            }
        }

        /// <summary>
        /// Provided data set
        /// </summary>
        public override DataSet DataSet
        {
            get
            {
                try
                {
                    if (dataSet == null)
                    {
                        StreamingContext ctx = new StreamingContext();
                        Init(null, ctx);
                        connection.Open();
                        dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        connection.Close();
                        change(dataSet);
                    }
                    return dataSet;
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                }
                return null;
            }
        }

        /// <summary>
        /// Updates itself
        /// </summary>
        public void Update()
        {
            dataSet = null;
        }

        /// <summary>
        /// Name of factory
        /// </summary>
        public string FactoryName
        {
            get
            {
                return factoryName;
            }
            set
            {
                factoryName = value;
                if (value != null)
                {
                    factory = DataSetFactoryChooser.Chooser[factoryName];
                }
            }
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected virtual void Init(SerializationInfo info, StreamingContext context)
        {
            factory = DataSetFactoryChooser.Chooser[factoryName];
            connection = factory.Connection;
            connection.ConnectionString = 
                connectionString.ConvertConnectionString(); ;
            command = factory.Command;
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = FinalStatement;
            adapter = factory.Adapter;
            adapter.SelectCommand = command;
        }

        #endregion

        #region IRemovableObject Members

        void IDisposable.Dispose()
        {
            if (dataSet != null)
            {
                dataSet.Dispose();
            }
        }

        #endregion
    }
}
