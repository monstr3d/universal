using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace FormulaEditor.Symbols
{
    /// <summary>
    /// The symbol of brackets
    /// </summary>
    public class BracketsSymbol : SimpleSymbol
    {
        #region Ctor

        /// <summary>
        /// Constructor 
        /// </summary>
        public BracketsSymbol()
            : base('P')
        {
            type = (byte)2;
            s = "( )";
        }


        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="s">Prototype</param>
        public BracketsSymbol(BracketsSymbol s)
            : this()
        {
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Sets this symbol to formula
        /// </summary>
        /// <param name="formula">The formula to set</param>
        public override void SetToFormula(MathFormula formula)
        {
            base.SetToFormula(formula);
            //font = fonts[level];
            if ((this is FractionSymbol) | (this is BinaryFunctionSymbol))
            {
                return;
            }
            MathFormula child1 = new MathFormula((byte)(level), sizes);
            children.Add(child1);
            //childPositions = new Point[]{new Point()};
            if (sizes == null)
            {
                return;
            }
            if (level < (sizes.Length - 1))
            {
                MathFormula child2 = new MathFormula((byte)(level + 1), sizes);
                children.Add(child2);
                //childPositions = new Point[]{new Point(), new Point()};
                return;
            }
        }

        /// <summary>
        /// The ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
        {
            return new BracketsSymbol();
        }

        /// <summary>
        /// Sets level of symbol
        /// </summary>
        /// <param name="level">The level</param>
        public override void SetLevel(byte level)
        {
            this.level = level;
            int k = (int)level;
            for (int i = 0; i < Count; i++)
            {
                MathFormula f = this[i];
                if (f != null)
                {
                    f.SetLevel((byte)(i + k));
                }
            }
        }

        #endregion
    }
}
