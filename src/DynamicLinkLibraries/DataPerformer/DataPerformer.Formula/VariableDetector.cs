using System;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using FormulaEditor;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

using ExtendedFormulaEditor;

namespace DataPerformer.Formula
{
    /// <summary>
    /// Detector of variable helper
    /// </summary>
    static public class VariableDetector
    {
        /// <summary>
        /// Gets creator
        /// </summary>
        /// <param name="table">Table</param>
        /// <returns>Creator</returns>
        static public IFormulaObjectCreator GetCreator(Dictionary<char, object> table)
        {
            return table.GetCreator();
        }

        /// <summary>
        /// Gets creator
        /// </summary>
        /// <param name="detector">Detector</param>
        /// <returns>Creator</returns>
        static public IFormulaObjectCreator GetCreator(IVariableDetector detector)
        {
            List<IOperationDetector> l = new List<IOperationDetector>();
            l.AddRange(StaticExtensionDataPerformerFormula.OperationDetectors);
            l.Add(new DerivationDetector("d/dt", "d/dt"));
            return detector.GetCreator(l, StaticExtensionDataPerformerFormula.BinaryDetectors);
        }

        /// <summary>
        /// Detects acceptor
        /// </summary>
        /// <param name="sym">The symbol</param>
        /// <param name="dic">Opretation dictionary</param>
        /// <returns>Acceptor</returns>
        static public IOperationAcceptor Detect(MathSymbol sym, IDictionary<string, IOperationAcceptor> dic)
        {
            string s = sym.Symbol + "";
            if (dic != null)
            {
                if (dic.ContainsKey(s))
                {
                    return dic[s];
                }
            }
            if (sym.SymbolType != (int)FormulaConstants.Variable)
            {
                return null;
            }
            return null;
        }
    }
}
