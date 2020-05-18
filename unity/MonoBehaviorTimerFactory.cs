using Event.Interfaces;
using Scada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Standard
{
    public class MonoBehaviorTimerFactory : ITimerEventFactory,
    ITimerEvent, ITimerFactory, ITimer
    {

        #region Fields

        private IScadaInterface scada;
 
        Action ev = () => { };


        Action[] eve;

        #endregion

        #region Ctor

        private MonoBehaviorTimerFactory(string desktop, out Action[] even)
        {
            scada = desktop.ToUniqueScada(this, this);
            even = new Action[] { ev };
            eve = even;
        }

        #endregion

        #region Members

        /// <summary>
        /// Creates scada
        /// </summary>
        /// <param name="desktop">Desktop name</param>
        /// <param name="even">Event</param>
        /// <returns>The scada</returns>
        public static IScadaInterface Create(string desktop, out Action[] even)
        {
            MonoBehaviorTimerFactory f = new MonoBehaviorTimerFactory(desktop, out even);
            return f.scada;
        }

        #endregion

        #region Implementation of interfacces

        ITimerEvent ITimerEventFactory.NewTimer => this;

        TimeSpan ITimerEvent.TimeSpan { get; set; }
        bool Event.Interfaces.IEvent.IsEnabled { get; set; } = false;

        TimeSpan ITimer.TimeSpan => new TimeSpan();

        bool ITimer.IsEnabled { get; set; } = false;

        event Action Event.Interfaces.IEvent.Event
        {
            add
            {
                Action evr = eve[0];
                evr += value;
                eve[0] = evr;
            }

            remove
            {
                Action evr = eve[0];
                evr -= value;
                eve[0] = evr;
            }
        }

        event Action ITimer.Event
        {
            add
            {
                Action evr = eve[0];
                evr += value;
                eve[0] = evr;
            }

            remove
            {
                Action evr = eve[0];
                evr -= value;
                eve[0] = evr;
            }
        }

        ITimer ITimerFactory.CreateTimer(TimeSpan timeSpan)
        {
            return this;
        }



        #endregion

    }
}
