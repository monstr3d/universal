using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


using FormulaEditor.Symbols;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Creator of symbols from xml element
    /// </summary>
    public interface IXmlSymbolCreator
    {
        /// <summary>
        /// Creates symbol from XmlElement
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The symbol</returns>
        MathSymbol CreateSymbol(XElement element);

        /// <summary>
        /// Creates Xml element from symbol
        /// </summary>
        /// <param name="doc">Document</param>
        /// <param name="symbol">Symbol</param>
        /// <returns>The element</returns>
        XElement CreateElement(MathSymbol symbol);
    }
}
