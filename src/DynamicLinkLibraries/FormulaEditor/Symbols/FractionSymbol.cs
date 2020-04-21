using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaEditor.Symbols
{
    /// <summary>
    /// Math fraction symbol
    /// </summary>
    public class FractionSymbol : BracketsSymbol
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public FractionSymbol()
        {
            type = (byte)2;
            s = "F";
            symbol = (char)'F';
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="s">Base syblol</param>
        public FractionSymbol(FractionSymbol s)
            : this()
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
            return new FractionSymbol();
        }

    }
}
