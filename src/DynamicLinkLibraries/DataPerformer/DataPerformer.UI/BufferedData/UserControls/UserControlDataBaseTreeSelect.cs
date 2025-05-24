using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Diagram.UI;

using DataPerformer.Interfaces;
using DataPerformer.Interfaces.BufferedData.Interfaces;
using ErrorHandler;

namespace DataPerformer.UI.BufferedData.UserControls
{
    public partial class UserControlDataBaseTreeSelect : UserControl
    {
        #region Fields

        Event.Portable.Objects.BufferedData.BufferReadWrite buffer;

        event Action<TreeNode> changeNode = (TreeNode n) => { };

        TreeNode current;

        #endregion

        #region Ctor

 
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlDataBaseTreeSelect()
        {
            InitializeComponent();
            Fill();
        }


        #endregion

        #region Public Members

        /// <summary>
        /// Log
        /// </summary>
        public Event.Portable.Objects.BufferedData.BufferReadWrite Buffer
        {
            get
            {
                return buffer;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                buffer = value;
                GetUrl();
            }
        }

        /// <summary>
        /// Fills itself
        /// </summary>
         public void Fill()
        {
            treeViewMain.Nodes.Clear();
            IBufferDirectory dir = StaticExtensionDataPerformerInterfaces.Root;
            if (dir == null)
            {
                return;
            }
            treeViewMain.ImageList = StaticExtensionDataPerformerUI.BufferDataImageList;
            List<TreeNode> l = new List<TreeNode>();
            l.Sort(StaticExtensionDataPerformerUI.BufferComparer);
            TreeNode n = dir.CreateNode();
                treeViewMain.Nodes.Add(n);
            GetUrl();
        }

        /// <summary>
        /// Change node event
        /// </summary>
        public event Action<TreeNode> ChangeNode
        {
            add { changeNode += value; }
            remove { changeNode -= value; }
        }

        #endregion

        #region Private Members

        void GetUrl()
        {
            if (buffer == null)
            {
                return;
            }
            string url = buffer.Url;
            TreeNode n = treeViewMain.Find(url);
            if (n != null)
            {
                if (treeViewMain.SelectedNode == n)
                {
                    return;
                }
                treeViewMain.SelectedNode = n;
                IBufferItem d = n.Tag as IBufferItem;
       //         toolStripLabelSize.Text = "";// = "Length = " + d.GetLength();
       //         toolStripLabelSize.Visible = true;
            }
            else
            {
         //       toolStripLabelSize.Visible = false;
            }
        }

        void SetUrl()
        {
            TreeNode n = treeViewMain.SelectedNode;
            if (n == current)
            {
                return;
            }
            current = n;
            changeNode(n);
            if (n == null)
            {
                return;
            }
            if (buffer == null)
            {
                return;
            }
            if (n.Tag is IBufferItem)
            {
                IBufferItem d = n.Tag as IBufferItem;
                string uid = d.GetUrl();
                try
                {
                    buffer.Url = uid;
                //    toolStripLabelSize.Text = "";//"Length = " + d.GetLength();
                //    toolStripLabelSize.Visible = true;
                }
                catch (Exception exception)
                {
                    exception.HandleException();
                }
                return;
            }
       //     toolStripLabelSize.Visible = false;
        }

        #endregion

        #region Event Handlers

        private void UserControlDataBaseTreeSelect_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetUrl();
        }

        #endregion
    }
}
