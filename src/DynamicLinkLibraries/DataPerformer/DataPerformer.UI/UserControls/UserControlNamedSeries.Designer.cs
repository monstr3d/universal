namespace DataPerformer.UI.UserControls
{
    partial class UserControlNamedSeries
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlNamedSeries));
            this.openFileDialogGraph = new System.Windows.Forms.OpenFileDialog();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonType = new System.Windows.Forms.ToolStripComboBox();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.userControlChart = new Chart.UserControls.UserControlChart();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelDraw = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pic = new OfficePickers.ColorPicker.ToolStripColorPicker();
            this.toolStripComboBoxX = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxY = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabelCoord = new System.Windows.Forms.ToolStripLabel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelGraph.SuspendLayout();
            this.panelDraw.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 23);
            this.saveToolStripButton.Text = "Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 23);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripButtonType
            // 
            this.toolStripButtonType.Name = "toolStripButtonType";
            this.toolStripButtonType.Size = new System.Drawing.Size(121, 26);
            // 
            // panelGraph
            // 
            this.panelGraph.BackColor = System.Drawing.Color.White;
            this.panelGraph.Controls.Add(this.userControlChart);
            this.panelGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraph.Location = new System.Drawing.Point(0, 26);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(669, 291);
            this.panelGraph.TabIndex = 34;
            // 
            // userControlChart
            // 
            this.userControlChart.Coordinator = null;
            this.userControlChart.Cursor = System.Windows.Forms.Cursors.Cross;
            this.userControlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlChart.IsBlocked = true;
            this.userControlChart.Location = new System.Drawing.Point(0, 0);
            this.userControlChart.Margin = new System.Windows.Forms.Padding(4);
            this.userControlChart.Name = "userControlChart";
            this.userControlChart.Size = new System.Drawing.Size(669, 291);
            this.userControlChart.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 26);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 291);
            this.panelLeft.TabIndex = 32;
            // 
            // panelDraw
            // 
            this.panelDraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDraw.Controls.Add(this.panelGraph);
            this.panelDraw.Controls.Add(this.panelRight);
            this.panelDraw.Controls.Add(this.panelLeft);
            this.panelDraw.Controls.Add(this.panelBottom);
            this.panelDraw.Controls.Add(this.toolStripMain);
            this.panelDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDraw.Location = new System.Drawing.Point(0, 0);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(673, 321);
            this.panelDraw.TabIndex = 3;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(669, 26);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 291);
            this.panelRight.TabIndex = 33;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 317);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(669, 0);
            this.panelBottom.TabIndex = 31;
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripButtonRefresh,
            this.toolStripButtonType,
            this.pic,
            this.toolStripComboBoxX,
            this.toolStripComboBoxY,
            this.toolStripLabelCoord});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(669, 26);
            this.toolStripMain.TabIndex = 30;
            this.toolStripMain.Text = "Main";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 23);
            this.openToolStripButton.Text = "Open";
            this.openToolStripButton.Visible = false;
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
            // toolStripComboBoxX
            // 
            this.toolStripComboBoxX.Name = "toolStripComboBoxX";
            this.toolStripComboBoxX.Size = new System.Drawing.Size(121, 26);
            // 
            // toolStripComboBoxY
            // 
            this.toolStripComboBoxY.Name = "toolStripComboBoxY";
            this.toolStripComboBoxY.Size = new System.Drawing.Size(121, 26);
            // 
            // toolStripLabelCoord
            // 
            this.toolStripLabelCoord.Name = "toolStripLabelCoord";
            this.toolStripLabelCoord.Size = new System.Drawing.Size(121, 23);
            this.toolStripLabelCoord.Text = "Coordinates";
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.panelDraw);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(673, 321);
            this.panelCenter.TabIndex = 14;
            // 
            // UserControlNamedSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Name = "UserControlNamedSeries";
            this.Size = new System.Drawing.Size(673, 321);
            this.panelGraph.ResumeLayout(false);
            this.panelDraw.ResumeLayout(false);
            this.panelDraw.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogGraph;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripComboBox toolStripButtonType;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelDraw;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxX;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxY;
        private System.Windows.Forms.ToolStripLabel toolStripLabelCoord;
        private Chart.UserControls.UserControlChart userControlChart;
        private OfficePickers.ColorPicker.ToolStripColorPicker pic;
    }
}
