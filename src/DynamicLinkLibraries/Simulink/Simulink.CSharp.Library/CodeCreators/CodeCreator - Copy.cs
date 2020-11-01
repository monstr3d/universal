using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.CodeDom.Compiler;



using Simulink.Parser.Library;
using Simulink.Parser.Library.Interfaces;
using Simulink.Parser.Library.CodeCreators;
using Simulink.Parser.Library.DiagramElements;
using Simulink.CSharp.Library.Interfaces;

namespace Simulink.CSharp.Library.CodeCreators
{
    /// <summary>
    /// Creator of C# code
    /// </summary>
    public partial class CodeCreator : ICodeCreator, IBlockInternalCode
    {
        #region Fields

        /// <summary>
        /// Compiler
        /// </summary>
        public static readonly CodeDomProvider compiler = CodeDomProvider.CreateProvider("cs");

        /// <summary>
        /// Standard header of class
        /// </summary>
        public const string StandardHeader = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Text;\r\n\r\nusing Simulink.CSharp.Library.Interfaces;\r\nusing Simulink.CSharp.Library;\r\n\r\n";


        const string ops = "+-=*/() ";

        XElement doc;

        SimulinkSystem system;

        SimulinkSubsystem subsystem;

        Block[] blocks;

        string timeVariable = "time";

        int order;

        private Dictionary<string, Type> input = new Dictionary<string, Type>();
        private Dictionary<string, Type> output = new Dictionary<string, Type>();

        private List<string> reset;

        private List<string> init = new List<string>();


        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">Simulink source text</param>
        public CodeCreator(IList<string> text)
        {
            doc = Simulink.Parser.Library.SimulinkXmlParser.Create(text);
            Simulink.Parser.Library.SimulinkXmlParser.TransformFunc(doc);
            system = new SimulinkSystem(doc);
            subsystem = system.Subsystem;
            int k = 0;
            subsystem.Enumerate(ref k);
            subsystem.SetArrowVariables("arrow_");
            List<Block> lb = subsystem.AllBlocks;
            order = Block.SetOrder(lb, new BlockCodeCreator());
            blocks = lb.ToArray();
        }

        #endregion


        #region ICodeCreator Members

        IList<string> ICodeCreator.CreateCode(SimulinkSubsystem system)
        {
            List<string> lcode = new List<string>();
            lcode.Add(StandardHeader);
            List<string> var = CreateVariables(out reset);
            string ss = "namespace Calculation";
            // ss += guid;
            ss += "\r\n{\r\n    public class Calculate : IStateCalculation";
            ss += "\r\n{\r\n";
 
            lcode.Add(ss);
            lcode.Add("        public void Update()\r\n        {\r\n");
            IBlockInternalCode ic = this;
            List<string> l = new List<string>();
            init.Clear();
            for (int i = 0; i < blocks.Length; i++)
            {
                IList<string> c = ic.Create(blocks[i], i);
                if (c == null)
                {
                    continue;
                }
                l.AddRange(c);
            }
            lcode.AddRange(l);
            lcode.Add("oldTime = time;");
            lcode.Add("        }\r\n");
            lcode.AddRange(var);
            List<string> lh;
            List<string> lic;
            List<string> ld = CreateInput(out lh, out lic);
            lcode.AddRange(ld);
            lcode.AddRange(lh);
            List<string> loc;
            ld = CreateOutput(out lh, out loc);
            lcode.AddRange(ld);
            lcode.AddRange(lh);
            List<string> lconsto;
            List<string> lconsti;
            List<string> lconst = CreateConstats(out lconsto, out lconsti);
            lcode.Add("public Calculate()");
            lcode.Add("{");
            lcode.AddRange(lic);
            lcode.AddRange(loc);
            lcode.AddRange(lconsti);
            lcode.Add("}");
            lcode.Add("        public void Reset()\r\n        {\r\n");
            lcode.AddRange(reset);
            lcode.Add("}");
            lcode.AddRange(lconst);
            lcode.AddRange(lconsto);
            lcode.AddRange(init);
            lcode.Add("        }\r\n");
            lcode.Add("        }\r\n");

            return lcode;
        }

        #endregion


        #region IBlockInternalCode Members

        IList<string> IBlockInternalCode.Create(Block block, int number)
        {
            if (block.Type.Equals("Inport") | block.Type.Equals("Outport"))
            {
                return new List<string>();
            }
            IList<string> l = CreateElementary(block, number);
            if (l != null)
            {
                return l;
            }
            return null;
        }

