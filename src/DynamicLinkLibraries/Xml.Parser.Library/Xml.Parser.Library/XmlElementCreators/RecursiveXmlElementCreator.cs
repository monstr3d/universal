using System;
using System.Collections.Generic;
using System.Xml.Linq;

using Xml.Parser.Library.Interfaces;

using ErrorHandler;



namespace Xml.Parser.Library.XmlElementCreators
{
    /// <summary>
    /// Recursive Xml Parser
    /// </summary>
    public class RecursiveXmlElementCreator : IXmlElementCreator
    {

        #region Fields

        /// <summary>
        /// Open bracket symbol
        /// </summary>
        protected char openSymbol;

        /// <summary>
        /// Open bracket symbol
        /// </summary>
        protected char closeSymbol;

        /// <summary>
        /// Prototype
        /// </summary>
        protected IXmlElementCreator creator;

        /// <summary>
        /// This creator
        /// </summary>
        protected IXmlElementCreator This;

        /// <summary>
        /// Dictionary of elements
        /// </summary>
        protected Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

        /// <summary>
        /// End row of text
        /// </summary>
        protected int endRow = 0;

        /// <summary>
        /// End column of texts
        /// </summary>
        protected int endColumn = 0;

        /// <summary>
        /// String with comment
        /// </summary>
        protected string commentString;

         #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected RecursiveXmlElementCreator()
        {
            This = this;
        }

        #endregion

        #region IXmlElementCreator Members

        XElement IXmlElementCreator.Create(IList<string> text, int bRow, int bColumn, int eRow, int eColumn)
        {
            return CreateInternal(text, bRow, bColumn, eRow, eColumn);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Creates Xml Element from strings
        /// </summary>
        /// <param name="text">The strings</param>
        /// <param name="bRow">The begin row</param>
        /// <param name="bColumn">The begin column</param>
        /// <param name="eRow">The end row</param>
        /// <param name="eColumn">The end column</param>
        /// <returns>Created Xml Element</returns>
        public XElement[] Create(IList<string> text, int bRow, int bColumn, int eRow, int eColumn)
        {
            return CreateElements(text, bRow, bColumn, eRow, eColumn);
        }

 
        #endregion

        #region Protected Members

        /// <summary>
        /// Creates Xml Element from strings
        /// </summary>
        /// <param name="text">The strings</param>
        /// <param name="bRow">The begin row</param>
        /// <param name="bColumn">The begin column</param>
        /// <param name="eRow">The end row</param>
        /// <param name="eColumn">The end column</param>
        /// <returns>Created Xml Element</returns>
        protected virtual XElement[] CreateElements(IList<string> text, int bRow, int bColumn, int eRow, int eColumn)
        {
            int bb = bRow;
            int bc = bColumn;
            int brf;
            int bcf;
            IXmlElementCreator creator = this;
            List<XElement> l = new List<XElement>();
            while (true)
            {
                try
                {
                    FindNext(text, bb, bc, out brf, out bcf);
                    XElement e = creator.Create(text, bb, bc, brf, bcf);
                    if (e == null)
                    {
                        break;
                    }
                    l.Add(e);
                    StaticExtensionXmlParserLibrary.FindNext(text, openSymbol, true, brf, bcf, out bb, out bc);
                }
                catch (Exception ex)
                {
                    ex.HandleException(10);
                    break;
                }
            }
            return l.ToArray();
        }


        protected virtual void FindNext(IList<string> text, int bRow, int bColumn, out int eRow, out int eColumn)
        {
            int k = bRow;
            int n = 0;
            int cl = bColumn;
            for (int i = bRow; i < text.Count; i++)
            {
                string s = text[i];
                for (int j = cl; j < s.Length; j++)
                {
                    char c = s[cl];
                    if (c == openSymbol)
                    {
                        ++n;
                    }
                    if (c == closeSymbol)
                    {
                        --n;
                    }
                    if (n == 0)
                    {
                        eRow = i;
                        eColumn = j;
                        return;
                    }
                }
                cl = 0;

            }
            eRow = -1;
            eColumn = -1;
        }


        /// <summary>
        /// Creates Xml Element from strings
        /// </summary>
        /// <param name="text">The strings</param>
        /// <param name="bRow">The begin row</param>
        /// <param name="bColumn">The begin column</param>
        /// <param name="eRow">The end row</param>
        /// <param name="eColumn">The end column</param>
        /// <returns>Created Xml Element</returns>
        protected virtual XElement CreateInternal(IList<string> text, int bRow, int bColumn, int eRow, int eColumn)
        {
            List<int> l = null;
            if (dic.ContainsKey(bRow))
            {
                l = dic[bRow];
            }
            else
            {
                l = new List<int>();
                dic[bRow] = l;
            }
            if (l.Contains(eRow))
            {
                return null;
            }
            l.Add(eRow);
            int bbRow = bRow;
            int bbColumn = bColumn;
            int eeRow;
            int eeColumn;
            XElement element = creator.Create(text, bRow, bColumn, eRow, eColumn);
            if (element == null)
            {
                return null;
            }
            while (true)
            {
                char? c = StaticExtensionXmlParserLibrary.FindNext(text, openSymbol, false, bbRow, bbColumn, out eeRow, out eeColumn);
                if (c == null)
                {
                    return element;
                }
                if (eeRow >= eRow)
                {
                    break;
                }
                if (eeRow == eRow)
                {
                    if (eeColumn >= eColumn)
                    {
                        break;
                    }
                }
                bbRow = eeRow;
                bbColumn = eeColumn;
                StaticExtensionXmlParserLibrary.FindNextClose(text, openSymbol, closeSymbol, true, bbRow, bbColumn, out eeRow, out eeColumn);
                XElement e = This.Create(text, bbRow, bbColumn, eeRow, eeColumn);
                if (e != null)
                {
                    element.Add(e);
                }
                bbRow = eeRow;
                bbColumn = eeColumn;
                endRow = eeRow;
                endColumn = eeColumn;
            }
            return element;
        }



        #endregion

    }
}
