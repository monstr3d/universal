using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Simulink.Parser.Library.DiagramElements;

namespace Simulink.CSharp.Library.Interfaces
{
    interface IBlockCode
    {
        IList<string> CreateCode(Block block, Dictionary<string, string> input, Dictionary<string, string> output,
            IList<string[]> intern);

    }
}
