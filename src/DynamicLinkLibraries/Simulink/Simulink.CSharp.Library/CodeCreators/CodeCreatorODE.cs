using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Simulink.Parser.Library.DiagramElements;

namespace Simulink.CSharp.Library.CodeCreators
{
    partial class CodeCreator
    {
        #region Methods

        IList<string> CreateIntegrator(Block block, int number)
        {
            List<string> l = new List<string>();
            StringBuilder sb = new StringBuilder(derivation);
            sb.Append("[");
            sb.Append(number);
            sb.Append("] = ");
            sb.Append(GetFirstIn(block));
            sb.Append(";");
            l.Add(sb.ToString());
            l.Add(GetFirstOut(block) + " = " + "state[" + number + "];");
            ++number;
            return l;
        }

        #endregion
    }
}
