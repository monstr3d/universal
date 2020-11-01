using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaEditor.Symbols
{
    /// <summary>
    /// Binary function symbol
    /// </summary>
    public class BinaryFunctionSymbol : BracketsSymbol
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="s">Base symbl</param>
        public BinaryFunctionSymbol(BinaryFunctionSymbol s) 
        {
            this.bold = base.bold;
            this.italic = italic;
            this.s = s.s;
            this.sb = s.sb;
            this.sizes = s.sizes;
            this.level = s.level;
            this.symbol = s.symbol;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public BinaryFunctionSymbol(char symbol, string s)
        {
            type = (byte)2;
            if (s != null)
            {
                if (MathFormula.Resources.ContainsKey(s))
                {
                    this.s = MathFormula.Resources[s];
                }
            }
            this.s = s;
            this.symbol = symbol;
        }

        /// <summary>
        /// Sets this symbol to formula
        /// </summary>
        /// <param name="formula">The formula to set</param>
        public override void SetToFormula(MathFormula formula)
        {
            base.SetToFormula(formula);
            for (int i = 0; i < 2; i++)
            {
                children.Add(new MathFormula((byte)level, sizes));
            }
        }

        /// <summary>
        /// The Interfaces.ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
        {
            return new BinaryFunctionSymbol(symbol, s);
        }

        /// <summary>
        /// Sets level of symbol
        /// </summary>
        /// <param name="level">The level</param>
        public override void SetLevel(byte level)
        {
            this.level = level;
            for (int i = 0; i < Count; i++)
            {
                MathFormula f = this[i];
                if (f != null)
                {
                    f.SetLevel(level);
                }
            }
        }

    }
}