        #endregion

        #region Members

        /// <summary>
        /// The system
        /// </summary>
        public SimulinkSystem SimulinkSystem
        {
            get
            {
                return system;
            }
        }


        List<string> CreateArrowVariables(out List<string> reset)
        {
            IList<Arrow> l = subsystem.AllArrows;
            List<string> var = new List<string>();
            List<string> ini = new List<string>();
            reset = new List<string>();
            foreach (Arrow ar in l)
            {
                string vn = ar.VariableName;
                if (var.Contains(vn))
                {
                    continue;
                }
                Type type = ar.Type;
                var.Add(vn);
                string ss = type + " " + vn + ";";
                ini.Add(ss);
                string sr = vn + " = " + ((type.Equals(typeof(bool))) ? "false" : "0") + ";";
                reset.Add(sr);
            }
            ini.Add("public double[] State");
            ini.Add("{");
            ini.Add("get");
            ini.Add("{");
            ini.Add("return state;");
            ini.Add("}");
            ini.Add("}");
            ini.Add("public double[] Derivation");
            ini.Add("{");
            ini.Add("get");
            ini.Add("{");
            ini.Add("return derivation;");
            ini.Add("}");
            ini.Add("}");
            return ini;
        }

        List<string> CreateVariables(out List<string> reset)
        {
            List<string> l = CreateArrowVariables(out reset);
            l.Add("double[] state = new double[" + order + "];");
            l.Add("double[] derivation = new double[" + order + "];");
            l.Add("double time;");
            l.Add("double oldTime;");
            l.Add("public double Time");
            l.Add("{");
            l.Add("get");
            l.Add("{");
            l.Add("return time;");
            l.Add("}");
            l.Add("set");
            l.Add("{");
            l.Add("time = value;");
            l.Add("}");
            l.Add("}");
            l.Add("double u = 0;");
            string[] cons = subsystem.Constants;
            foreach (string con in cons)
            {
                l.Add("double " + con + " = 0;");
            }
            return l;
        }

        List<string> CreateInput(out List<string> lo, out List<string> lc)
        {
            List<string> l = new List<string>();
            l.Add("public Dictionary<string, SetValue> Input");
            l.Add("{");
            l.Add("get");
            l.Add("{");
            l.Add("return input;");
            l.Add("}");
            l.Add("}");
            l.Add("Dictionary<string, SetValue> input;");
            lo = new List<string>();
            lc = new List<string>();
            lc.Add("input = new Dictionary<string, SetValue>();");
            int k = 0;
            input.Clear();
            foreach (Block b in subsystem.Blocks)
            {
                if (b.BlockType != BlockType.Inport)
                {
                    continue;
                }
                if (k > 0)
                {
                    l.Add(",");
                }
                string fun = "SetBlock_" + k;
                lc.Add("input[\"" + b.Name + "\"] = " + fun + ";");
                ++k;
                lo.Add("void " + fun + "(object o)");
                lo.Add("{");
                Arrow ar = b.Output.Values.First<Arrow>();
                Type t = ar.Type;
                string vn = ar.VariableName;
                input[b.Name] = t;
                string s = vn + " =  (" + t + ")o;";
                lo.Add(s);
                lo.Add("}");
            }
            return l;
        }

        List<string> CreateConstats(out List<string> lo, out List<string> lc)
        {
            List<string> l = new List<string>();
            l.Add("public Dictionary<string, SetValue> Constants");
            l.Add("{");
            l.Add("get");
            l.Add("{");
            l.Add("return constants;");
            l.Add("}");
            l.Add("}");
            l.Add("Dictionary<string, SetValue> constants;");
            lo = new List<string>();
            lc = new List<string>();
            lc.Add("constants = new Dictionary<string, SetValue>();");
            int k = 0;
            string[] con = subsystem.Constants;
            foreach (string c in con)
            {
                string fun = "SetConst_" + k;
                lc.Add("constants[\"" + c + "\"] = " + fun + ";");
                ++k;
                lo.Add("void " + fun + "(object o)");
                lo.Add("{");
                string s = c + "= (double)o;";
                lo.Add(s);
                lo.Add("}");
            }
            return l;
        }

