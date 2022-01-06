
namespace BasicEngineering.UI.Factory.Advanced.Forms
{
    partial class FormMain
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
            if (ResourceService.Resources.MissWriter != null)
            {
                ResourceService.Resources.MissWriter.Flush();
                ResourceService.Resources.MissWriter.Dispose();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.tabControlControls = new System.Windows.Forms.TabControl();
            this.panelToolBottom = new System.Windows.Forms.Panel();
            this.panelToolTop = new System.Windows.Forms.Panel();
            this.panelToolLeft = new System.Windows.Forms.Panel();
            this.panelTopLeft = new System.Windows.Forms.Panel();
            this.panelTopRight = new System.Windows.Forms.Panel();
            this.panelTopBottom = new System.Windows.Forms.Panel();
            this.panelTopTop = new System.Windows.Forms.Panel();
            this.panelToolRight = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusCurrentTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCurentTimeInd = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialogScn = new System.Windows.Forms.OpenFileDialog();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonToolBox = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFont = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSync = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxCheckDetails = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonTest = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonAnimation = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxStart = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxStep = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.stepCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxStepCount = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxPause = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemTimeIndicator = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxTimeIndicator = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPause = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDir = new System.Windows.Forms.ToolStripDropDownButton();
            this.soundDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSoundDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStrict = new System.Windows.Forms.ToolStripButton();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadfromdatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savetodatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSCADAXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletecommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearselectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeorderofselectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectTreelBarToolStripMenuItemObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.toolboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wizardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containerDesignerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.derivationCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorOfAliasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuGereratedFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.classNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxClassName = new System.Windows.Forms.ToolStripTextBox();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readWriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogScn = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialogScadaXml = new System.Windows.Forms.SaveFileDialog();
            this.panelTop.SuspendLayout();
            this.panelTopTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 55);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(3, 846);
            this.panelLeft.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(1370, 55);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1, 846);
            this.panelRight.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.tabControlControls);
            this.panelTop.Controls.Add(this.panelToolBottom);
            this.panelTop.Controls.Add(this.panelToolTop);
            this.panelTop.Controls.Add(this.panelToolLeft);
            this.panelTop.Controls.Add(this.panelTopLeft);
            this.panelTop.Controls.Add(this.panelTopRight);
            this.panelTop.Controls.Add(this.panelTopBottom);
            this.panelTop.Controls.Add(this.panelTopTop);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(3, 55);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1367, 77);
            this.panelTop.TabIndex = 2;
            // 
            // tabControlControls
            // 
            this.tabControlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlControls.Location = new System.Drawing.Point(88, 3);
            this.tabControlControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControlControls.Name = "tabControlControls";
            this.tabControlControls.SelectedIndex = 0;
            this.tabControlControls.Size = new System.Drawing.Size(1276, 71);
            this.tabControlControls.TabIndex = 7;
            // 
            // panelToolBottom
            // 
            this.panelToolBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelToolBottom.Location = new System.Drawing.Point(88, 74);
            this.panelToolBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelToolBottom.Name = "panelToolBottom";
            this.panelToolBottom.Size = new System.Drawing.Size(1276, 2);
            this.panelToolBottom.TabIndex = 6;
            // 
            // panelToolTop
            // 
            this.panelToolTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolTop.Location = new System.Drawing.Point(88, 1);
            this.panelToolTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelToolTop.Name = "panelToolTop";
            this.panelToolTop.Size = new System.Drawing.Size(1276, 2);
            this.panelToolTop.TabIndex = 5;
            // 
            // panelToolLeft
            // 
            this.panelToolLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelToolLeft.Location = new System.Drawing.Point(13, 1);
            this.panelToolLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelToolLeft.Name = "panelToolLeft";
            this.panelToolLeft.Size = new System.Drawing.Size(75, 75);
            this.panelToolLeft.TabIndex = 4;
            // 
            // panelTopLeft
            // 
            this.panelTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTopLeft.Location = new System.Drawing.Point(0, 1);
            this.panelTopLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTopLeft.Name = "panelTopLeft";
            this.panelTopLeft.Size = new System.Drawing.Size(13, 75);
            this.panelTopLeft.TabIndex = 3;
            // 
            // panelTopRight
            // 
            this.panelTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTopRight.Location = new System.Drawing.Point(1364, 1);
            this.panelTopRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTopRight.Name = "panelTopRight";
            this.panelTopRight.Size = new System.Drawing.Size(3, 75);
            this.panelTopRight.TabIndex = 2;
            // 
            // panelTopBottom
            // 
            this.panelTopBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTopBottom.Location = new System.Drawing.Point(0, 76);
            this.panelTopBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTopBottom.Name = "panelTopBottom";
            this.panelTopBottom.Size = new System.Drawing.Size(1367, 1);
            this.panelTopBottom.TabIndex = 1;
            // 
            // panelTopTop
            // 
            this.panelTopTop.Controls.Add(this.panelToolRight);
            this.panelTopTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopTop.Location = new System.Drawing.Point(0, 0);
            this.panelTopTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTopTop.Name = "panelTopTop";
            this.panelTopTop.Size = new System.Drawing.Size(1367, 1);
            this.panelTopTop.TabIndex = 0;
            // 
            // panelToolRight
            // 
            this.panelToolRight.Location = new System.Drawing.Point(1079, 11);
            this.panelToolRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelToolRight.Name = "panelToolRight";
            this.panelToolRight.Size = new System.Drawing.Size(21, 122);
            this.panelToolRight.TabIndex = 5;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.statusStrip);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(3, 867);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1367, 34);
            this.panelBottom.TabIndex = 3;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusCurrentTime,
            this.toolStripStatusLabelCurentTimeInd,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 12);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1367, 22);
            this.statusStrip.TabIndex = 28;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusCurrentTime
            // 
            this.toolStripStatusCurrentTime.Name = "toolStripStatusCurrentTime";
            this.toolStripStatusCurrentTime.Size = new System.Drawing.Size(0, 16);
            // 
            // toolStripStatusLabelCurentTimeInd
            // 
            this.toolStripStatusLabelCurentTimeInd.Name = "toolStripStatusLabelCurentTimeInd";
            this.toolStripStatusLabelCurentTimeInd.Size = new System.Drawing.Size(0, 16);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.panel2);
            this.panelCenter.Controls.Add(this.panel3);
            this.panelCenter.Controls.Add(this.panel4);
            this.panelCenter.Controls.Add(this.panel5);
            this.panelCenter.Controls.Add(this.panel1);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(3, 132);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(1367, 735);
            this.panelCenter.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 733);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1361, 2);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1364, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 733);
            this.panel3.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1364, 2);
            this.panel4.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(3, 735);
            this.panel5.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1367, 735);
            this.panel1.TabIndex = 9;
            // 
            // openFileDialogScn
            // 
            this.openFileDialogScn.Filter = "Configuration files |*.cfa;*.cont";
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.copyToolStripButton,
            this.toolStripSeparator2,
            this.pasteToolStripButton,
            this.cutToolStripButton,
            this.toolStripSeparator,
            this.printToolStripButton,
            this.saveToolStripButton,
            this.openToolStripButton,
            this.toolStripButtonClear,
            this.toolStripButtonRefresh,
            this.toolStripButtonToolBox,
            this.toolStripButtonFont,
            this.toolStripButtonSync,
            this.toolStripComboBoxCheckDetails,
            this.toolStripButtonTest,
            this.toolStripDropDownButtonAnimation,
            this.toolStripButtonStart,
            this.toolStripButtonPause,
            this.toolStripButtonStop,
            this.toolStripButtonDir,
            this.helpToolStripButton,
            this.toolStripButtonStrict});
            this.toolStripMain.Location = new System.Drawing.Point(0, 28);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1371, 27);
            this.toolStripMain.TabIndex = 5;
            this.toolStripMain.Text = "Main";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(29, 25);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Visible = false;
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.pasteToolStripButton.Text = "&Paste";
            this.pasteToolStripButton.Click += new System.EventHandler(this.toolStripButtonPaste_Click);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.cutToolStripButton.Text = "C&ut";
            this.cutToolStripButton.Click += new System.EventHandler(this.toolStripButtonCut_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(29, 25);
            this.printToolStripButton.Text = "&Print";
            this.printToolStripButton.Visible = false;
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveControl);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // toolStripButtonClear
            // 
            this.toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClear.Image")));
            this.toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClear.Name = "toolStripButtonClear";
            this.toolStripButtonClear.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonClear.Text = "Clear";
            this.toolStripButtonClear.Click += new System.EventHandler(this.toolStripButtonClear_Click);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripButtonToolBox
            // 
            this.toolStripButtonToolBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonToolBox.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonToolBox.Image")));
            this.toolStripButtonToolBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonToolBox.Name = "toolStripButtonToolBox";
            this.toolStripButtonToolBox.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonToolBox.Text = "Toolbox";
            this.toolStripButtonToolBox.Visible = false;
            // 
            // toolStripButtonFont
            // 
            this.toolStripButtonFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFont.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFont.Image")));
            this.toolStripButtonFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFont.Name = "toolStripButtonFont";
            this.toolStripButtonFont.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonFont.Text = "Font";
            this.toolStripButtonFont.Click += new System.EventHandler(this.toolStripButtonFont_Click);
            // 
            // toolStripButtonSync
            // 
            this.toolStripButtonSync.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSync.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSync.Image")));
            this.toolStripButtonSync.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSync.Name = "toolStripButtonSync";
            this.toolStripButtonSync.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonSync.Text = "Sync";
            this.toolStripButtonSync.Click += new System.EventHandler(this.toolStripButtonSync_Click);
            // 
            // toolStripComboBoxCheckDetails
            // 
            this.toolStripComboBoxCheckDetails.Items.AddRange(new object[] {
            "Full check",
            "Lite check"});
            this.toolStripComboBoxCheckDetails.Name = "toolStripComboBoxCheckDetails";
            this.toolStripComboBoxCheckDetails.Size = new System.Drawing.Size(160, 28);
            this.toolStripComboBoxCheckDetails.Visible = false;
            // 
            // toolStripButtonTest
            // 
            this.toolStripButtonTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTest.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTest.Image")));
            this.toolStripButtonTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTest.Name = "toolStripButtonTest";
            this.toolStripButtonTest.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonTest.ToolTipText = "Test";
            this.toolStripButtonTest.Visible = false;
            this.toolStripButtonTest.Click += new System.EventHandler(this.toolStripButtonTest_Click);
            // 
            // toolStripDropDownButtonAnimation
            // 
            this.toolStripDropDownButtonAnimation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonAnimation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripTextBoxStart,
            this.toolStripSeparator11,
            this.stepToolStripMenuItem,
            this.toolStripTextBoxStep,
            this.toolStripSeparator7,
            this.stepCountToolStripMenuItem,
            this.toolStripTextBoxStepCount,
            this.toolStripSeparator10,
            this.pauseToolStripMenuItem,
            this.toolStripTextBoxPause,
            this.toolStripSeparator6,
            this.toolStripMenuItemTimeIndicator,
            this.toolStripTextBoxTimeIndicator});
            this.toolStripDropDownButtonAnimation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonAnimation.Image")));
            this.toolStripDropDownButtonAnimation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonAnimation.Name = "toolStripDropDownButtonAnimation";
            this.toolStripDropDownButtonAnimation.Size = new System.Drawing.Size(92, 24);
            this.toolStripDropDownButtonAnimation.Text = "Animation";
            this.toolStripDropDownButtonAnimation.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripDropDownButtonAnimation.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(227, 26);
            this.toolStripMenuItem1.Text = "Start time";
            // 
            // toolStripTextBoxStart
            // 
            this.toolStripTextBoxStart.Name = "toolStripTextBoxStart";
            this.toolStripTextBoxStart.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(224, 6);
            // 
            // stepToolStripMenuItem
            // 
            this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            this.stepToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.stepToolStripMenuItem.Text = "Step";
            // 
            // toolStripTextBoxStep
            // 
            this.toolStripTextBoxStep.Name = "toolStripTextBoxStep";
            this.toolStripTextBoxStep.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(224, 6);
            // 
            // stepCountToolStripMenuItem
            // 
            this.stepCountToolStripMenuItem.Name = "stepCountToolStripMenuItem";
            this.stepCountToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.stepCountToolStripMenuItem.Text = "Step count";
            // 
            // toolStripTextBoxStepCount
            // 
            this.toolStripTextBoxStepCount.Name = "toolStripTextBoxStepCount";
            this.toolStripTextBoxStepCount.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(224, 6);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.pauseToolStripMenuItem.Text = "Pause";
            // 
            // toolStripTextBoxPause
            // 
            this.toolStripTextBoxPause.Name = "toolStripTextBoxPause";
            this.toolStripTextBoxPause.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(224, 6);
            // 
            // toolStripMenuItemTimeIndicator
            // 
            this.toolStripMenuItemTimeIndicator.Name = "toolStripMenuItemTimeIndicator";
            this.toolStripMenuItemTimeIndicator.Size = new System.Drawing.Size(227, 26);
            this.toolStripMenuItemTimeIndicator.Text = "Time indication step";
            // 
            // toolStripTextBoxTimeIndicator
            // 
            this.toolStripTextBoxTimeIndicator.Name = "toolStripTextBoxTimeIndicator";
            this.toolStripTextBoxTimeIndicator.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStart.Image")));
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonStart.Text = "Start animation";
            this.toolStripButtonStart.Visible = false;
            this.toolStripButtonStart.Click += new System.EventHandler(this.toolStripButtonStart_Click);
            // 
            // toolStripButtonPause
            // 
            this.toolStripButtonPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPause.Enabled = false;
            this.toolStripButtonPause.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPause.Image")));
            this.toolStripButtonPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPause.Name = "toolStripButtonPause";
            this.toolStripButtonPause.Size = new System.Drawing.Size(29, 24);
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
            this.toolStripButtonStop.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonStop.Text = "Stop";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // toolStripButtonDir
            // 
            this.toolStripButtonDir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soundDirectoryToolStripMenuItem,
            this.toolStripMenuItemSoundDirectory,
            this.browseToolStripMenuItem});
            this.toolStripButtonDir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDir.Image")));
            this.toolStripButtonDir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDir.Name = "toolStripButtonDir";
            this.toolStripButtonDir.Size = new System.Drawing.Size(34, 24);
            this.toolStripButtonDir.Text = "Audio";
            // 
            // soundDirectoryToolStripMenuItem
            // 
            this.soundDirectoryToolStripMenuItem.Name = "soundDirectoryToolStripMenuItem";
            this.soundDirectoryToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.soundDirectoryToolStripMenuItem.Text = "Sound directory";
            // 
            // toolStripMenuItemSoundDirectory
            // 
            this.toolStripMenuItemSoundDirectory.Name = "toolStripMenuItemSoundDirectory";
            this.toolStripMenuItemSoundDirectory.Size = new System.Drawing.Size(197, 26);
            // 
            // browseToolStripMenuItem
            // 
            this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            this.browseToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.browseToolStripMenuItem.Text = "Browse...";
            this.browseToolStripMenuItem.Click += new System.EventHandler(this.browseToolStripMenuItem_Click);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Visible = false;
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // toolStripButtonStrict
            // 
            this.toolStripButtonStrict.Checked = true;
            this.toolStripButtonStrict.CheckOnClick = true;
            this.toolStripButtonStrict.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonStrict.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonStrict.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStrict.Image")));
            this.toolStripButtonStrict.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStrict.Name = "toolStripButtonStrict";
            this.toolStripButtonStrict.Size = new System.Drawing.Size(47, 24);
            this.toolStripButtonStrict.Text = "Strict";
            this.toolStripButtonStrict.Visible = false;
            this.toolStripButtonStrict.Click += new System.EventHandler(this.toolStripButtonStrict_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewMenu,
            this.toolsToolStripMenuItem1,
            this.wizardsToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.checkDesktopToolStripMenuItem,
            this.saveLogsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.openLogDirectoryToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(1371, 28);
            this.menuStripMain.TabIndex = 6;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.loadfromdatabaseToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.savetodatabaseToolStripMenuItem,
            this.saveSCADAXMLToolStripMenuItem,
            this.toolStripSeparator12,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // loadfromdatabaseToolStripMenuItem
            // 
            this.loadfromdatabaseToolStripMenuItem.Name = "loadfromdatabaseToolStripMenuItem";
            this.loadfromdatabaseToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.loadfromdatabaseToolStripMenuItem.Text = "Load from database";
            this.loadfromdatabaseToolStripMenuItem.Click += new System.EventHandler(this.loadfromdatabaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveControl);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveasToolStripMenuItem_Click);
            // 
            // savetodatabaseToolStripMenuItem
            // 
            this.savetodatabaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("savetodatabaseToolStripMenuItem.Image")));
            this.savetodatabaseToolStripMenuItem.Name = "savetodatabaseToolStripMenuItem";
            this.savetodatabaseToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.savetodatabaseToolStripMenuItem.Text = "Save to database";
            this.savetodatabaseToolStripMenuItem.Click += new System.EventHandler(this.savetodatabaseToolStripMenuItem_Click);
            // 
            // saveSCADAXMLToolStripMenuItem
            // 
            this.saveSCADAXMLToolStripMenuItem.Name = "saveSCADAXMLToolStripMenuItem";
            this.saveSCADAXMLToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.saveSCADAXMLToolStripMenuItem.Text = "Save SCADA XML";
            this.saveSCADAXMLToolStripMenuItem.Click += new System.EventHandler(this.saveSCADAXMLToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(223, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator9,
            this.selectAllToolStripMenuItem,
            this.deletecommentsToolStripMenuItem,
            this.clearselectedToolStripMenuItem,
            this.clearallToolStripMenuItem,
            this.changeorderofselectedToolStripMenuItem,
            this.unselectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
            this.undoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoToolStripMenuItem.Image")));
            this.redoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.cutToolStripMenuItem.Text = "Cu&t";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.pasteToolStripMenuItem.Text = "&Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(256, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // deletecommentsToolStripMenuItem
            // 
            this.deletecommentsToolStripMenuItem.Name = "deletecommentsToolStripMenuItem";
            this.deletecommentsToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.deletecommentsToolStripMenuItem.Text = "Delete comments";
            this.deletecommentsToolStripMenuItem.Click += new System.EventHandler(this.deletecommentsToolStripMenuItem_Click);
            // 
            // clearselectedToolStripMenuItem
            // 
            this.clearselectedToolStripMenuItem.Name = "clearselectedToolStripMenuItem";
            this.clearselectedToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.clearselectedToolStripMenuItem.Text = "Clear selected";
            this.clearselectedToolStripMenuItem.Visible = false;
            this.clearselectedToolStripMenuItem.Click += new System.EventHandler(this.clearselectedToolStripMenuItem_Click);
            // 
            // clearallToolStripMenuItem
            // 
            this.clearallToolStripMenuItem.Name = "clearallToolStripMenuItem";
            this.clearallToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.clearallToolStripMenuItem.Text = "Clear all";
            this.clearallToolStripMenuItem.Click += new System.EventHandler(this.clearallToolStripMenuItem_Click);
            // 
            // changeorderofselectedToolStripMenuItem
            // 
            this.changeorderofselectedToolStripMenuItem.Name = "changeorderofselectedToolStripMenuItem";
            this.changeorderofselectedToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.changeorderofselectedToolStripMenuItem.Text = "Change order of selected";
            this.changeorderofselectedToolStripMenuItem.Click += new System.EventHandler(this.changeorderofselectedToolStripMenuItem_Click);
            // 
            // unselectAllToolStripMenuItem
            // 
            this.unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            this.unselectAllToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.unselectAllToolStripMenuItem.Text = "Unselect All";
            this.unselectAllToolStripMenuItem.Click += new System.EventHandler(this.unselectAllToolStripMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.Checked = true;
            this.viewMenu.CheckOnClick = true;
            this.viewMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarToolStripMenuItem,
            this.objectTreelBarToolStripMenuItemObjects,
            this.toolboxToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.messagesToolStripMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(55, 24);
            this.viewMenu.Text = "&View";
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.statusBarToolStripMenuItem.Text = "&Status Bar";
            // 
            // objectTreelBarToolStripMenuItemObjects
            // 
            this.objectTreelBarToolStripMenuItemObjects.Checked = true;
            this.objectTreelBarToolStripMenuItemObjects.CheckOnClick = true;
            this.objectTreelBarToolStripMenuItemObjects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.objectTreelBarToolStripMenuItemObjects.Image = ((System.Drawing.Image)(resources.GetObject("objectTreelBarToolStripMenuItemObjects.Image")));
            this.objectTreelBarToolStripMenuItemObjects.Name = "objectTreelBarToolStripMenuItemObjects";
            this.objectTreelBarToolStripMenuItemObjects.Size = new System.Drawing.Size(175, 26);
            this.objectTreelBarToolStripMenuItemObjects.Text = "Objects\' tree";
            this.objectTreelBarToolStripMenuItemObjects.Click += new System.EventHandler(this.objectTreelBarToolStripMenuItemObjects_Click);
            // 
            // toolboxToolStripMenuItem
            // 
            this.toolboxToolStripMenuItem.Checked = true;
            this.toolboxToolStripMenuItem.CheckOnClick = true;
            this.toolboxToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolboxToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toolboxToolStripMenuItem.Image")));
            this.toolboxToolStripMenuItem.Name = "toolboxToolStripMenuItem";
            this.toolboxToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.toolboxToolStripMenuItem.Text = "Toolbox";
            this.toolboxToolStripMenuItem.Click += new System.EventHandler(this.toolboxToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.Checked = true;
            this.dataToolStripMenuItem.CheckOnClick = true;
            this.dataToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dataToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dataToolStripMenuItem.Image")));
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.dataToolStripMenuItem.Text = "Database";
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.dataToolStripMenuItem_Click);
            // 
            // messagesToolStripMenuItem
            // 
            this.messagesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("messagesToolStripMenuItem.Image")));
            this.messagesToolStripMenuItem.Name = "messagesToolStripMenuItem";
            this.messagesToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.messagesToolStripMenuItem.Text = "Warnings";
            this.messagesToolStripMenuItem.Click += new System.EventHandler(this.messagesToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem1
            // 
            this.toolsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem1.Name = "toolsToolStripMenuItem1";
            this.toolsToolStripMenuItem1.Size = new System.Drawing.Size(58, 24);
            this.toolsToolStripMenuItem1.Text = "&Tools";
            this.toolsToolStripMenuItem1.Visible = false;
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // wizardsToolStripMenuItem
            // 
            this.wizardsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.containerDesignerToolStripMenuItem,
            this.derivationCalculatorToolStripMenuItem,
            this.editorOfAliasesToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuGereratedFiles,
            this.classNameToolStripMenuItem,
            this.toolStripTextBoxClassName});
            this.wizardsToolStripMenuItem.Name = "wizardsToolStripMenuItem";
            this.wizardsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.wizardsToolStripMenuItem.Text = "Wizards";
            // 
            // containerDesignerToolStripMenuItem
            // 
            this.containerDesignerToolStripMenuItem.Name = "containerDesignerToolStripMenuItem";
            this.containerDesignerToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.containerDesignerToolStripMenuItem.Text = "Container designer";
            this.containerDesignerToolStripMenuItem.Click += new System.EventHandler(this.containerDesignerToolStripMenuItem_Click);
            // 
            // derivationCalculatorToolStripMenuItem
            // 
            this.derivationCalculatorToolStripMenuItem.Name = "derivationCalculatorToolStripMenuItem";
            this.derivationCalculatorToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.derivationCalculatorToolStripMenuItem.Text = "Derivation calculator";
            this.derivationCalculatorToolStripMenuItem.Click += new System.EventHandler(this.derivationCalculatorToolStripMenuItem_Click);
            // 
            // editorOfAliasesToolStripMenuItem
            // 
            this.editorOfAliasesToolStripMenuItem.Name = "editorOfAliasesToolStripMenuItem";
            this.editorOfAliasesToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.editorOfAliasesToolStripMenuItem.Text = "Editor of aliases";
            this.editorOfAliasesToolStripMenuItem.Click += new System.EventHandler(this.editorOfAliasesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(271, 6);
            // 
            // toolStripMenuGereratedFiles
            // 
            this.toolStripMenuGereratedFiles.Name = "toolStripMenuGereratedFiles";
            this.toolStripMenuGereratedFiles.Size = new System.Drawing.Size(274, 26);
            this.toolStripMenuGereratedFiles.Text = "Directory of generated files";
            this.toolStripMenuGereratedFiles.Click += new System.EventHandler(this.toolStripMenuGereratedFiles_Click);
            // 
            // classNameToolStripMenuItem
            // 
            this.classNameToolStripMenuItem.Name = "classNameToolStripMenuItem";
            this.classNameToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.classNameToolStripMenuItem.Text = "Class name";
            // 
            // toolStripTextBoxClassName
            // 
            this.toolStripTextBoxClassName.Name = "toolStripTextBoxClassName";
            this.toolStripTextBoxClassName.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBoxClassName.Text = "GeneratedProject";
            this.toolStripTextBoxClassName.TextChanged += new System.EventHandler(this.toolStripTextBoxClassName_TextChanged);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.readWriteToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // readWriteToolStripMenuItem
            // 
            this.readWriteToolStripMenuItem.Name = "readWriteToolStripMenuItem";
            this.readWriteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.readWriteToolStripMenuItem.Text = "Read";
            this.readWriteToolStripMenuItem.Click += new System.EventHandler(this.readWriteToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // checkDesktopToolStripMenuItem
            // 
            this.checkDesktopToolStripMenuItem.Name = "checkDesktopToolStripMenuItem";
            this.checkDesktopToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.checkDesktopToolStripMenuItem.Text = "Check desktop";
            this.checkDesktopToolStripMenuItem.Click += new System.EventHandler(this.checkDesktopToolStripMenuItem_Click);
            // 
            // saveLogsToolStripMenuItem
            // 
            this.saveLogsToolStripMenuItem.Enabled = false;
            this.saveLogsToolStripMenuItem.Name = "saveLogsToolStripMenuItem";
            this.saveLogsToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.saveLogsToolStripMenuItem.Text = "Save logs";
            this.saveLogsToolStripMenuItem.Visible = false;
            this.saveLogsToolStripMenuItem.Click += new System.EventHandler(this.saveLogsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(147, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.generateToolStripMenuItem.Text = "Generate";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // openLogDirectoryToolStripMenuItem
            // 
            this.openLogDirectoryToolStripMenuItem.Name = "openLogDirectoryToolStripMenuItem";
            this.openLogDirectoryToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.openLogDirectoryToolStripMenuItem.Text = "Open Log directory";
            this.openLogDirectoryToolStripMenuItem.Visible = false;
            this.openLogDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openLogDirectoryToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // saveFileDialogScn
            // 
            this.saveFileDialogScn.Filter = "Astronomy configuration files |*.cfa";
            // 
            // saveFileDialogScadaXml
            // 
            this.saveFileDialogScadaXml.Filter = "Xml Files|*.xml";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1371, 901);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "Astronomy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTopTop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelTopTop;
        private System.Windows.Forms.Panel panelTopBottom;
        private System.Windows.Forms.Panel panelTopRight;
        private System.Windows.Forms.Panel panelTopLeft;
        private System.Windows.Forms.OpenFileDialog openFileDialogScn;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wizardsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogScn;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearselectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletecommentsToolStripMenuItem;
        private System.Windows.Forms.Panel panelToolLeft;
        private System.Windows.Forms.Panel panelToolRight;
        private System.Windows.Forms.Panel panelToolTop;
        private System.Windows.Forms.Panel panelToolBottom;
        private System.Windows.Forms.TabControl tabControlControls;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButtonToolBox;
        private System.Windows.Forms.ToolStripButton toolStripButtonFont;
        private System.Windows.Forms.ToolStripButton toolStripButtonClear;
        private System.Windows.Forms.ToolStripMenuItem loadfromdatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem savetodatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeorderofselectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonSync;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem derivationCalculatorToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem containerDesignerToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonTest;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectTreelBarToolStripMenuItemObjects;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolboxToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCurentTimeInd;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readWriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxCheckDetails;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonAnimation;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxStart;
        private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxStep;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem stepCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxStepCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxPause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton toolStripButtonStrict;
        private System.Windows.Forms.ToolStripButton toolStripButtonPause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTimeIndicator;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxTimeIndicator;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCurrentTime;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonDir;
        private System.Windows.Forms.ToolStripMenuItem soundDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSoundDirectory;
        private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorOfAliasesToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem saveSCADAXMLToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogScadaXml;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuGereratedFiles;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxClassName;
    }
}

