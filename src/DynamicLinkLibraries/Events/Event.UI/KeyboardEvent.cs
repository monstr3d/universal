using Event.Interfaces;
using Event.Portable.Events;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Event.UI
{
    public class KeyboardEvent
    {
        Dictionary<Keys, Tuple<int, bool, object[]>> dup = new();

        string kb  = StaticExtensionEventInterfaces.Keyboard;
 

        Portable.Events.ForcedEventData forced;

        public KeyboardEvent(ForcedEventData forced)
        {
            this.forced = forced;
        }

        public void Prepare()
        {
            dup.Clear();
            for (int i = 0; i < forced.Types.Count; i++)
            {
                var t = forced.Types[i];
                var name = t.Item1;
                if (!name.StartsWith(kb))
                {
                    continue;
                }
                var n = name.Substring(kb.Length).Split("_");
                bool b = true;
                foreach (var nk in n)
                {
                    var key = nk.ToKeyType();
                    var obj = BaseTypes.StaticExtensionBaseTypes.GetObjectFromTypeA(t.Item2.GetType());
                    var tp = new Tuple<int, bool, object[]>(i, b, obj);
                    b = false;
                    dup[key] = tp;
                }
            }
        }

        void KeyDown(object sender, KeyEventArgs e)
        {
            if (dup.ContainsKey(e.KeyCode))
            {
                var d = dup[e.KeyCode];
                var v = d.Item2;
                var x = v ? d.Item3[d.Item3.Length - 1] : d.Item3[0];
                forced.Data[d.Item1] = x;
                forced.Force();
            }
        }

        void KeyUp(object sender, KeyEventArgs e)
        {
            if (dup.ContainsKey(e.KeyCode))
            {
                var d = dup[e.KeyCode];
                var x = d.Item3.Length == 3 ? d.Item3[1] : d.Item3[0];
                forced.Data[d.Item1] = x;
                forced.Force();
            }
        }

        public void Set(Control control, bool add, bool rec = true)
        {
            if (add)
            {
                control.KeyUp += KeyUp;
                control.KeyDown += KeyDown;
            }
            else
            {
                control.KeyUp -= KeyUp;
                control.KeyDown -= KeyDown;
            }
            if (rec)
            {
                foreach (var d in control.Controls)
                {
                    if (d is Control ctr)
                    {
                        Set(ctr, add, rec);
                    }
                }
            }
        }

    }
}
