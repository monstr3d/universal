using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    class EventLogLink : IDisposable
    {

        IEvent ev;

        string name;

        IEventLog log;

        internal EventLogLink(IEvent ev, IEventLog log, string name)
        {
            this.ev = ev;
            this.log = log;
            this.name = name;
            ev.Event += Log;
        }

        void Log()
        {
            log.Write(ev, name, DateTime.Now);
        }


        #region IDisposable Support

        /// <summary>
        /// Disposes itself
        /// </summary>
        public void Dispose()
        {
            if (ev != null)
            {
                ev.Event -= Log;
            }
            ev = null;
        }

        #endregion
    }
}
