using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;


namespace FormulaEditor
{
    class PolySum : IObjectOperation
    {
        Dictionary<ObjectFormulaTree, bool> summands = new Dictionary<ObjectFormulaTree, bool>();
        bool positive;
        internal PolySum(bool positive)
        {
            this.positive = positive;
        }


        #region IObjectOperation Members

        object[] IObjectOperation.InputTypes
        {
            get { return new object[summands.Count]; }
        }

        object IObjectOperation.this[object[] x]
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        object IObjectOperation.ReturnType
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

        private static ObjectFormulaTree sumSum(ObjectFormulaTree tree)
        {
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            for (int i = 0; i < tree.Count; i++)
            {
                ObjectFormulaTree t = tree[i];
               // t = ElementaryFormulaSimplification.Object.Simplify(t);
                l.Add(sumSum(t));
            }
            IObjectOperation op = tree.Operation;
            if (op is ElementaryBinaryOperation)
            {
                ElementaryBinaryOperation bo = op as ElementaryBinaryOperation;
                char c = bo.Symbol;
                PolySum ps = new PolySum(true);
                if (c == '+' | c == '-')
                {
                    bool b = c == '+';
                    PolySum p = new PolySum(true);
                    Dictionary<ObjectFormulaTree, bool> dic = p.summands;
                    for (int i = 0; i < l.Count; i++)
                    {
                        ObjectFormulaTree t = l[i];
                        if (PolyMult.IsZero(t))
                        {
                            continue;
                        }
                        bool kb = true;
                        if (i > 0)
                        {
                            kb = b;
                        }
                        IObjectOperation oo = t.Operation;
                        if (oo is PolySum)
                        {
                            PolySum pss = oo as PolySum;
                            Dictionary<ObjectFormulaTree, bool> d = pss.summands;
                            foreach (ObjectFormulaTree tr in d.Keys)
                            {
                                bool rb = d[tr];
                                if (!kb)
                                {
                                    rb = !rb;
                                }
                                dic[tr] = rb;
                            }
                            continue;
                        }
                        dic[t] = kb;
                    }
                    return new ObjectFormulaTree(p, new List<ObjectFormulaTree>());
                }
            }
            return new ObjectFormulaTree(op, l);
        }

        private static ObjectFormulaTree delConst(ObjectFormulaTree tree, ref bool simple)
        {
            IObjectOperation op = tree.Operation;
            if (op is PolySum)
            {
                PolySum ps = op as PolySum;
                return delConst(ps, ref simple);
            }
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            for (int i = 0; i < tree.Count; i++)
            {
                l.Add(delConst(tree[i], ref simple));
            }
            if ((op is ElementaryBrackets) | (op is ElementaryRoot) | (op is ElementaryPowerOperation))
            {
                if (l.Count == 2)
                {
                    ObjectFormulaTree t = l[1];
                    if (ElementaryFormulaSimplification.IsConst(t))
                    {
                        double a = (double) t.Result;
                        if (a == 1)
                        {
                            simple = false;
                            return l[0];
                        }
                    }
                }
            }
            return new ObjectFormulaTree(op, l);
        }


        private static ObjectFormulaTree delConst(PolySum ps, ref bool simple)
        {
            Dictionary<ObjectFormulaTree, bool> dd = ps.summands;
            List<ObjectFormulaTree> del = new List<ObjectFormulaTree>();
            Dictionary<ObjectFormulaTree, bool> d = new Dictionary<ObjectFormulaTree,bool>();
            foreach (ObjectFormulaTree ttt in dd.Keys)
            {
                ObjectFormulaTree ts = ElementaryFormulaSimplification.Object.Simplify(ttt);
                if (!PolyMult.IsZero(ts))
                {
                    d[ts] = dd[ttt];
                }
            }
            PolySum p = new PolySum(true);
            Dictionary<ObjectFormulaTree, bool> forms = p.summands;
            double a = 0;
            int i = 0;
            foreach (ObjectFormulaTree t in d.Keys)
            {
                bool b = d[t];
                ObjectFormulaTree tr = delConst(t, ref simple);
                if (PolyMult.IsZero(tr))
                {
                    simple = false;
                    continue;
                }
                if (ElementaryFormulaSimplification.IsConst(tr))
                {
                    double x = (double)tr.Result;
                    a += b ? x : -x;
                    ++i;
                    if (i > 1)
                    {
                        simple = false;
                    }
                }
                else
                {
                    forms[tr] = d[t];
                }
            }
            if (a != 0)
            {
                ElementaryRealConstant ec = new ElementaryRealConstant(a);
                forms[new ObjectFormulaTree(ec, new List<ObjectFormulaTree>())] = true;
            }
            if (forms.Count == 1)
            {
                foreach (ObjectFormulaTree f in forms.Keys)
                {
                    bool b = forms[f];
                    if (b)
                    {
                        return f;
                    }
                    ElementaryFunctionOperation op = new ElementaryFunctionOperation('-');
                    List<ObjectFormulaTree> lop = new List<ObjectFormulaTree>();
                    lop.Add(f);
                    return new ObjectFormulaTree(op, lop);
                }
            }
            return new ObjectFormulaTree(p, new List<ObjectFormulaTree>());
        }

