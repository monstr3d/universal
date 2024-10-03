using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Simulink.Parser.Library.Interfaces;
using Simulink.Parser.Library.DiagramElements;

namespace Simulink.Parser.Library.CodeCreators
{
    public class TrivialBlockInternalCode : IBlockInternalCode
    {
        #region IBlockInternalCode Members

        IList<string> IBlockInternalCode.Create(Block block, int number)
        {
            List<string> l = new List<string>();
            string s = block.Output.Values.First<Arrow>().VariableName + " = " +
                block.Input.Values.First<Arrow>().VariableName + ";";
            l.Add(s);
            return l;
        }

        #endregion
    }
}
