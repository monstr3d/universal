using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ResourceService;

namespace BasicEngineering.UI.Factory.Advanced
{
    /// <summary>
    /// Static methods
    /// </summary>
    static class StaticExtensionBasicEngineeringUIFactoryAdvanced
    {

        internal static void Prepare(Dictionary<string, object>[] res)
        {
            resources = Localizator.CreateResources(new Dictionary<string, object>[][]
            {
                res,
                Common.Engineering.Localization.Utils.ControlUtilites.Resources,
                Common.UI.Resources.Utils.ControlUtilites.Resources
            });

        }

        private static Dictionary<string, object>[] resources;

  
        internal static void LoadControlResources(this Control control)
        {
            control.LoadControlResources(resources);
        }

        internal static string Localize(this string str)
        {
            return str.GetControlResource(resources);
        }

        internal static Dictionary<string, object>[] Resources
        {
            get
            {
                return resources;
            }
        }
    }
}
