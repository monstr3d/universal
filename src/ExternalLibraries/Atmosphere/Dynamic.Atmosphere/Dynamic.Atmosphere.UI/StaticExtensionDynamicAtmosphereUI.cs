using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI;

using Dynamic.Atmosphere.UI.Factory;

namespace Dynamic.Atmosphere.UI
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDynamicAtmosphereUI
    {
        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        static StaticExtensionDynamicAtmosphereUI()
        {
            (new UIFactory()).Add();
        }
    }
}
