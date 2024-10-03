using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces.Labels;


namespace Diagram.UI
{
	/// <summary>
	/// Form that can change order
	/// </summary>
	public class FormOrder : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label labelObject;
		private System.Windows.Forms.ListBox listBoxComponents;
		private System.Windows.Forms.Button buttonOK;
		private INamedComponent label;
        private PanelDesktop desktop;

        /// <summary>
        /// Default constructor
        /// </summary>
		public FormOrder()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Consructor
        /// </summary>
        /// <param name="desktop">Desktop</param>
		public FormOrder(PanelDesktop desktop)
		{
			InitializeComponent();
            this.LoadControlResources(ControlUtilites.Resources);
			this.desktop = desktop;
            IList<IObjectLabel> objs;
            IList<IArrowLabel> arrs;
            desktop.GetSelected(out objs, out arrs);
            if (objs.Count != 0 | arrs.Count != 0)
            {
                if (objs.Count == 0)
                {
                    return;
                }
                else
                {
                    label = objs[0] as INamedComponent;
                }
            }
            else
            {
                label = objs[0] as INamedComponent;
            }
			labelObject.Text = label.Name;
			foreach (Control c in desktop.Controls)
			{
				if (!(c is INamedComponent))
				{
					continue;
				}
				INamedComponent nc = c as INamedComponent;
				listBoxComponents.Items.Add(nc.Name);
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
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelObject = new System.Windows.Forms.Label();
			this.listBoxComponents = new System.Windows.Forms.ListBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelObject
			// 
			this.labelObject.Location = new System.Drawing.Point(40, 40);
			this.labelObject.Name = "labelObject";
			this.labelObject.TabIndex = 0;
			this.labelObject.Text = "label1";
			// 
			// listBoxComponents
			// 
			this.listBoxComponents.Location = new System.Drawing.Point(72, 96);
			this.listBoxComponents.Name = "listBoxComponents";
			this.listBoxComponents.Size = new System.Drawing.Size(304, 277);
			this.listBoxComponents.TabIndex = 1;
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(88, 392);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// FormOrder
			// 
			this.ClientSize = new System.Drawing.Size(536, 445);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.listBoxComponents);
			this.Controls.Add(this.labelObject);
			this.Name = "FormOrder";
			this.Text = "Change control order";
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			int ord = label.Ord;
			try
			{
				int n = listBoxComponents.SelectedIndex;
                if (label is IObjectLabelUI)
                {
                    IObjectLabelUI l = label as IObjectLabelUI;
                    l.Ord = n;
                }
                if (label is IArrowLabelUI)
                {
                    IArrowLabelUI l = label as IArrowLabelUI;
                    l.Ord = n;
                }
				desktop.CheckOrder();
				Dispose();
			}
			catch (Exception ex)
			{
                ex.ShowError(10);
                if (label is IObjectLabelUI)
                {
                    IObjectLabelUI l = label as IObjectLabelUI;
                    l.Ord = ord;
                }
                if (label is IArrowLabelUI)
                {
                    IArrowLabelUI l = label as IArrowLabelUI;
                    l.Ord = ord;
                }
                this.ShowError(ex, Diagram.UI.Utils.ControlUtilites.Resources);
			}
		}
	}
}
