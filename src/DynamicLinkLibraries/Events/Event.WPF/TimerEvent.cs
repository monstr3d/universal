using System.Windows.Threading;

using Event.Interfaces;

namespace Event.WPF
{
    class TimerEvent : ITimerEvent, IDisposable
    {

        #region Fields

        DispatcherTimer timer = new DispatcherTimer();

        event Action ev;

        event Action proxy;


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
                    CreateProxy();
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

        Action IEventProxy.Proxy { get => proxy; set => proxy = value; }

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

        protected event Action<Action> onCreate;

        event Action<Action> IEventProxy.OnCreate
        {
            add
            {
                onCreate += value;
            }

            remove
            {
                onCreate -= value;
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
            proxy();
        }

        void IEventProxy.CreateProxy()
        {
            CreateProxy();
        }

        protected void CreateProxy()
        {
            proxy = () => { ev?.Invoke(); };
            onCreate?.Invoke(ev);

        }
    }
}
