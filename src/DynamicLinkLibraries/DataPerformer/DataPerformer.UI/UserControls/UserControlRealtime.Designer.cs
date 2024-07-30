namespace DataPerformer.UI.UserControls
{
    partial class UserControlRealtime
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
            if (realtime != null)
            {
               //!!! Event.Basic.StaticExtensionEventBase.StopRealTime();
            }
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
            panelCenterMain = new System.Windows.Forms.Panel();
            tabControl = new System.Windows.Forms.TabControl();
            tabPageDigital = new System.Windows.Forms.TabPage();
            splitContainer = new System.Windows.Forms.SplitContainer();
            panelCenterSettings = new System.Windows.Forms.Panel();
            panelCenterS = new System.Windows.Forms.Panel();
            panelRightInterval = new System.Windows.Forms.Panel();
            panelLeftS = new System.Windows.Forms.Panel();
            panelTopS = new System.Windows.Forms.Panel();
            userControlRealtimeMeasurements = new UserControlRealtimeMeasurements();
            panelBottomS = new System.Windows.Forms.Panel();
            panelRightSettings = new System.Windows.Forms.Panel();
            panelLeftSettings = new System.Windows.Forms.Panel();
            panelTopSettings = new System.Windows.Forms.Panel();
            label5 = new System.Windows.Forms.Label();
            panelBottomSettings = new System.Windows.Forms.Panel();
            panelCenterDigital = new System.Windows.Forms.Panel();
            panelCenterList = new System.Windows.Forms.Panel();
            userControlRealtimeList = new UserControlRealtimeList();
            panelList = new System.Windows.Forms.Panel();
            panelLeftList = new System.Windows.Forms.Panel();
            panelTopList = new System.Windows.Forms.Panel();
            panelBottomList = new System.Windows.Forms.Panel();
            panelRightDigital = new System.Windows.Forms.Panel();
            panelLeftDigital = new System.Windows.Forms.Panel();
            panelTopDigital = new System.Windows.Forms.Panel();
            labelTime = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            panelBottomDigital = new System.Windows.Forms.Panel();
            tabPageChart = new System.Windows.Forms.TabPage();
            panelCenterChart = new System.Windows.Forms.Panel();
            panelChart = new System.Windows.Forms.Panel();
            panelChartRight = new System.Windows.Forms.Panel();
            panelLeftChart = new System.Windows.Forms.Panel();
            panelTopChart = new System.Windows.Forms.Panel();
            panelBottomChart = new System.Windows.Forms.Panel();
            panelCenter = new System.Windows.Forms.Panel();
            textBoxChartInterval = new System.Windows.Forms.TextBox();
            panelItntervalRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            panelTopInterval = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            panelRightMain = new System.Windows.Forms.Panel();
            panelLeftMain = new System.Windows.Forms.Panel();
            panelTopMain = new System.Windows.Forms.Panel();
            panelBottomMain = new System.Windows.Forms.Panel();
            panelCenterMain.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageDigital.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panelCenterSettings.SuspendLayout();
            panelTopS.SuspendLayout();
            panelTopSettings.SuspendLayout();
            panelCenterDigital.SuspendLayout();
            panelCenterList.SuspendLayout();
            panelTopDigital.SuspendLayout();
            tabPageChart.SuspendLayout();
            panelCenterChart.SuspendLayout();
            panelBottomChart.SuspendLayout();
            panelCenter.SuspendLayout();
            panelLeft.SuspendLayout();
            SuspendLayout();
            // 
            // panelCenterMain
            // 
            panelCenterMain.Controls.Add(tabControl);
            panelCenterMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenterMain.Location = new System.Drawing.Point(0, 0);
            panelCenterMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelCenterMain.Name = "panelCenterMain";
            panelCenterMain.Size = new System.Drawing.Size(513, 352);
            panelCenterMain.TabIndex = 20;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageDigital);
            tabControl.Controls.Add(tabPageChart);
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.Location = new System.Drawing.Point(0, 0);
            tabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(513, 352);
            tabControl.TabIndex = 0;
            // 
            // tabPageDigital
            // 
            tabPageDigital.Controls.Add(splitContainer);
            tabPageDigital.Location = new System.Drawing.Point(4, 24);
            tabPageDigital.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPageDigital.Name = "tabPageDigital";
            tabPageDigital.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPageDigital.Size = new System.Drawing.Size(505, 324);
            tabPageDigital.TabIndex = 0;
            tabPageDigital.Text = "Digital values";
            tabPageDigital.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer.Location = new System.Drawing.Point(4, 3);
            splitContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(panelCenterSettings);
            splitContainer.Panel1.Controls.Add(panelRightSettings);
            splitContainer.Panel1.Controls.Add(panelLeftSettings);
            splitContainer.Panel1.Controls.Add(panelTopSettings);
            splitContainer.Panel1.Controls.Add(panelBottomSettings);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panelCenterDigital);
            splitContainer.Panel2.Controls.Add(panelRightDigital);
            splitContainer.Panel2.Controls.Add(panelLeftDigital);
            splitContainer.Panel2.Controls.Add(panelTopDigital);
            splitContainer.Panel2.Controls.Add(panelBottomDigital);
            splitContainer.Size = new System.Drawing.Size(497, 318);
            splitContainer.SplitterDistance = 200;
            splitContainer.SplitterWidth = 5;
            splitContainer.TabIndex = 0;
            // 
            // panelCenterSettings
            // 
            panelCenterSettings.AutoScroll = true;
            panelCenterSettings.Controls.Add(panelCenterS);
            panelCenterSettings.Controls.Add(panelRightInterval);
            panelCenterSettings.Controls.Add(panelLeftS);
            panelCenterSettings.Controls.Add(panelTopS);
            panelCenterSettings.Controls.Add(panelBottomS);
            panelCenterSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenterSettings.Location = new System.Drawing.Point(0, 31);
            panelCenterSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelCenterSettings.Name = "panelCenterSettings";
            panelCenterSettings.Size = new System.Drawing.Size(200, 287);
            panelCenterSettings.TabIndex = 20;
            // 
            // panelCenterS
            // 
            panelCenterS.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenterS.Location = new System.Drawing.Point(0, 99);
            panelCenterS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelCenterS.Name = "panelCenterS";
            panelCenterS.Size = new System.Drawing.Size(200, 188);
            panelCenterS.TabIndex = 20;
            // 
            // panelRightInterval
            // 
            panelRightInterval.Dock = System.Windows.Forms.DockStyle.Right;
            panelRightInterval.Location = new System.Drawing.Point(200, 99);
            panelRightInterval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelRightInterval.Name = "panelRightInterval";
            panelRightInterval.Size = new System.Drawing.Size(0, 188);
            panelRightInterval.TabIndex = 18;
            // 
            // panelLeftS
            // 
            panelLeftS.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeftS.Location = new System.Drawing.Point(0, 99);
            panelLeftS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelLeftS.Name = "panelLeftS";
            panelLeftS.Size = new System.Drawing.Size(0, 188);
            panelLeftS.TabIndex = 17;
            // 
            // panelTopS
            // 
            panelTopS.AutoSize = true;
            panelTopS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelTopS.Controls.Add(userControlRealtimeMeasurements);
            panelTopS.Dock = System.Windows.Forms.DockStyle.Top;
            panelTopS.Location = new System.Drawing.Point(0, 0);
            panelTopS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTopS.Name = "panelTopS";
            panelTopS.Size = new System.Drawing.Size(200, 99);
            panelTopS.TabIndex = 16;
            // 
            // userControlRealtimeMeasurements
            // 
            userControlRealtimeMeasurements.Dock = System.Windows.Forms.DockStyle.Top;
            userControlRealtimeMeasurements.Location = new System.Drawing.Point(0, 0);
            userControlRealtimeMeasurements.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            userControlRealtimeMeasurements.Name = "userControlRealtimeMeasurements";
            userControlRealtimeMeasurements.Size = new System.Drawing.Size(198, 97);
            userControlRealtimeMeasurements.TabIndex = 0;
            // 
            // panelBottomS
            // 
            panelBottomS.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottomS.Location = new System.Drawing.Point(0, 287);
            panelBottomS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBottomS.Name = "panelBottomS";
            panelBottomS.Size = new System.Drawing.Size(200, 0);
            panelBottomS.TabIndex = 19;
            // 
            // panelRightSettings
            // 
            panelRightSettings.Dock = System.Windows.Forms.DockStyle.Right;
            panelRightSettings.Location = new System.Drawing.Point(200, 31);
            panelRightSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelRightSettings.Name = "panelRightSettings";
            panelRightSettings.Size = new System.Drawing.Size(0, 287);
            panelRightSettings.TabIndex = 18;
            // 
            // panelLeftSettings
            // 
            panelLeftSettings.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeftSettings.Location = new System.Drawing.Point(0, 31);
            panelLeftSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelLeftSettings.Name = "panelLeftSettings";
            panelLeftSettings.Size = new System.Drawing.Size(0, 287);
            panelLeftSettings.TabIndex = 17;
            // 
            // panelTopSettings
            // 
            panelTopSettings.Controls.Add(label5);
            panelTopSettings.Dock = System.Windows.Forms.DockStyle.Top;
            panelTopSettings.Location = new System.Drawing.Point(0, 0);
            panelTopSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTopSettings.Name = "panelTopSettings";
            panelTopSettings.Size = new System.Drawing.Size(200, 31);
            panelTopSettings.TabIndex = 16;
            // 
            // label5
            // 
            label5.Location = new System.Drawing.Point(2, 3);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(197, 37);
            label5.TabIndex = 22;
            label5.Text = "Data sources";
            // 
            // panelBottomSettings
            // 
            panelBottomSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottomSettings.Location = new System.Drawing.Point(0, 318);
            panelBottomSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBottomSettings.Name = "panelBottomSettings";
            panelBottomSettings.Size = new System.Drawing.Size(200, 0);
            panelBottomSettings.TabIndex = 19;
            // 
            // panelCenterDigital
            // 
            panelCenterDigital.Controls.Add(panelCenterList);
            panelCenterDigital.Controls.Add(panelList);
            panelCenterDigital.Controls.Add(panelLeftList);
            panelCenterDigital.Controls.Add(panelTopList);
            panelCenterDigital.Controls.Add(panelBottomList);
            panelCenterDigital.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenterDigital.Location = new System.Drawing.Point(0, 31);
            panelCenterDigital.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelCenterDigital.Name = "panelCenterDigital";
            panelCenterDigital.Size = new System.Drawing.Size(292, 287);
            panelCenterDigital.TabIndex = 20;
            // 
            // panelCenterList
            // 
            panelCenterList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelCenterList.Controls.Add(userControlRealtimeList);
            panelCenterList.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenterList.Location = new System.Drawing.Point(0, 0);
            panelCenterList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelCenterList.Name = "panelCenterList";
            panelCenterList.Size = new System.Drawing.Size(292, 287);
            panelCenterList.TabIndex = 20;
            // 
            // userControlRealtimeList
            // 
            userControlRealtimeList.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlRealtimeList.Location = new System.Drawing.Point(0, 0);
            userControlRealtimeList.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            userControlRealtimeList.Name = "userControlRealtimeList";
            userControlRealtimeList.Size = new System.Drawing.Size(290, 285);
            userControlRealtimeList.TabIndex = 0;
            // 
            // panelList
            // 
            panelList.Dock = System.Windows.Forms.DockStyle.Right;
            panelList.Location = new System.Drawing.Point(292, 0);
            panelList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelList.Name = "panelList";
            panelList.Size = new System.Drawing.Size(0, 287);
            panelList.TabIndex = 18;
            // 
            // panelLeftList
            // 
            panelLeftList.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeftList.Location = new System.Drawing.Point(0, 0);
            panelLeftList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelLeftList.Name = "panelLeftList";
            panelLeftList.Size = new System.Drawing.Size(0, 287);
            panelLeftList.TabIndex = 17;
            // 
            // panelTopList
            // 
            panelTopList.Dock = System.Windows.Forms.DockStyle.Top;
            panelTopList.Location = new System.Drawing.Point(0, 0);
            panelTopList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTopList.Name = "panelTopList";
            panelTopList.Size = new System.Drawing.Size(292, 0);
            panelTopList.TabIndex = 16;
            // 
            // panelBottomList
            // 
            panelBottomList.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottomList.Location = new System.Drawing.Point(0, 287);
            panelBottomList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBottomList.Name = "panelBottomList";
            panelBottomList.Size = new System.Drawing.Size(292, 0);
            panelBottomList.TabIndex = 19;
            // 
            // panelRightDigital
            // 
            panelRightDigital.Dock = System.Windows.Forms.DockStyle.Right;
            panelRightDigital.Location = new System.Drawing.Point(292, 31);
            panelRightDigital.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelRightDigital.Name = "panelRightDigital";
            panelRightDigital.Size = new System.Drawing.Size(0, 287);
            panelRightDigital.TabIndex = 18;
            // 
            // panelLeftDigital
            // 
            panelLeftDigital.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeftDigital.Location = new System.Drawing.Point(0, 31);
            panelLeftDigital.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelLeftDigital.Name = "panelLeftDigital";
            panelLeftDigital.Size = new System.Drawing.Size(0, 287);
            panelLeftDigital.TabIndex = 17;
            // 
            // panelTopDigital
            // 
            panelTopDigital.Controls.Add(labelTime);
            panelTopDigital.Controls.Add(label1);
            panelTopDigital.Dock = System.Windows.Forms.DockStyle.Top;
            panelTopDigital.Location = new System.Drawing.Point(0, 0);
            panelTopDigital.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTopDigital.Name = "panelTopDigital";
            panelTopDigital.Size = new System.Drawing.Size(292, 31);
            panelTopDigital.TabIndex = 16;
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Location = new System.Drawing.Point(74, 5);
            labelTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelTime.Name = "labelTime";
            labelTime.Size = new System.Drawing.Size(0, 15);
            labelTime.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(18, 5);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(33, 15);
            label1.TabIndex = 0;
            label1.Text = "Time";
            // 
            // panelBottomDigital
            // 
            panelBottomDigital.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottomDigital.Location = new System.Drawing.Point(0, 318);
            panelBottomDigital.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBottomDigital.Name = "panelBottomDigital";
            panelBottomDigital.Size = new System.Drawing.Size(292, 0);
            panelBottomDigital.TabIndex = 19;
            // 
            // tabPageChart
            // 
            tabPageChart.Controls.Add(panelCenterChart);
            tabPageChart.Controls.Add(panelChartRight);
            tabPageChart.Controls.Add(panelLeftChart);
            tabPageChart.Controls.Add(panelTopChart);
            tabPageChart.Controls.Add(panelBottomChart);
            tabPageChart.Location = new System.Drawing.Point(4, 24);
            tabPageChart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPageChart.Name = "tabPageChart";
            tabPageChart.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPageChart.Size = new System.Drawing.Size(505, 324);
            tabPageChart.TabIndex = 1;
            tabPageChart.Text = "Chart";
            tabPageChart.UseVisualStyleBackColor = true;
            // 
            // panelCenterChart
            // 
            panelCenterChart.Controls.Add(panelChart);
            panelCenterChart.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenterChart.Location = new System.Drawing.Point(4, 3);
            panelCenterChart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelCenterChart.Name = "panelCenterChart";
            panelCenterChart.Size = new System.Drawing.Size(497, 289);
            panelCenterChart.TabIndex = 20;
            // 
            // panelChart
            // 
            panelChart.Dock = System.Windows.Forms.DockStyle.Fill;
            panelChart.Location = new System.Drawing.Point(0, 0);
            panelChart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelChart.Name = "panelChart";
            panelChart.Size = new System.Drawing.Size(497, 289);
            panelChart.TabIndex = 0;
            panelChart.Resize += panelChart_Resize;
            // 
            // panelChartRight
            // 
            panelChartRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelChartRight.Location = new System.Drawing.Point(501, 3);
            panelChartRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelChartRight.Name = "panelChartRight";
            panelChartRight.Size = new System.Drawing.Size(0, 289);
            panelChartRight.TabIndex = 18;
            // 
            // panelLeftChart
            // 
            panelLeftChart.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeftChart.Location = new System.Drawing.Point(4, 3);
            panelLeftChart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelLeftChart.Name = "panelLeftChart";
            panelLeftChart.Size = new System.Drawing.Size(0, 289);
            panelLeftChart.TabIndex = 17;
            // 
            // panelTopChart
            // 
            panelTopChart.Dock = System.Windows.Forms.DockStyle.Top;
            panelTopChart.Location = new System.Drawing.Point(4, 3);
            panelTopChart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTopChart.Name = "panelTopChart";
            panelTopChart.Size = new System.Drawing.Size(497, 0);
            panelTopChart.TabIndex = 16;
            // 
            // panelBottomChart
            // 
            panelBottomChart.Controls.Add(panelCenter);
            panelBottomChart.Controls.Add(panelItntervalRight);
            panelBottomChart.Controls.Add(panelLeft);
            panelBottomChart.Controls.Add(panelTopInterval);
            panelBottomChart.Controls.Add(panelBottom);
            panelBottomChart.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottomChart.Location = new System.Drawing.Point(4, 292);
            panelBottomChart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBottomChart.Name = "panelBottomChart";
            panelBottomChart.Size = new System.Drawing.Size(497, 29);
            panelBottomChart.TabIndex = 19;
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(textBoxChartInterval);
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(144, 0);
            panelCenter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(332, 29);
            panelCenter.TabIndex = 20;
            // 
            // textBoxChartInterval
            // 
            textBoxChartInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            textBoxChartInterval.Location = new System.Drawing.Point(0, 0);
            textBoxChartInterval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxChartInterval.Name = "textBoxChartInterval";
            textBoxChartInterval.Size = new System.Drawing.Size(332, 23);
            textBoxChartInterval.TabIndex = 0;
            // 
            // panelItntervalRight
            // 
            panelItntervalRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelItntervalRight.Location = new System.Drawing.Point(476, 0);
            panelItntervalRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelItntervalRight.Name = "panelItntervalRight";
            panelItntervalRight.Size = new System.Drawing.Size(21, 29);
            panelItntervalRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(label2);
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 0);
            panelLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(144, 29);
            panelLeft.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(4, 10);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(89, 15);
            label2.TabIndex = 0;
            label2.Text = "Chart Interval, s";
            // 
            // panelTopInterval
            // 
            panelTopInterval.Dock = System.Windows.Forms.DockStyle.Top;
            panelTopInterval.Location = new System.Drawing.Point(0, 0);
            panelTopInterval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTopInterval.Name = "panelTopInterval";
            panelTopInterval.Size = new System.Drawing.Size(497, 0);
            panelTopInterval.TabIndex = 16;
            // 
            // panelBottom
            // 
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 29);
            panelBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(497, 0);
            panelBottom.TabIndex = 19;
            // 
            // panelRightMain
            // 
            panelRightMain.Dock = System.Windows.Forms.DockStyle.Right;
            panelRightMain.Location = new System.Drawing.Point(513, 0);
            panelRightMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelRightMain.Name = "panelRightMain";
            panelRightMain.Size = new System.Drawing.Size(0, 352);
            panelRightMain.TabIndex = 18;
            // 
            // panelLeftMain
            // 
            panelLeftMain.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeftMain.Location = new System.Drawing.Point(0, 0);
            panelLeftMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelLeftMain.Name = "panelLeftMain";
            panelLeftMain.Size = new System.Drawing.Size(0, 352);
            panelLeftMain.TabIndex = 17;
            // 
            // panelTopMain
            // 
            panelTopMain.Dock = System.Windows.Forms.DockStyle.Top;
            panelTopMain.Location = new System.Drawing.Point(0, 0);
            panelTopMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTopMain.Name = "panelTopMain";
            panelTopMain.Size = new System.Drawing.Size(513, 0);
            panelTopMain.TabIndex = 16;
            // 
            // panelBottomMain
            // 
            panelBottomMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottomMain.Location = new System.Drawing.Point(0, 352);
            panelBottomMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBottomMain.Name = "panelBottomMain";
            panelBottomMain.Size = new System.Drawing.Size(513, 0);
            panelBottomMain.TabIndex = 19;
            // 
            // UserControlRealtime
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelCenterMain);
            Controls.Add(panelRightMain);
            Controls.Add(panelLeftMain);
            Controls.Add(panelTopMain);
            Controls.Add(panelBottomMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UserControlRealtime";
            Size = new System.Drawing.Size(513, 352);
            panelCenterMain.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPageDigital.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panelCenterSettings.ResumeLayout(false);
            panelCenterSettings.PerformLayout();
            panelTopS.ResumeLayout(false);
            panelTopSettings.ResumeLayout(false);
            panelCenterDigital.ResumeLayout(false);
            panelCenterList.ResumeLayout(false);
            panelTopDigital.ResumeLayout(false);
            panelTopDigital.PerformLayout();
            tabPageChart.ResumeLayout(false);
            panelCenterChart.ResumeLayout(false);
            panelBottomChart.ResumeLayout(false);
            panelCenter.ResumeLayout(false);
            panelCenter.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCenterMain;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageDigital;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabPage tabPageChart;
        private System.Windows.Forms.Panel panelRightMain;
        private System.Windows.Forms.Panel panelLeftMain;
        private System.Windows.Forms.Panel panelTopMain;
        private System.Windows.Forms.Panel panelBottomMain;
        private System.Windows.Forms.Panel panelCenterSettings;
        private System.Windows.Forms.Panel panelRightSettings;
        private System.Windows.Forms.Panel panelLeftSettings;
        private System.Windows.Forms.Panel panelTopSettings;
        private System.Windows.Forms.Panel panelBottomSettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelCenterDigital;
        private System.Windows.Forms.Panel panelRightDigital;
        private System.Windows.Forms.Panel panelLeftDigital;
        private System.Windows.Forms.Panel panelTopDigital;
        private System.Windows.Forms.Panel panelBottomDigital;
        private System.Windows.Forms.Panel panelCenterS;
        private System.Windows.Forms.Panel panelRightInterval;
        private System.Windows.Forms.Panel panelLeftS;
        private System.Windows.Forms.Panel panelTopS;
        private System.Windows.Forms.Panel panelBottomS;
        private UserControlRealtimeMeasurements userControlRealtimeMeasurements;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCenterList;
        private UserControlRealtimeList userControlRealtimeList;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Panel panelLeftList;
        private System.Windows.Forms.Panel panelTopList;
        private System.Windows.Forms.Panel panelBottomList;
        private System.Windows.Forms.Panel panelCenterChart;
        private System.Windows.Forms.Panel panelChartRight;
        private System.Windows.Forms.Panel panelLeftChart;
        private System.Windows.Forms.Panel panelTopChart;
        private System.Windows.Forms.Panel panelBottomChart;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.TextBox textBoxChartInterval;
        private System.Windows.Forms.Panel panelItntervalRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTopInterval;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.Label labelTime;
    }
}
