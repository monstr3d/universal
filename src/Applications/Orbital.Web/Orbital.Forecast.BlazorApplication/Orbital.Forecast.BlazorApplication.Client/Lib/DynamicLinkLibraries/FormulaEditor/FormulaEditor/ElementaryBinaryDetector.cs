using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{

    /// <summary>
    /// Detector of elementary binary operation
    /// </summary>
    public class ElementaryBinaryDetector : IBinaryDetector, IBinaryAcceptor
    {
        private List<IBinaryAcceptor> acceptors = new List<IBinaryAcceptor>();

        /// <summary>
        /// Operation symbol
        /// </summary>
        private char symbol;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">Operation symbol</param>
        public ElementaryBinaryDetector(char symbol)
        {
            this.symbol = symbol;
        }

        /// <summary>
        /// Adds acceptor
        /// </summary>
        /// <param name="acceptor">Acceptor to add</param>
        public void Add(IBinaryAcceptor acceptor)
        {
            acceptors.Add(acceptor);
        }

        /// <summary>
        /// Acceptor of binary operation
        /// </summary>
        /// <param name="typeA">Type of left part</param>
        /// <param name="typeB">Type of right part</param>
        /// <returns>Accepted operation</returns>
        public IObjectOperation Accept(object typeA, object typeB)
        {
            object type = ElementaryBinaryOperation.DetectType(typeA, typeB);
            if (type == null)
            {
                foreach (IBinaryAcceptor acceptor in acceptors)
                {
                    IObjectOperation op = acceptor.Accept(typeA, typeB);
                    if (op != null)
                    {
                        return op;
                    }
                }
                return null;
            }
            return new ElementaryBinaryOperation(symbol, new object[]{typeA, typeB});
        }

        /// <summary>
        /// Association direction
        /// </summary>
        public BinaryAssociationDirection AssociationDirection
        {
            get
            {
                return BinaryAssociationDirection.RightLeft;
            }
        }

        /// <summary>
        /// Detects operation acceptor
        /// </summary>
        /// <param name="s">Operation symbol</param>
        /// <returns>The acceptor</returns>
        public IBinaryAcceptor Detect(MathSymbol s)
        {
            if (!(s is BinarySymbol))
            {
                return null;
            }
            BinarySymbol sym = s as BinarySymbol;
            if (s.Symbol != symbol)
            {
                return null;
            }
            return this;
        }
    }
}
