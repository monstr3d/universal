using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;

using Event.Interfaces;
using Event.UI.Forms;

using WindowsExtensions;
using AssemblyService.Attributes;

namespace Event.UI
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionEventUI
    {
        /// <summary>
        /// Inits itself
        /// </summary>
        public static void Init()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionEventUI()
        {
            new Binder();
        }
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

        class Binder : SerializationBinder
        {
            internal Binder()
            {
                this.Add();
            }

            public override Type BindToType(string assemblyName, string typeName)
            {
                string ass = assemblyName;
                string tn = typeName;
                if (assemblyName.Contains("Event.UI,"))
                {
                    var a = typeof(Binder).Assembly.FullName;
                    Type type = Type.GetType(string.Format("{0}, {1}", tn, a));
                    if (type != null)
                    {
                        return type;
                    }
                  }
                return null;
            }
        }
    }
}