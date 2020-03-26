using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace FormulaEditor.Symbols
{
    /// <summary>
    /// The symbol of root
    /// </summary>
    public class RootSymbol : BracketsSymbol
    {

        /// <summary>
        /// Unicode root symbol
        /// </summary>
        static char specQ = 'Q';


        /// <summary>
        /// Constructor
        /// </summary>
        public RootSymbol()
        {
            symbol = 'Q';
            s = "" + specQ;
        }


        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="s">Prototype</param>
        public RootSymbol(RootSymbol s)
            : this()
        {
        }


        /// <summary>
        /// The ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
        {
            return new RootSymbol();
        }
    }
}
