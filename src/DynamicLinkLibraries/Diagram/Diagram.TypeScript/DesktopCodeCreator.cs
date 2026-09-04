using BaseTypes.Attributes;
using CategoryTheory;
using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using NamedTree.Interfaces;

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

        protected virtual Dictionary<object, string> Loaded { get; } = new Dictionary<object, string>();

        Dictionary<object, string> IDesktopCodeCreator.Loaded => Loaded;



        public DesktopCodeCreator() { this.AddDesktopCodeCreator(); }


        /// <summary>
        /// Creates code for desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="namespacE">The namespace</param>
        /// <param name="className">Name of desktop class</param>
        /// <param name="staticClass">The "static class" sign</param>
        /// <returns>The code</returns>
        List<string> IDesktopCodeCreator.CreateCode(IComponentCollection desktop, string namespacE, 
            string className, bool staticClass)
        {
            Exception ex;

            try
            {
                Loaded.Clear();
                collection = desktop;
                dictionary = performer.Enumerate(desktop);
                List<ICategoryObject> categoryObjects;
                List<ICategoryArrow> categoryArrows;
                Dictionary<ICategoryObject, int> objects;
                Dictionary<ICategoryArrow, int> arrows;
                performer.Get(desktop, out categoryObjects, out categoryArrows, out objects, out arrows);
                IClassCodeCreator classCodeCreator = performer.GetLaguageObject<IClassCodeCreator>(this);
                classCodeCreator.DesktopCodeCreator = this;
                var l = new List<string>();
                int j = 0;
                foreach  (var categoryObject in categoryObjects)
                {
                    if (Loaded.ContainsKey(categoryObject))
                    {
                        continue;
                    }
                    var pr = className + "_" + "CategoryObject_" + j;
                    Current = pr;
                    var c = classCodeCreator.CreateCode(pr, categoryObject, null);
                    if (!Loaded.ContainsKey(categoryObject))
                    {
                        Loaded[categoryObject] = pr;
                    }
                    l.AddRange(c);
                    l.Add("");
                    ++j;
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
                l.Add("");
                l.Add("\tpublic static async getDesktopAsync(controller : AbortController, factory?: IFactory): Promise<IDesktop> {");
                l.Add("\t\tlet d = new " + className + "(factory)");
                l.Add("\t\tawait d.loadAsync(controller)");
                l.Add("\t\treturn d");
                l.Add("\t}");
                l.Add("");
                l.Add("\tconstructor(factory? : IFactory)");
                l.Add("\t{");
                l.Add("\t\tsuper(factory);");
                l.Add("");
                l.Add("\t\tthis.name = \"" + className + "\";");
                l.Add("");
                var lco = new List<ICategoryObject>();
                for (var i = 0; i < categoryObjects.Count; i++)
                {
                    var categoryObject = categoryObjects[i] as IAssociatedObject;
                    if (categoryObject is IChildren<ICategoryObject> ch)
                    {
                        foreach (var child in ch.Children)
                        {
                            lco.Add(child);
                        }
                    }
                    if (lco.Contains(categoryObject))
                    {
                        continue;
                    }
                    var nac = categoryObject.Object as INamedComponent;
                    string name = nac.RootName;
                    name = "\"" + name + "\"";
                    var cn = Loaded[categoryObject];
                    
                    var cnn = "\"" + cn + "\""; 
                    var pr = "\t\tthis.mapObjects.set(" + cnn + ", new " + cn + "(this, " + name + "))";
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
                if (!staticClass)
                {
                    l.Add("\tthis.finish()");
                }
                l.Add("}");
                l.Add("");

                l.Add("finish() : void");
                l.Add("{");

                l.Add("\t\tlet objects = this.getCategoryObjects();");
                l.Add("\t\tlet arrows = this.getCategoryArrows();");
                l.Add("");
                for (int i = 0; i < categoryArrows.Count; i++)
                {
                    var categoryArrow = categoryArrows[i];
                    var sn = "\"" + Loaded[categoryArrow.Source] + "\"";
                    var tn = "\"" + Loaded[categoryArrow.Target] + "\"";
                    var ss = "s" + i;
                    var tt = "t" + i;
                    l.Add("\t\tlet " + ss + " = this.mapObjects.get(" + sn + ")");
                    l.Add("\t\tif(" + ss + " != undefined)    arrows[" + i + "].setSource(" + ss + ");");
                    l.Add("\t\tlet " + tt + " = this.mapObjects.get(" + tn + ")");
                    l.Add("\t\tif(" + tt + " != undefined)    arrows[" + i + "].setTarget(" + tt + ");");
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
