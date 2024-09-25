using System;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using FormulaEditor;
using FormulaEditor.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable;


namespace DataPerformer.Formula
{
    /// <summary>
    /// Variable measurement
    /// </summary>
    public class VariableMeasurement : IMeasurementHolder, 
        IObjectOperation, IPowered, IDerivationOperation, IOperationAcceptor, ITreeCreator
    {

        #region Fields

        IMeasurement measurement;

        object obj;

        internal IMeasurement Measurement
        {
            get => measurement;
            set => measurement = value;
        }
     

        ObjectFormulaTree derivation;

        IOperationAcceptor acceptor;

        IVariableDetector detector;

        ObjectFormulaTree tree;


        /// <summary>
        /// Symbol
        /// </summary>
        protected string symbol;

        IOperationDetector operationDetector;

        IOneVariableFunction func;

        OneVariableFunctionDetector funcwrapper;

     //   FuncReturn funcReturn;

        Table2D table2D;

        Table3D table3D;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">Symbol of variable</param>
        /// <param name="measurement">Measure</param>
        /// <param name="detector">Detector of variables</param>
        internal VariableMeasurement(string symbol, IMeasurement measurement, 
            IVariableDetector detector, object obj)
        {
            this.obj = obj;
            this.symbol = symbol;
            Measurement = measurement;
            this.detector = detector;
            object par = measurement.Type;
            if (par is IOneVariableFunction)
            {
                func = par as IOneVariableFunction;
                operationDetector = new OneVariableFunctionDetector(detector);
                funcwrapper = new OneVariableFunctionDetector(func);
            }
            else if (par is Table2D)
            {
                table2D = par as Table2D;
            }
            else if (par is Table3D)
            {
                table3D = par as Table3D;
            }
         /*!!!   else if (par is FuncReturn)
            {
                funcReturn = par as FuncReturn;
                //operationDetector = new FormulaEditor.Func.FuncDetector(detector,  )
            }*/
            else
            {
                acceptor = this;
            }
            tree = new ObjectFormulaTree(this, new List<ObjectFormulaTree>());
        }

        #endregion

        #region IObjectOperation Members

        object[] IObjectOperation.InputTypes
        {
            get { return new object[0]; }
        }

        object IObjectOperation.this[object[] x]
        {
            get { return Measurement.Parameter(); }
        }

        object IObjectOperation.ReturnType
        {
            get { return Measurement.Type; }
        }

        bool IPowered.IsPowered
        {
            get { return true; }
        }

        #endregion

        #region IDerivationOperation Members

        ObjectFormulaTree IDerivationOperation.Derivation(ObjectFormulaTree tree, string s)
        {
            if (derivation != null)
            {
                return derivation;
            }
            if (!(Measurement is IDerivation))
            {
                throw new Exception("VariableMeasure.Derivation");
            }
            IDerivation d = Measurement as IDerivation;
            VariableMeasurement mea = new VariableMeasurement("", d.Derivation, detector, obj);
            derivation = new ObjectFormulaTree(mea, new List<ObjectFormulaTree>());
            return derivation;
        }

        #endregion

        #region ITreeCreator Members

        ObjectFormulaTree ITreeCreator.Tree
        {
            get { return tree; }
        }

        #endregion

        #region IOperationAcceptor Members

        IObjectOperation IOperationAcceptor.Accept(object type)
        {
    /**!!!!        if (funcReturn != null)
            {
                IOperationDetector d = new FormulaEditor.Func.FuncDetector(funcReturn, measurement.Parameter());
            }
    */
            if (func != null)
            {
                func = Measurement.Parameter() as IOneVariableFunction;
                funcwrapper = new OneVariableFunctionDetector(func);
                return OneVariableFunctionDetector.Accept(funcwrapper, type);
            }
            if (table2D != null)
            {
                return table2D;
            }
            if (table3D != null)
            {
                return table3D;
            }
            return this;
        }

        #endregion


        /// <summary>
        /// Measurement
        /// </summary>
        IMeasurement IMeasurementHolder.Measurement
        {
            get => Measurement;
        }


        #region Members

        public override string ToString()
        {
            return obj.ToString() + base.ToString();
        }

        /// <summary>
        /// Sets a measurement
        /// </summary>
        /// <param name="measurement">The measurement</param>
        public void SetMeasurement(IMeasurement measurement)
        {
           Measurement = measurement;
        }

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol
        {
            get
            {
                return symbol;
            }
        }
  
        #endregion

     }
}