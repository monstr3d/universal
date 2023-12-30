using System;
using System.Collections.Generic;

using Diagram.UI.Interfaces;
using Diagram.UI;

using FormulaEditor;

using DataPerformer.Portable;

namespace DataPerformer.Formula
{
    class CSCodeCreator : IClassCodeCreator
    {

        static readonly Dictionary<Func<object, bool>, Func<string, object, List<string>>> dictionary =
                new Dictionary<Func<object, bool>, Func<string, object, List<string>>>()
                {
                    { (object o) => { return o is VectorFormulaConsumer; } , CreateVectorConsumer },
                    { (object o) => { return o is DifferentialEquationSolver; } , CreateDiffrerentialSolver },
                    { (object o) => { return o is Recursive; } , CreateRecursive },
                };


        internal CSCodeCreator()
        {
            this.AddCSharpCodeCreator();
        }

        #region IClassCodeCreator Members

        List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
        {
            foreach (Func<object, bool> key in dictionary.Keys)
            {
                if (key(obj))
                {
                    return dictionary[key](preffix, obj);
                }
            }
            return null;
        }
        #endregion

        #region Private Members

        static List<string> CreateVectorConsumer(string preffix, object obj)
        {
            List<string> l = new List<string>();
            bool check = StaticExtensionFormulaEditor.ShouldCheckValueInGeneratedCode;
            string pr = preffix;
            if (pr[pr.Length - 1] != '.')
            {
                pr = pr + ".";
            }
            VectorFormulaConsumer v = obj as VectorFormulaConsumer;
            l.Add("DataPerformer.Formula.VectorFormulaConsumer, FormulaEditor.Interfaces.ITreeCollectionProxyFactory");
            l.Add("{");
            l.Add("");
            l.Add("\tinternal CategoryObject()");
            l.Add("\t{");
            l.Add("\t\tproxyFactory = this;");
            bool beg = true;
            var feed = v.Feedback;
            l.Add("\t\tfeedback = new Dictionary<int, string>()");
            l.Add("\t\t{");
            foreach (var key in feed.Keys)
            {
                string s = "\t\t\t{ " + key + "," + "\"" + feed[key] + "\" }";
                if (!beg)
                {
                    s = ", " + s;
                }
                else
                {
                    beg = false;
                }
                l.Add(s);
            }
            l.Add("\t\t};");
            l.Add("");
            int dim = v.Dimension;
            l.Add("\t\tformulaString = new string[]");
            List<string> lf = new List<string>();
            for (int i = 0; i < dim; i++)
            {
                string sf = v.GetFormula(i);
                sf = sf.Replace("\r", "");
                sf = sf.Replace("\n", "");
                sf = sf.Replace("\"", "\\\"");
                lf.Add(sf);
            }
            List<string> lt = lf.GetCSharpCodeArray();
            foreach (string s in lt)
            {
                l.Add("\t\t" + s);
            }
            l.Add("\t\tisSerialized = true;");
            l.Add("\t\tcalculateDerivation = " + v.CalculateDerivation.StringValue() + ";");
            l.Add("\t\tderiOrder = " + v.DerivationOrder + ";");
            l.Add("\t\targuments =  new List<string>()");
            List<string> args = v.Arguments.GetCSharpCodeArray();
            foreach (string s in args) 
            {
                l.Add("\t\t" + s);
            }
            lt = v.CreateCSharpAliasList();
            l.Add("\t\tparameters =" + lt[0]);
            for (int i = 1; i < lt.Count; i++)
            {
                l.Add("\t\t" + lt[i]);
            }
            lt = v.OperationNames.GetDictionaryCSharpCode<int, string>();
            l.Add("\t\toperationNames = " + lt[0]);
            for (int i = 1; i < lt.Count; i++)
            {
                l.Add("\t\t" + lt[i]);
            }
            l.Add("\t\tInit();");
            l.Add("\t}");
            l.Add("");
            l.Add("\tFormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Action<object> checkValue)");
            l.Add("\t{");
            l.Add("\t\tFormulaEditor.Interfaces.ITreeCollection f = this;");
            l.Add("\t\tvar t = ");
            l.Add("\t\t\tFormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());");
            l.Add("\t\tvar tt = t.ToArray();");
            if (check)
            {
                l.Add("\t\treturn new Calculation(tt, checkValue);");
            }
            else
            {
                l.Add("\t\treturn new Calculation(tt);");
            }
            l.Add("\t}");
            l.Add("");
            FormulaEditor.Interfaces.ITreeCollection tc = v;
            lt = StaticExtensionFormulaEditor.TreeCollectionCodeCreator.CreateCode(tc.Trees, "Calculation", "internal ",
                check);
            l.Add("\tinternal class Calculation" + lt[0]);
            for (int i = 1; i < lt.Count; i++)
            {
                l.Add("\t" + lt[i]);
            }
            l.Add("}");
            return l;
        }

