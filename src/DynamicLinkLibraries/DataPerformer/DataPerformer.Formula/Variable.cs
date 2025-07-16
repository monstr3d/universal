using System;
using System.Collections.Generic;

using CategoryTheory;

using BaseTypes.Interfaces;

using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;

using FormulaEditor;
using FormulaEditor.Interfaces;
using NamedTree;

namespace DataPerformer.Formula
{
    /// <summary>
    /// State variable
    /// </summary>
    public class Variable :  IMeasurementHolder, IAssociatedObject,
        IObjectOperation, IPowered, IOperationAcceptor, 
        IMeasurement, IDerivation, IDerivationOperation, IStack
    {

        #region Fields

        private Stack<double> stack = new Stack<double>();

        object obj;

        const double a = 0;

        double value;

        FormulaMeasurement derivation;

        FormulaMeasurementDerivation temp;

        ObjectFormulaTree tree;

        Func<object> parameter;


        private string symbol;

        protected AssociatedAddition addition;

        #endregion

        #region Ctor

        public Variable(string symbol, AssociatedAddition addition, object obj)
        {
            this.obj = obj;
            this.symbol = symbol;
            parameter = GetValue;
            this.addition = addition;
        }

        #endregion

        #region IObjectOperation Members

        object[] IObjectOperation.InputTypes
        {
            get { return new object[0]; }
        }

        object IObjectOperation.this[object[] x]
        {
            get { return value; }
        }

        object IObjectOperation.ReturnType
        {
            get { return a; }
        }

        bool IPowered.IsPowered
        {
            get { return true; }
        }

        #endregion

        #region IOperationAcceptor Members

        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            return this;
        }

        #endregion

        #region IDerivation Members

        IMeasurement IDerivation.Derivation
        {
            get { return derivation; }
        }

        #endregion

        #region IDerivationOperation Members

        ObjectFormulaTree IDerivationOperation.Derivation(ObjectFormulaTree tree, string s)
        {
            if (s.Equals("d/dt"))
            {
                return this.tree;
            }
            return null;
        }

        #endregion

        #region IMeasurement Members

        Func<object> IMeasurement.Parameter
        {
            get { return parameter; }
        }

        string IMeasurement.Name
        {
            get { return symbol; }
        }

        object IMeasurement.Type
        {
            get { return a; }
        }

        #endregion

        #region IMeasurementHolder Members

        IMeasurement IMeasurementHolder.Measurement => this;

        #endregion

        #region IStack Members

        void IStack.Push()
        {
            stack.Push(value);
        }

        void IStack.Pop()
        {
            value = stack.Pop();
        }

        #endregion

        #region Members

        public override string ToString()
        {
            return obj.ToString() + base.ToString();
        }


        internal string String
        {
            get
            {
                return symbol;
            }
        }

        internal void SetTree(ObjectFormulaTree tree,
            bool next,
            AssociatedAddition addition,
            IList<IMeasurement> list, object obj)
        {
            string dn = "D" + symbol;
            this.tree = tree;
            IDistribution d = DeltaFunction.GetDistribution(tree);
            if (next)
            {
                if (d != null)
                {
                    temp = new FormulaMeasurementDerivationDistribution(tree, null, symbol, addition, obj);
                }
                else
                {
                    temp = new FormulaMeasurementDerivation(tree, null, symbol, addition, obj);
                }
                derivation = temp;
                list.Add(derivation);
                return;
            }
            if (d != null)
            {
                derivation = new FormulaMeasurementDistribution(tree, symbol, addition, obj);
            }
            else
            {
                derivation = new FormulaMeasurement(tree, symbol, addition, obj);
            }
            list.Add(derivation);
            return;
        }

        internal void Iterate(bool next)
        {
            AssociatedAddition aa = FormulaMeasurementDerivation.Create(addition);
            temp = temp.Iterate(next, aa, obj);
        }

        /// <summary>
        /// Symbol of variable
        /// </summary>
        public char Symbol
        {
            get
            {
                return symbol[0];
            }
        }

        /// <summary>
        /// Value of variable
        /// </summary>
        public double Value
        {
            set
            {
                this.value = value;
            }
        }

        object IAssociatedObject.Object
        {
            get => obj; 
            set { }
        }

        void Update()
        {
            derivation.Update();
        }

        private object GetValue()
        {
            return value;
        }

        #endregion

    }
}
