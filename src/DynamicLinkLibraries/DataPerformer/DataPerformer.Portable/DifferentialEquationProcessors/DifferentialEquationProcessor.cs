using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI;
using Diagram.UI.Interfaces;


using DataPerformer.Interfaces;
using DataPerformer.Portable.Interfaces;

namespace DataPerformer.Portable.DifferentialEquationProcessors
{

    /// <summary>
    /// Processor for solving ordinary differential equations system 
    /// </summary>
    public abstract class DifferentialEquationProcessor : IDifferentialEquationProcessor
    {
        /// <summary>
        /// Processor
        /// </summary>
        static private IDifferentialEquationProcessor processor;


        /// <summary>
        /// The is busy sign
        /// </summary>
        protected bool isBusy = false;

        /// <summary>
        /// Time provider
        /// </summary>
        protected ITimeMeasurementProvider timeProvider;

        /// <summary>
        /// Variables
        /// </summary>
        protected List<string[]> variablesStr = new List<string[]>();

        /// <summary>
        /// Processor
        /// </summary>
        public static IDifferentialEquationProcessor Processor
        {
            get
            {
                return processor;
            }
            set
            {
                processor = value;
            }
        }


        /// <summary>
        /// Systems of equations
        /// </summary>
        protected List<IDifferentialEquationSolver> equations =
            new List<IDifferentialEquationSolver>();

        /// <summary>
        /// Normalizable components
        /// </summary>
        protected List<INormalizable> norm = new List<INormalizable>();

        /// <summary>
        /// Children measurements
        /// </summary>
        protected List<IMeasurements> measurements = new List<IMeasurements>();



        /// <summary>
        /// Variables
        /// </summary>
        protected List<string[]> variables = new List<string[]>();

        /// <summary>
        /// Constructor
        /// </summary>
        protected DifferentialEquationProcessor()
        {
        }

        /// <summary>
        /// Sets consumers
        /// </summary>
        /// <param name="collection">Consumers</param>
        /// <returns>Lists of parameters</returns>
        public virtual void Set(object collection)
        {
            IComponentCollection cc = collection as IComponentCollection;
            IDataRuntime rt = StaticExtensionDataPerformerPortable.Factory.Create(cc, 0);
            Clear();
            variablesStr.Clear();
            /*           IEnumerable<IDataConsumer> consumers = cc.GetAll<IDataConsumer>();
                       foreach (IDataConsumer c in consumers)
                       {
                           c.GetMeasurements(measurements);
                       }*/
            List<object> l = new List<object>();
            cc.ForEach<IDifferentialEquationSolver>((IDifferentialEquationSolver solver) =>
            {
                if (solver is IMeasurements)
                {
                    if (!l.Contains(solver))
                    {
                        l.Insert(0, solver);
                    }
                }
                if (solver is IDataConsumer)
                {
                    (solver as IDataConsumer).GetDependentObjects(l);
                }
            }
            );
            foreach (object o in l)
            {
                if (o is IMeasurements)
                {
                    measurements.Add(o as IMeasurements);
                }
            }
            foreach (IMeasurements m in measurements)
            {
                IDataRuntimeFactory s = StaticExtensionDataPerformerPortable.Factory;
                if (m is IDifferentialEquationSolver)
                {
                    IDifferentialEquationSolver ds = m as IDifferentialEquationSolver;
                    Add(ds);
                }
                else if (s != null)
                {
                    IDifferentialEquationSolver ds = rt.GetDifferentialEquationSolver(m);
                    if (ds != null)
                    {
                        Add(ds);
                    }
                }
                if (m is INormalizable)
                {
                    Add(m as INormalizable);
                }
            }
            measurements.SortMeasurements();
        }