        static List<string> CreateDiffrerentialSolver(string preffix, object obj)
        {
            List<string> l = new List<string>();
            bool check = StaticExtensionFormulaEditor.ShouldCheckValueInGeneratedCode;
            string pr = preffix;
            if (pr[pr.Length - 1] != '.')
            {
                pr = pr + ".";
            }
            DifferentialEquationSolver v = obj as DifferentialEquationSolver;
            l.Add("DataPerformer.Formula.DifferentialEquationSolver, FormulaEditor.Interfaces.ITreeCollectionProxyFactory");
            l.Add("{");
            l.Add("");
            l.Add("\tinternal CategoryObject()");
            l.Add("\t{");
            l.Add("\t\tproxyFactory = this;");
            int dim = v.Variables.Length;
            var feed = v.Feedback;
            bool beg = true;

            l.Add("\t\tfeedback = new Dictionary<int, string>()");
            l.Add("\t\t{");
            foreach (var key in feed.Keys)
            {
                string s = "\t\t\t{ " + key + "," + "\"" + feed[key] + "\" }";
                if (!beg)
                {
                    s = ", " + s;
                }
                else
                {
                    beg = false;
                }
                l.Add(s);
            }
            l.Add("\t\t};");
            l.Add("");
            Dictionary<object, object> vars = v.VariableValues;
            l.Add("\t\tvars = new Dictionary<object, object>()");
            l.Add("\t\t{");
            beg = true;
            foreach (char c in vars.Keys)
            {
                object[] oo = vars[c] as object[];
                string sf = oo[0] + "";
                sf = sf.Replace("\r", "");
                sf = sf.Replace("\n", "");
                sf = sf.Replace("\"", "\\\"");
                string type = "(" + oo[1].GetType() + ")";
                string vv = "\t\t\t{\'" + c + "\' , new object[] {\"" + sf +
                    "\" , " + type + "(" + oo[1].StringValue() + ")}}";
                if (beg)
                {
                    vv = "\t\t\t" + vv;
                    beg = false;
                }
                else
                {
                    vv = "\t\t\t," + vv;
                }
                l.Add(vv);
            }
            l.Add("\t\t};");
            beg = true;
            vars = v.Hpars;
            l.Add("\t\tpars = new Dictionary<object, object>()");
            l.Add("\t\t{");
            foreach (char c in vars.Keys)
            {
                object o = vars[c];
                string vv = "\t\t\t{\'" + c + "\' , \"" + o + "\"}";
                if (beg)
                {
                    vv = "\t\t\t" + vv;
                    beg = false;
                }
                else
                {
                    vv = "\t\t\t," + vv;
                }
                l.Add(vv);
            }
            l.Add("\t\t};");
            vars = v.Haliases;
            l.Add("\t\taliases = new Dictionary<object, object>()");
            l.Add("\t\t{");
            beg = true;
            foreach (string c in vars.Keys)
            {
                object o = vars[c];
                string type = "(" + o.GetType() + ")";
                string vv = "\t\t\t{\"" + c + "\" , " + type + "(" + o.StringValue() + ")}";
                if (beg)
                {
                    vv = "\t\t\t" + vv;
                    beg = false;
                }
                else
                {
                    vv = "\t\t\t," + vv;
                }
                l.Add(vv);
            }
            l.Add("\t\t};");
            l.Add("\t\tisSerialized = true;");
            l.Add("\t\tcalculateDerivation = " + v.CalculateDerivation.StringValue() + ";");
            l.Add("\t\tderiOrder = " + v.DerivationOrder + ";");
            l.Add("\t\targuments =  new List<string>()");
            List<string> args = v.Arguments.GetCSharpCodeArray();
            foreach (string s in args)
            {
                l.Add("\t\t" + s);
            }
            l.Add("\t}");
            l.Add("\tFormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Action<object> checkValue)");
            l.Add("\t{");
            l.Add("\t\tFormulaEditor.Interfaces.ITreeCollection f = this;");
            l.Add("\t\tFormulaEditor.ObjectFormulaTree[] trees = FormulaEditor.StaticExtensionFormulaEditor.Transform(f.Trees);");
            if (check)
            {
                l.Add("\t\treturn new Calculation(trees, checkValue);");
            }
            else
            {
                l.Add("\t\treturn new Calculation(trees);");
            }
            l.Add("\t}");
            l.Add("");
            FormulaEditor.Interfaces.ITreeCollection tc = v;
            List<string> lt = 
                StaticExtensionFormulaEditor.TreeCollectionCodeCreator.CreateCode(tc.Trees, 
                "Calculation", "internal ",
                check);
            l.Add("\tinternal class Calculation" + lt[0]);
            for (int i = 1; i < lt.Count; i++)
            {
                l.Add("\t" + lt[i]);
            }
            l.Add("}");
            return l;
        }

