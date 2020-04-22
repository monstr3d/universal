using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI;

using DataPerformer.Interfaces;
using Event.Interfaces;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Consumer of data
    /// </summary>
    public class DataConsumer : CategoryObject,  IDataConsumer,
        IEventHandler, ITimeMeasureConsumer, IAddRemove, ICalculationReason
    {
 
        #region Fields

        /// <summary>
        /// Add event 
        /// </summary>
        protected event Action<IEvent> onAddEvent = (IEvent e) => { };

        /// <summary>
        /// Remove event
        /// </summary>
        protected event Action<IEvent> onRemoveEvent = (IEvent e) => { };

        /// <summary>
        /// Change input
        /// </summary>
        protected event Action onChangeInput = () => { };

        /// <summary>
        /// Interrupted excfeption
        /// </summary>
        public const string Interrupted = "Interrupted";


        /// <summary>
        /// Error message of variables shortage
        /// </summary>
        public static readonly string VariablesShortage = "Shortage of variables";

        /// <summary>
        /// Arrows to data providers
        /// </summary>
        protected List<IMeasurements> measurementsData;

        /// <summary>
        /// Dependent measurements
        /// </summary>
        protected List<IMeasurements> dependent = new List<IMeasurements>();

        /// <summary>
        /// List of dependent objects
        /// </summary>
        protected List<object> list = new List<object>();

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

        protected IAssociatedObject[] children = new IAssociatedObject[] { new Diagram.UI.Objects.EmptyAddRemove() };

        protected List<IEvent> events = new List<IEvent>();

        IMeasurement timeMeasurement;

        protected string calculationReason = "";

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of consumer</param>
        public DataConsumer(int type)
        {
            this.type = type;
            initialize();
        }

        #endregion

        #region IEventHandler Members

        void IEventHandler.Add(IEvent ev)
        {
            events.Add(ev);
            onAddEvent(ev);
        }

        void IEventHandler.Remove(IEvent ev)
        {
            events.Remove(ev);
            onRemoveEvent(ev);
        }

        IEnumerable<IEvent> IEventHandler.Events
        {
            get
            {
                foreach (IEvent ev in events)
                {
                    yield return ev;
                }
            }
        }

        event Action<IEvent> IEventHandler.OnAdd
        {
            add { onAddEvent += value; }
            remove { onAddEvent -= value; }
        }

        event Action<IEvent> IEventHandler.OnRemove
        {
            add { onRemoveEvent += value; }
            remove { onRemoveEvent -= value; }
        }
        #endregion

        #region IAddRemove Members

        void IAddRemove.Add(object obj)
        {

        }

        void IAddRemove.Remove(object obj)
        {

        }

        Type IAddRemove.Type
        {
            get { return typeof(object); }
        }

        event Action<object> IAddRemove.AddAction
        {
            add { }
            remove { }
        }

        event Action<object> IAddRemove.RemoveAction
        {
            add { }
            remove { }
        }

        #endregion

        #region ITimeMeasureConsumer Members

        IMeasurement ITimeMeasureConsumer.Time
        {
            get
            {
                return TimeMeasurement;
            }
            set
            {
                TimeMeasurement = value;
            }
        }

        #endregion

        #region Protected Virtual Members

        /// <summary>
        /// Time measure
        /// </summary>
        protected virtual IMeasurement TimeMeasurement
        {
            get
            {
                return timeMeasurement;
            }
            set
            {
                timeMeasurement = value;
            }
        }

        #endregion

        #region Static Helper Members




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
            onChangeInput();
        }

        /// <summary>
        /// Removes target arrow
        /// </summary>
        /// <param name="arrow">Arrow to remove</param>
        public void Remove(IMeasurements arrow)
        {
            measurementsData.Remove(arrow);
            measurementsData.GetDependent(list, dependent);
            onChangeInput();
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
                    e.ShowError(10);
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
        /// Shows, wreather the object is updated
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
        public double Start
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

        #endregion

        #region   Private Members
        /// <summary>
        /// Initialization
        /// </summary>
        private void initialize()
        {
            measurementsData = new List<IMeasurements>();
        }

        #endregion

    }
}
