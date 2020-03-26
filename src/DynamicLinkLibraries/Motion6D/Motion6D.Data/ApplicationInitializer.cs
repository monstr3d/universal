using System;
using System.Collections.Generic;
using System.Text;

using Diagram.UI.Interfaces;
using Diagram.UI;

namespace Motion6D
{
    /// <summary>
    /// Initializer for motoin 6D operations
    /// </summary>
    public class ApplicationInitializer : IApplicationInitializer
    {
        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly ApplicationInitializer Object = new ApplicationInitializer();

        #endregion

        #region Ctor

        private ApplicationInitializer()
        {
        }

        #endregion

        #region IApplicationInitializer Members

        void IApplicationInitializer.InitializeApplication()
        {
           IApplicationInitializer init = DataPerformer.DataPerformerInitializer.Initializer;
           init.InitializeApplication();
           PureDesktop.DesktopPostLoad += MotionDesktopPostLoad.Object.PostLoad;
        }

        #endregion
    }
}
