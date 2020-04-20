using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Desktop
{
    class EventWrapper : Scada.Interfaces.IEvent
    {
        #region Fields

        Event.Interfaces.IEvent ev;

        #endregion

        #region Ctor

        internal EventWrapper(Event.Interfaces.IEvent ev)
        {
            this.ev = ev;
        }

        #endregion

        #region IEvent Members

        event Action Interfaces.IEvent.Event
        {
            add { ev.Event += value; }
            remove { ev.Event -= value; }
        }

        #endregion
    }
}
