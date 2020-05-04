using System;
using System.Collections.Generic;
using System.Text;


using BaseTypes;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Dectector of array operation with many variables
    /// </summary>
    public class MultiArrayOperationDetector : IMultiOperationDetector
    {
        #region Fields

        private IMultiOperationDetector detector;


        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="detector">Base detector of opreation with many variables</param>
        public MultiArrayOperationDetector(IMultiOperationDetector detector)
        {
            this.detector = detector;
        }

        #endregion

        #region IMultiOperationDetector Members

        /// <summary>
        /// The "has begin" sign
        /// </summary>
        public bool HasBegin
        {
            get
            {
                return detector.HasBegin;
            }
        }

        /// <summary>
        /// The "has end" sign
        /// </summary>
        public bool HasEnd
        {
            get
            {
                return detector.HasEnd;
            }
        }

        /// <summary>
        /// Count of variables
        /// </summary>
        public int Count
        {
            get
            {
                return detector.Count;
            }
        }

        /// <summary>
        /// Detects operation
        /// </summary>
        /// <param name="i">variable number</param>
        /// <param name="symbol">Symbol</param>
        /// <returns>True if operation is decected and false otherwise</returns>
        public bool Detect(int i, MathSymbol symbol)
        {
            return detector.Detect(i, symbol);
        }

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="types">Types of variables</param>
        /// <returns>Object operation</returns>
        public IObjectOperation Accept(object[] types)
        {
            foreach (object o in types)
            {
                if (o is ArrayReturnType)
                {
                    return accept(types);
                }
            }
            return detector.Accept(types);
        }

        #endregion

        #region Specific members


        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="types">Types of variables</param>
        /// <returns>Object operation</returns>
        public IObjectOperation accept(object[] types)
        {
            object[] t = new object[types.Length];
            bool arr = false;
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i] is ArrayReturnType)
                {
                    arr = true;
                }
                t[i] = ArrayReturnType.GetBaseType(types[i]);
            }
            IObjectOperation op = detector.Accept(t);
            if (arr)
            {
                return new ArrayOperation(op, types);
            }
            return op;
        }

        #endregion

    }
}
