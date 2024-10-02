using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Creator of elementary functions
    /// </summary>
    public class ElementaryFunctionsCreator : IFormulaObjectCreator
    {
        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly ElementaryFunctionsCreator Object = new ElementaryFunctionsCreator(true);

        /// <summary>
        /// Detectors of unary operations
        /// </summary>
        protected List<IOperationDetector> unaryDetectors = new List<IOperationDetector>();
        
        /// <summary>
        /// Detyectors of binary operations
        /// </summary>
        protected IBinaryDetector[] detectors;

        const Double a = 0;

        private IMultiOperationDetector[] multiDetectors = new IMultiOperationDetector[]
			{
				OptionalDetector.Object
			};

        /// <summary>
        /// Default constructor
        /// </summary>
        protected ElementaryFunctionsCreator()
            : this(true)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="init">Initialization sign</param>
        protected ElementaryFunctionsCreator(bool init)
        {
            if (!init)
            {
                return;
            }
            ElementaryBinaryDetector plus = new ElementaryBinaryDetector('+');
            plus.Add(StringConcatOperation.Object);
            //!!! Has priority higher than needed '+'-type operations, throws a bug           
            plus.Add(StringObjectConcatOperation.Object);
            LikeOperation like = new LikeOperation();
            like.Add(LikeObjectOperation.Object);

            detectors = new IBinaryDetector[]
			{
				new LogicalDetector('\u2217'), new LogicalDetector('\u2216'), 
                new LogicalDetector('\u8835'),
				LogicalEqualityDetector.Object,
				new BitDetector('|'), new BitDetector('&'), new BitDetector('^'),
				new BitDetector('\u2266'), new BitDetector('\u2267'),
				ComparationDetector.Object,  like,
				plus, new ElementaryBinaryDetector('-'),
				new ElementaryBinaryDetector('*'),
                new ElementaryDivisionDetector('﹪'),
                new ElementaryDivisionDetector('/'),
                WhereDetector.Singleton, OrderByDetector.Singleton, AverageDetector.Singleton,
                IndexOfDetector.Singleton
			};
        }

        /// <summary>
        /// Count of binary operations
        /// </summary>
        public virtual int BinaryCount
        {
            get
            {
                return detectors.Length;
            }
        }
        /// <summary>
        /// Gets i - th binary detector
        /// </summary>
        /// <param name="i">Detector number</param>
        /// <returns>The i - th detector</returns>
        public virtual IBinaryDetector GetBinaryDetector(int i)
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
            return s.Symbol == '(';
        }

        /// <summary>
        /// Checks whether symbol is ket
        /// </summary>
        /// <param name="s">The symbol</param>
        /// <returns>True if symbol is ket and false otherwise</returns>
        public bool IsKet(MathSymbol s)
        {
            return s.Symbol == ')';
        }

        /// <summary>
        /// Count of operations
        /// </summary>
        public virtual int OperationCount
        {
            get
            {
                return unaryDetectors.Count + 1;
            }
        }

        /// <summary>
        /// Gets i - th operation detector
        /// </summary>
        /// <param name="i">Detector number</param>
        /// <returns>The i - th detector</returns>
        public virtual IOperationDetector GetDetector(int i)
        {
            if (i == 0)
            {
                return ElementaryRealDetector.Object;
            }
            return unaryDetectors[i - 1] as IOperationDetector;
        }

        /// <summary>
        /// Count of multi operation
        /// </summary>
        public int MultiOperationCount
        {
            get
            {
                return multiDetectors.Length;
            }
        }

   
        /// <summary>
        /// Gets multi operation detector
        /// </summary>
        /// <param name="n">The detector number</param>
        /// <returns>The n - th detector</returns>
        public IMultiOperationDetector GetMultiOperationDetector(int n)
        {
            return multiDetectors[n];
        }

        /// <summary>
        /// Gets power operation
        /// </summary>
        /// <param name="valType">Type of value</param>
        /// <param name="powType">Type of power</param>
        /// <returns>Operation</returns>
        public virtual IObjectOperation GetPowerOperation(object valType, object powType)
        {
            if (valType.Equals(a) & powType.Equals(a))
            {
                return new ElementaryPowerOperation(valType, powType);
            }
            return null;
        }

        void IFormulaObjectCreator.Add(IOperationDetector detector)
        {
            unaryDetectors.Add(detector);
        }

        void IFormulaObjectCreator.Add(IBinaryDetector binaryDetector)
        {
            List<IBinaryDetector> b = detectors.ToList();
            b.Add(binaryDetector);
            detectors = b.ToArray(); 
        }
    }
}
