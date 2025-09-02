using System.Collections.Generic;
using System.Collections;
using DataPerformer.Interfaces;



namespace DataPerformer
{
    /// <summary>
    /// Structured formula calculator
    /// </summary>
    public class FormulaStructuredCalculator : IStructuredCalculation
    {
        /// <summary>
        /// Selection
        /// </summary>
        private IArgumentSelection selection;

        /// <summary>
        /// Formula
        /// </summary>
        private VectorFormulaConsumer formula;
        private IMeasurements measurements;
        private int vectorDimension;
        private string[] variables;
        private ArrayList parameters;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="selection">Selection</param>
        /// <param name="formula">Formula</param>
        public FormulaStructuredCalculator(IArgumentSelection selection, VectorFormulaConsumer formula)
        {
            this.formula = formula;
            this.selection = selection;
            vectorDimension = selection.VectorDimension;
            measurements = formula;
            if (vectorDimension != measurements.Count)
            {
                throw new ErrorHandler.OwnException("Illegal dimension");
            }
            variables = selection.Variables;
            IList<string> l = formula.AliasNames;
            parameters = new ArrayList();
            foreach (string n in l)
            {
                parameters.Add(n);
            }
            foreach (string str in variables)
            {
                if (!parameters.Contains(str))
                {
                    throw new ErrorHandler.OwnException("Illegal variable");
                }
                parameters.Remove(str);
            }
            parameters.Sort();
       }

        /// <summary>
        /// Calculates parameters
        /// </summary>
        /// <param name="x">Input</param>
        /// <param name="selection">Selection</param>
        /// <param name="y">Output</param>
        public void Calculate(double[] x, IStructuredSelection selection, double?[] y)
        {
            for (int i = 0; i < parameters.Count; i++)
            {
                string s = parameters[i] as string;
                formula[s] = x[i];
            }
            for (int i = 0; i < this.selection.PointsCount; i++)
            {
                int k = i * vectorDimension;
                foreach (string s in variables)
                {
                    formula[s] = this.selection[i, s];
                }
                formula.Reset();
                (formula as IMeasurements).UpdateMeasurements();
                for (int j = 0; j < measurements.Count; j++)
                {
                    y[k + j] = (double)measurements[j].Parameter();
                }
            }
        }

        /// <summary>
        /// Dimension of estimated vector
        /// </summary>
        public int Dimension
        {
            get
            {
                return parameters.Count;
            }
        }

        /// <summary>
        /// Parametes
        /// </summary>
        public ArrayList Parameters
        {
            get
            {
                return parameters;
            }
        }

        /// <summary>
        /// Sets i th parameter
        /// </summary>
        public double this[string s]
        {
            set
            {
                formula[s] = value;
            }
            get
            {
                return (double) formula[s];
            }
        }
    }
}
