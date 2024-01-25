using System.Windows.Forms.DataVisualization.Charting;
using ChartAPI = Chart;
namespace WinTradingResearch
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
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();
            Series series2 = new Series();
            Series series3 = new Series();
            Series series4 = new Series();
            Series series5 = new Series();
            Series series6 = new Series();
            Series series7 = new Series();
            Series series8 = new Series();
            panelTop = new Panel();
            toolsMenu = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            helpMenu = new ToolStripMenuItem();
            contentsToolStripMenuItem = new ToolStripMenuItem();
            indexToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusBarToolStripMenuItem = new ToolStripMenuItem();
            toolBarToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripSeparator4 = new ToolStripSeparator();
            openToolStripMenuItem = new ToolStripMenuItem();
            viewMenu = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            printToolStripMenuItem = new ToolStripMenuItem();
            printPreviewToolStripMenuItem = new ToolStripMenuItem();
            printSetupToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editMenu = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            panelRight = new Panel();
            panelLeft = new Panel();
            panelBottom = new Panel();
            printToolStripButton = new ToolStripButton();
            printPreviewToolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            saveToolStripButton = new ToolStripButton();
            openToolStripButton = new ToolStripButton();
            toolStrip = new ToolStrip();
            newToolStripButton = new ToolStripButton();
            helpToolStripButton = new ToolStripButton();
            toolStripButtonStart = new ToolStripButton();
            panelCenter = new Panel();
            splitContainer1 = new SplitContainer();
            panelLeftSplit = new Panel();
            panel26 = new Panel();
            longNum = new NumericUpDown();
            panel27 = new Panel();
            label5 = new Label();
            panel28 = new Panel();
            panel29 = new Panel();
            panel41 = new Panel();
            comboBoxBarSize = new ComboBox();
            panel42 = new Panel();
            label7 = new Label();
            panel43 = new Panel();
            panel44 = new Panel();
            labelMouseIndicator = new Label();
            labelIncome = new Label();
            panel30 = new Panel();
            panel45 = new Panel();
            numericUpDownDonchian = new NumericUpDown();
            panel46 = new Panel();
            panel47 = new Panel();
            label6 = new Label();
            panel48 = new Panel();
            panel49 = new Panel();
            panel1 = new Panel();
            panel8 = new Panel();
            panel15 = new Panel();
            panel22 = new Panel();
            shortNum = new NumericUpDown();
            panel23 = new Panel();
            label4 = new Label();
            panel24 = new Panel();
            panel25 = new Panel();
            panel16 = new Panel();
            panel17 = new Panel();
            dateEnd = new DateTimePicker();
            panel18 = new Panel();
            panel19 = new Panel();
            label3 = new Label();
            panel20 = new Panel();
            panel21 = new Panel();
            panel9 = new Panel();
            panel10 = new Panel();
            dateBegin = new DateTimePicker();
            panel11 = new Panel();
            panel12 = new Panel();
            label2 = new Label();
            panel13 = new Panel();
            panel14 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            comboBoxSymbols = new ComboBox();
            panel4 = new Panel();
            panel5 = new Panel();
            label1 = new Label();
            panel6 = new Panel();
            panel7 = new Panel();
            panel31 = new Panel();
            panel32 = new Panel();
            panel33 = new Panel();
            panel34 = new Panel();
            panel35 = new Panel();
            panel36 = new Panel();
            panel37 = new Panel();
            userControlChart = new ChartAPI.UserControls.UserControlChart();
            chartData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel38 = new Panel();
            panel39 = new Panel();
            panel40 = new Panel();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelLeftSplit.SuspendLayout();
            panel26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)longNum).BeginInit();
            panel27.SuspendLayout();
            panel29.SuspendLayout();
            panel41.SuspendLayout();
            panel42.SuspendLayout();
            panel44.SuspendLayout();
            panel30.SuspendLayout();
            panel45.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDonchian).BeginInit();
            panel47.SuspendLayout();
            panel1.SuspendLayout();
            panel8.SuspendLayout();
            panel15.SuspendLayout();
            panel22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)shortNum).BeginInit();
            panel23.SuspendLayout();
            panel16.SuspendLayout();
            panel17.SuspendLayout();
            panel19.SuspendLayout();
            panel9.SuspendLayout();
            panel10.SuspendLayout();
            panel12.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel31.SuspendLayout();
            panel37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartData).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(1, 51);
            panelTop.Margin = new Padding(4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1075, 1);
            panelTop.TabIndex = 22;
            // 
            // toolsMenu
            // 
            toolsMenu.DropDownItems.AddRange(new ToolStripItem[] { optionsToolStripMenuItem });
            toolsMenu.Name = "toolsMenu";
            toolsMenu.Size = new Size(46, 20);
            toolsMenu.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(116, 22);
            optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpMenu
            // 
            helpMenu.DropDownItems.AddRange(new ToolStripItem[] { contentsToolStripMenuItem, indexToolStripMenuItem, searchToolStripMenuItem, toolStripSeparator8, aboutToolStripMenuItem });
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new Size(44, 20);
            helpMenu.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F1;
            contentsToolStripMenuItem.Size = new Size(168, 22);
            contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            indexToolStripMenuItem.Image = (Image)resources.GetObject("indexToolStripMenuItem.Image");
            indexToolStripMenuItem.ImageTransparentColor = Color.Black;
            indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            indexToolStripMenuItem.Size = new Size(168, 22);
            indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Image = (Image)resources.GetObject("searchToolStripMenuItem.Image");
            searchToolStripMenuItem.ImageTransparentColor = Color.Black;
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(168, 22);
            searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(165, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(168, 22);
            aboutToolStripMenuItem.Text = "&About ...";
            // 
            // statusBarToolStripMenuItem
            // 
            statusBarToolStripMenuItem.Checked = true;
            statusBarToolStripMenuItem.CheckOnClick = true;
            statusBarToolStripMenuItem.CheckState = CheckState.Checked;
            statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            statusBarToolStripMenuItem.Size = new Size(126, 22);
            statusBarToolStripMenuItem.Text = "&Status Bar";
            // 
            // toolBarToolStripMenuItem
            // 
            toolBarToolStripMenuItem.Checked = true;
            toolBarToolStripMenuItem.CheckOnClick = true;
            toolBarToolStripMenuItem.CheckState = CheckState.Checked;
            toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            toolBarToolStripMenuItem.Size = new Size(126, 22);
            toolBarToolStripMenuItem.Text = "&Toolbar";
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(1, 660);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 17, 0);
            statusStrip.Size = new Size(1075, 22);
            statusStrip.TabIndex = 20;
            statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(39, 17);
            toolStripStatusLabel.Text = "Status";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.ImageTransparentColor = Color.Black;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(146, 22);
            saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(146, 22);
            saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(143, 6);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(143, 6);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.ImageTransparentColor = Color.Black;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(146, 22);
            openToolStripMenuItem.Text = "&Open";
            // 
            // viewMenu
            // 
            viewMenu.DropDownItems.AddRange(new ToolStripItem[] { toolBarToolStripMenuItem, statusBarToolStripMenuItem });
            viewMenu.Name = "viewMenu";
            viewMenu.Size = new Size(44, 20);
            viewMenu.Text = "&View";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.ImageTransparentColor = Color.Black;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(146, 22);
            newToolStripMenuItem.Text = "&New";
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, editMenu, viewMenu, toolsMenu, helpMenu });
            menuStrip.Location = new Point(1, 27);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(5, 2, 0, 2);
            menuStrip.Size = new Size(1075, 24);
            menuStrip.TabIndex = 19;
            menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator3, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator4, printToolStripMenuItem, printPreviewToolStripMenuItem, printSetupToolStripMenuItem, toolStripSeparator5, exitToolStripMenuItem });
            fileMenu.ImageTransparentColor = SystemColors.ActiveBorder;
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(37, 20);
            fileMenu.Text = "&File";
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Image = (Image)resources.GetObject("printToolStripMenuItem.Image");
            printToolStripMenuItem.ImageTransparentColor = Color.Black;
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            printToolStripMenuItem.Size = new Size(146, 22);
            printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            printPreviewToolStripMenuItem.Image = (Image)resources.GetObject("printPreviewToolStripMenuItem.Image");
            printPreviewToolStripMenuItem.ImageTransparentColor = Color.Black;
            printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            printPreviewToolStripMenuItem.Size = new Size(146, 22);
            printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // printSetupToolStripMenuItem
            // 
            printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
            printSetupToolStripMenuItem.Size = new Size(146, 22);
            printSetupToolStripMenuItem.Text = "Print Setup";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(146, 22);
            exitToolStripMenuItem.Text = "E&xit";
            // 
            // editMenu
            // 
            editMenu.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator6, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator7, selectAllToolStripMenuItem });
            editMenu.Name = "editMenu";
            editMenu.Size = new Size(39, 20);
            editMenu.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Image = (Image)resources.GetObject("undoToolStripMenuItem.Image");
            undoToolStripMenuItem.ImageTransparentColor = Color.Black;
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(164, 22);
            undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Image = (Image)resources.GetObject("redoToolStripMenuItem.Image");
            redoToolStripMenuItem.ImageTransparentColor = Color.Black;
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoToolStripMenuItem.Size = new Size(164, 22);
            redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(161, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = (Image)resources.GetObject("cutToolStripMenuItem.Image");
            cutToolStripMenuItem.ImageTransparentColor = Color.Black;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(164, 22);
            cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = (Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.ImageTransparentColor = Color.Black;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(164, 22);
            copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = (Image)resources.GetObject("pasteToolStripMenuItem.Image");
            pasteToolStripMenuItem.ImageTransparentColor = Color.Black;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(164, 22);
            pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(161, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            selectAllToolStripMenuItem.Size = new Size(164, 22);
            selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // panelRight
            // 
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(1076, 27);
            panelRight.Margin = new Padding(4);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(1, 655);
            panelRight.TabIndex = 24;
            // 
            // panelLeft
            // 
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 27);
            panelLeft.Margin = new Padding(4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(1, 655);
            panelLeft.TabIndex = 23;
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 682);
            panelBottom.Margin = new Padding(4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1077, 1);
            panelBottom.TabIndex = 25;
            // 
            // printToolStripButton
            // 
            printToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            printToolStripButton.Image = (Image)resources.GetObject("printToolStripButton.Image");
            printToolStripButton.ImageTransparentColor = Color.Black;
            printToolStripButton.Name = "printToolStripButton";
            printToolStripButton.Size = new Size(24, 24);
            printToolStripButton.Text = "Print";
            // 
            // printPreviewToolStripButton
            // 
            printPreviewToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            printPreviewToolStripButton.Image = (Image)resources.GetObject("printPreviewToolStripButton.Image");
            printPreviewToolStripButton.ImageTransparentColor = Color.Black;
            printPreviewToolStripButton.Name = "printPreviewToolStripButton";
            printPreviewToolStripButton.Size = new Size(24, 24);
            printPreviewToolStripButton.Text = "Print Preview";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // saveToolStripButton
            // 
            saveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveToolStripButton.Image = (Image)resources.GetObject("saveToolStripButton.Image");
            saveToolStripButton.ImageTransparentColor = Color.Black;
            saveToolStripButton.Name = "saveToolStripButton";
            saveToolStripButton.Size = new Size(24, 24);
            saveToolStripButton.Text = "Save";
            // 
            // openToolStripButton
            // 
            openToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openToolStripButton.Image = (Image)resources.GetObject("openToolStripButton.Image");
            openToolStripButton.ImageTransparentColor = Color.Black;
            openToolStripButton.Name = "openToolStripButton";
            openToolStripButton.Size = new Size(24, 24);
            openToolStripButton.Text = "Open";
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { newToolStripButton, openToolStripButton, saveToolStripButton, toolStripSeparator1, printToolStripButton, printPreviewToolStripButton, toolStripSeparator2, helpToolStripButton, toolStripButtonStart });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1077, 27);
            toolStrip.TabIndex = 21;
            toolStrip.Text = "ToolStrip";
            // 
            // newToolStripButton
            // 
            newToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            newToolStripButton.Image = (Image)resources.GetObject("newToolStripButton.Image");
            newToolStripButton.ImageTransparentColor = Color.Black;
            newToolStripButton.Name = "newToolStripButton";
            newToolStripButton.Size = new Size(24, 24);
            newToolStripButton.Text = "New";
            // 
            // helpToolStripButton
            // 
            helpToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            helpToolStripButton.Image = (Image)resources.GetObject("helpToolStripButton.Image");
            helpToolStripButton.ImageTransparentColor = Color.Black;
            helpToolStripButton.Name = "helpToolStripButton";
            helpToolStripButton.Size = new Size(24, 24);
            helpToolStripButton.Text = "Help";
            // 
            // toolStripButtonStart
            // 
            toolStripButtonStart.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonStart.Image = (Image)resources.GetObject("toolStripButtonStart.Image");
            toolStripButtonStart.ImageTransparentColor = Color.Magenta;
            toolStripButtonStart.Name = "toolStripButtonStart";
            toolStripButtonStart.Size = new Size(24, 24);
            toolStripButtonStart.Text = "Start animation";
            toolStripButtonStart.Click += toolStripButtonStart_Click;
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(splitContainer1);
            panelCenter.Dock = DockStyle.Fill;
            panelCenter.Location = new Point(1, 52);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new Size(1075, 608);
            panelCenter.TabIndex = 26;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelLeftSplit);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel31);
            splitContainer1.Panel2.Controls.Add(panel37);
            splitContainer1.Panel2.Controls.Add(panel38);
            splitContainer1.Panel2.Controls.Add(panel39);
            splitContainer1.Panel2.Controls.Add(panel40);
            splitContainer1.Size = new Size(1075, 608);
            splitContainer1.SplitterDistance = 361;
            splitContainer1.TabIndex = 0;
            // 
            // panelLeftSplit
            // 
            panelLeftSplit.Controls.Add(panel26);
            panelLeftSplit.Controls.Add(panel27);
            panelLeftSplit.Controls.Add(panel28);
            panelLeftSplit.Controls.Add(panel29);
            panelLeftSplit.Controls.Add(panel1);
            panelLeftSplit.Dock = DockStyle.Fill;
            panelLeftSplit.Location = new Point(0, 0);
            panelLeftSplit.Name = "panelLeftSplit";
            panelLeftSplit.Size = new Size(361, 608);
            panelLeftSplit.TabIndex = 0;
            // 
            // panel26
            // 
            panel26.Controls.Add(longNum);
            panel26.Dock = DockStyle.Fill;
            panel26.Location = new Point(147, 217);
            panel26.Margin = new Padding(4, 3, 4, 3);
            panel26.Name = "panel26";
            panel26.Size = new Size(214, 38);
            panel26.TabIndex = 24;
            // 
            // longNum
            // 
            longNum.Dock = DockStyle.Fill;
            longNum.Location = new Point(0, 0);
            longNum.Margin = new Padding(4, 3, 4, 3);
            longNum.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            longNum.Name = "longNum";
            longNum.Size = new Size(214, 23);
            longNum.TabIndex = 0;
            longNum.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // panel27
            // 
            panel27.Controls.Add(label5);
            panel27.Dock = DockStyle.Left;
            panel27.Location = new Point(0, 217);
            panel27.Margin = new Padding(4, 3, 4, 3);
            panel27.Name = "panel27";
            panel27.Size = new Size(147, 38);
            panel27.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 8);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 0;
            label5.Text = "Average long";
            // 
            // panel28
            // 
            panel28.Dock = DockStyle.Top;
            panel28.Location = new Point(0, 207);
            panel28.Margin = new Padding(4, 3, 4, 3);
            panel28.Name = "panel28";
            panel28.Size = new Size(361, 10);
            panel28.TabIndex = 21;
            // 
            // panel29
            // 
            panel29.Controls.Add(panel41);
            panel29.Controls.Add(panel42);
            panel29.Controls.Add(panel43);
            panel29.Controls.Add(panel44);
            panel29.Controls.Add(panel30);
            panel29.Dock = DockStyle.Bottom;
            panel29.Location = new Point(0, 255);
            panel29.Margin = new Padding(4, 3, 4, 3);
            panel29.Name = "panel29";
            panel29.Size = new Size(361, 353);
            panel29.TabIndex = 23;
            // 
            // panel41
            // 
            panel41.Controls.Add(comboBoxBarSize);
            panel41.Dock = DockStyle.Fill;
            panel41.Location = new Point(147, 60);
            panel41.Margin = new Padding(4, 3, 4, 3);
            panel41.Name = "panel41";
            panel41.Size = new Size(214, 30);
            panel41.TabIndex = 24;
            // 
            // comboBoxBarSize
            // 
            comboBoxBarSize.Dock = DockStyle.Fill;
            comboBoxBarSize.FormattingEnabled = true;
            comboBoxBarSize.Location = new Point(0, 0);
            comboBoxBarSize.Margin = new Padding(4, 3, 4, 3);
            comboBoxBarSize.Name = "comboBoxBarSize";
            comboBoxBarSize.Size = new Size(214, 23);
            comboBoxBarSize.TabIndex = 0;
            comboBoxBarSize.Text = "15 min";
            // 
            // panel42
            // 
            panel42.Controls.Add(label7);
            panel42.Dock = DockStyle.Left;
            panel42.Location = new Point(0, 60);
            panel42.Margin = new Padding(4, 3, 4, 3);
            panel42.Name = "panel42";
            panel42.Size = new Size(147, 30);
            panel42.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 8);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 0;
            label7.Text = "Bar size";
            // 
            // panel43
            // 
            panel43.Dock = DockStyle.Top;
            panel43.Location = new Point(0, 50);
            panel43.Margin = new Padding(4, 3, 4, 3);
            panel43.Name = "panel43";
            panel43.Size = new Size(361, 10);
            panel43.TabIndex = 21;
            // 
            // panel44
            // 
            panel44.Controls.Add(labelMouseIndicator);
            panel44.Controls.Add(labelIncome);
            panel44.Dock = DockStyle.Bottom;
            panel44.Location = new Point(0, 90);
            panel44.Margin = new Padding(4, 3, 4, 3);
            panel44.Name = "panel44";
            panel44.Size = new Size(361, 263);
            panel44.TabIndex = 23;
            // 
            // labelMouseIndicator
            // 
            labelMouseIndicator.AutoSize = true;
            labelMouseIndicator.Location = new Point(41, 110);
            labelMouseIndicator.Name = "labelMouseIndicator";
            labelMouseIndicator.Size = new Size(115, 15);
            labelMouseIndicator.TabIndex = 1;
            labelMouseIndicator.Text = "labelMouseIndicator";
            // 
            // labelIncome
            // 
            labelIncome.AutoSize = true;
            labelIncome.Location = new Point(40, 52);
            labelIncome.Name = "labelIncome";
            labelIncome.Size = new Size(72, 15);
            labelIncome.TabIndex = 0;
            labelIncome.Text = "labelIncome";
            // 
            // panel30
            // 
            panel30.Controls.Add(panel45);
            panel30.Controls.Add(panel46);
            panel30.Controls.Add(panel47);
            panel30.Controls.Add(panel48);
            panel30.Controls.Add(panel49);
            panel30.Dock = DockStyle.Top;
            panel30.Location = new Point(0, 0);
            panel30.Name = "panel30";
            panel30.Size = new Size(361, 50);
            panel30.TabIndex = 0;
            // 
            // panel45
            // 
            panel45.Controls.Add(numericUpDownDonchian);
            panel45.Dock = DockStyle.Fill;
            panel45.Location = new Point(147, 10);
            panel45.Margin = new Padding(4, 3, 4, 3);
            panel45.Name = "panel45";
            panel45.Size = new Size(209, 34);
            panel45.TabIndex = 25;
            // 
            // numericUpDownDonchian
            // 
            numericUpDownDonchian.Dock = DockStyle.Fill;
            numericUpDownDonchian.Location = new Point(0, 0);
            numericUpDownDonchian.Margin = new Padding(4, 3, 4, 3);
            numericUpDownDonchian.Name = "numericUpDownDonchian";
            numericUpDownDonchian.Size = new Size(209, 23);
            numericUpDownDonchian.TabIndex = 0;
            numericUpDownDonchian.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // panel46
            // 
            panel46.Dock = DockStyle.Right;
            panel46.Location = new Point(356, 10);
            panel46.Margin = new Padding(4, 3, 4, 3);
            panel46.Name = "panel46";
            panel46.Size = new Size(5, 34);
            panel46.TabIndex = 23;
            // 
            // panel47
            // 
            panel47.Controls.Add(label6);
            panel47.Dock = DockStyle.Left;
            panel47.Location = new Point(0, 10);
            panel47.Margin = new Padding(4, 3, 4, 3);
            panel47.Name = "panel47";
            panel47.Size = new Size(147, 34);
            panel47.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 10);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 0;
            label6.Text = "Donchian interval";
            // 
            // panel48
            // 
            panel48.Dock = DockStyle.Top;
            panel48.Location = new Point(0, 0);
            panel48.Margin = new Padding(4, 3, 4, 3);
            panel48.Name = "panel48";
            panel48.Size = new Size(361, 10);
            panel48.TabIndex = 21;
            // 
            // panel49
            // 
            panel49.Dock = DockStyle.Bottom;
            panel49.Location = new Point(0, 44);
            panel49.Margin = new Padding(4, 3, 4, 3);
            panel49.Name = "panel49";
            panel49.Size = new Size(361, 6);
            panel49.TabIndex = 24;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(361, 207);
            panel1.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Controls.Add(panel15);
            panel8.Controls.Add(panel9);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 55);
            panel8.Name = "panel8";
            panel8.Size = new Size(361, 207);
            panel8.TabIndex = 1;
            // 
            // panel15
            // 
            panel15.Controls.Add(panel22);
            panel15.Controls.Add(panel23);
            panel15.Controls.Add(panel24);
            panel15.Controls.Add(panel25);
            panel15.Controls.Add(panel16);
            panel15.Dock = DockStyle.Top;
            panel15.Location = new Point(0, 55);
            panel15.Name = "panel15";
            panel15.Size = new Size(361, 207);
            panel15.TabIndex = 1;
            // 
            // panel22
            // 
            panel22.Controls.Add(shortNum);
            panel22.Dock = DockStyle.Fill;
            panel22.Location = new Point(147, 65);
            panel22.Margin = new Padding(4, 3, 4, 3);
            panel22.Name = "panel22";
            panel22.Size = new Size(214, 132);
            panel22.TabIndex = 24;
            // 
            // shortNum
            // 
            shortNum.Dock = DockStyle.Fill;
            shortNum.Location = new Point(0, 0);
            shortNum.Margin = new Padding(4, 3, 4, 3);
            shortNum.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            shortNum.Name = "shortNum";
            shortNum.Size = new Size(214, 23);
            shortNum.TabIndex = 0;
            shortNum.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // panel23
            // 
            panel23.Controls.Add(label4);
            panel23.Dock = DockStyle.Left;
            panel23.Location = new Point(0, 65);
            panel23.Margin = new Padding(4, 3, 4, 3);
            panel23.Name = "panel23";
            panel23.Size = new Size(147, 132);
            panel23.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 8);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 0;
            label4.Text = "Average short";
            // 
            // panel24
            // 
            panel24.Dock = DockStyle.Top;
            panel24.Location = new Point(0, 55);
            panel24.Margin = new Padding(4, 3, 4, 3);
            panel24.Name = "panel24";
            panel24.Size = new Size(361, 10);
            panel24.TabIndex = 21;
            // 
            // panel25
            // 
            panel25.Dock = DockStyle.Bottom;
            panel25.Location = new Point(0, 197);
            panel25.Margin = new Padding(4, 3, 4, 3);
            panel25.Name = "panel25";
            panel25.Size = new Size(361, 10);
            panel25.TabIndex = 23;
            // 
            // panel16
            // 
            panel16.Controls.Add(panel17);
            panel16.Controls.Add(panel18);
            panel16.Controls.Add(panel19);
            panel16.Controls.Add(panel20);
            panel16.Controls.Add(panel21);
            panel16.Dock = DockStyle.Top;
            panel16.Location = new Point(0, 0);
            panel16.Name = "panel16";
            panel16.Size = new Size(361, 55);
            panel16.TabIndex = 0;
            // 
            // panel17
            // 
            panel17.Controls.Add(dateEnd);
            panel17.Dock = DockStyle.Fill;
            panel17.Location = new Point(147, 10);
            panel17.Margin = new Padding(4, 3, 4, 3);
            panel17.Name = "panel17";
            panel17.Size = new Size(209, 35);
            panel17.TabIndex = 20;
            // 
            // dateEnd
            // 
            dateEnd.Dock = DockStyle.Fill;
            dateEnd.Location = new Point(0, 0);
            dateEnd.Margin = new Padding(4, 3, 4, 3);
            dateEnd.Name = "dateEnd";
            dateEnd.Size = new Size(209, 23);
            dateEnd.TabIndex = 0;
            // 
            // panel18
            // 
            panel18.Dock = DockStyle.Right;
            panel18.Location = new Point(356, 10);
            panel18.Margin = new Padding(4, 3, 4, 3);
            panel18.Name = "panel18";
            panel18.Size = new Size(5, 35);
            panel18.TabIndex = 18;
            // 
            // panel19
            // 
            panel19.Controls.Add(label3);
            panel19.Dock = DockStyle.Left;
            panel19.Location = new Point(0, 10);
            panel19.Margin = new Padding(4, 3, 4, 3);
            panel19.Name = "panel19";
            panel19.Size = new Size(147, 35);
            panel19.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 8);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 0;
            label3.Text = "End";
            // 
            // panel20
            // 
            panel20.Dock = DockStyle.Top;
            panel20.Location = new Point(0, 0);
            panel20.Margin = new Padding(4, 3, 4, 3);
            panel20.Name = "panel20";
            panel20.Size = new Size(361, 10);
            panel20.TabIndex = 16;
            // 
            // panel21
            // 
            panel21.Dock = DockStyle.Bottom;
            panel21.Location = new Point(0, 45);
            panel21.Margin = new Padding(4, 3, 4, 3);
            panel21.Name = "panel21";
            panel21.Size = new Size(361, 10);
            panel21.TabIndex = 19;
            // 
            // panel9
            // 
            panel9.Controls.Add(panel10);
            panel9.Controls.Add(panel11);
            panel9.Controls.Add(panel12);
            panel9.Controls.Add(panel13);
            panel9.Controls.Add(panel14);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(361, 55);
            panel9.TabIndex = 0;
            // 
            // panel10
            // 
            panel10.Controls.Add(dateBegin);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(147, 10);
            panel10.Margin = new Padding(4, 3, 4, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(209, 35);
            panel10.TabIndex = 20;
            // 
            // dateBegin
            // 
            dateBegin.Dock = DockStyle.Fill;
            dateBegin.Location = new Point(0, 0);
            dateBegin.Margin = new Padding(4, 3, 4, 3);
            dateBegin.Name = "dateBegin";
            dateBegin.Size = new Size(209, 23);
            dateBegin.TabIndex = 0;
            // 
            // panel11
            // 
            panel11.Dock = DockStyle.Right;
            panel11.Location = new Point(356, 10);
            panel11.Margin = new Padding(4, 3, 4, 3);
            panel11.Name = "panel11";
            panel11.Size = new Size(5, 35);
            panel11.TabIndex = 18;
            // 
            // panel12
            // 
            panel12.Controls.Add(label2);
            panel12.Dock = DockStyle.Left;
            panel12.Location = new Point(0, 10);
            panel12.Margin = new Padding(4, 3, 4, 3);
            panel12.Name = "panel12";
            panel12.Size = new Size(147, 35);
            panel12.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 8);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 0;
            label2.Text = "Begin";
            // 
            // panel13
            // 
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(0, 0);
            panel13.Margin = new Padding(4, 3, 4, 3);
            panel13.Name = "panel13";
            panel13.Size = new Size(361, 10);
            panel13.TabIndex = 16;
            // 
            // panel14
            // 
            panel14.Dock = DockStyle.Bottom;
            panel14.Location = new Point(0, 45);
            panel14.Margin = new Padding(4, 3, 4, 3);
            panel14.Name = "panel14";
            panel14.Size = new Size(361, 10);
            panel14.TabIndex = 19;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel7);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(361, 55);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(comboBoxSymbols);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(147, 10);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(209, 35);
            panel3.TabIndex = 20;
            // 
            // comboBoxSymbols
            // 
            comboBoxSymbols.Dock = DockStyle.Fill;
            comboBoxSymbols.FormattingEnabled = true;
            comboBoxSymbols.Location = new Point(0, 0);
            comboBoxSymbols.Margin = new Padding(4, 3, 4, 3);
            comboBoxSymbols.Name = "comboBoxSymbols";
            comboBoxSymbols.Size = new Size(209, 23);
            comboBoxSymbols.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(356, 10);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(5, 35);
            panel4.TabIndex = 18;
            // 
            // panel5
            // 
            panel5.Controls.Add(label1);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 10);
            panel5.Margin = new Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(147, 35);
            panel5.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 8);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Symbol";
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Margin = new Padding(4, 3, 4, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(361, 10);
            panel6.TabIndex = 16;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(0, 45);
            panel7.Margin = new Padding(4, 3, 4, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(361, 10);
            panel7.TabIndex = 19;
            // 
            // panel31
            // 
            panel31.Controls.Add(panel32);
            panel31.Controls.Add(panel33);
            panel31.Controls.Add(panel34);
            panel31.Controls.Add(panel35);
            panel31.Controls.Add(panel36);
            panel31.Dock = DockStyle.Bottom;
            panel31.Location = new Point(11, 597);
            panel31.Margin = new Padding(4);
            panel31.Name = "panel31";
            panel31.Size = new Size(688, 11);
            panel31.TabIndex = 14;
            // 
            // panel32
            // 
            panel32.Dock = DockStyle.Fill;
            panel32.Location = new Point(0, 0);
            panel32.Margin = new Padding(4);
            panel32.Name = "panel32";
            panel32.Size = new Size(688, 11);
            panel32.TabIndex = 20;
            // 
            // panel33
            // 
            panel33.Dock = DockStyle.Right;
            panel33.Location = new Point(688, 0);
            panel33.Margin = new Padding(4);
            panel33.Name = "panel33";
            panel33.Size = new Size(0, 11);
            panel33.TabIndex = 18;
            // 
            // panel34
            // 
            panel34.Dock = DockStyle.Left;
            panel34.Location = new Point(0, 0);
            panel34.Margin = new Padding(4);
            panel34.Name = "panel34";
            panel34.Size = new Size(0, 11);
            panel34.TabIndex = 17;
            // 
            // panel35
            // 
            panel35.Dock = DockStyle.Top;
            panel35.Location = new Point(0, 0);
            panel35.Margin = new Padding(4);
            panel35.Name = "panel35";
            panel35.Size = new Size(688, 0);
            panel35.TabIndex = 16;
            // 
            // panel36
            // 
            panel36.Dock = DockStyle.Bottom;
            panel36.Location = new Point(0, 11);
            panel36.Margin = new Padding(4);
            panel36.Name = "panel36";
            panel36.Size = new Size(688, 0);
            panel36.TabIndex = 19;
            // 
            // panel37
            // 
            panel37.Controls.Add(userControlChart);
            panel37.Controls.Add(chartData);
            panel37.Dock = DockStyle.Fill;
            panel37.Location = new Point(11, 11);
            panel37.Name = "panel37";
            panel37.Size = new Size(688, 597);
            panel37.TabIndex = 15;
            // 
            // userControlChart
            // 
            userControlChart.Coordinator = null;
            userControlChart.Dock = DockStyle.Fill;
            userControlChart.IsBlocked = true;
            userControlChart.Location = new Point(0, 0);
            userControlChart.Margin = new Padding(4, 3, 4, 3);
            userControlChart.Name = "userControlChart";
            userControlChart.Size = new Size(688, 597);
            userControlChart.TabIndex = 1;
            // 
            // chartData
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.Name = "ChartAreaStock";
            chartData.ChartAreas.Add(chartArea1);
            chartData.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartData.Legends.Add(legend1);
            chartData.Location = new Point(0, 0);
            chartData.Name = "chartData";
            series1.ChartArea = "ChartAreaStock";
            series1.ChartType = SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=LightSalmon, PriceUpColor=GreenYellow";
            series1.Legend = "Legend1";
            series1.Name = "SeriesStock";
            series1.XValueType = ChartValueType.DateTime;
            series1.YValuesPerPoint = 4;
            series2.BorderColor = Color.White;
            series2.ChartArea = "ChartAreaStock";
            series2.ChartType = SeriesChartType.Spline;
            series2.Color = Color.ForestGreen;
            series2.Legend = "Legend1";
            series2.Name = "SeriesTop";
            series3.ChartArea = "ChartAreaStock";
            series3.ChartType = SeriesChartType.Spline;
            series3.Color = Color.Crimson;
            series3.Legend = "Legend1";
            series3.Name = "SeriesBotton";
            series4.ChartArea = "ChartAreaStock";
            series4.ChartType = SeriesChartType.Line;
            series4.Color = Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "SeriesDunUp";
            series5.ChartArea = "ChartAreaStock";
            series5.ChartType = SeriesChartType.Line;
            series5.Color = Color.Blue;
            series5.Legend = "Legend1";
            series5.Name = "SeriesDunDown";
            series6.ChartArea = "ChartAreaStock";
            series6.ChartType = SeriesChartType.FastPoint;
            series6.Color = Color.ForestGreen;
            series6.CustomProperties = "OpenCloseStyle=Triangle";
            series6.Legend = "Legend1";
            series6.Name = "SeriesBUY";
            series6.YValuesPerPoint = 4;
            series7.ChartArea = "ChartAreaStock";
            series7.ChartType = SeriesChartType.FastPoint;
            series7.Color = Color.Red;
            series7.Legend = "Legend1";
            series7.Name = "SeriesSELL";
            series7.YValuesPerPoint = 4;
            series8.ChartArea = "ChartAreaStock";
            series8.ChartType = SeriesChartType.Line;
            series8.Color = Color.LightCoral;
            series8.Legend = "Legend1";
            series8.Name = "SeriesIncome";
            chartData.Series.Add(series1);
            chartData.Series.Add(series2);
            chartData.Series.Add(series3);
            chartData.Series.Add(series4);
            chartData.Series.Add(series5);
            chartData.Series.Add(series6);
            chartData.Series.Add(series7);
            chartData.Series.Add(series8);
            chartData.Size = new Size(688, 597);
            chartData.TabIndex = 0;
            chartData.Text = "chart1";
            // 
            // panel38
            // 
            panel38.Dock = DockStyle.Right;
            panel38.Location = new Point(699, 11);
            panel38.Margin = new Padding(4);
            panel38.Name = "panel38";
            panel38.Size = new Size(11, 597);
            panel38.TabIndex = 13;
            // 
            // panel39
            // 
            panel39.Dock = DockStyle.Left;
            panel39.Location = new Point(0, 11);
            panel39.Margin = new Padding(4);
            panel39.Name = "panel39";
            panel39.Size = new Size(11, 597);
            panel39.TabIndex = 12;
            // 
            // panel40
            // 
            panel40.Dock = DockStyle.Top;
            panel40.Location = new Point(0, 0);
            panel40.Margin = new Padding(4);
            panel40.Name = "panel40";
            panel40.Size = new Size(710, 11);
            panel40.TabIndex = 11;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 683);
            Controls.Add(panelCenter);
            Controls.Add(panelTop);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelBottom);
            Controls.Add(toolStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "Trading analisys";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            panelCenter.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelLeftSplit.ResumeLayout(false);
            panel26.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)longNum).EndInit();
            panel27.ResumeLayout(false);
            panel27.PerformLayout();
            panel29.ResumeLayout(false);
            panel41.ResumeLayout(false);
            panel42.ResumeLayout(false);
            panel42.PerformLayout();
            panel44.ResumeLayout(false);
            panel44.PerformLayout();
            panel30.ResumeLayout(false);
            panel45.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownDonchian).EndInit();
            panel47.ResumeLayout(false);
            panel47.PerformLayout();
            panel1.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)shortNum).EndInit();
            panel23.ResumeLayout(false);
            panel23.PerformLayout();
            panel16.ResumeLayout(false);
            panel17.ResumeLayout(false);
            panel19.ResumeLayout(false);
            panel19.PerformLayout();
            panel9.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel31.ResumeLayout(false);
            panel37.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTop;
        private ToolStripMenuItem toolsMenu;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem helpMenu;
        private ToolStripMenuItem contentsToolStripMenuItem;
        private ToolStripMenuItem indexToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem statusBarToolStripMenuItem;
        private ToolStripMenuItem toolBarToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem viewMenu;
        private ToolStripMenuItem newToolStripMenuItem;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripMenuItem printSetupToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editMenu;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private Panel panelRight;
        private Panel panelLeft;
        private Panel panelBottom;
        private ToolStripButton printToolStripButton;
        private ToolStripButton printPreviewToolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton saveToolStripButton;
        private ToolStripButton openToolStripButton;
        private ToolStrip toolStrip;
        private ToolStripButton newToolStripButton;
        private ToolStripButton helpToolStripButton;
        private Panel panelCenter;
        private SplitContainer splitContainer1;
        private Panel panelLeftSplit;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private ComboBox comboBoxSymbols;
        private Panel panel4;
        private Panel panel5;
        private Label label1;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel15;
        private Panel panel16;
        private Panel panel17;
        private DateTimePicker dateEnd;
        private Panel panel18;
        private Panel panel19;
        private Label label3;
        private Panel panel20;
        private Panel panel21;
        private Panel panel9;
        private Panel panel10;
        private DateTimePicker dateBegin;
        private Panel panel11;
        private Panel panel12;
        private Label label2;
        private Panel panel13;
        private Panel panel14;
        private ToolStripButton toolStripButtonStart;
        private Panel panel26;
        private NumericUpDown longNum;
        private Panel panel27;
        private Label label5;
        private Panel panel28;
        private Panel panel29;
        private Panel panel22;
        private NumericUpDown shortNum;
        private Panel panel23;
        private Label label4;
        private Panel panel24;
        private Panel panel25;
        private Panel panel30;
        private Panel panel31;
        private Panel panel32;
        private Panel panel33;
        private Panel panel34;
        private Panel panel35;
        private Panel panel36;
        private Panel panel37;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartData;
        private Panel panel38;
        private Panel panel39;
        private Panel panel40;
        private Panel panel41;
        private ComboBox comboBoxBarSize;
        private Panel panel42;
        private Label label7;
        private Panel panel43;
        private Panel panel44;
        private Panel panel45;
        private NumericUpDown numericUpDownDonchian;
        private Panel panel46;
        private Panel panel47;
        private Panel panel48;
        private Panel panel49;
        private Label label6;
        private Label labelIncome;
        private ChartAPI.UserControls.UserControlChart userControlChart;
        private Label labelMouseIndicator;
    }
}