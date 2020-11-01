using CategoryTheory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gravity_36_36.Wrapper
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionGravity_36_36_Portable
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
        static StaticExtensionGravity_36_36_Portable()
        {
            new CodeCreators.CSCodeCreator();
        }

        #endregion
    }
}
