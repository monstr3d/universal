using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;

using ResourceService;

namespace ControlSystems.UI.Utils
{
    public static class ControlUtilites
    {
        public static readonly Dictionary<string, object>[] Resources =
            Localizator.CreateResources(new Dictionary<string, object>[][]
            {
            Localizator.CreateResources(new string[] { "rus" }, new ResourceManager[]
            {
                ResourceControl_Ru.ResourceManager
            })
            ,
            Common.Engineering.Localization.Utils.ControlUtilites.Resources}
            );
    }
}