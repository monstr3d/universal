using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xml.Parser.Library;

using Simulink.Parser.Library.Interfaces;
using Simulink.Parser.Library.DiagramElements;

namespace Simulink.CSharp.Library.CodeCreators
{
    partial class CodeCreator
    {
        /// <summary>
        /// Derivation string
        /// </summary>
        public const string derivation = "derivation";

        /// <summary>
        /// State string
        /// </summary>
        public const string state = "state";

        IList<string> CreateTransfer(Block block, int num)
        {
            List<string> l = new List<string>();
            IAttribute a = block;
            string[] nom = StaticExtensionXmlParserLibrary.Parse("[", "]", " ,".ToCharArray(), a["Numerator"]);
            string[] den = StaticExtensionXmlParserLibrary.Parse("[", "]", " ,".ToCharArray(), a["Denominator"]);
            int ord = block.Order;
            string inp = GetFirstIn(block);
            int count = den.Length;
            for (int i = 0; i < count - 2; i++)
            {
                int j = i + ord;
                l.Add(derivation + "[" + j + "] = state[" + (j + 1) + "];");
            }
            string bn = "block_" + num;
            string ss = "double " + bn + " = " + inp;
            StringBuilder sb = new StringBuilder(ss);
            for (int i = 0; i < count - 1; i++)
            {
                sb.Append(" - ((" + den[i] + ") * state[" + (ord + i) + "])");
            }
            sb.Append(";");
            l.Add(sb.ToString());
            l.Add(derivation + "[" + (ord + den.Length - 2) + "] = " + bn + ";");
            sb = new StringBuilder(GetFirstOut(block) + " = ");
            for (int i = 0; i < nom.Length; i++)
            {
                sb.Append("+ ((" + nom[i] + ") * state[" + (ord + i) + "])");
            }
            sb.Append(";");
            l.Add(sb.ToString());
            return l;
        }
    }
}
