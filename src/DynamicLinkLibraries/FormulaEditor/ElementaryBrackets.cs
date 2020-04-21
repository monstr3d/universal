using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{

    /// <summary>
    /// Elementary real constant
    /// </summary>
    public class ElementaryBrackets : IMultiVariableOperationAcceptor, 
        IMultiVariableOperation, 
        IPowered, IDerivationOperation,
        Interfaces.ICloneable, 
        IFormulaCreatorOperation
    {
        /// <summary>
        /// Return type
        /// </summary>
        private object type;


        /// <summary>
        /// The arity
        /// </summary>
        private int arity = 1;

        /// <summary>
        /// Formula object creator
        /// </summary>
        private IFormulaObjectCreator creator;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="creator">Creator of formula</param>
        public ElementaryBrackets(IFormulaObjectCreator creator)
        {
            this.creator = creator;
        }

        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>A clone</returns>
        public object Clone()
        {
            ElementaryBrackets r = new ElementaryBrackets(creator);
            r.arity = arity;
            r.creator = creator;
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
            MathFormula form = new MathFormula(level, sizes);
            IFormulaCreatorOperation op = tree[0].Operation as IFormulaCreatorOperation;
            MathFormula f = op.CreateFormula(tree[0], level, sizes);
            MathSymbol s = new BracketsSymbol();
            s.Append(form);
            form.First[0] = f;
            if (arity > 1)
            {
                IFormulaCreatorOperation opPower = tree[1].Operation as IFormulaCreatorOperation;
                MathFormula p = opPower.CreateFormula(tree[0], level, sizes);
                form.First[1] = p;
            }
            return form;
        }

        /// <summary>
        /// Operation priority
        /// </summary>
        public int OperationPriority
        {
            get
            {
                return (int)ElementaryOperationPriorities.Brackets;
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
                return tree[0].Derivation(variableName);
            }
            IDerivationOperation pow =
                ElementaryFunctionsCreator.Object.GetPowerOperation(tree[0].ReturnType, tree[1].ReturnType)
                as IDerivationOperation;
            return pow.Derivation(tree, variableName);
        }


        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] IObjectOperation.InputTypes
        {
            get
            {
                if (arity == 1)
                {
                    return new object[] { (double)0 };
                }
                return new object[] { (double)0, (double)0 };
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                if (arity == 1)
                {
                    return x[0];
                }
                double a = (double)x[0];
                double b = (double)x[1];
                return Math.Pow(a, b);
            }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
        {
            get
            {
                return type;
            }
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
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
        {
            this.type = type;
            return this;
        }

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="types">Types of variables</param>
        /// <returns>Accepted operation</returns>
        public IObjectOperation Accept(object[] types)
        {
            type = types[0];
            arity = types.Length;
            if (arity > 1)
            {
                if (creator != null)
                {
                    IObjectOperation op = creator.GetPowerOperation(types[0], types[1]);
                    if (op != null)
                    {
                        return op;
                    }
                }
                foreach (object o in types)
                {
                    if (o != null & o is ArrayReturnType)
                    {
                        return null;
                    }
                }
            }
            return this;
        }


        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <returns>Accepted operation</returns>
        public IMultiVariableOperation AcceptOperation(MathSymbol symbol)
        {
            if (symbol is BracketsSymbol)
            {
                return this;
            }
            return null;
        }
    }
}
