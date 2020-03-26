namespace ImageNavigation.UserControls
{
    partial class UserControlBitmapGraphSelection
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlBitmapGraphSelection));
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.userControlChart = new Chart.UserControls.UserControlChart();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pic = new OfficePickers.ColorPicker.ToolStripColorPicker();
            this.toolStripButtonActive = new System.Windows.Forms.ToolStripButton();
            this.panelCenter.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(149, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1, 123);
            this.panelRight.TabIndex = 2;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.userControlChart);
            this.panelCenter.Controls.Add(this.panelRight);
            this.panelCenter.Controls.Add(this.panelLeft);
            this.panelCenter.Controls.Add(this.panelBottom);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 26);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(150, 124);
            this.panelCenter.TabIndex = 8;
            // 
            // userControlChart
            // 
            this.userControlChart.Coordinator = null;
            this.userControlChart.Cursor = System.Windows.Forms.Cursors.Cross;
            this.userControlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlChart.IsBlocked = true;
            this.userControlChart.Location = new System.Drawing.Point(1, 0);
            this.userControlChart.Name = "userControlChart";
            this.userControlChart.Size = new System.Drawing.Size(148, 123);
            this.userControlChart.TabIndex = 3;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(1, 123);
            this.panelLeft.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 123);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(150, 1);
            this.panelBottom.TabIndex = 0;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.pic,
            this.toolStripButtonActive});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(150, 26);
            this.toolStrip.TabIndex = 7;
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 23);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // pic
            // 
            this.pic.AutoSize = false;
            this.pic.ButtonDisplayStyle = OfficePickers.ColorPicker.ToolStripColorPickerDisplayType.UnderLineAndImage;
            this.pic.Color = System.Drawing.Color.Black;
            this.pic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(30, 23);
            this.pic.Text = "Color";
            this.pic.ToolTipText = "";
            // 
            // toolStripButtonActive
            // 
            this.toolStripButtonActive.CheckOnClick = true;
            this.toolStripButtonActive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonActive.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonActive.Image")));
            this.toolStripButtonActive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonActive.Name = "toolStripButtonActive";
            this.toolStripButtonActive.Size = new System.Drawing.Size(40, 23);
            this.toolStripButtonActive.Text = "Show";
            // 
            // UserControlBitmapChartSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.toolStrip);
            this.Name = "UserControlBitmapChartSelection";
            this.panelCenter.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ToolStrip toolStrip;
        private Chart.UserControls.UserControlChart userControlChart;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private OfficePickers.ColorPicker.ToolStripColorPicker pic;
        private System.Windows.Forms.ToolStripButton toolStripButtonActive;
    }
}
