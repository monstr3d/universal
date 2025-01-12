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

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        bool isEnabled = false;

        TimeSpan timeSpan = new TimeSpan();

        event Action onPrepare = () => { };

        bool isDisposed = false;

        #endregion

        #region Ctor

        internal Timer()
        {
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
            ev();
        }

        #endregion
    }
}
