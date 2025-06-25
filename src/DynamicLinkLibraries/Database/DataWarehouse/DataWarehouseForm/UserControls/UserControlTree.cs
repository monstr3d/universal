using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Common.UI;

using CommonControls.Interfaces;

using DataWarehouse.Forms;
using DataWarehouse.Interfaces;

namespace DataWarehouse.UserControls
{
    /// <summary>
    /// User control for database tree
    /// </summary>
    public partial class UserControlTree : UserControl
    {

        #region Fields
        string ext;
        DatabaseInterface data;
        Image image;

        private event Action<TreeNode> onRemove = (TreeNode n) => { };

        private event Action<string> onSearch = (string text) => { };

        Dictionary<INode, TreeNode> nodes = new Dictionary<INode, TreeNode>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlTree()
        {
            InitializeComponent();
            /*  !!! ADD EVENTS
            StaticExtensionDataWarehouse.OnRemoveNode += DeleteNodeTag;
            StaticExtensionDataWarehouse.OnAddNode += OnAddNode;
            StaticExtensionDataWarehouse.OnChangeNode += OnChangeNode;
            */
        }
  
        #endregion

        #region Public

        /// <summary>
        /// On remove event
        /// </summary>
        public event Action<TreeNode> OnRemove
        {
            add { onRemove += value; }
            remove { onRemove -= value; }
        }

        /// <summary>
        /// On search event
        /// </summary>
        public event Action<string> OnSearch
        {
            add { onSearch += value; }
            remove { onSearch -= value; }
        }

        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="data">Database interface</param>
        /// <param name="ext">Extension</param>
        /// <param name="image">Tree image</param>
        public void Set(DatabaseInterface data, string ext, Image image)
        {
            this.data = data;
            this.image = image;
            ImageList l = new ImageList();
            l.Images.Add(ResourceImage.CLSDFOLD);
            l.Images.Add(ResourceImage.OPENFOLD);
            l.Images.Add(image);
            treeViewMain.ImageList = l;
            Fill();
            this.ext = ext;
            treeViewMain.BeforeExpand += TreeViewMain_BeforeExpand;
         }

        private void TreeViewMain_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var node = e.Node;
            if (node == null)
            {
                return;
            }
            foreach (var n in node.Nodes)
            {
                if (n is Forms.Tree.TreeNode nd)
                {
                    nd.Expand(true);
                }
            }
        }

        /// <summary>
        /// Tree
        /// </summary>
        public TreeView Tree
        {
            get
            {
                return treeViewMain;
            }
        }

        /// <summary>
        /// Deletes node tag
        /// </summary>
        /// <param name="node"></param>
        public void DeleteNodeTag(INode node)
        {
            nodes[node].Remove();
        }

        #endregion

        #region Event Handlers

        private void treeViewMain_MouseDown(object sender, MouseEventArgs e)
        {
            var node = treeViewMain.GetNodeAt(e.Location);
            if (node == null)
            {
                return;
            }
            object o = node.Tag;
            if (o is ILeaf leaf)
            {
                IStreamCreator sc = new DatabaseStreamCreator(leaf);
                treeViewMain.DoDragDrop(sc, DragDropEffects.All);
            }
        }

        private void refresh()
        {
            try
            {
                treeViewMain.Nodes[0].Remove();
                Fill();
            }
            catch (Exception)
            {
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void toolStripButtonFind_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void toolStripTextBoxFind_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = treeViewMain.SelectedNode;
            if (tn != null)
            {
                onRemove(tn);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedNode.Save();
        }

        #endregion

        #region Private

        private void OnChangeNode(INode node)
        {
            nodes[node].Text = node.Name;
        }


        private void OnAddNode(IDirectory directory, INode node)
        {
            var tn = nodes[directory];
            var tnl = (node is ILeaf) ? new TreeNode(node.Name, 2, 2) : new TreeNode(node.Name, 0, 1);
            tnl.Tag = node;
            tn.Nodes.Add(tnl);
            nodes[node] = tnl;
        }


        private INode SelectedNode
        {
            get
            {
                TreeNode tn = treeViewMain.SelectedNode;
                if (tn == null)
                {
                    return null;
                }
                return tn.Tag as INode;
            }
        }

        void Search()
        {
            string s = toolStripTextBoxFind.Text;
            if (s.Length > 0)
            {
                onSearch(s);
            }
        }

        void SetDisposed(System.Windows.Forms.TreeNode node)
        {
            var n = node as Forms.Tree.TreeNode;
            n.SetDisposed();
            foreach (TreeNode tn in node.Nodes)
            {
                SetDisposed(tn); ;
            }
        }

   
        void Fill()
        {
            treeViewMain.Fill(data, ext);
      /* !!! DELETE      IDirectory[] dir = data.GetRoots(new string[] { ext });
            foreach (IDirectory d in dir)
            {
                var nd = d.GetNode();
                treeViewMain.Nodes.Add(nd);
            }
            foreach (System.Windows.Forms.TreeNode tn in treeViewMain.Nodes)
            {
                SetDisposed(tn);
            }*/
        }

        

        #endregion

    }
}
