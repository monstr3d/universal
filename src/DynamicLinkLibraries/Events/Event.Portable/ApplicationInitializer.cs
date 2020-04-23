using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI.Interfaces;

using Event.Interfaces;

namespace Event.Portable
{
    /// <summary>
    /// Application initializer
    /// </summary>
    public class ApplicationInitializer : IApplicationInitializer
    {

        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static IApplicationInitializer Singleton = new ApplicationInitializer();

        #endregion

        #region Ctor

        private ApplicationInitializer()
        {
        }

        #endregion

        #region IApplicationInitializer Members

        void IApplicationInitializer.InitializeApplication()
        {

            DataPerformer.Portable.StaticExtensionDataPerformerPortable.Factory = 
                DataPerformer.Runtime.DataRuntimeFactory.Singleton;
            StaticExtensionEventPortable.ActionFactoryCreator =
               DataPerformer.Portable.StaticExtensionDataPerformerPortable.Factory as IActionFactoryCreator;
        }

        #endregion
    }
}
