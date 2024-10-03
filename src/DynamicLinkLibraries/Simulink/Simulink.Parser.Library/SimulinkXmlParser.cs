using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;



using Xml.Parser.Library.XmlElementCreators;
using Xml.Parser.Library.Interfaces;
using Xml.Parser.Library;



namespace Simulink.Parser.Library
{
    /// <summary>
    /// Simulink parser
    /// </summary>
    public class SimulinkXmlParser : RecursiveXmlElementCreator
    {
        #region Fields

        private static readonly char[] split = " \t".ToCharArray();

        /// <summary>
        /// Source, target block strings
        /// </summary>
        public static readonly string[] SourceTarget = new string[]
        {
            "SrcBlock", "DstBlock"
        };


        /// <summary>
        /// Source, target port strings
        /// </summary>
        public static readonly string[] SourceTargetPorts = new string[]
        {
            "SrcPort", "DstPort"
        };

        /// <summary>
        /// Inport, outport strings
        /// </summary>
        public static readonly string[] IOPorts = new string[]
        {
            "Inport", "Outport"
        };

        /// <summary>
        /// Port string
        /// </summary>
        public const string Port = "Port";

        /// <summary>
        /// Block type string
        /// </summary>
        public const string BlockType = "BlockType";

        /// <summary>
        /// Subsystem string
        /// </summary>
        public const string SubSystem = "SubSystem";

        /// <summary>
        /// Step string
        /// </summary>
        public const string Step = "Step";

        /// <summary>
        /// Gian string
        /// </summary>
        public const string Gain = "Gain";

        /// <summary>
        /// Transfer function string
        /// </summary>
        public const string TransferFcn = "TransferFcn";

        /// <summary>
        /// System sting
        /// </summary>
        public const string SystemStr = "System";

        /// <summary>
        /// Sin string
        /// </summary>
        public const string SinStr = "Sin";

        /// <summary>
        /// Fraction strings
        /// </summary>
        public static readonly string[] Fraction = new string[] { "Numerator", "Denominator" };

        /// <summary>
        /// Fraction attribute strings
        /// </summary>
        public static readonly string[] FractionAttr = new string[] { "n", "d" };

        /// <summary>
        /// Block string
        /// </summary>
        public const string Block = "Block";

        /// <summary>
        /// Line string
        /// </summary>
        public const string Line = "Line";

        /// <summary>
        /// Branch string
        /// </summary>
        public const string Branch = "Branch";

        /// <summary>
        /// Types of blocks
        /// </summary>
        public static readonly string[] BlockTypes = new string[]
        {
            "Step", "Gain", "TransferFcn"
        };

        /// <summary>
        /// Name string
        /// </summary>
        public const string Name = "Name";

        /// <summary>
        /// off string
        /// </summary>
        public const string off = "off";

        //private SimulinkSubsystem system;

        XElement doc;

        #endregion

        #region Ctor

        private SimulinkXmlParser(XElement doc)
        {
            this.doc = doc;
            creator = new InternalParser(doc);
            openSymbol = '{';
            closeSymbol = '}';
        }

        #endregion

        #region Members

        /// <summary>
        /// Gets name of Xml element
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The name</returns>
        public static string GetName(XElement element)
        {
            return element.GetAttribute(Name);
        }

        /// <summary>
        /// Gets coordinates of points from Xml element
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>Coordinates of points</returns>
        public static int[][] GetPoints(XElement element)
        {
            try
            {
                string s = element.GetAttribute("Points");
                s = s.Replace("[", "");
                s = s.Replace("]", "");
                string[] ss = s.Split(";".ToCharArray());
                int[][] n = new int[ss.Length][];
                for (int i = 0; i < ss.Length; i++)
                {
                    string[] sss = ss[i].Split(",".ToCharArray());
                    int[] nn = new int[sss.Length];
                    n[i] = nn;
                    for (int j = 0; j < nn.Length; j++)
                    {
                        nn[j] = Int32.Parse(sss[j]);
                    }
                }
                return n;
            }
            catch (Exception)
            {
            }
            return null;
        }

        /// <summary>
        /// Gets position from Xml element
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>Coordinates of position</returns>
        public static int[] GetPosition(XElement element)
        {
            string s = element.GetAttribute("Position");
            return ParseInt(s);
        }

        /// <summary>
        /// Parses int array from string
        /// </summary>
        /// <param name="s">The string</param>
        /// <returns>The array</returns>
        public static int[] ParseInt(string s)
        {
            return StaticExtensionXmlParserLibrary.ParseInt("[", "]", " ,".ToCharArray(), s);
        }


