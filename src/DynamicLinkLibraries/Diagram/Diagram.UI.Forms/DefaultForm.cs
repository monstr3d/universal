using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Resources;
using System.IO;

using CategoryTheory;

using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

namespace Diagram.UI
{
	/// <summary>
	/// Default properties' editor.
	/// </summary>
	public class DefaultForm : Form, IUpdatableForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button buttonRemove;
		private System.Windows.Forms.PictureBox pictureBoxObject;
		private System.Windows.Forms.Button buttonUpdate;
		private System.Windows.Forms.Label labelSourceH;
		private System.Windows.Forms.PictureBox pictureBoxSource;
		private System.Windows.Forms.Label labelTargetH;
		private System.Windows.Forms.PictureBox pictureBoxTarget;
		private System.Windows.Forms.Label labelSource;
		private System.Windows.Forms.Label labelTarget;
		private System.Windows.Forms.CheckBox checkBoxUpdatable;
		private System.Windows.Forms.Label labelH;

		/// <summary>
		/// Component of form
		/// </summary>
        private INamedComponent component;
 
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="component">Corresponding component</param>
		public DefaultForm(INamedComponent component)
		{
			InitializeComponent();
			this.component = component;
			this.LoadControlResources(ControlUtilites.Resources);//, Resources);
			UpdateFormUI();
			pictureBoxObject.Image = component.GetImage();
			labelH.Text = component.GetToolTip();
			object o = null;
			if (component is IObjectLabel)
			{
				IObjectLabel l = component as IObjectLabel;
				o = l.Object;
			}
			if (component is IArrowLabel)
			{
				IArrowLabel l = component as IArrowLabel;
				o = l.Arrow;
			}
			if (!(o is IUpdatableObject))
			{
				checkBoxUpdatable.Visible = false;
			}
			else
			{
				IUpdatableObject upd = o as IUpdatableObject;
				if (upd.ShouldUpdate)
				{
					checkBoxUpdatable.Checked = true;
				}
			}

			if (!(component is IArrowLabel))
			{
				this.labelSourceH.Visible = false;
				this.labelTargetH.Visible = false;
				return;
			}
			IArrowLabel label = component as IArrowLabel;
			pictureBoxSource.Image = label.Source.GetImage();
			pictureBoxTarget.Image = label.Target.GetImage();
		}

		/// <summary>
		/// Gets parent form of control
		/// </summary>
		/// <param name="control">The control</param>
		/// <returns>The form</returns>
		public static Form GetParentForm(Control control)
		{
			if (control is Form)
			{
				return control as Form;
			}
			return GetParentForm(control.Parent);
		}

