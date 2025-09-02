using System;
using System.Collections.Generic;
using System.Linq;
using ErrorHandler;
using FormulaEditor.CodeCreators.Interfaces;

namespace FormulaEditor.CodeCreators
{
    /// <summary>
    /// Static class for creation of code
    /// </summary>
    public static class StaticCodeCreator
    {

        #region Public Members

        /// <summary>
        /// Gets number of tree
        /// </summary>
        /// <param name="creator">Creator of code</param>
        /// <param name="tree">The tree</param>
        /// <returns>Number of tree</returns>
        public static int GetNumber(ITreeCodeCreator creator, ObjectFormulaTree tree)
        {
            Exception exteption;
            try
            {
                return creator.GetNumber(tree);
            }
            catch (Exception e)
            {
                object o = new object[] { creator, tree };
                exteption =  IncludedException.Get(e, o, "Tree not found");
            }
            throw exteption;
        }

        /// <summary>
        /// Creates code from trees
        /// </summary>
        /// <param name="trees">The trees</param>
        /// <param name="creator">Code creator</param>
        /// <param name="local">Local code creator</param>
        /// <param name="variables">Strings of variables</param>
        /// <param name="initializers">Strings of initializers</param>
        /// <returns>Strings of code</returns>
        public static Dictionary<string, List<string>> CreateCode(object obj, 
            ObjectFormulaTree[] trees, ITreeCodeCreator creator,
            out ITreeCodeCreator local)
        {
            List<string> code = new List<string>();
            List<string> vari = new List<string>();
            List<string> init = new List<string>();
            Dictionary<string, List<string>> c;
            try
            {
                local = creator.Create(obj, trees);
                List<ObjectFormulaTree> lt = local.Trees.ToList();
                if (local.Optional.Count > 0)
                {
                    return CreateOptionalCode(obj, local);
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
                    c = local.CreateCode(obj, t, ret, par.ToArray());
                    if (c.ContainsKey("variables"))
                    {
                        vari.AddRange(c["variables"]);
                    }
                    if (c.ContainsKey("initializers"))
                    {
                        init.AddRange(c["initializers"]);
                    }
                    if (creator.GetConstValue(t) == null)
                    {
                        code.AddRange(c["code"]);
                    }
                    else if (creator.GetConstValue(t).Equals("\"\""))
                    {
                        code.AddRange(c["code"]);
                    }
                }
                var d = new Dictionary<string, List<string>>()
                {
                    { "initializers", init },
                    { "variables", vari },
                    { "code", code }
                };
                 return d;
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            local = null;
            return null;
        }

        #endregion

        #region Private Members

        static Dictionary<string, List<string>> CreateOptionalCode(object obj, ITreeCodeCreator creator)
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
                    string rc = creator[cond];
                    if (!conds.Contains(cond))
                    {
                        conds.Add(cond);
                        var cc = creator.CreateCode(obj, cond, rc, par.ToArray());
                             vari.AddRange(cc["variables"]);
                            init.AddRange(cc["initializers"]);
                        if (creator.GetConstValue(cond) == null)
                        {
                        code.AddRange(cc["code"]);
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
                            var cr = creator.CreateCode(obj, tt, rr, p.ToArray<string>());
                            vari.AddRange(cr["variablves"]);
                            init.AddRange(cr["initializers"]);
                            if (creator.GetConstValue(t) == null)
                            {
                                code.AddRange(cr["code"]);
                            }
                        }
                        else
                        {
                            code.AddRange(CreateCode(obj, creator, tt, busy)["code"]);
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
                var c = creator.CreateCode(obj, t, ret, par.ToArray<string>());
                vari.AddRange(c["variables"]);
                init.AddRange(c["ititializers"]);
                if (creator.GetConstValue(t) == null)
                {
                    code.AddRange(c["code"]);
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
            List<string> lini = new List<string>();
            foreach (string s in init)
            {
                if (!lini.Contains(s))
                {
                    lini.Add(s);
                }
            }
            var d = new Dictionary<string, List<string>>()
         {
             { "initializers", init },
             { "variables", vari },
             { "code", code }
         };
          return d;
        }

        static FormulaEditor.Performer formulaPerformer = new Performer();


        private static Dictionary<string, List<string>> CreateCode(object obj, ITreeCodeCreator creator, 
            ObjectFormulaTree tree, List<ObjectFormulaTree> busy)
        {
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            var d = new Dictionary<string, List<string>>();
            formulaPerformer.GetList(tree, l, busy);
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
                var ct = creator.CreateCode(obj, tr, rr, p.ToArray());
                foreach (var c in ct)
                {
                    List<string> list = null;
                    var k = c.Key;
                    if (d.ContainsKey(k))
                    {
                        list = d[k];
                    }
                    else
                    {
                        list = new List<string>();
                        d[k] = list;
                    }
                    list.AddRange(c.Value);
                }

            }
            return d;
        }

        #endregion

    }
}