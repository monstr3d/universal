namespace ImageNavigation.UserControls
{
    partial class UserControlBitmapGraphSelectionTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlBitmapGraphSelectionTab));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pic = new OfficePickers.ColorPicker.ToolStripColorPicker();
            this.toolStripButtonActive = new System.Windows.Forms.ToolStripButton();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageChart = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userControlBitmapChartSelection = new ImageNavigation.UserControls.UserControlBitmapGraphSelection();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.status = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageDataTable = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.labelNumOfPoints = new System.Windows.Forms.Label();
            this.checkBoxShow = new System.Windows.Forms.CheckBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageChart.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPageDataTable.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.pic,
            this.toolStripButtonActive});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(369, 26);
            this.toolStrip.TabIndex = 9;
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
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(368, 26);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1, 325);
            this.panelRight.TabIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 26);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(1, 325);
            this.panelLeft.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 351);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(369, 1);
            this.panelBottom.TabIndex = 0;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControlMain);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(1, 26);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(367, 325);
            this.panelCenter.TabIndex = 10;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageChart);
            this.tabControlMain.Controls.Add(this.tabPageDataTable);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(367, 325);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageChart
            // 
      /*      this.tabPageChart.Controls.Add(this.panel2);
            this.tabPageChart.Controls.Add(this.status);
            this.tabPageChart.Location = new System.Drawing.Point(4, 22);
            this.tabPageChart.Name = "tabPageChart";
            this.tabPageChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChart.Size = new System.Drawing.Size(359, 299);
            this.tabPageChart.TabIndex = 0;
            this.tabPageChart.Text = "Chart";
            this.tabPageChart.UseVisualStyleBackColor = true;*/
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.userControlBitmapChartSelection);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panelTop);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 271);
            this.panel2.TabIndex = 8;
            // 
            // userControlBitmapChartSelection
            // 
            this.userControlBitmapChartSelection.Color = System.Drawing.Color.Empty;
            this.userControlBitmapChartSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlBitmapChartSelection.Location = new System.Drawing.Point(1, 1);
            this.userControlBitmapChartSelection.Name = "userControlBitmapChartSelection";
            this.userControlBitmapChartSelection.Show = false;
            this.userControlBitmapChartSelection.Size = new System.Drawing.Size(351, 270);
            this.userControlBitmapChartSelection.StripVisible = false;
            this.userControlBitmapChartSelection.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(352, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 270);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 270);
            this.panel3.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(353, 1);
            this.panelTop.TabIndex = 0;
            // 
            // status
            // 
         /*   this.status.Location = new System.Drawing.Point(3, 274);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(353, 22);
            this.status.TabIndex = 7;
            this.status.Controls.Add(labelStatus);*/
            // 
            // tabPageDataTable
            // 
            this.tabPageDataTable.Controls.Add(this.panel4);
            this.tabPageDataTable.Controls.Add(this.panel8);
            this.tabPageDataTable.Location = new System.Drawing.Point(4, 22);
            this.tabPageDataTable.Name = "tabPageDataTable";
            this.tabPageDataTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataTable.Size = new System.Drawing.Size(359, 299);
            this.tabPageDataTable.TabIndex = 1;
            this.tabPageDataTable.Text = "Table";
            this.tabPageDataTable.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(353, 251);
            this.panel4.TabIndex = 8;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnX,
            this.ColumnY});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(1, 1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(351, 250);
            this.dataGridView.TabIndex = 3;
            // 
            // ColumnX
            // 
            this.ColumnX.HeaderText = "X";
            this.ColumnX.Name = "ColumnX";
            this.ColumnX.ReadOnly = true;
            // 
            // ColumnY
            // 
            this.ColumnY.HeaderText = "Y";
            this.ColumnY.Name = "ColumnY";
            this.ColumnY.ReadOnly = true;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(352, 1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 250);
            this.panel5.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1, 250);
            this.panel6.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(353, 1);
            this.panel7.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.labelNumOfPoints);
            this.panel8.Controls.Add(this.checkBoxShow);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(3, 254);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(353, 42);
            this.panel8.TabIndex = 7;
            // 
            // labelNumOfPoints
            // 
            this.labelNumOfPoints.AutoSize = true;
            this.labelNumOfPoints.Location = new System.Drawing.Point(121, 4);
            this.labelNumOfPoints.Name = "labelNumOfPoints";
            this.labelNumOfPoints.Size = new System.Drawing.Size(0, 13);
            this.labelNumOfPoints.TabIndex = 1;
            // 
            // checkBoxShow
            // 
            this.checkBoxShow.AutoSize = true;
            this.checkBoxShow.Location = new System.Drawing.Point(21, 4);
            this.checkBoxShow.Name = "checkBoxShow";
            this.checkBoxShow.Size = new System.Drawing.Size(83, 17);
            this.checkBoxShow.TabIndex = 0;
            this.checkBoxShow.Text = "Show Table";
            this.checkBoxShow.UseVisualStyleBackColor = true;
            this.checkBoxShow.CheckedChanged += new System.EventHandler(this.checkBoxShow_CheckedChanged);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(6, 2);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 9;
            this.labelStatus.Text = "Status";
            // 
            // UserControlBitmapGraphSelectionTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.toolStrip);
            this.Name = "UserControlBitmapGraphSelectionTab";
            this.Size = new System.Drawing.Size(369, 352);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageChart.ResumeLayout(false);
            this.tabPageChart.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabPageDataTable.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private OfficePickers.ColorPicker.ToolStripColorPicker pic;
        private System.Windows.Forms.ToolStripButton toolStripButtonActive;
         private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageChart;
        private System.Windows.Forms.TabPage tabPageDataTable;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStripMenuItem status;
        private UserControlBitmapGraphSelection userControlBitmapChartSelection;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnY;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label labelNumOfPoints;
        private System.Windows.Forms.CheckBox checkBoxShow;
        private System.Windows.Forms.Label labelStatus;
    }
}
