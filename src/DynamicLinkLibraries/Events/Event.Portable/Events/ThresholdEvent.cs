using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using Event.Interfaces;


namespace Event.Portable.Events
{
    /// <summary>
    /// Threshold Event
    /// </summary>
    public class ThresholdEvent : CategoryObject, IDataConsumer,
        IEvent, IEventHandler, IPostSetArrow
    {
  
        #region Fields

        bool isEnabled = false;

        protected bool last = true;

        event Action ev = () => { };

        IMeasurement measurement = null;

        List<IMeasurements> measurements = new List<IMeasurements>();

  
        List<IEvent> events = new List<IEvent>();

        event Action onChangeInput  = () => { };

        event Action<IEvent> onAdd = (IEvent ev) => {};

        event Action<IEvent> onRemove = (IEvent ev) => { };

        Func<bool> threshold;

        protected IDataConsumer dc;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public ThresholdEvent()
        {
            dc = this;
        }

        #endregion

        #region IEvent Members

        event Action IEvent.Event
        {
            add { ev += value; }
            remove { ev -= value; }
        }

        bool IEvent.IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
            }
        }

        #endregion

        #region IEventHandler Members


        event Action<IEvent> IEventHandler.OnAdd
        {
            add
            {
                onAdd += value;
            }

            remove
            {
                onAdd -= value;
            }
        }

        event Action<IEvent> IEventHandler.OnRemove
        {
            add
            {
                onRemove += value;
            }

            remove
            {
                onRemove -= value;
            }
        }


        IEnumerable<IEvent> IEventHandler.Events => events;

        void IEventHandler.Add(IEvent ev)
        {
            onAdd(ev);
            events.Add(ev);
            ev.Event += Perform;
        }

        void IEventHandler.Remove(IEvent ev)
        {
            onRemove(ev);
            events.Remove(ev);
            ev.Event -= Perform;
        }


        #endregion

        #region IDataConsumer Members

        int IDataConsumer.Count => measurements.Count;

        IMeasurements IDataConsumer.this[int number] => measurements[number];

        void IDataConsumer.Add(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            dc.UpdateChildrenData();
        }

        event Action IDataConsumer.OnChangeInput
        {
            add
            {
                onChangeInput += value;
            }

            remove
            {
                onChangeInput -= value;
            }
        }


        void IDataConsumer.Reset()
        {
            dc.Reset();
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Set();
        }

        #endregion

        #region Own Members

        #region Public

        /// <summary>
        /// Type
        /// </summary>
        public object Type
        { get; set; } = (double)0;

        /// <summary>
        /// Measurement
        /// </summary>
        public string Measurement
        { get; set; } = "";

        /// <summary>
        /// Decrease
        /// </summary>
        public bool Decrease
        { get; set; } = true;

        /// <summary>
        /// Sets itself
        /// </summary>
        public void Set()
        {
            if (Type.GetType() == typeof(double))
            {
               if (Decrease)
                {
                    threshold = DoubleDecrease;
                }
            }
            measurement = dc.FindMeasurement(Measurement, true);
        }

        #endregion

        #region Protected

        /// <summary>
        /// Performs threshold
        /// </summary>
        protected void Perform()
        {
            if (threshold())
            {
                ev();
            }
        }

        #endregion


        #region Protected

        /// <summary>
        /// Performs threshold
        /// </summary>
        bool DoubleDecrease()
        {
            bool b =  (double)measurement.Parameter() < 0;
            if (last)
            {
                if (b)
                {
                    last = false;
                    return true;
                }
            }
            last = !b;
            return false;
        }

        #endregion

        #endregion

    }
}
