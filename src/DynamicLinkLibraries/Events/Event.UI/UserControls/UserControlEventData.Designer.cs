namespace Event.UI.UserControls
{
    partial class UserControlEventData
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
            if (forced != null)
            {
                forced.OnChangeTypes -= ForcedChange;
                forced = null;
            }
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlEventData));
            this.panelCenter = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageTypes = new System.Windows.Forms.TabPage();
            this.userControlTypeList = new Diagram.UI.UserControls.UserControlTypeList();
            this.tabPageInitial = new System.Windows.Forms.TabPage();
            this.propertyGridInitial = new System.Windows.Forms.PropertyGrid();
            this.tabPageValues = new System.Windows.Forms.TabPage();
            this.propertyGridValues = new System.Windows.Forms.PropertyGrid();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelCenter.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageTypes.SuspendLayout();
            this.tabPageInitial.SuspendLayout();
            this.tabPageValues.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControl);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(265, 226);
            this.panelCenter.TabIndex = 20;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageTypes);
            this.tabControl.Controls.Add(this.tabPageInitial);
            this.tabControl.Controls.Add(this.tabPageValues);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(265, 226);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageTypes
            // 
            this.tabPageTypes.Controls.Add(this.userControlTypeList);
            this.tabPageTypes.Location = new System.Drawing.Point(4, 22);
            this.tabPageTypes.Name = "tabPageTypes";
            this.tabPageTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTypes.Size = new System.Drawing.Size(257, 200);
            this.tabPageTypes.TabIndex = 0;
            this.tabPageTypes.Text = "Types";
            this.tabPageTypes.UseVisualStyleBackColor = true;
            // 
            // userControlTypeList
            // 
            this.userControlTypeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlTypeList.Location = new System.Drawing.Point(3, 3);
            this.userControlTypeList.Name = "userControlTypeList";
            this.userControlTypeList.Size = new System.Drawing.Size(251, 194);
            this.userControlTypeList.TabIndex = 0;
            this.userControlTypeList.Types = ((System.Collections.Generic.List<System.Tuple<string, object>>)(resources.GetObject("userControlTypeList.Types")));
            // 
            // tabPageInitial
            // 
            this.tabPageInitial.Controls.Add(this.propertyGridInitial);
            this.tabPageInitial.Location = new System.Drawing.Point(4, 22);
            this.tabPageInitial.Name = "tabPageInitial";
            this.tabPageInitial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInitial.Size = new System.Drawing.Size(257, 200);
            this.tabPageInitial.TabIndex = 2;
            this.tabPageInitial.Text = "Initial values";
            this.tabPageInitial.UseVisualStyleBackColor = true;
            // 
            // propertyGridInitial
            // 
            this.propertyGridInitial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridInitial.Location = new System.Drawing.Point(3, 3);
            this.propertyGridInitial.Name = "propertyGridInitial";
            this.propertyGridInitial.Size = new System.Drawing.Size(251, 194);
            this.propertyGridInitial.TabIndex = 0;
            // 
            // tabPageValues
            // 
            this.tabPageValues.Controls.Add(this.propertyGridValues);
            this.tabPageValues.Location = new System.Drawing.Point(4, 22);
            this.tabPageValues.Name = "tabPageValues";
            this.tabPageValues.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageValues.Size = new System.Drawing.Size(257, 200);
            this.tabPageValues.TabIndex = 1;
            this.tabPageValues.Text = "Values";
            this.tabPageValues.UseVisualStyleBackColor = true;
            // 
            // propertyGridValues
            // 
            this.propertyGridValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridValues.Location = new System.Drawing.Point(3, 3);
            this.propertyGridValues.Name = "propertyGridValues";
            this.propertyGridValues.Size = new System.Drawing.Size(251, 194);
            this.propertyGridValues.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(265, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 226);
            this.panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 226);
            this.panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(265, 0);
            this.panelTop.TabIndex = 16;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 226);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(265, 0);
            this.panelBottom.TabIndex = 19;
            // 
            // UserControlEventData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlEventData";
            this.Size = new System.Drawing.Size(265, 226);
            this.panelCenter.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageTypes.ResumeLayout(false);
            this.tabPageInitial.ResumeLayout(false);
            this.tabPageValues.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageTypes;
        private System.Windows.Forms.TabPage tabPageValues;
        private Diagram.UI.UserControls.UserControlTypeList userControlTypeList;
        private System.Windows.Forms.TabPage tabPageInitial;
        private System.Windows.Forms.PropertyGrid propertyGridInitial;
        private System.Windows.Forms.PropertyGrid propertyGridValues;
    }
}
