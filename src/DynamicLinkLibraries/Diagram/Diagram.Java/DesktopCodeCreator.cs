using BaseTypes.Attributes;

using CategoryTheory;

using Diagram.CodeCreators;
using Diagram.UI.Interfaces;

using ErrorHandler;

namespace Diagram.UI.Java
{
    [Language("Java", ".java")]
    public class DesktopCodeCreator : AbstractDesktopCodeCreator
    {

        public DesktopCodeCreator() : base(false) { this.AddDesktopCodeCreator(); }

        public static void AddOverride(List<string> l)
        {
            l.Add("\t@Override");
        }

        protected override List<string> CreateClasses(IComponentCollection collection, string namespacE, string className, bool staticClass)
        {
            var l = new List<string>(); 
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
            return l;
        }

        protected override List<string> CreateObjects(IComponentCollection collection, string namespacE, string className, bool staticClass)
        {
            var l = new List<string>(); 
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
            return l;

        }

        protected override List<string> CreateLinks(IComponentCollection collection, string namespacE, string className, bool staticClass)
        {
            var l = new List<string>();
            for (int i = 0; i < categoryArrows.Count; i++)
            {
                var categoryArrow = categoryArrows[i];
                var sn = objects[categoryArrow.Source];
                var tn = objects[categoryArrow.Target];
                l.Add("\t\tarrows.get(" + i + ").setSource(objects.get(" + sn + "));");
                l.Add("\t\tarrows.get(" + i + ").setTarget(objects.get(" + tn + "));");
            }
            return l;
        }


        protected override List<string> CreateCode(IComponentCollection desktop, string namespacE, string className, 
            bool staticClass)
        {
            Exception exception;
            try
            {
                var l = base.CreateCode(desktop, namespacE, className, staticClass);
                l.Add("package generated;");
                l.Add("");
                l.Add("import java.util.concurrent.CompletableFuture;");
                l.Add("");
                l.Add("import java.util.concurrent.ExecutionException;");
                l.Add("");
                l.Add("import cancellation.interfaces.ICancellation;");
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
                classCodeCreator = StaticExtensionDiagramUI.Creators["Java"];
                if (staticClass)
                {
                    l.Add("\tpublic static IDesktop getDesktop(ICheck check, IErrorHandler errorHandler, ICancellation cancellation)");
                    l.Add("\t{");
                    l.Add("\ttry {");
                    var n = 0;
                    desktop.ForEach((IInitializeTask task) => { ++n; });



                    l.Add("\t\tvar desktop = new " + className + "(check, errorHandler);");
                    if (n == 0)
                    {
                        l.Add("\t\tdesktop.finish();");
                        l.Add("return desktop;");
                        l.Add("\t}");
                        l.Add("");
                        return l;
                    }


                    l.Add("\t\tvar inits = desktop.getTaskInitializers(cancellation);");
                    if (n == 1)
                    {
                        l.Add("\t\tvar all = inits.get(0);");

                    }
                    else
                    {
                        l.Add("\t\tvar all = CompletableFuture.allOf(");
                        for (var i = 0; i < n; i++)
                        {
                            var s = "\t\t\tinits.get(" + i + ")";
                            if (i + 1 < n)
                            {
                                s += ",";
                            }

                            l.Add(s);

                        }
                        l.Add("\t\t);");
                    }
                    l.Add("\t\tall.get();");
                    l.Add("\t\tdesktop.finish();");
                    l.Add("return desktop;");
                    l.Add("\t}");
                    l.Add("catch (InterruptedException | ExecutionException e) {");
                    l.Add("throw new RuntimeException(e); }");
                    l.Add("\t}");
                    l.Add("");
                }
                var ll = CreateClasses(desktop, namespacE, className, staticClass);
                performer.Add(l, ll, 1);

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
                ll = CreateObjects(desktop, namespacE, className, staticClass);
                performer.Add(l, ll, 1);
                if (!staticClass)
                {
                    l.Add("\t\tfinish();");
                }
                l.Add("\t}");
                l.Add("");
                AddOverride(l);
                l.Add("\tprotected void finish()");
                l.Add("\t{");
                ll = CreateLinks(desktop, namespacE, className, staticClass);
                performer.Add(l, ll, 2);
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
