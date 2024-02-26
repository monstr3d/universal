using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Linq;

namespace FormulaEditor.Symbols
{
    /// <summary>
    /// Subscripted index
    /// </summary>
    public class SubscriptedSymbol : SimpleSymbol
    {
        /// <summary>
        /// Subscript
        /// </summary>
        protected string sub;

        /// <summary>
        /// Pair
        /// </summary>
        protected StringPair pair;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="s">String</param>
        /// <param name="sub">Subsript</param>
        public SubscriptedSymbol(string s, string sub)
            : base('f', (int)FormulaConstants.Series, true, s)
        {
            this.sub = sub;
            pair = new StringPair(s, sub);
        }


        /// <summary>
        /// Creates attributes for Xml element
        /// </summary>
        /// <param name="doc">The element document</param>
        /// <param name="e">The element</param>
        public override void CreateAttributes(XElement e)
        {
            base.CreateAttributes(e);
            e.SetAttributeValue("Sub", sub);
        }

        /// <summary>
        /// Loads attributes from Xml element
        /// </summary>
        /// <param name="e">The element</param>
        public override void LoadAttributes(XElement e)
        {
            base.LoadAttributes(e);
            sub = e.GetAttribute("Sub");
        }

        /// <summary>
        /// Sets this symbol to formula
        /// </summary>
        /// <param name="formula">The formula to set</param>
        public override void SetToFormula(MathFormula formula)
        {

        }

        /// <summary>
        /// The symbol pair
        /// </summary>
        public StringPair Pair
        {
            get
            {
                return pair;
            }
        }


        /// <summary>
        /// The Interfaces.ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
        {
            return new SubscriptedSymbol(s, sub);
        }

    }

    /// <summary>
    /// Pair of strings
    /// </summary>
    public class StringPair
    {
        /// <summary>
        /// First string
        /// </summary>
        string s1;

        /// <summary>
        /// Second string
        /// </summary>
        string s2;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="s1">First string</param>
        /// <param name="s2">Second string</param>
        public StringPair(string s1, string s2)
        {
            this.s1 = s1;
            this.s2 = s2;
        }

        /// <summary>
        /// Overriden function
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return s1.GetHashCode() * s2.GetHashCode();
        }

        /// <summary>
        /// Overriden equals
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is StringPair)
            {
                StringPair p = obj as StringPair;
                return (s1.Equals(p.s1) & s2.Equals(p.s2));
            }
            return false;
        }

        /// <summary>
        /// First string
        /// </summary>
        public string First
        {
            get
            {
                return s1;
            }
        }


        /// <summary>
        /// Second string
        /// </summary>
        public string Second
        {
            get
            {
                return s2;
            }
        }
    }

}
