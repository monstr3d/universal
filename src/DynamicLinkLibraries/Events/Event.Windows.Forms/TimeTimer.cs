using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Interfaces;

namespace Event.Windows.Forms
{
    class TimeTimer : ITimer, IDisposable
    {

        TimeSpan timeSpan;

         System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

       // System.Threading.Timer timer = new System.Threading.Timer(null);

        event Action ev = () => { };


        internal TimeTimer(TimeSpan timeSpan)
        {
            this.timeSpan = timeSpan;
            timer.Interval = (int)timeSpan.TotalMilliseconds;
            timer.Tick += (object sender, EventArgs e) =>
            {
                ev();
            };

        }


        bool ITimer.IsEnabled
        {
            get
            {
                return timer.Enabled;
            }
            set
            {
                if (timer.Enabled != value)
                {
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
        }

        TimeSpan ITimer.TimeSpan
        {
            get
            {
                return timeSpan;
            }
        }

        event Action ITimer.Event
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
            timer.Dispose();
        }
    }
}
