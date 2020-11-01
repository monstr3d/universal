using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using WeifenLuo.WinFormsUI.Docking;

using DataWarehouse;
using DataWarehouse.Utils;
using DataWarehouse.Interfaces;

using Common.UI;

namespace DataWarehouse.Advanced.Forms
{
    /// <summary>
    /// Database tree
    /// </summary>
    public partial class FormDatabaseTree : DockContent
    {
        #region Fields

        FormSearch formSearch;

        DockPanel dockPanel;

        #endregion

        #region Ctor

        private FormDatabaseTree()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Costructor
        /// </summary>
        /// <param name="data">Database interface</param>
        /// <param name="ext">Extension</param>
        /// <param name="image">Tree image</param>
        public FormDatabaseTree(DatabaseInterface data, string ext, Image image)
            : this()
        {
            this.LoadControlResources();
            userControlTree.Set(data, ext, image);
            init();
            formSearch = new FormSearch();
            formSearch.Tree = userControlTree.Tree;
            StaticExtensionDataWarehouse.RemoveNode += userControlTree.DeleteNodeTag;
            StaticExtensionDataWarehouse.RemoveNode += (INode n) =>
                {
                    formSearch.DeleteTag(n);
                };
            formSearch.OnRemoveNode += onRemoveNode;
        }

        #endregion

        #region Overriden

        public override void Show(DockPanel dockPanel)
        {
            base.Show(dockPanel);
            if (this.dockPanel == null)
            {
                this.dockPanel = dockPanel;
            }
        }


        #endregion

        #region Public Members

        /// <summary>
        /// Open Node Event
        /// </summary>
        public event Action<TreeNode> OpenNode
        {
            add { formSearch.OpenNode += value; }
            remove { formSearch.OpenNode -= value; }
        }

        #endregion

        #region Members

        void Remove(INode node)
        {
        }

        void Search(string s)
        {
            if (s.Length > 0)
            {
                formSearch.SearchText = s;
                formSearch.Show(dockPanel);
            }
        }



        private void init()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            AllowDrop = true;

            //Prepare richTextbox's context menu.
            ContextMenu theMenu;
            MenuItem menuItem;

            theMenu = new ContextMenu();

            menuItem = new MenuItem("Undo");
            theMenu.MenuItems.Add(menuItem);

            menuItem = new MenuItem("-");
            theMenu.MenuItems.Add(menuItem);

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

        private void onRemoveNode(TreeNode obj)
        {
            object o = obj.Tag;
            if (o is INode)
            {
                (o as INode).Remove();
            }
        }

        private void userControlTree_OnRemove(TreeNode obj)
        {
            onRemoveNode(obj);
        }
    }
}