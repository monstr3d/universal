using System;
using System.Collections.Generic;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI;

using DataPerformer.Interfaces;

using Event.Interfaces;

using ErrorHandler;

using NamedTree;

namespace DataPerformer.Portable
{
 
    /// <summary>
    /// Data consumer
    /// </summary>
    public class DataConsumer : CategoryObject,  IDataConsumer,
        IEventHandler, ITimeMeasurementConsumer, IAddRemove, ICalculationReason
    {

        #region Fields

        /// <summary>
        /// Add event 
        /// </summary>
        protected event Action<IEvent> onAddEvent;

        /// <summary>
        /// Remove event
        /// </summary>
        protected event Action<IEvent> onRemoveEvent;

        /// <summary>
        /// Change input
        /// </summary>
        protected event Action onChangeInput;

        /// <summary>
        /// Interrupted exception
        /// </summary>
        public const string Interrupted = "Interrupted";

        /// <summary>
        /// Error message of variables shortage
        /// </summary>
        public static readonly string VariablesShortage = "Shortage of variables";

        /// <summary>
        /// Arrows to data providers
        /// </summary>
        protected List<IMeasurements> measurementsData = new ();

        /// <summary>
        /// Dependent measurements
        /// </summary>
        protected List<IMeasurements> dependent = new ();

        /// <summary>
        /// List of dependent objects
        /// </summary>
        protected List<object> list = new ();

        /// <summary>
        /// Type of consumer
        /// </summary>
        protected int type;

        /// <summary>
        /// Update flag
        /// </summary>
        protected bool isUpdated;

        /// <summary>
        /// Comments
        /// </summary>
        protected byte[] comments = new byte[0];

        /// <summary>
        /// Start
        /// </summary>
        protected double start = 0;

        /// <summary>
        /// Step
        /// </summary>
        protected double step = 1;

        /// <summary>
        /// Number of steps
        /// </summary>
        protected int steps = 2;

        /// <summary>
        /// Children
        /// </summary>
        protected IAssociatedObject[] children = new IAssociatedObject[] { new Diagram.UI.Objects.EmptyAddRemove()};

        /// <summary>
        /// Events
        /// </summary>
        protected List<IEvent> events = new ();

        /// <summary>
        /// Calculation reason
        /// </summary>
        protected string calculationReason = "";

        /// <summary>
        /// Time measurement
        /// </summary>
        private IMeasurement timeMeasurement = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of consumer</param>
        public DataConsumer(int type)
        {
            this.type = type;
        }

        #endregion

        #region IEventHandler Members

        void IChildren<IEvent>.AddChild(IEvent ev)
        {
            events.Add(ev);
            onAddEvent?.Invoke(ev);
        }

        void IChildren<IEvent>.RemoveChild(IEvent ev)
        {
            events.Remove(ev);
            onRemoveEvent?.Invoke(ev);
        }
        IEnumerable<IEvent> IChildren<IEvent>.Children => events;
   
    
        event Action<IEvent> IChildren<IEvent>.OnAdd
        {
            add { onAddEvent += value; }
            remove { onAddEvent -= value; }
        }

        event Action<IEvent> IChildren<IEvent>.OnRemove
        {
            add { onRemoveEvent += value; }
            remove { onRemoveEvent -= value; }
        }
        #endregion

        #region IAddRemove Members

   
        Type IAddRemove.Type
        {
            get { return typeof(object); }
        }

    
        #endregion

        #region ITimeMeasureConsumer Members

        IMeasurement ITimeMeasurementConsumer.Time
        {
            get => TimeMeasurement;
            set => TimeMeasurement = value;
        }

        #endregion

        #region Protected Virtual Members

        /// <summary>
        /// Time measure
        /// </summary>
        protected virtual IMeasurement TimeMeasurement
        {
            get => timeMeasurement;
            set
            {
                if (timeMeasurement == value)
                {
                    return;
                }
                timeMeasurement = value;
            }
        }

        #endregion

        #region Public Members


        /// <summary>
        /// On Change input
        /// </summary>
        public event Action OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<object> IChildren<object>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<object> IChildren<object>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }


