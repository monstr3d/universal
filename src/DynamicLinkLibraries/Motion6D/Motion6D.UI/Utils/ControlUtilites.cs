using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;

using ResourceService;


namespace Motion6D.UI.Utils
{
    /// <summary>
    /// Control utilites
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
                DataPerformer.UI.Utils.ControlUtilites.Resources
            }
            );
    }
}
