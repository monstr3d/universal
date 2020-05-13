
using System;

using Unity;
using UnityEngine;

using Diagram.UI;

using BaseTypes.Attributes;
using DataPerformer.Portable.Interfaces;
using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

using Event.Interfaces;

using Scada.Interfaces;
using Scada.Desktop;
using StaticExtension;
using System.Collections.Generic;

namespace Assets
{
    public class MonoBehaviorWrapper  : ITimerFactory, ITimer, ITimerEventFactory, ITimerEvent,
        ITimeMeasurementProviderFactory, ITimeMeasurementProvider
    {
        private MonoBehaviour monoBehaviour;

        

        private TimeSpan timeSpan;

        private bool isEnabled = false;

        static IMeasurement timeMeasurement;

        TimeSpan ITimer.TimeSpan => timeSpan;

        private IScadaInterface scada;

        private Diagram.UI.Interfaces.IDesktop desktop;

        private Dictionary<string, Motion6D.Interfaces.IReferenceFrame> frames =
            new Dictionary<string, Motion6D.Interfaces.IReferenceFrame>();

        double step;

        static MonoBehaviorWrapper()
        {
            StaticInit.Init();
            timeMeasurement = new Measurement(GetTime, "Time");
        }

        public MonoBehaviorWrapper(MonoBehaviour monoBehaviour, string name = null, bool unique = false)
        {
            this.monoBehaviour = monoBehaviour;
            if (name != null)
            {
                scada = name.ToScada("Consumer", this, this, this, TimeType.Second, false, null, unique);
                scada.ErrorHandler = StaticInit.ErrorHandler;
                desktop = scada.GetDesktop();
                desktop.ForEach((Motion6D.Interfaces.IReferenceFrame frame) =>
                {
                    string fn = frame.GetName(desktop);
                    frames[fn] = frame;
                });
            }
        }

        public Dictionary<string, Motion6D.Interfaces.IReferenceFrame> Frames { get => frames; }

        public IScadaInterface Scada { get => scada; }

         
        static object GetTime()
        {
            return (double)Time.time;
        }

        

        public void Event()
        {
            ev();
        }

        Action ev = () => { };

        bool ITimer.IsEnabled { get => isEnabled; set => isEnabled = value; }

        ITimerEvent ITimerEventFactory.NewTimer => this;

        TimeSpan ITimerEvent.TimeSpan { get => timeSpan; set => timeSpan = value; }
       
        bool Event.Interfaces.IEvent.IsEnabled { get => isEnabled; set => isEnabled = value; }

        IMeasurement ITimeMeasurementProvider.TimeMeasurement => timeMeasurement;

        double ITimeMeasurementProvider.Time { get => (double)Time.time; set { } }
        double ITimeMeasurementProvider.Step { get => step; set => step = value; }

        event Action ITimer.Event
        {
            add
            {
                ev += value;
            }

            remove
            {
                ev -= value;
            }
        }

        event Action Event.Interfaces.IEvent.Event
        {
            add
            {
                ev += value;
            }

            remove
            {
                ev -= value;
            }
        }

        ITimer ITimerFactory.CreateTimer(TimeSpan timeSpan)
        {
           this.timeSpan = timeSpan;
            return this;
        }

        ITimeMeasurementProvider ITimeMeasurementProviderFactory.Create(bool isAbsolute, TimeType timeUnit, string reason)
        {
            return this;
        }
    }
}
