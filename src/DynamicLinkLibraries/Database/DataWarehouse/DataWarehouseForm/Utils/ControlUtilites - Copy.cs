using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;

using ResourceService;

namespace DataWarehouse.Utils
{
    /// <summary>
    /// Database control utilites
    /// </summary>
    public static class ControlUtilites
    {
        /// <summary>
        /// Resources
        /// </summary>
        static public readonly Dictionary<string, object>[] Resources =
            Localizator.CreateResources(new Dictionary<string, object>[][]
            {
                Localizator.CreateResources(new string[] {"rus"}, 
                new ResourceManager[]
                {
                    ResourceControl_Ru.ResourceManager
                }),
                Common.UI.Resources.Utils.ControlUtilites.Resources,
            }
            );
    }
}
