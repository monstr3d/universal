using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Symbols;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Creator of formula object
    /// </summary>
    public interface IFormulaObjectCreator
    {
        /// <summary>
        /// Count of binary operations
        /// </summary>
        int BinaryCount
        {
            get;
        }


        /// <summary>
        /// Gets i - th binary detector
        /// </summary>
        /// <param name="i">Detector number</param>
        /// <returns>The i - th detector</returns>
        IBinaryDetector GetBinaryDetector(int i);

        /// <summary>
        /// Count of multi operation
        /// </summary>
        int MultiOperationCount
        {
            get;
        }

        /// <summary>
        /// Gets multi operation detector
        /// </summary>
        /// <param name="n">The detector number</param>
        /// <returns>The n - th detector</returns>
        IMultiOperationDetector GetMultiOperationDetector(int n);

        /// <summary>
        /// Count of operations
        /// </summary>
        int OperationCount
        {
            get;
        }

        /// <summary>
        /// Gets i - th operation detector
        /// </summary>
        /// <param name="i">Detector number</param>
        /// <returns>The i - th detector</returns>
        IOperationDetector GetDetector(int i);


        /// <summary>
        /// Checks whether symbol is bra
        /// </summary>
        /// <param name="s">The symbol</param>
        /// <returns>True if symbol is bra and false otherwise</returns>
        bool IsBra(MathSymbol s);

        /// <summary>
        /// Checks whether symbol is ket
        /// </summary>
        /// <param name="s">The symbol</param>
        /// <returns>True if symbol is ket and false otherwise</returns>
        bool IsKet(MathSymbol s);

        /// <summary>
        /// Gets power operation
        /// </summary>
        /// <param name="valType">Type of value</param>
        /// <param name="powType">Type of power</param>
        /// <returns>Operation</returns>
        IObjectOperation GetPowerOperation(object valType, object powType);

        /// <summary>
        /// Adds operation detector
        /// </summary>
        /// <param name="The detector"></param>
        void Add(IOperationDetector detector);

        /// <summary>
        /// Adds binary detector
        /// </summary>
        /// <param name="binaryDetector">Bitary detector</param>
        void Add(IBinaryDetector binaryDetector);

    }
}