        /// <summary>
        /// Parses double array from string
        /// </summary>
        /// <param name="s">The string</param>
        /// <returns>The array</returns>
        public static double[] ParseDouble(string s)
        {
            //IFormatProvider
            return StaticExtensionXmlParserLibrary.ParseDouble("[", "]", " ,".ToCharArray(), s, System.Globalization.NumberStyles.Float,  
                System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
        }

        /// <summary>
        /// Parses string array from string
        /// </summary>
        /// <param name="s">The string</param>
        /// <returns>The array</returns>
        static public string[] ParseString(string s)
        {
            return StaticExtensionXmlParserLibrary.Parse("[", "]", " ,".ToCharArray(), s);
        }

        /// <summary>
        /// Gets type of block
        /// </summary>
        /// <param name="element">Element of block</param>
        /// <returns>Type of block</returns>
        public static string GetBlockType(XElement element)
        {
            return element.GetAttribute(BlockType);
        }

        /// <summary>
        /// Creates document from list of strings
        /// </summary>
        /// <param name="text">List of strings</param>
        /// <returns>The document</returns>
        public static XElement Create(IList<string> text)
        {
            XElement doc = XElement.Parse("<Root/>");

            int nr = text.Count - 1;
            int nc = text[nr].Length;
            --nc;
            int eRow;
            int eColumn;

            SimulinkXmlParser parser = new SimulinkXmlParser(doc);
            IXmlElementCreator creator = parser;
            StaticExtensionXmlParserLibrary.FindNext(text, '{', false, 0, 0, out eRow, out eColumn);
            XElement[] elements = parser.Create(text, eRow, eColumn, nr, nc);
            foreach (XElement e in elements)
            {
                doc.Add(e);
            }
            return parser.doc;
        }

        /// <summary>
        /// Transforms "transformation functions" of document
        /// </summary>
        /// <param name="doc">The document</param>
        public static void TransformFunc(XElement doc)
        {
            IEnumerable<XElement> nl = doc.GetElementsByTagName(Block);
            foreach (XElement e in nl)
            {
                if (!e.GetAttribute(BlockType).Equals(TransferFcn))
                {
                    continue;
                }
                for (int i = 0; i < Fraction.Length; i++)
                {
                    string s = e.GetAttribute(Fraction[i]);
                    string sa = FractionAttr[i];
                    double[] d = ParseDouble(s);
                    for (int j = 0; j < d.Length; j++)
                    {
                        int k = d.Length - j - 1;
                        string sn = sa + k;
                        e.SetAttributeValue(sn, d[j] + "");
                    }
 
                }
            }
        }

        /// <summary>
        /// Gets degerees of transformation functions
        /// </summary>
        /// <param name="element">The transformation function element</param>
        /// <returns>Array of nominator denominator</returns>
        public static int[] TransformFuncDegree(XElement element)
        {
            int[] k = new int[2];
            for (int i = 0; i < Fraction.Length; i++)
            {
                string s = element.GetAttribute(Fraction[i]);
                string sa = FractionAttr[i];
                double[] d = ParseDouble(s);
                k[i] = d.Length;
            }
            return k;
        }

        /// <summary>
        /// Gets children of Xml element
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The children</returns>
        public static XElement[] GetChildren(XElement element)
        {
            return StaticExtensionXmlParserLibrary.GetChildren(element);
        }


        

        #endregion

        #region Internal Parser class

        class InternalParser : IXmlElementCreator
        {
            #region Fields

            XElement doc;
            private static readonly char[] split = " \t".ToCharArray();

            #endregion

            #region Ctor

            internal InternalParser(XElement doc)
            {
                this.doc = doc;
            }

            #endregion

            #region IXmlElementCreator Members

            XElement IXmlElementCreator.Create(IList<string> text, int bRow, int bColumn, int eRow, int eColumn)
            {
                string s = text[bRow];
                string[] ss = s.Split(split);
                string tn = "";
                for (int kn = 0; kn < ss.Length; kn++)
                {
                    tn = ss[kn];
                    if (tn.Length > 0)
                    {
                        break;
                    }
                }
                if (tn.Contains("\""))
                {
                    return null;
                }
                XElement element = doc.CreateXElement(tn);
                int count = 0;
                for (int i = bRow + 1; i < eRow; i++)
                {
                    s = text[i];
                    if (s.Length == 0)
                    {
                        continue;
                    }
                    if (s[0] == '#')
                    {
                        continue;
                    }
                    if (s.Contains("{"))
                    {
                        ++count;
                    }
                    if (s.Contains("}"))
                    {
                        --count;
                        continue;
                    }
                    if (count > 0)
                    {
                        continue;
                    }
                    ss = s.Split(split);
                    int k = 0;
                    string sn = "";
                    do
                    {
                        sn = ss[k];
                        ++k;
                    }
                    while (sn.Length == 0);
                    ++k;
                    string sv = "";
                    for (; k < ss.Length; k++)
                    {
                        string sc = ss[k];
                        if (sc.Length > 0)
                        {
                            if (sv.Length > 0)
                            {
                                sv += " ";
                            }
                            sv += sc;
                        }
                    }
                    sv = sv.Replace("\"", "");
                    try
                    {
                        element.SetAttributeValue(sn, sv);
                    }
                    catch (Exception)
                    {
                    }
                }
                return element;
            }

            #endregion

        }

        #endregion
    }
}
