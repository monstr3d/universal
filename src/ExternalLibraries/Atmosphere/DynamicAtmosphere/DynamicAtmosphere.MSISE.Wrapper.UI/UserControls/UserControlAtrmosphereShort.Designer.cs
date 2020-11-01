namespace DynamicAtmosphere.MSISE.Wrapper.UI.UserControls
{
    partial class UserControlAtrmosphereShort
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.userControlSwithes = new DynamicAtmosphere.MSISE.Wrapper.UI.UserControls.UserControlSwithes();
            this.tabPageUnits = new System.Windows.Forms.TabPage();
            this.userControlPhysicalUnit = new Diagram.UI.UserControls.UserControlPhysicalUnit();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSettings.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.tabPageUnits.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.panelSettings);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(480, 335);
            this.tabPageSettings.TabIndex = 2;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.userControlSwithes);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettings.Location = new System.Drawing.Point(0, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(480, 335);
            this.panelSettings.TabIndex = 0;
            // 
            // userControlSwithes
            // 
            this.userControlSwithes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlSwithes.Location = new System.Drawing.Point(0, 0);
            this.userControlSwithes.Name = "userControlSwithes";
            this.userControlSwithes.Size = new System.Drawing.Size(480, 335);
            this.userControlSwithes.TabIndex = 0;
            // 
            // tabPageUnits
            // 
            this.tabPageUnits.Controls.Add(this.userControlPhysicalUnit);
            this.tabPageUnits.Location = new System.Drawing.Point(4, 22);
            this.tabPageUnits.Name = "tabPageUnits";
            this.tabPageUnits.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUnits.Size = new System.Drawing.Size(480, 335);
            this.tabPageUnits.TabIndex = 1;
            this.tabPageUnits.Text = "Physical units";
            this.tabPageUnits.UseVisualStyleBackColor = true;
            // 
            // userControlPhysicalUnit
            // 
            this.userControlPhysicalUnit.Attribute = null;
            this.userControlPhysicalUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlPhysicalUnit.Location = new System.Drawing.Point(3, 3);
            this.userControlPhysicalUnit.Name = "userControlPhysicalUnit";
            this.userControlPhysicalUnit.PhysicalUnitObject = null;
            this.userControlPhysicalUnit.Size = new System.Drawing.Size(474, 329);
            this.userControlPhysicalUnit.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageUnits);
            this.tabControl.Controls.Add(this.tabPageSettings);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(488, 361);
            this.tabControl.TabIndex = 1;
            // 
            // UserControlAtrmosphereShort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "UserControlAtrmosphereShort";
            this.Size = new System.Drawing.Size(488, 361);
            this.tabPageSettings.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.tabPageUnits.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.Panel panelSettings;
        private UserControlSwithes userControlSwithes;
        private System.Windows.Forms.TabPage tabPageUnits;
        private Diagram.UI.UserControls.UserControlPhysicalUnit userControlPhysicalUnit;
        private System.Windows.Forms.TabControl tabControl;
    }
}
