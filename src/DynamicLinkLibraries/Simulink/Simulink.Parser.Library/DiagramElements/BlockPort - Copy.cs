using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulink.Parser.Library.DiagramElements
{
    /// <summary>
    /// Blocks and blocks
    /// </summary>
    public class BlockPort
    {
        #region Fields

        string block;

        string port;

        int portNumber =- 1;

        #endregion


        #region Ctor

        /// <summary>
        /// Construcor
        /// </summary>
        /// <param name="block">Block</param>
        /// <param name="port">Port</param>
        public BlockPort(string block, string port)
        {
            this.block = block;
            try
            {
                this.port = port;
                portNumber = Int32.Parse(port);
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Overriden
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return block.GetHashCode() + port.GetHashCode();
        }

        /// <summary>
        /// Overriden
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns>True if equal and false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (obj is BlockPort)
            {
                BlockPort bp = obj as BlockPort;
                return block.Equals(bp.block) & (port.Equals(bp.port));
            }
            return false;
        }

        #endregion

        #region Own Members

        /// <summary>
        /// Block
        /// </summary>
        public string Block
        {
            get
            {
                return block;
            }
        }

        /// <summary>
        /// Port
        /// </summary>
        public string Port
        {
            get
            {
                return port;
            }
        }

        /// <summary>
        /// Number of port
        /// </summary>
        public int PortNumber
        {
            get
            {
              return  portNumber;
            }
        }

        #endregion
    }
}
