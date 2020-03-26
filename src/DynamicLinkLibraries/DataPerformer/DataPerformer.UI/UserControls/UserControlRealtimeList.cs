using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using DataPerformer.Interfaces;

using WindowsExtensions;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Realtime list
    /// </summary>
    public partial class UserControlRealtimeList : UserControl
    {
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlRealtimeList()
        {
            InitializeComponent();
        }

        #endregion


        #region Internal members

       internal void Set(List<Tuple<string, object[]>> list)
       {
           listView.Items.Clear();
           foreach (Tuple<string, object[]> t in list)
           {
               ListViewItem it = new ListViewItem(new string[]{ t.Item1, ""});
               listView.Items.Add(it);
               it.Tag = t.Item2;
           }
       }

       new internal void Show()
       {
           this.InvokeIfNeeded(ShowPrivate);
       }

        #endregion

       #region Private Members

       private void ShowPrivate()
       {
           foreach (ListViewItem it in listView.Items)
           {
               object[] o = it.Tag as object[];
               it.SubItems[1].Text = o[0] + "";
           }
       }

       #endregion

    }
}
