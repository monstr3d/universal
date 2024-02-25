using FormulaEditor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Made analogous to ElementaryOperatioDetector, though most of functionality remains dump since only one single operation is needed for now.
    /// </summary>
    public class ElementaryDivisionDetector : IBinaryAcceptor, IBinaryDetector
    {
        #region Fields 

        private char symbol;

        private List<IBinaryAcceptor> acceptors = new List<IBinaryAcceptor>();

        #endregion

        #region Ctor

        public ElementaryDivisionDetector(char symbol)
        {
            this.symbol = symbol;
        }

        #endregion

        #region IBinaryDetector members
        BinaryAssociationDirection IBinaryDetector.AssociationDirection
        {
            get
            {
                return BinaryAssociationDirection.RightLeft;
            }
        }

        IBinaryAcceptor IBinaryDetector.Detect(MathSymbol symbol)
        {
            if (!(symbol is BinarySymbol))
            {
                return null;
            }
            BinarySymbol sym = symbol as BinarySymbol;
            if (symbol.Symbol != this.symbol)
            {
                return null;
            }
            return this;
        }

        #endregion

        #region IBinaryAcceptor members

        IObjectOperation IBinaryAcceptor.Accept(object typeA, object typeB)
        {
            object type = ElementaryDivisionOperation.DetectType(typeA, typeB, symbol);
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
            return new ElementaryDivisionOperation(symbol, new object[] {typeA, typeB }); 
        }

        #endregion

        #region Specific members

        /// <summary>
        /// Adding acceptors for overloaded operations
        /// </summary>
        /// <param name="acceptor">Acceptor to add</param>
        public void Add(IBinaryAcceptor acceptor)
        {
            acceptors.Add(acceptor);
        }

        #endregion
    }
}
