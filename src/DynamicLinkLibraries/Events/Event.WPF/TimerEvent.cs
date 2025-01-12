using System.Windows.Threading;

using Event.Interfaces;

namespace Event.WPF
{
    class TimerEvent : ITimerEvent, IDisposable
    {

        #region Fields

        DispatcherTimer timer = new DispatcherTimer();

        event Action ev;

        bool isEnabled = false;

        #endregion

        #region Interface implementation

        bool IEvent.IsEnabled
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
                isEnabled = value;
                if (isEnabled)
                {
                    timer.Tick += Timer_Tick;
                    timer.Start();
                    return;
                }
                timer.Stop();
                timer.Tick -= Timer_Tick;
            }
        }

        TimeSpan ITimerEvent.TimeSpan
        {
            get
            {
                return timer.Interval;
            }

            set
            {
                timer.Interval = value;
            }
        }

        event Action IEvent.Event
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

        void IDisposable.Dispose()
        {
           if (timer != null)
            {
                if (isEnabled)
                {
                    timer.Stop();
                    timer.Tick -= Timer_Tick;
                }
                timer = null;
            }
        }

        #endregion

        private void Timer_Tick(object sender, EventArgs e)
        {
            ev?.Invoke(); 
        }
    }
}
