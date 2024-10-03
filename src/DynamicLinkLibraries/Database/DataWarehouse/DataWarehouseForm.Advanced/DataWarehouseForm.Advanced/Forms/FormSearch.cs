using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace DataWarehouse.Advanced.Forms
{
    public partial class FormSearch : DockContent
    {
        #region Ctor

        public FormSearch()
        {
            InitializeComponent();
            this.LoadControlResources();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Tree
        /// </summary>
        public TreeView Tree
        {
            get
            {
                return userControlTreeSearch.Tree;
            }
            set
            {
                if (value != null)
                {
                    userControlTreeSearch.Tree = value;
                }
            }
        }

        public void DeleteTag(object tag)
        {
            userControlTreeSearch.DeleteTag(tag);
        }

        /// <summary>
        /// Search text
        /// </summary>
        public string SearchText
        {
            set
            {
                userControlTreeSearch.SearchText = value;
            }
        }

        /// <summary>
        /// Open Node Event
        /// </summary>
        public event Action<TreeNode> OpenNode
        {
            add { userControlTreeSearch.OpenNode += value; }
            remove { userControlTreeSearch.OpenNode -= value; }
        }

        /// <summary>
        /// Remove Node Event
        /// </summary>
        public event Action<TreeNode> RemoveNode
        {
            add { userControlTreeSearch.RemoveNode += value; }
            remove { userControlTreeSearch.RemoveNode -= value; }
        }

        /// <summary>
        /// Remove Node Event
        /// </summary>
        public event Action<TreeNode> OnRemoveNode
        {
            add { userControlTreeSearch.OnRemoveNode += value; }
            remove { userControlTreeSearch.OnRemoveNode -= value; }
        }


        #endregion

        #region Private Members


        private void init()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            AllowDrop = true;

            //Prepare richTextbox's context menu.
            ContextMenuStrip theMenu;
            ToolStripMenuItem menuItem;

            theMenu = new ContextMenuStrip();

            menuItem = new ToolStripMenuItem("Undo");
            theMenu.Items.Add(menuItem);

            menuItem = new ToolStripMenuItem("-");
            theMenu.Items.Add(menuItem);

            this.DockAreas = ((DockAreas)(((((DockAreas.Float | DockAreas.DockLeft)
                | DockAreas.DockRight)
                | DockAreas.DockTop)
                | DockAreas.DockBottom)));
            this.ClientSize = new System.Drawing.Size(180, 300);
            this.DockPadding.Bottom = 3;
            this.DockPadding.Top = 3;
            this.HideOnClose = true;
            this.ShowHint = DockState.DockRight;

        }


        #endregion
    }
}
