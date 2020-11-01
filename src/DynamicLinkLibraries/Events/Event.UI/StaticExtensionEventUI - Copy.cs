using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;

using Event.Interfaces;
using Event.UI.Forms;

using WindowsExtensions;

namespace Event.UI
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    public static class StaticExtensionEventUI
    {
        /// <summary>
        /// Edition of conncetion sttring
        /// </summary>
        static public void EditConnectionSrtring()
        {
            Form form = new FormConnectionString();
            form.ShowDialog();
        }

        /// <summary>
        /// Enable runtime
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="enable">Enable</param>
        /// <param name="calculationReason">Calculation reason</param>
        /// <param name="list">List of updates</param>
        public static void EnableRuntime(this Control control, bool enable, string calculationReason = null, 
            List<IRealtimeUpdate> list = null)
        {
            foreach (Control c in control.Controls)
            {
                c.EnableRuntime(enable, calculationReason, list);
            }
            if (control is IShowForm)
            {
                Control f = (control as IShowForm).Form as Control;
                if (f != null)
                {
                    if (!f.IsDisposed)
                    {
                        f.EnableRuntime(enable, calculationReason, list);
                    }
                }
            }
            if (calculationReason != null)
            {
                if (control is ICalculationReason)
                {
                    (control as ICalculationReason).CalculationReason = calculationReason;
                }
            }
            if (control is IRealTimeStartStop)
            {
                IRealTimeStartStop rt = control as IRealTimeStartStop;
                if (enable)
                {
                   control.InvokeIfNeeded(() => rt.Start());
                }
                else
                {
                    rt.Stop();
                }
            }
            if (list != null)
            {
                if (control is IRealtimeUpdate)
                {
                    IRealtimeUpdate up = control as IRealtimeUpdate;
                    if (!list.Contains(up))
                    {
                        list.Add(up);
                    }
                }
            }
       }

        /// <summary>
        /// Creates start
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="reason">Runtime reason</param>
        /// <param name="update">Update action</param>
        /// <param name="start">Start action</param>
        /// <param name="stop">Stop action</param>
        public static void CreateEventActions(this Control control,
           ref Action update, ref Action start, ref Action stop)
        {
            foreach (Control c in control.Controls)
            {
                if (c is IRealtimeUpdate)
                {
                    if (update != null)
                    {
                        update = update + (c as IRealtimeUpdate).Update;
                    }
                }
                if (c is IRealTimeStartStop)
                { 
                    if (start != null)
                    {
                        Action act = () => { (c as IRealTimeStartStop).Start(); };
                        start = start + act;
                    }
                    if (stop != null)
                    {
                        stop = stop + (c as IRealTimeStartStop).Stop;
                    }
                }
                c.CreateEventActions(ref update, ref start, ref stop);
            }
        }
    }
}