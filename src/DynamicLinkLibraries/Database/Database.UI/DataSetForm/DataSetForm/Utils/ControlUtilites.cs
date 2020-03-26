using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;

using ResourceService;

namespace DataSetService.Forms.Utils
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
                    global::DataSetService.Utils.ResourceControl_Ru.ResourceManager
                })
            }
             );
    }
}