        private static ObjectFormulaTree sumSumInverse(PolySum ps)
        {
            Dictionary<ObjectFormulaTree, bool> d = new Dictionary<ObjectFormulaTree, bool>(ps.summands);
            ObjectFormulaTree first = null;
            ObjectFormulaTree second = null;
            bool bf = true;
            foreach (ObjectFormulaTree t in d.Keys)
            {
                if (ElementaryFormulaSimplification.IsConst(t))
                {
                    first = t;
                }
            }
            if (first == null)
            {
                if (d.Count > 0)
                {
                    foreach (ObjectFormulaTree t in d.Keys)
                    {
                        first = t;
                        bf = d[t];
                        break;
                    }
                }
            }
            if (first == null)
            {
                ElementaryRealConstant er = new ElementaryRealConstant(0);
                return new ObjectFormulaTree(er, new List<ObjectFormulaTree>());
            }
            d.Remove(first);
            first = sumSumInverse(first);
            if (!bf)
            {
                ElementaryFunctionOperation ef = new ElementaryFunctionOperation('-');
                List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
                l.Add(first);
                first = new ObjectFormulaTree(ef, l);
            }
            if (d.Count == 0)
            {
                return first;
            }
            ObjectFormulaTree sec = null;
            foreach (ObjectFormulaTree t in d.Keys)
            {
                sec = t;
            }
            bool kb = d[sec];
            PolySum pp = new PolySum(true);
            Dictionary<ObjectFormulaTree, bool> dd = pp.summands;
            foreach (ObjectFormulaTree t in d.Keys)
            {
                if (PolyMult.IsZero(t))
                {
                    continue;
                }
                bool bl = d[t];
                if (!kb)
                {
                    bl = !bl;
                }
                dd[t] = bl;
            }
            second = sumSumInverse(pp);
            List<ObjectFormulaTree> lr = new List<ObjectFormulaTree>();
            lr.Add(first);
            lr.Add(second);
            char c = kb ? '+' : '-';
            if (PolyMult.IsZero(second))
            {
                return first;
            }
            Double type = 0;
            ElementaryBinaryOperation eop = new ElementaryBinaryOperation(c, new object[] {type, type});
            return new ObjectFormulaTree(eop, lr);
        }

        private static ObjectFormulaTree sumSumInverse(ObjectFormulaTree tree)
        {
            ObjectFormulaTree tre = tree;
            IObjectOperation op = tree.Operation;
            if (op is PolySum)
            {
                PolySum ps = op as PolySum;
                tre = sumSumInverse(ps);
                op = tre.Operation;
            }
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            for (int i = 0; i < tre.Count; i++)
            {
                l.Add(sumSumInverse(tre[i]));
            }
            if (op is ElementaryBinaryOperation)
            {
                ElementaryBinaryOperation bo = op as ElementaryBinaryOperation;
                char c = bo.Symbol;
                if (c == '+' | c == '-')
                {
                    if (PolyMult.IsZero(l[1]))
                    {
                        return l[0];
                    }
                    if (PolyMult.IsZero(l[0]))
                    {
                        return signed(l[1], c);
                    }
                }
            }
            return new ObjectFormulaTree(op, l);
        }


        internal static ObjectFormulaTree signed(ObjectFormulaTree tree, bool sign)
        {
            if (sign)
            {
                return tree;
            }
            ElementaryFunctionOperation eo = new ElementaryFunctionOperation('-');
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            l.Add(tree);
            return new ObjectFormulaTree(eo, l);
        }
        
        internal static ObjectFormulaTree signed(ObjectFormulaTree tree, char sign)
        {
            return signed(tree, sign == '+');
        }

        internal static ObjectFormulaTree Simplify(ObjectFormulaTree tree, ref bool simple)
        {
            ObjectFormulaTree t = sumSum(tree);
            t = delConst(t, ref simple);
            return sumSumInverse(t);
        }
    }
}
