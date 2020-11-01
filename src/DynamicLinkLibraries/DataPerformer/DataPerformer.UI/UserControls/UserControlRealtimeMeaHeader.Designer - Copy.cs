namespace DataPerformer.UI.UserControls
{
    partial class UserControlRealtimeMeaHeader
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
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.userControlTopObject = new DataPerformer.UI.UserControls.UserControlTopObject();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.userControlRealtimeMeasureContainer = new DataPerformer.UI.UserControls.UserControlRealtimeMeasureContainer();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 103);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(232, 1);
            this.panelCenter.TabIndex = 15;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(232, 103);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 1);
            this.panelRight.TabIndex = 13;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 103);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 1);
            this.panelLeft.TabIndex = 12;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.userControlTopObject);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(232, 103);
            this.panelTop.TabIndex = 11;
            // 
            // userControlTopObject
            // 
            this.userControlTopObject.Dock = System.Windows.Forms.DockStyle.Top;
            this.userControlTopObject.Location = new System.Drawing.Point(0, 0);
            this.userControlTopObject.Name = "userControlTopObject";
            this.userControlTopObject.Size = new System.Drawing.Size(232, 97);
            this.userControlTopObject.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.userControlRealtimeMeasureContainer);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 104);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(232, 60);
            this.panelBottom.TabIndex = 14;
            // 
            // userControlRealtimeMeasureContainer
            // 
            this.userControlRealtimeMeasureContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.userControlRealtimeMeasureContainer.Location = new System.Drawing.Point(0, 0);
            this.userControlRealtimeMeasureContainer.Name = "userControlRealtimeMeasureContainer";
            this.userControlRealtimeMeasureContainer.Size = new System.Drawing.Size(232, 56);
            this.userControlRealtimeMeasureContainer.TabIndex = 0;
            // 
            // UserControlRealtimeMeaHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlRealtimeMeaHeader";
            this.Size = new System.Drawing.Size(232, 164);
            this.panelTop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private UserControlTopObject userControlTopObject;
        private UserControlRealtimeMeasureContainer userControlRealtimeMeasureContainer;
    }
}
