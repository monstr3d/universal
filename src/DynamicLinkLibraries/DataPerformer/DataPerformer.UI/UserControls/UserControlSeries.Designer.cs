namespace DataPerformer.UI.UserControls
{
    partial class UserControlSeries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlSeries));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.coordLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelDraw = new System.Windows.Forms.Panel();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonType = new System.Windows.Forms.ToolStripComboBox();
            this.pic = new OfficePickers.ColorPicker.ToolStripColorPicker();
            this.toolStripLabelCoord = new System.Windows.Forms.ToolStripLabel();
            this.openFileDialogGraph = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogGraph = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.panelDraw.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 26);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 332);
            this.panelLeft.TabIndex = 32;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coordLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 3);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(439, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // coordLabel
            // 
            this.coordLabel.Name = "coordLabel";
            this.coordLabel.Size = new System.Drawing.Size(17, 17);
            this.coordLabel.Text = "X";
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.panelDraw);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(4);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(591, 362);
            this.panelCenter.TabIndex = 13;
            // 
            // panelDraw
            // 
            this.panelDraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDraw.Controls.Add(this.panelGraph);
            this.panelDraw.Controls.Add(this.panelRight);
            this.panelDraw.Controls.Add(this.panelLeft);
            this.panelDraw.Controls.Add(this.toolStripMain);
            this.panelDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDraw.Location = new System.Drawing.Point(0, 0);
            this.panelDraw.Margin = new System.Windows.Forms.Padding(4);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(591, 362);
            this.panelDraw.TabIndex = 3;
            // 
            // panelGraph
            // 
            this.panelGraph.BackColor = System.Drawing.Color.White;
            this.panelGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraph.Location = new System.Drawing.Point(0, 26);
            this.panelGraph.Margin = new System.Windows.Forms.Padding(4);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(587, 332);
            this.panelGraph.TabIndex = 34;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(587, 26);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 332);
            this.panelRight.TabIndex = 33;
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripButtonRefresh,
            this.toolStripButtonType,
            this.pic,
            this.toolStripLabelCoord});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(587, 26);
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
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
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
            this.toolStripButtonType.Size = new System.Drawing.Size(160, 26);
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
            // toolStripLabelCoord
            // 
            this.toolStripLabelCoord.Name = "toolStripLabelCoord";
            this.toolStripLabelCoord.Size = new System.Drawing.Size(149, 23);
            this.toolStripLabelCoord.Text = "Coordinates";
            // 
            // saveFileDialogGraph
            // 
            this.saveFileDialogGraph.Filter = "Graph files |*.gra";
            // 
            // UserControlSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlSeries";
            this.Size = new System.Drawing.Size(591, 362);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.panelDraw.ResumeLayout(false);
            this.panelDraw.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);

        }
 
        #endregion

        private System.Windows.Forms.Panel panelLeft;
       // private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelDraw;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripComboBox toolStripButtonType;
        private System.Windows.Forms.OpenFileDialog openFileDialogGraph;
        private System.Windows.Forms.SaveFileDialog saveFileDialogGraph;

        /// <summary>
        /// Main tool strip
        /// </summary>
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.Panel panelGraph;
        private OfficePickers.ColorPicker.ToolStripColorPicker pic;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel coordLabel;
        private System.Windows.Forms.ToolStripLabel toolStripLabelCoord;
    }
}
