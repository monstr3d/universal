using System.Data;

using CategoryTheory;

using DataSetService.Pure.Interfaces;

namespace DataSetService.Pure
{
    /// <summary>
    /// Abstract data provider
    /// </summary>
    public abstract class AbstractDataProvider : CategoryObject, IDataSetProvider
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
