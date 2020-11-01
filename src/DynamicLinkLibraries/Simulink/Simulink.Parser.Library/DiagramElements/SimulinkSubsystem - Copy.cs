using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Simulink.Parser.Library.DiagramElements;
using Simulink.Parser.Library.Interfaces;
using Xml.Parser.Library;

namespace Simulink.Parser.Library
{
    /// <summary>
    /// Subsystem block
    /// </summary>
    public class SimulinkSubsystem : Block
    {
        #region Fields

        private List<Arrow> arrows = new List<Arrow>();

        private Dictionary<string, Block> blocks = new Dictionary<string, Block>();
        private Dictionary<Block, string> eblocks = new Dictionary<Block, string>();

        private List<string> lBlocks = new List<string>();
        
        private List<Block> listBlocks = new List<Block>();

        private Dictionary<string, List<Arrow>> inputs = new Dictionary<string, List<Arrow>>();

        private Dictionary<string, List<Arrow>> outputs = new Dictionary<string, List<Arrow>>();

        private Dictionary<string, SimulinkSubsystem> systems =
            new Dictionary<string, SimulinkSubsystem>();

        private Dictionary<SimulinkSubsystem, string> esystems =
            new Dictionary<SimulinkSubsystem, string>();

        private int globalNumber;

        string globalName;

        string constPreffix;

        Dictionary<string, string> systemConst = new Dictionary<string, string>();

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor from element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="system">Parent system</param>
        /// <param name="creator">Creation interface</param>
        public SimulinkSubsystem(XElement element, SimulinkSubsystem system, 
            IBlockCodeCreator creator)
            : base(element, system)
        {
            XElement e = null;
            XElement[] children = StaticExtensionXmlParserLibrary.GetChildren(element);
            foreach (XElement child in children)
            {
                if (child.Name.Equals(SimulinkXmlParser.SystemStr))
                {
                    e = child;
                }
            }
            Create(e);
            if (system == null)
            {
                SetArrows(creator);
            }
            CreateConst();
        }

        /// <summary>
        /// Constructor from Xml element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="system">Parent system</param>
        public SimulinkSubsystem(XElement element, SimulinkSubsystem system)
            : this(element, system, null)
        {
        }

        #endregion

        #region Public

        /// <summary>
        /// Input arrows
        /// </summary>
        public Dictionary<string, List<Arrow>> Inputs
        {
            get
            {
                return inputs;
            }
        }

        /// <summary>
        /// Arrows
        /// </summary>
        public IList<Arrow> Arrows
        {
            get
            {
                return arrows;
            }
        }

        /// <summary>
        /// All arrows
        /// </summary>
        public IList<Arrow> AllArrows
        {
            get
            {
                List<Arrow> l = new List<Arrow>();
                l.AddRange(arrows);
                foreach (SimulinkSubsystem s in systems.Values)
                {
                    IList<Arrow> la = s.AllArrows;
                    l.AddRange(la);
                }
                return l;
            }
        }

        /// <summary>
        /// Blocks
        /// </summary>
        public IList<Block> Blocks
        {
            get
            {
                return listBlocks;
            }
        }

        /// <summary>
        /// Sets arrow variables
        /// </summary>
        /// <param name="preffix">Preffix</param>
        public void SetArrowVariables(string preffix)
        {
            int i = 0;
            Dictionary<Block, Dictionary<string, Arrow>> dic = new Dictionary<Block, Dictionary<string, Arrow>>();
            SetArrowVariables(preffix, ref i, dic);

        }

        /// <summary>
        /// Enumerates variables
        /// </summary>
        /// <param name="number">First variable number in input and last variable number at output</param>
        public void Enumerate(ref int number)
        {
            globalNumber = number;
            globalName = "System_" + number;
            constPreffix = globalName + "_const_";
            ++number;
            foreach (SimulinkSubsystem s in systems.Values)
            {
                s.Enumerate(ref number);
            }
        }

