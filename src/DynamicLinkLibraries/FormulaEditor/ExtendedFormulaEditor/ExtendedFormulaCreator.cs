using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Extended code creator
    /// </summary>
    public class ExtendedFormulaCreator : ElementaryObjectsCreator
    {
        const Double a = 0;
        const Int32 it = 0;

        #region Ctor

        internal ExtendedFormulaCreator(Dictionary<char, object> table)
            : base(table, false)
        {
            opDetectors = new IOperationDetector[] 
            { new OneVariableFunctionDetector(table), new ExtendedOperationDetector(table, this) };
            ElementaryBinaryDetector plus = new ElementaryBinaryDetector('+');
            plus.Add(StringConcatOperation.Object);
 /// Has higher priority than other '+'-type operators, causes a bug           
            plus.Add(StringObjectConcatOperation.Object);
            LikeOperation like = new LikeOperation();
            like.Add(LikeObjectOperation.Object);
            detectors = new IBinaryDetector[]
			{
				new LogicalDetector('\u2217'), new LogicalDetector('\u2216'), new LogicalDetector('\u8835'),
				LogicalEqualityDetector.Object,
				new BitDetector('|'), new BitDetector('&'), new BitDetector('^'),
				new BitDetector('\u2266'), new BitDetector('\u2267'),
				ComparationDetector.Object,  like, RealMatrixBinary.Singleton,
                RealVectorBinary.Singleton,
				plus, new ElementaryBinaryDetector('-'),
                RealMatrixMultiplication.Singleton,
				new ElementaryBinaryDetector('*'),
                Vector3DProduct.Object,
                BinaryPropertyDetector.Singleton,
                new ElementaryDivisionDetector('﹪'), 
                new ElementaryDivisionDetector('/')
			};
        }


        internal ExtendedFormulaCreator(IVariableDetector detector)
            : base(detector, false)
        {
            opDetectors = new IOperationDetector[]
            { new OneVariableFunctionDetector(detector), new ExtendedOperationDetector(detector, this) //,
               /*!!! new Func.FuncDetector(detector) */};
            ElementaryBinaryDetector plus = new ElementaryBinaryDetector('+');
            plus.Add(StringConcatOperation.Object);
            /// Has higher priority than other '+'-type operators, causes a bug            
            plus.Add(StringObjectConcatOperation.Object);
            LikeOperation like = new LikeOperation();
            like.Add(LikeObjectOperation.Object);
            detectors = new IBinaryDetector[]
			{
				new LogicalDetector('\u2217'), new LogicalDetector('\u2216'), new LogicalDetector('\u8835'),
				LogicalEqualityDetector.Object,
				new BitDetector('|'), new BitDetector('&'), new BitDetector('^'),
				new BitDetector('\u2266'), new BitDetector('\u2267'),
				ComparationDetector.Object,  like, RealMatrixBinary.Singleton,
                RealVectorBinary.Singleton,
				plus, new ElementaryBinaryDetector('-'),
                RealMatrixMultiplication.Singleton,
				new ElementaryBinaryDetector('*'),
                new ElementaryDivisionDetector('/'),
                new ElementaryDivisionDetector('﹪'),
                Vector3DProduct.Object,
                WhereDetector.Singleton,
                OrderByDetector.Singleton,
                AverageDetector.Singleton
			};

        }

        #endregion

        #region Overriden Members

        public override IObjectOperation GetPowerOperation(object valType, object powType)
        {
            if (powType == VirtualTranspose.Singleton)
            {
                if (valType is ArrayReturnType)
                {
                    ArrayReturnType at = valType as ArrayReturnType;
                    if (!at.IsObjectType)
                    {
                        int[] dim = at.Dimension;
                        if (at.ElementType.Equals(a) & dim.Length == 2)
                        {
                            return new TransposeRealMatrix(dim[0], dim[1]);
                        }
                    }
                }
            }
            if (valType is ArrayReturnType)
            {
                ArrayReturnType at = valType as ArrayReturnType;
                if (!at.IsObjectType)
                {
                    int[] dim = at.Dimension;
                    if (at.ElementType.Equals(a) & dim.Length == 2)
                    {
                        if (dim[0] == dim[1])
                        {
                            if (powType.Equals(a) | powType.Equals(it))
                            {
                                return new RealMatrixPower(dim[0]);
                            }
                        }
                    }
                }
            }
            return base.GetPowerOperation(valType, powType);
        }

        public override IOperationDetector GetDetector(int i)
        {
            if (i == 0)
            {
                return VirtualTranspose.Singleton;
            }
            return base.GetDetector(i - 1);
        }

        public override int OperationCount
        {
            get
            {
                return base.OperationCount + 1;
            }
        }

        #endregion
   }
}
