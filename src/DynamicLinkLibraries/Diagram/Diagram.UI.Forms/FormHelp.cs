using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using Diagram.UI.Labels;
using Diagram.UI.Utils;

namespace Diagram.UI
{
	/// <summary>
	/// Summary description for FormHelp.
	/// </summary>
	public class FormHelp : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonHelp;
		private System.Windows.Forms.Label labelHelp;
		private string helpURL;
		private System.Windows.Forms.Label labelOb;
		private System.Windows.Forms.Label labelObName;
		private System.Windows.Forms.Button buttonShowComponent;
		private DiagramException exception;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
		public FormHelp()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="helpURL">Help URL</param>
		public FormHelp(string message, string helpURL)
		{
			InitializeComponent();
           this.LoadControlResources(ControlUtilites.Resources);
			labelHelp.Text = message;
			this.helpURL = helpURL;
			if (helpURL == null)
			{
				buttonHelp.Visible = false;
				buttonOK.Left = (Width - buttonOK.Width) / 2;
			}
		}
        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="e">Exception</param>
        /// <param name="helpURL">Help URL</param>
		public FormHelp(string message, Exception e, string helpURL)
		{
			InitializeComponent();
			this.LoadControlResources(Utils.ControlUtilites.Resources);
			labelHelp.Text = message;
			this.helpURL = helpURL;
			if (e is DiagramException)
			{
				exception = e as DiagramException;
				labelObName.Text = exception.Component.RootName;
			}
			else
			{
				buttonShowComponent.Visible = false;
				labelOb.Visible = false;
				labelObName.Visible = false;
			}
			if (helpURL == null)
			{
				buttonHelp.Visible = false;
				buttonOK.Left = (Width - buttonOK.Width) / 2;
			}
        }

        #endregion

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormHelp));
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonHelp = new System.Windows.Forms.Button();
			this.labelHelp = new System.Windows.Forms.Label();
			this.labelOb = new System.Windows.Forms.Label();
			this.labelObName = new System.Windows.Forms.Label();
			this.buttonShowComponent = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(112, 256);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonHelp
			// 
			this.buttonHelp.Location = new System.Drawing.Point(296, 256);
			this.buttonHelp.Name = "buttonHelp";
			this.buttonHelp.TabIndex = 1;
			this.buttonHelp.Text = "Help";
			this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
			// 
			// labelHelp
			// 
			this.labelHelp.Location = new System.Drawing.Point(56, 56);
			this.labelHelp.Name = "labelHelp";
			this.labelHelp.Size = new System.Drawing.Size(400, 96);
			this.labelHelp.TabIndex = 2;
			this.labelHelp.Text = "labelHelp";
			// 
			// labelOb
			// 
			this.labelOb.Location = new System.Drawing.Point(56, 176);
			this.labelOb.Name = "labelOb";
			this.labelOb.TabIndex = 3;
			this.labelOb.Text = "Object";
			// 
			// labelObName
			// 
			this.labelObName.Location = new System.Drawing.Point(184, 176);
			this.labelObName.Name = "labelObName";
			this.labelObName.Size = new System.Drawing.Size(304, 40);
			this.labelObName.TabIndex = 4;
			this.labelObName.Text = "Unknown";
			// 
			// buttonShowComponent
			// 
			this.buttonShowComponent.Location = new System.Drawing.Point(296, 224);
			this.buttonShowComponent.Name = "buttonShowComponent";
			this.buttonShowComponent.Size = new System.Drawing.Size(168, 23);
			this.buttonShowComponent.TabIndex = 5;
			this.buttonShowComponent.Text = "Object properties";
			this.buttonShowComponent.Click += new System.EventHandler(this.buttonShowComponent_Click);
			// 
			// FormHelp
			// 
			this.ClientSize = new System.Drawing.Size(528, 317);
			this.Controls.Add(this.buttonShowComponent);
			this.Controls.Add(this.labelObName);
			this.Controls.Add(this.labelOb);
			this.Controls.Add(this.labelHelp);
			this.Controls.Add(this.buttonHelp);
			this.Controls.Add(this.buttonOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormHelp";
			this.Text = "Error";
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
            Close();
		}

		private void buttonHelp_Click(object sender, System.EventArgs e)
		{
			Help.ShowHelp(this, helpURL);
		}

		private void buttonShowComponent_Click(object sender, System.EventArgs e)
		{
			try
			{
				NamedComponent nc = exception.Component as NamedComponent;
				nc.ShowDialog(this);
			}
			catch (Exception)
			{
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, ResourceService.Resources.GetControlResource("Unable to open properties editor",
                    ControlUtilites.Resources));
			}
		}

	}
}
