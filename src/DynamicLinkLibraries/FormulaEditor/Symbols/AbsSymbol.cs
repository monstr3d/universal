using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Symbols
{

    /// <summary>
    /// Absolute value symbol
    /// </summary>
    public class AbsSymbol : SimpleSymbol
    {
        #region Ctor

        /// <summary>
        /// Constructor 
        /// </summary>
        public AbsSymbol()
            : base('M')
        {
            type = (byte)2;
            s = "| |";
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="s">Prototype</param>
        public AbsSymbol(AbsSymbol s)
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
            if (!this.GetType().Equals(typeof(AbsSymbol)))
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
        /// The Interfaces.ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
        {
            return new AbsSymbol();
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
