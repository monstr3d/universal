﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;
using BaseTypes.Interfaces;
using Diagram.UI.Interfaces;
using DataPerformer.Interfaces;
using FormulaEditor;
using FormulaEditor.Interfaces;

namespace DataPerformer.Formula
{
    /// <summary>
    /// State variable
    /// </summary>
    public class Variable :  IMeasurementHolder,
        IObjectOperation, IPowered, IOperationAcceptor, IMeasurement, IDerivation, IDerivationOperation, IStack
    {

        #region Fields

        private Stack<double> stack = new Stack<double>();

        const Double a = 0;

        double value;

        FormulaMeasurement derivation;

        FormulaMeasurementDerivation temp;

        ObjectFormulaTree tree;

        Func<object> par;


        private string symbol;

        protected AssociatedAddition addition;

        #endregion

        #region Ctor

        public Variable(string symbol, AssociatedAddition addition)
        {
            this.symbol = symbol;
            par = GetValue;
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
            get { return par; }
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



        #region Members


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
            IList<IMeasurement> list)
        {
            string dn = "D" + symbol;
            this.tree = tree;
            IDistribution d = DeltaFunction.GetDistribution(tree);
            if (next)
            {
                if (d != null)
                {
                    temp = new FormulaMeasurementDerivationDistribution(tree, null, symbol, addition);
                }
                else
                {
                    temp = new FormulaMeasurementDerivation(tree, null, symbol, addition);
                }
                derivation = temp;
                list.Add(derivation);
                return;
            }
            if (d != null)
            {
                derivation = new FormulaMeasurementDistribution(tree, symbol, addition);
            }
            else
            {
                derivation = new FormulaMeasurement(tree, symbol, addition);
            }
            list.Add(derivation);
            return;
        }

        internal void Iterate(bool next)
        {
            AssociatedAddition aa = FormulaMeasurementDerivation.Create(addition);
            temp = temp.Iterate(next, aa);
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
        void Update()
        {
            derivation.Update();
        }

        private object GetValue()
        {
            return value;
        }

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
    }
}
