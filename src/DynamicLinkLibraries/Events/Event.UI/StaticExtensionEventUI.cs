using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;

using AssemblyService.Attributes;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;

using Event.Interfaces;
using Event.UI.Forms;

using WindowsExtensions;

using KeyboardHMI;

namespace Event.UI
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionEventUI
    {

        static Dictionary<Key, Keys> dkeys = new Dictionary<Key, Keys>();

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionEventUI()
        {
            new Binder();

            var k = Enum.GetValues<Key>();
            var d = new Dictionary<string, Key>();
            foreach (var x in k)
            {
                var y = x + "";
                d[y] = x;
                if (y.EndsWith("Arrow"))
                {
                    var z = y.Substring(0, y.Length - "Arrow".Length);
                    d[z] = x;
                }
            }
            var kk = Enum.GetValues<Keys>();
            var dk = new Dictionary<string, Keys>();
            foreach (var x in kk)
            {
                dk[x + ""] = x;
            }
            foreach (var x in d)
            {
                var val = x.Value + "";
                if (dk.ContainsKey(val))
                {
                    dkeys[x.Value] = dk[val];
                }
                else if (val.EndsWith("Arrow"))
                {
                    var z = val.Substring(0, val.Length - "Arrow".Length);
                    dkeys[x.Value] = dk[z];
                }
            }
        }

        static public Keys ToKeyType(this string key)
        {
            var k = StaticExtensionKeyBoard.ToKeyType(key);
            return dkeys[k];
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