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
    /// Elementary atan2
    /// </summary>
    public class ElementaryAtan2 : IMultiVariableOperationAcceptor, IMultiVariableOperation,
        IDerivationOperation, IFormulaCreatorOperation
    {

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly ElementaryAtan2 Object = new ElementaryAtan2();


        /// <summary>
        /// Return type
        /// </summary>
        private const Double a = 0;


        /// <summary>
        /// The arity
        /// </summary>
        private int arity = 2;

        private static readonly object[] types = new object[] { (double)0,  (double)0 };



        /// <summary>
        /// Constructor
        /// </summary>
        private ElementaryAtan2()
        {
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
            BinaryFunctionSymbol atan = new BinaryFunctionSymbol('A', "atan2");
            atan.Append(form);
            for (int i = 0; i < 2; i++)
            {
                form.First[i] = FormulaCreator.CreateFormula(tree[i], level, sizes);
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
            Double a = 0;
            ObjectFormulaTree[] fc = new ObjectFormulaTree[2];
            ObjectFormulaTree[] fd = new ObjectFormulaTree[2];
            for (int i = 0; i < 2; i++)
            {
                fc[i] = tree[i];
                fd[i] = fc[i].Derivation(variableName);
            }
            List<ObjectFormulaTree> list = new List<ObjectFormulaTree>();
            IObjectOperation nom = new ElementaryBinaryOperation('-', new object[] { a, a });
            List<ObjectFormulaTree> nomList = new List<ObjectFormulaTree>();
            for (int i = 0; i < 2; i++)
            {
                List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
                l.Add(fc[1 - i]);
                l.Add(fd[i]);
                IObjectOperation o = new ElementaryBinaryOperation('*', new object[] { a, a });
                nomList.Add(new ObjectFormulaTree(o, l));
            }
            list.Add(new ObjectFormulaTree(nom, nomList));
            List<ObjectFormulaTree> plusList = new List<ObjectFormulaTree>();
            for (int i = 0; i < 2; i++)
            {
                List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
                l.Add(fc[i]);
                l.Add(new ObjectFormulaTree(new ElementaryRealConstant(2), new List<ObjectFormulaTree>()));
                IObjectOperation o = ElementaryFunctionsCreator.Object.GetPowerOperation(a, a);
                plusList.Add(new ObjectFormulaTree(o, l));
            }
            IObjectOperation plusOp = new ElementaryBinaryOperation('+', new object[] { a, a });
            IObjectOperation denomOp = new ElementaryRoot();
            List<ObjectFormulaTree> denomList = new List<ObjectFormulaTree>();
           // denomList.Add(new ObjectFormulaTree(plusOp, plusList));
            //list.Add(new ObjectFormulaTree(new ElementaryRoot(), denomList));
            list.Add(new ObjectFormulaTree(plusOp, plusList));
            return new ObjectFormulaTree(ElementaryFraction.Object, list);
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
                double a = (double)x[0];
                double b = (double)x[1];
                return Math.Atan2(a, b);
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
            if (symbol is BinaryFunctionSymbol)
            {
                return this;
            }
            return null;
        }
    }
}
