using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Dirac delta function
    /// </summary>
    public class DeltaFunction : ElementaryFunctionOperation, IDistribution
    {

        #region Fields

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        static private readonly string error = "Delta function error";

        /// <summary>
        /// Return result
        /// </summary>
        static private readonly double result = 0;

        /// <summary>
        /// Temporary previous time
        /// </summary>
        double prevTemp;

        /// <summary>
        /// Previous time
        /// </summary>
        double prev;
        
        /// <summary>
        /// IsReset
        /// </summary>
        bool isReset;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public DeltaFunction()
            : base('\u03B4')
        {
        }

        #endregion

        /// <summary>
        /// IObjectOperation overriden
        /// </summary>
        /// <param name="x">Argument</param>
        /// <returns>Result of operation</returns>
        public override object this[object[] x]
        {
            get
            {
                if (isReset)
                {
                    prev = (double)x[0];
                }
                else
                {
                    prevTemp = (double)x[0];
                }
                isReset = false;
                return result;
            }
        }

        /// <summary>
        /// Creates distribution from formula tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>The distribution</returns>
        static public IDistribution GetDistribution(ObjectFormulaTree tree)
        {
            if (!CheckDelta(tree))
            {
                return null;
            }
            return new FormulaDistribution(tree);
        }

        /// <summary>
        /// Resets distributons of tree
        /// </summary>
        /// <param name="tree">The tree</param>
        static public void Reset(ObjectFormulaTree tree)
        {
            IObjectOperation op = tree.Operation;
            if (op is IDistribution)
            {
                IDistribution d = op as IDistribution;
                d.Reset();
                return;
            }
            for (int i = 0; i < tree.Count; i++)
            {
                Reset(tree[i]);
            }
        }

        /// <summary>
        /// Checks whether tree contains distributions
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>True if contains and false otherwise</returns>
        static bool CheckDelta(ObjectFormulaTree tree)
        {
            int count = 0;
            if (tree == null)
            {
                return false;
            }
            if (tree.Operation is IDistribution)
            {
                return true;
            }
            bool b = false;
            for (int i = 0; i < tree.Count; i++)
            {
                ObjectFormulaTree t = tree[i];
                if (t == null)
                {
                    continue;
                }
                b |= CheckDelta(t);
                if (t.Operation is IDistribution)
                {
                    ++count;
                }
            }
            IObjectOperation op = tree.Operation;
            if (b)
            {
                if (op.InputTypes.Length == 2)
                {
                    if (op is ElementaryBinaryOperation)
                    {
                        ElementaryBinaryOperation bop = op as ElementaryBinaryOperation;
                        char s = bop.Symbol;
                        if (s != '+' & s != '-' & s != '*')
                        {
                            throwError(); 
                        }
                        if (count > 1 & s == '*')
                        {
                            throwError();   
                        }
                    }
                    else if (op is ElementaryFunctionOperation)
                    {
                        ElementaryFunctionOperation eop = op as ElementaryFunctionOperation;
                        char c = eop.Symbol;
                        if (c != '!' & c != '-')
                        {
                            throwError();
                        }
                    }
                    else
                    {
                        throwError();
                    }
                }
            }
            return b | count > 0;
        }

        /// <summary>
        /// Integral of tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>The integral</returns>
        public static double Integral(ObjectFormulaTree tree)
        {
            IObjectOperation op = tree.Operation;
            if (op is IDistribution)
            {
                IDistribution df = op as IDistribution;
                return df.Integral;
            }
            if (op is ElementaryBinaryOperation)
            {
                ElementaryBinaryOperation ebo = op as ElementaryBinaryOperation;
                char c = ebo.Symbol;
                if (c == '+')
                {
                    return getSum(tree);
                }
                if (c == '-')
                {
                    return getDiff(tree);
                }
                if (c == '*')
                {
                    return getMult(tree);
                }
            }
            if (op is ElementaryFunctionOperation)
            {
                ElementaryFunctionOperation efo = op as ElementaryFunctionOperation;
                char c = efo.Symbol;
                double a = Integral(tree[0]);
                if (c == '?')
                {
                    return a;
                }
                if (c == '-')
                {
                    return -a;
                }
            }
            return 0;
        }

        /// <summary>
        /// Gets integral of multiplication
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>The integral</returns>
        private static double getMult(ObjectFormulaTree tree)
        {
            double a = Integral(tree[0]);
            double b = Integral(tree[1]);
            if (a != 0)
            {
                return a * (double)tree[1].Result;
            }
            if (b != 0)
            {
                return b * (double)tree[0].Result;
            }
            return 0;
        }

        /// <summary>
        /// Gets integral of the sum tree
        /// </summary>
        /// <param name="tree">The sum tree</param>
        /// <returns>The integral</returns>
        private static double getSum(ObjectFormulaTree tree)
        {
            return Integral(tree[0]) + Integral(tree[1]);
        }

        /// <summary>
        /// Gets integral of the substract tree
        /// </summary>
        /// <param name="tree">The substract tree</param>
        /// <returns>The integral</returns>
        private static double getDiff(ObjectFormulaTree tree)
        {
            return Integral(tree[0]) - Integral(tree[1]);
        }


        /// <summary>
        /// Throws error
        /// </summary>
        private static void throwError()
        {
            throw new Exception(error);
        }

        #region IDistribution Members

        void IDistribution.Reset()
        {
            isReset = true;
        }

        double IDistribution.Integral
        {
            get 
            {
                if (isReset)
                {
                    return 0;
                }
                double p = prev;
                double c = prevTemp;
                if (p < 0 & c >= 0)
                {
                    return 1;
                }
                if (p > 0 & c <= 0)
                {
                    return -1;
                }
                return 0;
            }
        }

        #endregion

        /// <summary>
        /// Distribution of formula
        /// </summary>
        class FormulaDistribution : IDistribution
        {
            #region Fields

            /// <summary>
            /// The tree
            /// </summary>
            private ObjectFormulaTree tree;

            #endregion

            #region Ctor

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="tree">The tree</param>
            internal FormulaDistribution(ObjectFormulaTree tree)
            {
                this.tree = tree;
            }

            #endregion

            #region IDistribution Members


            void IDistribution.Reset()
            {
                DeltaFunction.Reset(tree);
            }

            double IDistribution.Integral
            {
                get { return DeltaFunction.Integral(tree); }
            }



            #endregion
        }

    }
}
