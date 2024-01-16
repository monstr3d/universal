
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            panelLeft = new System.Windows.Forms.Panel();
            panelRight = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            tabControlControls = new System.Windows.Forms.TabControl();
            panelToolBottom = new System.Windows.Forms.Panel();
            panelToolTop = new System.Windows.Forms.Panel();
            panelToolLeft = new System.Windows.Forms.Panel();
            panelTopLeft = new System.Windows.Forms.Panel();
            panelTopRight = new System.Windows.Forms.Panel();
            panelTopBottom = new System.Windows.Forms.Panel();
            panelTopTop = new System.Windows.Forms.Panel();
            panelToolRight = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            statusStrip = new System.Windows.Forms.StatusStrip();
            toolStripStatusCurrentTime = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelCurentTimeInd = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            panelCenter = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            panel4 = new System.Windows.Forms.Panel();
            panel5 = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            openFileDialogScn = new System.Windows.Forms.OpenFileDialog();
            toolStripMain = new System.Windows.Forms.ToolStrip();
            newToolStripButton = new System.Windows.Forms.ToolStripButton();
            copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            printToolStripButton = new System.Windows.Forms.ToolStripButton();
            saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            openToolStripButton = new System.Windows.Forms.ToolStripButton();
            toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            toolStripButtonToolBox = new System.Windows.Forms.ToolStripButton();
            toolStripButtonFont = new System.Windows.Forms.ToolStripButton();
            toolStripButtonSync = new System.Windows.Forms.ToolStripButton();
            toolStripComboBoxCheckDetails = new System.Windows.Forms.ToolStripComboBox();
            toolStripButtonTest = new System.Windows.Forms.ToolStripButton();
            toolStripDropDownButtonAnimation = new System.Windows.Forms.ToolStripDropDownButton();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripTextBoxStart = new System.Windows.Forms.ToolStripTextBox();
            toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripTextBoxStep = new System.Windows.Forms.ToolStripTextBox();
            toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            stepCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripTextBoxStepCount = new System.Windows.Forms.ToolStripTextBox();
            toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripTextBoxPause = new System.Windows.Forms.ToolStripTextBox();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItemTimeIndicator = new System.Windows.Forms.ToolStripMenuItem();
            toolStripTextBoxTimeIndicator = new System.Windows.Forms.ToolStripTextBox();
            toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            toolStripButtonPause = new System.Windows.Forms.ToolStripButton();
            toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            toolStripButtonDir = new System.Windows.Forms.ToolStripDropDownButton();
            soundDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemSoundDirectory = new System.Windows.Forms.ToolStripMenuItem();
            browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            toolStripButtonStrict = new System.Windows.Forms.ToolStripButton();
            menuStripMain = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            loadfromdatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            savetodatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveSCADAXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deletecommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearselectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            changeorderofselectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            objectTreelBarToolStripMenuItemObjects = new System.Windows.Forms.ToolStripMenuItem();
            toolboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            messagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            wizardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            containerDesignerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            derivationCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editorOfAliasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuGereratedFiles = new System.Windows.Forms.ToolStripMenuItem();
            classNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripTextBoxClassName = new System.Windows.Forms.ToolStripTextBox();
            databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            readWriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            checkDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openLogDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveFileDialogScn = new System.Windows.Forms.SaveFileDialog();
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            saveFileDialogScadaXml = new System.Windows.Forms.SaveFileDialog();
            openInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panelTop.SuspendLayout();
            panelTopTop.SuspendLayout();
            panelBottom.SuspendLayout();
            statusStrip.SuspendLayout();
            panelCenter.SuspendLayout();
            toolStripMain.SuspendLayout();
            menuStripMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 51);
            panelLeft.Margin = new System.Windows.Forms.Padding(4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(3, 625);
            panelLeft.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(1199, 51);
            panelRight.Margin = new System.Windows.Forms.Padding(4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(1, 625);
            panelRight.TabIndex = 1;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(tabControlControls);
            panelTop.Controls.Add(panelToolBottom);
            panelTop.Controls.Add(panelToolTop);
            panelTop.Controls.Add(panelToolLeft);
            panelTop.Controls.Add(panelTopLeft);
            panelTop.Controls.Add(panelTopRight);
            panelTop.Controls.Add(panelTopBottom);
            panelTop.Controls.Add(panelTopTop);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(3, 51);
            panelTop.Margin = new System.Windows.Forms.Padding(4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(1196, 58);
            panelTop.TabIndex = 2;
            // 
            // tabControlControls
            // 
            tabControlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlControls.Location = new System.Drawing.Point(77, 3);
            tabControlControls.Margin = new System.Windows.Forms.Padding(4);
            tabControlControls.Name = "tabControlControls";
            tabControlControls.SelectedIndex = 0;
            tabControlControls.Size = new System.Drawing.Size(1116, 52);
            tabControlControls.TabIndex = 7;
            // 
            // panelToolBottom
            // 
            panelToolBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelToolBottom.Location = new System.Drawing.Point(77, 55);
            panelToolBottom.Margin = new System.Windows.Forms.Padding(4);
            panelToolBottom.Name = "panelToolBottom";
            panelToolBottom.Size = new System.Drawing.Size(1116, 2);
            panelToolBottom.TabIndex = 6;
            // 
            // panelToolTop
            // 
            panelToolTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelToolTop.Location = new System.Drawing.Point(77, 1);
            panelToolTop.Margin = new System.Windows.Forms.Padding(4);
            panelToolTop.Name = "panelToolTop";
            panelToolTop.Size = new System.Drawing.Size(1116, 2);
            panelToolTop.TabIndex = 5;
            // 
            // panelToolLeft
            // 
            panelToolLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelToolLeft.Location = new System.Drawing.Point(11, 1);
            panelToolLeft.Margin = new System.Windows.Forms.Padding(4);
            panelToolLeft.Name = "panelToolLeft";
            panelToolLeft.Size = new System.Drawing.Size(66, 56);
            panelToolLeft.TabIndex = 4;
            // 
            // panelTopLeft
            // 
            panelTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelTopLeft.Location = new System.Drawing.Point(0, 1);
            panelTopLeft.Margin = new System.Windows.Forms.Padding(4);
            panelTopLeft.Name = "panelTopLeft";
            panelTopLeft.Size = new System.Drawing.Size(11, 56);
            panelTopLeft.TabIndex = 3;
            // 
            // panelTopRight
            // 
            panelTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelTopRight.Location = new System.Drawing.Point(1193, 1);
            panelTopRight.Margin = new System.Windows.Forms.Padding(4);
            panelTopRight.Name = "panelTopRight";
            panelTopRight.Size = new System.Drawing.Size(3, 56);
            panelTopRight.TabIndex = 2;
            // 
            // panelTopBottom
            // 
            panelTopBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelTopBottom.Location = new System.Drawing.Point(0, 57);
            panelTopBottom.Margin = new System.Windows.Forms.Padding(4);
            panelTopBottom.Name = "panelTopBottom";
            panelTopBottom.Size = new System.Drawing.Size(1196, 1);
            panelTopBottom.TabIndex = 1;
            // 
            // panelTopTop
            // 
            panelTopTop.Controls.Add(panelToolRight);
            panelTopTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTopTop.Location = new System.Drawing.Point(0, 0);
            panelTopTop.Margin = new System.Windows.Forms.Padding(4);
            panelTopTop.Name = "panelTopTop";
            panelTopTop.Size = new System.Drawing.Size(1196, 1);
            panelTopTop.TabIndex = 0;
            // 
            // panelToolRight
            // 
            panelToolRight.Location = new System.Drawing.Point(944, 8);
            panelToolRight.Margin = new System.Windows.Forms.Padding(4);
            panelToolRight.Name = "panelToolRight";
            panelToolRight.Size = new System.Drawing.Size(18, 92);
            panelToolRight.TabIndex = 5;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(statusStrip);
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(3, 650);
            panelBottom.Margin = new System.Windows.Forms.Padding(4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(1196, 26);
            panelBottom.TabIndex = 3;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusCurrentTime, toolStripStatusLabelCurentTimeInd, toolStripStatusLabel });
            statusStrip.Location = new System.Drawing.Point(0, 4);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
            statusStrip.Size = new System.Drawing.Size(1196, 22);
            statusStrip.TabIndex = 28;
            statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusCurrentTime
            // 
            toolStripStatusCurrentTime.Name = "toolStripStatusCurrentTime";
            toolStripStatusCurrentTime.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabelCurentTimeInd
            // 
            toolStripStatusLabelCurentTimeInd.Name = "toolStripStatusLabelCurentTimeInd";
            toolStripStatusLabelCurentTimeInd.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(panel2);
            panelCenter.Controls.Add(panel3);
            panelCenter.Controls.Add(panel4);
            panelCenter.Controls.Add(panel5);
            panelCenter.Controls.Add(panel1);
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(3, 109);
            panelCenter.Margin = new System.Windows.Forms.Padding(4);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(1196, 541);
            panelCenter.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(3, 539);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1190, 2);
            panel2.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.Dock = System.Windows.Forms.DockStyle.Right;
            panel3.Location = new System.Drawing.Point(1193, 2);
            panel3.Margin = new System.Windows.Forms.Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(3, 539);
            panel3.TabIndex = 7;
            // 
            // panel4
            // 
            panel4.Dock = System.Windows.Forms.DockStyle.Top;
            panel4.Location = new System.Drawing.Point(3, 0);
            panel4.Margin = new System.Windows.Forms.Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(1193, 2);
            panel4.TabIndex = 6;
            // 
            // panel5
            // 
            panel5.Dock = System.Windows.Forms.DockStyle.Left;
            panel5.Location = new System.Drawing.Point(0, 0);
            panel5.Margin = new System.Windows.Forms.Padding(4);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(3, 541);
            panel5.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1196, 541);
            panel1.TabIndex = 9;
            // 
            // openFileDialogScn
            // 
            openFileDialogScn.Filter = "Configuration files |*.cfa;*.cont";
            // 
            // toolStripMain
            // 
            toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { newToolStripButton, copyToolStripButton, toolStripSeparator2, pasteToolStripButton, cutToolStripButton, toolStripSeparator, printToolStripButton, saveToolStripButton, openToolStripButton, toolStripButtonClear, toolStripButtonRefresh, toolStripButtonToolBox, toolStripButtonFont, toolStripButtonSync, toolStripComboBoxCheckDetails, toolStripButtonTest, toolStripDropDownButtonAnimation, toolStripButtonStart, toolStripButtonPause, toolStripButtonStop, toolStripButtonDir, helpToolStripButton, toolStripButtonStrict });
            toolStripMain.Location = new System.Drawing.Point(0, 24);
            toolStripMain.Name = "toolStripMain";
            toolStripMain.Size = new System.Drawing.Size(1200, 27);
            toolStripMain.TabIndex = 5;
            toolStripMain.Text = "Main";
            // 
            // newToolStripButton
            // 
            newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            newToolStripButton.Image = (System.Drawing.Image)resources.GetObject("newToolStripButton.Image");
            newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            newToolStripButton.Name = "newToolStripButton";
            newToolStripButton.Size = new System.Drawing.Size(24, 24);
            newToolStripButton.Text = "&New";
            newToolStripButton.Visible = false;
            // 
            // copyToolStripButton
            // 
            copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            copyToolStripButton.Image = (System.Drawing.Image)resources.GetObject("copyToolStripButton.Image");
            copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            copyToolStripButton.Name = "copyToolStripButton";
            copyToolStripButton.Size = new System.Drawing.Size(24, 24);
            copyToolStripButton.Text = "&Copy";
            copyToolStripButton.Click += toolStripButtonCopy_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // pasteToolStripButton
            // 
            pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            pasteToolStripButton.Image = (System.Drawing.Image)resources.GetObject("pasteToolStripButton.Image");
            pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            pasteToolStripButton.Name = "pasteToolStripButton";
            pasteToolStripButton.Size = new System.Drawing.Size(24, 24);
            pasteToolStripButton.Text = "&Paste";
            pasteToolStripButton.Click += toolStripButtonPaste_Click;
            // 
            // cutToolStripButton
            // 
            cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            cutToolStripButton.Image = (System.Drawing.Image)resources.GetObject("cutToolStripButton.Image");
            cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            cutToolStripButton.Name = "cutToolStripButton";
            cutToolStripButton.Size = new System.Drawing.Size(24, 24);
            cutToolStripButton.Text = "C&ut";
            cutToolStripButton.Click += toolStripButtonCut_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // printToolStripButton
            // 
            printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            printToolStripButton.Image = (System.Drawing.Image)resources.GetObject("printToolStripButton.Image");
            printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            printToolStripButton.Name = "printToolStripButton";
            printToolStripButton.Size = new System.Drawing.Size(24, 24);
            printToolStripButton.Text = "&Print";
            printToolStripButton.Visible = false;
            // 
            // saveToolStripButton
            // 
            saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            saveToolStripButton.Image = (System.Drawing.Image)resources.GetObject("saveToolStripButton.Image");
            saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveToolStripButton.Name = "saveToolStripButton";
            saveToolStripButton.Size = new System.Drawing.Size(24, 24);
            saveToolStripButton.Text = "&Save";
            saveToolStripButton.Click += saveControl;
            // 
            // openToolStripButton
            // 
            openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            openToolStripButton.Image = (System.Drawing.Image)resources.GetObject("openToolStripButton.Image");
            openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            openToolStripButton.Name = "openToolStripButton";
            openToolStripButton.Size = new System.Drawing.Size(24, 24);
            openToolStripButton.Text = "&Open";
            openToolStripButton.Click += openToolStripButton_Click;
            // 
            // toolStripButtonClear
            // 
            toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonClear.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonClear.Image");
            toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonClear.Name = "toolStripButtonClear";
            toolStripButtonClear.Size = new System.Drawing.Size(24, 24);
            toolStripButtonClear.Text = "Clear";
            toolStripButtonClear.Click += toolStripButtonClear_Click;
            // 
            // toolStripButtonRefresh
            // 
            toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonRefresh.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonRefresh.Image");
            toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            toolStripButtonRefresh.Size = new System.Drawing.Size(24, 24);
            toolStripButtonRefresh.Text = "Refresh";
            toolStripButtonRefresh.Click += toolStripButtonRefresh_Click;
            // 
            // toolStripButtonToolBox
            // 
            toolStripButtonToolBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonToolBox.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonToolBox.Image");
            toolStripButtonToolBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonToolBox.Name = "toolStripButtonToolBox";
            toolStripButtonToolBox.Size = new System.Drawing.Size(24, 24);
            toolStripButtonToolBox.Text = "Toolbox";
            toolStripButtonToolBox.Visible = false;
            // 
            // toolStripButtonFont
            // 
            toolStripButtonFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonFont.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonFont.Image");
            toolStripButtonFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonFont.Name = "toolStripButtonFont";
            toolStripButtonFont.Size = new System.Drawing.Size(24, 24);
            toolStripButtonFont.Text = "Font";
            toolStripButtonFont.Click += toolStripButtonFont_Click;
            // 
            // toolStripButtonSync
            // 
            toolStripButtonSync.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonSync.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonSync.Image");
            toolStripButtonSync.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonSync.Name = "toolStripButtonSync";
            toolStripButtonSync.Size = new System.Drawing.Size(24, 24);
            toolStripButtonSync.Text = "Sync";
            toolStripButtonSync.Click += toolStripButtonSync_Click;
            // 
            // toolStripComboBoxCheckDetails
            // 
            toolStripComboBoxCheckDetails.Items.AddRange(new object[] { "Full check", "Lite check" });
            toolStripComboBoxCheckDetails.Name = "toolStripComboBoxCheckDetails";
            toolStripComboBoxCheckDetails.Size = new System.Drawing.Size(140, 27);
            toolStripComboBoxCheckDetails.Visible = false;
            // 
            // toolStripButtonTest
            // 
            toolStripButtonTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonTest.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonTest.Image");
            toolStripButtonTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonTest.Name = "toolStripButtonTest";
            toolStripButtonTest.Size = new System.Drawing.Size(24, 24);
            toolStripButtonTest.ToolTipText = "Test";
            toolStripButtonTest.Visible = false;
            toolStripButtonTest.Click += toolStripButtonTest_Click;
            // 
            // toolStripDropDownButtonAnimation
            // 
            toolStripDropDownButtonAnimation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripDropDownButtonAnimation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem1, toolStripTextBoxStart, toolStripSeparator11, stepToolStripMenuItem, toolStripTextBoxStep, toolStripSeparator7, stepCountToolStripMenuItem, toolStripTextBoxStepCount, toolStripSeparator10, pauseToolStripMenuItem, toolStripTextBoxPause, toolStripSeparator6, toolStripMenuItemTimeIndicator, toolStripTextBoxTimeIndicator });
            toolStripDropDownButtonAnimation.Image = (System.Drawing.Image)resources.GetObject("toolStripDropDownButtonAnimation.Image");
            toolStripDropDownButtonAnimation.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripDropDownButtonAnimation.Name = "toolStripDropDownButtonAnimation";
            toolStripDropDownButtonAnimation.Size = new System.Drawing.Size(76, 24);
            toolStripDropDownButtonAnimation.Text = "Animation";
            toolStripDropDownButtonAnimation.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            toolStripDropDownButtonAnimation.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            toolStripMenuItem1.Text = "Start time";
            // 
            // toolStripTextBoxStart
            // 
            toolStripTextBoxStart.Name = "toolStripTextBoxStart";
            toolStripTextBoxStart.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new System.Drawing.Size(178, 6);
            // 
            // stepToolStripMenuItem
            // 
            stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            stepToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            stepToolStripMenuItem.Text = "Step";
            // 
            // toolStripTextBoxStep
            // 
            toolStripTextBoxStep.Name = "toolStripTextBoxStep";
            toolStripTextBoxStep.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new System.Drawing.Size(178, 6);
            // 
            // stepCountToolStripMenuItem
            // 
            stepCountToolStripMenuItem.Name = "stepCountToolStripMenuItem";
            stepCountToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            stepCountToolStripMenuItem.Text = "Step count";
            // 
            // toolStripTextBoxStepCount
            // 
            toolStripTextBoxStepCount.Name = "toolStripTextBoxStepCount";
            toolStripTextBoxStepCount.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new System.Drawing.Size(178, 6);
            // 
            // pauseToolStripMenuItem
            // 
            pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            pauseToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            pauseToolStripMenuItem.Text = "Pause";
            // 
            // toolStripTextBoxPause
            // 
            toolStripTextBoxPause.Name = "toolStripTextBoxPause";
            toolStripTextBoxPause.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(178, 6);
            // 
            // toolStripMenuItemTimeIndicator
            // 
            toolStripMenuItemTimeIndicator.Name = "toolStripMenuItemTimeIndicator";
            toolStripMenuItemTimeIndicator.Size = new System.Drawing.Size(181, 22);
            toolStripMenuItemTimeIndicator.Text = "Time indication step";
            // 
            // toolStripTextBoxTimeIndicator
            // 
            toolStripTextBoxTimeIndicator.Name = "toolStripTextBoxTimeIndicator";
            toolStripTextBoxTimeIndicator.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripButtonStart
            // 
            toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonStart.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonStart.Image");
            toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonStart.Name = "toolStripButtonStart";
            toolStripButtonStart.Size = new System.Drawing.Size(24, 24);
            toolStripButtonStart.Text = "Start animation";
            toolStripButtonStart.Visible = false;
            toolStripButtonStart.Click += toolStripButtonStart_Click;
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
            // toolStripButtonDir
            // 
            toolStripButtonDir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonDir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { soundDirectoryToolStripMenuItem, toolStripMenuItemSoundDirectory, browseToolStripMenuItem });
            toolStripButtonDir.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonDir.Image");
            toolStripButtonDir.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonDir.Name = "toolStripButtonDir";
            toolStripButtonDir.Size = new System.Drawing.Size(33, 24);
            toolStripButtonDir.Text = "Audio";
            // 
            // soundDirectoryToolStripMenuItem
            // 
            soundDirectoryToolStripMenuItem.Name = "soundDirectoryToolStripMenuItem";
            soundDirectoryToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            soundDirectoryToolStripMenuItem.Text = "Sound directory";
            // 
            // toolStripMenuItemSoundDirectory
            // 
            toolStripMenuItemSoundDirectory.Name = "toolStripMenuItemSoundDirectory";
            toolStripMenuItemSoundDirectory.Size = new System.Drawing.Size(158, 22);
            // 
            // browseToolStripMenuItem
            // 
            browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            browseToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            browseToolStripMenuItem.Text = "Browse...";
            browseToolStripMenuItem.Click += browseToolStripMenuItem_Click;
            // 
            // helpToolStripButton
            // 
            helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            helpToolStripButton.Image = (System.Drawing.Image)resources.GetObject("helpToolStripButton.Image");
            helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            helpToolStripButton.Name = "helpToolStripButton";
            helpToolStripButton.Size = new System.Drawing.Size(24, 24);
            helpToolStripButton.Text = "He&lp";
            helpToolStripButton.Visible = false;
            helpToolStripButton.Click += helpToolStripButton_Click;
            // 
            // toolStripButtonStrict
            // 
            toolStripButtonStrict.Checked = true;
            toolStripButtonStrict.CheckOnClick = true;
            toolStripButtonStrict.CheckState = System.Windows.Forms.CheckState.Checked;
            toolStripButtonStrict.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButtonStrict.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonStrict.Image");
            toolStripButtonStrict.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonStrict.Name = "toolStripButtonStrict";
            toolStripButtonStrict.Size = new System.Drawing.Size(38, 24);
            toolStripButtonStrict.Text = "Strict";
            toolStripButtonStrict.Visible = false;
            toolStripButtonStrict.Click += toolStripButtonStrict_Click;
            // 
            // menuStripMain
            // 
            menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, viewMenu, toolsToolStripMenuItem1, wizardsToolStripMenuItem, databaseToolStripMenuItem, updateToolStripMenuItem, checkDesktopToolStripMenuItem, saveLogsToolStripMenuItem, helpToolStripMenuItem, generateToolStripMenuItem, openLogDirectoryToolStripMenuItem, testToolStripMenuItem, openInExplorerToolStripMenuItem });
            menuStripMain.Location = new System.Drawing.Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStripMain.Size = new System.Drawing.Size(1200, 24);
            menuStripMain.TabIndex = 6;
            menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openToolStripMenuItem, loadfromdatabaseToolStripMenuItem, toolStripSeparator1, saveToolStripMenuItem, saveAsToolStripMenuItem, savetodatabaseToolStripMenuItem, saveSCADAXMLToolStripMenuItem, toolStripSeparator12, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            openToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // loadfromdatabaseToolStripMenuItem
            // 
            loadfromdatabaseToolStripMenuItem.Name = "loadfromdatabaseToolStripMenuItem";
            loadfromdatabaseToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            loadfromdatabaseToolStripMenuItem.Text = "Load from database";
            loadfromdatabaseToolStripMenuItem.Click += loadfromdatabaseToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            saveToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            saveToolStripMenuItem.Text = "&Save";
            saveToolStripMenuItem.Click += saveControl;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            saveAsToolStripMenuItem.Text = "Save &As";
            saveAsToolStripMenuItem.Click += saveasToolStripMenuItem_Click;
            // 
            // savetodatabaseToolStripMenuItem
            // 
            savetodatabaseToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("savetodatabaseToolStripMenuItem.Image");
            savetodatabaseToolStripMenuItem.Name = "savetodatabaseToolStripMenuItem";
            savetodatabaseToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            savetodatabaseToolStripMenuItem.Text = "Save to database";
            savetodatabaseToolStripMenuItem.Click += savetodatabaseToolStripMenuItem_Click;
            // 
            // saveSCADAXMLToolStripMenuItem
            // 
            saveSCADAXMLToolStripMenuItem.Name = "saveSCADAXMLToolStripMenuItem";
            saveSCADAXMLToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            saveSCADAXMLToolStripMenuItem.Text = "Save SCADA XML";
            saveSCADAXMLToolStripMenuItem.Click += saveSCADAXMLToolStripMenuItem_Click;
            // 
            // toolStripSeparator12
            // 
            toolStripSeparator12.Name = "toolStripSeparator12";
            toolStripSeparator12.Size = new System.Drawing.Size(176, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator9, selectAllToolStripMenuItem, deletecommentsToolStripMenuItem, clearselectedToolStripMenuItem, clearallToolStripMenuItem, changeorderofselectedToolStripMenuItem, unselectAllToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("undoToolStripMenuItem.Image");
            undoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z;
            undoToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("redoToolStripMenuItem.Image");
            redoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y;
            redoToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            redoToolStripMenuItem.Text = "&Redo";
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("cutToolStripMenuItem.Image");
            cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X;
            cutToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            cutToolStripMenuItem.Text = "Cu&t";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C;
            copyToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            copyToolStripMenuItem.Text = "&Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("pasteToolStripMenuItem.Image");
            pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V;
            pasteToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            pasteToolStripMenuItem.Text = "&Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new System.Drawing.Size(203, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            selectAllToolStripMenuItem.Text = "Select &All";
            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
            // 
            // deletecommentsToolStripMenuItem
            // 
            deletecommentsToolStripMenuItem.Name = "deletecommentsToolStripMenuItem";
            deletecommentsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            deletecommentsToolStripMenuItem.Text = "Delete comments";
            deletecommentsToolStripMenuItem.Click += deletecommentsToolStripMenuItem_Click;
            // 
            // clearselectedToolStripMenuItem
            // 
            clearselectedToolStripMenuItem.Name = "clearselectedToolStripMenuItem";
            clearselectedToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            clearselectedToolStripMenuItem.Text = "Clear selected";
            clearselectedToolStripMenuItem.Visible = false;
            clearselectedToolStripMenuItem.Click += clearselectedToolStripMenuItem_Click;
            // 
            // clearallToolStripMenuItem
            // 
            clearallToolStripMenuItem.Name = "clearallToolStripMenuItem";
            clearallToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            clearallToolStripMenuItem.Text = "Clear all";
            clearallToolStripMenuItem.Click += clearallToolStripMenuItem_Click;
            // 
            // changeorderofselectedToolStripMenuItem
            // 
            changeorderofselectedToolStripMenuItem.Name = "changeorderofselectedToolStripMenuItem";
            changeorderofselectedToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            changeorderofselectedToolStripMenuItem.Text = "Change order of selected";
            changeorderofselectedToolStripMenuItem.Click += changeorderofselectedToolStripMenuItem_Click;
            // 
            // unselectAllToolStripMenuItem
            // 
            unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            unselectAllToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            unselectAllToolStripMenuItem.Text = "Unselect All";
            unselectAllToolStripMenuItem.Click += unselectAllToolStripMenuItem_Click;
            // 
            // viewMenu
            // 
            viewMenu.Checked = true;
            viewMenu.CheckOnClick = true;
            viewMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { statusBarToolStripMenuItem, objectTreelBarToolStripMenuItemObjects, toolboxToolStripMenuItem, dataToolStripMenuItem, messagesToolStripMenuItem });
            viewMenu.Name = "viewMenu";
            viewMenu.Size = new System.Drawing.Size(44, 20);
            viewMenu.Text = "&View";
            // 
            // statusBarToolStripMenuItem
            // 
            statusBarToolStripMenuItem.Checked = true;
            statusBarToolStripMenuItem.CheckOnClick = true;
            statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            statusBarToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            statusBarToolStripMenuItem.Text = "&Status Bar";
            // 
            // objectTreelBarToolStripMenuItemObjects
            // 
            objectTreelBarToolStripMenuItemObjects.Checked = true;
            objectTreelBarToolStripMenuItemObjects.CheckOnClick = true;
            objectTreelBarToolStripMenuItemObjects.CheckState = System.Windows.Forms.CheckState.Checked;
            objectTreelBarToolStripMenuItemObjects.Image = (System.Drawing.Image)resources.GetObject("objectTreelBarToolStripMenuItemObjects.Image");
            objectTreelBarToolStripMenuItemObjects.Name = "objectTreelBarToolStripMenuItemObjects";
            objectTreelBarToolStripMenuItemObjects.Size = new System.Drawing.Size(140, 22);
            objectTreelBarToolStripMenuItemObjects.Text = "Objects' tree";
            objectTreelBarToolStripMenuItemObjects.Click += objectTreelBarToolStripMenuItemObjects_Click;
            // 
            // toolboxToolStripMenuItem
            // 
            toolboxToolStripMenuItem.Checked = true;
            toolboxToolStripMenuItem.CheckOnClick = true;
            toolboxToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            toolboxToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("toolboxToolStripMenuItem.Image");
            toolboxToolStripMenuItem.Name = "toolboxToolStripMenuItem";
            toolboxToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            toolboxToolStripMenuItem.Text = "Toolbox";
            toolboxToolStripMenuItem.Click += toolboxToolStripMenuItem_Click;
            // 
            // dataToolStripMenuItem
            // 
            dataToolStripMenuItem.Checked = true;
            dataToolStripMenuItem.CheckOnClick = true;
            dataToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            dataToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("dataToolStripMenuItem.Image");
            dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            dataToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            dataToolStripMenuItem.Text = "Database";
            dataToolStripMenuItem.Click += dataToolStripMenuItem_Click;
            // 
            // messagesToolStripMenuItem
            // 
            messagesToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("messagesToolStripMenuItem.Image");
            messagesToolStripMenuItem.Name = "messagesToolStripMenuItem";
            messagesToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            messagesToolStripMenuItem.Text = "Warnings";
            messagesToolStripMenuItem.Click += messagesToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem1
            // 
            toolsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { customizeToolStripMenuItem, optionsToolStripMenuItem });
            toolsToolStripMenuItem1.Name = "toolsToolStripMenuItem1";
            toolsToolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            toolsToolStripMenuItem1.Text = "&Tools";
            toolsToolStripMenuItem1.Visible = false;
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            optionsToolStripMenuItem.Text = "&Options";
            // 
            // wizardsToolStripMenuItem
            // 
            wizardsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { containerDesignerToolStripMenuItem, derivationCalculatorToolStripMenuItem, editorOfAliasesToolStripMenuItem, toolStripSeparator3, toolStripMenuGereratedFiles, classNameToolStripMenuItem, toolStripTextBoxClassName });
            wizardsToolStripMenuItem.Name = "wizardsToolStripMenuItem";
            wizardsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            wizardsToolStripMenuItem.Text = "Wizards";
            // 
            // containerDesignerToolStripMenuItem
            // 
            containerDesignerToolStripMenuItem.Name = "containerDesignerToolStripMenuItem";
            containerDesignerToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            containerDesignerToolStripMenuItem.Text = "Container designer";
            containerDesignerToolStripMenuItem.Click += containerDesignerToolStripMenuItem_Click;
            // 
            // derivationCalculatorToolStripMenuItem
            // 
            derivationCalculatorToolStripMenuItem.Name = "derivationCalculatorToolStripMenuItem";
            derivationCalculatorToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            derivationCalculatorToolStripMenuItem.Text = "Derivation calculator";
            derivationCalculatorToolStripMenuItem.Click += derivationCalculatorToolStripMenuItem_Click;
            // 
            // editorOfAliasesToolStripMenuItem
            // 
            editorOfAliasesToolStripMenuItem.Name = "editorOfAliasesToolStripMenuItem";
            editorOfAliasesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            editorOfAliasesToolStripMenuItem.Text = "Editor of aliases";
            editorOfAliasesToolStripMenuItem.Click += editorOfAliasesToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(213, 6);
            // 
            // toolStripMenuGereratedFiles
            // 
            toolStripMenuGereratedFiles.Name = "toolStripMenuGereratedFiles";
            toolStripMenuGereratedFiles.Size = new System.Drawing.Size(216, 22);
            toolStripMenuGereratedFiles.Text = "Directory of generated files";
            toolStripMenuGereratedFiles.Click += toolStripMenuGereratedFiles_Click;
            // 
            // classNameToolStripMenuItem
            // 
            classNameToolStripMenuItem.Name = "classNameToolStripMenuItem";
            classNameToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            classNameToolStripMenuItem.Text = "Class name";
            // 
            // toolStripTextBoxClassName
            // 
            toolStripTextBoxClassName.Name = "toolStripTextBoxClassName";
            toolStripTextBoxClassName.Size = new System.Drawing.Size(100, 23);
            toolStripTextBoxClassName.Text = "GeneratedProject";
            toolStripTextBoxClassName.TextChanged += toolStripTextBoxClassName_TextChanged;
            // 
            // databaseToolStripMenuItem
            // 
            databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { connectToolStripMenuItem, readWriteToolStripMenuItem });
            databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            databaseToolStripMenuItem.Text = "Database";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            connectToolStripMenuItem.Text = "Connect";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // readWriteToolStripMenuItem
            // 
            readWriteToolStripMenuItem.Name = "readWriteToolStripMenuItem";
            readWriteToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            readWriteToolStripMenuItem.Text = "Read";
            readWriteToolStripMenuItem.Click += readWriteToolStripMenuItem_Click;
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            updateToolStripMenuItem.Text = "Update";
            updateToolStripMenuItem.Click += updateToolStripMenuItem_Click;
            // 
            // checkDesktopToolStripMenuItem
            // 
            checkDesktopToolStripMenuItem.Name = "checkDesktopToolStripMenuItem";
            checkDesktopToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            checkDesktopToolStripMenuItem.Text = "Check desktop";
            checkDesktopToolStripMenuItem.Click += checkDesktopToolStripMenuItem_Click;
            // 
            // saveLogsToolStripMenuItem
            // 
            saveLogsToolStripMenuItem.Enabled = false;
            saveLogsToolStripMenuItem.Name = "saveLogsToolStripMenuItem";
            saveLogsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            saveLogsToolStripMenuItem.Text = "Save logs";
            saveLogsToolStripMenuItem.Visible = false;
            saveLogsToolStripMenuItem.Click += saveLogsToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { contentsToolStripMenuItem, indexToolStripMenuItem, searchToolStripMenuItem, toolStripSeparator8, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new System.Drawing.Size(119, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            aboutToolStripMenuItem.Text = "&About...";
            // 
            // generateToolStripMenuItem
            // 
            generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            generateToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            generateToolStripMenuItem.Text = "Generate";
            generateToolStripMenuItem.Click += generateToolStripMenuItem_Click;
            // 
            // openLogDirectoryToolStripMenuItem
            // 
            openLogDirectoryToolStripMenuItem.Name = "openLogDirectoryToolStripMenuItem";
            openLogDirectoryToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            openLogDirectoryToolStripMenuItem.Text = "Open Log directory";
            openLogDirectoryToolStripMenuItem.Visible = false;
            openLogDirectoryToolStripMenuItem.Click += openLogDirectoryToolStripMenuItem_Click;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            testToolStripMenuItem.Text = "Test";
            testToolStripMenuItem.Click += testToolStripMenuItem_Click;
            // 
            // saveFileDialogScn
            // 
            saveFileDialogScn.Filter = "Astronomy configuration files |*.cfa";
            // 
            // saveFileDialogScadaXml
            // 
            saveFileDialogScadaXml.Filter = "Xml Files|*.xml";
            // 
            // openInExplorerToolStripMenuItem
            // 
            openInExplorerToolStripMenuItem.Name = "openInExplorerToolStripMenuItem";
            openInExplorerToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            openInExplorerToolStripMenuItem.Text = "Open in Explorer";
            openInExplorerToolStripMenuItem.Click += openInExplorerToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLight;
            ClientSize = new System.Drawing.Size(1200, 676);
            Controls.Add(panelCenter);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(toolStripMain);
            Controls.Add(menuStripMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "FormMain";
            Text = "Astronomy";
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            panelTop.ResumeLayout(false);
            panelTopTop.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            panelCenter.ResumeLayout(false);
            toolStripMain.ResumeLayout(false);
            toolStripMain.PerformLayout();
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem openInExplorerToolStripMenuItem;
    }
}

