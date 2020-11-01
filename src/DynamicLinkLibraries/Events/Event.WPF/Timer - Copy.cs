﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

using Event.Interfaces;

namespace Event.WPF
{
    /// <summary>
    /// WPF timer
    /// </summary>
    class Timer : ITimer,  IDisposable
    {

        #region Fields

        event Action ev = () => { };

        DispatcherTimer timer = new DispatcherTimer();

        bool isEnabled = false;

   //     TimeSpan timeSpan = new TimeSpan();

        #endregion

        #region Ctor

        internal Timer(TimeSpan timeSpan)
        {
            timer.Tick += (object sender, EventArgs e) =>
            {
                ev();
            };
            timer.Interval = timeSpan;
        }


        #endregion

        #region ITimer Members

        TimeSpan ITimer.TimeSpan
        {
            get
            {
                return timer.Interval;
            }
        }

        event Action ITimer.Event
        {
            add { ev += value; }
            remove { ev -= value; }
        }

  
        bool ITimer.IsEnabled
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
                timer.IsEnabled = value;
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
            try
            {
                if (timer != null)
                {
                    timer.Stop();
                }
            }
            catch (Exception)
            {

            }
            timer = null;
        }

        #endregion

    }
}
