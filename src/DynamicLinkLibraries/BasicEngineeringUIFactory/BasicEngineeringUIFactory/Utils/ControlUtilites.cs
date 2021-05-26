using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicEngineering.UI.Factory.Utils
{
    public static class ControlUtilites
    {
        static public Dictionary<string, object>[] Resources
        {
            get
            {
                return Diagram.UI.Utils.ControlUtilites.Resources;
            }
        }
    }
}
