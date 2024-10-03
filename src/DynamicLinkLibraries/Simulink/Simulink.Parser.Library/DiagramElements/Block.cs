using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Simulink.Parser.Library;
using Simulink.Parser.Library.Interfaces;

namespace Simulink.Parser.Library.DiagramElements
{
    /// <summary>
    /// Simulink block proxy
    /// </summary>
    public class Block : IAttribute
    {

        #region Fields

        /// <summary>
        /// Associated element
        /// </summary>
        protected XElement xml;


        private readonly Dictionary<string, BlockType> dict = new Dictionary<string, BlockType>()
        {
            {"Inport", BlockType.Inport},
            {"Outport", BlockType.Outport}
        };

        BlockType blockType;

        string type;

        string name;

        SimulinkSubsystem parent;


        Dictionary<string, Arrow> input = new Dictionary<string, Arrow>();

        Dictionary<string, Arrow> output = new Dictionary<string, Arrow>();

        int order = 0;

        int dim = 0;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="type">Type</param>
        /// <param name="parent">Parent</param>
        protected Block(string name, string type, SimulinkSubsystem parent)
        {
            this.name = name;
            this.type = type;
            this.parent = parent;
            SetBlockType();
        }

         internal Block(XElement element, SimulinkSubsystem parent)
        {
            xml = element;
            name = element.GetAttribute(SimulinkXmlParser.Name);
            type = element.GetAttribute(SimulinkXmlParser.BlockType);
            this.parent = parent;
            SetBlockType();
        }

        #endregion

        #region IAttribute Members

        string IAttribute.this[string key]
        {
            get 
            {
                if (xml.GetAttribute(key) == null)
                {
                    return null;
                }
                return xml.GetAttribute(key);
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// Block name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Block type
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// Block element
        /// </summary>
        public XElement Element
        {
            get
            {
                return xml;
            }
        }

        /// <summary>
        /// Parent system
        /// </summary>
        public SimulinkSubsystem Parent
        {
            get
            {
                return parent;
            }
        }

        /// <summary>
        /// Type of block
        /// </summary>
        public BlockType BlockType
        {
            get
            {
                return blockType;
            }
        }

        /// <summary>
        /// Input arrows
        /// </summary>
        public Dictionary<string, Arrow> Input
        {
            get
            {
                return input;
            }
        }

        /// <summary>
        /// Output arrows
        /// </summary>
        public Dictionary<string, Arrow> Output
        {
            get
            {
                return output;
            }
        }

        /// <summary>
        /// Dictionary of arrows
        /// </summary>
        /// <param name="isInput">The sign</param>
        /// <returns>Input arrows if isInput = true and output arrows otherwise</returns>
        public Dictionary<string, Arrow> this[bool isInput]
        {
            get
            {
                return isInput ? input : output;
 
            }
        }

        /// <summary>
        /// Order of block
        /// </summary>
        public int Order
        {
            get
            {
                return order;
            }
        }

        /// <summary>
        /// Internal dimension
        /// </summary>
        public int Dim
        {
            get
            {
                return dim;
            }
        }

        /// <summary>
        /// Sets orders
        /// </summary>
        /// <param name="blocks">Blocks</param>
        /// <param name="creator">Ctrastion interface</param>
        /// <returns>Global dimension</returns>
        public static int SetOrder(IList<Block> blocks, IBlockCodeCreator creator)
        {
            int ord = 0;
            foreach (Block b in blocks)
            {
                b.order = ord;
                int dim = creator.GetInternalDimension(b);
                b.dim = dim;
                ord += dim;
            }
            return ord;
        }

        #endregion

        #region Private

        void SetBlockType()
        {
            blockType = BlockType.Internal;
            if (dict.ContainsKey(type))
            {
                blockType = dict[type];
            }
        }


        #endregion
    }

    /// <summary>
    /// Types of block
    /// </summary>
    public enum BlockType
    {
        /// <summary>
        /// Internal
        /// </summary>
        Internal,
        /// <summary>
        /// Input port
        /// </summary>
        Inport,
        /// <summary>
        /// Output port
        /// </summary>
        Outport,

        /// <summary>
        /// Subsystem
        /// </summary>
        Subsystem
    }

}
