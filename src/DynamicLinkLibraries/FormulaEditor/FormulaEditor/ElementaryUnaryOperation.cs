using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using BaseTypes.Interfaces;


using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;
using ErrorHandler;

namespace FormulaEditor
{
    /// <summary>
    /// Operation of unary functions
    /// </summary>
    public class ElementaryUnaryOperation : IObjectOperation, IPowered, IOperationAcceptor, IDerivationOperation,
        IFormulaCreatorOperation
    {

        /// <summary>
        /// Type of operation
        /// </summary>
        private const Double a = 0;

        private static readonly object[] types = new object[] { (double)0 };


        /// <summary>
        /// Index of unary
        /// </summary>
        private int index;

        /// <summary>
        /// derivation sign
        /// </summary>
        private bool deriv = false;


        /// <summary>
        /// Unary
        /// </summary>
        private IUnary unary;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unary">Unary</param>
        /// <param name="index">Index of unary</param>
        public ElementaryUnaryOperation(IUnary unary, int index)
        {
            this.unary = unary;
            this.index = index;
        }

        /// <summary>
        /// Creates formula
        /// </summary>
        /// <param name="tree">Operation tree</param>
        /// <param name="level">Formula level</param>
        /// <param name="sizes">Sizes of symbols</param>
        /// <returns>The formula</returns>
        public MathFormula CreateFormula(ObjectFormulaTree tree, byte level, int[] sizes)
        {
            MathFormula form = new MathFormula(level, sizes);
            MathSymbol sym = new SeriesSymbol(index);
            sym.Append(form);
            sym = new BracketsSymbol();
            sym.Append(form);
            form.Last[0] = FormulaCreator.CreateFormula(tree[0], level, sizes);
            form.Last[1] = new MathFormula((byte)(level + 1), sizes);
            return form;
        }

        /// <summary>
        /// Operation priority
        /// </summary>
        public int OperationPriority
        {
            get
            {
                return (int)ElementaryOperationPriorities.Function;
            }
        }


        /// <summary>
        /// Calculates derivation
        /// </summary>
        /// <param name="tree">The function for derivation calculation</param>
        /// <param name="variableName">Name of variable</param>
        /// <returns>The derivation</returns>
        public ObjectFormulaTree Derivation(ObjectFormulaTree tree, string variableName)
        {
            if (deriv)
            {
                throw new ErrorHandler.OwnException("Could not calculate second derivation");
            }
            ElementaryUnaryOperation der = new ElementaryUnaryOperation(unary, index);
            der.deriv = true;
            List<ObjectFormulaTree> list = new List<ObjectFormulaTree>();
            List<ObjectFormulaTree> lFirst = new List<ObjectFormulaTree>();
            lFirst.Add(tree[0]);//.Clone() as ObjectFormulaTree);
            list.Add(new ObjectFormulaTree(der, lFirst));
            list.Add(tree[0].Derivation(variableName));
            Double a = 0;
            return new ObjectFormulaTree(new ElementaryBinaryOperation('*', new object[] { a, a }), list);
        }

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return types;
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                double y = (double)x[0];
                return unaryValue(y);
            }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
        {
            get
            {
                return a;
            }
        }

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
        {
            /*if (type is ArrayReturnType)
            {
                Array arr = type as Array;
                object ot = arr.GetValue(0);
                if (ot is Double)
                {
                    double a = 0;
                    object[] ob = new object[arr.Length];
                    for (int i = 0; i < ob.Length; i++)
                    {
                        ob[i] = a;
                    }
                    return new ArrayOperation(this, new object[] { ob });
                }
            }*/
            if (!(type is Double) & type != null)
            {
                return null;
            }
            return this;
        }

        /// <summary>
        /// The "is powered" sign
        /// </summary>
        bool IPowered.IsPowered
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Sets unary table
        /// </summary>
        public Dictionary<int, IUnary> Unary
        {
            set
            {
                unary = value[index];
            }
        }

        /// <summary>
        /// Index
        /// </summary>
        public int Index
        {
            get
            {
                return index;
            }
        }

        /// <summary>
        /// Sets unary table on tree
        /// </summary>
        /// <param name="tree">Tree to set unary</param>
        /// <param name="unary">Unary table</param>
        public static void SetUnary(ObjectFormulaTree tree, Dictionary<int, IUnary> unary)
        {
            if (tree.Operation is ElementaryUnaryOperation)
            {
                ElementaryUnaryOperation op = tree.Operation as ElementaryUnaryOperation;
                op.Unary = unary;
            }
            else if (tree.Operation is ArrayOperation)
            {
                ArrayOperation ao = tree.Operation as ArrayOperation;
                if (ao.SingleOperation is ElementaryUnaryOperation)
                {
                    ElementaryUnaryOperation eo = ao.SingleOperation as ElementaryUnaryOperation;
                    eo.Unary = unary;
                }
            }
            for (int i = 0; i < tree.Count; i++)
            {
                SetUnary(tree[i], unary);
            }
        }

