using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes.Interfaces;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace Bitmap.FormulaEditior.UnaryDetectors
{
    class UnaryAcceptor : IOperationAcceptor
    {
        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            if (type.Equals(typeof(System.Drawing.Bitmap)))
            {
                return new UnaryOperation();
            }
            return null;
        }
    }
}
