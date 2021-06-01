
using System;
using System.Collections.Generic;
using System.Text;

using AssemblyService.Attributes;


namespace Gravity_36_36.Wrapper
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionGravityWrapper
    {

        #region Public Members

        /// <summary>
        /// Inits itself
        /// </summary>
        public static void Init()
        {

        }

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionGravityWrapper()
        {
            new CodeCreators.CSCodeCreator();
        }

        #endregion
    }
}
