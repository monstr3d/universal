using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using SerializationInterface;

using DataPerformer.Interfaces;
using DataPerformer.Abstract;
using DataPerformer.Runtime;
using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;

namespace DataPerformer.Advanced.Accumulators
{
    /// <summary>
    /// Base class for all accumulatotrs
    /// </summary>
    public class AccumulatorBase : AbstractDataTransformer,
        ISerializable, ITimeMeasurementProvider, IPostSetArrow, IChildrenObject
    {
        #region Fields

        /// <summary>
        /// Time measure
        /// </summary>
        protected IMeasurement timeMeasurement;

        /// <summary>
        /// Time
        /// </summary>
        protected double time;

        /// <summary>
        /// Type of variable
        /// </summary>
        static private readonly Double a = 0;

        /// <summary>
        /// Array of arguments
        /// </summary>
        protected double[] arg = new double[1];


        /// <summary>
        /// Table of time functions
        /// </summary>
        Dictionary<IMeasurement, TimeFunction> functions = new Dictionary<IMeasurement, TimeFunction>();

        /// <summary>
        /// Dependent daca consumers
        /// </summary>
        private IList<object> dep;

        /// <summary>
        /// Updatable objects
        /// </summary>
        private List<IUpdatableObject> upd = new List<IUpdatableObject>();

        /// <summary>
        /// Consumers
        /// </summary>
        private List<IDataConsumer> consumers = new List<IDataConsumer>();

        /// <summary>
        /// Dynamical
        /// </summary>
        private List<IDynamical> dyn = new List<IDynamical>();

        private List<IStep> steps = new List<IStep>();

        /// <summary>
        /// Degree of interpolation
        /// </summary>
        private int degree = 1;

        /// <summary>
        /// Block
        /// </summary>
        private bool block = false;

        /// <summary>
        /// Processor
        /// </summary>
        private IDifferentialEquationProcessor processor;

        private IAssociatedObject[] children = new IAssociatedObject[1];


        /// <summary>
        /// Step
        /// </summary>
        protected double step;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected AccumulatorBase()
        {
            processor = new InternalRungeProcessor(this);
            timeMeasurement = new TimeMeasurement(new Func<object>(GetTime));
            children[0] = new EventBlock();
       }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected AccumulatorBase(SerializationInfo info, StreamingContext context)
            : this()
        {
            try
            {
                isSerialized = true;
                Degree = (int)info.GetValue("Degree", typeof(int));
                children[0] = info.Deserialize<EventBlock>("EventBlock");
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }


        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Post();
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Degree", degree, typeof(int));
            info.Serialize<EventBlock>("EventBlock", children[0] as EventBlock);
        }

        #endregion

        #region IChildrenObject Members

        IAssociatedObject[] IChildrenObject.Children
        {
            get { return children; }
        }

        #endregion

        #region ITimeMeasurementProvider Members

        IMeasurement ITimeMeasurementProvider.TimeMeasurement
        {
            get { return timeMeasurement; }
        }

        double ITimeMeasurementProvider.Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }

