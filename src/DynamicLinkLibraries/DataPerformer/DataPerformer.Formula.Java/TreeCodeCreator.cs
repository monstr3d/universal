using BaseTypes;
using BaseTypes.Attributes;
using BaseTypes.CodeCreator.Interfaces;
using BaseTypes.Interfaces;
using DataPerformer.Interfaces;
using DataPerformer.Interfaces.Attributes;
using DataPerformer.Portable.Measurements;
using Diagram.Interfaces;
using Diagram.UI.Attributes;
using Diagram.UI.Interfaces;
using ErrorHandler;
using FormulaEditor;
using FormulaEditor.CodeCreators;
using FormulaEditor.CodeCreators.Interfaces;
using FormulaEditor.Interfaces;
using System.Text;

namespace DataPerformer.Formula.Java
{
    [Language("Java")]
    internal class TreeCodeCreator : BaseTreeCodeCreator
    {
        internal TreeCodeCreator()
            : base()
        {
            this.AddTreeCodeCreator();
        }
    }

    internal class BaseTreeCodeCreator : SeparatorCodeCreator, IOperationSeparatorCreator
    {

        #region Const

        private static bool cycle = false;



        private static readonly Dictionary<string, string[]> elementary =
new Dictionary<string, string[]> {
            {"s", new string[] {"Math.sin(", "[0])"}},
            {"c", new string[] {"Math.cos(", "[0])"}},
            {"l", new string[] {"Math.log(", "[0])" }},
            {"e", new string[] {"Math.exp(", ")"}},
            {"t", new string[] {"Math.tan(", "[0])" }},
            {"q", new string[] {"Math.tan( Math.PI / 2 - (", "))"}},
            {"a", new string[] {"Math.atan(", "[0])"}},
            {"b", new string[] {"Math.PI / 2 - Math.atan(", "[0])" }},
            {"j", new string[] {"1 / Math.cos(", "[0])" }},
            {"k", new string[] {"1 / Math.sin(", "[0])" }},
            {"f", new string[] {"Math.asin(", "[0])" }},
            {"g", new string[] {"Math.acos(", "[0])" }},
            {"?", new string[] { "(", ")"}},
            {"-", new string[] {" -(", "[0])"}},
            {"A", new string[] {"Math.abs(", "[0])"}},
};

        private static readonly string[] squareRoot = new string[] { "Math.sqrt(", "[0]);" };

        private static readonly string[] root = new string[] { "Math.pow(", ", 1 /(", "[0]));" };

        private static readonly string[] abs = new string[] { "Math.abs(", "[0]);" };

        private static readonly string[] absPower = new string[] { "Math.pow(Math.abs(", "), ", ");" };

        private static readonly string[] atan2 = new string[] { "Math.atan2(", "[0], ", "[0]);" };


        private static readonly string[] modulodiv = new string[] { "(", " % ", ");" };


        private static readonly string[] optionalSeparator = new string[] { "(", "[0]) ? (", "[0]) : (", "[0]);" };

        private static readonly string[] power = new string[]
        { "Math.pow(", "[0], ", "[0]);" };


        private static Dictionary<string, string[]> elementaryBinary = new Dictionary<string, string[]>()
        {
            {"+", new string[] {"(", "[0]) + (", "[0]);" }},
            {"-", new string[] {"(", "[0]) - (", "[0]);" }},
            {"*", new string[] {"(", "[0]) * (", "[0]);" }},
        };

        private static readonly Dictionary<string, string[]> comparation = new Dictionary<string, string[]>()
        {
            {">", new string[] {"(", "[0]) > (", "[0]));"}},
            {"<", new string[] {"(", "[0]) < (", "[0]));"}},
            {"\u2260", new string[] {"(", "[0]) != (", "[0]));"}},
            {"\u2264", new string[] {"(", "[0]) >= (", "[0]));" }},
            {"\u2265", new string[] {"(", "[0]) <= (", "[0]));" }},
        };

