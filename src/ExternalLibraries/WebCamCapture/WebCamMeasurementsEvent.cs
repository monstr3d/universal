using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using DataPerformer.Interfaces;

using Event.Interfaces;

namespace WebCamCapture
{
    [Serializable]
    public class WebCamMeasurementsEvent : SuperWebCamMeasurements, IEventHandler, 
        IEventReader, INativeReader, IRealtimeUpdate, IRuntimeUpdate
    {
        #region Fields

        event Action<object[]> read = (object[] o) => { };

        event Action ev = () => { };

        List<IEvent> events = new List<IEvent>();

        static readonly List<Tuple<string, object>> types = new List<Tuple<string, object>>()
        {
            new Tuple<string, object>("Image", typeof(Bitmap))
        };

        bool isEnabled;

        IMeasurement measurement;

        #endregion


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public WebCamMeasurementsEvent()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected WebCamMeasurementsEvent(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        #endregion



        #region Protected Members

        /// <summary>
        /// Sets calculation reason
        /// </summary>
        protected override void SetCalculationReason()
        {
            if (calculationReason.Equals(StaticExtensionEventInterfaces.Realtime))
            {
                update = Update;
            }
            else
            {
                update = UpdateBitmap;
            }
        }


        #endregion

        #region IEventHandler Members

        IEnumerable<IEvent> IEventHandler.Events
        {
            get
            {
                return events;
            }
        }

        event Action<IEvent> IEventHandler.OnAdd
        {
            add
            {

            }

            remove
            {

            }
        }

        event Action<IEvent> IEventHandler.OnRemove
        {
            add
            {

            }

            remove
            {

            }
        }

        void IEventHandler.Add(IEvent ev)
        {
            events.Add(ev);
        }

        void IEventHandler.Remove(IEvent ev)
        {
            events.Remove(ev);
        }

        #endregion

        #region IEventReader Members

        IEventReader IEventReader.this[string name]
        {
            get
            {
                return this;
            }
        }

        string[] IEventReader.EventNames
        {
            get
            {
                return new string[] { "Capture" };
            }
        }

        bool IEventReader.IsEnabled
        {
            get
            {
                return isEnabled;
            }

            set
            {
                if (isEnabled == value)
                {
                    return;
                }
                SetEnabled(value);
            }
        }

        List<Tuple<string, object>> IEventReader.Types
        {
            get
            {
                return types;
            }
        }

        event Action IEventReader.Change
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<object[]> IEventReader.EventData
        {
            add
            {
                read += value;
            }

            remove
            {
                read -= value;
            }
        }


        #endregion

        #region IRealtimeUpdate Members

        event Action IRealtimeUpdate.OnUpdate
        {
            add
            {
                
            }

            remove
            {
                
            }
        }

        Action IRealtimeUpdate.Update
        {
            get
            {
                return UpdateBitmap;
            }
        }

        bool IRuntimeUpdate.ShouldRuntimeUpdate
        {
            get
            {
                return true;
            }

            set
            {

            }
        }

        #endregion

        #region INativeReader Members

        void INativeReader.Read(object[] o)
        {
            bitmap = o[0] as Bitmap;
        }

        #endregion

        #region Private Members

        void Event()
        {
            update();
            object[] o = new object[] { bitmap };
            read(o);
        }

        void SetEnabled(bool enabled)
        {
            FindMeasurement();
            isEnabled = enabled;
            if (enabled)
            {
                Start();
            }
            else
            {
                Stop();
            }
            foreach (IEvent ev in events)
            {
                if (ev is ICalculationReason)
                {
                    (ev as ICalculationReason).CalculationReason = calculationReason;
                }
                ev.IsEnabled = enabled;
                if (enabled)
                {
                    ev.Event += Event;
                }
                else
                {
                    ev.Event -= Event;
                }
            }
        }

        void UpdateBitmap()
        {
          //  bitmap = measurement.Parameter() as Bitmap;
        }

        void FindMeasurement()
        {
            Diagram.UI.Labels.IObjectLabel l = this.Object as Diagram.UI.Labels.IObjectLabel;
            IMeasurements m = l.Object as IMeasurements;
            measurement = m[0];

        }

        #endregion


    }
}
