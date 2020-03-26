using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagram.UI.Interfaces;

namespace Diagram.UI
{
    class ObjectContainerClassCodeCreator : IClassCodeCreator
    {

        internal ObjectContainerClassCodeCreator()
        {
            this.AddCSharpCodeCreator();
        }

        #region IClassCodeCreator Members

        List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
        {
            if (!(obj is ObjectContainerPortable))
            {
                return null;
            }
            List<string> l = new List<string>();
            ObjectContainerPortable oc = obj as ObjectContainerPortable;
            l.Add("Diagram.UI.ObjectContainerPortable");
            l.Add("{");
            l.Add("\tinternal CategoryObject() : base(null)");
            l.Add("\t{");
            l.Add("\t\tdesktop = new Desktop();");
           l.Add("\t\tLoad();");
          //  l.Add("\t\tisPostoaded = true;;");
            l.Add("\t}");
            l.Add("");
            List<string> lt = (oc.Desktop as PureDesktop).CreateDesktopCode(preffix + ".CategoryObject",  "Desktop");
            l.Add("\tnew internal class " + lt[0]);
            for (int i = 1; i < lt.Count; i++)
            {
                l.Add("\t" + lt[i]);
            }
            l.Add("}");
            return l;
        }



        #endregion
    }
}
