using System;
using System.Collections.Generic;
using System.Text;

using AnalyticPolynom;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.DifferentialEquationProcessors;
using DataPerformer.Portable.Measurements;

namespace DataPerformer
{
    /// <summary>
    /// Adams processor for ordinary differential equations
    /// </summary>
    public class AdamsProcessor : DifferentialEquationProcessor
    {

        /// <summary>
        /// Values of previous steps
        /// </summary>
        private double[,] prevDeri;

        /// <summary>
        /// Values of parameters in previous ptep
        /// </summary>
        private double[] prevStep;

        /// <summary>
        /// Values of old step
        /// </summary>
        private double[] oldStep;

        /// <summary>
        /// Counter of steps
        /// </summary>
        private int stepCount;

        /// <summary>
        /// Counter of parameters in equations
        /// </summary>
        private int paramCount;

        /// <summary>
        /// Additional Runge - Kutta processor
        /// </summary>
        private RungeProcessor runge = RungeProcessor.Processor;

        /// <summary>
        /// Singleton
        /// </summary>
        new static public readonly AdamsProcessor Processor = new AdamsProcessor();

        /// <summary>
        /// The massive of coefficients
        /// </summary>
        private double[] prCoeff;

        /// <summary>
        /// Accurate coefficient
        /// </summary>
        private double[] aqCoeff;

        /// <summary>
        /// The order of precision
        /// </summary>
        private int order;

        /// <summary>
        /// Constructor
        /// </summary>
        protected AdamsProcessor()
        {
        }

        /// <summary>
        /// Order
        /// </summary>
        public int Order
        {
            set
            {
                order = value;
            }
        }

        /// <summary>
        /// Sets root data consumers
        /// </summary>
        /// <param name="consumers">Consumers to set</param>
        public override void Set(List<IDataConsumer> consumers)
        {
            base.Set(consumers);
            int n = Dim;
            stepCount = 0;
            prevStep = new double[n];
            oldStep = new Double[n];
            prevDeri = new double[n, order];
            prCoeff = new double[order];
            aqCoeff = new Double[order];
            RealPolynom pNom = new RealPolynom(1);
            RealPolynom mult = new RealPolynom(2);
            mult[0] = 0;
            mult[1] = 1;
            for (int i = 0; i < order; i++)
            {
                pNom = new RealPolynom(1);
                pNom[0] = 1;
                for (int j = 0; j < order; j++)
                {
                    if (i != j)
                    {
                        mult[0] = j;
                        pNom *= mult / (j - i);
                    }
                }
                pNom = ~pNom;
                prCoeff[i] = pNom[(double)(1)];
                aqCoeff[i] = -pNom[(double)(-1)];
            }
            runge.Set(consumers);
        }

        /// <summary>
        /// Updates dimension
        /// </summary>
        public override void UpdateDimension()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Creates new processor
        /// </summary>
        public override IDifferentialEquationProcessor New
        {
            get
            {
                return new AdamsProcessor();
            }
        }


        /// <summary>
        /// Performs step of integration
        /// </summary>
        /// <param name="t0">Step start</param>
        /// <param name="t1">Step finish</param>
        public override void Step(double t0, double t1)
        {
            isBusy = true;
            paramCount = 0;
            if (stepCount < order)
            {
                runge.Step(t0, t1);
                foreach (IMeasurements m in equations)
                {
                    runge.Step(t0, t1);
                    IDifferentialEquationSolver s = m as IDifferentialEquationSolver;
                    s.CalculateDerivations();
                    for (int j = 0; j < m.Count; j++)
                    {
                        IDerivation der = m[j] as IDerivation;
                        prevDeri[paramCount, stepCount] = der.Derivation.ToDouble();
                        prevStep[paramCount] = m[j].ToDouble();
                        ++paramCount;
                    }
                    s.CopyVariablesToSolver(paramCount - m.Count, prevStep);
                    ++stepCount;
                }
                paramCount = 0;
            }

            else
            {
                foreach (IMeasurements m in equations)
                {
                    IDifferentialEquationSolver s = m as IDifferentialEquationSolver;
                    s.CalculateDerivations();
                    for (int j = 0; j < m.Count; j++)
                    {
                        prevStep[paramCount] = (double)m[j].Parameter();
                        oldStep[paramCount] = prevStep[paramCount];
                        for (int i = 0; i < order; i++)
                        {
                            prevStep[paramCount] += prevDeri[paramCount, i] * prCoeff[i] * (t1 - t0);
                        }
                        ++paramCount;
                    }
                    s.CopyVariablesToSolver(paramCount - m.Count, prevStep);
                }

                paramCount = 0;
                foreach (IMeasurements m in equations)
                {
                    for (int j = 0; j < m.Count; j++)
                    {
                        for (int i = 0; i < order - 1; i++)
                        {
                            prevDeri[paramCount, i] = prevDeri[paramCount, i + 1];
                        }
                        ++paramCount;
                    }
                }

                paramCount = 0;
                foreach (IMeasurements m in equations)
                {
                    IDifferentialEquationSolver s = m as IDifferentialEquationSolver;
                    s.CalculateDerivations();
                    for (int j = 0; j < m.Count; j++)
                    {
                        IDerivation der = m[j] as IDerivation;
                        prevDeri[paramCount, order - 1] = der.Derivation.ToDouble();
                        ++paramCount;
                    }
                }
                paramCount = 0;


                foreach (IMeasurements m in equations)
                {
                    IDifferentialEquationSolver s = m as IDifferentialEquationSolver;
                    for (int j = 0; j < m.Count; j++)
                    {
                        prevStep[paramCount] = oldStep[paramCount];
                        for (int i = 0; i < order; i++)
                        {
                            prevStep[paramCount] += prevDeri[paramCount, i] * aqCoeff[i] * (t1 - t0);
                        }
                        ++paramCount;
                    }
                    s.CopyVariablesToSolver(paramCount - m.Count, prevStep);
                }
                ++stepCount;
            }
            isBusy = false;
        }
    }
}
