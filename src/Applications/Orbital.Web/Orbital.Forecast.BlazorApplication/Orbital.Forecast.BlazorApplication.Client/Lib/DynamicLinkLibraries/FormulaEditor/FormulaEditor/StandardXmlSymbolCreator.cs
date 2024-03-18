using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Standard creator of math symblos from XML
    /// </summary>
    public class StandardXmlSymbolCreator : IXmlSymbolCreator
    {
        static readonly string[] symb =
        {
            "SimpleSymbol",
            "BinaryFunctionSymbol", 
            "TernaryFunctionSymbol",
            "BinarySymbol",
            "BracketsSymbol",
            "DateTimeSymbol",
            "FieldSymbol",
            "FractionSymbol",
            "RootSymbol",
            "SeriesSymbol",
            "SubscriptedSymbol",
            "AbsSymbol"

       };
   

        #region IXmlSymbolCreator Members

        MathSymbol IXmlSymbolCreator.CreateSymbol(XElement element)
        {
            string type = element.GetAttribute("type");
            MathSymbol s = CreateSymbol(type);
            s.LoadAttributes(element);
            return s;
        }

        XElement IXmlSymbolCreator.CreateElement(MathSymbol symbol)
        {
            XElement e = this.CreateXElement("S");
            symbol.CreateAttributes(e);
            return e;
        }

        #endregion

        #region Specific Members

        MathSymbol CreateSymbol(string type)
        {
            int i = GetSymbolNumber(type);
            switch (i)
            {
                case 0:
                    return new SimpleSymbol('0');
                case 1:
                    return new BinaryFunctionSymbol('0', "0");
                case 2:
                    return new TernaryFunctionSymbol('0', "0");
                case 3:
                    return new BinarySymbol('0');
                case 4:
                    return new BracketsSymbol();
                case 5:
                    return new DateTimeSymbol();
                case 6:
                    return new FieldSymbol("");
                case 7:
                    return new FractionSymbol();
                case 8:
                    return new RootSymbol();
                case 9:
                    return new SeriesSymbol(0);
                case 10:
                    return new SubscriptedSymbol("", "");
                case 11:
                    return new AbsSymbol();
                default:
                    break;
            }
            return null;
        }

        int GetSymbolNumber(string type)
        {
            for (int i = 0; i < symb.Length; i++)
            {
                string s = symb[i];
                if (("FormulaEditor." + s).Equals(type) | ("FormulaEditor.Symbols." + s).Equals(type))
                {
                    return i;
                }
            }
            return -1;
        }

        #endregion

    }
}
