using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Detector of one variable function
    /// </summary>
    public class OneVariableFunctionDetector : IOperationDetector, IOperationAcceptor, IVariableDetector
    {

        #region Fields
        /// <summary>
        /// Table of variables
        /// </summary>
        private Dictionary<char, object> table;

        /// <summary>
        /// Detected function
        /// </summary>
        private IOneVariableFunction f;

        /// <summary>
        /// Variable detector
        /// </summary>
        private IVariableDetector varDetector;

        #endregion

        #region Ctor

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="table">Table of variables</param>
        public OneVariableFunctionDetector(Dictionary<char, object> table)
        {
            this.table = table;
            varDetector = this;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="varDetector">Variable detector</param>
        public OneVariableFunctionDetector(IVariableDetector varDetector)
        {
            this.varDetector = varDetector;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="f">The detected function</param>
        public OneVariableFunctionDetector(IOneVariableFunction f)
        {
            this.f = f;
        }

        #endregion

        #region IOperationDetector Members

        IOperationAcceptor IOperationDetector.Detect(MathSymbol s)
        {
            return varDetector.Detect(s);
        }

        #endregion

        #region IOperationAcceptor Members

        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            return Accept(this, type);
        }

        #endregion

        #region IVariableDetector Members

        IOperationAcceptor IVariableDetector.Detect(MathSymbol sym)
        {
            char c = sym.Symbol;
            if (!table.ContainsKey(c))
            {
                return null;
            }
            object o = table[c];
            if (!(o is IOneVariableFunction))
            {
                return null;
            }
            return new OneVariableFunctionDetector(o as IOneVariableFunction);
        }

        #endregion

        #region Members

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="detector">Operation detector</param>
        /// <param name="type">Operation type</param>
        /// <returns>Operation</returns>
        public static IObjectOperation Accept(OneVariableFunctionDetector detector, object type)
        {
            if (type is IOneVariableFunction)
            {
                try
                {
                    IOneVariableFunction g = type as IOneVariableFunction;
                    return new OneVariableReturn(OneVariableFuntionCompostion.Compose(g, detector.f));
                }
                catch (Exception)
                {

                }
            }
            if (detector.f == null)
            {
                return null;
            }
            if (type == null)
            {
                return new OneVariableReturn(detector.f);
            }
            object t = detector.f.VariableType;
            if (!type.Equals(t))
            {
                return null;
            }
            return detector.f;

        }
        #endregion

        #region Class OneRegionReturn


        /// <summary>
        /// Operation that returns a function
        /// </summary>
        class OneVariableReturn : IObjectOperation, IOneVariableFunction
        {
            #region Fields

            /// <summary>
            /// The function to return
            /// </summary>
            IOneVariableFunction f;
            #endregion

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="f">The function to return</param>
            internal OneVariableReturn(IOneVariableFunction f)
            {
                this.f = f;
            }

            #region IObjectOperation Members

            /// <summary>
            /// Types of input parameters
            /// </summary>
            object[] IObjectOperation.InputTypes
            {
                get
                {
                    return new object[0];
                }
            }

            object IObjectOperation.this[object[] x]
            {
                get { return f; }
            }

            object IObjectOperation.ReturnType
            {
                get { return f; }
            }

            #endregion

            #region IOneVariableFunction Members

            object IOneVariableFunction.VariableType
            {
                get { return f.VariableType; }
            }

            #endregion


        }
        #endregion
    }
}

