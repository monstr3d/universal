using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Elementary root
    /// </summary>
    public class ElementaryRoot : 
        IMultiVariableOperationAcceptor, IMultiVariableOperation, ICloneable,
        IDerivationOperation, IFormulaCreatorOperation
    {
        /// <summary>
        /// Return type
        /// </summary>
        private const Double a = 0;


        /// <summary>
        /// The arity
        /// </summary>
        private int arity = 1;

        private static readonly object[] types = new object[] { (double)0, (double)0 };



        /// <summary>
        /// Constructor
        /// </summary>
        public ElementaryRoot()
        {
        }

        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>A clone</returns>
        public object Clone()
        {
            ElementaryRoot r = new ElementaryRoot();
            r.arity = arity;
            return r;
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
            MathFormula f = FormulaCreator.CreateFormula(tree[0], level, sizes);
            MathFormula form = new MathFormula(level, sizes);
            RootSymbol root = new RootSymbol();
            root.Append(form);
            form.First[0] = f;
            if (arity == 1)
            {
                return form;
            }
            MathFormula p = FormulaCreator.CreateFormula(tree[1], (byte)((int)level + 1), sizes);
            form.First[1] = p;
            return form;
        }


        /// <summary>
        /// Operation priority
        /// </summary>
        public int OperationPriority
        {
            get
            {
                return (int)ElementaryOperationPriorities.Power;
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
            if (arity == 1)
            {
                return ElementaryFunctionOperation.SquareRootDerivation(tree, variableName);
            }
            IObjectOperation mainOp = ElementaryFunctionsCreator.Object.GetPowerOperation(a, a);
            List<ObjectFormulaTree> mainList = new List<ObjectFormulaTree>();
            mainList.Add(tree[0]);
            IObjectOperation secondOp = ElementaryFraction.Object;
            List<ObjectFormulaTree> secondList = new List<ObjectFormulaTree>();
            IObjectOperation secondFistOperation = new ElementaryRealConstant(1);
            ObjectFormulaTree secondFirstTree = new ObjectFormulaTree(secondFistOperation, new List<ObjectFormulaTree>());
            secondList.Add(secondFirstTree);
            secondList.Add(tree[1]);
            ObjectFormulaTree secondTree = new ObjectFormulaTree(secondOp, secondList);
            mainList.Add(secondTree);
            return (new ObjectFormulaTree(mainOp, mainList)).Derivation(variableName);
        }




        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                if (arity == 1)
                {
                    return new object[] { (double)0 };
                }
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
                double a = (double)x[0];
                if (arity == 1)
                {
                    return Math.Sqrt(a);
                }
                double b = (double)x[1];
                return Math.Pow(a, 1 / b);
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
            if (type.Equals(a))
            {
                return this;
            }
            return null;
        }

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="types">Types of variables</param>
        /// <returns>Accepted operation</returns>
        public IObjectOperation Accept(object[] types)
        {
            for (int i = 0; i < types.Length; i++)
            {
                if (!types[i].Equals(a))
                {
                    return null;
                }
            }
            arity = types.Length;
            return this;
        }


        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <returns>Accepted operation</returns>
        public IMultiVariableOperation AcceptOperation(MathSymbol symbol)
        {
            if (symbol is RootSymbol)
            {
                return this;
            }
            return null;
        }
    }
}
