using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Simulink.Parser.Library.Interfaces;
using Simulink.Parser.Library.DiagramElements;

namespace Simulink.CSharp.Library.CodeCreators
{
    partial class CodeCreator
    {
        #region Fields

        private static readonly Dictionary<string, string[]> elementary =
new Dictionary<string, string[]> {
            {"Sin", new string[] {" = Math.Sin(", ");"}},
            {"Cos", new string[] {" = Math.Cos(", ");"}},
            {"l", new string[] {" = Math.Log(", ");"}},
            {"e", new string[] {" = Math.Exp(", ");"}},
            {"t", new string[] {" = Math.Tan(", ");"}},
            {"q", new string[] {" = Math.Tan( Math.PI / 2 - (", "));"}},
            {"a", new string[] {" = Math.Atan(", ");"}},
            {"b", new string[] {" = Math.PI / 2 - Math.Atan(", ");"}},
            {"j", new string[] {" = 1 / Math.Cos(", ");"}},
            {"k", new string[] {" = 1 / Math.Sin(", ");"}},
            {"f", new string[] {" = Math.Asin(", ");"}},
            {"g", new string[] {" = Math.Acos(", ");"}},
            {"?", new string[] {" = (", ");"}},
            {"-", new string[] {" = -(", ");"}}
        };


        #endregion


        #region Methods

        IList<string> CreateElementary(Block block, int number)
        {
            string type = block.Type;
            if (type.Equals("TransferFcn"))
            {
                return CreateTransfer(block, number);
            }
            if (type.Equals("Gain"))
            {
                return CreateGain(block, number);
            }
            if (type.Equals("Sum"))
            {
                return CreateSum(block, number);
            }
            if (type.Equals("Integrator"))
            {
                return CreateIntegr(block, number);
            }
            if (type.Equals("Fcn"))
            {
                return CreateFcn(block, number);
            }
            if (type.Equals("Reference"))
            {
                return CreateReference(block, number);
            }
            if (type.Equals("Derivative"))
            {
                return CreateDerivative(block, number);
            }
            if (!elementary.ContainsKey(type))
            {
                return null;
            }
            string[] s = elementary[type];
            string arg = timeVariable;
            Arrow ar = block.Input.Values.First<Arrow>();
            StringBuilder sb = new StringBuilder();
            sb.Append(ar.VariableName);
            sb.Append(s[0] + arg + s[1]);
            List<string> ls = new List<string>();
            ls.Add(sb.ToString());
            return ls;
        }

        string GetFirstOut(Block block)
        {
            return block.Output.Values.First<Arrow>().VariableName;
        }


        string GetFirstIn(Block block)
        {
            return block.Input.Values.First<Arrow>().VariableName;
        }


        List<string> CreateSum(Block block, int num)
        {
            List<string> l = new List<string>();
            IAttribute a = block;
            string s = a["Inputs"];
            s = s.Substring(1);
            string sb = GetFirstOut(block);
            StringBuilder so = new StringBuilder(sb + " = ");
            for (int i = 0; i < s.Length; i++)
            {
                so.Append(s[i] + block.Input[(i + 1) + ""].VariableName);
            }
            so.Append(";");
            l.Add(so.ToString());
            return l;
        }

        List<string> CreateGain(Block block, int num)
        {
            IAttribute a = block;
            string gain = a["Gain"];
            string expr = TransformExpression(gain);
            expr = Simulink.Parser.Library.SimulinkSubsystem.Replace(block, expr);
            List<string> l = new List<string>();
            string s = GetFirstOut(block) + " = (" + expr + ") * " + GetFirstIn(block) + ";";
            l.Add(s);
            return l;

        }

        List<string> CreateFcn(Block block, int num)
        {
            IAttribute a = block;
            string expr = a["Expr"];
            expr = Simulink.Parser.Library.SimulinkSubsystem.Replace(block, expr);
            expr = TransformExpression(expr);
            List<string> l = new List<string>();
            l.Add("u = " + GetFirstIn(block) + ";");
            l.Add(GetFirstOut(block) + " = " + expr + ";");
            return l;

        }

        IList<string> CreateReference(Block block, int number)
        {
            List<string> l = new List<string>();
            IAttribute a = block;
            string s = GetFirstOut(block);
            string bn = "block_" + number + "_";
            string bnx = bn + "x";
            string bny = bn + "y";
            string bnt = bn + "t";
            List<string> lo = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                lo.Add(block.Input[(i + 1) + ""].VariableName);
            }
            string st = s + " = StaticPerformer.Calculate2D(" +
                lo[0] + ", " + lo[1] + ", " + bnx + ", " + bny + ", " + bnt + ");";
            l.Add(st);

            string[] sxy = new string[] { "x", "y" };
            string[] bnn = new string[] { bnx, bny };
            for (int i = 0; i < 2; i++)
            {
                string si = "double[] " + bnn[i] + " = new double[]\r\n{";
                init.Add(si);
                init.Add(CreateArray(a[sxy[i]]));
                init.Add("};");
            }
            init.Add("double[,] " + bnt + " = new double[,]\r\n{");
            init.Add(CreateDoubleArray(a["t"]));
            init.Add("};");
            return l;
        }


        IList<string> CreateDerivative(Block block, int number)
        {
            List<string> l = new List<string>();
            string inp = GetFirstIn(block);
            string old = inp + "_Old";
            init.Add("double " + old + ";");
            string ou = GetFirstOut(block);
            l.Add("if (time != oldTime)");
            l.Add("{");
            l.Add(ou + " = " + inp + " - " + old + ";");
            l.Add(old + " = " + inp + ";");
            l.Add("}");
            reset.Add(old + " = 0;");
            return l;
        }




        string CreateArray(string s)
        {
            string[] ss = s.Split("[] ".ToCharArray());
            string sa = "";
            for (int i = 0; i < ss.Length; i++)
            {
                string sss = ss[i];
                sa += sss;
                if (sss.Length > 0)
                {
                    sa += ",";
                }
            }
            if (sa[sa.Length - 1] == ',')
            {
                sa = sa.Substring(0, sa.Length - 1);
            }
            return sa;
        }

        string CreateDoubleArray(string s)
        {
            string[] ss = s.Split("[];".ToCharArray());
            string sa = "";
            foreach (string sss in ss)
            {
                if (sss.Length < 2)
                {
                    continue;
                }
                string[] sssa = sss.Split(" ".ToCharArray());
                if (sssa.Length < 3)
                {
                    continue;
                }
                string ssa = "{";
                foreach (string ssssa in sssa)
                {
                    if (ssssa.Length > 0)
                    {
                        ssa += ssssa + ",";
                    }
                }
                if (ssa[ssa.Length - 1] == ',')
                {
                    ssa = ssa.Substring(0, ssa.Length - 1);
                }
                ssa += "}";
                sa += ssa + ",";
            }
            if (sa[sa.Length - 1] == ',')
            {
                sa = sa.Substring(0, sa.Length - 1);
            }
            return sa;
        }


        #endregion



    }
}
