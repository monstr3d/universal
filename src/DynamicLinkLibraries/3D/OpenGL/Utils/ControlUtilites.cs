using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceOpenGL.Utils
{
    public static class ControlUtilites
    {
        static public Dictionary<string, object>[] resources;

        static Func<Dictionary<string, object>[]> res = InitResources;

        static public Dictionary<string, object>[] Resources
        {
            get
            {
                return res();
            }
        }

        static Dictionary<string, object>[] InitResources()
        {
 /*           Dictionary<string, object> resp = new Dictionary<string, object>();
            if (System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToLower().Equals("ru"))
            {
                resp = ResourceService.Resources.CreateLocalizationDictionary(MotionUI.Resources.ResourceConrtol_Ru.ResourceManager);
            }
            resources = new Dictionary<string, object>[]
            {
                resp,
                DiagramUI.Utils.ControlUtilites.Resources[0]
            };*/
            res = PostResources;
            resources = Motion6D.UI.Utils.ControlUtilites.Resources;
            return resources;
        }

        static Dictionary<string, object>[] PostResources()
        {
            return resources;
        }

    }
}
