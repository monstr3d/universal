using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simulink.Parser.Library.DiagramElements;

namespace Simulink.Parser.Library.Interfaces
{
    /// <summary>
    /// Creator of code from block
    /// </summary>
    public interface IBlockCodeCreator
    {
        /// <summary>
        /// Gets number of connected block
        /// </summary>
        /// <param name="k">Number of connection</param>
        /// <param name="block">The block</param>
        /// <returns>Connected block</returns>
        int GetNumber(int k, Block block);

        /// <summary>
        /// Get type of connected variable
        /// </summary>
        /// <param name="k">Blok number</param>
        /// <param name="block">Block</param>
        /// <param name="port">Port</param>
        /// <returns>Type of connected variable</returns>
        Type GetType(int k, Block block, int port);
  
        /// <summary>
        /// Get block number
        /// </summary>
        /// <param name="block">The block</param>
        /// <returns>The block number</returns>
        int GetNumber(Block block);

        /// <summary>
        /// Gets type of connected variable
        /// </summary>
        /// <param name="block">The block</param>
        /// <param name="number">The block number</param>
        /// <returns>Type of connected variable</returns>
        Type GetType(Block block, int number);

        /// <summary>
        /// Gets internal dimension
        /// </summary>
        /// <param name="block">The block</param>
        /// <returns>The dimension</returns>
        int GetInternalDimension(Block block);

        /// <summary>
        /// Checks whether the block is output
        /// </summary>
        /// <param name="block">The block</param>
        /// <returns>True if the block is output and false otherwise</returns>
        bool IsOutput(Block block);
    }
}
