using BaseTypes;
using BaseTypes.Attributes;
using BaseTypes.CodeCreator.Interfaces;
using DataPerformer.Interfaces;
using DataPerformer.Interfaces.Attributes;
using Diagram.Interfaces;
using Diagram.UI.Attributes;
using Diagram.UI.Interfaces;
using ErrorHandler;
using FormulaEditor;
using FormulaEditor.CodeCreators;
using FormulaEditor.CodeCreators.Interfaces;
using FormulaEditor.Interfaces;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DataPerformer.Formula.Java
{
    [Language("Java")]
    internal class TreeCollectionCodeCreator : ITreeCollectionCodeCreator
    {
        Performer performer = new Performer();

        object current;

        ObjectFormulaTree[] trees;

        ITypeCreator typeCreator;

        IClassCodeCreator classCodeCreator;


        protected ITreeCollection collection = null;


        ITreeCodeCreator local = null;

        ITreeCodeCreator codeCreator;



        internal TreeCollectionCodeCreator()
        {
            this.AddTreeCollectionCodeCreator();
            codeCreator = performer.GetLaguageObject<ITreeCodeCreator>(this);
            classCodeCreator = performer.GetLaguageObject<IClassCodeCreator>(this);
            typeCreator = performer.GetLaguageObject<ITypeCreator>(this);

        }

        List<string> PostCreateCode(ITreeCodeCreator local, object ob, IList<string> lcode,
           IList<string> variables, IList<string> initializers, string consturctor, bool checkValue = true)
        {
            List<string> l = new();
            performer.Add(l, lcode as List<string>, 1);
            int nTree = local.Trees.Length;
            l.Add("");
            if (checkValue)
            {
            }
            else
            {
                l.Add(consturctor + "(FormulaEditor.ObjectFormulaTree[] trees)");
                l.Add("{");
                l.Add("\tthis.trees = trees;");
            }
            l.Add("@Override");
            l.Add("protected void init()");
            l.Add("{");
            if (ob is IMeasurements)
            {
                l.Add("\tvar all = this.getAllMeasurements();");
            }
            performer.Add(l, initializers as List<string>, 1);
            l.Add("}");
            l.Add("");
            foreach (string s in variables)
            {
                l.Add("" + s);
            }
            if (checkValue)
            {
            }
            return l;
        }

        private List<string> PreCreateCode(object obj, out ITreeCodeCreator local,
     out IList<string> variables, out IList<string> initializers, string current)
        {
            if (codeCreator == null)
            {
                codeCreator = performer.GetLaguageObject<ITreeCodeCreator>(this);
            }
            var lcode = JaveCreateCode(obj, trees, codeCreator,
                out local, out variables, out initializers, current);
            ObjectFormulaTree[] tr = local.Trees;
            foreach (ObjectFormulaTree tree in tr)
            {
                AddTree(tree, initializers, variables);
            }
            var l = new List<string>();
            l.Add("@Override");
            l.Add("protected void calculateTree()");
            l.Add("{");
            l.Add("\tsuccess = true;");
            performer.Add(l, lcode as List<string>, 1);
            l.Add("}");
            return l;
        }

        void AddTree(ObjectFormulaTree tree, IList<string> init, IList<string> func)
        {
            int n = StaticCodeCreator.GetNumber(local, tree);
            string tid = local[tree];
            string f = "get_" + n;
            // init.Add("this.mapOperations.set(" + n + ", this." + f + ");");
            func.Add("");
            func.Add("Object " + f + "()");
            func.Add("{");
            func.Add("\treturn success ? this." + tid + " : null;");
            func.Add("}");
        }


        Dictionary<string, List<string>> ITreeCollectionCodeCreator.CreateCode(object obj, ObjectFormulaTree[] trees, string className, string constructorModifier, bool checkValue)
        {
            this.trees = trees;
            IList<string> variables;
            IList<string> initializers;
            List<string> l = new List<string>();
            //          l.Add(" : FormulaEditor.Interfaces.ITreeCollectionProxy");
            //        local = null;
            var lt = PreCreateCode(obj, out local, out variables, out initializers, className);
            List<string> ltt = PostCreateCode(local, obj, lt, variables, initializers,
                         constructorModifier + " " + className,
                         checkValue);
            var ltr = local.Trees;
            performer.Add(l, ltt, 0);
            var output = new Dictionary<string, Tuple<int, object>>();
            if (obj is IStringTreeDictionary dictionary)
            {
                output = DataPerformerFormula.GetOutput(dictionary, ltr);
            }
            else if (obj is IMeasurements mm)
            {
                output = DataPerformerFormula.GetOutput(mm, ltr);
            }
            var attr = performer.GetAttribute<CodeCreatorAttribute>(obj);
            var ll = new List<string>();
            l.Add("@Override");
            ll.Add("protected void save(){");
            var s = "\tvar v = variables;";
            if (attr != null)
            {
                if (attr.IsSysemOfDifferentialEquations)
                {
                    s = "\tvar v = derivations;";
                }
            }
            ll.Add(s);
            var mea = obj as IMeasurements;
            var kk = 0;
            foreach (var k in output)
            {
                var st = "x" + kk;
                ++kk;
                ll.Add("\tvar " + st + " = v.get(" + "\"" + k.Key + "\");");
                ll.Add("\t" + st + ".setIValue(this.get_" + k.Value.Item1 + "());");
            }
            ll.Add("}");
            l.AddRange(ll);
            l.Add("");
            var d = new Dictionary<string, List<string>>();
            d["code"] = l;
            return d;
        }

        bool GetState(object obj)
        {
            bool b = false;
            var attr = performer.GetAttribute<CodeCreatorAttribute>(obj);
            if (attr != null)
            {
                b = attr.InitialState;
            }
            return b;
        }

        public  IList<string> StaticJavaCreateCode(object obj, ObjectFormulaTree[] trees, ITreeCodeCreator creator,
    out ITreeCodeCreator local,
     out IList<string> variables,
     out IList<string> initializers, string current)
        {
            List<string> code = new List<string>();
            List<string> vari = new List<string>();
            List<string> init = new List<string>();
            var measurements = obj as IMeasurements;
            try
            {
                var values = new List<int>();
                local = creator.Create(obj, trees);
                IList<ObjectFormulaTree> lt = local.Trees;
                var ct = DataPerformerFormula.Get(obj as IDataConsumer, lt.ToArray());
                bool state = GetState(obj);
                for (int i = 0; i < lt.Count; i++)
                {
                    var tree = lt[i];
                    var op = tree.Operation;
                    foreach (var ii in ct)
                    {
                        if (ii[0] == i)
                        {
                            var att = performer.GetAttribute<InternalVariableAttribute>(op);
                            if (att == null)
                            {
                                var mtt = "measurement" + ii[0];
                                var mmt = "measurements.interfaces.IMeasurement ";
                                vari.Add(mmt + mtt + ";");
                                init.Add(mtt + " = all[" + ii[1] +
                                    "].getMeasurement(" + ii[2] + ");");
                            }
                            else
                            {
                                if (att.IsDerivation)
                                {
                                    var vtt = "value" + ii[0];
                                    vari.Add("general_service.interfaces.IValue " + vtt + ";");
                                }
                            }
                            goto m;
                        }
                    }
                    if (state & (measurements != null))
                    {
                        if (!GetState(op))
                        {
                            continue;
                        }
                        var att = performer.GetAttribute<InternalVariableAttribute>(op);

                        if (att != null)
                        {
                            if (att.IsDerivation)
                            {
                                if (op is IDerivation der)
                                {
                                    var d = der.Derivation;
                                    for (var j = 0; j < measurements.Count; j++)
                                    {
                                        var m = measurements[j];
                                        if (m == op)
                                        {
                                            var mtt = "value" + i;
                                            vari.Add("general_service.interfaces.IValue  " + mtt + ";");
                                            init.Add(mtt + " = this.output[" + j + "];");
                                            values.Add(i);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (var j = 0; j < measurements.Count; j++)
                                {
                                    var m = measurements[j];
                                    if (m == op)
                                    {
                                        var mtt = "value" + i;
                                        init.Add("this." + mtt + " = this.output[" + j + "];");
                                        values.Add(i);
                                    }
                                }

                            }
                        }
                    }
                m: continue;
                }
                var loc = local as BaseTreeCodeCreator;
                loc.Values = values;
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
                    var c = local.CreateCode(obj, t, ret, par.ToArray<string>());
                    lv = c["variables"];
                    if (lv != null)
                    {
                        if (lv.Count > 0)
                        {
                            vari.AddRange(lv);
                        }
                        else
                        {

                        }
                    }
                    lp = c["initializers"];
                    if (lp != null)
                    {
                        init.AddRange(lp);
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
                variables = vari;
                initializers = init;
                return code;
            }
            catch (Exception exception)
            {
                var ex = IncludedException.Get(exception);
                ex.HandleException();
            }
            local = null;
            variables = null;
            initializers = null;
            return null;
        }

        IList<string> JaveCreateCode(object obj, ObjectFormulaTree[] trees, ITreeCodeCreator creator,
            out ITreeCodeCreator local,
             out IList<string> variables, out IList<string> initializers, string current)
        {
            Exception ex;
            try
            {
                local = null;
                 IList<string> l = StaticJavaCreateCode(obj, trees, creator, out local,
                    out variables, out initializers, current);
                ObjectFormulaTree[] lt = local.Trees;
                foreach (ObjectFormulaTree tree in lt)
                {
                    var s = "";
                    object ret = tree.ReturnType;
                    if (ret.IsEmpty())
                    {
                        continue;
                    }
                    var t = typeCreator.GetType(ret) + " ";
                    var id = local[tree];
                    string cv = creator.GetConstValue(tree);
                    string def = "";
                    if (cv == null)
                    {
                        def = typeCreator.GetDefaultValue(ret) + "";
                        if (def.Length > 0)
                        {
                            s = t + " "  + id +  " = " + def;
                        }
                    }
                    else
                    {
                        s = t + " " + id + " = " + cv;
                    }
                    s += ";";
                    variables.Add(s);
                }
                return l;
            }
            catch (Exception e)
            {
                ex = IncludedException.Get(e);
            }
            throw ex;
        }

        IList<string> CreateOptionalCode(object obj, ITreeCodeCreator creator, out IList<string> variables, out IList<string> initializers)
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
                        var cc = creator.CreateCode(obj, cond, rc, par.ToArray());
                        lvc = cc["variables"];
                        if (lvc != null)
                        {
                            vari.AddRange(lvc);
                        }
                        lpc = cc["initializers"];
                        if (lpc != null)
                        {
                            init.AddRange(lpc);
                        }
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
                            lvr = cr["variables"];
                            if (lvr != null)
                            {
                                vari.AddRange(lvr);
                            }
                            lpr = cr["initializers"];
                            if (lpr != null)
                            {
                                init.AddRange(lpr);
                            }
                            if (creator.GetConstValue(t) == null)
                            {
                                code.AddRange(cr["code"]);
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
                var c = creator.CreateCode(obj, t, ret, par.ToArray<string>());
                lv = c["variables"];
                if (lv != null)
                {
                    vari.AddRange(lv);
                }
                lp = c["initializers"];
                if (lp != null)
                {
                    init.AddRange(lp);
                }
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


        static FormulaEditor.Performer formulaPerformer = new FormulaEditor.Performer();



        IList<string> CreateCode(object obj, ITreeCodeCreator creator,
            ObjectFormulaTree tree, List<ObjectFormulaTree> busy)
        {
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            formulaPerformer.GetList(tree, l, busy);
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
                var c = creator.CreateCode(obj, tr, rr, p.ToArray());
                cc.AddRange(c["code"]);
            }
            return cc;
        }

  


    }
}
