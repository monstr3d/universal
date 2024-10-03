using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourceService;
using System.Resources;

namespace Common.UI.Resources.Utils
{
    public static class ControlUtilites
    {

        public static Dictionary<string, object>[] Resources
        {
            get
            {
              return  new Dictionary<string, object>[]
                {
                Localizator.Create(new string[] { "rus" },
                    new ResourceManager[]
                    {
                    ResourceControl_Ru.ResourceManager
                    }
                    ).Dictionary
                };
            }
        }
    }
}
