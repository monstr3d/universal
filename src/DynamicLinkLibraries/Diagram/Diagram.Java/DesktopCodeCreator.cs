using BaseTypes.Attributes;

using CategoryTheory;

using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;
using ErrorHandler;

namespace Diagram.UI.Java
{
    [Language("Java", ".java")]
    public class DesktopCodeCreator : IDesktopCodeCreator
    {
        UI.Performer performer = new UI.Performer();

        public DesktopCodeCreator() { this.AddDesktopCodeCreator(); }

        public static void AddOverride(List<string> l)
        {
            l.Add("\t@Override");
        }


        IComponentCollection collection;

        Tuple<Dictionary<ICategoryObject, int>, Dictionary<ICategoryArrow, int>> dictionary;

        IComponentCollection IDesktopCodeCreator.ComponentCollection => collection;

        Tuple<Dictionary<ICategoryObject, int>, Dictionary<ICategoryArrow, int>> IDesktopCodeCreator.Enumeration => dictionary;

        List<string> IDesktopCodeCreator.CreateCode(IComponentCollection desktop, string namespacE, string className, bool staticClass)
        {
            Exception exception;
            try
            {
                collection = desktop;
                dictionary = performer.Enumerate(collection);
                var l = new List<string>();
                l.Add("package generated;");
                l.Add("");
                l.Add("import diagram.Desktop;");
                l.Add("");
                l.Add("import diagram.interfaces.IDesktop;");
                l.Add("");
                l.Add("import error_handler.interfaces.ICheck;");
                l.Add("");
                l.Add("import error_handler.interfaces.IErrorHandler;");
                l.Add("");
                l.Add("public class " + className + " extends Desktop");
                l.Add("{");
                l.Add("");
                List<ICategoryObject> categoryObjects;
                List<ICategoryArrow> categoryArrows;
                Dictionary<ICategoryObject, int> objects;
                Dictionary<ICategoryArrow, int> arrows;
                performer.Get(desktop, out categoryObjects, out categoryArrows, out objects, out arrows);
                IClassCodeCreator classCodeCreator = StaticExtensionDiagramUI.Creators["Java"];
                for (int i = 0; i < categoryObjects.Count; i++)
                {
                    var categoryObject = categoryObjects[i];
                    var pr = "CategoryObject" + i;
                    var c = classCodeCreator.CreateCode(pr, categoryObject, null);
                    performer.Add(l, c, 1);
                    l.Add("");
                }
                for (int i = 0; i < categoryArrows.Count; i++)
                {
                    var categoryArrow = categoryArrows[i];
                    var pr = "CategoryArrow" + i;
                    var c = classCodeCreator.CreateCode(pr, categoryArrow, null);
                    performer.Add(l, c, 1);
                    l.Add("");
                }

                l.Add("\tpublic " + className + "() {");
                l.Add("\t\tsuper();");
                l.Add("\t}");
                l.Add("");

                l.Add("\tpublic " + className + "(ICheck check, IErrorHandler errorHandler) {");
                l.Add("\t\tsuper(check, errorHandler);");
                l.Add("\t}");
                l.Add("");

                l.Add("");
                AddOverride(l);
                l.Add("\tpublic void init()");
                l.Add("\t{");
                for (int i = 0; i < categoryObjects.Count; i++)
                {
                    var o = categoryObjects[i];
                    var r = performer.GetRootName(o);
                    l.Add("\t\tnew " + className + ".CategoryObject" + i +
                        "(\"" + r + "\", this);");
                }
                for (int i = 0; i < categoryArrows.Count; i++)
                {
                    l.Add("\t\tnew " + className + ".CategoryArrow" + i +
                        "(\"" + performer.GetRootName(categoryArrows[i]) + "\", this);");
                }
                for (int i = 0; i < categoryArrows.Count; i++)
                {
                    var categoryArrow = categoryArrows[i];
                    var sn = objects[categoryArrow.Source];
                    var tn = objects[categoryArrow.Target];
                    l.Add("\t\tarrows.get(" + i + ").setSource(objects.get(" + sn + "));");
                    l.Add("\t\tarrows.get(" + i + ").setTarget(objects.get(" + tn + "));");
                }
                l.Add("\t\tpostSet();");
                l.Add("\t}");
                l.Add("");
                l.Add("");
                l.Add("}");

                return l;
            }
            catch (Exception ex)
            {
                exception = IncludedException.Get(ex);
            }
            throw exception;
        }
    }
}
