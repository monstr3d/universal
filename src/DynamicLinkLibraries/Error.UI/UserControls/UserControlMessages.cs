using System;
using System.Windows.Forms;


using WindowsExtensions;

namespace Error.UI.UserControls
{
    public partial class UserControlMessages : UserControl
    {
        // private Action<string[]> act;

        public UserControlMessages()
        {
            InitializeComponent();

        }

        public void Add(string[] str)
        {

            this.InvokeIfNeeded<string[]>(AddPrivate, str);
        }

        private void Clear()
        {
            this.InvokeIfNeeded(() => { listView.Items.Clear(); });
        }

        private static readonly TimeSpan Span = new TimeSpan(0, 1, 0);

        private void AddPrivate(string[] str)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string[] ss = new string[] { str[0], dt.ToLongTimeString(), str[1] };
                ListViewItem li = new ListViewItem(ss);
                li.Tag = dt;
                listView.Items.Add(li);
                int i = listView.Items.Count - 1;
                for (; i >= 0; i--)
                {
                    ListViewItem it = listView.Items[i];
                    DateTime t = (DateTime)it.Tag;
                    TimeSpan ts = dt - t;
                    if (ts > Span)
                    {
                        break;
                    }

                }
                if (i < listView.Items.Count - 1)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        listView.Items.RemoveAt(0);
                    }
                }
                /*  if (listView.Items.Count > 20)
                  {
                      listView.Items.RemoveAt(0);
                  }*/
                if (!listView.IsDisposed)
                {
                    listView.TopItem = li;
                }
            }
            catch (Exception)
            {
            }
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void listView_Resize(object sender, EventArgs e)
        {
            columnHeaderMessage.Width = listView.Width - 100;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection c = listView.SelectedItems;
            string s = "";
            foreach (ListViewItem it in c)
            {
                s += it.SubItems[2].Text;
            }
            if (s.Length > 0)
            {
                Clipboard.SetText(s);
            }
        }


    }
}
