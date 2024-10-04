using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaEditor.Symbols
{
    /// <summary>
    /// The symbol of binary operation
    /// </summary>
    public class BinarySymbol : SimpleSymbol
    {


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="c">The symbol char</param>
        /// <param name="italic">The italic style flag</param>
        /// <param name="s">The string for show</param>
        public BinarySymbol(char c, bool italic, String s)
            : base(c, (byte)3, italic, s)
        {
            children = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="c">The symbol char</param>
        /// <param name="italic">The italic style flag</param>
        public BinarySymbol(char c, bool italic)
            : this(c, italic, "")
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="c">The symbol char</param>
        public BinarySymbol(char c)
            : base(c, (byte)3, false, "")
        {
            string str = "";
            str += c;
            s = str;
            if (MathFormula.Resources != null)
            {
                if (MathFormula.Resources.ContainsKey(str))
                {
                    this.s = MathFormula.Resources[str];
                }
            }
            children = null;
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="s">Prototype</param>
        public BinarySymbol(BinarySymbol s)
            : base(s)
        {
        }

        /// <summary>
        /// Sets level of symbol
        /// </summary>
        /// <param name="level">The level</param>
        public override void SetLevel(byte level)
        {
            SetSameLevel(level);
        }


        /// <summary>
        /// Checks whether the symbol is same
        /// </summary>
        /// <param name="sym">Symbol</param>
        /// <returns>True if same and false otherwise</returns>
        public override bool IsSame(MathSymbol sym)
        {
            if (!(sym is BinarySymbol))
            {
                return false;
            }
            BinarySymbol ss = sym as BinarySymbol;
            return symbol == ss.symbol;
        }

        /// <summary>
        /// The Interfaces.ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
        {
            return new BinarySymbol(symbol, italic, s);
        }
    }
}
