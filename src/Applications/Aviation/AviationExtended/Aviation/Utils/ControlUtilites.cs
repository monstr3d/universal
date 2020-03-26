using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;

using ResourceService;


namespace Aviation.Utils
{
    internal class ControlUtilites
    {
        internal static readonly Dictionary<string, object>[] Resources =
                         Localizator.CreateResources(new Dictionary<string, object>[][]
            {
            Localizator.CreateResources(new string[] { "rus" }, new ResourceManager[]
            {
              ResourceControl_Ru.ResourceManager
            })
            ,
            Motion6D.UI.Utils.ControlUtilites.Resources,
            ControlSystems.Data.UI.Utils.ControlUtilites.Resources
            }
             );
    }
}
