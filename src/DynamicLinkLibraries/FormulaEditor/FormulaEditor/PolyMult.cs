using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    class PolyMult : IObjectOperation
    {
        //private static readonly Double a = 0;
        private List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();


        private PolyMult()
        {
        }


        #region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                Double a = 0;
                object[] o = new object[l.Count];
                for (int i = 0; i < o.Length; i++)
                {
                    o[i] = a;
                }
                return o;
            }
        }

        public object this[object[] x]
        {
            get
            {
                double a = 1;
                foreach (double c in x)
                {
                    double xx = (double)c;
                    a *= xx;
                }
                return a;
            }
        }

        public object ReturnType
        {
            get
            {
                return null;
            }
        }


        #endregion


        #region Specific Members

        static internal ObjectFormulaTree reduceTree(ObjectFormulaTree tree, bool simple)
        {
            bool b;
            simple = true;
            ObjectFormulaTree t = reduce(tree);
            ObjectFormulaTree st = simplify(t, out b);
            if (!b)
            {
                simple = false;
            }
            return st;
        }


        private void add(ObjectFormulaTree tree)
        {
            l.Add(tree);
        }


        private bool reduce()
        {
            List<ObjectFormulaTree> list = new List<ObjectFormulaTree>(l);
            bool b = true;
            foreach (ObjectFormulaTree t in l)
            {
                if (t.Operation is PolyMult)
                {
                    list.Remove(t);
                    PolyMult pm = t.Operation as PolyMult;
                    list.AddRange(pm.l);
                    b = false;
                    continue;
                }
                if (!(t.Operation is ElementaryBinaryOperation))
                {
                    continue;
                }
                ElementaryBinaryOperation op = t.Operation as ElementaryBinaryOperation;
                if (op.Symbol != '*')
                {
                    continue;
                }
                list.Remove(t);
                for (int i = 0; i < 2; i++)
                {
                    list.Add(t);
                    b = false;
                }
            }
            l = list;
            return b;
        }


        private void repeatReduce()
        {
            while (true)
            {
                if (reduce())
                {
                    break;
                }
            }
        }

        private static ObjectFormulaTree reduce(ObjectFormulaTree tree)
        {
            bool mult = false;
            if (tree.Operation is ElementaryBinaryOperation)
            {
                ElementaryBinaryOperation op = tree.Operation as ElementaryBinaryOperation;
                if (op.Symbol == '*')
                {
                    mult = true;
                }
            }
            if (mult)
            {
                PolyMult pm = new PolyMult();
                for (int i = 0; i < tree.Count; i++)
                {
                    pm.add(tree);
                }
                pm.repeatReduce();
                List<ObjectFormulaTree> list = new List<ObjectFormulaTree>(pm.l);
                pm.l.Clear();
                foreach (ObjectFormulaTree t in list)
                {
                    ObjectFormulaTree r = reduce(t);
                    list.Add(r);
                    pm.add(r);
                }
                return new ObjectFormulaTree(pm, list);
            }

            List<ObjectFormulaTree> listr = new List<ObjectFormulaTree>();
            for (int i = 0; i < tree.Count; i++)
            {
                listr.Add(reduce(tree[i]));
            }
            return new ObjectFormulaTree(tree.Operation, listr);

        }

        static internal ObjectFormulaTree simplify(ObjectFormulaTree tree, out bool simple)
        {
            //bool s = true;
            simple = true;
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            for (int i = 0; i < tree.Count; i++)
            {
                ObjectFormulaTree t = simplifyRecursive(tree[i]);
                l.Add(t);
            }
            if (!(tree.Operation is PolyMult))
            {
                return new ObjectFormulaTree(tree.Operation, l);
            }
            List<ObjectFormulaTree> consts = new List<ObjectFormulaTree>();
            List<ObjectFormulaTree> forms = new List<ObjectFormulaTree>();
            for (int i = 0; i < tree.Count; i++)
            {
                if (ElementaryFormulaSimplification.IsConst(tree[i]))
                {
                    consts.Add(tree[i]);
                    continue;
                }
                forms.Add(tree[i]);
            }
            double a = 1;
            foreach (ObjectFormulaTree t in consts)
            {
                double x = (double)t.Result;
                a *= x;
            }
            if (a == 0)
            {
                ElementaryRealConstant x = new ElementaryRealConstant(0);
                simple = true;
                return new ObjectFormulaTree(x, new List<ObjectFormulaTree>());
            }
            if (a == 1)
            {
                PolyMult pm = new PolyMult();
                foreach (ObjectFormulaTree t in forms)
                {
                    pm.add(t);
                }
                if (consts.Count > 0)
                {
                    simple = false;
                }
                return new ObjectFormulaTree(pm, forms);
            }
            if (consts.Count <= 1)
            {
                PolyMult pm = new PolyMult();
                pm.l = l;
                return new ObjectFormulaTree(tree.Operation, l);
            }
            simple = false;
            ElementaryRealConstant xx = new ElementaryRealConstant(a);
            ObjectFormulaTree yy = new ObjectFormulaTree(xx, new List<ObjectFormulaTree>());
            List<ObjectFormulaTree> ll = new List<ObjectFormulaTree>();
            ll.Add(yy);
            ll.AddRange(forms);
            PolyMult pmm = new PolyMult();
            pmm.l = new List<ObjectFormulaTree>(ll);
            return new ObjectFormulaTree(pmm, ll);
        }

        static private ObjectFormulaTree simplifyRecursive(ObjectFormulaTree tree)
        {
            ObjectFormulaTree t = tree;
            while (true)
            {
                bool b;
                t = simplify(t, out b);
               // t = PolyMult.Simplify(t, ref b);
                if (b)
                {
                    break;
                }
            }
            return t;
        }


        internal static ObjectFormulaTree MultMult(ObjectFormulaTree tree)
        {
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            for (int i = 0; i < tree.Count; i++)
            {
                ObjectFormulaTree tr = tree[i];
               // tr = ElementaryFormulaSimplification.Object.Simplify(tr);
                l.Add(MultMult(tr));
            }
            IObjectOperation op = tree.Operation;
            if (op is ElementaryBinaryOperation)
            {
                ElementaryBinaryOperation bo = op as ElementaryBinaryOperation;
                if (bo.Symbol == '*')
                {
                    List<ObjectFormulaTree> ll = new List<ObjectFormulaTree>();
                    PolyMult pm = new PolyMult();
                    foreach (ObjectFormulaTree t in l)
                    {
                        if (!(t.Operation is PolyMult))
                        {
                            pm.add(t);
                            ll.Add(t);
                            continue;
                        }
                        for (int i = 0; i < t.Count; i++)
                        {
                            pm.add(t[i]);
                            ll.Add(t[i]);
                        }
                    }
                    return new ObjectFormulaTree(pm, ll);
                }
            }
            return new ObjectFormulaTree(op, l);
        }

        static internal bool IsZero(ObjectFormulaTree tree)
        {
            IObjectOperation op = tree.Operation;
            if (op is ElementaryRealConstant)
            {
                ElementaryRealConstant ec = op as ElementaryRealConstant;
                double a = ec.Value;
                return a == 0;
            }
            if (!(op is PolyMult))
            {
                return false;
            }
            PolyMult pm = op as PolyMult;
            for (int i = 0; i < tree.Count; i++)
            {
                if (IsZero(tree[i]))
                {
                    return true;
                }
            }
            return false;
        }

        internal static ObjectFormulaTree MultMultReverse(ObjectFormulaTree tree)
        {
            Double a = 0;
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            IObjectOperation op = tree.Operation;
            PolyMult pm = null;
            if (op is PolyMult)
            {
                pm = op as PolyMult;
            }
            for (int i = 0; i < tree.Count; i++)
            {
                l.Add(MultMultReverse(tree[i]));
            }
            if (pm == null)
            {
                return new ObjectFormulaTree(op, l); 
            }
            if (l.Count == 1)
            {
                return l[0];
            }
            PolyMult p = new PolyMult();
            if (l.Count == 0)
            {
                ElementaryRealConstant rc = new ElementaryRealConstant(0);
                return new ObjectFormulaTree(rc, new List<ObjectFormulaTree>());
            }
            ObjectFormulaTree left = l[0];
            l.RemoveAt(0);
            p.l = l;
            ObjectFormulaTree right = MultMultReverse(new ObjectFormulaTree(p, l));
            List<ObjectFormulaTree> lll = new List<ObjectFormulaTree>();
            lll.Add(left);
            lll.Add(right);
            ElementaryBinaryOperation bo = new ElementaryBinaryOperation('*', new object[]{a, a});
            return new ObjectFormulaTree(bo, lll);
        }
        #endregion
    }
}
