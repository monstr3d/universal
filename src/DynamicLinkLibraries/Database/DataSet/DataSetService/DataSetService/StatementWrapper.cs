using DataSetService.Pure;
using DataSetService.Pure.Interfaces;
using ErrorHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;

namespace DataSetService
{
    /// <summary>
    /// Wrapper of statement
    /// </summary>
    [Serializable()]
    public class StatementWrapper : Pure.StatementWrapper, ISerializable
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
        {
            connectionString = info.GetValue("ConnectionString", typeof(string)) + "";
            statement = info.GetValue("Statement", typeof(string)) + "";
            try
            {
                desktop = info.GetValue("Desktop", typeof(object)) as IDataSetDesktop;
            }
            catch (Exception ex)
            {
                ex.HandleException(-1);
            }
            try
            {
                parameters = info.GetValue("Parameters", typeof(Dictionary<string, string>)) as Dictionary<string, string>;
            }
            catch (Exception exc)
            {
                exc.HandleException(10);
            }
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
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ConnectionString", connectionString);
            info.AddValue("Statement", statement);
            info.AddValue("Parameters", parameters, typeof(Dictionary<string, string>));
            if (desktop != null)
            {
                if (desktop is ISerializable)
                {
                    info.AddValue("Desktop", desktop);
                }
            }
            info.AddValue("FactoryName", factoryName);
        }

        #endregion

        
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
                    ex.HandleException(10);
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

 
    }
}
