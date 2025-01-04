using System.Collections;
using System.ComponentModel.Design;
using CategoryTheory;
using CategoryTheory.Math;
using Diagram.UI.Labels;
using MathGraph;

namespace Diagram.UI.Math
{
    public static class StaticExtensionDiagramUIMath
    {

        /// <summary>
        /// Composition of path arrows
        /// </summary>
        /// <param name="category">Category of arrows</param>
        /// <param name="path">The path</param>
        /// <returns>The composition</returns>
        static public IAdvancedCategoryArrow Composition(ICategory category, DigraphPath path)
        {
            IArrowLabel label = path[0].Object as IArrowLabel;
            IAdvancedCategoryArrow arrow = label.Arrow as IAdvancedCategoryArrow;
            for (int i = 1; i < path.Count; i++)
            {
                label = path[i].Object as IArrowLabel;
                arrow = (label.Arrow as IAdvancedCategoryArrow).Compose(category, arrow);
            }
            return arrow;
        }

        /// <summary>
        /// Restores arrow
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="label">Label of arrow to restore</param>
        /// <param name="objects">Objects of diagram</param>
        /// <param name="arrows">Arrows of diagram</param>
        /// <param name="res">Result of search</param>
        static public void RestoreArrow(ICategory category, IArrowLabel label,
            IList<IObjectLabel> objects, IList<IArrowLabel> arrows, out FindResults res)
        {
            object o = label.Source.Object;
            if (!(o is IDiagramRestoredObject))
            {
                throw new Exception("Arrow cannot be restored");
            }
            IDiagramRestoredObject source = o as IDiagramRestoredObject;
            IAdvancedCategoryObject sourceObject = source as IAdvancedCategoryObject;
            IAdvancedCategoryObject target = label.Target.Object as IAdvancedCategoryObject;
            Digraph graph = PureDesktop.CreateDigraph(objects, arrows);
            List<DigraphLoop> tempLoops = graph.Loops;
            List<DigraphLoop> restLoops = new List<DigraphLoop>();
            List<DigraphLoop> commLoops = new List<DigraphLoop>();
            foreach (DigraphLoop loop in tempLoops)
            {
                if (loop.ContainsObject(label))
                {
                    restLoops.Add(loop);
                    continue;
                }
                commLoops.Add(loop);
            }
            foreach (DigraphLoop loop in commLoops)
            {
                string s = NonCommutativeLoop(category, loop);
                if (s != null)
                {
                    throw new Exception(s);
                }
            }
            IAdvancedCategoryArrow[,] arr = new IAdvancedCategoryArrow[restLoops.Count, 3];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                DigraphLoop loop = restLoops[i] as DigraphLoop;
                int n = (loop[0].ContainsObject(label)) ? 0 : 1;
                DigraphPath arrowPath = loop[n];
                DigraphPath roundPath = loop[1 - n];
                IAdvancedCategoryArrow round = Composition(category, roundPath);
                arr[i, 0] = round;
                int j = 0;
                IAdvancedCategoryArrow to = null;
                IObjectLabel lo = arrowPath.Source.Object as IObjectLabel;
                if (lo.Object == sourceObject)
                {
                    to = (sourceObject as IAdvancedCategoryObject).Id;
                    j++;
                }
                else
                {
                    for (j = 0; j < arrowPath.Count; j++)
                    {
                        lo = arrowPath[j].Target.Object as IObjectLabel;
                        if (lo.Object == source)
                        {
                            break;
                        }
                    }
                    ++j;
                    IArrowLabel la = arrowPath[0].Object as IArrowLabel;
                    to = la.Arrow as IAdvancedCategoryArrow;
                    for (int k = 1; k < j; k++)
                    {
                        la = arrowPath[k].Object as IArrowLabel;
                        IAdvancedCategoryArrow ar = la.Arrow as IAdvancedCategoryArrow;
                        to = ar.Compose(category, to);
                    }
                    ++j;
                }
                arr[i, 1] = to;
                IAdvancedCategoryArrow from = null;
                if (j == arrowPath.Count)
                {
                    from = target.Id;
                }
                else
                {
                    IArrowLabel la = arrowPath[j].Object as IArrowLabel;
                    from = la.Arrow as IAdvancedCategoryArrow;
                    ++j;
                    for (; j < arrowPath.Count; j++)
                    {
                        la = arrowPath[j].Object as IArrowLabel;
                        from = (la.Arrow as IAdvancedCategoryArrow).Compose(category, from);
                    }
                }
                arr[i, 2] = from;
            }
            IAdvancedCategoryArrow result = source.RestoreArrow(target, arr, out res);
            if (result != null)
            {
                label.Arrow = result;
            }
        }

        /// <summary>
        /// String representation of non-commutative loop
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="objects">Objects</param>
        /// <param name="arrows">Arrows</param>
        /// <returns>String representation of non-commutative loop</returns>
        static public string NonCommutativeLoop(ICategory category, IList<IObjectLabel> objects, IList<IArrowLabel> arrows)
        {
            Digraph graph = PureDesktop.CreateDigraph(objects, arrows);
            List<DigraphLoop> loops = graph.Loops;
            foreach (DigraphLoop loop in loops)
            {
                string s = NonCommutativeLoop(category, loop);
                if (s != null)
                {
                    return s;
                }
            }
            return null;
        }



        /// <summary>
        /// Creates Natural transformations
        /// </summary>
        /// <param name="transformations">Interfaces</param>
        /// <param name="preffix">Preffix</param>
        /// <param name="suffix">Suffix</param>
        /// <param name="objects">Objects</param>
        /// <param name="arrows">Arrows</param>
        /// <param name="x">X - coordinate</param>
        /// <param name="y">Y - coordinate</param>
        public static void CreateNaturalTransformations(INaturalTransformation[] transformations,
            string preffix, string suffix,
            List<IObjectLabel> objects, List<IArrowLabel> arrows, int x, int y)
        {
        }

