using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
                    { (object o) => { return o is DifferentialEquationSolver; } , CreateDiffrerentialSolver }
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
            if (check)
            {
                l.Add("\t\treturn new Calculation(f.Trees, checkValue);");
            }
            else
            {
                l.Add("\t\treturn new Calculation(f.Trees);");
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
          //  l.Add("\t\tInit();");
            l.Add("\t}");
            l.Add("");
            l.Add("\tFormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Action<object> checkValue)");
            l.Add("\t{");
            l.Add("\t\tFormulaEditor.Interfaces.ITreeCollection f = this;");
            if (check)
            {
                l.Add("\t\treturn new Calculation(f.Trees, checkValue);");
            }
            else
            {
                l.Add("\t\treturn new Calculation(f.Trees);");
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



        #endregion
    }
}