        /// <summary>
        /// Adds solver
        /// </summary>
        /// <param name="solver">Solver to add</param>
        public void Add(IDifferentialEquationSolver solver)
        {
            if (equations.Contains(solver))
            {
                return;
            }
            /*           string n = solver.GetName();
                       List<string> var = solver.Variables;
                       foreach (string s in var)
                       {
                           variablesStr.Add(new string[] { n, s });
                       }*/
            equations.Add(solver);

            if (solver is INormalizable)
            {
                Add(solver as INormalizable);
            }
        }

        /// <summary>
        /// Adds collection of solvers
        /// </summary>
        /// <param name="collection">Collection to add</param>
        public void AddRange(ICollection<IDifferentialEquationSolver> collection)
        {
            foreach (IDifferentialEquationSolver s in collection)
            {
                Add(s);
            }
            foreach (object o in collection)
            {
                if (o is INormalizable)
                {
                    Add(o as INormalizable);
                }
            }
        }

        /// <summary>
        /// Equations
        /// </summary>
        public ICollection<IDifferentialEquationSolver> Equations
        {
            get
            {
                List<IDifferentialEquationSolver> l = new List<IDifferentialEquationSolver>();
                l.AddRange(equations);
                return l;
            }
        }


        void Add(INormalizable n)
        {
            if (!norm.Contains(n))
            {
                norm.Add(n);
            }
        }




        /// <summary>
        /// Count of equations system
        /// </summary>
        public int Count
        {
            get
            {
                return equations.Count;
            }
        }

        /// <summary>
        /// Access to i - th equations sistem
        /// </summary>
        public IDifferentialEquationSolver this[int i]
        {
            get
            {
                return equations[i] as IDifferentialEquationSolver;
            }
        }


        /// <summary>
        /// Resets "is updated" sign
        /// </summary>
        public void Reset()
        {
            foreach (IMeasurements m in measurements)
            {
                m.IsUpdated = false;
            }
        }

        /// <summary>
        /// Sets root data consumer
        /// </summary>
        /// <param name="consumer">The consumer to set</param>
        public void Set(IDataConsumer consumer)
        {
            List<IDataConsumer> l = new List<IDataConsumer>();
            l.Add(consumer);
            Set(l);
        }

        /// <summary>
        /// Sets root data consumers
        /// </summary>
        /// <param name="consumers">Consumers to set</param>
        public virtual void Set(List<IDataConsumer> consumers)
        {
        }

        /// <summary>
        /// Dimension of state vector
        /// </summary>
        public int Dim
        {
            get
            {
                int n = 0;
                foreach (IMeasurements m in equations)
                {
                    n += m.Count;
                }
                return n;
            }
        }

        /// <summary>
        /// Updates measurements
        /// </summary>
        public virtual void UpdateMeasurements()
        {
            if (Dim > 0)
            {
                try
                {
                    foreach (IMeasurements m in measurements)
                    {
                        m.UpdateMeasurements();
                    }
                    foreach (INormalizable n in norm)
                    {
                        n.Normalize();
                    }
                }
                catch (Exception e)
                {
                    e.ShowError(10);
                    this.Throw(e);
                }
            }
        }

        /// <summary>
        /// Time provider
        /// </summary>
        public ITimeMeasurementProvider TimeProvider
        {
            get
            {
                return timeProvider;
            }
            set
            {
                timeProvider = value;
            }
        }

        /// <summary>
        /// Performs step of integration
        /// </summary>
        /// <param name="t0">Step start</param>
        /// <param name="t2">Step finish</param>
        abstract public void Step(double t0, double t2);

        /// <summary>
        /// Updates dimension
        /// </summary>
        abstract public void UpdateDimension();

        /// <summary>
        /// Creates new processor
        /// </summary>
        public abstract IDifferentialEquationProcessor New
        {
            get;
        }


        /// <summary>
        /// Clears itself
        /// </summary>
        public void Clear()
        {
            equations.Clear();
            measurements.Clear();
            norm.Clear();
        }


        /// <summary>
        /// The "is busy" sign
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
        }


    }
}
