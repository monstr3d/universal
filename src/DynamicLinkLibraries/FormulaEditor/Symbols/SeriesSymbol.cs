using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using FormulaEditor.Interfaces;

namespace FormulaEditor.Symbols
{
    /// <summary>
    /// Symbol of unary series
    /// </summary>
    public class SeriesSymbol : SimpleSymbol
    {
        /// <summary>
        /// Operation
        /// </summary>
        private IOperationAcceptor acceptor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="index">Index of series</param>
        public SeriesSymbol(int index)
            : base('f', (int)FormulaConstants.Series, true, "f")
        {
            Index = index;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="s">Prototype</param>
        public SeriesSymbol(SeriesSymbol s)
            : this(s.index)
        {
        }

        /// <summary>
        /// Sets this symbol to formula
        /// </summary>
        /// <param name="formula">The formula to set</param>
        public override void SetToFormula(MathFormula formula)
        {
            base.SetToFormula(formula);
            if (!GetType().Equals(typeof(SeriesSymbol)))
            {
                return;
            }
            children.Clear();
            if (level < (sizes.Length - 1))
            {
                MathFormula child = new MathFormula((byte)(level + 1), sizes);
                children.Add(child);
                return;
            }
            children = null;
        }


        /// <summary>
        /// Operation
        /// </summary>
        public IOperationAcceptor Acceptor
        {
            get
            {
                return acceptor;
            }
        }


        /// <summary>
        /// The ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
        {
            return new SeriesSymbol(Index);
        }

        /// <summary>
        /// Sets operations to formula
        /// </summary>
        /// <param name="formula">The formula</param>
        /// <param name="table">Table of operations</param>
        public static void SetOperations(MathFormula formula, Dictionary<int, IOperationAcceptor>  table)
        {
            for (int i = 0; i < formula.Count; i++)
            {
                MathSymbol s = formula[i];
                for (int j = 0; j < s.Count; j++)
                {
                    SetOperations(s[j], table);
                }
                if (!(s is SeriesSymbol))
                {
                    continue;
                }
                SeriesSymbol ss = s as SeriesSymbol;
                int ind = ss.index;
                ss.acceptor = null;
                if (!table.ContainsKey(ind))
                {
                    throw new Exception("Operation with index " + ind + " does not exist");
                }
                IOperationAcceptor acc = table[ind];
                ss.acceptor = acc;
            }
        }

        /// <summary>
        /// Sets operations to formulas
        /// </summary>
        /// <param name="formulas">Formulas</param>
        /// <param name="table">Table of operations</param>
        public static void SetOperations(MathFormula[] formulas, Dictionary<int, IOperationAcceptor> table)
        {
            foreach (MathFormula f in formulas)
            {
                SetOperations(f, table);
            }
        }

        /// <summary>
        /// Gets indexes
        /// </summary>
        /// <param name="formulas">Formulas</param>
        /// <returns>Indexes</returns>
        public static List<int> GetOperationIndexes(MathFormula[] formulas)
        {
            List<int> list = new List<int>();
            foreach (MathFormula f in formulas)
            {
                getOperationIndexes(f, list);
            }
            return list;
        }

        private static void getOperationIndexes(MathFormula formula, List<int> list)
        {
            for (int i = 0; i < formula.Count; i++)
            {
                MathSymbol s = formula[i];
                for (int j = 0; j < s.Count; j++)
                {
                    getOperationIndexes(s[j], list);
                }
                if (!(s is SeriesSymbol))
                {
                    continue;
                }
                SeriesSymbol ss = s as SeriesSymbol;
                int ind = ss.index;
                if (!list.Contains(ind))
                {
                    list.Add(ind);
                }
            }
        }
    }
}
