namespace DataPerformer.UI.UserControls
{
    partial class UserControlGraph
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
                base.Dispose(disposing);
                if (consumer != null)
                {
                    consumer.OnChangeInput -= FillMeasurements;
                    consumer = null;
                }
                if (indicatorWrapper != null)
                {
                    indicatorWrapper.Dispose();
                    indicatorWrapper = null;
                }
            }
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlGraph));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelDraw = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageGraph = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainerGraph = new System.Windows.Forms.SplitContainer();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.userControlRealtimeAnalysis = new DataPerformer.UI.UserControls.UserControlRealtimeAnalysis();
            this.panelMeaRight = new System.Windows.Forms.Panel();
            this.panelMeaBottom = new System.Windows.Forms.Panel();
            this.panelMea = new System.Windows.Forms.Panel();
            this.panelMeaLeft = new System.Windows.Forms.Panel();
            this.panelMeaTop = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBoxDirectoryIteration = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxStepCount = new System.Windows.Forms.ComboBox();
            this.comboBoxStep = new System.Windows.Forms.ComboBox();
            this.comboBoxStart = new System.Windows.Forms.ComboBox();
            this.calculatorBoxStep = new System.Windows.Forms.TextBox();
            this.calculatorBoxStart = new System.Windows.Forms.TextBox();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxStepCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxArg = new System.Windows.Forms.ComboBox();
            this.panelIntLeft = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.contextMenuStripTextTab = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelText = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panelTextBottom = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.comboBoxCond = new System.Windows.Forms.ComboBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.tabPageRealTime = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.userControlRealtime = new DataPerformer.UI.UserControls.UserControlRealtime();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.checkBoxAbsoluteTime = new System.Windows.Forms.CheckBox();
            this.userControlTimeType = new Diagram.UI.UserControls.UserControlTimeUnit();
            this.label9 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.tabPageStartStopRealtime = new System.Windows.Forms.TabPage();
            this.panel26 = new System.Windows.Forms.Panel();
            this.buttonStartStopRealtime = new System.Windows.Forms.Button();
            this.panel27 = new System.Windows.Forms.Panel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.panel29 = new System.Windows.Forms.Panel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.tabPageAnimation = new System.Windows.Forms.TabPage();
            this.panel19 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxAnimationScale = new System.Windows.Forms.TextBox();
            this.userControlTimeUnitAnimation = new Diagram.UI.UserControls.UserControlTimeUnit();
            this.numericUpDownPause = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.checkBoxSynchronous = new System.Windows.Forms.CheckBox();
            this.panel25 = new System.Windows.Forms.Panel();
            this.tabPageCadr = new System.Windows.Forms.TabPage();
            this.panel31 = new System.Windows.Forms.Panel();
            this.userControlCadr = new DataPerformer.UI.UserControls.Graph.UserControlCadr();
            this.panel32 = new System.Windows.Forms.Panel();
            this.panel33 = new System.Windows.Forms.Panel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.panel35 = new System.Windows.Forms.Panel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAnimation = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPause = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxPoints = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonSeries = new System.Windows.Forms.ToolStripComboBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerText = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showRuntimeIndicatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorkerReatimeAnalysis = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerTextRealtimeAnalysis = new System.ComponentModel.BackgroundWorker();
            this.panelCenter.SuspendLayout();
            this.panelDraw.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageGraph.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGraph)).BeginInit();
            this.splitContainerGraph.Panel1.SuspendLayout();
            this.splitContainerGraph.Panel2.SuspendLayout();
            this.splitContainerGraph.SuspendLayout();
            this.panelGraph.SuspendLayout();
            this.panelMeaTop.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPageText.SuspendLayout();
            this.contextMenuStripTextTab.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel12.SuspendLayout();
            this.tabPageRealTime.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panel17.SuspendLayout();
            this.tabPageStartStopRealtime.SuspendLayout();
            this.panel26.SuspendLayout();
            this.tabPageAnimation.SuspendLayout();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPause)).BeginInit();
            this.panel24.SuspendLayout();
            this.tabPageCadr.SuspendLayout();
            this.panel31.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.contextMenuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 490);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(635, 1);
            this.panelBottom.TabIndex = 9;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.panelDraw);
            this.panelCenter.Controls.Add(this.panelRight);
            this.panelCenter.Controls.Add(this.panelLeft);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(635, 491);
            this.panelCenter.TabIndex = 10;
            // 
            // panelDraw
            // 
            this.panelDraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDraw.Controls.Add(this.tabControlMain);
            this.panelDraw.Controls.Add(this.toolStripMain);
            this.panelDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDraw.Location = new System.Drawing.Point(1, 0);
            this.panelDraw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(633, 491);
            this.panelDraw.TabIndex = 3;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageGraph);
            this.tabControlMain.Controls.Add(this.tabPageText);
            this.tabControlMain.Controls.Add(this.tabPageRealTime);
            this.tabControlMain.Controls.Add(this.tabPageStartStopRealtime);
            this.tabControlMain.Controls.Add(this.tabPageAnimation);
            this.tabControlMain.Controls.Add(this.tabPageCadr);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 28);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(629, 459);
            this.tabControlMain.TabIndex = 31;
            // 
            // tabPageGraph
            // 
            this.tabPageGraph.Controls.Add(this.panel1);
            this.tabPageGraph.Controls.Add(this.panel2);
            this.tabPageGraph.Controls.Add(this.panel3);
            this.tabPageGraph.Controls.Add(this.panel5);
            this.tabPageGraph.Location = new System.Drawing.Point(4, 29);
            this.tabPageGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageGraph.Name = "tabPageGraph";
            this.tabPageGraph.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageGraph.Size = new System.Drawing.Size(621, 426);
            this.tabPageGraph.TabIndex = 0;
            this.tabPageGraph.Text = "Chart";
            this.tabPageGraph.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 1);
            this.panel1.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(4, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 416);
            this.panel2.TabIndex = 28;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainerGraph);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panelIntLeft);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 5);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(612, 416);
            this.panel3.TabIndex = 31;
            // 
            // splitContainerGraph
            // 
            this.splitContainerGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerGraph.Location = new System.Drawing.Point(1, 0);
            this.splitContainerGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainerGraph.Name = "splitContainerGraph";
            // 
            // splitContainerGraph.Panel1
            // 
            this.splitContainerGraph.Panel1.Controls.Add(this.panelGraph);
            // 
            // splitContainerGraph.Panel2
            // 
            this.splitContainerGraph.Panel2.Controls.Add(this.panelMeaRight);
            this.splitContainerGraph.Panel2.Controls.Add(this.panelMeaBottom);
            this.splitContainerGraph.Panel2.Controls.Add(this.panelMea);
            this.splitContainerGraph.Panel2.Controls.Add(this.panelMeaLeft);
            this.splitContainerGraph.Panel2.Controls.Add(this.panelMeaTop);
            this.splitContainerGraph.Size = new System.Drawing.Size(611, 291);
            this.splitContainerGraph.SplitterDistance = 359;
            this.splitContainerGraph.SplitterWidth = 5;
            this.splitContainerGraph.TabIndex = 28;
            // 
            // panelGraph
            // 
            this.panelGraph.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGraph.Controls.Add(this.userControlRealtimeAnalysis);
            this.panelGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraph.Location = new System.Drawing.Point(0, 0);
            this.panelGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(359, 291);
            this.panelGraph.TabIndex = 3;
            // 
            // userControlRealtimeAnalysis
            // 
            this.userControlRealtimeAnalysis.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.userControlRealtimeAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlRealtimeAnalysis.Location = new System.Drawing.Point(0, 0);
            this.userControlRealtimeAnalysis.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.userControlRealtimeAnalysis.Name = "userControlRealtimeAnalysis";
            this.userControlRealtimeAnalysis.Size = new System.Drawing.Size(357, 289);
            this.userControlRealtimeAnalysis.TabIndex = 0;
            this.userControlRealtimeAnalysis.Visible = false;
            // 
            // panelMeaRight
            // 
            this.panelMeaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMeaRight.Location = new System.Drawing.Point(246, 74);
            this.panelMeaRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelMeaRight.Name = "panelMeaRight";
            this.panelMeaRight.Size = new System.Drawing.Size(1, 216);
            this.panelMeaRight.TabIndex = 29;
            // 
            // panelMeaBottom
            // 
            this.panelMeaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMeaBottom.Location = new System.Drawing.Point(1, 290);
            this.panelMeaBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelMeaBottom.Name = "panelMeaBottom";
            this.panelMeaBottom.Size = new System.Drawing.Size(246, 1);
            this.panelMeaBottom.TabIndex = 30;
            // 
            // panelMea
            // 
            this.panelMea.AutoScroll = true;
            this.panelMea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMea.Location = new System.Drawing.Point(1, 74);
            this.panelMea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelMea.Name = "panelMea";
            this.panelMea.Size = new System.Drawing.Size(246, 217);
            this.panelMea.TabIndex = 26;
            this.panelMea.Resize += new System.EventHandler(this.panelMea_Resize);
            // 
            // panelMeaLeft
            // 
            this.panelMeaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMeaLeft.Location = new System.Drawing.Point(0, 74);
            this.panelMeaLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelMeaLeft.Name = "panelMeaLeft";
            this.panelMeaLeft.Size = new System.Drawing.Size(1, 217);
            this.panelMeaLeft.TabIndex = 28;
            // 
            // panelMeaTop
            // 
            this.panelMeaTop.Controls.Add(this.label5);
            this.panelMeaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMeaTop.Location = new System.Drawing.Point(0, 0);
            this.panelMeaTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelMeaTop.Name = "panelMeaTop";
            this.panelMeaTop.Size = new System.Drawing.Size(247, 74);
            this.panelMeaTop.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 49);
            this.label5.TabIndex = 21;
            this.label5.Text = "Data sources";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkBoxDirectoryIteration);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.comboBoxStepCount);
            this.panel4.Controls.Add(this.comboBoxStep);
            this.panel4.Controls.Add(this.comboBoxStart);
            this.panel4.Controls.Add(this.calculatorBoxStep);
            this.panel4.Controls.Add(this.calculatorBoxStart);
            this.panel4.Controls.Add(this.labelY);
            this.panel4.Controls.Add(this.labelX);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.textBoxStepCount);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.comboBoxArg);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(1, 291);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(611, 125);
            this.panel4.TabIndex = 27;
            // 
            // checkBoxDirectoryIteration
            // 
            this.checkBoxDirectoryIteration.AutoSize = true;
            this.checkBoxDirectoryIteration.Location = new System.Drawing.Point(12, 89);
            this.checkBoxDirectoryIteration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxDirectoryIteration.Name = "checkBoxDirectoryIteration";
            this.checkBoxDirectoryIteration.Size = new System.Drawing.Size(92, 24);
            this.checkBoxDirectoryIteration.TabIndex = 37;
            this.checkBoxDirectoryIteration.Text = "Directory";
            this.checkBoxDirectoryIteration.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(472, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Step count";
            // 
            // comboBoxStepCount
            // 
            this.comboBoxStepCount.FormattingEnabled = true;
            this.comboBoxStepCount.Location = new System.Drawing.Point(476, 86);
            this.comboBoxStepCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxStepCount.Name = "comboBoxStepCount";
            this.comboBoxStepCount.Size = new System.Drawing.Size(120, 28);
            this.comboBoxStepCount.TabIndex = 35;
            // 
            // comboBoxStep
            // 
            this.comboBoxStep.FormattingEnabled = true;
            this.comboBoxStep.Location = new System.Drawing.Point(329, 86);
            this.comboBoxStep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxStep.Name = "comboBoxStep";
            this.comboBoxStep.Size = new System.Drawing.Size(137, 28);
            this.comboBoxStep.TabIndex = 34;
            // 
            // comboBoxStart
            // 
            this.comboBoxStart.FormattingEnabled = true;
            this.comboBoxStart.Location = new System.Drawing.Point(181, 88);
            this.comboBoxStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxStart.Name = "comboBoxStart";
            this.comboBoxStart.Size = new System.Drawing.Size(137, 28);
            this.comboBoxStart.TabIndex = 33;
            // 
            // calculatorBoxStep
            // 
            this.calculatorBoxStep.Location = new System.Drawing.Point(329, 54);
            this.calculatorBoxStep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calculatorBoxStep.Name = "calculatorBoxStep";
            this.calculatorBoxStep.Size = new System.Drawing.Size(139, 27);
            this.calculatorBoxStep.TabIndex = 32;
            this.calculatorBoxStep.Text = "0";
            // 
            // calculatorBoxStart
            // 
            this.calculatorBoxStart.Location = new System.Drawing.Point(181, 54);
            this.calculatorBoxStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calculatorBoxStart.Name = "calculatorBoxStart";
            this.calculatorBoxStart.Size = new System.Drawing.Size(139, 27);
            this.calculatorBoxStart.TabIndex = 31;
            this.calculatorBoxStart.Text = "0";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(216, 5);
            this.labelY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(35, 20);
            this.labelY.TabIndex = 30;
            this.labelY.Text = "Y = ";
            this.labelY.Visible = false;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(11, 5);
            this.labelX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(36, 20);
            this.labelX.TabIndex = 29;
            this.labelX.Text = "X = ";
            this.labelX.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(201, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 35);
            this.label4.TabIndex = 27;
            this.label4.Text = "Start";
            // 
            // textBoxStepCount
            // 
            this.textBoxStepCount.Location = new System.Drawing.Point(476, 54);
            this.textBoxStepCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxStepCount.Name = "textBoxStepCount";
            this.textBoxStepCount.Size = new System.Drawing.Size(120, 27);
            this.textBoxStepCount.TabIndex = 23;
            this.textBoxStepCount.Text = "2";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(465, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 34);
            this.label3.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 22);
            this.label1.TabIndex = 20;
            this.label1.Text = "Argument";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(321, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 35);
            this.label2.TabIndex = 22;
            this.label2.Text = "Step";
            // 
            // comboBoxArg
            // 
            this.comboBoxArg.FormattingEnabled = true;
            this.comboBoxArg.ItemHeight = 20;
            this.comboBoxArg.Location = new System.Drawing.Point(12, 54);
            this.comboBoxArg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxArg.Name = "comboBoxArg";
            this.comboBoxArg.Size = new System.Drawing.Size(160, 28);
            this.comboBoxArg.TabIndex = 19;
            this.comboBoxArg.Text = "Time";
            // 
            // panelIntLeft
            // 
            this.panelIntLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIntLeft.Location = new System.Drawing.Point(0, 0);
            this.panelIntLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelIntLeft.Name = "panelIntLeft";
            this.panelIntLeft.Size = new System.Drawing.Size(1, 416);
            this.panelIntLeft.TabIndex = 26;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(616, 5);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 416);
            this.panel5.TabIndex = 30;
            // 
            // tabPageText
            // 
            this.tabPageText.ContextMenuStrip = this.contextMenuStripTextTab;
            this.tabPageText.Controls.Add(this.panelText);
            this.tabPageText.Controls.Add(this.panel9);
            this.tabPageText.Controls.Add(this.panel7);
            this.tabPageText.Controls.Add(this.panelTextBottom);
            this.tabPageText.Controls.Add(this.panel8);
            this.tabPageText.Location = new System.Drawing.Point(4, 29);
            this.tabPageText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageText.Size = new System.Drawing.Size(621, 426);
            this.tabPageText.TabIndex = 1;
            this.tabPageText.Text = "Text";
            this.tabPageText.UseVisualStyleBackColor = true;
            // 
            // contextMenuStripTextTab
            // 
            this.contextMenuStripTextTab.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripTextTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveXmlToolStripMenuItem});
            this.contextMenuStripTextTab.Name = "contextMenuStripTextTab";
            this.contextMenuStripTextTab.Size = new System.Drawing.Size(140, 28);
            // 
            // saveXmlToolStripMenuItem
            // 
            this.saveXmlToolStripMenuItem.Name = "saveXmlToolStripMenuItem";
            this.saveXmlToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.saveXmlToolStripMenuItem.Text = "Save Xml";
            this.saveXmlToolStripMenuItem.Click += new System.EventHandler(this.saveXmlToolStripMenuItem_Click);
            // 
            // panelText
            // 
            this.panelText.AutoScroll = true;
            this.panelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelText.Location = new System.Drawing.Point(5, 59);
            this.panelText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelText.Name = "panelText";
            this.panelText.Size = new System.Drawing.Size(611, 362);
            this.panelText.TabIndex = 11;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(616, 59);
            this.panel9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1, 362);
            this.panel9.TabIndex = 10;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(4, 59);
            this.panel7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1, 362);
            this.panel7.TabIndex = 9;
            // 
            // panelTextBottom
            // 
            this.panelTextBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTextBottom.Location = new System.Drawing.Point(4, 421);
            this.panelTextBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTextBottom.Name = "panelTextBottom";
            this.panelTextBottom.Size = new System.Drawing.Size(613, 0);
            this.panelTextBottom.TabIndex = 8;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Controls.Add(this.panel11);
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Controls.Add(this.panel14);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(4, 5);
            this.panel8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(613, 54);
            this.panel8.TabIndex = 6;
            // 
            // panel10
            // 
            this.panel10.ContextMenuStrip = this.contextMenuStripTextTab;
            this.panel10.Controls.Add(this.comboBoxCond);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(191, 8);
            this.panel10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(409, 46);
            this.panel10.TabIndex = 23;
            // 
            // comboBoxCond
            // 
            this.comboBoxCond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxCond.FormattingEnabled = true;
            this.comboBoxCond.Location = new System.Drawing.Point(0, 0);
            this.comboBoxCond.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxCond.Name = "comboBoxCond";
            this.comboBoxCond.Size = new System.Drawing.Size(409, 28);
            this.comboBoxCond.TabIndex = 0;
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(600, 8);
            this.panel11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(13, 46);
            this.panel11.TabIndex = 22;
            // 
            // panel12
            // 
            this.panel12.ContextMenuStrip = this.contextMenuStripTextTab;
            this.panel12.Controls.Add(this.label7);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 8);
            this.panel12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(191, 46);
            this.panel12.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ContextMenuStrip = this.contextMenuStripTextTab;
            this.label7.Location = new System.Drawing.Point(19, 8);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Output condition";
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(613, 8);
            this.panel14.TabIndex = 20;
            // 
            // tabPageRealTime
            // 
            this.tabPageRealTime.Controls.Add(this.panel6);
            this.tabPageRealTime.Controls.Add(this.panel13);
            this.tabPageRealTime.Controls.Add(this.panel15);
            this.tabPageRealTime.Controls.Add(this.panelTop);
            this.tabPageRealTime.Controls.Add(this.panel16);
            this.tabPageRealTime.Location = new System.Drawing.Point(4, 29);
            this.tabPageRealTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageRealTime.Name = "tabPageRealTime";
            this.tabPageRealTime.Size = new System.Drawing.Size(621, 426);
            this.tabPageRealTime.TabIndex = 2;
            this.tabPageRealTime.Text = "Realtime";
            this.tabPageRealTime.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.userControlRealtime);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 42);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(621, 384);
            this.panel6.TabIndex = 20;
            // 
            // userControlRealtime
            // 
            this.userControlRealtime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlRealtime.Location = new System.Drawing.Point(0, 0);
            this.userControlRealtime.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.userControlRealtime.Name = "userControlRealtime";
            this.userControlRealtime.Size = new System.Drawing.Size(621, 384);
            this.userControlRealtime.TabIndex = 0;
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel13.Location = new System.Drawing.Point(621, 42);
            this.panel13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(0, 384);
            this.panel13.TabIndex = 18;
            // 
            // panel15
            // 
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(0, 42);
            this.panel15.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(0, 384);
            this.panel15.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panel17);
            this.panelTop.Controls.Add(this.panel18);
            this.panelTop.Controls.Add(this.panel20);
            this.panelTop.Controls.Add(this.panel21);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(621, 42);
            this.panelTop.TabIndex = 16;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.checkBoxAbsoluteTime);
            this.panel17.Controls.Add(this.userControlTimeType);
            this.panel17.Controls.Add(this.label9);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(621, 42);
            this.panel17.TabIndex = 20;
            // 
            // checkBoxAbsoluteTime
            // 
            this.checkBoxAbsoluteTime.AutoSize = true;
            this.checkBoxAbsoluteTime.Location = new System.Drawing.Point(417, 8);
            this.checkBoxAbsoluteTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxAbsoluteTime.Name = "checkBoxAbsoluteTime";
            this.checkBoxAbsoluteTime.Size = new System.Drawing.Size(124, 24);
            this.checkBoxAbsoluteTime.TabIndex = 2;
            this.checkBoxAbsoluteTime.Text = "Absolute time";
            this.checkBoxAbsoluteTime.UseVisualStyleBackColor = true;
            this.checkBoxAbsoluteTime.CheckedChanged += new System.EventHandler(this.checkBoxAbsoluteTime_CheckedChanged);
            // 
            // userControlTimeType
            // 
            this.userControlTimeType.Location = new System.Drawing.Point(175, 5);
            this.userControlTimeType.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.userControlTimeType.Name = "userControlTimeType";
            this.userControlTimeType.Size = new System.Drawing.Size(165, 35);
            this.userControlTimeType.TabIndex = 1;
            this.userControlTimeType.TimeUnit = BaseTypes.Attributes.TimeType.Second;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 6);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Time unit";
            // 
            // panel18
            // 
            this.panel18.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel18.Location = new System.Drawing.Point(621, 0);
            this.panel18.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(0, 42);
            this.panel18.TabIndex = 18;
            // 
            // panel20
            // 
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(0, 0);
            this.panel20.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(621, 0);
            this.panel20.TabIndex = 16;
            // 
            // panel21
            // 
            this.panel21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel21.Location = new System.Drawing.Point(0, 42);
            this.panel21.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(621, 0);
            this.panel21.TabIndex = 19;
            // 
            // panel16
            // 
            this.panel16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel16.Location = new System.Drawing.Point(0, 426);
            this.panel16.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(621, 0);
            this.panel16.TabIndex = 19;
            // 
            // tabPageStartStopRealtime
            // 
            this.tabPageStartStopRealtime.Controls.Add(this.panel26);
            this.tabPageStartStopRealtime.Controls.Add(this.panel27);
            this.tabPageStartStopRealtime.Controls.Add(this.panel28);
            this.tabPageStartStopRealtime.Controls.Add(this.panel29);
            this.tabPageStartStopRealtime.Controls.Add(this.panel30);
            this.tabPageStartStopRealtime.Location = new System.Drawing.Point(4, 29);
            this.tabPageStartStopRealtime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageStartStopRealtime.Name = "tabPageStartStopRealtime";
            this.tabPageStartStopRealtime.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageStartStopRealtime.Size = new System.Drawing.Size(621, 426);
            this.tabPageStartStopRealtime.TabIndex = 4;
            this.tabPageStartStopRealtime.Text = "Control";
            this.tabPageStartStopRealtime.UseVisualStyleBackColor = true;
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.buttonStartStopRealtime);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel26.Location = new System.Drawing.Point(4, 5);
            this.panel26.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(613, 416);
            this.panel26.TabIndex = 20;
            // 
            // buttonStartStopRealtime
            // 
            this.buttonStartStopRealtime.BackColor = System.Drawing.Color.Green;
            this.buttonStartStopRealtime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStartStopRealtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonStartStopRealtime.Location = new System.Drawing.Point(0, 0);
            this.buttonStartStopRealtime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStartStopRealtime.Name = "buttonStartStopRealtime";
            this.buttonStartStopRealtime.Size = new System.Drawing.Size(613, 416);
            this.buttonStartStopRealtime.TabIndex = 0;
            this.buttonStartStopRealtime.Text = "Start";
            this.buttonStartStopRealtime.UseVisualStyleBackColor = false;
            this.buttonStartStopRealtime.Click += new System.EventHandler(this.buttonStartStopRealtime_Click);
            // 
            // panel27
            // 
            this.panel27.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel27.Location = new System.Drawing.Point(617, 5);
            this.panel27.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(0, 416);
            this.panel27.TabIndex = 18;
            // 
            // panel28
            // 
            this.panel28.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel28.Location = new System.Drawing.Point(4, 5);
            this.panel28.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(0, 416);
            this.panel28.TabIndex = 17;
            // 
            // panel29
            // 
            this.panel29.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel29.Location = new System.Drawing.Point(4, 5);
            this.panel29.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(613, 0);
            this.panel29.TabIndex = 16;
            // 
            // panel30
            // 
            this.panel30.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel30.Location = new System.Drawing.Point(4, 421);
            this.panel30.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(613, 0);
            this.panel30.TabIndex = 19;
            // 
            // tabPageAnimation
            // 
            this.tabPageAnimation.Controls.Add(this.panel19);
            this.tabPageAnimation.Controls.Add(this.panel22);
            this.tabPageAnimation.Controls.Add(this.panel23);
            this.tabPageAnimation.Controls.Add(this.panel24);
            this.tabPageAnimation.Controls.Add(this.panel25);
            this.tabPageAnimation.Location = new System.Drawing.Point(4, 29);
            this.tabPageAnimation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageAnimation.Name = "tabPageAnimation";
            this.tabPageAnimation.Size = new System.Drawing.Size(621, 426);
            this.tabPageAnimation.TabIndex = 3;
            this.tabPageAnimation.Text = "Animation";
            this.tabPageAnimation.UseVisualStyleBackColor = true;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.label10);
            this.panel19.Controls.Add(this.textBoxAnimationScale);
            this.panel19.Controls.Add(this.userControlTimeUnitAnimation);
            this.panel19.Controls.Add(this.numericUpDownPause);
            this.panel19.Controls.Add(this.label8);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel19.Location = new System.Drawing.Point(0, 41);
            this.panel19.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(621, 385);
            this.panel19.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 60);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 20);
            this.label10.TabIndex = 43;
            this.label10.Text = "Animation time scale";
            // 
            // textBoxAnimationScale
            // 
            this.textBoxAnimationScale.Location = new System.Drawing.Point(372, 51);
            this.textBoxAnimationScale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxAnimationScale.Name = "textBoxAnimationScale";
            this.textBoxAnimationScale.Size = new System.Drawing.Size(199, 27);
            this.textBoxAnimationScale.TabIndex = 42;
            // 
            // userControlTimeUnitAnimation
            // 
            this.userControlTimeUnitAnimation.Location = new System.Drawing.Point(372, 5);
            this.userControlTimeUnitAnimation.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.userControlTimeUnitAnimation.Name = "userControlTimeUnitAnimation";
            this.userControlTimeUnitAnimation.Size = new System.Drawing.Size(200, 35);
            this.userControlTimeUnitAnimation.TabIndex = 41;
            this.userControlTimeUnitAnimation.TimeUnit = BaseTypes.Attributes.TimeType.Second;
            // 
            // numericUpDownPause
            // 
            this.numericUpDownPause.Location = new System.Drawing.Point(116, 9);
            this.numericUpDownPause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownPause.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownPause.Name = "numericUpDownPause";
            this.numericUpDownPause.Size = new System.Drawing.Size(77, 27);
            this.numericUpDownPause.TabIndex = 40;
            this.numericUpDownPause.ValueChanged += new System.EventHandler(this.numericUpDownPause_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 14);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 20);
            this.label8.TabIndex = 39;
            this.label8.Text = "Pause";
            // 
            // panel22
            // 
            this.panel22.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel22.Location = new System.Drawing.Point(621, 41);
            this.panel22.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(0, 385);
            this.panel22.TabIndex = 18;
            // 
            // panel23
            // 
            this.panel23.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel23.Location = new System.Drawing.Point(0, 41);
            this.panel23.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(0, 385);
            this.panel23.TabIndex = 17;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.checkBoxSynchronous);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(0, 0);
            this.panel24.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(621, 41);
            this.panel24.TabIndex = 16;
            // 
            // checkBoxSynchronous
            // 
            this.checkBoxSynchronous.AutoSize = true;
            this.checkBoxSynchronous.Location = new System.Drawing.Point(21, 6);
            this.checkBoxSynchronous.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxSynchronous.Name = "checkBoxSynchronous";
            this.checkBoxSynchronous.Size = new System.Drawing.Size(114, 24);
            this.checkBoxSynchronous.TabIndex = 0;
            this.checkBoxSynchronous.Text = "Synchronous";
            this.checkBoxSynchronous.UseVisualStyleBackColor = true;
            this.checkBoxSynchronous.CheckedChanged += new System.EventHandler(this.checkBoxSynchronous_CheckedChanged);
            // 
            // panel25
            // 
            this.panel25.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel25.Location = new System.Drawing.Point(0, 426);
            this.panel25.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(621, 0);
            this.panel25.TabIndex = 19;
            // 
            // tabPageCadr
            // 
            this.tabPageCadr.Controls.Add(this.panel31);
            this.tabPageCadr.Controls.Add(this.panel32);
            this.tabPageCadr.Controls.Add(this.panel33);
            this.tabPageCadr.Controls.Add(this.panel34);
            this.tabPageCadr.Controls.Add(this.panel35);
            this.tabPageCadr.Location = new System.Drawing.Point(4, 29);
            this.tabPageCadr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageCadr.Name = "tabPageCadr";
            this.tabPageCadr.Size = new System.Drawing.Size(621, 426);
            this.tabPageCadr.TabIndex = 5;
            this.tabPageCadr.Text = "Cadr";
            this.tabPageCadr.UseVisualStyleBackColor = true;
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.userControlCadr);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel31.Location = new System.Drawing.Point(0, 0);
            this.panel31.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(621, 426);
            this.panel31.TabIndex = 20;
            // 
            // userControlCadr
            // 
            this.userControlCadr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlCadr.Location = new System.Drawing.Point(0, 0);
            this.userControlCadr.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.userControlCadr.Name = "userControlCadr";
            this.userControlCadr.Size = new System.Drawing.Size(621, 426);
            this.userControlCadr.TabIndex = 0;
            // 
            // panel32
            // 
            this.panel32.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel32.Location = new System.Drawing.Point(621, 0);
            this.panel32.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(0, 426);
            this.panel32.TabIndex = 18;
            // 
            // panel33
            // 
            this.panel33.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel33.Location = new System.Drawing.Point(0, 0);
            this.panel33.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(0, 426);
            this.panel33.TabIndex = 17;
            // 
            // panel34
            // 
            this.panel34.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel34.Location = new System.Drawing.Point(0, 0);
            this.panel34.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(621, 0);
            this.panel34.TabIndex = 16;
            // 
            // panel35
            // 
            this.panel35.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel35.Location = new System.Drawing.Point(0, 426);
            this.panel35.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(621, 0);
            this.panel35.TabIndex = 19;
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStart,
            this.toolStripButtonAnimation,
            this.toolStripButtonPause,
            this.toolStripButtonStop,
            this.toolStripComboBoxPoints,
            this.toolStripButtonAdd,
            this.toolStripButtonClearAll,
            this.toolStripButtonType,
            this.toolStripButtonSeries});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(629, 28);
            this.toolStripMain.TabIndex = 30;
            this.toolStripMain.Text = "Main";
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStart.Image")));
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonStart.Text = "Start";
            this.toolStripButtonStart.Click += new System.EventHandler(this.toolStripButtonStart_Click);
            // 
            // toolStripButtonAnimation
            // 
            this.toolStripButtonAnimation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAnimation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAnimation.Image")));
            this.toolStripButtonAnimation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAnimation.Name = "toolStripButtonAnimation";
            this.toolStripButtonAnimation.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonAnimation.Text = "Animation";
            this.toolStripButtonAnimation.Visible = false;
            this.toolStripButtonAnimation.Click += new System.EventHandler(this.toolStripButtonAnimation_Click);
            // 
            // toolStripButtonPause
            // 
            this.toolStripButtonPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPause.Enabled = false;
            this.toolStripButtonPause.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPause.Image")));
            this.toolStripButtonPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPause.Name = "toolStripButtonPause";
            this.toolStripButtonPause.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonPause.Text = "Pause";
            this.toolStripButtonPause.Click += new System.EventHandler(this.toolStripButtonPause_Click);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStop.Enabled = false;
            this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonStop.Text = "Stop";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // toolStripComboBoxPoints
            // 
            this.toolStripComboBoxPoints.Name = "toolStripComboBoxPoints";
            this.toolStripComboBoxPoints.Size = new System.Drawing.Size(160, 28);
            this.toolStripComboBoxPoints.Text = "<Points>";
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdd.Image")));
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonAdd.Text = "Add";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonClearAll
            // 
            this.toolStripButtonClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClearAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClearAll.Image")));
            this.toolStripButtonClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClearAll.Name = "toolStripButtonClearAll";
            this.toolStripButtonClearAll.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonClearAll.Text = "Clear all";
            // 
            // toolStripButtonType
            // 
            this.toolStripButtonType.Name = "toolStripButtonType";
            this.toolStripButtonType.Size = new System.Drawing.Size(160, 28);
            this.toolStripButtonType.Text = "<Series type>";
            // 
            // toolStripButtonSeries
            // 
            this.toolStripButtonSeries.Name = "toolStripButtonSeries";
            this.toolStripButtonSeries.Size = new System.Drawing.Size(75, 28);
            this.toolStripButtonSeries.Text = "<Series>";
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(634, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1, 491);
            this.panelRight.TabIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(1, 491);
            this.panelLeft.TabIndex = 1;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // backgroundWorkerText
            // 
            this.backgroundWorkerText.WorkerSupportsCancellation = true;
            this.backgroundWorkerText.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerText_DoWork);
            this.backgroundWorkerText.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerText_RunWorkerCompleted);
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showRuntimeIndicatorsToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(239, 28);
            // 
            // showRuntimeIndicatorsToolStripMenuItem
            // 
            this.showRuntimeIndicatorsToolStripMenuItem.Name = "showRuntimeIndicatorsToolStripMenuItem";
            this.showRuntimeIndicatorsToolStripMenuItem.Size = new System.Drawing.Size(238, 24);
            this.showRuntimeIndicatorsToolStripMenuItem.Text = "Show runtime indicators";
            this.showRuntimeIndicatorsToolStripMenuItem.Click += new System.EventHandler(this.showRuntimeIndicatorsToolStripMenuItem_Click);
            // 
            // backgroundWorkerReatimeAnalysis
            // 
            this.backgroundWorkerReatimeAnalysis.WorkerSupportsCancellation = true;
            this.backgroundWorkerReatimeAnalysis.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReatimeAnalysis_DoWork);
            this.backgroundWorkerReatimeAnalysis.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReatimeAnalysis_RunWorkerCompleted);
            // 
            // backgroundWorkerTextRealtimeAnalysis
            // 
            this.backgroundWorkerTextRealtimeAnalysis.WorkerSupportsCancellation = true;
            this.backgroundWorkerTextRealtimeAnalysis.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTextRealtimeAnalysis_DoWork);
            this.backgroundWorkerTextRealtimeAnalysis.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTextRealtimeAnalysis_RunWorkerCompleted);
            // 
            // UserControlGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ContextMenuStrip = this.contextMenuStripMain;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelCenter);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserControlGraph";
            this.Size = new System.Drawing.Size(635, 491);
            this.panelCenter.ResumeLayout(false);
            this.panelDraw.ResumeLayout(false);
            this.panelDraw.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageGraph.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainerGraph.Panel1.ResumeLayout(false);
            this.splitContainerGraph.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGraph)).EndInit();
            this.splitContainerGraph.ResumeLayout(false);
            this.panelGraph.ResumeLayout(false);
            this.panelMeaTop.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPageText.ResumeLayout(false);
            this.contextMenuStripTextTab.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.tabPageRealTime.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.tabPageStartStopRealtime.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.tabPageAnimation.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPause)).EndInit();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.tabPageCadr.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.contextMenuStripMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelDraw;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageGraph;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainerGraph;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.Panel panelMeaRight;
        private System.Windows.Forms.Panel panelMeaBottom;
        private System.Windows.Forms.Panel panelMea;
        private System.Windows.Forms.Panel panelMeaLeft;
        private System.Windows.Forms.Panel panelMeaTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxStepCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxArg;
        private System.Windows.Forms.Panel panelIntLeft;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TabPage tabPageText;
        private System.Windows.Forms.Panel panelTextBottom;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearAll;
        private System.Windows.Forms.ToolStripComboBox toolStripButtonType;
        private System.Windows.Forms.ToolStripComboBox toolStripButtonSeries;
        private System.Windows.Forms.Panel panelText;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.TextBox calculatorBoxStep;
        private System.Windows.Forms.TextBox calculatorBoxStart;
        private System.Windows.Forms.ComboBox comboBoxStepCount;
        private System.Windows.Forms.ComboBox comboBoxStep;
        private System.Windows.Forms.ComboBox comboBoxStart;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.ComboBox comboBoxCond;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.ComponentModel.BackgroundWorker backgroundWorkerText;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxPoints;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnimation;
        private System.Windows.Forms.ToolStripButton toolStripButtonPause;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTextTab;
        private System.Windows.Forms.ToolStripMenuItem saveXmlToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageRealTime;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.CheckBox checkBoxAbsoluteTime;
        private Diagram.UI.UserControls.UserControlTimeUnit userControlTimeType;
        private System.Windows.Forms.Label label9;
        private UserControlRealtime userControlRealtime;
        private System.Windows.Forms.TabPage tabPageAnimation;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.CheckBox checkBoxSynchronous;
        private System.Windows.Forms.Panel panel25;
        private Diagram.UI.UserControls.UserControlTimeUnit userControlTimeUnitAnimation;
        private System.Windows.Forms.NumericUpDown numericUpDownPause;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxAnimationScale;
        private System.Windows.Forms.TabPage tabPageStartStopRealtime;
        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.Button buttonStartStopRealtime;
        private UserControlRealtimeAnalysis userControlRealtimeAnalysis;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem showRuntimeIndicatorsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReatimeAnalysis;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTextRealtimeAnalysis;
        private System.Windows.Forms.TabPage tabPageCadr;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.Panel panel33;
        private System.Windows.Forms.Panel panel34;
        private System.Windows.Forms.Panel panel35;
        private Graph.UserControlCadr userControlCadr;
        private System.Windows.Forms.CheckBox checkBoxDirectoryIteration;
    }
}
