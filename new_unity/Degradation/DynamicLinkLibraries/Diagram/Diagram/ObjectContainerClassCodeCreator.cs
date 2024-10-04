using System;
using System.Collections.Generic;
using System.IO;
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
            List<string> l = new List<string>();
            string str = null;
            if (obj is BelongsToCollectionPortable)
            {
                str = "Diagram.UI.BelongsToCollectionPortable";
            }
            if (str != null)
            {
                l.Add(str);
                l.Add("{");
                l.Add("}");
                return l;
            }
            if (!(obj is ObjectContainerPortable))
            {
                return null;
            }
            ObjectContainerPortable oc = obj as ObjectContainerPortable;
            l.Add("Diagram.UI.ObjectContainerPortable");
            l.Add("{");
            l.Add("\tinternal CategoryObject() : base(null)");
            l.Add("\t{");
            l.Add("\t\tdesktop = new Desktop(this);");
           l.Add("\t\tLoad();");
          //  l.Add("\t\tisPostoaded = true;;");
            l.Add("\t}");
            l.Add("");
            List<string> lt = (oc.Desktop as PureDesktop).CreateDesktopCode(preffix + ".CategoryObject",  "Desktop");
            l.Add("\tnew internal class " + lt[0]);
            for (int i = 1; i < lt.Count - 2; i++)
            {
                l.Add("\t" + lt[i]);
            }
            l.Add("");
            l.Add("\tCategoryTheory.ICategoryObject obj;");
            l.Add("");
            l.Add("\tinternal Desktop(CategoryTheory.ICategoryObject obj) : this()");
            l.Add("\t{");
            l.Add("\t\tthis.obj = obj;");
            l.Add("\t}"); 
            l.Add("");
            l.Add("\tpublic override Diagram.UI.Interfaces.IDesktop Root");
            l.Add("\t{");
            l.Add("\t\tget");
            l.Add("\t\t{");
            l.Add("\t\t\tDiagram.UI.Labels.INamedComponent nc = obj.Object as Diagram.UI.Labels.INamedComponent;");
            l.Add("\t\treturn nc.Desktop.Root;");
            l.Add("\t\t}");
            l.Add("\t}");
            l.Add("}");
            l.Add("}");
            return l;
        }



        #endregion
    }
}
