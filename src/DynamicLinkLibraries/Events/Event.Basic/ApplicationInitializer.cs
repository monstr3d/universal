using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI.Interfaces;

using Event.Interfaces;
using Event.Portable;

namespace Event.Basic
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
            StaticExtensionEventPortable.ActionFactoryCreator =
               DataPerformer.Portable.StaticExtensionDataPerformerPortable.Factory as IActionFactoryCreator;
        }

        #endregion
    }
}
