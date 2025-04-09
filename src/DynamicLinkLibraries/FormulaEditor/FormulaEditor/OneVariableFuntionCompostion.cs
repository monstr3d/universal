using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Composition g * f of one variable functions
    /// </summary>
    public class OneVariableFuntionCompostion : IOneVariableFunction
    {

        #region Fields

        /// <summary>
        /// The f
        /// </summary>
        IOneVariableFunction f;

        /// <summary>
        /// The g
        /// </summary>
        IOneVariableFunction g;

        /// <summary>
        /// The operation of f
        /// </summary>
        IObjectOperation fo;

        /// <summary>
        /// The operation of g
        /// </summary>
        IObjectOperation go;

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        object[] o = new object[1];

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="f">The f</param>
        /// <param name="g">The g</param>
        private OneVariableFuntionCompostion(IOneVariableFunction f, IOneVariableFunction g)
        {
            if (!f.ReturnType.Equals(g.VariableType))
            {
                throw new ErrorHandler.OwnException("OneVariableFuntionCompostion");
            }
            this.f = f;
            this.g = g;
            fo = f;
            go = g;
        }

        #endregion

        #region IOneVariableFunction Members

        object IOneVariableFunction.VariableType
        {
            get { return f.VariableType; }
        }

        #endregion

        #region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get 
            {
                return g.InputTypes; 
            }
        }

        object IObjectOperation.this[object[] x]
        {
            get 
            {
                o[0] = fo[x];
                return go[o]; 
            }
        }

        object IObjectOperation.ReturnType
        {
            get { return g.ReturnType; }
        }


        #endregion

        /// <summary>
        /// Composition g * f;
        /// </summary>
        /// <param name="f">The f</param>
        /// <param name="g">The g</param>
        /// <returns>The composition</returns>
        static public IOneVariableFunction Compose(IOneVariableFunction f, IOneVariableFunction g)
        {
            return new OneVariableFuntionCompostion(f, g);
        }

    }
}
