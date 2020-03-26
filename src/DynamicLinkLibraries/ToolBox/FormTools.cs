using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace ToolBox
{
	/// <summary>
	/// Toolbox form
	/// </summary>
	public class FormTools : Form
	{
		private System.Windows.Forms.Button buttonEdit;
		private System.Windows.Forms.Button buttonPicture;
		private IToolBox parent;
		static private Image pictImage;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        /// <summary>
        /// Constructor
        /// </summary>
		public FormTools()
		{
			InitializeComponent();
            ResourceService.Resources.LoadControlResources(this, Common.UI.Resources.Utils.ControlUtilites.Resources);
			if (pictImage == null)
			{
				pictImage = buttonPicture.Image;
			}
            init();
		}
		
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent</param>
		public FormTools(IToolBox parent)
		{
			InitializeComponent();
            ResourceService.Resources.LoadControlResources(this,
                new Dictionary<string, object>[]
                {
                ResourceService.Resources.ControlResources});
            this.parent = parent;
			if (pictImage == null)
			{
				pictImage = buttonPicture.Image;
			}
            init();
		}

        /// <summary>
        /// Picture image
        /// </summary>
		public static Image PictImage
		{
			get
			{
				return pictImage;
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			if (parent != null)
			{
				parent.ToolBox = null;
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTools));
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonPicture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEdit
            // 
            this.buttonEdit.AllowDrop = true;
            this.buttonEdit.Image = ((System.Drawing.Image)(resources.GetObject("buttonEdit.Image")));
            this.buttonEdit.Location = new System.Drawing.Point(8, 24);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(48, 48);
            this.buttonEdit.TabIndex = 0;
            this.buttonEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonEdit_MouseDown);
            // 
            // buttonPicture
            // 
            this.buttonPicture.Image = ((System.Drawing.Image)(resources.GetObject("buttonPicture.Image")));
            this.buttonPicture.Location = new System.Drawing.Point(8, 78);
            this.buttonPicture.Name = "buttonPicture";
            this.buttonPicture.Size = new System.Drawing.Size(48, 48);
            this.buttonPicture.TabIndex = 1;
            this.buttonPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonPicture_MouseDown);
            // 
            // FormTools
            // 
            this.ClientSize = new System.Drawing.Size(152, 242);
            this.Controls.Add(this.buttonPicture);
            this.Controls.Add(this.buttonEdit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTools";
            this.Text = "Toolbox";
            this.TopMost = true;
            this.ResumeLayout(false);

		}
		#endregion

		private void buttonEdit_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			buttonEdit.DoDragDrop("MovedEditor", DragDropEffects.All);
		}

        /// <summary>
        /// Gets coordinates of control
        /// </summary>
        /// <param name="c">The control</param>
        /// <param name="x">The X - coordinate</param>
        /// <param name="y">The Y - coordinate</param>
		public static void GetCoordinates(Control c, ref int x, ref int y)
		{
			x = c.Left;
			y = c.Top;
			Control p = c.Parent;
			if (p == null)
			{
				return;
			}
			int xp = 0;
			int yp = 0;
			GetCoordinates(p, ref xp, ref yp);
			x += xp;
			y += yp;
		}

        /// <summary>
        ///  Gets coordinates of control
        /// </summary>
        /// <param name="s">Source control</param>
        /// <param name="t">Target control</param>
        /// <param name="xi">Initial X - coordinate</param>
        /// <param name="yi">Initial Y - coordinate</param>
        /// <param name="x">The X - coordinate</param>
        /// <param name="y">The Y - coordinate</param>
        public static void GetCoordinates(Control s, Control t, int xi, int yi, ref int x, ref int y)
        {
            int xs = 0, ys = 0, xt = 0, yt = 0;
            GetCoordinates(s, ref xs, ref ys);
            GetCoordinates(t, ref xt, ref yt);
            x = xi + xs - xt;
            y = yi + xs - xt;
        }


		private void buttonPicture_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			buttonEdit.DoDragDrop("MovedPicture", DragDropEffects.All);
		}

        void init()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            AllowDrop = true;

            //Prepare richTextbox's context menu.
            ContextMenu theMenu;
            MenuItem menuItem;

            theMenu = new ContextMenu();

            menuItem = new MenuItem("Undo");
            //            menuItem.Click += new EventHandler(OnTexBoxMenu_Undo);
            theMenu.MenuItems.Add(menuItem);

            menuItem = new MenuItem("-");
            theMenu.MenuItems.Add(menuItem);

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
          /*  this.AllowedStates = ((DockableControls.ContentStates)(((((DockableControls.ContentStates.Float | DockableControls.ContentStates.DockLeft)
                | DockableControls.ContentStates.DockRight)
                | DockableControls.ContentStates.DockTop)
                | DockableControls.ContentStates.DockBottom)));
             this.ClientSize = new System.Drawing.Size(180, 300);
            this.DockPadding.Bottom = 3;
            this.DockPadding.Top = 3;
            this.HideOnClose = true;
            this.Name = "Objects";
            this.ShowHint = DockableControls.DockState.DockLeft;*/

        }
	}

			
}
