namespace WindowsTemplates.UserControls
{
    partial class UserControlFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlFile));
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelWork = new System.Windows.Forms.Panel();
            this.panelRightHigh = new System.Windows.Forms.Panel();
            this.panelLeftHigh = new System.Windows.Forms.Panel();
            this.panelTopHigh = new System.Windows.Forms.Panel();
            this.panelBottomHigh = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelCenter.SuspendLayout();
            this.panelWork.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.panelWork);
            this.panelCenter.Controls.Add(this.panelRight);
            this.panelCenter.Controls.Add(this.panelLeft);
            this.panelCenter.Controls.Add(this.panelTop);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(495, 333);
            this.panelCenter.TabIndex = 8;
            // 
            // panelWork
            // 
            this.panelWork.Controls.Add(this.panelRightHigh);
            this.panelWork.Controls.Add(this.panelLeftHigh);
            this.panelWork.Controls.Add(this.panelTopHigh);
            this.panelWork.Controls.Add(this.panelBottomHigh);
            this.panelWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWork.Location = new System.Drawing.Point(1, 24);
            this.panelWork.Name = "panelWork";
            this.panelWork.Size = new System.Drawing.Size(493, 309);
            this.panelWork.TabIndex = 3;
            // 
            // panelRightHigh
            // 
            this.panelRightHigh.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightHigh.Location = new System.Drawing.Point(493, 0);
            this.panelRightHigh.Name = "panelRightHigh";
            this.panelRightHigh.Size = new System.Drawing.Size(0, 309);
            this.panelRightHigh.TabIndex = 16;
            // 
            // panelLeftHigh
            // 
            this.panelLeftHigh.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftHigh.Location = new System.Drawing.Point(0, 0);
            this.panelLeftHigh.Name = "panelLeftHigh";
            this.panelLeftHigh.Size = new System.Drawing.Size(0, 309);
            this.panelLeftHigh.TabIndex = 15;
            // 
            // panelTopHigh
            // 
            this.panelTopHigh.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopHigh.Location = new System.Drawing.Point(0, 0);
            this.panelTopHigh.Name = "panelTopHigh";
            this.panelTopHigh.Size = new System.Drawing.Size(493, 0);
            this.panelTopHigh.TabIndex = 11;
            // 
            // panelBottomHigh
            // 
            this.panelBottomHigh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomHigh.Location = new System.Drawing.Point(0, 309);
            this.panelBottomHigh.Name = "panelBottomHigh";
            this.panelBottomHigh.Size = new System.Drawing.Size(493, 0);
            this.panelBottomHigh.TabIndex = 14;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(494, 24);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1, 309);
            this.panelRight.TabIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 24);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(1, 309);
            this.panelLeft.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStripMain);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(495, 24);
            this.panelTop.TabIndex = 0;
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(495, 25);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "Main";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "Open";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "Save";
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 333);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(495, 1);
            this.panelBottom.TabIndex = 7;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Function files |*.xml";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Function files |*.xml";
            // 
            // UserControlFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlFile";
            this.Size = new System.Drawing.Size(495, 334);
            this.panelCenter.ResumeLayout(false);
            this.panelWork.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelWork;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel panelTopHigh;
        private System.Windows.Forms.Panel panelBottomHigh;
        private System.Windows.Forms.Panel panelRightHigh;
        private System.Windows.Forms.Panel panelLeftHigh;
    }
}
