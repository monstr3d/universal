using CategoryTheory;

using Diagram.Attributes;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using NamedTree;

namespace Diagram.TypeScript
{
    [Language("TS", ".ts")]
    internal class DesktopCodeCreator : IDesktopCodeCreator
    {
        Diagram.UI.Performer performer = new Diagram.UI.Performer();
        Performer p = new ();

        public DesktopCodeCreator() { this.AddCodeCreator(); }


        /// <summary>
        /// Creates code for desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="namespacE">The namespace</param>
        /// <param name="className">Name of desktop class</param>
        /// <param name="staticClass">The "static class" sign</param>
        /// <returns>The code</returns>
        List<string> IDesktopCodeCreator.CreateCode(IDesktop desktop, string namespacE, string className, bool staticClass)
        {
            List<ICategoryObject> categoryObjects;
            List<ICategoryArrow> categoryArrows;
            Dictionary<ICategoryObject, int> objects;
            Dictionary<ICategoryArrow, int> arrows;
            performer.Get(desktop, out categoryObjects, out categoryArrows, out objects, out arrows);
            IClassCodeCreator classCodeCreator = StaticExtensionDiagramUI.Creators["TS"];
            var l = new List<string>();
            for (int i = 0; i < categoryObjects.Count; i++)
            {
                var categoryObject = categoryObjects[i];
                var pr = className + "_" + "CategoryObject_" + i;
                var c = classCodeCreator.CreateCode(pr, categoryObject);
                l.AddRange(c);
                l.Add("");
            }
            for (int i = 0; i < categoryArrows.Count; i++)
            {
                var categoryArrow = categoryArrows[i];
                var pr = className + "_" + "CategoryArrow_" + i;
                var c = classCodeCreator.CreateCode(pr, categoryArrow);
                l.AddRange(c);
                l.Add("");
            }
            l.Add("");
            l.Add("");
            var s = p.ClassString(className, "Desktop");
            l.Add("export " + s);
            l.Add("{");
            l.Add("\tconstructor()");

            l.Add("\t{");
            l.Add("\t\tsuper();");
            l.Add("");
            l.Add("\t\tthis.name = \"" + className + "\";");
            l.Add("");
            for (var i = 0; i < categoryObjects.Count; i++)
            {
                var categoryObject = categoryObjects[i] as IAssociatedObject;
                var nac = categoryObject.Object as INamedComponent;
                string name = nac.RootName;
                name = "\"" + name + "\"";
                var pr = "\t\tnew " + className + "_" + "CategoryObject_" + i + "(this, " + name + ");";
                l.Add(pr);
            }
            for (var i = 0; i < categoryArrows.Count; i++)
            {
                var categoryArrow = categoryArrows[i] as IAssociatedObject;
                var nac = categoryArrow.Object as INamedComponent;
                string name = nac.RootName;
                name = "\"" + name + "\"";
                var pr = "\t\tnew " + className + "_" + "CategoryArrow_" + i + "(this, " + name + ");";
                l.Add(pr);
            }
            l.Add("");
            l.Add("\t\tlet arrows  = this.getArrows();");
            l.Add("\t\tlet objects = this.getObjects();");
            l.Add("");
            for (int i = 0; i < categoryArrows.Count; i++)
            {
                var categoryArrow = categoryArrows[i];
                var sn = objects[categoryArrow.Source];
                var tn = objects[categoryArrow.Target];
                l.Add("\t\tarrows[" + i + "].setSource(objects[" + sn + "]);");
                l.Add("\t\tarrows[" + i + "].setTarget(objects[" + tn + "]);");
            }
            for (int i = 0; i < categoryArrows.Count; i++)
            {
                var categoryArrow = categoryArrows[i];
                if (categoryArrow is IPostSetArrow)
                {
                    l.Add("\t\t(arrows[" + i + "] as unknown as IPostSetArrow).postSetArrow();");
                }

            }
            for (var i = 0; i < categoryObjects.Count; i++)
            {
                if (categoryObjects[i] is IPostSetArrow)
                {
                    l.Add("\t\t(objects[" + i + "] as unknown as IPostSetArrow).postSetArrow();");
                }
            }

            l.Add("\t}");
            l.Add("}");
            return l;
        }
    }
}
