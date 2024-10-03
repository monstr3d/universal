using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourceService;
using System.Resources;

namespace Common.Engineering.Localization.Utils
{
    /// <summary>
    /// Control utilites
    /// </summary>
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
            Common.UI.Resources.Utils.ControlUtilites.Resources}
            );
    }
}

