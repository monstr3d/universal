using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace Xml.Parser.Library
{
    /// <summary>
    /// Static parser operations
    /// </summary>
    public static class StaticExtensionXmlParserLibrary
    {
        private static event Action<Exception> onException = (Exception ex) => { };


        #region Public XML Members

        /// <summary>
        /// Gets child nodes
        /// </summary>
        /// <param name="element">Element</param>
        /// <returns>Child nodes</returns>
        public static IEnumerable<XElement> GetChildNodes(this XElement element)
        {
            IEnumerable<XElement> c = element.Elements();
            return c;
        }

        /// <summary>
        /// Gets elements by tag name
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="tag">Tag</param>
        /// <returns>Elementa</returns>
        public static IEnumerable<XElement> GetElementsByTagName(this XElement element, string tag)
        {
            return element.Elements(XName.Get(tag));
        }

        /// <summary>
        /// Gets attribute
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="name">Name</param>
        /// <returns>Attribute</returns>
        public static string GetAttribute(this System.Xml.Linq.XElement element, string name)
        {
            return element.Attribute(System.Xml.Linq.XName.Get(name)).Value;
        }

        /// <summary>
        /// Creates XElement
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The element</returns>
        public static XElement CreateXElement(string tag)
        {
            return XElement.Parse("<" + tag + "/>");
        }

        /// <summary>
        /// Creates XElement
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <param name="obj">The object</param>
        /// <returns>The element</returns>
        public static XElement CreateXElement(this object obj, string tag)
        {
            XElement e = CreateXElement(tag);
            if (obj is XElement)
            {
                (obj as XElement).Add(e);
            }
            return e;
        }


  

        #endregion


        /// <summary>
        /// Transforms a string to lists of strings
        /// </summary>
        /// <param name="str">Initial string</param>
        /// <returns>Final result (lists of strings)</returns>
        public static IList<string> Transform(string str)
        {
            List<string> text = new List<string>();
            string[] ss = str.Split("\n".ToCharArray());
            text.AddRange(ss);
            return text;
        }

        /// <summary>
        /// Logs exception
        /// </summary>
        /// <param name="ex">The exception</param>
        public static void Log(this Exception ex)
        {
            onException(ex);
        }


        /// <summary>
        /// On exception event
        /// </summary>
        public static event Action<Exception> OnException
        {
            add { onException += value; }
            remove { onException += value; }
        }


        /// <summary>
        /// Gets children Xml elements 
        /// </summary>
        /// <param name="element">Parent</param>
        /// <returns>Children Xml elements</returns>
        public static XElement[] GetChildren(XElement element)
        {
            List<XElement> l = new List<XElement>();
            IEnumerable<XElement> nl = element.GetChildNodes();
            foreach (XElement n in nl)
            {
                    l.Add(n);
            }
            return l.ToArray();
        }

        /// <summary>
        /// Reads list of text from text reader
        /// </summary>
        /// <param name="reader">The text reader</param>
        /// <returns>List of strings</returns>
        public static IList<string> Transform(TextReader reader)
        {
             List<string> text = new List<string>();
             while (true)
             {
                 string s = reader.ReadLine();
                 if (s == null)
                 {
                     break;
                 }
                 text.Add(s);
             }
            return text;
        }
        
        /// <summary>
        /// Transforms file to list of strings
        /// </summary>
        /// <param name="fileName">Filename</param>
        /// <returns>List of strings</returns>
        public static IList<string> TransformFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            IList<string> text = Transform(reader);
            reader.Close();
            return text;
        }

        /// <summary>
        /// Finds next character
        /// </summary>
        /// <param name="text">Lists of strings</param>
        /// <param name="Char">Prototype</param>
        /// <param name="beg">Begin msign</param>
        /// <param name="bRow">Begin row</param>
        /// <param name="bColumn">Brgin colomn</param>
        /// <param name="eRow">End row</param>
        /// <param name="eColumn">End column</param>
        /// <returns>Character</returns>
        public static char? FindNext(IList<string> text, char Char, bool beg, int bRow, int bColumn, out int eRow, out int eColumn)
        {
            eRow = bRow;
            eColumn = bColumn;
            char? c = GetSymbol(text, eRow, eColumn);
            if (c == Char)
            {
                if (beg)
                {
                    return c;
                }
            }
            do
            {
                c = GetNextSymbol(text, ref eRow, ref eColumn);
                if (c == null)
                {
                    return c;
                }
            }
            while (c != Char);
            return c;
        }

        /// <summary>
        /// Finds next string
        /// </summary>
        /// <param name="text">Lists of strings</param>
        /// <param name="String">Prototype</param>
        /// <param name="beg">Begin msign</param>
        /// <param name="bRow">Begin row</param>
        /// <param name="bColumn">Brgin colomn</param>
        /// <param name="eRow">End row</param>
        /// <param name="eColumn">End column</param>
        /// <returns></returns>
        public static string FindNext(IList<string> text, string String, bool beg, int bRow, int bColumn, out int eRow, out int eColumn)
        {
            eRow = bRow;
            eColumn = bColumn;
            string s = GetString(text, eRow, eColumn);
            if (s != null)
            {
                if (s.Contains(String))
                {
                    if (beg)
                    {
                        return s;
                    }
                }
            }
            do
            {
                s = GetNextString(text, ref eRow, ref eColumn);
                if (s == null)
                {
                    return s;
                }
            }
            while (!s.Contains(String));
            return s;
        }


        /// <summary>
        /// Parsing to string array
        /// </summary>
        /// <param name="open">Open clause</param>
        /// <param name="close">Close clause</param>
        /// <param name="sep">Separators</param>
        /// <param name="str">Input string</param>
        /// <returns>Output string array</returns>
        public static string[] Parse(string open, string close, char[] sep, string str)
        {
            string s = str.Replace(open, "");
            s = s.Replace(close, "");
            string[] ss = s.Split(sep);
            List<string> l = new List<string>();
            foreach (string st in ss)
            {
                if (st.Length > 0)
                {
                    l.Add(st);
                }
            }
            return l.ToArray();
        }

        /// <summary>
        /// Parses int array
        /// </summary>
        /// <param name="open">Open clause</param>
        /// <param name="close">Close clause</param>
        /// <param name="sep">Separators</param>
        /// <param name="str">Input string</param>
        /// <returns>Output int array</returns>
        public static int[] ParseInt(string open, string close, char[] sep, string str)
        {
            string[] s = Parse(open, close, sep, str);
            int[] n = new int[s.Length];
            for (int i = 0; i < n.Length; i++)
            {
                try
                {
                    n[i] = Int32.Parse(s[i]);
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                }
            }
            return n;
        }

        /// <summary>
        /// Parsing of double array
        /// </summary>
        /// <param name="open">Open substring</param>
        /// <param name="close">Close substring</param>
        /// <param name="sep">Array of separators</param>
        /// <param name="str">Parsed string</param>
        /// <param name="style">Number stype</param>
        /// <param name="provider">Format provider</param>
        /// <returns>Double array</returns>
        public static double[] ParseDouble(string open, string close, char[] sep, string str, 
            System.Globalization.NumberStyles style, IFormatProvider provider)
        {
            string[] s = Parse(open, close, sep, str);
            double[] d = new double[s.Length];
            for (int i = 0; i < d.Length; i++)
            {
                try
                {
                    d[i] = Double.Parse(s[i], style, provider);
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                }
            }
            return d;
        }


        /// <summary>
        /// Finds next close symbol
        /// </summary>
        /// <param name="text">List of strings</param>
        /// <param name="openChar">Open symbol</param>
        /// <param name="closeChar">Close symbol</param>
        /// <param name="beg">The "begin" sign</param>
        /// <param name="bRow">Rebin row</param>
        /// <param name="bColumn">Begin column</param>
        /// <param name="eRow">End row</param>
        /// <param name="eColumn">End column</param>
        public static void FindNextClose(IList<string> text, char openChar, char closeChar,
            bool beg, int bRow, int bColumn, out int eRow, out int eColumn)
        {
            eRow = bRow;
            eColumn = bColumn;
            char? c = GetSymbol(text, eRow, eColumn);
            int count = 0;
            if (c == openChar)
                if (beg)
                {
                    ++count;
                }
            while (count > 0)
            {
                c = GetNextSymbol(text, ref eRow, ref eColumn);
                if (c == openChar)
                {
                    ++count;
                }
                if (c == closeChar)
                {
                    --count;
                }
            }
        }

        /// <summary>
        /// Finds next close string
        /// </summary>
        /// <param name="text">List of strings</param>
        /// <param name="openString">Open symbol</param>
        /// <param name="closeString">Close symbol</param>
        /// <param name="beg">The "begin" sign</param>
        /// <param name="bRow">Rebin row</param>
        /// <param name="bColumn">Begin column</param>
        /// <param name="eRow">End row</param>
        /// <param name="eColumn">End column</param>
        public static void FindNextClose(IList<string> text, string openString, string closeString,
            bool beg, int bRow, int bColumn, out int eRow, out int eColumn)
        {
            eRow = bRow;
            eColumn = bColumn;
            string s = GetString(text, eRow, eColumn);
            int count = 0;
            if (s.Contains(openString))
            {
                if (beg)
                {
                    ++count;
                    ++eRow;
                }
            }
            while (count > 0)
            {
                eColumn = 0;
                s = GetNextString(text, ref eRow, ref eColumn);
                if (s == null)
                {
                    break;
                }
                if (s.Contains(openString))
                {
                    ++count;
                }
                if (s.Contains(closeString))
                {
                    --count;
                }
            }
        }

        /// <summary>
        /// Gets symbol from list of strings
        /// </summary>
        /// <param name="text">List of strings</param>
        /// <param name="row">Row</param>
        /// <param name="col">Column</param>
        /// <returns>The symbol if exists</returns>
        static char? GetSymbol(IList<string> text, int row, int col)
        {
            if (row >= text.Count)
            {
                return null;
            }
            string s = text[row];
            if (s.Length == 0)
            {
                return null;
            }
            if (s.Length <= col)
            {
                return null;
            }
            return s[col];
        }
        /// <summary>
        /// Gets string from list of strings
        /// </summary>
        /// <param name="text">List of strings</param>
        /// <param name="row">Row</param>
        /// <param name="col">Column</param>
        /// <returns>The symbol if exists</returns>
        static public string GetString(IList<string> text, int row, int col)
        {
            if (row >= text.Count)
            {
                return null;
            }
            string s = text[row];
            return s;
       }


        /// <summary>
        /// Gets next symbol
        /// </summary>
        /// <param name="text">List of strings</param>
        /// <param name="row">Input and output row</param>
        /// <param name="col">Input and output column</param>
        /// <returns>The symbol if exists</returns>
        static char? GetNextSymbol(IList<string> text, ref int row, ref int col)
        {
            if (row >= text.Count)
            {
                return null;
            }
            Next(text, ref row, ref col);
            return GetSymbol(text, row, col);
        }
        /// <summary>
        /// Gets next string
        /// </summary>
        /// <param name="text">List of strings</param>
        /// <param name="row">Input and output row</param>
        /// <param name="col">Input and output column</param>
        /// <returns>The string if exists</returns>
        static public string GetNextString(IList<string> text, ref int row, ref int col)
        {
            ++row;
            if (row >= text.Count)
            {
                return null;
            }
            Next(text, ref row, ref col);
            return GetString(text, row, col);
        }


        internal static void ShowError(this Exception exception, int errorLevel)
        {
        }



        static void Next(IList<string> text, ref int row, ref int col)
        {
            ++col;
            if (text[row].Length > col)
            {
                return;
            }
            col = 0;
            ++row;
            if (row >= text.Count)
            {
                return;
            }
            if (text[row].Length == 0)
            {
                Next(text, ref row, ref col);
            }
        }

        
    }
}
