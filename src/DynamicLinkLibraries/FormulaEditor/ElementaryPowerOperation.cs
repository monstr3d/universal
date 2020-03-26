using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Elementary power operation
    /// </summary>
    public class ElementaryPowerOperation : IObjectOperation, ICloneable, IDerivationOperation,
        IFormulaCreatorOperation
    {

        /// <summary>
        /// Type of operation
        /// </summary>
        private const Double a = 0;

        private static readonly object[] types = new object[] { (double)0, (double)0 };


        /// <summary>
        /// Type of value
        /// </summary>
        private object valType;

        /// <summary>
        /// Type of pow
        /// </summary>
        private object powType;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valType"></param>
        /// <param name="powType"></param>
        public ElementaryPowerOperation(object valType, object powType)
        {
            this.valType = valType;
            this.powType = powType;
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
            MathFormula p = FormulaCreator.CreateFormula(tree[1], (byte)((int)level + 1), sizes);
            IObjectOperation op = tree[0].Operation;
            if (op.IsPowered())
            {
                if (op is ElementaryFunctionOperation)
                {
                    f.First[0] = p;
                }
                else
                {
                    f.Last[0] = p;
                }
                return f;
            }
            MathFormula form = new MathFormula(level, sizes);
            MathSymbol s = new BracketsSymbol();
            s.Append(form);
            form.First[0] = p;
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
            Double a = 0;
            ObjectFormulaTree[] fc = new ObjectFormulaTree[2];
            ObjectFormulaTree[] fd = new ObjectFormulaTree[2];
            bool[] b = new bool[] { false, false };
            for (int i = 0; i < 2; i++)
            {
                fc[i] = tree[i];//.Clone() as ObjectFormulaTree;
                fd[i] = fc[i].Derivation(variableName);
                bool bb = ZeroPerformer.IsZero(fd[i]);
                b[i] = bb;
                if (!bb)
                {
                   // glo = true;
                }
            }
            if (b[1])
            {
                double rs = (double)fc[1].Result;
                if (rs == 1)
                {
                    return fd[0];
                }
            }
            List<ObjectFormulaTree> mainList = new List<ObjectFormulaTree>();
            IObjectOperation mainOperation = new ElementaryBinaryOperation('+', new object[]{a, a});
            List<ObjectFormulaTree> firstList = new List<ObjectFormulaTree>();
            IObjectOperation firstOperation = new ElementaryBinaryOperation('*', new object[] { a, a });
            List<ObjectFormulaTree> secondList = new List<ObjectFormulaTree>();
            IObjectOperation secondOperation = new ElementaryBinaryOperation('*', new object[] { a, a });
            List<ObjectFormulaTree> firstFirstList = new List<ObjectFormulaTree>();
            firstFirstList.Add(fc[1]);
            IObjectOperation firstFirstOperation = new ElementaryBinaryOperation('*', new object[] { a, a });
            IObjectOperation firstFirstSecondOperation = new ElementaryPowerOperation(valType, powType);
            List<ObjectFormulaTree> firstFirstSecondList = new List<ObjectFormulaTree>();
            firstFirstSecondList.Add(fc[0]);
            List<ObjectFormulaTree> firstFirstSecondSecondList = new List<ObjectFormulaTree>();
            IObjectOperation firstFirstSecondSecondOperation = new ElementaryBinaryOperation('-', new object[] { a, a });
            ObjectFormulaTree fcd = fd[1];
            firstFirstSecondSecondList.Add(fc[1]);
            IObjectOperation firstFirstSecondSecondSecondOperation = new ElementaryRealConstant(1);
            ObjectFormulaTree firstFirstSecondSecondSecondTree =
                new ObjectFormulaTree(firstFirstSecondSecondSecondOperation, new List<ObjectFormulaTree>());
            firstFirstSecondSecondList.Add(firstFirstSecondSecondSecondTree);
            ObjectFormulaTree firstFirstSecondSecondTree = null;
            bool unityDeg = false;
            if (ZeroPerformer.IsZero(fd[1]))
            {
                double f2d = (double)tree[1].Result - 1;
                if (f2d == 1)
                {
                    unityDeg = true;
                }
                ElementaryRealConstant erc = new ElementaryRealConstant(f2d);
                firstFirstSecondSecondTree = new ObjectFormulaTree(erc, new List<ObjectFormulaTree>());
            }
            else
            {
                firstFirstSecondSecondTree =
                    new ObjectFormulaTree(firstFirstSecondSecondOperation, firstFirstSecondSecondList);
            }
            firstFirstSecondList.Add(firstFirstSecondSecondTree);
            ObjectFormulaTree firstFirstSecondTree = null;
            if (unityDeg)
            {
                firstFirstSecondTree = fc[0];
            }
            else
            {
                firstFirstSecondTree =
                    new ObjectFormulaTree(firstFirstSecondOperation, firstFirstSecondList);
            }
            firstFirstList.Add(firstFirstSecondTree);
            ObjectFormulaTree firstFirstTree = new ObjectFormulaTree(firstFirstOperation, firstFirstList);
            firstList.Add(firstFirstTree);
            firstList.Add(fd[0]);
            ObjectFormulaTree firstTree = new ObjectFormulaTree(firstOperation, firstList);
            mainList.Add(firstTree);

            // Second part

            IObjectOperation secondFirstOperation = new ElementaryBinaryOperation('*', new object[] { a, a });
            List<ObjectFormulaTree> secondFirstList = new List<ObjectFormulaTree>();
            IObjectOperation secondFirstFirstOperation = new ElementaryFunctionOperation('l');
            List<ObjectFormulaTree> secondFirstFirstList = new List<ObjectFormulaTree>();
            secondFirstFirstList.Add(fc[0]);//.Clone() as ObjectFormulaTree);
            ObjectFormulaTree secondFirstFirstTree =
                new ObjectFormulaTree(secondFirstFirstOperation, secondFirstFirstList);
            secondFirstList.Add(secondFirstFirstTree);
            secondFirstList.Add(tree);//.Clone() as ObjectFormulaTree);
            ObjectFormulaTree secondFirstTree = new ObjectFormulaTree(secondFirstOperation, secondFirstList);
            secondList.Add(secondFirstTree);
            secondList.Add(fd[1]);
            ObjectFormulaTree secondTree = new ObjectFormulaTree(secondOperation, secondList);
            mainList.Add(secondTree);
            if (b[0] & b[1])
            {
                return ElementaryRealConstant.RealZero;
            }
            for (int i = 0; i < 2; i++)
            {
                if (b[i])
                {
                    return mainList[1 - i];
                }
            }
            return new ObjectFormulaTree(mainOperation, mainList);
        }



        /// <summary>
        /// ICloneable interface implementation
        /// </summary>
        /// <returns>Clone of itself</returns>
        public object Clone()
        {
            return new ElementaryPowerOperation(valType, powType);
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
                return calculate(x);
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
        /// Calculates itself
        /// </summary>
        /// <param name="x">Arguments</param>
        /// <returns>Result of calculation</returns>
        private double calculate(object[] x)
        {
            double a = (double)x[0];
            if (a == 0)
            {
                return 0;
            }
            double b = (double)x[1];
            return Math.Pow(a, b);
        }
    }
}
