using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace BasicEngineering.UI.Factory.Advanced.Forms
{
    public partial class FormDockableTree : DockContent
    {
        public FormDockableTree()
        {
            InitializeComponent();
            init();
            this.LoadControlResources();
        }

        public TreeView Tree
        {
            get
            {
                return treeViewMain;
            }
        }


        private void init()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            AllowDrop = true;

            this.ShowIcon = true;

            //Prepare richTextbox's context menu.
            ContextMenuStrip theMenu;
            ToolStripMenuItem menuItem;

            theMenu = new ContextMenuStrip();

            menuItem = new ToolStripMenuItem("Undo");
            //            menuItem.Click += new EventHandler(OnTexBoxMenu_Undo);
            theMenu.Items.Add(menuItem);

            menuItem = new ToolStripMenuItem("-");
            theMenu.Items.Add(menuItem);

            /*menuItem = new MenuItem("Cut");
            menuItem.Click += new EventHandler(OnTexBoxMenu_Cut);
            theMenu.MenuItems.Add(menuItem);*/
            /*
                        menuItem = new MenuItem("Copy");
                        menuItem.Click += new EventHandler(OnTexBoxMenu_Copy);
                        theMenu.MenuItems.Add(menuItem);

                        menuItem = new MenuItem("Paste");
                        menuItem.Click += new EventHandler(OnTexBoxMenu_Paste);
                        theMenu.MenuItems.Add(menuItem);

                        menuItem = new MenuItem("Delete");
                        menuItem.Click += new EventHandler(OnTexBoxMenu_Delete);
                        theMenu.MenuItems.Add(menuItem);

                        menuItem = new MenuItem("-");
                        theMenu.MenuItems.Add(menuItem);

                        menuItem = new MenuItem("Select All");
                        menuItem.Click += new EventHandler(OnTexBoxMenu_SelectAll);
                        theMenu.MenuItems.Add(menuItem);

                        theMenu.Popup += new EventHandler(OnTexBoxMenu_Popup);

                        _textBox.ContextMenu = theMenu;

                        Controls.Add(_textBox);

                        _upScroll.Enabled = false;
                        _dnScroll.Enabled = false;
            */
            this.DockAreas = ((DockAreas)(((((DockAreas.Float | DockAreas.DockLeft)
                | DockAreas.DockRight)
                | DockAreas.DockTop)
                | DockAreas.DockBottom)));
            this.ClientSize = new System.Drawing.Size(180, 300);
            this.DockPadding.Bottom = 3;
            this.DockPadding.Top = 3;
            this.HideOnClose = true;
            this.Name = "Objects";
            this.ShowHint = DockState.DockLeft;
            this.Text = "Objects' tree";

        }

    }
}