        /// <summary>
        /// Replaces block id by expression
        /// </summary>
        /// <param name="b">The block</param>
        /// <param name="expr">The expression</param>
        /// <returns>Replacement result</returns>
        public static string Replace(Block b, string expr)
        {
            SimulinkSubsystem system = b.Parent;
            string pre = system.constPreffix;
            string so = expr + "";
            foreach (string s in system.systemConst.Keys)
            {
                so = so.Replace(s, pre + s);
            }
            return so;
        }

        /// <summary>
        /// Constants
        /// </summary>
        public string[] Constants
        {
            get
            {
                List<string> l = new List<string>();
                ConstVar(l);
                return l.ToArray();
            }
        }

        /// <summary>
        /// Subsustems
        /// </summary>
        public SimulinkSubsystem[] Systems
        {
            get
            {
                List<string> l = new List<string>(systems.Keys);
                l.Sort();
                List<SimulinkSubsystem> ll = new List<SimulinkSubsystem>();
                foreach (string s in l)
                {
                    ll.Add(systems[s]);
                }
                return ll.ToArray();
            }
        }
 
        #endregion

        #region Internal

        void AddBlock(XElement element)
        {
            string name = SimulinkXmlParser.GetName(element);
            string type = element.GetAttribute(SimulinkXmlParser.BlockType);
            lBlocks.Add(name);
            if (type.Equals(SimulinkXmlParser.SubSystem))
            {
           //     XElement[] children = SimulinkXmlParser.GetChildren(element);
        //        foreach (XElement child in children)
        //        {
      //              if (child.Name.Equals(SimulinkXmlParser.SystemStr))
      //              {
                        SimulinkSubsystem system = new SimulinkSubsystem(element, this, null);
                        listBlocks.Add(system);
                        systems[system.Name] = system;
                        esystems[system] = system.Name;
       //                 return;
      //              }
      //          }
                return;
            }
            Block block = new Block(element, this);
            blocks[name] = block;
            eblocks[block] = name;
            listBlocks.Add(block);

        }

        /// <summary>
        /// All blocks of system
        /// </summary>
        public List<Block> AllBlocks
        {
            get
            {
                List<Block> l = new List<Block>();
                GetAllBlocks(l);
                return l;
            }
        }


        #endregion

        #region Private


        void ConstVar(IList<string> var)
        {
            List<string> l = new List<string>(systemConst.Keys);
            l.Sort();
            foreach (string s in l)
            {
                var.Add(constPreffix + s);
            }
            foreach (SimulinkSubsystem sys in systems.Values)
            {
                sys.ConstVar(var);
            }
        }

        void CreateConst()
        {
           IAttribute a = this;
           string s = a["MaskInitialization"];
           if (s == null)
           {
               return;
           }
           char[] sep = ";".ToCharArray();
           string[] ss = s.Split(';');
           foreach (string item in ss)
           {
               if (!item.Contains("="))
               {
                   continue;
               }
               string[] it = item.Split('=');
               systemConst[it[0].Trim()] = it[1].Trim();
           }
        }

        void GetAllBlocks(List<Block> l)
        {
            foreach (Block b in listBlocks)
            {
                if (b is SimulinkSubsystem)
                {
                    SimulinkSubsystem ss = b as SimulinkSubsystem;
                    ss.GetAllBlocks(l);
                    continue;
                }
                l.Add(b);
            }
        }

        void SetArrowVariables(string preffix, ref int i, Dictionary<Block, Dictionary<string, Arrow>> dic)
        {
            foreach (Arrow ar in arrows)
            {
                Dictionary<string, Arrow> d = null;
                Block bl = ar.SourceBlock;
                string port = ar.Source.Port;
                if (dic.ContainsKey(bl))
                {
                    d = dic[bl];
                }
                else
                {
                    d = new Dictionary<string, Arrow>();
                    dic[bl] = d;
                }
                if (d.ContainsKey(port))
                {
                    ar.VariableName = d[port].VariableName;
                }
                else
                {
                    ar.VariableName = preffix + i;
                    d[port] = ar;
                    ++i;
                }
            }
            foreach (SimulinkSubsystem sys in systems.Values)
            {
                sys.SetArrowVariables(preffix, ref i, dic);
            }

        }

