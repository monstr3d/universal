using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace FormulaEditor.Symbols
{
    /// <summary>
    /// TernaryFunctionSymbol function symbol
    /// </summary>
    public class TernaryFunctionSymbol : BinaryFunctionSymbol
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="s">Base symbl</param>
        public TernaryFunctionSymbol(TernaryFunctionSymbol s) : base(s)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public TernaryFunctionSymbol(char symbol, string s)
            : base(symbol, s)
        {
        }

        /// <summary>
        /// Sets this symbol to formula
        /// </summary>
        /// <param name="formula">The formula to set</param>
        public override void SetToFormula(MathFormula formula)
        {
            base.SetToFormula(formula);
            //for (int i = 0; i < 3; i++)
            //{
                children.Add(new MathFormula((byte)level, sizes));
            //}
        }

        /// <summary>
        /// The ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
        {
            return new TernaryFunctionSymbol(symbol, s);
        }

    }
}