        List<string> CreateOutput(out List<string> lo, out List<string> lc)
        {
            List<string> l = new List<string>();
            l.Add("public Dictionary<string, GetValue> Output");
            l.Add("{");
            l.Add("get");
            l.Add("{");
            l.Add("return output;");
            l.Add("}");
            l.Add("}");
            l.Add("Dictionary<string, GetValue> output;");
            lo = new List<string>();
            lc = new List<string>();
            lc.Add("output = new Dictionary<string, GetValue>();");
            int k = 0;
            output.Clear();
            foreach (Block b in subsystem.Blocks)
            {
                if (b.BlockType != BlockType.Outport)
                {
                    continue;
                }
                if (k > 0)
                {
                    l.Add(",");
                }
                string fun = "GetBlock_" + k;
                lc.Add("output[\"" + b.Name + "\"] = " + fun + ";");
                ++k;
                lo.Add("object " + fun + "()");
                lo.Add("{");
                Arrow ar = b.Input.Values.First<Arrow>();
                Type t = ar.Type;
                string vn = ar.VariableName;
                output[b.Name] = t;
                string s = "return " + vn + ";";
                lo.Add(s);
                lo.Add("}");
            }
            return l;
        }

        string TransformExpression(string s)
        {
            string str = TransformPow(s);
            str = TrnsformPI(str, 0);
            return str;
        }

        string TrnsformPI(string s, int k)
        {
            if (k > s.Length - 1)
            {
                return s;
            }
            for (int i = k; i < s.Length - 1; i++)
            {
                string ss = s.Substring(i, 2);
                if (ss.Equals("pi"))
                {
                    bool left = true;
                    if (i > 0)
                    {
                        if (!ops.Contains(s[i - 1]))
                        {
                            left = false;
                        }
                    }
                    bool right = true;
                    if (i + 2 <= s.Length)
                    {
                        if (!ops.Contains(s[i + 2]))
                        {
                            right = false;
                        }
                    }
                    if (left & right)
                    {
                        string res = s.Substring(0, i) + "Math.PI" + s.Substring(i + 2);
                        return TrnsformPI(res, k);
                    }
                    return TrnsformPI(s, k + 2);
                }
            }
            return s;
        }

        string TransformPow(string s)
        {
            if (!s.Contains('^'))
            {
                return s;
            }
            int k = s.IndexOf('^');
            string s1 = s.Substring(0, k);
            s1 = s1.Trim();
            string[] ss1 = new string[2];
            if (s1[s1.Length - 1] == ')')
            {
                int ks = 1;
                for (int i = s1.Length - 2; i >= 0; i--)
                {
                    char c = s1[i];
                    if (c == ')')
                    {
                        ++ks;
                    }
                    if (c == '(')
                    {
                        --ks;
                    }
                    if (ks == 0)
                    {
                        ss1[0] = s1.Substring(0, i);
                        ss1[1] = s1.Substring(i);
                        break;
                    }
                }
            }
            else
            {
                for (int i = s1.Length - 1; i >= 0; i--)
                {
                    char c = s1[i];
                    if (c == '+' | c == '-' | c == '*' | c == '/')
                    {
                        ss1[0] = s1.Substring(0, i + 1);
                        ss1[1] = s1.Substring(i + 1);
                        break;
                    }
                }
            }
            if (ss1[0] == null)
            {
                ss1[0] = "";
                ss1[1] = s1;
            }
            string s2 = s.Substring(k + 1);
            s2 = s2.Trim();
            string[] ss2 = new string[2];
            if (s2[0] == '(')
            {
                int ks = 1;
                for (int i = 1; i < s2.Length; i++)
                {
                    char c = s2[i];
                    if (c == '(')
                    {
                        ++ks;
                    }
                    if (c == ')')
                    {
                        --ks;
                    }
                    if (ks == 0)
                    {
                        ss2[0] = s2.Substring(0, i);
                        ss2[1] = s2.Substring(i);
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < s2.Length; i++)
                {
                    char c = s2[i];
                    if (c == '+' | c == '-' | c == '*' | c == '/')
                    {
                        ss2[0] = s2.Substring(0, i);
                        ss2[1] = s2.Substring(i);
                        break;
                    }
                }
            }
            if (ss1[0] == null)
            {
                ss1[0] = "";
                ss1[1] = s1;
            }
            if (ss2[1] == null)
            {
                ss2[0] = s2;
                ss2[1] = "";
            }
            return TransformPow(ss1[0] + "Math.Pow(" + ss1[1] + "," + ss2[0] + ")" + ss2[1]);
        }

        #endregion

    }
}
