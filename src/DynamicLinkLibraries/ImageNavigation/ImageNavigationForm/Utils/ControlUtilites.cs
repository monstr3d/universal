using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;

using ResourceService;

namespace ImageNavigation.Utils
{
    public static class ControlUtilites
    {
        static public readonly Dictionary<string, object>[] Resources =
            Localizator.CreateResources(new Dictionary<string, object>[][]
            {
                Localizator.CreateResources(new string[] {"rus"}, 
                new ResourceManager[]
                {
                    ResourceControl_Ru.ResourceManager
                }),
               Diagram.UI.Utils.ControlUtilites.Resources
            }
            );
    }
}