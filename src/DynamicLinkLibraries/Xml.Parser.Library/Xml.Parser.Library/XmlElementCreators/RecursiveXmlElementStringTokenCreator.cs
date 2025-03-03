using System;
using System.Collections.Generic;
using System.Xml.Linq;


using Xml.Parser.Library.Interfaces;

using ErrorHandler;

namespace Xml.Parser.Library.XmlElementCreators
{
    public class RecursiveXmlElementStringTokenCreator : RecursiveXmlElementCreator
    {
        #region Fields

        protected string openString;

        protected string closeString;

        #endregion

        #region Ctor

        protected RecursiveXmlElementStringTokenCreator(string openString, string closeString)
        {
            this.openString = openString;
            this.closeString = closeString;
        }


        #endregion

        #region Overriden Members

        protected override void FindNext(IList<string> text, int bRow, int bColumn, out int eRow, out int eColumn)
        {
            int k = bRow;
            int n = 0;
            int cl = bColumn;
            for (int i = bRow; i < text.Count; i++)
            {
                string s = text[i];
                if (s.Contains(openString))
                {
                    ++n;
                }
                if (s.Contains(closeString))
                {
                    --n;
                }
                if (n == 0)
                {
                    eRow = i;
                    eColumn = s.IndexOf(closeString);
                    if (eColumn < 0)
                    {
                        eColumn = 0;
                    }
                    return;
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
        protected override XElement CreateInternal(IList<string> text, int bRow, int bColumn, int eRow, int eColumn)
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
                string s = StaticExtensionXmlParserLibrary.FindNext(text, openString, false, bbRow, bbColumn, out eeRow, out eeColumn);
                if (s == null)
                {
                    return element;
                }
                if (eeRow >= eRow)
                {
                    break;
                }
                bbRow = eeRow;
                bbColumn = eeColumn;
                FindNextClose(text, openString, closeString, true, bbRow, bbColumn, out eeRow, out eeColumn);
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

        /// <summary>
        /// Finds next close string
        /// </summary>
        /// <param name="text">List of strings</param>
        /// <param name="openString">Open string</param>
        /// <param name="closeString">Close string</param>
        /// <param name="beg">The "begin" sign</param>
        /// <param name="bRow">Rebin row</param>
        /// <param name="bColumn">Begin column</param>
        /// <param name="eRow">End row</param>
        /// <param name="eColumn">End column</param>
        protected virtual void FindNextClose(IList<string> text, string openString, string closeString,
            bool beg, int bRow, int bColumn, out int eRow, out int eColumn)
        {
            StaticExtensionXmlParserLibrary.FindNextClose(text, openString, closeString, true, bRow, bColumn, out eRow, out eColumn);
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
        protected override XElement[] CreateElements(IList<string> text, int bRow, int bColumn, int eRow, int eColumn)
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
                    StaticExtensionXmlParserLibrary.FindNext(text, openString, true, brf, bcf, out bb, out bc);
                }
                catch (Exception ex)
                {
                    ex.HandleException(10); 
                    break;
                }
            }
            return l.ToArray();
        }


        #endregion
    }
}
