using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Simulink.Parser.Library.Interfaces;
using Simulink.Parser.Library.DiagramElements;

namespace Simulink.Parser.Library.CodeCreators
{
    /// <summary>
    /// Creator of code from Simulink blocks
    /// </summary>
    public class BlockCodeCreator : IBlockCodeCreator
    {
        #region Fields

        static private readonly List<string> Outputs = new List<string>()
       {
           "Scope"
       };

        #endregion

        #region IBlockCodeCreator Members

        int IBlockCodeCreator.GetNumber(int k, Block block)
        {
            return 1;
        }

        Type IBlockCodeCreator.GetType(int k, Block block, int port)
        {
            return typeof(double);
        }

        int IBlockCodeCreator.GetNumber(Block block)
        {
            return 0;
        }

        Type IBlockCodeCreator.GetType(Block block, int number)
        {
            return typeof(double);
        }

        int IBlockCodeCreator.GetInternalDimension(Block block)
        {
            if (block.Type.Equals("TransferFcn"))
            {
                int[] k = SimulinkXmlParser.TransformFuncDegree(block.Element);
                return k[1] - 1;
            }
            if (block.Type.Equals("Integrator"))
            {
                return 1;
            }
            return 0;
        }

        bool IBlockCodeCreator.IsOutput(Block block)
        {
            return Outputs.Contains(block.Type);
        }

        #endregion
    }
}
