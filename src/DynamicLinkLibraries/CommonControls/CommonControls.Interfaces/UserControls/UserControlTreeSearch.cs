using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CommonControls.Interfaces;

namespace CommonControls.Interfaces.UserControls
{
    /// <summary>
    /// Search on tree
    /// </summary>
    public partial class UserControlTreeSearch : UserControl
    {
        #region Fields

        TreeView tree;

        int num;

        private event Action<TreeNode> openNode = (TreeNode node) => { };

        private event Action<TreeNode> removeNode = (TreeNode node) => { };

        private event Action<TreeNode> onRemoveNode = (TreeNode node) => { };
       
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlTreeSearch()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Delete tag
        /// </summary>
        /// <param name="tag"></param>
        public void DeleteTag(object tag)
        {
            List<ListViewItem> l = new List<ListViewItem>();
            foreach (ListViewItem it in listView.Items)
            {
                TreeNode tn = it.Tag as TreeNode;
                if (tn.Tag == tag)
                {
                    l.Add(it);
                }
            }
            foreach (ListViewItem it in l)
            {
                it.Remove();
            }
       }

        /// <summary>
        /// Tree
        /// </summary>
        public TreeView Tree
        {
            get
            {
                return tree;
            }
            set
            {
                if (value != null)
                {
                    tree = value;
                }
            }
        }

        /// <summary>
        /// Search text
        /// </summary>
        public string SearchText
        {
            set
            {
                Search(value);
            }
        }

        /// <summary>
        /// Open Node Event
        /// </summary>
        public event Action<TreeNode> OpenNode
        {
            add { openNode += value; }
            remove { openNode -= value; }
        }

        /// <summary>
        /// Remove Node Event
        /// </summary>
        public event Action<TreeNode> RemoveNode
        {
            add { removeNode += value; }
            remove { removeNode -= value; }
        }
       
        /// <summary>
        /// Remove Node Event
        /// </summary>
        public event Action<TreeNode> OnRemoveNode
        {
            add { onRemoveNode += value; }
            remove { onRemoveNode -= value; }
        }

        #endregion

        #region Event Handlers

        private void listView_Resize(object sender, EventArgs e)
        {
            columnHeaderPath.Width = listView.Width - 100;
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            TreeNode n = Selected;
            n.Select();
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode n = Selected;
            if (n == null)
            {
                return;
            }
            openNode(n);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode n = Selected;
            if (n != null)
            {
                onRemoveNode(n);
            }
        }
 

 
        #endregion

        #region Private

        TreeNode Selected
        {
            get
            {
                ListView.SelectedListViewItemCollection c = listView.SelectedItems;
                if (c.Count == 0)
                {
                    return null;
                }
                ListViewItem it = listView.SelectedItems[0];
                if (it != null)
                {
                    return it.Tag as TreeNode;
                }
                return null;
            }
        }

        private string GetPath(TreeNode node)
        {
           /* string s = "";
            TreeNode p = node.Parent;
            if (p != null)
            {
                s = GetPath(p) + "->";
            }
            return s + node.Text;*/

            return node.FullPath;
        }

        void Search(string text)
        {
            num = 1;
            foreach (TreeNode n in tree.Nodes)
            {
                Search(text, n);
            }
        }


        void Search(string text, TreeNode node)
        {
            if (node.Text.ToLower().Contains(text.ToLower()))
            {
                string[] s = new string[]{num + "", GetPath(node)};
                ListViewItem it = new ListViewItem(s);
                it.Tag = node;
                listView.Items.Add(it);
                ++num;
            }
            foreach (TreeNode n in node.Nodes)
            {
                Search(text, n);
            }
        }

        #endregion

  
    }
}
