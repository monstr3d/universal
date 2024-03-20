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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlGraph));
            panelBottom = new System.Windows.Forms.Panel();
            panelCenter = new System.Windows.Forms.Panel();
            panelDraw = new System.Windows.Forms.Panel();
            tabControlMain = new System.Windows.Forms.TabControl();
            tabPageGraph = new System.Windows.Forms.TabPage();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            splitContainerGraph = new System.Windows.Forms.SplitContainer();
            panelGraph = new System.Windows.Forms.Panel();
            userControlRealtimeAnalysis = new UserControlRealtimeAnalysis();
            panelMeaRight = new System.Windows.Forms.Panel();
            panelMeaBottom = new System.Windows.Forms.Panel();
            panelMea = new System.Windows.Forms.Panel();
            panelMeaLeft = new System.Windows.Forms.Panel();
            panelMeaTop = new System.Windows.Forms.Panel();
            label5 = new System.Windows.Forms.Label();
            panel4 = new System.Windows.Forms.Panel();
            checkBoxIterator = new System.Windows.Forms.CheckBox();
            checkBoxDirectoryIteration = new System.Windows.Forms.CheckBox();
            label6 = new System.Windows.Forms.Label();
            comboBoxStepCount = new System.Windows.Forms.ComboBox();
            comboBoxStep = new System.Windows.Forms.ComboBox();
            comboBoxStart = new System.Windows.Forms.ComboBox();
            calculatorBoxStep = new System.Windows.Forms.TextBox();
            calculatorBoxStart = new System.Windows.Forms.TextBox();
            labelY = new System.Windows.Forms.Label();
            labelX = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            numericUpDownStepCount = new System.Windows.Forms.NumericUpDown();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            comboBoxArg = new System.Windows.Forms.ComboBox();
            panelIntLeft = new System.Windows.Forms.Panel();
            panel5 = new System.Windows.Forms.Panel();
            tabPageText = new System.Windows.Forms.TabPage();
            contextMenuStripTextTab = new System.Windows.Forms.ContextMenuStrip(components);
            saveXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panelText = new System.Windows.Forms.Panel();
            panel9 = new System.Windows.Forms.Panel();
            panel7 = new System.Windows.Forms.Panel();
            panelTextBottom = new System.Windows.Forms.Panel();
            panel8 = new System.Windows.Forms.Panel();
            panel10 = new System.Windows.Forms.Panel();
            comboBoxCond = new System.Windows.Forms.ComboBox();
            panel11 = new System.Windows.Forms.Panel();
            panel12 = new System.Windows.Forms.Panel();
            label7 = new System.Windows.Forms.Label();
            panel14 = new System.Windows.Forms.Panel();
            tabPageRealTime = new System.Windows.Forms.TabPage();
            panel6 = new System.Windows.Forms.Panel();
            userControlRealtime = new UserControlRealtime();
            panel13 = new System.Windows.Forms.Panel();
            panel15 = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            panel17 = new System.Windows.Forms.Panel();
            checkBoxAbsoluteTime = new System.Windows.Forms.CheckBox();
            userControlTimeType = new Diagram.UI.UserControls.UserControlTimeUnit();
            label9 = new System.Windows.Forms.Label();
            panel18 = new System.Windows.Forms.Panel();
            panel20 = new System.Windows.Forms.Panel();
            panel21 = new System.Windows.Forms.Panel();
            panel16 = new System.Windows.Forms.Panel();
            tabPageStartStopRealtime = new System.Windows.Forms.TabPage();
            panel26 = new System.Windows.Forms.Panel();
            buttonStartStopRealtime = new System.Windows.Forms.Button();
            panel27 = new System.Windows.Forms.Panel();
            panel28 = new System.Windows.Forms.Panel();
            panel29 = new System.Windows.Forms.Panel();
            panel30 = new System.Windows.Forms.Panel();
            tabPageAnimation = new System.Windows.Forms.TabPage();
            panel19 = new System.Windows.Forms.Panel();
            label10 = new System.Windows.Forms.Label();
            textBoxAnimationScale = new System.Windows.Forms.TextBox();
            userControlTimeUnitAnimation = new Diagram.UI.UserControls.UserControlTimeUnit();
            numericUpDownPause = new System.Windows.Forms.NumericUpDown();
            label8 = new System.Windows.Forms.Label();
            panel22 = new System.Windows.Forms.Panel();
            panel23 = new System.Windows.Forms.Panel();
            panel24 = new System.Windows.Forms.Panel();
            checkBoxSynchronous = new System.Windows.Forms.CheckBox();
            panel25 = new System.Windows.Forms.Panel();
            tabPageCadr = new System.Windows.Forms.TabPage();
            panel31 = new System.Windows.Forms.Panel();
            userControlCadr = new Graph.UserControlCadr();
            panel32 = new System.Windows.Forms.Panel();
            panel33 = new System.Windows.Forms.Panel();
            panel34 = new System.Windows.Forms.Panel();
            panel35 = new System.Windows.Forms.Panel();
            toolStripMain = new System.Windows.Forms.ToolStrip();
            toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            toolStripButtonAnimation = new System.Windows.Forms.ToolStripButton();
            toolStripButtonPause = new System.Windows.Forms.ToolStripButton();
            toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            toolStripComboBoxPoints = new System.Windows.Forms.ToolStripComboBox();
            toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            toolStripButtonClearAll = new System.Windows.Forms.ToolStripButton();
            toolStripButtonType = new System.Windows.Forms.ToolStripComboBox();
            toolStripButtonSeries = new System.Windows.Forms.ToolStripComboBox();
            panelRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(components);
            showRuntimeIndicatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            backgroundWorkerReatimeAnalysis = new System.ComponentModel.BackgroundWorker();
            backgroundWorkerTextRealtimeAnalysis = new System.ComponentModel.BackgroundWorker();
            panelCenter.SuspendLayout();
            panelDraw.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPageGraph.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerGraph).BeginInit();
            splitContainerGraph.Panel1.SuspendLayout();
            splitContainerGraph.Panel2.SuspendLayout();
            splitContainerGraph.SuspendLayout();
            panelGraph.SuspendLayout();
            panelMeaTop.SuspendLayout();
            panel4.SuspendLayout();
            tabPageText.SuspendLayout();
            contextMenuStripTextTab.SuspendLayout();
            panel8.SuspendLayout();
            panel10.SuspendLayout();
            panel12.SuspendLayout();
            tabPageRealTime.SuspendLayout();
            panel6.SuspendLayout();
            panelTop.SuspendLayout();
            panel17.SuspendLayout();
            tabPageStartStopRealtime.SuspendLayout();
            panel26.SuspendLayout();
            tabPageAnimation.SuspendLayout();
            panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPause).BeginInit();
            panel24.SuspendLayout();
            tabPageCadr.SuspendLayout();
            panel31.SuspendLayout();
            toolStripMain.SuspendLayout();
            contextMenuStripMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 369);
            panelBottom.Margin = new System.Windows.Forms.Padding(4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(639, 1);
            panelBottom.TabIndex = 9;
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
            panelCenter.Size = new System.Drawing.Size(639, 370);
            panelCenter.TabIndex = 10;
            // 
            // panelDraw
            // 
            panelDraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panelDraw.Controls.Add(tabControlMain);
            panelDraw.Controls.Add(toolStripMain);
            panelDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            panelDraw.Location = new System.Drawing.Point(1, 0);
            panelDraw.Margin = new System.Windows.Forms.Padding(4);
            panelDraw.Name = "panelDraw";
            panelDraw.Size = new System.Drawing.Size(637, 370);
            panelDraw.TabIndex = 3;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageGraph);
            tabControlMain.Controls.Add(tabPageText);
            tabControlMain.Controls.Add(tabPageRealTime);
            tabControlMain.Controls.Add(tabPageStartStopRealtime);
            tabControlMain.Controls.Add(tabPageAnimation);
            tabControlMain.Controls.Add(tabPageCadr);
            tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlMain.Location = new System.Drawing.Point(0, 27);
            tabControlMain.Margin = new System.Windows.Forms.Padding(4);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new System.Drawing.Size(633, 339);
            tabControlMain.TabIndex = 31;
            // 
            // tabPageGraph
            // 
            tabPageGraph.Controls.Add(panel1);
            tabPageGraph.Controls.Add(panel2);
            tabPageGraph.Controls.Add(panel3);
            tabPageGraph.Controls.Add(panel5);
            tabPageGraph.Location = new System.Drawing.Point(4, 24);
            tabPageGraph.Margin = new System.Windows.Forms.Padding(4);
            tabPageGraph.Name = "tabPageGraph";
            tabPageGraph.Padding = new System.Windows.Forms.Padding(4);
            tabPageGraph.Size = new System.Drawing.Size(625, 311);
            tabPageGraph.TabIndex = 0;
            tabPageGraph.Text = "Chart";
            tabPageGraph.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(5, 4);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(615, 1);
            panel1.TabIndex = 32;
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Left;
            panel2.Location = new System.Drawing.Point(4, 4);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1, 303);
            panel2.TabIndex = 28;
            // 
            // panel3
            // 
            panel3.Controls.Add(splitContainerGraph);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(panelIntLeft);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(4, 4);
            panel3.Margin = new System.Windows.Forms.Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(616, 303);
            panel3.TabIndex = 31;
            // 
            // splitContainerGraph
            // 
            splitContainerGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerGraph.Location = new System.Drawing.Point(1, 0);
            splitContainerGraph.Margin = new System.Windows.Forms.Padding(4);
            splitContainerGraph.Name = "splitContainerGraph";
            // 
            // splitContainerGraph.Panel1
            // 
            splitContainerGraph.Panel1.Controls.Add(panelGraph);
            // 
            // splitContainerGraph.Panel2
            // 
            splitContainerGraph.Panel2.Controls.Add(panelMeaRight);
            splitContainerGraph.Panel2.Controls.Add(panelMeaBottom);
            splitContainerGraph.Panel2.Controls.Add(panelMea);
            splitContainerGraph.Panel2.Controls.Add(panelMeaLeft);
            splitContainerGraph.Panel2.Controls.Add(panelMeaTop);
            splitContainerGraph.Size = new System.Drawing.Size(615, 209);
            splitContainerGraph.SplitterDistance = 360;
            splitContainerGraph.TabIndex = 28;
            // 
            // panelGraph
            // 
            panelGraph.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            panelGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelGraph.Controls.Add(userControlRealtimeAnalysis);
            panelGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            panelGraph.Location = new System.Drawing.Point(0, 0);
            panelGraph.Margin = new System.Windows.Forms.Padding(4);
            panelGraph.Name = "panelGraph";
            panelGraph.Size = new System.Drawing.Size(360, 209);
            panelGraph.TabIndex = 3;
            // 
            // userControlRealtimeAnalysis
            // 
            userControlRealtimeAnalysis.BackColor = System.Drawing.SystemColors.ButtonFace;
            userControlRealtimeAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlRealtimeAnalysis.Location = new System.Drawing.Point(0, 0);
            userControlRealtimeAnalysis.Margin = new System.Windows.Forms.Padding(4);
            userControlRealtimeAnalysis.Name = "userControlRealtimeAnalysis";
            userControlRealtimeAnalysis.Size = new System.Drawing.Size(358, 207);
            userControlRealtimeAnalysis.TabIndex = 0;
            userControlRealtimeAnalysis.Visible = false;
            // 
            // panelMeaRight
            // 
            panelMeaRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelMeaRight.Location = new System.Drawing.Point(250, 56);
            panelMeaRight.Margin = new System.Windows.Forms.Padding(4);
            panelMeaRight.Name = "panelMeaRight";
            panelMeaRight.Size = new System.Drawing.Size(1, 152);
            panelMeaRight.TabIndex = 29;
            // 
            // panelMeaBottom
            // 
            panelMeaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelMeaBottom.Location = new System.Drawing.Point(1, 208);
            panelMeaBottom.Margin = new System.Windows.Forms.Padding(4);
            panelMeaBottom.Name = "panelMeaBottom";
            panelMeaBottom.Size = new System.Drawing.Size(250, 1);
            panelMeaBottom.TabIndex = 30;
            // 
            // panelMea
            // 
            panelMea.AutoScroll = true;
            panelMea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panelMea.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMea.Location = new System.Drawing.Point(1, 56);
            panelMea.Margin = new System.Windows.Forms.Padding(4);
            panelMea.Name = "panelMea";
            panelMea.Size = new System.Drawing.Size(250, 153);
            panelMea.TabIndex = 26;
            panelMea.Resize += panelMea_Resize;
            // 
            // panelMeaLeft
            // 
            panelMeaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelMeaLeft.Location = new System.Drawing.Point(0, 56);
            panelMeaLeft.Margin = new System.Windows.Forms.Padding(4);
            panelMeaLeft.Name = "panelMeaLeft";
            panelMeaLeft.Size = new System.Drawing.Size(1, 153);
            panelMeaLeft.TabIndex = 28;
            // 
            // panelMeaTop
            // 
            panelMeaTop.Controls.Add(label5);
            panelMeaTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelMeaTop.Location = new System.Drawing.Point(0, 0);
            panelMeaTop.Margin = new System.Windows.Forms.Padding(4);
            panelMeaTop.Name = "panelMeaTop";
            panelMeaTop.Size = new System.Drawing.Size(251, 56);
            panelMeaTop.TabIndex = 27;
            // 
            // label5
            // 
            label5.Location = new System.Drawing.Point(4, 4);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(197, 37);
            label5.TabIndex = 21;
            label5.Text = "Data sources";
            // 
            // panel4
            // 
            panel4.Controls.Add(checkBoxIterator);
            panel4.Controls.Add(checkBoxDirectoryIteration);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(comboBoxStepCount);
            panel4.Controls.Add(comboBoxStep);
            panel4.Controls.Add(comboBoxStart);
            panel4.Controls.Add(calculatorBoxStep);
            panel4.Controls.Add(calculatorBoxStart);
            panel4.Controls.Add(labelY);
            panel4.Controls.Add(labelX);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(numericUpDownStepCount);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(comboBoxArg);
            panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel4.Location = new System.Drawing.Point(1, 209);
            panel4.Margin = new System.Windows.Forms.Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(615, 94);
            panel4.TabIndex = 27;
            // 
            // checkBoxIterator
            // 
            checkBoxIterator.AutoSize = true;
            checkBoxIterator.Location = new System.Drawing.Point(90, 67);
            checkBoxIterator.Name = "checkBoxIterator";
            checkBoxIterator.Size = new System.Drawing.Size(64, 19);
            checkBoxIterator.TabIndex = 38;
            checkBoxIterator.Text = "Iteraror";
            checkBoxIterator.UseVisualStyleBackColor = true;
            // 
            // checkBoxDirectoryIteration
            // 
            checkBoxDirectoryIteration.AutoSize = true;
            checkBoxDirectoryIteration.Location = new System.Drawing.Point(10, 67);
            checkBoxDirectoryIteration.Name = "checkBoxDirectoryIteration";
            checkBoxDirectoryIteration.Size = new System.Drawing.Size(74, 19);
            checkBoxDirectoryIteration.TabIndex = 37;
            checkBoxDirectoryIteration.Text = "Directory";
            checkBoxDirectoryIteration.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(413, 19);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(64, 15);
            label6.TabIndex = 36;
            label6.Text = "Step count";
            // 
            // comboBoxStepCount
            // 
            comboBoxStepCount.FormattingEnabled = true;
            comboBoxStepCount.Location = new System.Drawing.Point(463, 64);
            comboBoxStepCount.Margin = new System.Windows.Forms.Padding(4);
            comboBoxStepCount.Name = "comboBoxStepCount";
            comboBoxStepCount.Size = new System.Drawing.Size(106, 23);
            comboBoxStepCount.TabIndex = 35;
            // 
            // comboBoxStep
            // 
            comboBoxStep.FormattingEnabled = true;
            comboBoxStep.Location = new System.Drawing.Point(335, 64);
            comboBoxStep.Margin = new System.Windows.Forms.Padding(4);
            comboBoxStep.Name = "comboBoxStep";
            comboBoxStep.Size = new System.Drawing.Size(120, 23);
            comboBoxStep.TabIndex = 34;
            // 
            // comboBoxStart
            // 
            comboBoxStart.FormattingEnabled = true;
            comboBoxStart.Location = new System.Drawing.Point(205, 66);
            comboBoxStart.Margin = new System.Windows.Forms.Padding(4);
            comboBoxStart.Name = "comboBoxStart";
            comboBoxStart.Size = new System.Drawing.Size(120, 23);
            comboBoxStart.TabIndex = 33;
            // 
            // calculatorBoxStep
            // 
            calculatorBoxStep.Location = new System.Drawing.Point(335, 41);
            calculatorBoxStep.Margin = new System.Windows.Forms.Padding(4);
            calculatorBoxStep.Name = "calculatorBoxStep";
            calculatorBoxStep.Size = new System.Drawing.Size(122, 23);
            calculatorBoxStep.TabIndex = 32;
            calculatorBoxStep.Text = "0";
            // 
            // calculatorBoxStart
            // 
            calculatorBoxStart.Location = new System.Drawing.Point(205, 41);
            calculatorBoxStart.Margin = new System.Windows.Forms.Padding(4);
            calculatorBoxStart.Name = "calculatorBoxStart";
            calculatorBoxStart.Size = new System.Drawing.Size(122, 23);
            calculatorBoxStart.TabIndex = 31;
            calculatorBoxStart.Text = "0";
            // 
            // labelY
            // 
            labelY.AutoSize = true;
            labelY.Location = new System.Drawing.Point(189, 4);
            labelY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelY.Name = "labelY";
            labelY.Size = new System.Drawing.Size(28, 15);
            labelY.TabIndex = 30;
            labelY.Text = "Y = ";
            labelY.Visible = false;
            // 
            // labelX
            // 
            labelX.AutoSize = true;
            labelX.Location = new System.Drawing.Point(10, 4);
            labelX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelX.Name = "labelX";
            labelX.Size = new System.Drawing.Size(28, 15);
            labelX.TabIndex = 29;
            labelX.Text = "X = ";
            labelX.Visible = false;
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(176, 19);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(66, 26);
            label4.TabIndex = 27;
            label4.Text = "Start";
            // 
            // textBoxStepCount
            // 
            numericUpDownStepCount.Location = new System.Drawing.Point(463, 41);
            numericUpDownStepCount.Margin = new System.Windows.Forms.Padding(4);
            numericUpDownStepCount.Name = "textBoxStepCount";
            numericUpDownStepCount.Size = new System.Drawing.Size(106, 23);
            numericUpDownStepCount.TabIndex = 23;
            numericUpDownStepCount.Text = "2";
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(407, 19);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(116, 26);
            label3.TabIndex = 24;
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(25, 19);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(78, 17);
            label1.TabIndex = 20;
            label1.Text = "Argument";
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(281, 21);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(46, 26);
            label2.TabIndex = 22;
            label2.Text = "Step";
            // 
            // comboBoxArg
            // 
            comboBoxArg.FormattingEnabled = true;
            comboBoxArg.ItemHeight = 15;
            comboBoxArg.Location = new System.Drawing.Point(10, 41);
            comboBoxArg.Margin = new System.Windows.Forms.Padding(4);
            comboBoxArg.Name = "comboBoxArg";
            comboBoxArg.Size = new System.Drawing.Size(140, 23);
            comboBoxArg.TabIndex = 19;
            comboBoxArg.Text = "Time";
            // 
            // panelIntLeft
            // 
            panelIntLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelIntLeft.Location = new System.Drawing.Point(0, 0);
            panelIntLeft.Margin = new System.Windows.Forms.Padding(4);
            panelIntLeft.Name = "panelIntLeft";
            panelIntLeft.Size = new System.Drawing.Size(1, 303);
            panelIntLeft.TabIndex = 26;
            // 
            // panel5
            // 
            panel5.Dock = System.Windows.Forms.DockStyle.Right;
            panel5.Location = new System.Drawing.Point(620, 4);
            panel5.Margin = new System.Windows.Forms.Padding(4);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(1, 303);
            panel5.TabIndex = 30;
            // 
            // tabPageText
            // 
            tabPageText.ContextMenuStrip = contextMenuStripTextTab;
            tabPageText.Controls.Add(panelText);
            tabPageText.Controls.Add(panel9);
            tabPageText.Controls.Add(panel7);
            tabPageText.Controls.Add(panelTextBottom);
            tabPageText.Controls.Add(panel8);
            tabPageText.Location = new System.Drawing.Point(4, 24);
            tabPageText.Margin = new System.Windows.Forms.Padding(4);
            tabPageText.Name = "tabPageText";
            tabPageText.Padding = new System.Windows.Forms.Padding(4);
            tabPageText.Size = new System.Drawing.Size(625, 311);
            tabPageText.TabIndex = 1;
            tabPageText.Text = "Text";
            tabPageText.UseVisualStyleBackColor = true;
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
            saveXmlToolStripMenuItem.Click += saveXmlToolStripMenuItem_Click;
            // 
            // panelText
            // 
            panelText.AutoScroll = true;
            panelText.Dock = System.Windows.Forms.DockStyle.Fill;
            panelText.Location = new System.Drawing.Point(5, 45);
            panelText.Margin = new System.Windows.Forms.Padding(4);
            panelText.Name = "panelText";
            panelText.Size = new System.Drawing.Size(615, 262);
            panelText.TabIndex = 11;
            // 
            // panel9
            // 
            panel9.Dock = System.Windows.Forms.DockStyle.Right;
            panel9.Location = new System.Drawing.Point(620, 45);
            panel9.Margin = new System.Windows.Forms.Padding(4);
            panel9.Name = "panel9";
            panel9.Size = new System.Drawing.Size(1, 262);
            panel9.TabIndex = 10;
            // 
            // panel7
            // 
            panel7.Dock = System.Windows.Forms.DockStyle.Left;
            panel7.Location = new System.Drawing.Point(4, 45);
            panel7.Margin = new System.Windows.Forms.Padding(4);
            panel7.Name = "panel7";
            panel7.Size = new System.Drawing.Size(1, 262);
            panel7.TabIndex = 9;
            // 
            // panelTextBottom
            // 
            panelTextBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelTextBottom.Location = new System.Drawing.Point(4, 307);
            panelTextBottom.Margin = new System.Windows.Forms.Padding(4);
            panelTextBottom.Name = "panelTextBottom";
            panelTextBottom.Size = new System.Drawing.Size(617, 0);
            panelTextBottom.TabIndex = 8;
            // 
            // panel8
            // 
            panel8.Controls.Add(panel10);
            panel8.Controls.Add(panel11);
            panel8.Controls.Add(panel12);
            panel8.Controls.Add(panel14);
            panel8.Dock = System.Windows.Forms.DockStyle.Top;
            panel8.Location = new System.Drawing.Point(4, 4);
            panel8.Margin = new System.Windows.Forms.Padding(4);
            panel8.Name = "panel8";
            panel8.Size = new System.Drawing.Size(617, 41);
            panel8.TabIndex = 6;
            // 
            // panel10
            // 
            panel10.ContextMenuStrip = contextMenuStripTextTab;
            panel10.Controls.Add(comboBoxCond);
            panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            panel10.Location = new System.Drawing.Point(167, 6);
            panel10.Margin = new System.Windows.Forms.Padding(4);
            panel10.Name = "panel10";
            panel10.Size = new System.Drawing.Size(439, 35);
            panel10.TabIndex = 23;
            // 
            // comboBoxCond
            // 
            comboBoxCond.Dock = System.Windows.Forms.DockStyle.Fill;
            comboBoxCond.FormattingEnabled = true;
            comboBoxCond.Location = new System.Drawing.Point(0, 0);
            comboBoxCond.Margin = new System.Windows.Forms.Padding(4);
            comboBoxCond.Name = "comboBoxCond";
            comboBoxCond.Size = new System.Drawing.Size(439, 23);
            comboBoxCond.TabIndex = 0;
            // 
            // panel11
            // 
            panel11.Dock = System.Windows.Forms.DockStyle.Right;
            panel11.Location = new System.Drawing.Point(606, 6);
            panel11.Margin = new System.Windows.Forms.Padding(4);
            panel11.Name = "panel11";
            panel11.Size = new System.Drawing.Size(11, 35);
            panel11.TabIndex = 22;
            // 
            // panel12
            // 
            panel12.ContextMenuStrip = contextMenuStripTextTab;
            panel12.Controls.Add(label7);
            panel12.Dock = System.Windows.Forms.DockStyle.Left;
            panel12.Location = new System.Drawing.Point(0, 6);
            panel12.Margin = new System.Windows.Forms.Padding(4);
            panel12.Name = "panel12";
            panel12.Size = new System.Drawing.Size(167, 35);
            panel12.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ContextMenuStrip = contextMenuStripTextTab;
            label7.Location = new System.Drawing.Point(17, 6);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(99, 15);
            label7.TabIndex = 0;
            label7.Text = "Output condition";
            // 
            // panel14
            // 
            panel14.Dock = System.Windows.Forms.DockStyle.Top;
            panel14.Location = new System.Drawing.Point(0, 0);
            panel14.Margin = new System.Windows.Forms.Padding(4);
            panel14.Name = "panel14";
            panel14.Size = new System.Drawing.Size(617, 6);
            panel14.TabIndex = 20;
            // 
            // tabPageRealTime
            // 
            tabPageRealTime.Controls.Add(panel6);
            tabPageRealTime.Controls.Add(panel13);
            tabPageRealTime.Controls.Add(panel15);
            tabPageRealTime.Controls.Add(panelTop);
            tabPageRealTime.Controls.Add(panel16);
            tabPageRealTime.Location = new System.Drawing.Point(4, 24);
            tabPageRealTime.Margin = new System.Windows.Forms.Padding(4);
            tabPageRealTime.Name = "tabPageRealTime";
            tabPageRealTime.Size = new System.Drawing.Size(625, 311);
            tabPageRealTime.TabIndex = 2;
            tabPageRealTime.Text = "Realtime";
            tabPageRealTime.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.Controls.Add(userControlRealtime);
            panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            panel6.Location = new System.Drawing.Point(0, 32);
            panel6.Margin = new System.Windows.Forms.Padding(4);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(625, 279);
            panel6.TabIndex = 20;
            // 
            // userControlRealtime
            // 
            userControlRealtime.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlRealtime.Location = new System.Drawing.Point(0, 0);
            userControlRealtime.Margin = new System.Windows.Forms.Padding(4);
            userControlRealtime.Name = "userControlRealtime";
            userControlRealtime.Size = new System.Drawing.Size(625, 279);
            userControlRealtime.TabIndex = 0;
            // 
            // panel13
            // 
            panel13.Dock = System.Windows.Forms.DockStyle.Right;
            panel13.Location = new System.Drawing.Point(625, 32);
            panel13.Margin = new System.Windows.Forms.Padding(4);
            panel13.Name = "panel13";
            panel13.Size = new System.Drawing.Size(0, 279);
            panel13.TabIndex = 18;
            // 
            // panel15
            // 
            panel15.Dock = System.Windows.Forms.DockStyle.Left;
            panel15.Location = new System.Drawing.Point(0, 32);
            panel15.Margin = new System.Windows.Forms.Padding(4);
            panel15.Name = "panel15";
            panel15.Size = new System.Drawing.Size(0, 279);
            panel15.TabIndex = 17;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(panel17);
            panelTop.Controls.Add(panel18);
            panelTop.Controls.Add(panel20);
            panelTop.Controls.Add(panel21);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(625, 32);
            panelTop.TabIndex = 16;
            // 
            // panel17
            // 
            panel17.Controls.Add(checkBoxAbsoluteTime);
            panel17.Controls.Add(userControlTimeType);
            panel17.Controls.Add(label9);
            panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            panel17.Location = new System.Drawing.Point(0, 0);
            panel17.Margin = new System.Windows.Forms.Padding(4);
            panel17.Name = "panel17";
            panel17.Size = new System.Drawing.Size(625, 32);
            panel17.TabIndex = 20;
            // 
            // checkBoxAbsoluteTime
            // 
            checkBoxAbsoluteTime.AutoSize = true;
            checkBoxAbsoluteTime.Location = new System.Drawing.Point(365, 6);
            checkBoxAbsoluteTime.Margin = new System.Windows.Forms.Padding(4);
            checkBoxAbsoluteTime.Name = "checkBoxAbsoluteTime";
            checkBoxAbsoluteTime.Size = new System.Drawing.Size(100, 19);
            checkBoxAbsoluteTime.TabIndex = 2;
            checkBoxAbsoluteTime.Text = "Absolute time";
            checkBoxAbsoluteTime.UseVisualStyleBackColor = true;
            checkBoxAbsoluteTime.CheckedChanged += checkBoxAbsoluteTime_CheckedChanged;
            // 
            // userControlTimeType
            // 
            userControlTimeType.Location = new System.Drawing.Point(153, 4);
            userControlTimeType.Margin = new System.Windows.Forms.Padding(4);
            userControlTimeType.Name = "userControlTimeType";
            userControlTimeType.Size = new System.Drawing.Size(144, 26);
            userControlTimeType.TabIndex = 1;
            userControlTimeType.TimeUnit = BaseTypes.Attributes.TimeType.Second;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(4, 4);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(57, 15);
            label9.TabIndex = 0;
            label9.Text = "Time unit";
            // 
            // panel18
            // 
            panel18.Dock = System.Windows.Forms.DockStyle.Right;
            panel18.Location = new System.Drawing.Point(625, 0);
            panel18.Margin = new System.Windows.Forms.Padding(4);
            panel18.Name = "panel18";
            panel18.Size = new System.Drawing.Size(0, 32);
            panel18.TabIndex = 18;
            // 
            // panel20
            // 
            panel20.Dock = System.Windows.Forms.DockStyle.Top;
            panel20.Location = new System.Drawing.Point(0, 0);
            panel20.Margin = new System.Windows.Forms.Padding(4);
            panel20.Name = "panel20";
            panel20.Size = new System.Drawing.Size(625, 0);
            panel20.TabIndex = 16;
            // 
            // panel21
            // 
            panel21.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel21.Location = new System.Drawing.Point(0, 32);
            panel21.Margin = new System.Windows.Forms.Padding(4);
            panel21.Name = "panel21";
            panel21.Size = new System.Drawing.Size(625, 0);
            panel21.TabIndex = 19;
            // 
            // panel16
            // 
            panel16.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel16.Location = new System.Drawing.Point(0, 311);
            panel16.Margin = new System.Windows.Forms.Padding(4);
            panel16.Name = "panel16";
            panel16.Size = new System.Drawing.Size(625, 0);
            panel16.TabIndex = 19;
            // 
            // tabPageStartStopRealtime
            // 
            tabPageStartStopRealtime.Controls.Add(panel26);
            tabPageStartStopRealtime.Controls.Add(panel27);
            tabPageStartStopRealtime.Controls.Add(panel28);
            tabPageStartStopRealtime.Controls.Add(panel29);
            tabPageStartStopRealtime.Controls.Add(panel30);
            tabPageStartStopRealtime.Location = new System.Drawing.Point(4, 24);
            tabPageStartStopRealtime.Margin = new System.Windows.Forms.Padding(4);
            tabPageStartStopRealtime.Name = "tabPageStartStopRealtime";
            tabPageStartStopRealtime.Padding = new System.Windows.Forms.Padding(4);
            tabPageStartStopRealtime.Size = new System.Drawing.Size(625, 311);
            tabPageStartStopRealtime.TabIndex = 4;
            tabPageStartStopRealtime.Text = "Control";
            tabPageStartStopRealtime.UseVisualStyleBackColor = true;
            // 
            // panel26
            // 
            panel26.Controls.Add(buttonStartStopRealtime);
            panel26.Dock = System.Windows.Forms.DockStyle.Fill;
            panel26.Location = new System.Drawing.Point(4, 4);
            panel26.Margin = new System.Windows.Forms.Padding(4);
            panel26.Name = "panel26";
            panel26.Size = new System.Drawing.Size(617, 303);
            panel26.TabIndex = 20;
            // 
            // buttonStartStopRealtime
            // 
            buttonStartStopRealtime.BackColor = System.Drawing.Color.Green;
            buttonStartStopRealtime.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonStartStopRealtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            buttonStartStopRealtime.Location = new System.Drawing.Point(0, 0);
            buttonStartStopRealtime.Margin = new System.Windows.Forms.Padding(4);
            buttonStartStopRealtime.Name = "buttonStartStopRealtime";
            buttonStartStopRealtime.Size = new System.Drawing.Size(617, 303);
            buttonStartStopRealtime.TabIndex = 0;
            buttonStartStopRealtime.Text = "Start";
            buttonStartStopRealtime.UseVisualStyleBackColor = false;
            buttonStartStopRealtime.Click += buttonStartStopRealtime_Click;
            // 
            // panel27
            // 
            panel27.Dock = System.Windows.Forms.DockStyle.Right;
            panel27.Location = new System.Drawing.Point(621, 4);
            panel27.Margin = new System.Windows.Forms.Padding(4);
            panel27.Name = "panel27";
            panel27.Size = new System.Drawing.Size(0, 303);
            panel27.TabIndex = 18;
            // 
            // panel28
            // 
            panel28.Dock = System.Windows.Forms.DockStyle.Left;
            panel28.Location = new System.Drawing.Point(4, 4);
            panel28.Margin = new System.Windows.Forms.Padding(4);
            panel28.Name = "panel28";
            panel28.Size = new System.Drawing.Size(0, 303);
            panel28.TabIndex = 17;
            // 
            // panel29
            // 
            panel29.Dock = System.Windows.Forms.DockStyle.Top;
            panel29.Location = new System.Drawing.Point(4, 4);
            panel29.Margin = new System.Windows.Forms.Padding(4);
            panel29.Name = "panel29";
            panel29.Size = new System.Drawing.Size(617, 0);
            panel29.TabIndex = 16;
            // 
            // panel30
            // 
            panel30.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel30.Location = new System.Drawing.Point(4, 307);
            panel30.Margin = new System.Windows.Forms.Padding(4);
            panel30.Name = "panel30";
            panel30.Size = new System.Drawing.Size(617, 0);
            panel30.TabIndex = 19;
            // 
            // tabPageAnimation
            // 
            tabPageAnimation.Controls.Add(panel19);
            tabPageAnimation.Controls.Add(panel22);
            tabPageAnimation.Controls.Add(panel23);
            tabPageAnimation.Controls.Add(panel24);
            tabPageAnimation.Controls.Add(panel25);
            tabPageAnimation.Location = new System.Drawing.Point(4, 24);
            tabPageAnimation.Margin = new System.Windows.Forms.Padding(4);
            tabPageAnimation.Name = "tabPageAnimation";
            tabPageAnimation.Size = new System.Drawing.Size(625, 311);
            tabPageAnimation.TabIndex = 3;
            tabPageAnimation.Text = "Animation";
            tabPageAnimation.UseVisualStyleBackColor = true;
            // 
            // panel19
            // 
            panel19.Controls.Add(label10);
            panel19.Controls.Add(textBoxAnimationScale);
            panel19.Controls.Add(userControlTimeUnitAnimation);
            panel19.Controls.Add(numericUpDownPause);
            panel19.Controls.Add(label8);
            panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            panel19.Location = new System.Drawing.Point(0, 31);
            panel19.Margin = new System.Windows.Forms.Padding(4);
            panel19.Name = "panel19";
            panel19.Size = new System.Drawing.Size(625, 280);
            panel19.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(20, 45);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(119, 15);
            label10.TabIndex = 43;
            label10.Text = "Animation time scale";
            // 
            // textBoxAnimationScale
            // 
            textBoxAnimationScale.Location = new System.Drawing.Point(326, 38);
            textBoxAnimationScale.Margin = new System.Windows.Forms.Padding(4);
            textBoxAnimationScale.Name = "textBoxAnimationScale";
            textBoxAnimationScale.Size = new System.Drawing.Size(175, 23);
            textBoxAnimationScale.TabIndex = 42;
            // 
            // userControlTimeUnitAnimation
            // 
            userControlTimeUnitAnimation.Location = new System.Drawing.Point(326, 4);
            userControlTimeUnitAnimation.Margin = new System.Windows.Forms.Padding(4);
            userControlTimeUnitAnimation.Name = "userControlTimeUnitAnimation";
            userControlTimeUnitAnimation.Size = new System.Drawing.Size(175, 26);
            userControlTimeUnitAnimation.TabIndex = 41;
            userControlTimeUnitAnimation.TimeUnit = BaseTypes.Attributes.TimeType.Second;
            // 
            // numericUpDownPause
            // 
            numericUpDownPause.Location = new System.Drawing.Point(102, 7);
            numericUpDownPause.Margin = new System.Windows.Forms.Padding(4);
            numericUpDownPause.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownPause.Name = "numericUpDownPause";
            numericUpDownPause.Size = new System.Drawing.Size(67, 23);
            numericUpDownPause.TabIndex = 40;
            numericUpDownPause.ValueChanged += numericUpDownPause_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(17, 11);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(38, 15);
            label8.TabIndex = 39;
            label8.Text = "Pause";
            // 
            // panel22
            // 
            panel22.Dock = System.Windows.Forms.DockStyle.Right;
            panel22.Location = new System.Drawing.Point(625, 31);
            panel22.Margin = new System.Windows.Forms.Padding(4);
            panel22.Name = "panel22";
            panel22.Size = new System.Drawing.Size(0, 280);
            panel22.TabIndex = 18;
            // 
            // panel23
            // 
            panel23.Dock = System.Windows.Forms.DockStyle.Left;
            panel23.Location = new System.Drawing.Point(0, 31);
            panel23.Margin = new System.Windows.Forms.Padding(4);
            panel23.Name = "panel23";
            panel23.Size = new System.Drawing.Size(0, 280);
            panel23.TabIndex = 17;
            // 
            // panel24
            // 
            panel24.Controls.Add(checkBoxSynchronous);
            panel24.Dock = System.Windows.Forms.DockStyle.Top;
            panel24.Location = new System.Drawing.Point(0, 0);
            panel24.Margin = new System.Windows.Forms.Padding(4);
            panel24.Name = "panel24";
            panel24.Size = new System.Drawing.Size(625, 31);
            panel24.TabIndex = 16;
            // 
            // checkBoxSynchronous
            // 
            checkBoxSynchronous.AutoSize = true;
            checkBoxSynchronous.Location = new System.Drawing.Point(18, 4);
            checkBoxSynchronous.Margin = new System.Windows.Forms.Padding(4);
            checkBoxSynchronous.Name = "checkBoxSynchronous";
            checkBoxSynchronous.Size = new System.Drawing.Size(95, 19);
            checkBoxSynchronous.TabIndex = 0;
            checkBoxSynchronous.Text = "Synchronous";
            checkBoxSynchronous.UseVisualStyleBackColor = true;
            checkBoxSynchronous.CheckedChanged += checkBoxSynchronous_CheckedChanged;
            // 
            // panel25
            // 
            panel25.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel25.Location = new System.Drawing.Point(0, 311);
            panel25.Margin = new System.Windows.Forms.Padding(4);
            panel25.Name = "panel25";
            panel25.Size = new System.Drawing.Size(625, 0);
            panel25.TabIndex = 19;
            // 
            // tabPageCadr
            // 
            tabPageCadr.Controls.Add(panel31);
            tabPageCadr.Controls.Add(panel32);
            tabPageCadr.Controls.Add(panel33);
            tabPageCadr.Controls.Add(panel34);
            tabPageCadr.Controls.Add(panel35);
            tabPageCadr.Location = new System.Drawing.Point(4, 24);
            tabPageCadr.Margin = new System.Windows.Forms.Padding(4);
            tabPageCadr.Name = "tabPageCadr";
            tabPageCadr.Size = new System.Drawing.Size(625, 311);
            tabPageCadr.TabIndex = 5;
            tabPageCadr.Text = "Cadr";
            tabPageCadr.UseVisualStyleBackColor = true;
            // 
            // panel31
            // 
            panel31.Controls.Add(userControlCadr);
            panel31.Dock = System.Windows.Forms.DockStyle.Fill;
            panel31.Location = new System.Drawing.Point(0, 0);
            panel31.Margin = new System.Windows.Forms.Padding(4);
            panel31.Name = "panel31";
            panel31.Size = new System.Drawing.Size(625, 311);
            panel31.TabIndex = 20;
            // 
            // userControlCadr
            // 
            userControlCadr.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlCadr.Location = new System.Drawing.Point(0, 0);
            userControlCadr.Margin = new System.Windows.Forms.Padding(4);
            userControlCadr.Name = "userControlCadr";
            userControlCadr.Size = new System.Drawing.Size(625, 311);
            userControlCadr.TabIndex = 0;
            // 
            // panel32
            // 
            panel32.Dock = System.Windows.Forms.DockStyle.Right;
            panel32.Location = new System.Drawing.Point(625, 0);
            panel32.Margin = new System.Windows.Forms.Padding(4);
            panel32.Name = "panel32";
            panel32.Size = new System.Drawing.Size(0, 311);
            panel32.TabIndex = 18;
            // 
            // panel33
            // 
            panel33.Dock = System.Windows.Forms.DockStyle.Left;
            panel33.Location = new System.Drawing.Point(0, 0);
            panel33.Margin = new System.Windows.Forms.Padding(4);
            panel33.Name = "panel33";
            panel33.Size = new System.Drawing.Size(0, 311);
            panel33.TabIndex = 17;
            // 
            // panel34
            // 
            panel34.Dock = System.Windows.Forms.DockStyle.Top;
            panel34.Location = new System.Drawing.Point(0, 0);
            panel34.Margin = new System.Windows.Forms.Padding(4);
            panel34.Name = "panel34";
            panel34.Size = new System.Drawing.Size(625, 0);
            panel34.TabIndex = 16;
            // 
            // panel35
            // 
            panel35.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel35.Location = new System.Drawing.Point(0, 311);
            panel35.Margin = new System.Windows.Forms.Padding(4);
            panel35.Name = "panel35";
            panel35.Size = new System.Drawing.Size(625, 0);
            panel35.TabIndex = 19;
            // 
            // toolStripMain
            // 
            toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonStart, toolStripButtonAnimation, toolStripButtonPause, toolStripButtonStop, toolStripComboBoxPoints, toolStripButtonAdd, toolStripButtonClearAll, toolStripButtonType, toolStripButtonSeries });
            toolStripMain.Location = new System.Drawing.Point(0, 0);
            toolStripMain.Name = "toolStripMain";
            toolStripMain.Size = new System.Drawing.Size(633, 27);
            toolStripMain.TabIndex = 30;
            toolStripMain.Text = "Main";
            // 
            // toolStripButtonStart
            // 
            toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonStart.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonStart.Image");
            toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonStart.Name = "toolStripButtonStart";
            toolStripButtonStart.Size = new System.Drawing.Size(24, 24);
            toolStripButtonStart.Text = "Start";
            toolStripButtonStart.Click += toolStripButtonStart_Click;
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
            toolStripButtonAnimation.Click += toolStripButtonAnimation_Click;
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
            toolStripButtonPause.Click += toolStripButtonPause_Click;
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
            toolStripButtonStop.Click += toolStripButtonStop_Click;
            // 
            // toolStripComboBoxPoints
            // 
            toolStripComboBoxPoints.Name = "toolStripComboBoxPoints";
            toolStripComboBoxPoints.Size = new System.Drawing.Size(140, 27);
            toolStripComboBoxPoints.Text = "<Points>";
            // 
            // toolStripButtonAdd
            // 
            toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonAdd.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonAdd.Image");
            toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new System.Drawing.Size(24, 24);
            toolStripButtonAdd.Text = "Add";
            toolStripButtonAdd.Click += toolStripButtonAdd_Click;
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
            // toolStripButtonType
            // 
            toolStripButtonType.Name = "toolStripButtonType";
            toolStripButtonType.Size = new System.Drawing.Size(140, 27);
            toolStripButtonType.Text = "<Series type>";
            // 
            // toolStripButtonSeries
            // 
            toolStripButtonSeries.Name = "toolStripButtonSeries";
            toolStripButtonSeries.Size = new System.Drawing.Size(75, 27);
            toolStripButtonSeries.Text = "<Series>";
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(638, 0);
            panelRight.Margin = new System.Windows.Forms.Padding(4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(1, 370);
            panelRight.TabIndex = 2;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 0);
            panelLeft.Margin = new System.Windows.Forms.Padding(4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(1, 370);
            panelLeft.TabIndex = 1;
            // 
            // contextMenuStripMain
            // 
            contextMenuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { showRuntimeIndicatorsToolStripMenuItem });
            contextMenuStripMain.Name = "contextMenuStripMain";
            contextMenuStripMain.Size = new System.Drawing.Size(204, 26);
            // 
            // showRuntimeIndicatorsToolStripMenuItem
            // 
            showRuntimeIndicatorsToolStripMenuItem.Name = "showRuntimeIndicatorsToolStripMenuItem";
            showRuntimeIndicatorsToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            showRuntimeIndicatorsToolStripMenuItem.Text = "Show runtime indicators";
            showRuntimeIndicatorsToolStripMenuItem.Click += showRuntimeIndicatorsToolStripMenuItem_Click;
            // 
            // backgroundWorkerReatimeAnalysis
            // 
            backgroundWorkerReatimeAnalysis.WorkerSupportsCancellation = true;
            backgroundWorkerReatimeAnalysis.DoWork += backgroundWorkerReatimeAnalysis_DoWork;
            backgroundWorkerReatimeAnalysis.RunWorkerCompleted += backgroundWorkerReatimeAnalysis_RunWorkerCompleted;
            // 
            // backgroundWorkerTextRealtimeAnalysis
            // 
            backgroundWorkerTextRealtimeAnalysis.WorkerSupportsCancellation = true;
            backgroundWorkerTextRealtimeAnalysis.DoWork += backgroundWorkerTextRealtimeAnalysis_DoWork;
            backgroundWorkerTextRealtimeAnalysis.RunWorkerCompleted += backgroundWorkerTextRealtimeAnalysis_RunWorkerCompleted;
            // 
            // UserControlGraph
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            ContextMenuStrip = contextMenuStripMain;
            Controls.Add(panelBottom);
            Controls.Add(panelCenter);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "UserControlGraph";
            Size = new System.Drawing.Size(639, 370);
            panelCenter.ResumeLayout(false);
            panelDraw.ResumeLayout(false);
            panelDraw.PerformLayout();
            tabControlMain.ResumeLayout(false);
            tabPageGraph.ResumeLayout(false);
            panel3.ResumeLayout(false);
            splitContainerGraph.Panel1.ResumeLayout(false);
            splitContainerGraph.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerGraph).EndInit();
            splitContainerGraph.ResumeLayout(false);
            panelGraph.ResumeLayout(false);
            panelMeaTop.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tabPageText.ResumeLayout(false);
            contextMenuStripTextTab.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            tabPageRealTime.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            tabPageStartStopRealtime.ResumeLayout(false);
            panel26.ResumeLayout(false);
            tabPageAnimation.ResumeLayout(false);
            panel19.ResumeLayout(false);
            panel19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPause).EndInit();
            panel24.ResumeLayout(false);
            panel24.PerformLayout();
            tabPageCadr.ResumeLayout(false);
            panel31.ResumeLayout(false);
            toolStripMain.ResumeLayout(false);
            toolStripMain.PerformLayout();
            contextMenuStripMain.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.NumericUpDown numericUpDownStepCount;
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
        private System.Windows.Forms.CheckBox checkBoxIterator;
    }
}
