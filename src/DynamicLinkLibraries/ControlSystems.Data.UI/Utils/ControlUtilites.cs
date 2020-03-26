using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using ResourceService;

namespace ControlSystems.Data.UI.Utils
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
                ControlSystems.UI.Utils.ControlUtilites.Resources,
DataPerformer.UI.Utils.ControlUtilites.Resources
            }
            );
    }
}