        void Create(XElement element)
        {
            XElement[] children = SimulinkXmlParser.GetChildren(element);
            foreach (XElement e in children)
            {
                string type = e.Name.LocalName;
                if (!type.Equals(SimulinkXmlParser.Block))
                {
                    continue;
                }
                AddBlock(e);
            }
            foreach (XElement e in children)
            {
                string type = e.Name.LocalName;
                if (!type.Equals(SimulinkXmlParser.Line))
                {
                    continue;
                }
                ProcessArrow(e);
            }
        }

   

        private void ProcessArrow(XElement element)
        {
            List<BlockPort> l = new List<BlockPort>();
            for (int i = 0; i < 2; i++)
            {
                string b = element.GetAttribute(SimulinkXmlParser.SourceTarget[i]);
                string p = element.GetAttribute(SimulinkXmlParser.SourceTargetPorts[i]);
                if (b.Length == 0)
                {
                    break;
                }
                BlockPort bp = new BlockPort(b, p);
                l.Add(bp);
            }
            if (l.Count == 2)
            {
                Arrow arrow = new Arrow(this, l[0], l[1]);
                Add(arrow);
                return;
            }
            List<XElement> lch = new List<XElement>();
            GetChildernBranches(element, lch);
            XElement[] children = lch.ToArray();
            foreach (XElement c in children)
            {
                string type = c.Name.LocalName;
                if (!type.Equals(SimulinkXmlParser.Branch))
                {
                    continue;
                }
                string b = c.GetAttribute(SimulinkXmlParser.SourceTarget[1]);
                string p = c.GetAttribute(SimulinkXmlParser.SourceTargetPorts[1]);
                BlockPort bp = new BlockPort(b, p);
                Arrow ar = new Arrow(this, l[0], bp);
                Add(ar);
            }
        }

  
        void GetChildernBranches(XElement element, List<XElement> childern)
        {
            XElement[] ch = SimulinkXmlParser.GetChildren(element);
            if (ch.Length == 0)
            {
                if (element.Name.Equals(SimulinkXmlParser.Branch))
                {
                    childern.Add(element);
                }
                return;
            }
            bool b = true;
            foreach (XElement c in ch)
            {
                string type = c.Name.LocalName;
                if (!type.Equals(SimulinkXmlParser.Branch))
                {
                    continue;
                }
                XElement[] cch = SimulinkXmlParser.GetChildren(c);
                foreach (XElement el in cch)
                {
                    string tt = el.Name.LocalName;
                    if (!tt.Equals(SimulinkXmlParser.Branch))
                    {
                        continue;
                    }
                    b = false;
                    GetChildernBranches(el, childern);
                }
                if (b)
                {
                    childern.Add(c);
                }

            }
       }





        void Add(Arrow arrow)
        {
            arrows.Add(arrow);
            Add(arrow, arrow.Source.Block, outputs);
            Add(arrow, arrow.Target.Block, inputs);
        }

        void Add(Arrow arrow, string name, Dictionary<string, List<Arrow>> dictionary)
        {
            List<Arrow> list = null;
            if (dictionary.ContainsKey(name))
            {
                list = dictionary[name];
            }
            else
            {
                list = new List<Arrow>();
                dictionary[name] = list;
            }
            list.Add(arrow);
        }

        void SetArrows(IBlockCodeCreator codeCreator)
        {
            List<Arrow> inter = new List<Arrow>();
            SetArrows(inter);

            SetInterop(inter);
            IList<Arrow> arrs = AllArrows;
            if (codeCreator == null)
            {
                return;
            }
            foreach (Arrow ar in arrs)
            {
                ar.SetType(codeCreator);
            }
        }

