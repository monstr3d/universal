using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Data;
using System.Data.Common;

using CategoryTheory;

using Diagram.UI;
using ErrorHandler;

namespace DataSetService
{
    /// <summary>
    /// Abstract data provider
    /// </summary>
    public abstract class AbstractDataProvider : CategoryObject, ISerializable, IDataSetProvider
    {
        #region Fields

        /// <summary>
        /// Connection string
        /// </summary>
        protected string connectionString;

        /// <summary>
        /// Statement
        /// </summary>
        protected string statement;

        /// <summary>
        /// Desktop
        /// </summary>
        protected IDataSetDesktop desktop;

        /// <summary>
        /// Factory
        /// </summary>
        protected IDataSetFactory factory;

        /// <summary>
        /// Parameters of statement
        /// </summary>
        protected Dictionary<string, string> parameters = new Dictionary<string, string>();

        /// <summary>
        /// Change event
        /// </summary>
        protected Action<DataSet> change = (DataSet ds) => { };

        

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public AbstractDataProvider()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public AbstractDataProvider(SerializationInfo info, StreamingContext context)
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
        }


        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
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
        }

        #endregion

        #region IDataSetProvider Members
        
        /// <summary>
        /// Provided data set
        /// </summary>
        public abstract DataSet DataSet
        {
            get;
        }


        /// <summary>
        /// Factory
        /// </summary>
        public virtual IDataSetFactory Factory
        {
            get
            {
                return factory;
            }
            set
            {
                factory = value;
            }
        }

        event Action<DataSet> IDataSetProvider.Change
        {
            add { change += value; }
            remove { change -= value; }
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Desktop
        /// </summary>
        public IDataSetDesktop Desktop
        {
            get
            {
                return desktop;
            }
            set
            {
                desktop = value;
            }
        }

        /// <summary>
        /// Coonection string
        /// </summary>
        public string ConnecionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }

        /// <summary>
        /// Statement
        /// </summary>
        public string Statement
        {
            get
            {
                return statement;
            }
            set
            {
                statement = value;
            }
        }
        /// <summary>
        /// Final statement
        /// </summary>
        public string FinalStatement
        {
            get
            {
                string s = statement + "";
                foreach (string k in parameters.Keys)
                {
                    s = s.Replace(k, parameters[k]);
                }
                return s;
            }
        }

        /// <summary>
        /// Statement parameters
        /// </summary>
        public Dictionary<string, string> Parameters
        {
            get
            {
                return parameters;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                parameters = value;
            }
        }

        #endregion

    }
}