        /// <summary>
        /// Sets unary table on trees
        /// </summary>
        /// <param name="trees">Trees to set unary</param>
        /// <param name="unary">Unary table</param>
        public static void SetUnary(ObjectFormulaTree[] trees, Dictionary<int, IUnary> unary)
        {
            foreach (ObjectFormulaTree tree in trees)
            {
                SetUnary(tree, unary);
            }
        }


        /// <summary>
        /// Gets unary indexes of tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <param name="list">List of indexes</param>
        public static void GetUnaryIndexes(ObjectFormulaTree tree, List<int> list)
        {
            try
            {
                if (tree.Operation is ElementaryUnaryOperation)
                {
                    ElementaryUnaryOperation op = tree.Operation as ElementaryUnaryOperation;
                    int indx = op.index;
                    if (!list.Contains(indx))
                    {
                        list.Add(indx);
                    }
                }
                if (tree.Operation is ArrayOperation)
                {
                    ArrayOperation op = tree.Operation as ArrayOperation;
                    IObjectOperation so = op.SingleOperation;
                    if (so is ElementaryUnaryOperation)
                    {
                        ElementaryUnaryOperation sop = so as ElementaryUnaryOperation;
                        int ind = sop.index;
                        if (!list.Contains(ind))
                        {
                            list.Add(ind);
                        }
                    }
                }
                for (int i = 0; i < tree.Count; i++)
                {
                    GetUnaryIndexes(tree[i], list);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Gets unary indexes of tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>List of indexes</returns>
        public static List<int> GetUnaryIndexes(ObjectFormulaTree tree)
        {
            List<int> l = new List<int>();
            GetUnaryIndexes(tree, l);
            l.Sort();
            return l;
        }


        /// <summary>
        /// Gets unary indexes of trees
        /// </summary>
        /// <param name="trees">The trees</param>
        /// <returns>List of indexes</returns>
        public static List<int> GetUnaryIndexes(ObjectFormulaTree[] trees)
        {
            List<int> l = new List<int>();
            try
            {
                foreach (ObjectFormulaTree tree in trees)
                {
                    GetUnaryIndexes(tree, l);
                }
                l.Sort();
            }
            catch (Exception)
            {
            }
            return l;
        }

        /// <summary>
        /// Gets unary table of tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <param name="table">The table</param>
        public static void GetUnaryTable(ObjectFormulaTree tree, Dictionary<int, IUnary> table)
        {
            if (tree.Operation is ElementaryUnaryOperation)
            {
                ElementaryUnaryOperation op = tree.Operation as ElementaryUnaryOperation;
                table[op.index] = op.unary;
            }
            if (tree.Operation is ArrayOperation)
            {
                ArrayOperation op = tree.Operation as ArrayOperation;
                IObjectOperation so = op.SingleOperation;
                if (so is ElementaryUnaryOperation)
                {
                    ElementaryUnaryOperation sop = so as ElementaryUnaryOperation;
                    table[sop.index] = sop.unary;
                }
            }

            for (int i = 0; i < tree.Count; i++)
            {
                GetUnaryTable(tree[i], table);
            }
        }


        /// <summary>
        /// Gets Unary table from trees
        /// </summary>
        /// <param name="trees">The trees</param>
        /// <returns>The table</returns>
        public static Dictionary<int, IUnary> GetUnaryTable(ObjectFormulaTree[] trees)
        {
            Dictionary<int, IUnary> table = new Dictionary<int, IUnary>();
            foreach (ObjectFormulaTree tree in trees)
            {
                GetUnaryTable(tree, table);
            }
            return table;
        }

        /// <summary>
        /// Gets Unary table from tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>The table</returns>
        public static Dictionary<int, IUnary> GetUnaryTable(ObjectFormulaTree tree)
        {
            Dictionary<int, IUnary> table = new Dictionary<int, IUnary>();
            GetUnaryTable(tree, table);
            return table;
        }


        /// <summary>
        /// Calculates value of ementary function
        /// </summary>
        /// <param name="x">the argument</param>
        /// <returns>The value</returns>
        private double unaryValue(double x)
        {
            if (!deriv)
            {
                return unary.GetValue(x);
            }
            return unary.GetDerivation(x);
        }

        /// <summary>
        /// Inserts formula instead variable
        /// </summary>
        /// <param name="tree">Prototype</param>
        /// <param name="insert">Inerted formula</param>
        /// <returns>Result of the operation</returns>
        private static ObjectFormulaTree insertVariable(ObjectFormulaTree tree, ObjectFormulaTree insert)
        {
            Double a = 0;
            if (tree.Operation is ElementaryObjectVariable & tree.ReturnType.Equals(a))
            {
                return insert;//.Clone() as ObjectFormulaTree;
            }
            List<ObjectFormulaTree> children = new List<ObjectFormulaTree>();
            for (int i = 0; i < tree.Count; i++)
            {
                ObjectFormulaTree t = tree[i];//.Clone() as ObjectFormulaTree;
                children.Add(insertVariable(t, insert));
            }
            return new ObjectFormulaTree(tree.Operation, children);
        }
    }

}
