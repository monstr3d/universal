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
    class UnaryBitmapDetector : IOperationDetector
    {
        IOperationAcceptor IOperationDetector.Detect(MathSymbol symbol)
        {
           if (symbol.Symbol == '@')
            {
                if (symbol.String.Equals("UnaryBitmap"))
                {
                    return new UnaryAcceptor();
                }
            }
            return null;
        }
    }
}
