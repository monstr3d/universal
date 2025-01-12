
using BaseTypes.Interfaces;
using DataPerformer.Interfaces;
using DataPerformer.Portable.Wrappers;

namespace DataPerformer.Portable.DifferentialEquationProcessors
{
    /// <summary>
    ///  Runge–Kutta processor for solving ordinary differential equations system 
    /// </summary>
    public class RungeProcessor : DifferentialEquationProcessor
    {
        /// <summary>
        /// Coefficients of method
        /// </summary>
        static readonly double[] a = { 0.5, 0.5, 1.0, 1.0, 0.5 };


        /// <summary>
        /// Auxiliary buffer variable
        /// </summary>
        private double[] z;

        /// <summary>
        /// Auxiliary buffer variable
        /// </summary>
        private double[] w;

        /// <summary>
        /// Auxiliary buffer variable
        /// </summary>
        private double[] f;

        CommonWrapper wrapper = new();

        /// <summary>
        /// Auxiliary buffer variable
        /// </summary>
        private double[,] k;


        /// <summary>
        /// Singleton
        /// </summary>
        new static public readonly RungeProcessor Processor = new RungeProcessor();


        /// <summary>
        /// Default constructor
        /// </summary>
        protected RungeProcessor()
        {

        }

        /// <summary>
        /// Performs step of integration
        /// </summary>
        /// <param name="t0">Step start</param>
        /// <param name="t1">Step finish</param>
        public override void Step(double t0, double t1)
        {
            isBusy = true;
            if (Dim == 0)
            {
                return;
            }
            double dt = t1 - t0;
            int i = 0;
            foreach (IMeasurements m in equations)
            {
                IDifferentialEquationSolver s = m as IDifferentialEquationSolver;
                m.UpdateMeasurements(true);
                int n = s.GetVariablesCount();
                for (int j = 0; j < n; j++)
                {
                    w[i] = ToDouble(m[j]);
                    f[i] = w[i];
                    ++i;
                }
                s.CopyVariablesToSolver(i - s.GetVariablesCount(), w);
            }
            double t = t0;
            timeProvider.Time = t;
            i = 0;
            foreach (IMeasurements m in equations)
            {
                IDifferentialEquationSolver s = m as IDifferentialEquationSolver;
                s.CalculateDerivations();
                for (int j = 0; j < s.GetVariablesCount(); j++)
                {
                    IDerivation der = m[j] as IDerivation;
                    z[i] = ToDouble(der.Derivation);
                    k[0, i] = z[i] * dt;
                    w[i] = f[i] + 0.5 * k[0, i];
                    ++i;
                }
                s.CopyVariablesToSolver(i - s.GetVariablesCount(), w);
            }
            t = t0 + 0.5 * dt;
            timeProvider.Time = t;
            i = 0;
            foreach (IMeasurements m in equations)
            {
                IDifferentialEquationSolver s = m as IDifferentialEquationSolver;
                s.CalculateDerivations();
                for (int j = 0; j < s.GetVariablesCount(); j++)
                {
                    IDerivation der = m[j] as IDerivation;
                    z[i] = ToDouble(der.Derivation);
                    k[1, i] = z[i] * dt;
                    w[i] = f[i] + 0.5 * k[1, i];
                    ++i;
                }
                s.CopyVariablesToSolver(i - s.GetVariablesCount(), w);
            }
            t = t0 + 0.5 * dt;
            timeProvider.Time = t;
            i = 0;
            foreach (IMeasurements m in equations)
            {
                IDifferentialEquationSolver s = m as IDifferentialEquationSolver;
                s.CalculateDerivations();
                for (int j = 0; j < s.GetVariablesCount(); j++)
                {
                    IDerivation der = m[j] as IDerivation;
                    z[i] = der.Derivation.ToDouble();
                    k[2, i] = z[i] * dt;
                    w[i] = f[i] + k[2, i];
                    ++i;
                }
                s.CopyVariablesToSolver(i - s.GetVariablesCount(), w);
            }
            t = t0 + dt;
            timeProvider.Time = t;
            i = 0;
            foreach (IMeasurements m in equations)
            {
                IDifferentialEquationSolver s = m as IDifferentialEquationSolver;
                s.CalculateDerivations();
                for (int j = 0; j < s.GetVariablesCount(); j++)
                {
                    IDerivation der = m[j] as IDerivation;
                    z[i] = ToDouble(der.Derivation);
                    k[3, i] = z[i] * dt;
                    ++i;
                }
            }
            i = 0;
            foreach (IMeasurements m in equations)
            {
                IDifferentialEquationSolver s = m as IDifferentialEquationSolver;
                for (int j = 0; j < s.GetVariablesCount(); j++)
                {
                    f[i] += (k[0, i] + 2 * k[1, i] + 2 * k[2, i] + k[3, i]) / 6;
                    ++i;
                }
                s.CopyVariablesToSolver(i - s.GetVariablesCount(), f);
            }
            i = 0;
            foreach (IMeasurements m in equations)
            {
                IDifferentialEquationSolver s = m as IDifferentialEquationSolver;
                for (int j = 0; j < s.GetVariablesCount(); j++)
                {
                    IMeasurement measure = m[j];
                    IDerivation d = m[j] as IDerivation;
                    IMeasurement der = d.Derivation;
                    if (!(der is IDistribution))
                    {
                        ++i;
                        continue;
                    }
                    IDistribution distr = der as IDistribution;
                    f[i] += distr.Integral;
                    distr.Reset();
                    ++i;
                }
                s.CopyVariablesToSolver(i - s.GetVariablesCount(), f);
            }
            isBusy = false;
        }

        /// <summary>
        /// Sets consumers
        /// </summary>
        /// <param name="collection">Consumers</param>
        /// <returns>Lists of parameters</returns>
        public override void Set(object collection)
        {
            base.Set(collection);
            UpdateDimension();
        }

        /// <summary>
        /// Updates dimension
        /// </summary>
        public override void UpdateDimension()
        {
            int n = Dim;
            w = new double[n];
            z = new double[n];
            f = new double[n];
            k = new double[4, n];
        }

        /// <summary>
        /// Creates new processor
        /// </summary>
        public override IDifferentialEquationProcessor New
        {
            get
            {
                return new RungeProcessor();
            }
        }

        double ToDouble(IMeasurement measurement)
        {
            var parameter = measurement.Parameter;
            object o = parameter();
            if (o == null)
            {

            }
            return (double)o;
        }

        private int GetCount(IMeasurements m)
        {
            IDifferentialEquationSolver s = m as IDifferentialEquationSolver;
            return s.GetVariablesCount();
        }
    }
}
