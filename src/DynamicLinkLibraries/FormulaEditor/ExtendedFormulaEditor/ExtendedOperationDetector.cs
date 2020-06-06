using System;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    class ExtendedOperationDetector : ElementaryObjectDetector
    {
        private IFormulaObjectCreator creator;

        internal ExtendedOperationDetector(Dictionary<char, object> table, IFormulaObjectCreator creator)
            : base(table)
        {
            this.creator = creator;
        }

        internal ExtendedOperationDetector(IVariableDetector detector, IFormulaObjectCreator creator)
            : base(detector)
        {
            this.creator = creator;
        }


        protected override IOperationAcceptor Minus
        {
            get
            {
                return MatrixAlgebraAcceptor.Singleton;
            }
        }

        protected override ElementaryBrackets Brakets
        {
            get
            {
                return new ElementaryBrackets(creator);
            }
        }
    }
}
