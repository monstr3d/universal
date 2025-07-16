using CategoryTheory;

using Diagram.Attributes;
using Diagram.UI;
using Diagram.UI.Interfaces;

namespace Diagram.TypeScript
{
    [Language("TS", ".ts")]
    internal class DesktopCodeCreator : IDesktopCodeCreator
    {
        Diagram.UI.Performer performer = new Diagram.UI.Performer();

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
            return l;
        }
    }
}
