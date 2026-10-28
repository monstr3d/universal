using Diagram.UI;

using Event.Basic.Data.Events;
using Event.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Event.UI.UserControls
{
    public partial class UserControlEventDataFull : UserControl
    {
        #region Fields

        ForcedEventData forced;

        UserControlEventData udata;

        UserControlEventDataKey ukey;

        #endregion

        public UserControlEventDataFull()
        {
            InitializeComponent();
            udata = this.FindChild<UserControlEventData>();
            ukey = this.FindChild<UserControlEventDataKey>();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ForcedEventData Forced
        {
            set
            {
                forced = value;
                udata.Forced = value;
                ukey.Forced = value;
            }
        }

        internal void UpdateAll()
        {
            var l = new List<Tuple<string, object>>();
            var ini = new List<object>();
            var d = new List<object>();
            var i = 0;
            foreach (var item in udata.Types)
            {
                l.Add(item);
                ini.Add(udata.Initial[i]);
                d.Add(udata.Data[i]);

            }
            var kb = StaticExtensionEventInterfaces.Keyboard;

            foreach (var item in ukey.Types)
            {
                var it = kb + item.Item1;
                var ii =  item.Item2;
                if (ii != null)
                {
                    it += '_' + ii;
                }
                l.Add(new Tuple<string, object>(it, item.Item3));
                ini.Add(udata.Initial[i]);
                d.Add(udata.Data[i]);

            }
            forced.Types = l;
            forced.Initial = ini.ToArray();
            forced.Data = d.ToArray();
        }
    }
}
