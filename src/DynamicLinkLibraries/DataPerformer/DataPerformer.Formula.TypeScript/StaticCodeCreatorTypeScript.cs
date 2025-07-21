using DataPerformer.Interfaces;
using ErrorHandler;
using FormulaEditor;
using FormulaEditor.Interfaces;

namespace DataPerformer.Formula.TypeScript
{
    internal static  class StaticCodeCreatorTypeScript
    {

        #region Public Members

        internal static Dictionary<string, Tuple<int, object>> Output
        {
            get;
            set;
        }

      


        /// <summary>
        /// Gets number of tree
        /// </summary>
        /// <param name="creator">Creator of code</param>
        /// <param name="tree">The tree</param>
        /// <returns>Number of tree</returns>
        public static int GetNumber(ICodeCreator creator, ObjectFormulaTree tree)
        {
            try
            {
                return creator.GetNumber(tree);
                /*  ObjectFormulaTree[] trees = creator.Trees;
                  for (int i = 0; i < trees.Length; i++)
                  {
                      if (trees[i] == tree)
                      {
                          return i;
                      }
                  }*/
            }
            catch (Exception)
            {
                throw new Exception("Tree not found");
            }
        }

        /// <summary>
        /// Creates code from trees
        /// </summary>
        /// <param name="trees">The trees</param>
        /// <param name="creator">Code creator</param>
        /// <param name="local">Local code reator</param>
        /// <param name="variables">Strings of variables</param>
        /// <param name="initializers">Strings of initializers</param>
        /// <returns>Strings of code</returns>
        public static IList<string> CreateCode(object obj, ObjectFormulaTree[] trees, ICodeCreator creator,
            out ICodeCreator local,
             out IList<string> variables,
             out IList<string> initializers)
        {
            List<string> code = new List<string>();
            List<string> vari = new List<string>();
            List<string> init = new List<string>();
            try
            {
                local = creator.Create(obj, trees);
                IList<ObjectFormulaTree> lt = local.Trees;
                Output = DataPerformerFormula.GetOutput(obj as IMeasurements, lt.ToArray());
                foreach (var item in Output)
                {
                    var mname = "\"" + item.Key + "\"";
                    var mt = item.Value.Item2 + "";
                    var mf = "this.get_" + item.Value.Item1; 
                    init.Add("this.addMeasurement(new Measurement(" + mname + ", " + mt + ", " + mf + "));");
                }
                var ct = DataPerformerFormula.Get(obj as IDataConsumer, lt.ToArray());
                foreach (var ii in ct)
                {
                    var mtt = "measurement" + ii[0];
                    vari.Add(mtt + " !: " + "IMeasurement;");
                    init.Add("this." + mtt + " = this.dataConsumer.getAllMeasurements()[" + ii[1] +
                        "].geMeasurement(" + ii[2] + ");");
                }
                if (local.Optional.Count > 0)
                {
                    return CreateOptionalCode(obj, local, out variables, out initializers);
                }
                foreach (ObjectFormulaTree t in lt)
                {
                    string ret = local[t];
                    IList<string> par = new List<string>();
                    int n = t.Count;
                    for (int i = 0; i < n; i++)
                    {
                        ObjectFormulaTree child = t[i];
                        if (child == null)
                        {
                            continue;
                        }
                        par.Add(local[child]);
                    }
                    IList<string> lv;
                    IList<string> lp;
                    IList<string> c = local.CreateCode(obj, t, ret, par.ToArray<string>(),
                        out lv, out lp);
                    if (lv != null)
                    {
                        vari.AddRange(lv);
                    }
                    if (lp != null)
                    {
                        init.AddRange(lp);
                    }
                    if (creator.GetConstValue(t) == null)
                    {
                        code.AddRange(c);
                    }
                    else if (creator.GetConstValue(t).Equals("\"\""))
                    {
                        code.AddRange(c);
                    }
                }
                variables = vari;
                initializers = init;
                return code;
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            local = null;
            variables = null;
            initializers = null;
            return null;
        }

        #endregion

        #region Private Members

        static IList<string> CreateOptionalCode(object obj, ICodeCreator creator, out IList<string> variables, out IList<string> initializers)
        {
            List<string> code = new List<string>();
            List<string> vari = new List<string>();
            List<string> init = new List<string>();
            IList<ObjectFormulaTree> lt = creator.Trees;
            IList<ObjectFormulaTree> opt = creator.Optional;
            List<ObjectFormulaTree> busy = new List<ObjectFormulaTree>();
            List<ObjectFormulaTree> conds = new List<ObjectFormulaTree>();
            Dictionary<ObjectFormulaTree, ObjectFormulaTree> pch = new Dictionary<ObjectFormulaTree, ObjectFormulaTree>();
            foreach (ObjectFormulaTree t in opt)
            {
                for (int i = 0; i < t.Count; i++)
                {
                    pch[t[i]] = t;
                }
            }
            foreach (ObjectFormulaTree t in lt)
            {
                IList<string> par = new List<string>();
                if (busy.Contains(t))
                {
                    continue;
                }
                string ret = creator[t];
                if (pch.ContainsKey(t))
                {
                    ObjectFormulaTree oft = pch[t];
                    string rcr = creator[oft];
                    busy.Add(oft);
                    ObjectFormulaTree cond = oft[0];
                    for (int i = 0; i < cond.Count; i++)
                    {
                        ObjectFormulaTree chc = cond[i];
                        if (chc == null)
                        {
                            continue;
                        }
                        busy.Add(chc);
                        par.Add(creator[chc]);
                    }
                    IList<string> lvc;
                    IList<string> lpc;
                    string rc = creator[cond];
                    if (!conds.Contains(cond))
                    {
                        conds.Add(cond);
                        IList<string> cc = creator.CreateCode(obj, cond, rc, par.ToArray(),
                            out lvc, out lpc);
                        if (lvc != null)
                        {
                            vari.AddRange(lvc);
                        }
                        if (lpc != null)
                        {
                            init.AddRange(lpc);
                        }
                        if (creator.GetConstValue(cond) == null)
                        {
                            code.AddRange(cc);
                        }
                    }
                    code.Add("if (" + rc + ")");
                    code.Add("{");
                    for (int k = 1; k < 3; k++)
                    {
                        ObjectFormulaTree tt = oft[k];
                        if (k == 0)
                        {
                            IList<string> lvr;
                            IList<string> lpr;
                            string rr = creator[tt];
                            List<string> p = new List<string>();
                            if (k > 0)
                            {
                                for (int i = 0; i < tt.Count; i++)
                                {
                                    ObjectFormulaTree chc = tt[i];
                                    if (chc == null)
                                    {
                                        continue;
                                    }
                                    busy.Add(chc);
                                    p.Add(creator[chc]);
                                }
                            }
                            IList<string> cr = creator.CreateCode(obj, tt, rr, p.ToArray<string>(),
                              out lvr, out lpr);
                            if (lvr != null)
                            {
                                vari.AddRange(lvr);
                            }
                            if (lpr != null)
                            {
                                init.AddRange(lpr);
                            }
                            if (creator.GetConstValue(t) == null)
                            {
                                code.AddRange(cr);
                            }
                        }
                        else
                        {
                            code.AddRange(CreateCode(obj, creator, tt, busy));
                            code.Add(rcr + " = " + creator[tt] + ";");
                        }
                        if (k == 1)
                        {
                            code.Add("}");
                            code.Add("else");
                            code.Add("{");
                        }
                    }
                    code.Add("}");
                    continue;
                }
                busy.Add(t);
                int n = t.Count;
                for (int i = 0; i < n; i++)
                {
                    ObjectFormulaTree child = t[i];
                    busy.Add(child);
                    if (child == null)
                    {
                        continue;
                    }
                    par.Add(creator[child]);
                }
                IList<string> lv;
                IList<string> lp;
                IList<string> c = creator.CreateCode(obj, t, ret, par.ToArray<string>(),
                    out lv, out lp);
                if (lv != null)
                {
                    vari.AddRange(lv);
                }
                if (lp != null)
                {
                    init.AddRange(lp);
                }
                if (creator.GetConstValue(t) == null)
                {
                    code.AddRange(c);
                }
            }
            List<string> lvar = new List<string>();
            foreach (string s in vari)
            {
                if (!lvar.Contains(s))
                {
                    lvar.Add(s);
                }
            }
            variables = lvar;
            List<string> lini = new List<string>();
            foreach (string s in init)
            {
                if (!lini.Contains(s))
                {
                    lini.Add(s);
                }
            }
            initializers = lini;
            return code;
        }

        private static void GetList(ObjectFormulaTree tree, List<ObjectFormulaTree> l, List<ObjectFormulaTree> busy)
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

        private static IList<string> CreateCode(object obj, ICodeCreator creator, ObjectFormulaTree tree, List<ObjectFormulaTree> busy)
        {
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            GetList(tree, l, busy);
            IList<string> lvr;
            IList<string> lpr;
            List<string> cc = new List<string>();
            for (int i = 0; i < l.Count; i++)
            {
                ObjectFormulaTree tr = l[i];
                List<string> p = new List<string>();
                string rr = creator[tr];
                for (int j = 0; j < tr.Count; j++)
                {
                    ObjectFormulaTree chc = tr[j];
                    if (chc == null)
                    {
                        continue;
                    }
                    p.Add(creator[chc]);
                }
                cc.AddRange(creator.CreateCode(obj, tr, rr, p.ToArray(), out lvr, out lpr));
            }
            return cc;
        }

        #endregion


    }
}
