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
            this.panelCenterMain = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageDigital = new System.Windows.Forms.TabPage();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panelCenterSettings = new System.Windows.Forms.Panel();
            this.panelCenterS = new System.Windows.Forms.Panel();
            this.panelRightInterval = new System.Windows.Forms.Panel();
            this.panelLeftS = new System.Windows.Forms.Panel();
            this.panelTopS = new System.Windows.Forms.Panel();
            this.panelBottomS = new System.Windows.Forms.Panel();
            this.panelRightSettings = new System.Windows.Forms.Panel();
            this.panelLeftSettings = new System.Windows.Forms.Panel();
            this.panelTopSettings = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panelBottomSettings = new System.Windows.Forms.Panel();
            this.panelCenterDigital = new System.Windows.Forms.Panel();
            this.panelCenterList = new System.Windows.Forms.Panel();
            this.panelList = new System.Windows.Forms.Panel();
            this.panelLeftList = new System.Windows.Forms.Panel();
            this.panelTopList = new System.Windows.Forms.Panel();
            this.panelBottomList = new System.Windows.Forms.Panel();
            this.panelRightDigital = new System.Windows.Forms.Panel();
            this.panelLeftDigital = new System.Windows.Forms.Panel();
            this.panelTopDigital = new System.Windows.Forms.Panel();
            this.labelTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBottomDigital = new System.Windows.Forms.Panel();
            this.tabPageChart = new System.Windows.Forms.TabPage();
            this.panelCenterChart = new System.Windows.Forms.Panel();
            this.panelChart = new System.Windows.Forms.Panel();
            this.panelChartRight = new System.Windows.Forms.Panel();
            this.panelLeftChart = new System.Windows.Forms.Panel();
            this.panelTopChart = new System.Windows.Forms.Panel();
            this.panelBottomChart = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.textBoxChartInterval = new System.Windows.Forms.TextBox();
            this.panelItntervalRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTopInterval = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelRightMain = new System.Windows.Forms.Panel();
            this.panelLeftMain = new System.Windows.Forms.Panel();
            this.panelTopMain = new System.Windows.Forms.Panel();
            this.panelBottomMain = new System.Windows.Forms.Panel();
            this.userControlRealtimeMeasurements = new DataPerformer.UI.UserControls.UserControlRealtimeMeasurements();
            this.userControlRealtimeList = new DataPerformer.UI.UserControls.UserControlRealtimeList();
            this.elementHost = new System.Windows.Forms.Integration.ElementHost();
            this.performer = new DataPerformer.UI.UserControls.Wpf.UserControlWpfChart();
            this.panelCenterMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageDigital.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelCenterSettings.SuspendLayout();
            this.panelTopS.SuspendLayout();
            this.panelTopSettings.SuspendLayout();
            this.panelCenterDigital.SuspendLayout();
            this.panelCenterList.SuspendLayout();
            this.panelTopDigital.SuspendLayout();
            this.tabPageChart.SuspendLayout();
            this.panelCenterChart.SuspendLayout();
            this.panelChart.SuspendLayout();
            this.panelBottomChart.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenterMain
            // 
            this.panelCenterMain.Controls.Add(this.tabControl);
            this.panelCenterMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterMain.Location = new System.Drawing.Point(0, 0);
            this.panelCenterMain.Name = "panelCenterMain";
            this.panelCenterMain.Size = new System.Drawing.Size(440, 305);
            this.panelCenterMain.TabIndex = 20;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageDigital);
            this.tabControl.Controls.Add(this.tabPageChart);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(440, 305);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageDigital
            // 
            this.tabPageDigital.Controls.Add(this.splitContainer);
            this.tabPageDigital.Location = new System.Drawing.Point(4, 22);
            this.tabPageDigital.Name = "tabPageDigital";
            this.tabPageDigital.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDigital.Size = new System.Drawing.Size(432, 279);
            this.tabPageDigital.TabIndex = 0;
            this.tabPageDigital.Text = "Digital values";
            this.tabPageDigital.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(3, 3);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panelCenterSettings);
            this.splitContainer.Panel1.Controls.Add(this.panelRightSettings);
            this.splitContainer.Panel1.Controls.Add(this.panelLeftSettings);
            this.splitContainer.Panel1.Controls.Add(this.panelTopSettings);
            this.splitContainer.Panel1.Controls.Add(this.panelBottomSettings);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelCenterDigital);
            this.splitContainer.Panel2.Controls.Add(this.panelRightDigital);
            this.splitContainer.Panel2.Controls.Add(this.panelLeftDigital);
            this.splitContainer.Panel2.Controls.Add(this.panelTopDigital);
            this.splitContainer.Panel2.Controls.Add(this.panelBottomDigital);
            this.splitContainer.Size = new System.Drawing.Size(426, 273);
            this.splitContainer.SplitterDistance = 172;
            this.splitContainer.TabIndex = 0;
            // 
            // panelCenterSettings
            // 
            this.panelCenterSettings.AutoScroll = true;
            this.panelCenterSettings.Controls.Add(this.panelCenterS);
            this.panelCenterSettings.Controls.Add(this.panelRightInterval);
            this.panelCenterSettings.Controls.Add(this.panelLeftS);
            this.panelCenterSettings.Controls.Add(this.panelTopS);
            this.panelCenterSettings.Controls.Add(this.panelBottomS);
            this.panelCenterSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterSettings.Location = new System.Drawing.Point(0, 27);
            this.panelCenterSettings.Name = "panelCenterSettings";
            this.panelCenterSettings.Size = new System.Drawing.Size(172, 246);
            this.panelCenterSettings.TabIndex = 20;
            // 
            // panelCenterS
            // 
            this.panelCenterS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterS.Location = new System.Drawing.Point(0, 86);
            this.panelCenterS.Name = "panelCenterS";
            this.panelCenterS.Size = new System.Drawing.Size(172, 160);
            this.panelCenterS.TabIndex = 20;
            // 
            // panelRightInterval
            // 
            this.panelRightInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightInterval.Location = new System.Drawing.Point(172, 86);
            this.panelRightInterval.Name = "panelRightInterval";
            this.panelRightInterval.Size = new System.Drawing.Size(0, 160);
            this.panelRightInterval.TabIndex = 18;
            // 
            // panelLeftS
            // 
            this.panelLeftS.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftS.Location = new System.Drawing.Point(0, 86);
            this.panelLeftS.Name = "panelLeftS";
            this.panelLeftS.Size = new System.Drawing.Size(0, 160);
            this.panelLeftS.TabIndex = 17;
            // 
            // panelTopS
            // 
            this.panelTopS.AutoSize = true;
            this.panelTopS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopS.Controls.Add(this.userControlRealtimeMeasurements);
            this.panelTopS.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopS.Location = new System.Drawing.Point(0, 0);
            this.panelTopS.Name = "panelTopS";
            this.panelTopS.Size = new System.Drawing.Size(172, 86);
            this.panelTopS.TabIndex = 16;
            // 
            // panelBottomS
            // 
            this.panelBottomS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomS.Location = new System.Drawing.Point(0, 246);
            this.panelBottomS.Name = "panelBottomS";
            this.panelBottomS.Size = new System.Drawing.Size(172, 0);
            this.panelBottomS.TabIndex = 19;
            // 
            // panelRightSettings
            // 
            this.panelRightSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightSettings.Location = new System.Drawing.Point(172, 27);
            this.panelRightSettings.Name = "panelRightSettings";
            this.panelRightSettings.Size = new System.Drawing.Size(0, 246);
            this.panelRightSettings.TabIndex = 18;
            // 
            // panelLeftSettings
            // 
            this.panelLeftSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftSettings.Location = new System.Drawing.Point(0, 27);
            this.panelLeftSettings.Name = "panelLeftSettings";
            this.panelLeftSettings.Size = new System.Drawing.Size(0, 246);
            this.panelLeftSettings.TabIndex = 17;
            // 
            // panelTopSettings
            // 
            this.panelTopSettings.Controls.Add(this.label5);
            this.panelTopSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopSettings.Location = new System.Drawing.Point(0, 0);
            this.panelTopSettings.Name = "panelTopSettings";
            this.panelTopSettings.Size = new System.Drawing.Size(172, 27);
            this.panelTopSettings.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(2, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 32);
            this.label5.TabIndex = 22;
            this.label5.Text = "Data sources";
            // 
            // panelBottomSettings
            // 
            this.panelBottomSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomSettings.Location = new System.Drawing.Point(0, 273);
            this.panelBottomSettings.Name = "panelBottomSettings";
            this.panelBottomSettings.Size = new System.Drawing.Size(172, 0);
            this.panelBottomSettings.TabIndex = 19;
            // 
            // panelCenterDigital
            // 
            this.panelCenterDigital.Controls.Add(this.panelCenterList);
            this.panelCenterDigital.Controls.Add(this.panelList);
            this.panelCenterDigital.Controls.Add(this.panelLeftList);
            this.panelCenterDigital.Controls.Add(this.panelTopList);
            this.panelCenterDigital.Controls.Add(this.panelBottomList);
            this.panelCenterDigital.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterDigital.Location = new System.Drawing.Point(0, 27);
            this.panelCenterDigital.Name = "panelCenterDigital";
            this.panelCenterDigital.Size = new System.Drawing.Size(250, 246);
            this.panelCenterDigital.TabIndex = 20;
            // 
            // panelCenterList
            // 
            this.panelCenterList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCenterList.Controls.Add(this.userControlRealtimeList);
            this.panelCenterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterList.Location = new System.Drawing.Point(0, 0);
            this.panelCenterList.Name = "panelCenterList";
            this.panelCenterList.Size = new System.Drawing.Size(250, 246);
            this.panelCenterList.TabIndex = 20;
            // 
            // panelList
            // 
            this.panelList.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelList.Location = new System.Drawing.Point(250, 0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(0, 246);
            this.panelList.TabIndex = 18;
            // 
            // panelLeftList
            // 
            this.panelLeftList.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftList.Location = new System.Drawing.Point(0, 0);
            this.panelLeftList.Name = "panelLeftList";
            this.panelLeftList.Size = new System.Drawing.Size(0, 246);
            this.panelLeftList.TabIndex = 17;
            // 
            // panelTopList
            // 
            this.panelTopList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopList.Location = new System.Drawing.Point(0, 0);
            this.panelTopList.Name = "panelTopList";
            this.panelTopList.Size = new System.Drawing.Size(250, 0);
            this.panelTopList.TabIndex = 16;
            // 
            // panelBottomList
            // 
            this.panelBottomList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomList.Location = new System.Drawing.Point(0, 246);
            this.panelBottomList.Name = "panelBottomList";
            this.panelBottomList.Size = new System.Drawing.Size(250, 0);
            this.panelBottomList.TabIndex = 19;
            // 
            // panelRightDigital
            // 
            this.panelRightDigital.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightDigital.Location = new System.Drawing.Point(250, 27);
            this.panelRightDigital.Name = "panelRightDigital";
            this.panelRightDigital.Size = new System.Drawing.Size(0, 246);
            this.panelRightDigital.TabIndex = 18;
            // 
            // panelLeftDigital
            // 
            this.panelLeftDigital.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftDigital.Location = new System.Drawing.Point(0, 27);
            this.panelLeftDigital.Name = "panelLeftDigital";
            this.panelLeftDigital.Size = new System.Drawing.Size(0, 246);
            this.panelLeftDigital.TabIndex = 17;
            // 
            // panelTopDigital
            // 
            this.panelTopDigital.Controls.Add(this.labelTime);
            this.panelTopDigital.Controls.Add(this.label1);
            this.panelTopDigital.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopDigital.Location = new System.Drawing.Point(0, 0);
            this.panelTopDigital.Name = "panelTopDigital";
            this.panelTopDigital.Size = new System.Drawing.Size(250, 27);
            this.panelTopDigital.TabIndex = 16;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(63, 4);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(0, 13);
            this.labelTime.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time";
            // 
            // panelBottomDigital
            // 
            this.panelBottomDigital.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomDigital.Location = new System.Drawing.Point(0, 273);
            this.panelBottomDigital.Name = "panelBottomDigital";
            this.panelBottomDigital.Size = new System.Drawing.Size(250, 0);
            this.panelBottomDigital.TabIndex = 19;
            // 
            // tabPageChart
            // 
            this.tabPageChart.Controls.Add(this.panelCenterChart);
            this.tabPageChart.Controls.Add(this.panelChartRight);
            this.tabPageChart.Controls.Add(this.panelLeftChart);
            this.tabPageChart.Controls.Add(this.panelTopChart);
            this.tabPageChart.Controls.Add(this.panelBottomChart);
            this.tabPageChart.Location = new System.Drawing.Point(4, 22);
            this.tabPageChart.Name = "tabPageChart";
            this.tabPageChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChart.Size = new System.Drawing.Size(432, 279);
            this.tabPageChart.TabIndex = 1;
            this.tabPageChart.Text = "Chart";
            this.tabPageChart.UseVisualStyleBackColor = true;
            // 
            // panelCenterChart
            // 
            this.panelCenterChart.Controls.Add(this.panelChart);
            this.panelCenterChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterChart.Location = new System.Drawing.Point(3, 3);
            this.panelCenterChart.Name = "panelCenterChart";
            this.panelCenterChart.Size = new System.Drawing.Size(426, 248);
            this.panelCenterChart.TabIndex = 20;
            // 
            // panelChart
            // 
            this.panelChart.Controls.Add(this.elementHost);
            this.panelChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChart.Location = new System.Drawing.Point(0, 0);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(426, 248);
            this.panelChart.TabIndex = 0;
            this.panelChart.Resize += new System.EventHandler(this.panelChart_Resize);
            // 
            // panelChartRight
            // 
            this.panelChartRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelChartRight.Location = new System.Drawing.Point(429, 3);
            this.panelChartRight.Name = "panelChartRight";
            this.panelChartRight.Size = new System.Drawing.Size(0, 248);
            this.panelChartRight.TabIndex = 18;
            // 
            // panelLeftChart
            // 
            this.panelLeftChart.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftChart.Location = new System.Drawing.Point(3, 3);
            this.panelLeftChart.Name = "panelLeftChart";
            this.panelLeftChart.Size = new System.Drawing.Size(0, 248);
            this.panelLeftChart.TabIndex = 17;
            // 
            // panelTopChart
            // 
            this.panelTopChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopChart.Location = new System.Drawing.Point(3, 3);
            this.panelTopChart.Name = "panelTopChart";
            this.panelTopChart.Size = new System.Drawing.Size(426, 0);
            this.panelTopChart.TabIndex = 16;
            // 
            // panelBottomChart
            // 
            this.panelBottomChart.Controls.Add(this.panelCenter);
            this.panelBottomChart.Controls.Add(this.panelItntervalRight);
            this.panelBottomChart.Controls.Add(this.panelLeft);
            this.panelBottomChart.Controls.Add(this.panelTopInterval);
            this.panelBottomChart.Controls.Add(this.panelBottom);
            this.panelBottomChart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomChart.Location = new System.Drawing.Point(3, 251);
            this.panelBottomChart.Name = "panelBottomChart";
            this.panelBottomChart.Size = new System.Drawing.Size(426, 25);
            this.panelBottomChart.TabIndex = 19;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.textBoxChartInterval);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(123, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(285, 25);
            this.panelCenter.TabIndex = 20;
            // 
            // textBoxChartInterval
            // 
            this.textBoxChartInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxChartInterval.Location = new System.Drawing.Point(0, 0);
            this.textBoxChartInterval.Name = "textBoxChartInterval";
            this.textBoxChartInterval.Size = new System.Drawing.Size(285, 20);
            this.textBoxChartInterval.TabIndex = 0;
            // 
            // panelItntervalRight
            // 
            this.panelItntervalRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelItntervalRight.Location = new System.Drawing.Point(408, 0);
            this.panelItntervalRight.Name = "panelItntervalRight";
            this.panelItntervalRight.Size = new System.Drawing.Size(18, 25);
            this.panelItntervalRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.label2);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(123, 25);
            this.panelLeft.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chart Interval, s";
            // 
            // panelTopInterval
            // 
            this.panelTopInterval.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopInterval.Location = new System.Drawing.Point(0, 0);
            this.panelTopInterval.Name = "panelTopInterval";
            this.panelTopInterval.Size = new System.Drawing.Size(426, 0);
            this.panelTopInterval.TabIndex = 16;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 25);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(426, 0);
            this.panelBottom.TabIndex = 19;
            // 
            // panelRightMain
            // 
            this.panelRightMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightMain.Location = new System.Drawing.Point(440, 0);
            this.panelRightMain.Name = "panelRightMain";
            this.panelRightMain.Size = new System.Drawing.Size(0, 305);
            this.panelRightMain.TabIndex = 18;
            // 
            // panelLeftMain
            // 
            this.panelLeftMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftMain.Location = new System.Drawing.Point(0, 0);
            this.panelLeftMain.Name = "panelLeftMain";
            this.panelLeftMain.Size = new System.Drawing.Size(0, 305);
            this.panelLeftMain.TabIndex = 17;
            // 
            // panelTopMain
            // 
            this.panelTopMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopMain.Location = new System.Drawing.Point(0, 0);
            this.panelTopMain.Name = "panelTopMain";
            this.panelTopMain.Size = new System.Drawing.Size(440, 0);
            this.panelTopMain.TabIndex = 16;
            // 
            // panelBottomMain
            // 
            this.panelBottomMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomMain.Location = new System.Drawing.Point(0, 305);
            this.panelBottomMain.Name = "panelBottomMain";
            this.panelBottomMain.Size = new System.Drawing.Size(440, 0);
            this.panelBottomMain.TabIndex = 19;
            // 
            // userControlRealtimeMeasurements
            // 
            this.userControlRealtimeMeasurements.Dock = System.Windows.Forms.DockStyle.Top;
            this.userControlRealtimeMeasurements.Location = new System.Drawing.Point(0, 0);
            this.userControlRealtimeMeasurements.Name = "userControlRealtimeMeasurements";
            this.userControlRealtimeMeasurements.Size = new System.Drawing.Size(170, 84);
            this.userControlRealtimeMeasurements.TabIndex = 0;
            // 
            // userControlRealtimeList
            // 
            this.userControlRealtimeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlRealtimeList.Location = new System.Drawing.Point(0, 0);
            this.userControlRealtimeList.Name = "userControlRealtimeList";
            this.userControlRealtimeList.Size = new System.Drawing.Size(248, 244);
            this.userControlRealtimeList.TabIndex = 0;
            // 
            // elementHost
            // 
            this.elementHost.BackColor = System.Drawing.Color.Black;
            this.elementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost.Location = new System.Drawing.Point(0, 0);
            this.elementHost.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.elementHost.Name = "elementHost";
            this.elementHost.Size = new System.Drawing.Size(426, 248);
            this.elementHost.TabIndex = 0;
            this.elementHost.Text = "elementHost";
            this.elementHost.Child = this.performer;
            // 
            // UserControlRealtime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenterMain);
            this.Controls.Add(this.panelRightMain);
            this.Controls.Add(this.panelLeftMain);
            this.Controls.Add(this.panelTopMain);
            this.Controls.Add(this.panelBottomMain);
            this.Name = "UserControlRealtime";
            this.Size = new System.Drawing.Size(440, 305);
            this.panelCenterMain.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageDigital.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelCenterSettings.ResumeLayout(false);
            this.panelCenterSettings.PerformLayout();
            this.panelTopS.ResumeLayout(false);
            this.panelTopSettings.ResumeLayout(false);
            this.panelCenterDigital.ResumeLayout(false);
            this.panelCenterList.ResumeLayout(false);
            this.panelTopDigital.ResumeLayout(false);
            this.panelTopDigital.PerformLayout();
            this.tabPageChart.ResumeLayout(false);
            this.panelCenterChart.ResumeLayout(false);
            this.panelChart.ResumeLayout(false);
            this.panelBottomChart.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Integration.ElementHost elementHost;
        private Wpf.UserControlWpfChart performer;
    }
}