        void SetArrows(List<Arrow> inter)
        {
            foreach (SimulinkSubsystem system in systems.Values)
            {
                system.SetArrows(inter);
            }
            foreach (Arrow ar in arrows)
            {
                Block[] blocks  = new Block[] {GetBlock(ar.Source.Block), GetBlock(ar.Target.Block)};
                if ((blocks[0] is SimulinkSubsystem) | (blocks[1] is SimulinkSubsystem))
                {
                    inter.Add(ar);
                }
                Block s = blocks[0];
                Block t = blocks[1];
                ar.SourceBlock = s;
                s.Output[ar.Source.Port] = ar;
                ar.TargetBlock = t;
                t.Input[ar.Target.Port] = ar;
            }
        }

        SimulinkSubsystem Root
        {
            get
            {
                SimulinkSubsystem s = this;
                SimulinkSubsystem p = s.Parent;
                if (p == null)
                {
                    return s;
                }
                return p.Root;
            }
        }

        Block GetBlock(string name)
        {
            if (blocks.ContainsKey(name))
            {
                return blocks[name];
            }
            SimulinkSubsystem r = Root;
            return GetBlock(r, name);
        }

        SimulinkSubsystem GetSystem(string name)
        {
            SimulinkSubsystem r = Root;
            return GetSystem(r, name);
        }

        static SimulinkSubsystem GetSystem(SimulinkSubsystem system, string name)
        {

            if (system.systems.ContainsKey(name))
            {
                return system.systems[name];
            }
            foreach (SimulinkSubsystem sy in system.systems.Values)
            {
                SimulinkSubsystem b = GetSystem(sy, name);
                if (b != null)
                {
                    return b;
                }
            }
            return null;
        }
  
           

        static Block GetBlock(SimulinkSubsystem system, string name)
        {
            SimulinkSubsystem sys = GetSystem(system, name);
            if (sys != null)
            {
                return sys;
            }
            if (system.blocks.ContainsKey(name))
            {
                return system.blocks[name];
            }
            foreach (SimulinkSubsystem sy in system.systems.Values)
            {
                Block b = GetBlock(sy, name);
                if (b != null)
                {
                    return b;
                }
            }
            return null;
            /*char[] sep = "\\\n".ToCharArray();
            string[] s = name.Split(sep);
            /*SimulinkSystem system = this;
            Dictionary<string, SimulinkSystem> d = null;
            for (int i = 0; i < s.Length - 1; i++)
            {
                d = system.systems;
                string key = s[i];
                if (d.ContainsKey(key))
                {
                    system = d[key];
                }
            }
            if (system.blocks.ContainsKey(s[s.Length - 1]))
            {
                return system.blocks[s[s.Length - 1]];
            }
            return null;*/
        }


        static void SetInterop(List<Arrow> inter)
        {
            foreach (Arrow ar in inter)
            {
                Block[] bl = new Block[] { ar.SourceBlock, ar.TargetBlock };
                BlockPort[] bp = new BlockPort[] { ar.Source, ar.Target };
                for (int i = 0; i < bl.Length; i++)
                {
                    bool inp = (i == 0);
                    Block c = bl[i];
                    if (c is SimulinkSubsystem)
                    {
                        SimulinkSubsystem ss = c as SimulinkSubsystem;
                        Block br = GetIOBlock(ss, (1 - i), bp[i].Port + "");
                        if (br == null)
                        {
                            continue;
                        }
                        if (inp)
                        {
                            ar.TargetBlock = br;
                            br.Input[ar.Target.Port] = ar;
                        }
                        else
                        {
                            ar.SourceBlock = br;
                            br.Output[ar.Source.Port] = ar;
                        }
                    }
                }

            }
        }

        static Block GetIOBlock(SimulinkSubsystem system, int num, string port)
        {
            foreach (Block bl in system.blocks.Values)
            {
                if (!bl.Type.Equals(SimulinkXmlParser.IOPorts[num]))
                {
                    continue;
                }
                IAttribute a = bl;
                if (a[SimulinkXmlParser.Port].Equals(port))
                {
                    return bl;
                }
            }
            return null;
        }




        #endregion
    }
}
