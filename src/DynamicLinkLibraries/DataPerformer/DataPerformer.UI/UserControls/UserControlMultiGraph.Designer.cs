namespace DataPerformer.UI.UserControls
{
    partial class UserControlMultiGraph
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlMultiGraph));
            Chart.Drawing.Coordinators.SimpleCoordinator simpleCoordinator1 = new Chart.Drawing.Coordinators.SimpleCoordinator();
            backgroundWorkerTextRealtimeAnalysis = new System.ComponentModel.BackgroundWorker();
            showRuntimeIndicatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(components);
            panelRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            toolStripButtonSeries = new System.Windows.Forms.ToolStripComboBox();
            toolStripButtonType = new System.Windows.Forms.ToolStripComboBox();
            toolStripButtonClearAll = new System.Windows.Forms.ToolStripButton();
            toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            toolStripComboBoxPoints = new System.Windows.Forms.ToolStripComboBox();
            toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            toolStripButtonPause = new System.Windows.Forms.ToolStripButton();
            toolStripButtonAnimation = new System.Windows.Forms.ToolStripButton();
            toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            toolStripMain = new System.Windows.Forms.ToolStrip();
            toolStripLabelNumber = new System.Windows.Forms.ToolStripLabel();
            toolStripComboBoxNumber = new System.Windows.Forms.ToolStripComboBox();
            backgroundWorkerReatimeAnalysis = new System.ComponentModel.BackgroundWorker();
            contextMenuStripTextTab = new System.Windows.Forms.ContextMenuStrip(components);
            saveXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panelDraw = new System.Windows.Forms.Panel();
            panelMain = new System.Windows.Forms.Panel();
            splitContainer = new System.Windows.Forms.SplitContainer();
            userControlChartDouble = new Chart.UserControls.UserControlChartDouble();
            userControlFilledChart = new Chart.UserControls.UserControlFilledChart();
            userControlChartMeasurements = new UserControlChartMeasurements();
            panelBottom = new System.Windows.Forms.Panel();
            panelCenter = new System.Windows.Forms.Panel();
            userControlDoubleMeasurements = new UserControlDoubleMeasurements();
            contextMenuStripMain.SuspendLayout();
            toolStripMain.SuspendLayout();
            contextMenuStripTextTab.SuspendLayout();
            panelDraw.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panelCenter.SuspendLayout();
            SuspendLayout();
            // 
            // backgroundWorkerTextRealtimeAnalysis
            // 
            backgroundWorkerTextRealtimeAnalysis.WorkerSupportsCancellation = true;
            // 
            // showRuntimeIndicatorsToolStripMenuItem
            // 
            showRuntimeIndicatorsToolStripMenuItem.Name = "showRuntimeIndicatorsToolStripMenuItem";
            showRuntimeIndicatorsToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            showRuntimeIndicatorsToolStripMenuItem.Text = "Show runtime indicators";
            // 
            // contextMenuStripMain
            // 
            contextMenuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { showRuntimeIndicatorsToolStripMenuItem });
            contextMenuStripMain.Name = "contextMenuStripMain";
            contextMenuStripMain.Size = new System.Drawing.Size(204, 26);
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(825, 0);
            panelRight.Margin = new System.Windows.Forms.Padding(4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(1, 479);
            panelRight.TabIndex = 2;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 0);
            panelLeft.Margin = new System.Windows.Forms.Padding(4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(1, 479);
            panelLeft.TabIndex = 1;
            // 
            // toolStripButtonSeries
            // 
            toolStripButtonSeries.Name = "toolStripButtonSeries";
            toolStripButtonSeries.Size = new System.Drawing.Size(75, 27);
            toolStripButtonSeries.Text = "<Series>";
            toolStripButtonSeries.Visible = false;
            // 
            // toolStripButtonType
            // 
            toolStripButtonType.Name = "toolStripButtonType";
            toolStripButtonType.Size = new System.Drawing.Size(140, 27);
            toolStripButtonType.Text = "<Series type>";
            toolStripButtonType.Visible = false;
            // 
            // toolStripButtonClearAll
            // 
            toolStripButtonClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonClearAll.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonClearAll.Image");
            toolStripButtonClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonClearAll.Name = "toolStripButtonClearAll";
            toolStripButtonClearAll.Size = new System.Drawing.Size(24, 24);
            toolStripButtonClearAll.Text = "Clear all";
            // 
            // toolStripButtonAdd
            // 
            toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonAdd.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonAdd.Image");
            toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new System.Drawing.Size(24, 24);
            toolStripButtonAdd.Text = "Add";
            toolStripButtonAdd.Visible = false;
            // 
            // toolStripComboBoxPoints
            // 
            toolStripComboBoxPoints.Name = "toolStripComboBoxPoints";
            toolStripComboBoxPoints.Size = new System.Drawing.Size(140, 27);
            toolStripComboBoxPoints.Text = "<Points>";
            toolStripComboBoxPoints.Visible = false;
            // 
            // toolStripButtonStop
            // 
            toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonStop.Enabled = false;
            toolStripButtonStop.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonStop.Image");
            toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonStop.Name = "toolStripButtonStop";
            toolStripButtonStop.Size = new System.Drawing.Size(24, 24);
            toolStripButtonStop.Text = "Stop";
            // 
            // toolStripButtonPause
            // 
            toolStripButtonPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonPause.Enabled = false;
            toolStripButtonPause.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonPause.Image");
            toolStripButtonPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonPause.Name = "toolStripButtonPause";
            toolStripButtonPause.Size = new System.Drawing.Size(24, 24);
            toolStripButtonPause.Text = "Pause";
            // 
            // toolStripButtonAnimation
            // 
            toolStripButtonAnimation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonAnimation.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonAnimation.Image");
            toolStripButtonAnimation.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonAnimation.Name = "toolStripButtonAnimation";
            toolStripButtonAnimation.Size = new System.Drawing.Size(24, 24);
            toolStripButtonAnimation.Text = "Animation";
            toolStripButtonAnimation.Visible = false;
            // 
            // toolStripButtonStart
            // 
            toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonStart.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonStart.Image");
            toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonStart.Name = "toolStripButtonStart";
            toolStripButtonStart.Size = new System.Drawing.Size(24, 24);
            toolStripButtonStart.Text = "Start";
            // 
            // toolStripMain
            // 
            toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonStart, toolStripButtonAnimation, toolStripButtonPause, toolStripButtonStop, toolStripComboBoxPoints, toolStripButtonAdd, toolStripButtonClearAll, toolStripButtonType, toolStripButtonSeries, toolStripLabelNumber, toolStripComboBoxNumber });
            toolStripMain.Location = new System.Drawing.Point(0, 0);
            toolStripMain.Name = "toolStripMain";
            toolStripMain.Size = new System.Drawing.Size(820, 27);
            toolStripMain.TabIndex = 30;
            toolStripMain.Text = "Main";
            // 
            // toolStripLabelNumber
            // 
            toolStripLabelNumber.Name = "toolStripLabelNumber";
            toolStripLabelNumber.Size = new System.Drawing.Size(100, 24);
            toolStripLabelNumber.Text = "Number of charts";
            // 
            // toolStripComboBoxNumber
            // 
            toolStripComboBoxNumber.Items.AddRange(new object[] { "1", "2" });
            toolStripComboBoxNumber.Name = "toolStripComboBoxNumber";
            toolStripComboBoxNumber.Size = new System.Drawing.Size(121, 27);
            // 
            // backgroundWorkerReatimeAnalysis
            // 
            backgroundWorkerReatimeAnalysis.WorkerSupportsCancellation = true;
            // 
            // contextMenuStripTextTab
            // 
            contextMenuStripTextTab.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStripTextTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { saveXmlToolStripMenuItem });
            contextMenuStripTextTab.Name = "contextMenuStripTextTab";
            contextMenuStripTextTab.Size = new System.Drawing.Size(123, 26);
            // 
            // saveXmlToolStripMenuItem
            // 
            saveXmlToolStripMenuItem.Name = "saveXmlToolStripMenuItem";
            saveXmlToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            saveXmlToolStripMenuItem.Text = "Save Xml";
            // 
            // panelDraw
            // 
            panelDraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panelDraw.Controls.Add(panelMain);
            panelDraw.Controls.Add(toolStripMain);
            panelDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            panelDraw.Location = new System.Drawing.Point(1, 0);
            panelDraw.Margin = new System.Windows.Forms.Padding(4);
            panelDraw.Name = "panelDraw";
            panelDraw.Size = new System.Drawing.Size(824, 479);
            panelDraw.TabIndex = 3;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(splitContainer);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 27);
            panelMain.Name = "panelMain";
            panelMain.Size = new System.Drawing.Size(820, 448);
            panelMain.TabIndex = 31;
            // 
            // splitContainer
            // 
            splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer.Location = new System.Drawing.Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(userControlChartDouble);
            splitContainer.Panel1.Controls.Add(userControlFilledChart);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(userControlDoubleMeasurements);
            splitContainer.Panel2.Controls.Add(userControlChartMeasurements);
            splitContainer.Size = new System.Drawing.Size(820, 448);
            splitContainer.SplitterDistance = 666;
            splitContainer.TabIndex = 0;
            // 
            // userControlChartDouble
            // 
            userControlChartDouble.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlChartDouble.Location = new System.Drawing.Point(0, 0);
            userControlChartDouble.Name = "userControlChartDouble";
            userControlChartDouble.Size = new System.Drawing.Size(666, 448);
            userControlChartDouble.TabIndex = 1;
            userControlChartDouble.Visible = false;
            // 
            // userControlFilledChart
            // 
            userControlFilledChart.Coordinator = simpleCoordinator1;
            userControlFilledChart.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlFilledChart.IsBlocked = false;
            userControlFilledChart.Location = new System.Drawing.Point(0, 0);
            userControlFilledChart.Name = "userControlFilledChart";
            userControlFilledChart.Size = new System.Drawing.Size(666, 448);
            userControlFilledChart.TabIndex = 0;
            userControlFilledChart.Visible = false;
            // 
            // userControlChartMeasurements
            // 
            userControlChartMeasurements.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlChartMeasurements.Location = new System.Drawing.Point(0, 0);
            userControlChartMeasurements.Name = "userControlChartMeasurements";
            userControlChartMeasurements.Size = new System.Drawing.Size(150, 448);
            userControlChartMeasurements.TabIndex = 0;
            userControlChartMeasurements.Visible = false;
            // 
            // panelBottom
            // 
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 478);
            panelBottom.Margin = new System.Windows.Forms.Padding(4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(826, 1);
            panelBottom.TabIndex = 11;
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(panelDraw);
            panelCenter.Controls.Add(panelRight);
            panelCenter.Controls.Add(panelLeft);
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(0, 0);
            panelCenter.Margin = new System.Windows.Forms.Padding(4);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(826, 479);
            panelCenter.TabIndex = 12;
            // 
            // userControlDoubleMeasurements
            // 
            userControlDoubleMeasurements.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlDoubleMeasurements.Location = new System.Drawing.Point(0, 0);
            userControlDoubleMeasurements.Name = "userControlDoubleMeasurements";
            userControlDoubleMeasurements.Size = new System.Drawing.Size(150, 448);
            userControlDoubleMeasurements.TabIndex = 1;
            // 
            // UserControlMultiGraph
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelBottom);
            Controls.Add(panelCenter);
            Name = "UserControlMultiGraph";
            Size = new System.Drawing.Size(826, 479);
            contextMenuStripMain.ResumeLayout(false);
            toolStripMain.ResumeLayout(false);
            toolStripMain.PerformLayout();
            contextMenuStripTextTab.ResumeLayout(false);
            panelDraw.ResumeLayout(false);
            panelDraw.PerformLayout();
            panelMain.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panelCenter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorkerTextRealtimeAnalysis;
        private System.Windows.Forms.ToolStripMenuItem showRuntimeIndicatorsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.ToolStripComboBox toolStripButtonSeries;
        private System.Windows.Forms.ToolStripComboBox toolStripButtonType;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearAll;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxPoints;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripButton toolStripButtonPause;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnimation;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReatimeAnalysis;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTextTab;
        private System.Windows.Forms.ToolStripMenuItem saveXmlToolStripMenuItem;
        private System.Windows.Forms.Panel panelDraw;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.ToolStripLabel toolStripLabelNumber;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxNumber;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Chart.UserControls.UserControlFilledChart userControlFilledChart;
        private Chart.UserControls.UserControlChartDouble userControlChartDouble;
        private UserControlChartMeasurements userControlChartMeasurements;
        private UserControlDoubleMeasurements userControlDoubleMeasurements;
    }
}
