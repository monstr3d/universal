using System;
using System.Collections.Generic;
using System.Text;

using Diagram.UI.Interfaces;

namespace DataSetService.Initialization
{
    /// <summary>
    /// Initializer of data set service
    /// </summary>
    public class DatabaseInitializer : IApplicationInitializer
    {
        /// <summary>
        /// Creates initialiser from factory chooser
        /// </summary>
        /// <param name="chooser">Factory chhoser</param>
        /// <returns>Initializer</returns>
        public static IApplicationInitializer GetInitializer(IDataSetFactoryChooser chooser)
        {
            return new DatabaseInitializer(chooser);
        }


        private DatabaseInitializer(IDataSetFactoryChooser chooser)
        {
            DataSetFactoryChooser.Chooser = chooser;
        }

        #region IApplicationInitializer Members

        void IApplicationInitializer.InitializeApplication()
        {
        }

        #endregion
    }
}
