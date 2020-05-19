namespace DynamicAtmosphere.MSISE.Wrapper.UI.UserControls
{
    partial class UserControlAtmosphereFull
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageParameters = new System.Windows.Forms.TabPage();
            this.tabPageUnits = new System.Windows.Forms.TabPage();
            this.userControlPhysicalUnit = new Diagram.UI.UserControls.UserControlPhysicalUnit();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.userControlSwithes = new DynamicAtmosphere.MSISE.Wrapper.UI.UserControls.UserControlSwithes();
            this.userControlAtmosphere = new DynamicAtmosphere.MSISE.Wrapper.UI.UserControls.UserControlAtmosphere();
            this.tabControl.SuspendLayout();
            this.tabPageParameters.SuspendLayout();
            this.tabPageUnits.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageParameters);
            this.tabControl.Controls.Add(this.tabPageUnits);
            this.tabControl.Controls.Add(this.tabPageSettings);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(385, 356);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageParameters
            // 
            this.tabPageParameters.Controls.Add(this.userControlAtmosphere);
            this.tabPageParameters.Location = new System.Drawing.Point(4, 22);
            this.tabPageParameters.Name = "tabPageParameters";
            this.tabPageParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParameters.Size = new System.Drawing.Size(377, 330);
            this.tabPageParameters.TabIndex = 0;
            this.tabPageParameters.Text = "Parameters";
            this.tabPageParameters.UseVisualStyleBackColor = true;
            // 
            // tabPageUnits
            // 
            this.tabPageUnits.Controls.Add(this.userControlPhysicalUnit);
            this.tabPageUnits.Location = new System.Drawing.Point(4, 22);
            this.tabPageUnits.Name = "tabPageUnits";
            this.tabPageUnits.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUnits.Size = new System.Drawing.Size(377, 330);
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
            this.userControlPhysicalUnit.Size = new System.Drawing.Size(371, 324);
            this.userControlPhysicalUnit.TabIndex = 0;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.panelSettings);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(377, 330);
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
            this.panelSettings.Size = new System.Drawing.Size(377, 330);
            this.panelSettings.TabIndex = 0;
            // 
            // userControlSwithes
            // 
            this.userControlSwithes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlSwithes.Location = new System.Drawing.Point(0, 0);
            this.userControlSwithes.Name = "userControlSwithes";
            this.userControlSwithes.Size = new System.Drawing.Size(377, 330);
            this.userControlSwithes.TabIndex = 0;
            // 
            // userControlAtmosphere
            // 
            this.userControlAtmosphere.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlAtmosphere.Location = new System.Drawing.Point(3, 3);
            this.userControlAtmosphere.Name = "userControlAtmosphere";
            this.userControlAtmosphere.Size = new System.Drawing.Size(371, 324);
            this.userControlAtmosphere.TabIndex = 0;
            // 
            // UserControlAtmosphereFull
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "UserControlAtmosphereFull";
            this.Size = new System.Drawing.Size(385, 356);
            this.tabControl.ResumeLayout(false);
            this.tabPageParameters.ResumeLayout(false);
            this.tabPageUnits.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageParameters;
        private System.Windows.Forms.TabPage tabPageUnits;
        private System.Windows.Forms.TabPage tabPageSettings;
        private Diagram.UI.UserControls.UserControlPhysicalUnit userControlPhysicalUnit;
         private System.Windows.Forms.Panel panelSettings;
         private UserControlSwithes userControlSwithes;
         private UserControlAtmosphere userControlAtmosphere;
    }
}
