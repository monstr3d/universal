using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using WindowsExtensions;

namespace DataPerformer.UI.UserControls
{
    public partial class UserControlRealtimeAnalysis : UserControl
    {

        Dictionary<string, ListViewItem> d = new Dictionary<string, ListViewItem>();

        public UserControlRealtimeAnalysis()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal IEnumerable<string> Names
        {
            set
            {
                listView.Items.Clear();
                d.Clear();
                foreach (string name in value)
                {
                    ListViewItem it = new ListViewItem(new string[] { name, "" });
                    listView.Items.Add(it);
                    d[name] = it;
                }
                Refresh();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal IDictionary<string, object> Dictionary
        {
            set
            {
                this.InvokeIfNeeded(() =>
                {
                    foreach (string key in d.Keys)
                    {
                        if (value.ContainsKey(key))
                        {
                            object o = value[key];
                            ListViewItem it = d[key];
                            it.SubItems[1].Text = o + "";
                        }
                    }
                    Refresh();
                });
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal double Time
        {
            set
            {
                this.InvokeIfNeeded(() =>
                {
                    labelTime.Text = "Time = " + value;
                    labelCadr.Text = "Cadr = " + global::Event.Portable.StaticExtensionEventPortable.Cadr;
                });
            }
        }
    }
}
