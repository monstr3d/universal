using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using Event.Interfaces;
using System.Threading;

namespace Event.Basic.Events
{
    /// <summary>
    /// Timer
    /// </summary>
    [Serializable()]
    public class Timer1 : CategoryObject, ISerializable,
        IEvent, IRemovableObject
    {

        #region Fields

        TimeSpan timeSpan = new TimeSpan();

        bool isSuspended = true;

        event Action ev = () => { };

        AutoResetEvent reset;


         #endregion

        #region Ctor

        public Timer1()
        {
            //pre.Run = Run;
        }

        protected Timer1(SerializationInfo info, StreamingContext context)
        {
            timeSpan = (TimeSpan)info.GetValue("TimeSpan", typeof(TimeSpan));
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TimeSpan", timeSpan, typeof(TimeSpan));
         }

        #endregion

        #region IRemovableObject Members

        void IRemovableObject.RemoveObject()
        {
            isSuspended = true;
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
                return true;
            }
            set
            {
            }
        }

        #endregion
 
        #region Public Members

  
        /// <summary>
        /// Stops itself
        /// </summary>
        public void Stop()
        {
            if (isSuspended)
            {
                return;
            }
            reset = new AutoResetEvent(false);
            isSuspended = true;
            reset.WaitOne();
            reset = null;
        }

        #endregion

        #region Private Members

        private void Run()
        {
            while (true)
            {
                Thread.Sleep(timeSpan);
                if (isSuspended)
                {
                    if (reset != null)
                    {
                        reset.Set();
                    }
                    return;
                }
                lock (this)
                {
                    ev();
                }
            }
        }


        /// <summary>
        /// Time span
        /// </summary>
        public TimeSpan TimeSpan
        {
            get
            {
                return timeSpan;
            }
            set
            {
                timeSpan = value;
            }
        }

        #endregion

    }
}
