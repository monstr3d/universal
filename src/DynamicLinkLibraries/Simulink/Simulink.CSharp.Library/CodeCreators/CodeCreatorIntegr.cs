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
        List<string> CreateIntegr(Block block, int num)
        {
           
            IAttribute a = block;
            string ic = a["InitialCondition"];
            string res = "state[" + block.Order + "] = " + 
                Simulink.Parser.Library.SimulinkSubsystem.Replace(block, ic) + ";";
            reset.Add(res);
            string s = derivation + "[" + block.Order + "] = " + GetFirstIn(block) + ";";
            List<string> l = new List<string>();
            l.Add(s);
            return l;

        }
    }
}