        static List<string> CreateRecursive(string preffix, object obj)
        {
            List<string> l = new List<string>();
            bool check = StaticExtensionFormulaEditor.ShouldCheckValueInGeneratedCode;
            string pr = preffix;
            if (pr[pr.Length - 1] != '.')
            {
                pr = pr + ".";
            }
            Recursive v = obj as Recursive;
            l.Add("DataPerformer.Formula.Recursive, FormulaEditor.Interfaces.ITreeCollectionProxyFactory");
            l.Add("{");
            l.Add("");
            l.Add("\tinternal CategoryObject()");
            l.Add("\t{");
            l.Add("\t\tproxyFactory = this;");
            Dictionary<object, object> vars = v.Variables;
            bool beg = true;
            l.Add("\t\tvars = new Dictionary<object, object>()");
            l.Add("\t\t{");
            foreach (char key in vars.Keys)
            {
                object[] o = vars[key] as object[];
                string s = "{\'" + key + "\', new object[] {" + ToTypedObject(o[0]) + ","
                    + ToFormula(o[1]) + "," + ToTypedObject(o[2]) + "}}";
                if (beg)
                {
                    s = "\t\t\t" + s;
                    beg = false;
                }
                else
                {
                    s = "\t\t\t," + s;
                }
                l.Add(s);
            }
            l.Add("\t\t};");
            l.Add("");
            vars = v.Aliases;
            beg = true;
            l.Add("\t\taliases = new Dictionary<object, object>()");
            l.Add("\t\t{");
            foreach (char key in vars.Keys)
            {
                object[] o = vars[key] as object[];
                string s = "{\'" + key + "\', " + ToTypedObject(vars[key]) + "}";
                if (beg)
                {
                    s = "\t\t\t" + s;
                    beg = false;
                }
                else
                {
                    s = "\t\t\t," + s;
                }
                l.Add(s);
            }
            l.Add("\t\t};");
            l.Add("");
            vars = v.ExternalAliases;
            beg = true;
            l.Add("\t\texternalAls = new Dictionary<object, object>()");
            l.Add("\t\t{");
            foreach (char key in vars.Keys)
            {
                object[] o = vars[key] as object[];
                string s = "{\'" + key + "\', \"" + vars[key] + "\"}";
                if (beg)
                {
                    s = "\t\t\t" + s;
                    beg = false;
                }
                else
                {
                    s = "\t\t\t," + s;
                }
                l.Add(s);
            }
            l.Add("\t\t};");
            l.Add("");
            vars = v.Pars;
            beg = true;
            l.Add("\t\tpars = new Dictionary<object, object>()");
            l.Add("\t\t{");
            foreach (char key in vars.Keys)
            {
                object[] o = vars[key] as object[];
                string s = "{\'" + key + "\', \"" + vars[key] + "\"}";
                if (beg)
                {
                    s = "\t\t\t" + s;
                    beg = false;
                }
                else
                {
                    s = "\t\t\t," + s;
                }
                l.Add(s);
            }
            l.Add("\t\t};");
            l.Add("");
            l.Add("\t}");
            l.Add("");
            l.Add("\tFormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)");
            l.Add("\t{");
            l.Add("\t\tFormulaEditor.Interfaces.ITreeCollection f = this;");
            l.Add("\t\tFormulaEditor.ObjectFormulaTree[] trees = FormulaEditor.StaticExtensionFormulaEditor.Transform(f.Trees);");
            if (check)
            {
                l.Add("\t\treturn new Calculation(trees, checkValue);");
            }
            else
            {
                l.Add("\t\treturn new Calculation(trees);");
            }
            l.Add("\t}");
            l.Add("");
            FormulaEditor.Interfaces.ITreeCollection tc = v;
            List<string> lt =
                StaticExtensionFormulaEditor.TreeCollectionCodeCreator.CreateCode(tc.Trees,
                "Calculation", "internal ",
                check);
            l.Add("\tinternal class Calculation" + lt[0]);
            for (int i = 1; i < lt.Count; i++)
            {
                l.Add("\t" + lt[i]);
            }
            l.Add("}");
            return l;
        }

        static string ToFormula(object formula)
        {
            string sf = formula + "";
            sf = sf.Replace("\r", "");
            sf = sf.Replace("\n", "");
            sf = sf.Replace("\"", "\\\"");
            return "\"" + sf + "\"";
        }

        static string ToTypedObject(object ob)
        {
            return "(" + ob.GetType() + ")(" + ob.StringValue() + ")";
        }

        #endregion
    }
}
