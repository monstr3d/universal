using System;

using Event.Interfaces;

namespace Event.Windows.Forms
{
    /// <summary>
    /// Windows timer
    /// </summary>
    public class Timer : ITimerEvent, IDisposable
    {

        #region Fields

        event Action ev = () => { };

        event Action proxy;


        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        bool isEnabled = false;

        TimeSpan timeSpan = new TimeSpan();

        event Action onPrepare = () => { };

        bool isDisposed = false;

        #endregion

        #region Ctor

        internal Timer()
        {
            proxy = () => { ev?.Invoke(); };
            timer.Tick += (object sender, EventArgs e) => 
            {
                Event();
            };
        }


        #endregion

        #region ITimerEvent Members

        TimeSpan ITimerEvent.TimeSpan
        {
            get
            {
                return timeSpan;
            }
            set
            {
                if (timeSpan.Equals(value))
                {
                    return;
                }
                timeSpan = value;
                if (value.TotalMilliseconds <= 0)
                {
                    timer.Interval = 1;
                    return;
                }
                timer.Interval = (int)value.TotalMilliseconds;
            }
        }

        #endregion

        #region IEvent Members

        event Action IEvent.Event
        {
            add { ev += value; }
            remove { ev -= value; }
        }

        event Action<Action> IEventProxy.OnCreate
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }


        bool IEvent.IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (value == isEnabled)
                {
                    return;
                }
                isEnabled = value;
                if (value)
                {
                    onPrepare();
                }
                timer.Enabled = value;
                if (value)
                {
                    timer.Start();
                }
                else
                {
                    timer.Stop();
                }
            }
        }

        Action IEventProxy.Proxy { get => proxy; set => proxy = value; }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (isDisposed)
            {
                return;
            }
            try
            {
                timer.Dispose();
            }
            catch
            {

            }
            isDisposed = true;
        }

        #endregion

        #region

        void Event()
        {
            proxy();
        }

        void IEventProxy.CreateProxy()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
