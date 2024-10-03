using System.Collections.Generic;
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
