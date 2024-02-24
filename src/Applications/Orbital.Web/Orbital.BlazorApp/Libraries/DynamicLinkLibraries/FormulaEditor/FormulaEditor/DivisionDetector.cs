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
    public class DivisionDetector : IBinaryAcceptor, IBinaryDetector
    {
        #region Fields 

        private char symbol;

        private List<IBinaryAcceptor> acceptors = new List<IBinaryAcceptor>();

        #endregion

        #region Ctor

        public DivisionDetector(char symbol)
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
            if (symbol.Symbol == '﹪')
            {
                return this;
            }
            return null;
        }

        #endregion

        #region IBinaryAcceptor members

        IObjectOperation IBinaryAcceptor.Accept(object typeA, object typeB)
        {
            object type = ElementaryModuloDivision.DetectType(typeA, typeB);
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
            return new ElementaryModuloDivision('﹪', new object[] {typeA, typeB }); //!!! Dump. Needs to be edited if some other division-related operations appear.
            //Left like that because of Zeitnot. Needs to be replaced with an ElementaryDivisionOperation class as soon as the fair ends.
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
