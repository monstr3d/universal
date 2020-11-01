namespace ControlSystems.UI.UserControls
{
    partial class UserControlTransformFunction
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageFormula = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainerFormula = new System.Windows.Forms.SplitContainer();
            this.userFormulaEditor = new FormulaEditor.UI.UserControls.UserControlFormulaEditor();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelFormulaTop = new System.Windows.Forms.Panel();
            this.panelControl = new System.Windows.Forms.Panel();
            this.labelInput = new System.Windows.Forms.Label();
            this.comboBoxInput = new System.Windows.Forms.ComboBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonFormula = new System.Windows.Forms.Button();
            this.tabPageGraphics = new System.Windows.Forms.TabPage();
            this.panel14 = new System.Windows.Forms.Panel();
            this.splitContainerFreq = new System.Windows.Forms.SplitContainer();
            this.panel15 = new System.Windows.Forms.Panel();
            this.userControlChartApmplitude = new Chart.UserControls.UserControlChart();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelAmpBottom = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.userControlChartPhase = new Chart.UserControls.UserControlChart();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelPhaseBottom = new System.Windows.Forms.Panel();
            this.panelFreqRight = new System.Windows.Forms.Panel();
            this.panelFreqLeft = new System.Windows.Forms.Panel();
            this.panelFreqTop = new System.Windows.Forms.Panel();
            this.panelFreqBottom = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.checkBoxStable = new System.Windows.Forms.CheckBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.checkBoxLog = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.tabPageTransient = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.userControlChartTransient = new Chart.UserControls.UserControlChart();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel25 = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.tabPageFeedback = new System.Windows.Forms.TabPage();
            this.comboBoxFeedBack = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelCenter.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageFormula.SuspendLayout();
            this.panel4.SuspendLayout();
            this.splitContainerFormula.Panel1.SuspendLayout();
            this.splitContainerFormula.Panel2.SuspendLayout();
            this.splitContainerFormula.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.tabPageGraphics.SuspendLayout();
            this.panel14.SuspendLayout();
            this.splitContainerFreq.Panel1.SuspendLayout();
            this.splitContainerFreq.Panel2.SuspendLayout();
            this.splitContainerFreq.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panelFreqBottom.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel16.SuspendLayout();
            this.tabPageTransient.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tabPageFeedback.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 442);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(677, 1);
            this.panelBottom.TabIndex = 7;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControlMain);
            this.panelCenter.Controls.Add(this.panelRight);
            this.panelCenter.Controls.Add(this.panelLeft);
            this.panelCenter.Controls.Add(this.panelTop);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(677, 442);
            this.panelCenter.TabIndex = 8;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageFormula);
            this.tabControlMain.Controls.Add(this.tabPageGraphics);
            this.tabControlMain.Controls.Add(this.tabPageTransient);
            this.tabControlMain.Controls.Add(this.tabPageFeedback);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(1, 1);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(675, 441);
            this.tabControlMain.TabIndex = 3;
            // 
            // tabPageFormula
            // 
            this.tabPageFormula.Controls.Add(this.panel4);
            this.tabPageFormula.Controls.Add(this.panelControl);
            this.tabPageFormula.Location = new System.Drawing.Point(4, 22);
            this.tabPageFormula.Name = "tabPageFormula";
            this.tabPageFormula.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFormula.Size = new System.Drawing.Size(667, 415);
            this.tabPageFormula.TabIndex = 0;
            this.tabPageFormula.Text = "Transformation function";
            this.tabPageFormula.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.splitContainerFormula);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panelFormulaTop);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(661, 368);
            this.panel4.TabIndex = 6;
            // 
            // splitContainerFormula
            // 
            this.splitContainerFormula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFormula.Location = new System.Drawing.Point(1, 1);
            this.splitContainerFormula.Name = "splitContainerFormula";
            // 
            // splitContainerFormula.Panel1
            // 
            this.splitContainerFormula.Panel1.Controls.Add(this.userFormulaEditor);
            // 
            // splitContainerFormula.Panel2
            // 
            this.splitContainerFormula.Panel2.Controls.Add(this.propertyGrid);
            this.splitContainerFormula.Size = new System.Drawing.Size(659, 367);
            this.splitContainerFormula.SplitterDistance = 562;
            this.splitContainerFormula.TabIndex = 3;
            // 
            // userFormulaEditor
            // 
            this.userFormulaEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userFormulaEditor.Formula = "";
            this.userFormulaEditor.Location = new System.Drawing.Point(0, 0);
            this.userFormulaEditor.Name = "userFormulaEditor";
            this.userFormulaEditor.Size = new System.Drawing.Size(562, 367);
            this.userFormulaEditor.TabIndex = 0;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(93, 367);
            this.propertyGrid.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(660, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 367);
            this.panel3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 367);
            this.panel1.TabIndex = 1;
            // 
            // panelFormulaTop
            // 
            this.panelFormulaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFormulaTop.Location = new System.Drawing.Point(0, 0);
            this.panelFormulaTop.Name = "panelFormulaTop";
            this.panelFormulaTop.Size = new System.Drawing.Size(661, 1);
            this.panelFormulaTop.TabIndex = 0;
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.labelInput);
            this.panelControl.Controls.Add(this.comboBoxInput);
            this.panelControl.Controls.Add(this.buttonApply);
            this.panelControl.Controls.Add(this.buttonFormula);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl.Location = new System.Drawing.Point(3, 371);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(661, 41);
            this.panelControl.TabIndex = 5;
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(279, 12);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(31, 13);
            this.labelInput.TabIndex = 3;
            this.labelInput.Text = "Input";
            this.labelInput.Visible = false;
            // 
            // comboBoxInput
            // 
            this.comboBoxInput.FormattingEnabled = true;
            this.comboBoxInput.Location = new System.Drawing.Point(346, 9);
            this.comboBoxInput.Name = "comboBoxInput";
            this.comboBoxInput.Size = new System.Drawing.Size(287, 21);
            this.comboBoxInput.TabIndex = 2;
            this.comboBoxInput.Visible = false;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(346, 7);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(287, 23);
            this.buttonApply.TabIndex = 1;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // buttonFormula
            // 
            this.buttonFormula.Location = new System.Drawing.Point(10, 7);
            this.buttonFormula.Name = "buttonFormula";
            this.buttonFormula.Size = new System.Drawing.Size(287, 23);
            this.buttonFormula.TabIndex = 0;
            this.buttonFormula.Text = "Accept formula";
            this.buttonFormula.UseVisualStyleBackColor = true;
            this.buttonFormula.Click += new System.EventHandler(this.buttonFormula_Click);
            // 
            // tabPageGraphics
            // 
            this.tabPageGraphics.Controls.Add(this.panel14);
            this.tabPageGraphics.Controls.Add(this.panelFreqBottom);
            this.tabPageGraphics.Location = new System.Drawing.Point(4, 22);
            this.tabPageGraphics.Name = "tabPageGraphics";
            this.tabPageGraphics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGraphics.Size = new System.Drawing.Size(667, 415);
            this.tabPageGraphics.TabIndex = 1;
            this.tabPageGraphics.Text = "Frequency characteristics";
            this.tabPageGraphics.UseVisualStyleBackColor = true;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.splitContainerFreq);
            this.panel14.Controls.Add(this.panelFreqRight);
            this.panel14.Controls.Add(this.panelFreqLeft);
            this.panel14.Controls.Add(this.panelFreqTop);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(3, 3);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(661, 381);
            this.panel14.TabIndex = 8;
            // 
            // splitContainerFreq
            // 
            this.splitContainerFreq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFreq.Location = new System.Drawing.Point(1, 10);
            this.splitContainerFreq.Name = "splitContainerFreq";
            this.splitContainerFreq.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFreq.Panel1
            // 
            this.splitContainerFreq.Panel1.Controls.Add(this.panel15);
            this.splitContainerFreq.Panel1.Controls.Add(this.panelAmpBottom);
            // 
            // splitContainerFreq.Panel2
            // 
            this.splitContainerFreq.Panel2.Controls.Add(this.panel20);
            this.splitContainerFreq.Panel2.Controls.Add(this.panelPhaseBottom);
            this.splitContainerFreq.Size = new System.Drawing.Size(659, 371);
            this.splitContainerFreq.SplitterDistance = 182;
            this.splitContainerFreq.TabIndex = 3;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.userControlChartApmplitude);
            this.panel15.Controls.Add(this.panel11);
            this.panel15.Controls.Add(this.panel13);
            this.panel15.Controls.Add(this.panel12);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(659, 181);
            this.panel15.TabIndex = 8;
            // 
            // userControlChartApmplitude
            // 
            this.userControlChartApmplitude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlChartApmplitude.Coordinator = null;
            this.userControlChartApmplitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlChartApmplitude.IsBlocked = true;
            this.userControlChartApmplitude.Location = new System.Drawing.Point(10, 25);
            this.userControlChartApmplitude.Name = "userControlChartApmplitude";
            this.userControlChartApmplitude.Size = new System.Drawing.Size(639, 156);
            this.userControlChartApmplitude.TabIndex = 3;
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(649, 25);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(10, 156);
            this.panel11.TabIndex = 2;
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(0, 25);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(10, 156);
            this.panel13.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.label1);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(659, 25);
            this.panel12.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amplitude";
            // 
            // panelAmpBottom
            // 
            this.panelAmpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAmpBottom.Location = new System.Drawing.Point(0, 181);
            this.panelAmpBottom.Name = "panelAmpBottom";
            this.panelAmpBottom.Size = new System.Drawing.Size(659, 1);
            this.panelAmpBottom.TabIndex = 7;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.userControlChartPhase);
            this.panel20.Controls.Add(this.panel17);
            this.panel20.Controls.Add(this.panel19);
            this.panel20.Controls.Add(this.panel18);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel20.Location = new System.Drawing.Point(0, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(659, 184);
            this.panel20.TabIndex = 8;
            // 
            // userControlChartPhase
            // 
            this.userControlChartPhase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlChartPhase.Coordinator = null;
            this.userControlChartPhase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlChartPhase.IsBlocked = true;
            this.userControlChartPhase.Location = new System.Drawing.Point(10, 22);
            this.userControlChartPhase.Name = "userControlChartPhase";
            this.userControlChartPhase.Size = new System.Drawing.Size(639, 162);
            this.userControlChartPhase.TabIndex = 3;
            // 
            // panel17
            // 
            this.panel17.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel17.Location = new System.Drawing.Point(649, 22);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(10, 162);
            this.panel17.TabIndex = 2;
            // 
            // panel19
            // 
            this.panel19.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel19.Location = new System.Drawing.Point(0, 22);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(10, 162);
            this.panel19.TabIndex = 1;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.label2);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(0, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(659, 22);
            this.panel18.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phase, Deg";
            // 
            // panelPhaseBottom
            // 
            this.panelPhaseBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPhaseBottom.Location = new System.Drawing.Point(0, 184);
            this.panelPhaseBottom.Name = "panelPhaseBottom";
            this.panelPhaseBottom.Size = new System.Drawing.Size(659, 1);
            this.panelPhaseBottom.TabIndex = 7;
            // 
            // panelFreqRight
            // 
            this.panelFreqRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelFreqRight.Location = new System.Drawing.Point(660, 10);
            this.panelFreqRight.Name = "panelFreqRight";
            this.panelFreqRight.Size = new System.Drawing.Size(1, 371);
            this.panelFreqRight.TabIndex = 2;
            // 
            // panelFreqLeft
            // 
            this.panelFreqLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelFreqLeft.Location = new System.Drawing.Point(0, 10);
            this.panelFreqLeft.Name = "panelFreqLeft";
            this.panelFreqLeft.Size = new System.Drawing.Size(1, 371);
            this.panelFreqLeft.TabIndex = 1;
            // 
            // panelFreqTop
            // 
            this.panelFreqTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFreqTop.Location = new System.Drawing.Point(0, 0);
            this.panelFreqTop.Name = "panelFreqTop";
            this.panelFreqTop.Size = new System.Drawing.Size(661, 10);
            this.panelFreqTop.TabIndex = 0;
            // 
            // panelFreqBottom
            // 
            this.panelFreqBottom.Controls.Add(this.panel23);
            this.panelFreqBottom.Controls.Add(this.panel24);
            this.panelFreqBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFreqBottom.Location = new System.Drawing.Point(3, 384);
            this.panelFreqBottom.Name = "panelFreqBottom";
            this.panelFreqBottom.Size = new System.Drawing.Size(661, 28);
            this.panelFreqBottom.TabIndex = 7;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.checkBoxStable);
            this.panel23.Controls.Add(this.panel16);
            this.panel23.Controls.Add(this.panel22);
            this.panel23.Controls.Add(this.panel21);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel23.Location = new System.Drawing.Point(0, 0);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(661, 27);
            this.panel23.TabIndex = 8;
            // 
            // checkBoxStable
            // 
            this.checkBoxStable.AutoSize = true;
            this.checkBoxStable.Location = new System.Drawing.Point(66, 7);
            this.checkBoxStable.Name = "checkBoxStable";
            this.checkBoxStable.Size = new System.Drawing.Size(91, 17);
            this.checkBoxStable.TabIndex = 3;
            this.checkBoxStable.Text = "Stable system";
            this.checkBoxStable.UseVisualStyleBackColor = true;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.checkBoxLog);
            this.panel16.Controls.Add(this.label3);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel16.Location = new System.Drawing.Point(375, 1);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(286, 26);
            this.panel16.TabIndex = 2;
            // 
            // checkBoxLog
            // 
            this.checkBoxLog.AutoSize = true;
            this.checkBoxLog.Location = new System.Drawing.Point(4, 5);
            this.checkBoxLog.Name = "checkBoxLog";
            this.checkBoxLog.Size = new System.Drawing.Size(111, 17);
            this.checkBoxLog.TabIndex = 3;
            this.checkBoxLog.Text = "Logariphmic scale";
            this.checkBoxLog.UseVisualStyleBackColor = true;
            this.checkBoxLog.CheckedChanged += new System.EventHandler(this.checkBoxLog_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Frequency, Hz";
            // 
            // panel22
            // 
            this.panel22.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel22.Location = new System.Drawing.Point(0, 1);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(1, 26);
            this.panel22.TabIndex = 1;
            // 
            // panel21
            // 
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(0, 0);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(661, 1);
            this.panel21.TabIndex = 0;
            // 
            // panel24
            // 
            this.panel24.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel24.Location = new System.Drawing.Point(0, 27);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(661, 1);
            this.panel24.TabIndex = 7;
            // 
            // tabPageTransient
            // 
            this.tabPageTransient.Controls.Add(this.panel9);
            this.tabPageTransient.Location = new System.Drawing.Point(4, 22);
            this.tabPageTransient.Name = "tabPageTransient";
            this.tabPageTransient.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTransient.Size = new System.Drawing.Size(667, 415);
            this.tabPageTransient.TabIndex = 2;
            this.tabPageTransient.Text = "Transient";
            this.tabPageTransient.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.panel25);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(661, 409);
            this.panel9.TabIndex = 8;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.userControlChartTransient);
            this.panel10.Controls.Add(this.panel6);
            this.panel10.Controls.Add(this.panel8);
            this.panel10.Controls.Add(this.panel7);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(661, 399);
            this.panel10.TabIndex = 8;
            // 
            // userControlChartTransient
            // 
            this.userControlChartTransient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlChartTransient.Coordinator = null;
            this.userControlChartTransient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlChartTransient.IsBlocked = true;
            this.userControlChartTransient.Location = new System.Drawing.Point(10, 10);
            this.userControlChartTransient.Name = "userControlChartTransient";
            this.userControlChartTransient.Size = new System.Drawing.Size(641, 389);
            this.userControlChartTransient.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(651, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 389);
            this.panel6.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 10);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(10, 389);
            this.panel8.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(661, 10);
            this.panel7.TabIndex = 0;
            // 
            // panel25
            // 
            this.panel25.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel25.Location = new System.Drawing.Point(0, 399);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(661, 10);
            this.panel25.TabIndex = 7;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(676, 1);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1, 441);
            this.panelRight.TabIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 1);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(1, 441);
            this.panelLeft.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(677, 1);
            this.panelTop.TabIndex = 0;
            // 
            // tabPageFeedback
            // 
            this.tabPageFeedback.Controls.Add(this.label4);
            this.tabPageFeedback.Controls.Add(this.comboBoxFeedBack);
            this.tabPageFeedback.Location = new System.Drawing.Point(4, 22);
            this.tabPageFeedback.Name = "tabPageFeedback";
            this.tabPageFeedback.Size = new System.Drawing.Size(667, 415);
            this.tabPageFeedback.TabIndex = 3;
            this.tabPageFeedback.Text = "Feedback";
            this.tabPageFeedback.UseVisualStyleBackColor = true;
            // 
            // comboBoxFeedBack
            // 
            this.comboBoxFeedBack.FormattingEnabled = true;
            this.comboBoxFeedBack.Location = new System.Drawing.Point(135, 88);
            this.comboBoxFeedBack.Name = "comboBoxFeedBack";
            this.comboBoxFeedBack.Size = new System.Drawing.Size(363, 21);
            this.comboBoxFeedBack.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Feedback alias";
            // 
            // UserControlTransformFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlTransformFunction";
            this.Size = new System.Drawing.Size(677, 443);
            this.panelCenter.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageFormula.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.splitContainerFormula.Panel1.ResumeLayout(false);
            this.splitContainerFormula.Panel2.ResumeLayout(false);
            this.splitContainerFormula.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.tabPageGraphics.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.splitContainerFreq.Panel1.ResumeLayout(false);
            this.splitContainerFreq.Panel2.ResumeLayout(false);
            this.splitContainerFreq.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panelFreqBottom.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.tabPageTransient.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.tabPageFeedback.ResumeLayout(false);
            this.tabPageFeedback.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageFormula;
        private System.Windows.Forms.TabPage tabPageGraphics;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SplitContainer splitContainerFormula;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelFormulaTop;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button buttonFormula;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private FormulaEditor.UI.UserControls.UserControlFormulaEditor userFormulaEditor;
        private System.Windows.Forms.TabPage tabPageTransient;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.SplitContainer splitContainerFreq;
        private System.Windows.Forms.Panel panelFreqRight;
        private System.Windows.Forms.Panel panelFreqLeft;
        private System.Windows.Forms.Panel panelFreqTop;
        private System.Windows.Forms.Panel panelFreqBottom;
        private System.Windows.Forms.Panel panel15;
        private Chart.UserControls.UserControlChart userControlChartApmplitude;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panelAmpBottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel20;
        private Chart.UserControls.UserControlChart userControlChartPhase;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panelPhaseBottom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.CheckBox checkBoxLog;
        private System.Windows.Forms.Panel panel10;
        private Chart.UserControls.UserControlChart userControlChartTransient;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.ComboBox comboBoxInput;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.CheckBox checkBoxStable;
        private System.Windows.Forms.TabPage tabPageFeedback;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxFeedBack;
    }
}
