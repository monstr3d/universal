using System;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

using ErrorHandler;

namespace FormulaEditor
{
    /// <summary>
    /// Elementary fraction
    /// </summary>
    public class ElementaryFraction : 
        IMultiVariableOperationAcceptor, 
        IMultiVariableOperation,
        IFormulaCreatorOperation, IDerivationOperation
    {

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly ElementaryFraction Object = new ElementaryFraction();

        /// <summary>
        /// Return type
        /// </summary>
        private const Double a = 0;

        private Func<object[], object> calc;

        private static readonly object[] types = new object[] { (double)0, (double)0 };


        /// <summary>
        /// Constructor
        /// </summary>
        private ElementaryFraction()
        {
            calc = standard;
        }



        /// <summary>
        /// Calculates derivation
        /// </summary>
        /// <param name="tree">The function for derivation calculation</param>
        /// <param name="variableName">Derivation string</param>
        /// <returns>The derivation</returns>
        public ObjectFormulaTree Derivation(ObjectFormulaTree tree, string variableName)
        {
            Double a = 0;
            bool[] b = new bool[] { false, false };
            ObjectFormulaTree[] fc = new ObjectFormulaTree[2];
            ObjectFormulaTree[] fd = new ObjectFormulaTree[2];
            for (int i = 0; i < 2; i++)
            {
                fc[i] = tree[1 - i];
                fd[i] = fc[i].Derivation(variableName);
                b[i] = ZeroPerformer.IsZero(fd[i]);
            }
            if (b[0] & b[1])
            {
                return ElementaryRealConstant.RealZero;
            }
            IObjectOperation nom = new ElementaryBinaryOperation('-', new object[]{ a, a});
            List<ObjectFormulaTree> nomList = new List<ObjectFormulaTree>();
            for (int i = 0; i < 2; i++)
            {
                List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
                l.Add(fd[1 - i]);//.Clone() as ObjectFormulaTree);
                l.Add(fc[i]);//.Clone() as ObjectFormulaTree);
                IObjectOperation o = new ElementaryBinaryOperation('*', new object[] { a, a});
                nomList.Add(new ObjectFormulaTree(o, l));
            }
            List<ObjectFormulaTree> list = new List<ObjectFormulaTree>();
            if (b[0] | b[1])
            {
                for (int i = 0; i < 2; i++)
                {
                    if (b[i])
                    {
                        List<ObjectFormulaTree> lt = new List<ObjectFormulaTree>();
                        lt.Add(nomList[i]);
                        list.Add(new ObjectFormulaTree(new ElementaryFunctionOperation('-'), lt));
                    }
                }
            }
            else
            {
                list.Add(new ObjectFormulaTree(nom, nomList));
            }
            IObjectOperation square = ElementaryFunctionsCreator.Object.GetPowerOperation(a, a);
            List<ObjectFormulaTree> squareList = new List<ObjectFormulaTree>();
            squareList.Add(fc[0]);
            squareList.Add(new ObjectFormulaTree(new ElementaryRealConstant(2), new List<ObjectFormulaTree>()));
            list.Add(new ObjectFormulaTree(square, squareList));
            if (list.Count != 2)
            {
               // list = list;
            }
            return new ObjectFormulaTree(new ElementaryFraction(), list);
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
            MathSymbol sym = new FractionSymbol();
            sym.Append(form);
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
                return calc(x);
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
            if (types.Length < 2)
            {
                throw new OwnException("Incomplete fraction");
            }
            for (int i = 0; i < types.Length; i++)
            {
                if (!types[i].Equals(a))
                {
                    ElementaryFraction f = new ElementaryFraction();
                    Func<object[], object> c = f.CreateCalculator(types);
                    if (c == null)
                    {
                        return null;
                    }
                    f.calc = c;
                    return f;
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
            if (symbol is FractionSymbol)
            {
                return this;
            }
            return null;
        }

        Func<object[], object> CreateCalculator(object[] types)
        {
            Double a = 0;
            Int32 it = 0;
            if (types[0].Equals(it) & types[1].Equals(a))
            {
                return i32_standard;
            }
            if (types[0].Equals(a) & types[1].Equals(it))
            {
                return standard_i32;
            }
            if (types[0].Equals(it) & types[1].Equals(it))
            {
                return i32_standard_i32;
            }
            return null;
        }


        object standard(object[] x)
        {
            double a = (double)x[0];
            double b = (double)x[1];
            return a / b;
        }

        object i32_standard(object[] x)
        {
            int a = (int)x[0];
            double b = (double)x[1];
            return (double)a / b;
        }

        object standard_i32(object[] x)
        {
            double a = (double)x[0];
            int b = (int)x[1];
            return a / (double)b;
        }
        
        object i32_standard_i32(object[] x)
        {
            int a = (int)x[0];
            int b = (int)x[1];
            return (double)a / (double)b;
        }


    }
}
