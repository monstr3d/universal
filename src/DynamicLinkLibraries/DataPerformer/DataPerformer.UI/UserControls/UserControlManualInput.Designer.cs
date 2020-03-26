namespace DataPerformer.UI.UserControls
{
    partial class UserControlManualInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlManualInput));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageTypes = new System.Windows.Forms.TabPage();
            this.userControlTypeList = new Diagram.UI.UserControls.UserControlTypeList();
            this.tabPageInitial = new System.Windows.Forms.TabPage();
            this.propertyGridInitial = new System.Windows.Forms.PropertyGrid();
            this.tabPageValues = new System.Windows.Forms.TabPage();
            this.propertyGridValues = new System.Windows.Forms.PropertyGrid();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.tabPageTypes.SuspendLayout();
            this.tabPageInitial.SuspendLayout();
            this.tabPageValues.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageTypes);
            this.tabControl.Controls.Add(this.tabPageInitial);
            this.tabControl.Controls.Add(this.tabPageValues);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(383, 309);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageTypes
            // 
            this.tabPageTypes.Controls.Add(this.userControlTypeList);
            this.tabPageTypes.Location = new System.Drawing.Point(4, 25);
            this.tabPageTypes.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageTypes.Name = "tabPageTypes";
            this.tabPageTypes.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageTypes.Size = new System.Drawing.Size(375, 280);
            this.tabPageTypes.TabIndex = 0;
            this.tabPageTypes.Text = "Types";
            this.tabPageTypes.UseVisualStyleBackColor = true;
            // 
            // userControlTypeList
            // 
            this.userControlTypeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlTypeList.Location = new System.Drawing.Point(4, 4);
            this.userControlTypeList.Margin = new System.Windows.Forms.Padding(5);
            this.userControlTypeList.Name = "userControlTypeList";
            this.userControlTypeList.Size = new System.Drawing.Size(367, 272);
            this.userControlTypeList.TabIndex = 0;
            this.userControlTypeList.Types = ((System.Collections.Generic.List<System.Tuple<string, object>>)(resources.GetObject("userControlTypeList.Types")));
            // 
            // tabPageInitial
            // 
            this.tabPageInitial.Controls.Add(this.propertyGridInitial);
            this.tabPageInitial.Location = new System.Drawing.Point(4, 25);
            this.tabPageInitial.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageInitial.Name = "tabPageInitial";
            this.tabPageInitial.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageInitial.Size = new System.Drawing.Size(345, 249);
            this.tabPageInitial.TabIndex = 2;
            this.tabPageInitial.Text = "Initial values";
            this.tabPageInitial.UseVisualStyleBackColor = true;
            // 
            // propertyGridInitial
            // 
            this.propertyGridInitial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridInitial.Location = new System.Drawing.Point(4, 4);
            this.propertyGridInitial.Margin = new System.Windows.Forms.Padding(4);
            this.propertyGridInitial.Name = "propertyGridInitial";
            this.propertyGridInitial.Size = new System.Drawing.Size(337, 241);
            this.propertyGridInitial.TabIndex = 0;
            // 
            // tabPageValues
            // 
            this.tabPageValues.Controls.Add(this.propertyGridValues);
            this.tabPageValues.Location = new System.Drawing.Point(4, 25);
            this.tabPageValues.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageValues.Name = "tabPageValues";
            this.tabPageValues.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageValues.Size = new System.Drawing.Size(345, 249);
            this.tabPageValues.TabIndex = 1;
            this.tabPageValues.Text = "Values";
            this.tabPageValues.UseVisualStyleBackColor = true;
            // 
            // propertyGridValues
            // 
            this.propertyGridValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridValues.Location = new System.Drawing.Point(4, 4);
            this.propertyGridValues.Margin = new System.Windows.Forms.Padding(4);
            this.propertyGridValues.Name = "propertyGridValues";
            this.propertyGridValues.Size = new System.Drawing.Size(337, 241);
            this.propertyGridValues.TabIndex = 0;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControl);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(4);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(383, 309);
            this.panelCenter.TabIndex = 25;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(383, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 309);
            this.panelRight.TabIndex = 23;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 309);
            this.panelLeft.TabIndex = 22;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(383, 0);
            this.panelTop.TabIndex = 21;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 309);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(383, 0);
            this.panelBottom.TabIndex = 24;
            // 
            // UserControlManualInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlManualInput";
            this.Size = new System.Drawing.Size(383, 309);
            this.tabControl.ResumeLayout(false);
            this.tabPageTypes.ResumeLayout(false);
            this.tabPageInitial.ResumeLayout(false);
            this.tabPageValues.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageTypes;
        private Diagram.UI.UserControls.UserControlTypeList userControlTypeList;
        private System.Windows.Forms.TabPage tabPageInitial;
        private System.Windows.Forms.PropertyGrid propertyGridInitial;
        private System.Windows.Forms.TabPage tabPageValues;
        private System.Windows.Forms.PropertyGrid propertyGridValues;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
    }
}
