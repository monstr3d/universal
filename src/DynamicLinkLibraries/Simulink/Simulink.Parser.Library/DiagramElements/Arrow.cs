using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simulink.Parser.Library.Interfaces;

namespace Simulink.Parser.Library.DiagramElements
{
    /// <summary>
    /// Arrow
    /// </summary>
    public class Arrow
    {
        #region Fields

        BlockPort source;

        BlockPort target;

        SimulinkSubsystem system;
        
        Block sb;

        Block tb;

        Type varType;

        string variableName;

        #endregion

        #region Ctor

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="system">System</param>
        /// <param name="source">Source</param>
        /// <param name="target">Target</param>
        public Arrow(SimulinkSubsystem system, BlockPort source, BlockPort target)
        {
            this.system = system;
            this.source = source;
            this.target = target;
        }

        #endregion

        #region Members

        /// <summary>
        /// Source
        /// </summary>
        public BlockPort Source
        {
            get
            {
                return source;
            }
        }

        /// <summary>
        /// Target
        /// </summary>
        public BlockPort Target
        {
            get
            {
                return target;
            }
        }
        /// <summary>
        /// Source block
        /// </summary>
        public Block SourceBlock
        {
            get
            {
                return sb;
            }
            set
            {
                sb = value;
            }
        }

        /// <summary>
        /// Target block
        /// </summary>
        public Block TargetBlock
        {
            get
            {
                return tb;
            }
            set
            {
                tb = value;
            }
        }

        /// <summary>
        /// Name of variable
        /// </summary>
        public string VariableName
        {
            get
            {
                return variableName;
            }
            set
            {
                variableName = value;
            }
        }

        /// <summary>
        /// Sets type
        /// </summary>
        /// <param name="creator">Creator</param>
        public void SetType(IBlockCodeCreator creator)
        {
            BlockPort[] bp = new BlockPort[] { source, target };
            Block[] bl = new Block[] { sb, tb };
            for (int i = 0; i < bl.Length; i++)
            {
                try
                {
                    int p = bp[i].PortNumber;
                    varType = creator.GetType(i, bl[i], p);
                    return;
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Type of arrow variable
        /// </summary>
        public Type Type
        {
            get
            {
                return varType;
            }
        }





        #endregion
    }
}
