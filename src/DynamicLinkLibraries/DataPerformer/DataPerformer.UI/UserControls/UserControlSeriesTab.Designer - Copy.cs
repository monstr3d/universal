namespace DataPerformer.UI.UserControls
{
    partial class UserControlSeriesTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlSeriesTab));
            this.panelCenter = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageChart = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlSeries = new DataPerformer.UI.UserControls.UserControlSeries();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusCoord = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPageTable = new System.Windows.Forms.TabPage();
            this.panelTable = new System.Windows.Forms.Panel();
            this.userControlSeriesTable = new DataPerformer.UI.UserControls.UserControlSeriesTable();
            this.panelRightTable = new System.Windows.Forms.Panel();
            this.panelLeftTable = new System.Windows.Forms.Panel();
            this.panelTopTable = new System.Windows.Forms.Panel();
            this.panelBottomTable = new System.Windows.Forms.Panel();
            this.labelCount = new System.Windows.Forms.Label();
            this.checkBoxShow = new System.Windows.Forms.CheckBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.tabPageComments = new System.Windows.Forms.TabPage();
            this.userControlCommentsFont = new Diagram.UI.UserControls.UserControlCommentsFont();
            this.tabPageGenerator = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.userFormulaEditor = new FormulaEditor.UI.UserControls.UserControlFormulaEditor();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.textBoxStepCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStep = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStart = new System.Windows.Forms.TextBox();
            this.labelStart = new System.Windows.Forms.Label();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonType = new System.Windows.Forms.ToolStripComboBox();
            this.pic = new OfficePickers.ColorPicker.ToolStripColorPicker();
            this.toolStripDropDownButtonXml = new System.Windows.Forms.ToolStripDropDownButton();
            this.exportToXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.openFileDialogXml = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogXml = new System.Windows.Forms.SaveFileDialog();
            this.panelCenter.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageChart.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabPageTable.SuspendLayout();
            this.panelTable.SuspendLayout();
            this.panelBottomTable.SuspendLayout();
            this.tabPageComments.SuspendLayout();
            this.tabPageGenerator.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControlMain);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 26);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(407, 293);
            this.panelCenter.TabIndex = 15;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageChart);
            this.tabControlMain.Controls.Add(this.tabPageTable);
            this.tabControlMain.Controls.Add(this.tabPageComments);
            this.tabControlMain.Controls.Add(this.tabPageGenerator);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(407, 293);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageChart
            // 
            this.tabPageChart.Controls.Add(this.panel1);
            this.tabPageChart.Controls.Add(this.panel2);
            this.tabPageChart.Controls.Add(this.panel3);
            this.tabPageChart.Controls.Add(this.panelTop);
            this.tabPageChart.Controls.Add(this.statusStrip);
            this.tabPageChart.Location = new System.Drawing.Point(4, 22);
            this.tabPageChart.Name = "tabPageChart";
            this.tabPageChart.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageChart.Size = new System.Drawing.Size(399, 267);
            this.tabPageChart.TabIndex = 0;
            this.tabPageChart.Text = "Chart";
            this.tabPageChart.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userControlSeries);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 239);
            this.panel1.TabIndex = 20;
            // 
            // userControlSeries
            // 
            this.userControlSeries.Comments = new System.Collections.ICollection[0];
            this.userControlSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlSeries.Location = new System.Drawing.Point(0, 0);
            this.userControlSeries.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userControlSeries.Name = "userControlSeries";
            this.userControlSeries.PainterProvider = null;
            this.userControlSeries.Size = new System.Drawing.Size(393, 239);
            this.userControlSeries.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(396, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 239);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 239);
            this.panel3.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(393, 0);
            this.panelTop.TabIndex = 16;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusCoord});
            this.statusStrip.Location = new System.Drawing.Point(3, 242);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(393, 22);
            this.statusStrip.TabIndex = 19;
            // 
            // toolStripStatusCoord
            // 
            this.toolStripStatusCoord.Name = "toolStripStatusCoord";
            this.toolStripStatusCoord.Size = new System.Drawing.Size(0, 17);
            // 
            // tabPageTable
            // 
            this.tabPageTable.Controls.Add(this.panelTable);
            this.tabPageTable.Controls.Add(this.panelRightTable);
            this.tabPageTable.Controls.Add(this.panelLeftTable);
            this.tabPageTable.Controls.Add(this.panelTopTable);
            this.tabPageTable.Controls.Add(this.panelBottomTable);
            this.tabPageTable.Location = new System.Drawing.Point(4, 22);
            this.tabPageTable.Name = "tabPageTable";
            this.tabPageTable.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageTable.Size = new System.Drawing.Size(399, 267);
            this.tabPageTable.TabIndex = 1;
            this.tabPageTable.Text = "Table";
            this.tabPageTable.UseVisualStyleBackColor = true;
            // 
            // panelTable
            // 
            this.panelTable.Controls.Add(this.userControlSeriesTable);
            this.panelTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTable.Location = new System.Drawing.Point(3, 3);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(393, 221);
            this.panelTable.TabIndex = 15;
            // 
            // userControlSeriesTable
            // 
            this.userControlSeriesTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlSeriesTable.Location = new System.Drawing.Point(0, 0);
            this.userControlSeriesTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userControlSeriesTable.Name = "userControlSeriesTable";
            this.userControlSeriesTable.Series = null;
            this.userControlSeriesTable.Size = new System.Drawing.Size(393, 221);
            this.userControlSeriesTable.TabIndex = 0;
            this.userControlSeriesTable.Update += new System.Action(this.userControlSeriesTable_Update);
            // 
            // panelRightTable
            // 
            this.panelRightTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightTable.Location = new System.Drawing.Point(396, 3);
            this.panelRightTable.Name = "panelRightTable";
            this.panelRightTable.Size = new System.Drawing.Size(0, 221);
            this.panelRightTable.TabIndex = 13;
            // 
            // panelLeftTable
            // 
            this.panelLeftTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftTable.Location = new System.Drawing.Point(3, 3);
            this.panelLeftTable.Name = "panelLeftTable";
            this.panelLeftTable.Size = new System.Drawing.Size(0, 221);
            this.panelLeftTable.TabIndex = 12;
            // 
            // panelTopTable
            // 
            this.panelTopTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopTable.Location = new System.Drawing.Point(3, 3);
            this.panelTopTable.Name = "panelTopTable";
            this.panelTopTable.Size = new System.Drawing.Size(393, 0);
            this.panelTopTable.TabIndex = 11;
            // 
            // panelBottomTable
            // 
            this.panelBottomTable.Controls.Add(this.labelCount);
            this.panelBottomTable.Controls.Add(this.checkBoxShow);
            this.panelBottomTable.Controls.Add(this.buttonUpdate);
            this.panelBottomTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomTable.Location = new System.Drawing.Point(3, 224);
            this.panelBottomTable.Name = "panelBottomTable";
            this.panelBottomTable.Size = new System.Drawing.Size(393, 40);
            this.panelBottomTable.TabIndex = 14;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(208, 7);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(35, 13);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "label1";
            // 
            // checkBoxShow
            // 
            this.checkBoxShow.AutoSize = true;
            this.checkBoxShow.Location = new System.Drawing.Point(106, 7);
            this.checkBoxShow.Name = "checkBoxShow";
            this.checkBoxShow.Size = new System.Drawing.Size(79, 17);
            this.checkBoxShow.TabIndex = 1;
            this.checkBoxShow.Text = "Show table";
            this.checkBoxShow.UseVisualStyleBackColor = true;
            this.checkBoxShow.CheckedChanged += new System.EventHandler(this.checkBoxShow_CheckedChanged);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(14, 7);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // tabPageComments
            // 
            this.tabPageComments.Controls.Add(this.userControlCommentsFont);
            this.tabPageComments.Location = new System.Drawing.Point(4, 22);
            this.tabPageComments.Name = "tabPageComments";
            this.tabPageComments.Size = new System.Drawing.Size(399, 272);
            this.tabPageComments.TabIndex = 2;
            this.tabPageComments.Text = "Comments";
            this.tabPageComments.UseVisualStyleBackColor = true;
            // 
            // userControlCommentsFont
            // 
            this.userControlCommentsFont.AutoSave = true;
            this.userControlCommentsFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlCommentsFont.Location = new System.Drawing.Point(0, 0);
            this.userControlCommentsFont.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userControlCommentsFont.Name = "userControlCommentsFont";
            this.userControlCommentsFont.Size = new System.Drawing.Size(399, 283);
            this.userControlCommentsFont.TabIndex = 0;
            // 
            // tabPageGenerator
            // 
            this.tabPageGenerator.Controls.Add(this.panel4);
            this.tabPageGenerator.Controls.Add(this.panel5);
            this.tabPageGenerator.Controls.Add(this.panel6);
            this.tabPageGenerator.Controls.Add(this.panel7);
            this.tabPageGenerator.Controls.Add(this.panel8);
            this.tabPageGenerator.Location = new System.Drawing.Point(4, 22);
            this.tabPageGenerator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageGenerator.Name = "tabPageGenerator";
            this.tabPageGenerator.Size = new System.Drawing.Size(399, 272);
            this.tabPageGenerator.TabIndex = 3;
            this.tabPageGenerator.Text = "Generator";
            this.tabPageGenerator.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.userFormulaEditor);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(401, 223);
            this.panel4.TabIndex = 20;
            // 
            // userFormulaEditor
            // 
            this.userFormulaEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userFormulaEditor.Formula = "";
            this.userFormulaEditor.Location = new System.Drawing.Point(0, 0);
            this.userFormulaEditor.Name = "userFormulaEditor";
            this.userFormulaEditor.Size = new System.Drawing.Size(401, 223);
            this.userFormulaEditor.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(401, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(0, 223);
            this.panel5.TabIndex = 18;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(0, 223);
            this.panel6.TabIndex = 17;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(401, 0);
            this.panel7.TabIndex = 16;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.textBoxStepCount);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.textBoxStep);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.textBoxStart);
            this.panel8.Controls.Add(this.labelStart);
            this.panel8.Controls.Add(this.buttonGenerate);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 223);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(401, 51);
            this.panel8.TabIndex = 19;
            // 
            // textBoxStepCount
            // 
            this.textBoxStepCount.Location = new System.Drawing.Point(281, 26);
            this.textBoxStepCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxStepCount.Name = "textBoxStepCount";
            this.textBoxStepCount.Size = new System.Drawing.Size(91, 20);
            this.textBoxStepCount.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Step count";
            // 
            // textBoxStep
            // 
            this.textBoxStep.Location = new System.Drawing.Point(182, 27);
            this.textBoxStep.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxStep.Name = "textBoxStep";
            this.textBoxStep.Size = new System.Drawing.Size(88, 20);
            this.textBoxStep.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Step";
            // 
            // textBoxStart
            // 
            this.textBoxStart.Location = new System.Drawing.Point(80, 27);
            this.textBoxStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxStart.Name = "textBoxStart";
            this.textBoxStart.Size = new System.Drawing.Size(98, 20);
            this.textBoxStart.TabIndex = 2;
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(80, 11);
            this.labelStart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(29, 13);
            this.labelStart.TabIndex = 1;
            this.labelStart.Text = "Start";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(2, 21);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(74, 24);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Create";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(407, 26);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 293);
            this.panelRight.TabIndex = 13;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 26);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 293);
            this.panelLeft.TabIndex = 12;
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripButtonRefresh,
            this.toolStripButtonType,
            this.pic,
            this.toolStripDropDownButtonXml});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(407, 26);
            this.toolStripMain.TabIndex = 11;
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
            this.toolStripButtonType.Size = new System.Drawing.Size(121, 26);
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
            // toolStripDropDownButtonXml
            // 
            this.toolStripDropDownButtonXml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonXml.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToXmlToolStripMenuItem,
            this.importFromXmlToolStripMenuItem});
            this.toolStripDropDownButtonXml.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonXml.Image")));
            this.toolStripDropDownButtonXml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonXml.Name = "toolStripDropDownButtonXml";
            this.toolStripDropDownButtonXml.Size = new System.Drawing.Size(41, 23);
            this.toolStripDropDownButtonXml.Text = "Xml";
            this.toolStripDropDownButtonXml.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripDropDownButtonXml.ToolTipText = "Xml";
            // 
            // exportToXmlToolStripMenuItem
            // 
            this.exportToXmlToolStripMenuItem.Name = "exportToXmlToolStripMenuItem";
            this.exportToXmlToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exportToXmlToolStripMenuItem.Text = "Export to Xml";
            this.exportToXmlToolStripMenuItem.Click += new System.EventHandler(this.exportToXmlToolStripMenuItem_Click);
            // 
            // importFromXmlToolStripMenuItem
            // 
            this.importFromXmlToolStripMenuItem.Name = "importFromXmlToolStripMenuItem";
            this.importFromXmlToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.importFromXmlToolStripMenuItem.Text = "Import from Xml";
            this.importFromXmlToolStripMenuItem.Click += new System.EventHandler(this.importFromXmlToolStripMenuItem_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 319);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(407, 0);
            this.panelBottom.TabIndex = 14;
            // 
            // openFileDialogXml
            // 
            this.openFileDialogXml.Filter = "Xml files |*.xml";
            // 
            // saveFileDialogXml
            // 
            this.saveFileDialogXml.Filter = "Xml files |*.xml";
            // 
            // UserControlSeriesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlSeriesTab";
            this.Size = new System.Drawing.Size(407, 319);
            this.panelCenter.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageChart.ResumeLayout(false);
            this.tabPageChart.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabPageTable.ResumeLayout(false);
            this.panelTable.ResumeLayout(false);
            this.panelBottomTable.ResumeLayout(false);
            this.panelBottomTable.PerformLayout();
            this.tabPageComments.ResumeLayout(false);
            this.tabPageGenerator.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageChart;
        private System.Windows.Forms.TabPage tabPageTable;
        private System.Windows.Forms.Panel panelTable;
        private UserControlSeriesTable userControlSeriesTable;
        private System.Windows.Forms.Panel panelRightTable;
        private System.Windows.Forms.Panel panelLeftTable;
        private System.Windows.Forms.Panel panelTopTable;
        private System.Windows.Forms.Panel panelBottomTable;
        private System.Windows.Forms.CheckBox checkBoxShow;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TabPage tabPageComments;
        private Diagram.UI.UserControls.UserControlCommentsFont userControlCommentsFont;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripComboBox toolStripButtonType;
        private OfficePickers.ColorPicker.ToolStripColorPicker pic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.StatusStrip statusStrip;
        private UserControlSeries userControlSeries;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCoord;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonXml;
        private System.Windows.Forms.ToolStripMenuItem exportToXmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromXmlToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogXml;
        private System.Windows.Forms.SaveFileDialog saveFileDialogXml;
        private System.Windows.Forms.TabPage tabPageGenerator;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private FormulaEditor.UI.UserControls.UserControlFormulaEditor userFormulaEditor;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.TextBox textBoxStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxStart;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.TextBox textBoxStepCount;
        private System.Windows.Forms.Label label2;
     }
}
