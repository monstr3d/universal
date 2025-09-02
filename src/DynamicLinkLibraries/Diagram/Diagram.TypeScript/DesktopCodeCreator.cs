using BaseTypes.Attributes;
using CategoryTheory;

using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using NamedTree;

namespace Diagram.UI.TypeScript
{
    [Language("TS", ".ts")]
    internal class DesktopCodeCreator : IDesktopCodeCreator
    {
        UI.Performer performer = new ();
 
        
        Performer p = new();

        string Current
        {
            get;
            set;
        }

        IComponentCollection collection;

        Tuple<Dictionary<ICategoryObject, int>, Dictionary<ICategoryArrow, int>> dictionary;

        IComponentCollection IDesktopCodeCreator.ComponentCollection => collection;

        Tuple<Dictionary<ICategoryObject, int>, Dictionary<ICategoryArrow, int>> IDesktopCodeCreator.Enumeration => dictionary;

        public DesktopCodeCreator() { this.AddDesktopCodeCreator(); }


        /// <summary>
        /// Creates code for desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="namespacE">The namespace</param>
        /// <param name="className">Name of desktop class</param>
        /// <param name="staticClass">The "static class" sign</param>
        /// <returns>The code</returns>
        List<string> IDesktopCodeCreator.CreateCode(IComponentCollection desktop, string namespacE, string className, bool staticClass)
        {
            Exception ex;
            try
            {
                this.collection = desktop;
                dictionary = performer.Enumerate(desktop);
                List<ICategoryObject> categoryObjects;
                List<ICategoryArrow> categoryArrows;
                Dictionary<ICategoryObject, int> objects;
                Dictionary<ICategoryArrow, int> arrows;
                performer.Get(desktop, out categoryObjects, out categoryArrows, out objects, out arrows);
                IClassCodeCreator classCodeCreator = performer.GetLaguageObject<IClassCodeCreator>(this);
                    // StaticExtensionDiagramUI.Creators["TS"]
                var l = new List<string>();
                for (int i = 0; i < categoryObjects.Count; i++)
                {
                    var categoryObject = categoryObjects[i];
                    var pr = className + "_" + "CategoryObject_" + i;
                    Current = pr;
                    var c = classCodeCreator.CreateCode(pr, categoryObject, null);
                    l.AddRange(c);
                    l.Add("");
                }
                for (int i = 0; i < categoryArrows.Count; i++)
                {
                    var categoryArrow = categoryArrows[i];
                    var pr = className + "_" + "CategoryArrow_" + i;
                    var c = classCodeCreator.CreateCode(pr, categoryArrow, null);
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

                l.Add("\t\tlet objects = this.getCategoryObjects();");
                l.Add("\t\tlet arrows = this.getCategoryArrows();");
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
            catch (Exception e)
            {
                ex = ErrorHandler.IncludedException.Get(e);
            }
            throw ex;
        }
    }
}
