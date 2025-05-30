﻿using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;
using Diagram.UI.Interfaces;
using Event.Interfaces;
using Scada.Desktop;
using Scada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard.Interfaces;
using UnityEngine;


namespace Unity.Standard
{
    public class MonoBehaviourTimerFactory : ITimerEventFactory,
    ITimerEvent, ITimerFactory, ITimer, IScadaUpdate
    {
 

        #region Fields

        private Scada.Motion6D.ScadaDesktop scada;

        protected IDesktop desktop;
 
        Action ev;

        float currentTime;

        float step;

        protected bool exists;

        TimeSpan timeSpan = new TimeSpan();

        Action execute;

        protected string desktopName;

        static IMeasurement timeMeasurement;

        Action update = null;

        static event Action<string> onStart = (string s) => { };

        static public event Action<string> OnStart
        {
            add { onStart += value; }
            remove { onStart -= value; }
        }

        #endregion

        #region Ctor
        static MonoBehaviourTimerFactory()
        {
            StaticExtensionUnity.Init();
            timeMeasurement = new Measurement(GetTime, "Time", "Time");
        }

        protected MonoBehaviourTimerFactory(string desktopName)
        {
            exists = desktopName.ScadaExists();
            this.desktopName = desktopName;
            scada = desktopName.ToUniqueScada(this, this, this) as Scada.Motion6D.ScadaDesktop;
            desktop = scada.GetDesktop();
            if (!exists)
            {
                update = Event;
            }
        }

        #endregion

        #region Members

        #region Public Members

        /// <summary>
        /// Creates scada
        /// </summary>
        /// <param name="desktop">Desktop name</param>
        /// <param name="factory">Event</param>
        /// <returns>The scada</returns>
        public static IScadaInterface Create(string desktop, 
            out MonoBehaviourTimerFactory factory)
        {
            factory = new MonoBehaviourTimerFactory(desktop);
            return factory.scada;
        }

        /// <summary>
        /// Update
        /// </summary>
        public virtual Action Update
        {
            get
            {
                return update;
            }
        }


        public Scada.Motion6D.ScadaDesktop Scada { get => scada; }

        /// <summary>
        /// Starts itself
        /// </summary>
        public virtual void Start()
        {
            if (exists)
            {
                return;
            }
            execute = desktopName.ExecuteScadaUpdate();
            ev += execute;
            if (!scada.IsEnabled)
            {
                onStart(desktopName);
                scada.IsEnabled = true;
            }
            currentTime = (float)StaticExtensionUnity.Time;
        }

        protected virtual void Event()
        {
            float t = Time.fixedTime;
            if (Math.Abs(t - currentTime) < step)
            {
                return;
            }
            currentTime = t;
            ev?.Invoke();
        }




        #endregion

        #region Private Members



        static object GetTime()
        {
            return StaticExtensionUnity.Time;
        }


        #endregion

        #endregion

        #region Implementation of interfaces

        Action IScadaUpdate.Update { get; set; }

        ITimerEvent ITimerEventFactory.NewTimer => this;

        TimeSpan ITimerEvent.TimeSpan
        {
            get => timeSpan;
            set
            {
                timeSpan = value;
                step = (float)value.TotalSeconds;
            }
        }

        bool Event.Interfaces.IEvent.IsEnabled { get; set; } = false;

        bool ITimer.IsEnabled { get; set; } = false;

        TimeSpan ITimer.TimeSpan => timeSpan;

        event Action Event.Interfaces.IEvent.Event
        {
            add
            {
                if (!exists)
                {
                    ev += value;
                }
            }

            remove
            {
                if (!exists)
                {
                    ev -= value;
                }
            }
        }

        event Action ITimer.Event
        {
            add
            {
                if (!exists)
                {
                    ev += value;
                }
            }

            remove
            {
                if (!exists)
                {
                    ev -= value;
                }
            }
        }

        ITimer ITimerFactory.CreateTimer(TimeSpan timeSpan)
        {
            this.timeSpan = timeSpan;
            step = (float)timeSpan.TotalSeconds;
            return this;
        }




        #endregion

    }
}
