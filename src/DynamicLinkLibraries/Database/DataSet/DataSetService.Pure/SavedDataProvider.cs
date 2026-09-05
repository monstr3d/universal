using System.Data;

using CategoryTheory;

using DataSetService.Pure.Interfaces;


namespace DataSetService.Pure
{
    /// <summary>
    /// Data provider from xml
    /// </summary>
    public class SavedDataProvider : CategoryObject, IDataSetProvider
    {

        #region Fields

        /// <summary>
        /// Data set
        /// </summary>
        protected DataSet dataSet = new DataSet();

        /// <summary>
        /// Change event
        /// </summary>
        protected Action<DataSet> change = (DataSet ds) => { };


        #endregion

        #region Ctor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SavedDataProvider()
        {
        
        }

  
        #endregion


        #region IDataSetProvider Members

        DataSet IDataSetProvider.DataSet
        {
            get { return dataSet; }
        }

        IDataSetFactory IDataSetProvider.Factory
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        event Action<DataSet> IDataSetProvider.Change
        {
            add { change += value; }
            remove { change -= value; }
        }

        #endregion

        #region Members

        /// <summary>
        /// Sets Data set
        /// </summary>
        /// <param name="dataSet"></param>
        public void Set(DataSet dataSet)
        {
            this.dataSet = dataSet;
            change(dataSet);
        }

        #endregion

    }
}