        private static readonly Dictionary<string, string[]> logicalOperation = new Dictionary<string, string[]>()
       {
            {"\u2216", new string[] {"(", "[0]) & (", "[0]));"}},
            {"\u2217", new string[] {"(", "[0]) | (", "[0]));" }},
            {"\u8835", new string[] {" = (!(", "[0])) | (", "[0]));" }}
       };



        private static string[] fraction = new string[] { "(", ") / (", ");" };


        private static string[] equals = new string[] { "(", ").Equals(", ");" };

        #endregion

        object current;

        string language = "Java";
        IClassCodeCreator classCodeCreator;
        ITypeCreator typeCreator;

        Performer performer = new Performer();

        internal List<int> Values
        {
            get;
            set;
        }



        protected BaseTreeCodeCreator()
        {
            separatorCreator = this;
            typeCreator = performer.GetLaguageObject<ITypeCreator>(language);
            classCodeCreator = performer.GetLaguageObject<IClassCodeCreator>(language);
        }


        private string[] GetMultiSeparator(IObjectOperation op)
        {
            if (op is AliasNameVariable)
            {
                return ["aliasName", ".getAliasNameValue();"];
            }
            if (op is IAliasNameHolder)
            {
                return ["aliasName", ".getAliasNameValue();"];
            }
            if (op is IMeasurementHolder mh)
            {
                return ["measurement", ".getMeasurementValue();"];
            }
            if (op is OptionalOperation)
            {
                return optionalSeparator;
            }
            if (op is NegationOperation)
            {
                return new string[] { " = !", ";" };
            }
            if (op is ElementaryBinaryOperation)
            {
                ElementaryBinaryOperation eb = op as ElementaryBinaryOperation;
                string seb = eb.Symbol + "";
                if (elementaryBinary.ContainsKey(seb))
                {
                    return elementaryBinary[seb];
                }
            }
            if (op is ElementaryDivisionOperation ed)
            {
                char s = ed.Symbol;
                if (op.ReturnType.Equals((double)0) | op.ReturnType.Equals((float)0))
                {
                    switch (ed.Symbol)
                    {
                        case '﹪':
                            {
                                return modulodiv;
                            }
                        case '/':
                            {
                                return fraction;
                            }
                    }
                }

            }
            if (op is ElementaryModuloDivision)
            {
                if (op.ReturnType.Equals((double)0))
                {
                    return modulodiv;
                }
            }
            if (op is ElementaryAtan2)
            {
                return atan2;
            }
            if (op is EqualityOperation)
            {
                return equals;
            }
            if (op is ElementaryFraction)
            {
                return fraction;
            }
            if (op is ElementaryRoot)
            {
                if (op.InputTypes.Length == 1)
                {
                    return squareRoot;
                }
                return root;
            }
            if (op is ElementaryAbs)
            {
                if (op.InputTypes.Length == 1)
                {
                    return abs;
                }
                return absPower;
            }
            if ((op is ElementaryFunctionOperation) | (op is ElementaryAbs))
            {
                string key = "";
                if (op is ElementaryFunctionOperation)
                {
                    ElementaryFunctionOperation o = op as ElementaryFunctionOperation;
                    key = o.Symbol + "";
                }
                else
                {
                    key = "A";
                }
                if (elementary.ContainsKey(key))
                {
                    return elementary[key];
                }
            }
            if (op is ElementaryIntegerOperation)
            {
                return new string[] { "(" + op.ReturnType.GetType().Name + ")", ";" };
            }
            if (op is ComparationOperation)
            {
                ComparationOperation co = op as ComparationOperation;
                string cos = co.String;
                if (comparation.ContainsKey(cos))
                {
                    return comparation[cos];
                }
            }
            if (op is LogicalOperation)
            {
                LogicalOperation lo = op as LogicalOperation;
                string los = lo.Symbol + "";
                if (logicalOperation.ContainsKey(los))
                {
                    return logicalOperation[los];
                }
            }
            if (op is ElementaryPowerOperation)
            {
                return power;
            }
            return null;
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



        private List<string> CreateJavaCode(object obj, ObjectFormulaTree tree, string ret, string[] parameters,
            out IList<string> variables, out IList<string> initializers)
        {
            variables = new List<string>();
            initializers = new List<string>();
            var num = int.Parse(ret.Substring(4));
            var state = GetState(obj);
            var op = tree.Operation;
            var type = op.ReturnType.GetType();
            var att = performer.GetAttribute<InternalVariableAttribute>(op);
            var prefix = "";
            if (type == typeof(double))
            {
                prefix = "(double[])";
            }
            if (att != null)
            {
                if (true)
                {
                    if (state & GetState(op))
                    {
                        if (op is IValue)
                        {
                            var anvn = "value" + num;
                            var lan = new List<string>();
                            lan.Add("variable = " + anvn + ".getIValue();");
                            lan.Add("if (check(variable)) { success = false; return; }");
                            if (!att.IsDerivation)
                            {
                                var ss = "general_service.interfaces.IValue value" + num + ";";
                                variables.Add(ss);
                            }
                            lan.Add(tree.ToType(num, true));
                            return lan;

                        }

                    }
                }
            }
            if (op is AliasNameVariable anv)
            {
                var an = anv.AliasName;
                var nam = an.Name;
                var anvn = "aliasName" + num;
                var lan = new List<string>();
                var stt = tree.ToType(num);
                var spp = stt.Contains("[]") ? ")[0]" : "";
                lan.Add(stt + anvn + ".getAliasNameValue()" + spp + ";");
                lan.Add("if (check(var_" + num + ")) { success = false; return; }");
                var init = new List<string>()
                {
                    anvn + " = new general_service.AliasName(this, \"" + nam +"\");"
                };
                (initializers as List<string>).AddRange(init);
                var vari = new List<string> { "general_service.interfaces.IAliasName " + anvn + ";" };
                (variables as List<string>).AddRange(vari);
                return lan;
            }
            if (op is IMeasurementHolder mh)
            {
                var mea = mh.Measurement;
                if (mea is TimeMeasurement)
                {
                    return new List<string>()
                    {
                        ret + "[0] = this.getInternalTime();"
                    };
                }
                goto Label;
            }
            else if (op is IAliasNameHolder anh)
            {
                var an = anh.AliasName;
                var nam = an.Name;
                var anvn = "aliasName" + num;
                var lan = new List<string>();
                lan.Add("this.variable = " + anvn + ".getAliasNameValue();");
                var init = new List<string>()
                {
                  anvn + " = new general_service.AliasName(this, \"" + nam +"\");"
                  };
                (initializers as List<string>).AddRange(init);
                var vari = new List<string>() { "general_service.interfaces.IAliasName " + anvn + ";" };
                (variables as List<string>).AddRange(vari);
            }
        Label:
            string[] sep = separatorCreator[tree];
            if (sep == null)
            {
                variables = null;
                initializers = null;
                return null;
            }
            if (sep[1][0] == '.')
            {
                sep[1] = num + sep[1];
            }
            var list = new List<string>();
            string tt = TypeCreator.GetType(tree.ReturnType);
            string st = "";
            if (variables == null)
            {
                variables = new List<string>();
            }
            if (initializers == null)
            {
                initializers = new List<string>();
            }
            string s = ret + tree.ToType();
            int n = sep.Length;
            int m = parameters.Length;
            for (int i = 0; i < n; i++)
            {
                s += sep[i];
                if (i < m)
                {
                    s += parameters[i];
                }
            }
            if (prefix.Length > 0)
            {
                s = s.Replace(";", "");
                if (s.Contains("measurement"))
                {
                    s += ")[0];";
                }
                else
                {
                    s += ");";
                }
            }
            list.Add(s);
            list.Add("if (check(" + ret + ")) { success = false; return; } ");
            if (s.Contains("this.measurement"))
            {
                //       variables.Add("measurement" + num + " != IMeasurement");
            }
            return list;
        }
        /// <summary>
        /// Creates code for array operation
        /// </summary>
        /// <param name="tree">Tree</param>
        /// <param name="ret">Return</param>
        /// <param name="parameters">Parameters of tree</param>
        /// <param name="variables">Variables</param>
        /// <param name="initializers">Initializers</param>
        /// <returns>List of code strings</returns>
        protected IList<string> CreateArraySingleCode(ObjectFormulaTree tree, string ret, string[] parameters,
           out IList<string> variables, out IList<string> initializers)
        {
            variables = new List<string>();
            initializers = new List<string>();
            try
            {
                IObjectOperation op = tree.Operation;
                if (!(op is ArraySingleOperation))
                {
                    return null;
                }
                ArraySingleOperation ars = op as ArraySingleOperation;
                string ops = (ars.Type == ArraySingleOperationType.Sum) ? " + " : " * ";
                ObjectFormulaTree t = tree[0];
                ArrayReturnType art = t.ReturnType as ArrayReturnType;
                int n = art.Dimension[0];
                string sp = "";
                if (art.IsObjectType)
                {
                    sp = "(double)";
                }
                StringBuilder sb = new StringBuilder();
                sb.Append(ret);
                sb.Append(" = ");
                string par = sp + parameters[0] + "[";
                sb.Append(par + "0]");
                par = ops + par;
                for (int i = 1; i < n; i++)
                {
                    sb.Append(par);
                    sb.Append(i);
                    sb.Append("]");
                }
                sb.Append(";");
                return new List<string> { { sb.ToString() } };
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;
        }





        /// <summary>
        /// Creates Code from tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <param name="ret">Return value</param>
        /// <param name="parameters">Parameters</param>
        /// <param name="variables">Variables</param>
        /// <param name="initializers">Initializers</param>
        /// <returns>List of code</returns>
        protected override Dictionary<string, List<string>> CreateCode(object obj, ObjectFormulaTree tree,
            string ret, string[] parameters)
        {
            IList<string> variables;
            IList<string> initializers;

            IList<string> l = CreateJavaCode(obj, tree, ret, parameters, out variables, out initializers);
            if (l != null)
            {
                var d = new Dictionary<string, List<string>>()
                {
                    { "initializers", initializers as List<string> },
                    { "variables", variables  as List<string>},
                    { "code", l  as List<string>}
                };

                return d;
            }
            l = CreateArraySingleCode(tree, ret, parameters, out variables, out initializers);
            if (l != null)
            {
                var d = new Dictionary<string, List<string>>()
                {
              { "initializers", initializers as List<string> },
                    { "variables", variables  as List<string>},
                    { "code", l  as List<string>}
                    };
                return d;
            }
            try
            {
                l = CreateArrayCode(obj, tree, ret, parameters, out variables, out initializers);
                if (l != null)
                {
                 var    d = new Dictionary<string, List<string>>()
                {
                  { "initializers", initializers as List<string> },
                    { "variables", variables  as List<string>},
                    { "code", l  as List<string>}
                  };
                    return d;
                }
            }
            catch (Exception exception)
            {
                exception.HandleFictionException();
            }
            if (ret.Length > 0)
            {
                var ll = CreateTreeCode(tree, ret, parameters, out variables, out initializers);
                var d = new Dictionary<string, List<string>>()
                {
                  { "initializers", initializers as List<string> },
                    { "variables", variables  as List<string>},
                    { "code", l  as List<string>}
                  };
                return d;

            }
            return null;
        }

        /// <summary>
        /// Creates array code
        /// </summary>
        /// <param name="tree">Base tree</param>
        /// <param name="retValue">Return</param>
        /// <param name="parameters">Variables</param>
        /// <param name="variables">Parameters</param>
        /// <param name="initializers">Initializers</param>
        /// <returns>List of code strings</returns>
        protected IList<string> CreateTreeCode(ObjectFormulaTree tree, string retValue, string[] parameters,
            out IList<string> variables, out IList<string> initializers)
        {
            List<string> l = new List<string>();
            if (tree.ReturnType.IsEmpty())
            {
                variables = new List<string>();
                initializers = new List<string>();
                return l;
            }
            int n = StaticCodeCreator.GetNumber(this, tree);
            string curr = "trees[" + n + "].";
            // l.Add("currentTree = trees[" + n + "];");
            int count = tree.Count;
            List<string> vari = new List<string>();
            if (count > 0)
            {
                string ta = "treeArray_" + n;
                l.Add("currentArray = " + ta + ";");
                vari.Add("object[] " + ta + " = new object[" + count + "];");
            }
            for (int i = 0; i < count; i++)
            {
                ObjectFormulaTree t = tree[i];
                if (t == null)
                {
                    continue;
                }
                if (count > 0)
                {
                    string id = codeCreator[t];
                    l.Add("currentArray[" + i + "] = " + id + ";");
                }
            }
            string ss = "";
            string tt = typeCreator.GetType(tree.ReturnType);
            if (!tt.Equals("object"))
            {
                ss = "(" + tt + ")";
            }
            if (count > 0)
            {
                l.Add("variable = " + curr + "Calculate(currentArray);");
                l.Add("if (checkValue(variable)) { success = false; return; }");
                l.Add(retValue + " = " + ss + "variable;");
            }
            else
            {
                l.Add("variable =  " + curr + "Calculate();");
                l.Add("if (checkValue(variable)) { success = false; return; }");
                l.Add(retValue + " = " + ss + "variable;");
            }
            initializers = new List<string>();
            variables = vari;
            return l;
        }


        protected virtual string[] Get(ObjectFormulaTree tree)
        {
            string[] ss = null;
            IObjectOperation op = tree.Operation;
            ss = GetMultiSeparator(op);
            if (ss != null)
            {
                return ss;
            }
            return null;
        }


        string[] IOperationSeparatorCreator.this[ObjectFormulaTree tree] => Get(tree);

        protected override ITypeCreator TypeCreator => typeCreator;

        public override ITreeCodeCreator Create(object obj, ObjectFormulaTree[] trees)
        {
            if (classCodeCreator is ICurrentObject currentObject)
            {
                var co = currentObject.CurrentObject;
                if (current != co)
                {
                    current = co;
                }
                if (current is ITreeCollection tc)
                {
                    var cc = new BaseTreeCodeCreator();
                    cc.Set(tc.Trees);
                    return cc;
                }
            }
            throw new OwnNotImplemented();
        }
        const double a = 0;

        public override string GetConstValue(ObjectFormulaTree tree)
        {
            var op = tree.Operation;
            var type = op.ReturnType;
            var to = type.GetType();
            if (op is IStringConstantValue val)
            {
                var sv = val.Value;
                if (to == typeof(double))
                {
                    return " new double[] { " + sv + " }";
                }

                return (op as IStringConstantValue).Value;
            }

            if (op.ReturnType.Equals(""))
            {
                return "\"\"";
            }
            return null;
        }

        /// <summary>
        /// Creates code from tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <param name="ret">Return identifier</param>
        /// <param name="parameters">Parameters of tree</param>
        /// <param name="variables">Variables of tree</param>
        /// <param name="initializers">Initializers</param>
        /// <returns>List of code strings</returns>
        protected IList<string> CreateArrayCode(object obj, ObjectFormulaTree tree, string ret, string[] parameters,
            out IList<string> variables, out IList<string> initializers)
        {
            List<string> vari = new List<string>();
            List<string> init = new List<string>();
            variables = vari;
            initializers = init;
            IObjectOperation op = tree.Operation;
            if (!(op is ArrayOperation))
            {
                return null;
            }
            ArrayOperation ao = op as ArrayOperation;
            object[] types = ao.Types;
            string[] par = new string[parameters.Length];
            for (int i = 0; i < par.Length; i++)
            {
                par[i] = GetModifier(types[i]) + parameters[i];
            }
            ArrayReturnType art = ao.ReturnType as ArrayReturnType;
            List<ObjectFormulaTree> ch = new List<ObjectFormulaTree>();
            for (int i = 0; i < tree.Count; i++)
            {
                if (tree[i] != null)
                {
                    ch.Add(tree[i]);
                }
            }
            ObjectFormulaTree t = new ObjectFormulaTree(ao.SingleOperation, ch);
            List<string> list = new List<string>();
            bool success;
            if (cycle)
            {
                ProcessCycleArrayCode(obj, 0, tree, t, ret, par, parameters, types, art, list, vari, init, out success);
            }
            else
            {
                ProcessArrayCode(0, tree, t, ret, par, types, art, list, vari, init, out success);
            }
            if (!success)
            {
                return null;
            }
            return list;
        }

        /// <summary>
        /// Process cyclic array code
        /// </summary>
        /// <param name="level">Level</param>
        /// <param name="baseTree">Base tree</param>
        /// <param name="childTree">Child tree</param>
        /// <param name="ret">Rerurn</param>
        /// <param name="parameters">Parametres</param>
        /// <param name="pureParameters">Pure parametres</param>
        /// <param name="types">Types of variables</param>
        /// <param name="retType">Type of return</param>
        /// <param name="list">List of code strings</param>
        /// <param name="variables">List of variables</param>
        /// <param name="initializers">List of initializers</param>
        /// <param name="success">The success sign</param>
        protected void ProcessCycleArrayCode(object obj, int level, ObjectFormulaTree baseTree,
            ObjectFormulaTree childTree, string ret, string[] parameters,
            string[] pureParameters, object[] types, ArrayReturnType retType,
            List<string> list, List<string> variables, List<string> initializers, out bool success)
        {
            var retp = ret + "[";
            if (retType.Dimension.Length == 1)
            {
                //int n = retType.Dimension[level];
                string nam = null;
                for (int i = 0; i < types.Length; ++i)
                {
                    if (types[i] is ArrayReturnType)
                    {
                        nam = pureParameters[i] + ".Length";
                    }
                }
                string[] par = new string[parameters.Length];
                list.Add("for (int i = 0; i < " + nam + "; i++)");
                list.Add("{");
                string si = "i";
                string sf = si + "]";
                string retLocal = retp + sf;
                for (int j = 0; j < parameters.Length; j++)
                {
                    par[j] = parameters[j] + "";
                    int ll = GetLength(types[j]);
                    if (ll > 0)
                    {
                        if (ll == 1)
                        {
                            par[j] += "[";
                        }
                        par[j] += sf;
                    }
                }
                IList<string> vari;
                IList<string> init;
                var ld = CreateCode(obj, childTree, ret, par);
                success = (ld != null);
                if (!success)
                {
                    return;
                }
                var l = ld["code"];
                vari = ld["variables"];
                init = ld["iniializers"];

                foreach (string s in l)
                {
                    list.Add("\t" + s);
                }
                if (vari != null)
                {
                    variables.AddRange(vari);
                }
                if (init != null)
                {
                    initializers.AddRange(init);
                }
                list.Add("}");
                success = true;
                return;
            }
            if (level == retType.Dimension.Length - 1)
            {
                int n = retType.Dimension[level];
                string[] par = new string[parameters.Length];
                for (int i = 0; i < n; i++)
                {
                    string si = i + "";
                    string sf = si + "]";
                    string retLocal = retp + sf;

                    for (int j = 0; j < parameters.Length; j++)
                    {
                        par[j] = parameters[j] + "";
                        int ll = GetLength(types[j]);
                        if (ll > 0)
                        {
                            if (ll == 1)
                            {
                                par[j] += "[";
                            }
                            par[j] += sf;
                        }
                    }
                    IList<string> vari;
                    IList<string> init;
                    var l = CreateCode(obj, childTree, retLocal, par);
                    success = (l != null);
                    if (!success)
                    {
                        return;
                    }
                    list.AddRange(l["code"]);
                    vari = l["variables"];
                    if (vari != null)
                    {
                        variables.AddRange(vari);
                    }
                    init = l["initializers"];
                    if (init != null)
                    {
                        initializers.AddRange(init);
                    }
                }
                success = true;
                return;
            }
            string[] localPar = new string[parameters.Length];
            int k = retType.Dimension[level];
            int length = retType.Dimension.Length;
            for (int i = 0; i < k; i++)
            {
                string[] parlocal = new string[parameters.Length];
                string retLocal = retp + i + ",";
                for (int j = 0; j < parameters.Length; i++)
                {
                    int dim = GetLength(types[j]);
                    if (dim == 0)
                    {
                        continue;
                    }
                    if ((dim + level) <= length)
                    {
                        continue;
                    }
                    if ((dim + level) == length)
                    {
                        parlocal[i] += "[" + i + ", ";
                        continue;
                    }
                    parlocal[i] += i + ",";
                }
                ProcessArrayCode(level + 1, baseTree, childTree, retLocal, parlocal, types,
                    retType, list, variables, initializers, out success);
                if (!success)
                {
                    return;
                }
            }
            success = true;
        }


        /// <summary>
        /// Processes array code
        /// </summary>
        /// <param name="level">Level</param>
        /// <param name="baseTree">Base tree</param>
        /// <param name="childTree">Current tree</param>
        /// <param name="ret">Return</param>
        /// <param name="parameters">Parameters</param>
        /// <param name="types">Types of variables</param>
        /// <param name="retType">Return type</param>
        /// <param name="list">List of code strings</param>
        /// <param name="variables">Variables</param>
        /// <param name="initializers">Initializers</param>
        /// <param name="success">The "success" sign</param>
        protected void ProcessArrayCode(int level, ObjectFormulaTree baseTree, ObjectFormulaTree childTree,
            string ret, string[] parameters, object[] types, ArrayReturnType retType, List<string> list,
           List<string> variables, List<string> initializers, out bool success)
        {
            var retp = ret + "[";
            if (level == retType.Dimension.Length - 1)
            {
                int n = retType.Dimension[level];
                string[] par = new string[parameters.Length];
                for (int i = 0; i < n; i++)
                {
                    string si = i + "";
                    string sf = si + "]";
                    string retLocal = retp + sf;

                    for (int j = 0; j < parameters.Length; j++)
                    {
                        par[j] = parameters[j] + "";
                        int ll = GetLength(types[j]);
                        if (ll > 0)
                        {
                            if (ll == 1)
                            {
                                par[j] += "[";
                            }
                            par[j] += sf;
                        }
                    }
                    IList<string> vari;
                    IList<string> init;
                    var l = CreateCode(Object, childTree, retLocal, par);
                    success = (l != null);
                    if (!success)
                    {
                        return;
                    }
                    list.AddRange(l["code"]);
                    vari = l["variables"];
                    if (vari != null)
                    {
                        variables.AddRange(vari);
                    }
                    init = l["initializers"];
                    if (init != null)
                    {
                        initializers.AddRange(init);
                    }
                }
                success = true;
                return;
            }
            string[] localPar = new string[parameters.Length];
            int k = retType.Dimension[level];
            int length = retType.Dimension.Length;
            for (int i = 0; i < k; i++)
            {
                string[] parlocal = new string[parameters.Length];
                string retLocal = retp + i + ",";
                for (int j = 0; j < parameters.Length; i++)
                {
                    int dim = GetLength(types[j]);
                    if (dim == 0)
                    {
                        continue;
                    }
                    if ((dim + level) <= length)
                    {
                        continue;
                    }
                    if ((dim + level) == length)
                    {
                        parlocal[i] += "[" + i + ", ";
                        continue;
                    }
                    parlocal[i] += i + ",";
                }
                ProcessArrayCode(level + 1, baseTree, childTree, retLocal, parlocal, types,
                    retType, list, variables, initializers, out success);
                if (!success)
                {
                    return;
                }
            }
            success = true;
        }


        private string GetModifier(object type)
        {
            string s = "";
            if (type is ArrayReturnType)
            {
                ArrayReturnType art = type as ArrayReturnType;
                if (art.IsObjectType)
                {
                    s = "(" + typeCreator.GetType(art.ElementType) + ")";
                }
            }
            return s;
        }

        private int GetLength(object type)
        {
            if (!(type is ArrayReturnType))
            {
                return 0;
            }
            ArrayReturnType art = type as ArrayReturnType;
            return art.Dimension.Length;
        }

    }
}
