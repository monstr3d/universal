using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes.Interfaces;
using Bitmap.FormulaEditior.TernaryDetectors;
using Bitmap.FormulaEditior.UnaryDetectors;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace Bitmap.FormulaEditior.BinaryDetectors
{
    class BitmapDetector : IOperationDetector
    {

        internal static readonly BitmapDetector Singleton = new BitmapDetector();

        internal BitmapDetector()
        {

        }

        static readonly Dictionary<string, IOperationAcceptor> acceptors = new Dictionary<string, IOperationAcceptor>()
        {
            { StaticExtensionBitmapFormulaEditor.Operations[0], BinaryBitmapAcceptor.Sinleton },
            { StaticExtensionBitmapFormulaEditor.Operations[1], TernaryBitmapAcceptor.Sinleton }
        };

        IOperationAcceptor IOperationDetector.Detect(MathSymbol symbol)
        {
            string s = symbol.String;
            if (acceptors.ContainsKey(s))
            {
                return acceptors[s];
            }
            return null;
        }
    }
}
