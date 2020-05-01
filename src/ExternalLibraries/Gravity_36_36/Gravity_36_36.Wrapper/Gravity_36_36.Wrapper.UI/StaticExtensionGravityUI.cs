using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;
using Gravity_36_36.Wrapper.UI.Factory;

namespace Gravity_36_36.Wrapper.UI
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionGravityUI
    {
      
        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {
        }

        static StaticExtensionGravityUI()
        {
            new UIFactory();
        }

    }
}
