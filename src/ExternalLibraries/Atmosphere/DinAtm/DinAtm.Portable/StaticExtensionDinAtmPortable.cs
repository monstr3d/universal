using AssemblyService.Attributes;
using CategoryTheory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinAtm.Portable
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDinAtmPortable
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
        static StaticExtensionDinAtmPortable()
        {
            new CodeCreators.CSCodeCreator();
        }

        #endregion
    }
}