		/// <summary>
		/// Updates form UI
		/// </summary>
		public void UpdateFormUI()
		{
            if (component == null)
            {
                return;
            }
			Text = component.RootName;//NamedComponent.GetText(component) + "";
			if (!(component is IArrowLabel))
			{
				return;
			}
			IArrowLabel label = component as IArrowLabel;
			this.labelSource.Text = label.Source.RootName;//NamedComponent.GetText(label.Source) + "";
			this.labelTarget.Text = label.Target.RootName;//NamedComponent.GetText(label.Target) + "";
		}


 
 

 
 

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		//	NamedComponent.RemoveForm(component);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonRemove = new System.Windows.Forms.Button();
			this.pictureBoxObject = new System.Windows.Forms.PictureBox();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.labelSourceH = new System.Windows.Forms.Label();
			this.pictureBoxSource = new System.Windows.Forms.PictureBox();
			this.labelTargetH = new System.Windows.Forms.Label();
			this.pictureBoxTarget = new System.Windows.Forms.PictureBox();
			this.labelSource = new System.Windows.Forms.Label();
			this.labelTarget = new System.Windows.Forms.Label();
			this.checkBoxUpdatable = new System.Windows.Forms.CheckBox();
			this.labelH = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonRemove
			// 
			this.buttonRemove.Location = new System.Drawing.Point(344, 112);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.TabIndex = 0;
			this.buttonRemove.Text = "Remove";
			this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
			// 
			// pictureBoxObject
			// 
			this.pictureBoxObject.Location = new System.Drawing.Point(8, 8);
			this.pictureBoxObject.Name = "pictureBoxObject";
			this.pictureBoxObject.Size = new System.Drawing.Size(40, 40);
			this.pictureBoxObject.TabIndex = 1;
			this.pictureBoxObject.TabStop = false;
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Location = new System.Drawing.Point(344, 80);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.TabIndex = 2;
			this.buttonUpdate.Text = "Update";
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// labelSourceH
			// 
			this.labelSourceH.Location = new System.Drawing.Point(64, 112);
			this.labelSourceH.Name = "labelSourceH";
			this.labelSourceH.TabIndex = 3;
			this.labelSourceH.Text = "Source";
			// 
			// pictureBoxSource
			// 
			this.pictureBoxSource.Location = new System.Drawing.Point(32, 152);
			this.pictureBoxSource.Name = "pictureBoxSource";
			this.pictureBoxSource.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxSource.TabIndex = 4;
			this.pictureBoxSource.TabStop = false;
			// 
			// labelTargetH
			// 
			this.labelTargetH.Location = new System.Drawing.Point(64, 216);
			this.labelTargetH.Name = "labelTargetH";
			this.labelTargetH.TabIndex = 5;
			this.labelTargetH.Text = "Target";
			// 
			// pictureBoxTarget
			// 
			this.pictureBoxTarget.Location = new System.Drawing.Point(32, 256);
			this.pictureBoxTarget.Name = "pictureBoxTarget";
			this.pictureBoxTarget.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxTarget.TabIndex = 6;
			this.pictureBoxTarget.TabStop = false;
			// 
			// labelSource
			// 
			this.labelSource.Location = new System.Drawing.Point(88, 152);
			this.labelSource.Name = "labelSource";
			this.labelSource.Size = new System.Drawing.Size(312, 48);
			this.labelSource.TabIndex = 7;
			// 
			// labelTarget
			// 
			this.labelTarget.Location = new System.Drawing.Point(88, 256);
			this.labelTarget.Name = "labelTarget";
			this.labelTarget.Size = new System.Drawing.Size(312, 56);
			this.labelTarget.TabIndex = 8;
			// 
			// checkBoxUpdatable
			// 
			this.checkBoxUpdatable.Location = new System.Drawing.Point(216, 336);
			this.checkBoxUpdatable.Name = "checkBoxUpdatable";
			this.checkBoxUpdatable.Size = new System.Drawing.Size(192, 32);
			this.checkBoxUpdatable.TabIndex = 9;
			this.checkBoxUpdatable.Text = "Updatable";
			this.checkBoxUpdatable.CheckedChanged += new System.EventHandler(this.checkBoxUpdatable_CheckedChanged);
			// 
			// labelH
			// 
			this.labelH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelH.Location = new System.Drawing.Point(64, 8);
			this.labelH.Name = "labelH";
			this.labelH.Size = new System.Drawing.Size(360, 64);
			this.labelH.TabIndex = 10;
			this.labelH.Text = "labelH";
			// 
			// DefaultForm
			// 
			this.ClientSize = new System.Drawing.Size(440, 389);
			this.Controls.Add(this.labelH);
			this.Controls.Add(this.checkBoxUpdatable);
			this.Controls.Add(this.labelTarget);
			this.Controls.Add(this.labelSource);
			this.Controls.Add(this.pictureBoxTarget);
			this.Controls.Add(this.labelTargetH);
			this.Controls.Add(this.pictureBoxSource);
			this.Controls.Add(this.labelSourceH);
			this.Controls.Add(this.buttonUpdate);
			this.Controls.Add(this.pictureBoxObject);
			this.Controls.Add(this.buttonRemove);
			this.Name = "DefaultForm";
			this.Text = "DefaultForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void loadResources()
		{
            this.LoadControlResources(ControlUtilites.Resources);

		}
		private void buttonRemove_Click(object sender, System.EventArgs e)
		{
			/*
			if (component is IObjectLabel)
			{
				IObjectLabel lab = component as IObjectLabel;
				lab.Remove(true);
			}
			else if (component is IArrowLabel)
			{
				IArrowLabel lab = component as IArrowLabel;
				lab.Remove(true);
			}
			*/
			//NamedComponent.RemoveForm(component);
			Dispose();
		}

		private void buttonUpdate_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (component is IObjectLabel)
				{
					IObjectLabel lab = component as IObjectLabel;
					ICategoryObject obj = lab.Object;
					if (obj is IUpdatableObject)
					{
						IUpdatableObject updatable = obj as IUpdatableObject;
						if (updatable.Update != null)
                        {
                            updatable.Update();
                        }
					}
				}
				else if (component is IArrowLabel)
				{
					IArrowLabel lab = component as IArrowLabel;
					ICategoryArrow arrow = lab.Arrow;
					if (arrow is IUpdatableObject)
					{
						IUpdatableObject updatable = arrow as IUpdatableObject;
                        if (updatable.Update != null)
                        {
                            updatable.Update();
                        }
                    }
				}
			}
			catch (Exception ex)
			{
                ex.ShowError(10);
			}
		}

		private void checkBoxUpdatable_CheckedChanged(object sender, System.EventArgs e)
		{
			object o = null;
			if (component is IObjectLabel)
			{
				IObjectLabel lab = component as IObjectLabel;
				o = lab.Object;
			}
			else if (component is IArrowLabel)
			{
				IArrowLabel lab = component as IArrowLabel;
				o = lab.Arrow;
			}
			if (o is IUpdatableObject)
			{
				IUpdatableObject updatable = o as IUpdatableObject;
				updatable.ShouldUpdate = checkBoxUpdatable.Checked;
			}
		}
	}
}
