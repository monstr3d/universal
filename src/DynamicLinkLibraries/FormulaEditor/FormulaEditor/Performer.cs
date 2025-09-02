using System.Collections.Generic;

namespace FormulaEditor
{
    public class Performer
    {
        public void GetList(ObjectFormulaTree tree, List<ObjectFormulaTree> l, List<ObjectFormulaTree> busy)
        {
            int n = tree.Count;
            for (int i = 0; i < n; i++)
            {
                GetList(tree[i], l, busy);
            }
            if (!busy.Contains(tree))
            {
                l.Add(tree);
            }
        }
    }
}
