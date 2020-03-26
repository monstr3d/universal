using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;

using Event.Log.Database.Interfaces;
using Event.Portable;
using Event.Basic;

namespace Event.Log.Database.UI.UserControls
{
    public partial class UserControlDataBaseTreeSelect : UserControl
    {

        #region Fields

        LogHolder log;

        bool fileOnly = false;

        event Action<TreeNode> changeNode = (TreeNode n) => { };

        TreeNode current;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlDataBaseTreeSelect(bool fileOnly) :
            this()
        {
            this.fileOnly = fileOnly;
          
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlDataBaseTreeSelect()
        {
            InitializeComponent();
        }


        #endregion

        #region Public Members

        /// <summary>
        /// Log
        /// </summary>
        public LogHolder Log
        {
            get
            {
                return log;
            }
            set
            {
                log = value;
                GetUrl();
            }
        }

        /// <summary>
        /// Fills itself
        /// </summary>
        /// <param name="fileOnly">Only files</param>
        public void Fill(bool fileOnly = false)
        {
            treeViewMain.Nodes.Clear();
            ILogDirectory[] dirs = StaticExtensionEventLogDatabase.Roots;
            if (dirs == null)
            {
                return;
            }
            treeViewMain.ImageList = StaticExtensionEventLogDatabaseUI.ImageList;
            List<TreeNode> l = new List<TreeNode>();
            foreach (ILogDirectory d in dirs)
            {
                if (fileOnly)
                {
                    if (!d.Name.Equals("Files"))
                    {
                        continue;
                    }
                }
                TreeNode n = d.CreateNode();
                l.Add(n);
            }
            l.Sort(StaticExtensionEventLogDatabaseUI.Comparer);
            foreach (TreeNode n in l)
            {
                treeViewMain.Nodes.Add(n);
            }
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
            if (log == null)
            {
                return;
            }
            string url = log.Url;
            TreeNode n = treeViewMain.Find(url);
            if (n != null)
            {
                if (treeViewMain.SelectedNode == n)
                {
                    return;
                }
                treeViewMain.SelectedNode = n;
                ILogItem d = n.Tag as ILogItem;
                toolStripLabelSize.Text = "Length = " + d.GetLength();
                toolStripLabelSize.Visible = true;
            }
            else
            {
                toolStripLabelSize.Visible = false;
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
            if (log == null)
            {
                return;
            }
            if (n.Tag is ILogItem)
            {
                ILogItem d = n.Tag as ILogItem;
                string uid = d.GetUrl();
                try
                {
                    log.Url = uid;
                    toolStripLabelSize.Text = "Length = " + d.GetLength();
                    toolStripLabelSize.Visible = true;
                }
                catch (Exception exception)
                {
                    exception.ShowError();
                }
                return;
            }
            toolStripLabelSize.Visible = false;
        }

        #endregion

        #region Event Handlers

        private void UserControlDataBaseTreeSelect_Load(object sender, EventArgs e)
        {
            Fill(fileOnly);
        }

        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetUrl();
        }

        #endregion
    }
}
