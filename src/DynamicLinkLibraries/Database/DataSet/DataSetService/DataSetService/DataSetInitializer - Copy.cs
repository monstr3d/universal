using System;
using System.Collections.Generic;
using System.Text;
using Diagram.UI.Interfaces;

namespace DataSetService
{
    /// <summary>
    /// DataSet service Initializer
    /// </summary>
    public class DataSetInitializer : IApplicationInitializer
    {

        #region Fields

        private IDataSetFactoryChooser chooser;

        private static bool isInitialized = false;

        #endregion

        #region Ctor

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="chooser">DataSet factory chooser</param>
        private DataSetInitializer(IDataSetFactoryChooser chooser)
        {
            this.chooser = chooser;
        }

        #endregion

        #region IApplicationInitializer Members

        void IApplicationInitializer.InitializeApplication()
        {
            DataSetFactoryChooser.Chooser = chooser;
        }

        #endregion

        #region Members

        /// <summary>
        /// Initializer of database chooser
        /// </summary>
        /// <param name="chooser">Database chooser</param>
        /// <returns>the initializer</returns>
        public static IApplicationInitializer Create(DataSetFactoryChooser chooser)
        {
            if (isInitialized)
            {
                throw new Exception("Data factory is already initialized");
            }
            isInitialized = true;
            return new DataSetInitializer(chooser);
        }

        #endregion
    }
}