        /// <summary>
        /// Prepares itself
        /// </summary>
        public void Prepare()
        {
            IDesktop d = this.GetRootDesktop();
            this.FullReset();
            UpdateChildrenData();
        }

 
        /// <summary>
        /// Checks whether exeption is caused by interruption
        /// </summary>
        /// <param name="e">The exception</param>
        /// <returns>True in case of interruption and false oterwise</returns>
        public static bool IsInterrupted(Exception e)
        {
            return e.Message.Equals(Interrupted);
        }




        /// <summary>
        /// Aliases of this object and all its children
        /// </summary>
        /// 
        public virtual List<string> AllAliases
        {
            get
            {
                List<string> a = new List<string>();
                this.GetAliases(a, null);
                return a;
            }
        }


         /// <summary>
        /// Adds measurements provider 
        /// </summary>
        /// <param name="measurements">Provider to add</param>
        public void Add(IMeasurements measurements)
        {
            if (measurements is MeasurementsWrapper)
            {

            }
            if (measurementsData.Contains(measurements))
            {
                this.Throw("Measurements aldeady exists");
            }
            measurementsData.Add(measurements);
            measurementsData.GetDependent(list, dependent);
            onChangeInput?.Invoke();
        }

        /// <summary>
        /// Removes  measurements
        /// </summary>
        /// <param name="measurements">Measurements to remove</param>
        public void Remove(IMeasurements measurements)
        {
            measurementsData.Remove(measurements);
            measurementsData.GetDependent(list, dependent);
            onChangeInput?.Invoke();
        }

        /// <summary>
        /// Updates children measurements
        /// </summary>
        public void UpdateChildrenData()
        {
            if (isUpdated)
            {
                return;
            }
            foreach (IMeasurements m in measurementsData)
            {
                try
                {
                    if (m is IDataConsumer)
                    {
                        IDataConsumer dc = m as IDataConsumer;
                        dc.UpdateChildrenData();
                    }
                    m.UpdateMeasurements();
                }
                catch (Exception e)
                {
                    e.HandleException(10);
                    this.Throw(e);
                }
            }
        }


        /// <summary>
        /// Resets measurements
        /// </summary>
        public void Reset()
        {
            this.FullReset();
        }


        /// <summary>
        /// Count of providers
        /// </summary>
        public int Count
        {
            get
            {
                return measurementsData.Count;
            }
        }

        /// <summary>
        /// Arrow of n th provider
        /// </summary>
        public IMeasurements this[int n]
        {
            get
            {
                return measurementsData[n];
            }
        }

        /// <summary>
        /// Type of consumer
        /// </summary>
        public int ConsumerType
        {
            get
            {
                return type;
            }
        }



        /// <summary>
        /// Shows, whether the object is updated
        /// </summary>
        public bool IsUpdated
        {
            get
            {
                return isUpdated;
            }
            set
            {
                isUpdated = value;
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        public double StartTime
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
            }
        }

        /// <summary>
        /// Step
        /// </summary>
        public double Step
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

        /// <summary>
        /// Number of steps
        /// </summary>
        public int Steps
        {
            get
            {
                return steps;
            }
            set
            {
                steps = value;
            }
        }

        /// <summary>
        /// Calculation reason
        /// </summary>
        public virtual string CalculationReason
        {
            get
            {
                return calculationReason;
            }

            set
            {
                calculationReason = value;
            }
        }

        IEnumerable<IMeasurements> IChildren<IMeasurements>.Children => measurementsData;

        IEnumerable<object> IChildren<object>.Children => throw  new ErrorHandler.WriteProhibitedException(); 

        /// <summary>
        /// Tests desktop
        /// </summary>
        /// <param name="desktop">Desktop for testing</param>
        public static void Test(IDesktop desktop)
        {
            IEnumerable<ICategoryObject> objs = desktop.CategoryObjects;
            foreach (object o in objs)
            {
                if (o.GetType().FullName.Equals("DataPerformer.DataConsumer"))
                {
                    DataConsumer c = o as DataConsumer;
                  //!!!!!!  c.test(desktop);
                }
            }
        }

        void IChildren<IMeasurements>.AddChild(IMeasurements child)
        {
            measurementsData.Add(child);
            onChangeInput?.Invoke();
        }

        void IChildren<IMeasurements>.RemoveChild(IMeasurements child)
        {
            measurementsData.Remove(child);
            onChangeInput?.Invoke();
        }

        void IChildren<object>.AddChild(object child)
        {
        }

        void IChildren<object>.RemoveChild(object child)
        {
        }

        #endregion

    }
}