        double ITimeMeasurementProvider.Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
            }
        }


        #endregion

        #region Specific Members

        #region Overriden Members

        /// <summary>
        /// Updates measurements data
        /// </summary>
        public override void UpdateMeasurements()
        {
            Update();
        }

        #endregion

        #region Public


        /// <summary>
        /// Approximation degree
        /// </summary>
        public int Degree
        {
            get
            {
                return degree;
            }
            set
            {
                degree = value;
                SetDegree();
            }
        }

        #endregion

        #region Protected

        /// <summary>
        /// Post operation
        /// This function is called after editing of propreties
        /// </summary>
        protected virtual void Post()
        {
            isSerialized = false;
            CreateRuntime();
            functions.Clear();
            List<IMeasurement> measures = new List<IMeasurement>();
            for (int i = 0; i < measurements.Count; i++)
            {
                Perform(measurements[i], measures);
            }
            dep = this.GetDependentObjects();
            consumers.Clear();
            upd.Clear();
            dyn.Clear();
            steps.Clear();
            foreach (object o in dep)
            {
                Add(o);
            }
            mea = measures.ToArray();
            Degree = degree;
        }


        #endregion

        #region Private

        private void SetDegree()
        {
            foreach (TimeFunction f in functions.Values)
            {
                f.Degree = degree;
            }
        }

        private object GetTime()
        {
            return time;
        }

        void Add(object o)
        {
            if (o == null)
            {
                return;
            }
            if (o is IDataConsumer)
            {
                IDataConsumer c = o as IDataConsumer;
                if (!consumers.Contains(c))
                {
                    consumers.Add(c);
                }
            }
            if (o is IUpdatableObject)
            {
                IUpdatableObject u = o as IUpdatableObject;
                if (!upd.Contains(u))
                {
                    upd.Add(u);
                }
            }
            if (o is IDynamical)
            {
                IDynamical d = o as IDynamical;
                if (!dyn.Contains(d))
                {
                    dyn.Add(d);
                }
            }
            if (o is IStep)
            {
                IStep s = o as IStep;
                s.Step = 0;
                if (!steps.Contains(s))
                {
                    steps.Add(s);
                }
            }
            if (o is IChildrenObject)
            {
                IChildrenObject ch = o as IChildrenObject;
                IAssociatedObject[] objs = ch.Children;
                foreach (object obj in objs)
                {
                    Add(obj);
                }
            }
            if (o is MeasurementsWrapper)
            {
                MeasurementsWrapper mw = o as MeasurementsWrapper;
                int n = mw.Count;
                for (int i = 0; i < n; i++)
                {
                    Add(mw[i]);
                }
            }
        }

        private void Perform(IMeasurements m, List<IMeasurement> measures)
        {
            string s = "";
            if (m is IAssociatedObject)
            {
                IAssociatedObject ao = m as IAssociatedObject;
                s = this.GetRelativeName(ao);
                s = s.Replace("/", "_");
            }
            for (int i = 0; i < m.Count; i++)
            {
                Perform(m[i], s, measures);
            }
        }

        private void Perform(IMeasurement m, string str, List<IMeasurement> measures)
        {
            string s = str + "_" + m.Name;
            TimeFunction func = new TimeFunction(arg.Length, m.Type);
            functions[m] = func;
            IMeasurement mea = new Measurement(func, FuncMeasure.createParameter(func), s);
            measures.Add(mea);
        }

        private void Update()
        {
            this.ForEach<IStack>(delegate(IStack s)
           {
               s.Push();
           });

            ITimeMeasurementProvider old = processor.TimeProvider;
            processor.TimeProvider = this;
            if (block)
            {
                //return;
            }
            block = true;
            using (TimeProviderBackup tb = new TimeProviderBackup(this, this, processor, StaticExtensionDataPerformerInterfaces.Calculation, 0))
            {
                runtime.StartAll(0);
                IDataConsumer th = this;
                double last;
                if (arg == null)
                {
                    return;
                }
                if (IsUpdated)
                {
                    return;
                }
                double st = arg[0];
                last = st;
                foreach (IStep s in steps)
                {
                    s.Step = -1;
                }
                Action<double, double, long> act =
                    runtime.Step(processor, SetTime, StaticExtensionDataPerformerInterfaces.Calculation);
                for (int i = 0; i < arg.Length; i++)
                {
                    double time = arg[i];
                    act(last, time, i);
                    //th.UpdateChildrenData(); //TEST!!! Comment this string for artificial bug of orbit determination
                    foreach (IMeasurement m in functions.Keys)
                    {
                        object o = m.Parameter();
                        TimeFunction f = functions[m];
                        f.Set(i, time, o);
                    }
                    last = time;
                }
            }
            this.ForEach((IStack s) =>
            {
                s.Pop();
            });
            processor.TimeProvider = old;
            block = false;
        }

        private int Step
        {
            set
            {
                foreach (object o in dep)
                {
                    if (o is IStep)
                    {
                        IStep s = o as IStep;
                        s.Step = value;
                    }
                }
            }
        }


        private void SetTime(double time)
        {
            this.time = time;
        }

        private void start(double time)
        {
            foreach (object o in dep)
            {
                if (o is IStarted)
                {
                    IStarted s = o as IStarted;
                    s.Start(time);
                }
            }
        }

        #endregion

        #endregion

        #region Additional classes

        #region Functional Measure

        class FuncMeasure
        {
            TimeFunction func;
            private FuncMeasure(TimeFunction func)
            {
                this.func = func;
            }

            private object calc()
            {
                return func;
            }

            internal static Func<object> createParameter(TimeFunction f)
            {
                FuncMeasure fm = new FuncMeasure(f);
                return fm.calc;
            }
        }

        #endregion

        #region Internal Runge Processor

        class InternalRungeProcessor : Portable.DifferentialEquationProcessors.RungeProcessor
        {
            #region Fields

            AccumulatorBase accumulator;

            #endregion

            internal InternalRungeProcessor(AccumulatorBase accumulator)
            {
                this.accumulator = accumulator;
            }

            public override void UpdateMeasurements()
            {
                if (Dim > 0)
                {
                    try
                    {
                        foreach (IMeasurements m in measurements)
                        {
                            if (m == accumulator)
                            {
                                continue;
                            }
                            m.IsUpdated = false;
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
        }

        #endregion

        #endregion

    }
}
