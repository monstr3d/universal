using System.Collections.Generic;
using Diagram.UI.Portable;
using Diagram.UI.Interfaces;
using Diagram.Attributes;


namespace Diagram.UI
{
    [Language("C#")]
    class ObjectContainerClassCodeCreator : IClassCodeCreator
    {

        internal ObjectContainerClassCodeCreator()
        {
            this.AddCodeCreator(); ;
        }


        #region IClassCodeCreator Members

        List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
        {           
            List<string> l = new List<string>();
            string str = null;
            if (obj is BelongsToCollection)
            {
                str = "Diagram.UI.Portable.BelongsToCollection";
            }
            if (str != null)
            {
                l.Add(str);
                l.Add("{");
                l.Add("}");
                return l;
            }
            if (obj is ObjectContainer oc)
            {
                l.Add(" Diagram.UI.Portable.ObjectContainer");
                l.Add("{");
                l.Add("\tinternal CategoryObject(Diagram.UI.Labels.IObjectLabel label) : base(null)");
                l.Add("\t{");
                l.Add("\t\tObject = label;");
                l.Add("\t\tdesktop = new Desktop(this);");
                l.Add("\t\tLoad();");
                //  l.Add("\t\tisPostoaded = true;;");
                l.Add("\t}");
                l.Add("");
                List<string> lt = ((oc as IObjectContainer).Desktop as PureDesktop).CreateDesktopCode(preffix + ".CategoryObject", "Desktop");
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
            return null;
        }



        #endregion
    }
}