        /// <summary>
        /// Checks whether loop is commutative
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="loop">The loop to check</param>
        /// <returns>Non - commutative paths</returns>
        static public string NonCommutativeLoop(ICategory category, DigraphLoop loop)
        {
            ICategoryArrow[] arrows = new ICategoryArrow[2];
            for (int i = 0; i < 2; i++)
            {
                arrows[i] = Composition(category, loop[i]);
            }
            if (arrows[0].Equals(arrows[1]))
            {
                return null;
            }
            return "";// ToString(loop[0]) + " " + ResourceService.Resources.GetControlResource(IsNotEqual, ControlUtilites.Resources) + " " + ToString(loop[1]);
        }


        /// <summary>
        /// Creates functor image from objects and arrows
        /// </summary>
        /// <param name="functor">The functor</param>
        /// <param name="preffix">Preffix</param>
        /// <param name="suffix">Suffix</param>
        /// <param name="objects">Objects</param>
        /// <param name="arrows">Arrows</param>
        /// <param name="x">x - shift</param>
        /// <param name="y">x - shift</param>
        /// <param name="covariant"></param>
        /*    public void CreateFunctor(IFunctor functor, string preffix, string suffix,
                IList<IObjectLabel> objects, IList<IArrowLabel> arrows, int x, int y, bool covariant)
            {
                foreach (IArrowLabellabel in arrows)
                {
                    label.SourceNumber = objects.IndexOf(label.Source);
                    label.TargetNumber = objects.IndexOf(label.Target);
                }
                ArrayList imObjectLabels = new ArrayList();
                ICategoryObject[] imObjects = new ICategoryObject[objects.Count];
                int i = 0;
                foreach (IObjectLabelUI label in objects)
                {
                    IAdvancedCategoryObject ob = label.Object as IAdvancedCategoryObject;
                    IAdvancedCategoryObject im = functor.CalculateObject(ob);
                    IObjectLabelUI lab = tools.Factory.CreateObjectLabel(tools.Factory.GetObjectButton(im));
                    lab.X = label.X + x;
                    lab.Y = label.Y + y;
                    lab.ComponentName = preffix + label.Name + suffix;
                    lab.Object = im;
                    imObjectLabels.Add(lab);
                    AddNewObjectLabel(lab);
                    tools.AddObjectNode(lab);
                    imObjects[i] = im;
                    ++i;
                }
                foreach (IArrowLabelarr in arrows)
                {
                    IObjectLabelUI source = imObjectLabels[(int)arr.SourceNumber] as IObjectLabelUI;
                    IObjectLabelUI target = imObjectLabels[(int)arr.TargetNumber] as IObjectLabelUI;
                    IAdvancedCategoryObject imSource = imObjects[(int)arr.SourceNumber] as IAdvancedCategoryObject;
                    IAdvancedCategoryObject imTarget = imObjects[(int)arr.TargetNumber] as IAdvancedCategoryObject;
                    IAdvancedCategoryArrow imArrow = functor.CalculateArrow(imSource, imTarget, arr.Arrow as IAdvancedCategoryArrow);
                    IArrowLabelarrow = null;
                    IObjectLabelUI so = null;
                    IObjectLabelUI ta = null;
                    if (covariant)
                    {
                        so = source;
                        ta = target;
                    }
                    else
                    {
                        so = target;
                        ta = source;
                    }
                    arrow = tools.Factory.CreateArrowLabel(tools.Factory.GetArrowButton(imArrow), imArrow, so, ta);
                    arrow.ComponentName = preffix + arr.Name + suffix;
                    arrow.Source = so;
                    arrow.Target = ta;
                    AddNewArrowLabel(arrow);
                }
                foreach (IObjectLabelUI lab in objects)
                {
                    ICategoryObject obj = lab.Object;
                    PureDesktop.PostSetArrow(obj);
                }
            }*/

        /// <summary>
        /// Gets associated with edge arrow
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <returns>Associated arrow</returns>
        public static IAdvancedCategoryArrow GetEdgeArrow(DigraphEdge edge)
        {
            IArrowLabel l = edge.Object as IArrowLabel;
            return l.Arrow as IAdvancedCategoryArrow;
        }

        /// <summary>
        /// Creates composition from selection
        /// </summary>
        /// <param name="cat">Category</param>
        /// <param name="token">Token</param>
/*		public void CreateCompositionFromSelection(ICategory cat, string token)
        {
            IList<IObjectLabel> objs;
            IList<IArrowLabel> arrs;
            GetSelected(out objs, out arrs);
            ArrayList path = GetPath(arrs);
            IAdvancedCategoryArrow f = null;
            IObjectLabel source = null;
            IObjectLabel target = null;
            string name = "";
            foreach (IArrowLabellabel in path)
            {
                IAdvancedCategoryArrow g = label.Arrow as IAdvancedCategoryArrow;
                if (f == null)
                {
                    f = g;
                    name = label.Name;
                    source = label.Source;
                }
                else
                {
                    f = g.Compose(cat, f);
                    name = label.Name + token + name;
                }
                target = label.Target;
            }
            IArrowLabelarrow = tools.Factory.CreateArrowLabel(tools.Factory.GetArrowButton(f),
                f, source, target);
            arrow.ComponentName = name;
            AddArrowLabel(arrow);
            Redraw();
        }*/




    }
}
