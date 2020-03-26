using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Motion6D
{
    /// <summary>
    /// Extension of methods
    /// </summary>
    [CategoryTheory.InitAssembly]
    public static class StaticExtensionMotion6DData
    {


        static private bool first = true;

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {
            if (!first)
            {
                return;
            }
            first = false;
        }
    }
}
