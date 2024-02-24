using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;


using BaseTypes;
using BaseTypes.Interfaces;


using FormulaEditor.Attributes;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;
using System.Reflection;

namespace FormulaEditor
{
    /// <summary>
    /// Creator of trees of formulas which supports array operations
    /// </summary>
    public class FormulaArrayObjectCreator : IFormulaObjectCreator
    {
        private IFormulaObjectCreator creator;

        /// <summary>
        /// List of detectors of binary operations
        /// </summary>
        protected List<IBinaryDetector> binary = new List<IBinaryDetector>();
        /// <summary>
        /// List of detectors of operations with many variables
        /// </summary>
        protected List<IMultiOperationDetector> multi = new List<IMultiOperationDetector>();

        /// <summary>
        /// List of detectors of operations
        /// </summary>
        protected List<IOperationDetector> detectors = new List<IOperationDetector>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="creator">Base formula creator</param>
        public FormulaArrayObjectCreator(IFormulaObjectCreator creator)
        {
            this.creator = creator;
            for (int i = 0; i < creator.BinaryCount; i++)
            {
                binary.Add(new BinaryArrayOperationDetector(creator.GetBinaryDetector(i)));
            }
            for (int i = 0; i < creator.MultiOperationCount; i++)
            {
                multi.Add(new MultiArrayOperationDetector(creator.GetMultiOperationDetector(i)));
            }
            for (int i = 0; i < creator.OperationCount; i++)
            {
                IOperationDetector d = creator.GetDetector(i);
                TypeInfo dt = d.ToTypeInfo();
                TreeTransformationAttribute da = dt.GetAttribute<TreeTransformationAttribute>();
                if (da != null)
                {
                    detectors.Add(d);
                    goto detectorSelected;
                }
                detectors.Add(new ArrayOperationDetector(d));
            detectorSelected:
                continue;
            }
            detectors.Add(ArraySingleDetector.Object);
        }


        #region IFormulaObjectCreator Members

        /// <summary>
        /// Count of binary operations
        /// </summary>
        public int BinaryCount
        {
            get
            {
                return binary.Count;
            }
        }

        /// <summary>
        /// Gets i - th binary detector
        /// </summary>
        /// <param name="i">Detector number</param>
        /// <returns>The i - th detector</returns>
        public IBinaryDetector GetBinaryDetector(int i)
        {
            return binary[i];
        }

        /// <summary>
        /// Count of multi operation
        /// </summary>
        public int MultiOperationCount
        {
            get
            {
                return multi.Count;
            }
        }

        /// <summary>
        /// Gets multi operation detector
        /// </summary>
        /// <param name="n">The detector number</param>
        /// <returns>The n - th detector</returns>
        public IMultiOperationDetector GetMultiOperationDetector(int n)
        {
            return multi[n];
        }

        /// <summary>
        /// Count of operations
        /// </summary>
        public int OperationCount
        {
            get
            {
                return detectors.Count;
            }
        }

        /// <summary>
        /// Gets i - th operation detector
        /// </summary>
        /// <param name="i">Detector number</param>
        /// <returns>The i - th detector</returns>
        public IOperationDetector GetDetector(int i)
        {
            return detectors[i];
        }

        /// <summary>
        /// Checks whether symbol is bra
        /// </summary>
        /// <param name="s">The symbol</param>
        /// <returns>True if symbol is bra and false otherwise</returns>
        public bool IsBra(MathSymbol s)
        {
            return creator.IsBra(s);
        }


        /// <summary>
        /// Checks whether symbol is ket
        /// </summary>
        /// <param name="s">The symbol</param>
        /// <returns>True if symbol is ket and false otherwise</returns>
        public bool IsKet(MathSymbol s)
        {
            return creator.IsKet(s);
        }

        /// <summary>
        /// Gets power operation
        /// </summary>
        /// <param name="valType">Type of value</param>
        /// <param name="powType">Type of power</param>
        /// <returns>Operation</returns>
        public IObjectOperation GetPowerOperation(object valType, object powType)
        {
            return getPowerOperation(valType, powType);
        }

        void IFormulaObjectCreator.Add(IOperationDetector detector)
        {
            detectors.Add(detector);
        }

        void IFormulaObjectCreator.Add(IBinaryDetector binaryDetector)
        {
            binary.Add(binaryDetector);
        }

        #endregion

        #region Specific members


        /// <summary>
        /// Gets power operation
        /// </summary>
        /// <param name="valType">Type of value</param>
        /// <param name="powType">Type of power</param>
        /// <returns>Operation</returns>
        public IObjectOperation getPowerOperation(object valType, object powType)
        {
            IObjectOperation opOwn = creator.GetPowerOperation(valType, powType);
            if (opOwn != null)
            {
                return opOwn;
            }
            object[] types = new object[] { ArrayReturnType.GetBaseType(valType), ArrayReturnType.GetBaseType(powType) };
            IObjectOperation op = creator.GetPowerOperation(types[0], types[1]);
            if (!(valType is ArrayReturnType) & !(powType is ArrayReturnType))
            {
                return op;
            }
            return new ArrayOperation(op, new object[] { valType, powType });
        }

        #endregion
    }

}
