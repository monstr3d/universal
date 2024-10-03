using CategoryTheory;
using Diagram.UI;
using FormulaEditor;
using FormulaEditor.UI;
using ToolBox;
using DataTableSelection;



namespace Database.UI.Forms
{
    partial class FormStatementSelection
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
            //NamedComponent.RemoveForm(label);
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatementSelection));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateCreationScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDatabaseDriver = new System.Windows.Forms.ComboBox();
            this.textBoxConnection = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.labelNumber = new System.Windows.Forms.Label();
            this.checkBoxShowData = new System.Windows.Forms.CheckBox();
            this.buttonDiagram = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.textBoxStatement = new System.Windows.Forms.TextBox();
            this.panelSplitTopBottom = new System.Windows.Forms.Panel();
            this.panelSplitTopRight = new System.Windows.Forms.Panel();
            this.panelSplitTopLeft = new System.Windows.Forms.Panel();
            this.panelSplitTopTop = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            this.panelSplitBootomTop = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panelSplitBottomRight = new System.Windows.Forms.Panel();
            this.panelSplitBottomBottom = new System.Windows.Forms.Panel();
            this.panelSplitBottomLeft = new System.Windows.Forms.Panel();
            this.openFileDialogData = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogData = new System.Windows.Forms.SaveFileDialog();
            this.menuStripMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panelSplitTopTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
            this.panelSplitBootomTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 49);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(10, 504);
            this.panelLeft.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(532, 49);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(10, 504);
            this.panelRight.TabIndex = 7;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(542, 24);
            this.menuStripMain.TabIndex = 8;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveasToolStripMenuItem,
            this.generateCreationScriptToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveasToolStripMenuItem
            // 
            this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
            this.saveasToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.saveasToolStripMenuItem.Text = "Save as";
            this.saveasToolStripMenuItem.Click += new System.EventHandler(this.saveasToolStripMenuItem_Click);
            // 
            // generateCreationScriptToolStripMenuItem
            // 
            this.generateCreationScriptToolStripMenuItem.Name = "generateCreationScriptToolStripMenuItem";
            this.generateCreationScriptToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.generateCreationScriptToolStripMenuItem.Text = "Generate creation script";
            this.generateCreationScriptToolStripMenuItem.Click += new System.EventHandler(this.generateCreationScriptToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonSave});
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(542, 25);
            this.toolStripMain.TabIndex = 9;
            this.toolStripMain.Text = "Main";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image")));
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.Text = "Open";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.comboBoxDatabaseDriver);
            this.panelTop.Controls.Add(this.textBoxConnection);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(10, 49);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(522, 102);
            this.panelTop.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Connection string";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Database driver";
            // 
            // comboBoxDatabaseDriver
            // 
            this.comboBoxDatabaseDriver.FormattingEnabled = true;
            this.comboBoxDatabaseDriver.Location = new System.Drawing.Point(169, 8);
            this.comboBoxDatabaseDriver.Name = "comboBoxDatabaseDriver";
            this.comboBoxDatabaseDriver.Size = new System.Drawing.Size(326, 21);
            this.comboBoxDatabaseDriver.TabIndex = 7;
            // 
            // textBoxConnection
            // 
            this.textBoxConnection.Location = new System.Drawing.Point(29, 70);
            this.textBoxConnection.Name = "textBoxConnection";
            this.textBoxConnection.Size = new System.Drawing.Size(466, 20);
            this.textBoxConnection.TabIndex = 6;
            // 
            // panelBottom
            // 
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.labelNumber);
            this.panelBottom.Controls.Add(this.checkBoxShowData);
            this.panelBottom.Controls.Add(this.buttonDiagram);
            this.panelBottom.Controls.Add(this.buttonAccept);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(10, 500);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(522, 53);
            this.panelBottom.TabIndex = 11;
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(311, 19);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(87, 13);
            this.labelNumber.TabIndex = 10;
            this.labelNumber.Text = "Number of rows: ";
            // 
            // checkBoxShowData
            // 
            this.checkBoxShowData.AutoSize = true;
            this.checkBoxShowData.Location = new System.Drawing.Point(185, 18);
            this.checkBoxShowData.Name = "checkBoxShowData";
            this.checkBoxShowData.Size = new System.Drawing.Size(77, 17);
            this.checkBoxShowData.TabIndex = 9;
            this.checkBoxShowData.Text = "Show data";
            this.checkBoxShowData.Click += new System.EventHandler(this.checkBoxShowData_Click);
            // 
            // buttonDiagram
            // 
            this.buttonDiagram.Location = new System.Drawing.Point(91, 18);
            this.buttonDiagram.Name = "buttonDiagram";
            this.buttonDiagram.Size = new System.Drawing.Size(75, 23);
            this.buttonDiagram.TabIndex = 8;
            this.buttonDiagram.Text = "Diagram";
            this.buttonDiagram.Click += new System.EventHandler(this.buttonDiagram_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(10, 18);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 7;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.splitContainerMain);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(10, 151);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(522, 349);
            this.panelCenter.TabIndex = 12;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.textBoxStatement);
            this.splitContainerMain.Panel1.Controls.Add(this.panelSplitTopBottom);
            this.splitContainerMain.Panel1.Controls.Add(this.panelSplitTopRight);
            this.splitContainerMain.Panel1.Controls.Add(this.panelSplitTopLeft);
            this.splitContainerMain.Panel1.Controls.Add(this.panelSplitTopTop);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.dataGridViewTable);
            this.splitContainerMain.Panel2.Controls.Add(this.panelSplitBootomTop);
            this.splitContainerMain.Panel2.Controls.Add(this.panelSplitBottomRight);
            this.splitContainerMain.Panel2.Controls.Add(this.panelSplitBottomBottom);
            this.splitContainerMain.Panel2.Controls.Add(this.panelSplitBottomLeft);
            this.splitContainerMain.Size = new System.Drawing.Size(522, 349);
            this.splitContainerMain.SplitterDistance = 124;
            this.splitContainerMain.TabIndex = 7;
            this.splitContainerMain.Text = "splitContainer1";
            // 
            // textBoxStatement
            // 
            this.textBoxStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStatement.Location = new System.Drawing.Point(10, 38);
            this.textBoxStatement.Multiline = true;
            this.textBoxStatement.Name = "textBoxStatement";
            this.textBoxStatement.Size = new System.Drawing.Size(502, 76);
            this.textBoxStatement.TabIndex = 6;
            // 
            // panelSplitTopBottom
            // 
            this.panelSplitTopBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSplitTopBottom.Location = new System.Drawing.Point(10, 114);
            this.panelSplitTopBottom.Name = "panelSplitTopBottom";
            this.panelSplitTopBottom.Size = new System.Drawing.Size(502, 10);
            this.panelSplitTopBottom.TabIndex = 3;
            // 
            // panelSplitTopRight
            // 
            this.panelSplitTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSplitTopRight.Location = new System.Drawing.Point(512, 38);
            this.panelSplitTopRight.Name = "panelSplitTopRight";
            this.panelSplitTopRight.Size = new System.Drawing.Size(10, 86);
            this.panelSplitTopRight.TabIndex = 2;
            // 
            // panelSplitTopLeft
            // 
            this.panelSplitTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSplitTopLeft.Location = new System.Drawing.Point(0, 38);
            this.panelSplitTopLeft.Name = "panelSplitTopLeft";
            this.panelSplitTopLeft.Size = new System.Drawing.Size(10, 86);
            this.panelSplitTopLeft.TabIndex = 1;
            // 
            // panelSplitTopTop
            // 
            this.panelSplitTopTop.Controls.Add(this.label3);
            this.panelSplitTopTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSplitTopTop.Location = new System.Drawing.Point(0, 0);
            this.panelSplitTopTop.Name = "panelSplitTopTop";
            this.panelSplitTopTop.Size = new System.Drawing.Size(522, 38);
            this.panelSplitTopTop.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "SQL query";
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTable.Location = new System.Drawing.Point(10, 29);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.Size = new System.Drawing.Size(502, 182);
            this.dataGridViewTable.TabIndex = 7;
            this.dataGridViewTable.Text = "dataGridView1";
            // 
            // panelSplitBootomTop
            // 
            this.panelSplitBootomTop.Controls.Add(this.label4);
            this.panelSplitBootomTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSplitBootomTop.Location = new System.Drawing.Point(10, 0);
            this.panelSplitBootomTop.Name = "panelSplitBootomTop";
            this.panelSplitBootomTop.Size = new System.Drawing.Size(502, 29);
            this.panelSplitBootomTop.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Result";
            // 
            // panelSplitBottomRight
            // 
            this.panelSplitBottomRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSplitBottomRight.Location = new System.Drawing.Point(512, 0);
            this.panelSplitBottomRight.Name = "panelSplitBottomRight";
            this.panelSplitBottomRight.Size = new System.Drawing.Size(10, 211);
            this.panelSplitBottomRight.TabIndex = 2;
            // 
            // panelSplitBottomBottom
            // 
            this.panelSplitBottomBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSplitBottomBottom.Location = new System.Drawing.Point(10, 211);
            this.panelSplitBottomBottom.Name = "panelSplitBottomBottom";
            this.panelSplitBottomBottom.Size = new System.Drawing.Size(512, 10);
            this.panelSplitBottomBottom.TabIndex = 1;
            // 
            // panelSplitBottomLeft
            // 
            this.panelSplitBottomLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSplitBottomLeft.Location = new System.Drawing.Point(0, 0);
            this.panelSplitBottomLeft.Name = "panelSplitBottomLeft";
            this.panelSplitBottomLeft.Size = new System.Drawing.Size(10, 221);
            this.panelSplitBottomLeft.TabIndex = 0;
            // 
            // openFileDialogData
            // 
            this.openFileDialogData.Filter = "Xml Files|*.xml";
            // 
            // saveFileDialogData
            // 
            this.saveFileDialogData.Filter = "Xml Files|*.xml";
            // 
            // FormStatementSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 553);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormStatementSelection";
            this.Text = "FormODBCSelection";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.panelSplitTopTop.ResumeLayout(false);
            this.panelSplitTopTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            this.panelSplitBootomTop.ResumeLayout(false);
            this.panelSplitBootomTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ComboBox comboBoxDatabaseDriver;
        private System.Windows.Forms.TextBox textBoxConnection;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonDiagram;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel panelSplitTopTop;
        private System.Windows.Forms.Panel panelSplitTopLeft;
        private System.Windows.Forms.Panel panelSplitTopRight;
        private System.Windows.Forms.Panel panelSplitTopBottom;
        private System.Windows.Forms.TextBox textBoxStatement;
        private System.Windows.Forms.Panel panelSplitBottomLeft;
        private System.Windows.Forms.Panel panelSplitBottomBottom;
        private System.Windows.Forms.Panel panelSplitBottomRight;
        private System.Windows.Forms.Panel panelSplitBootomTop;
        private System.Windows.Forms.CheckBox checkBoxShowData;
        private System.Windows.Forms.DataGridView dataGridViewTable;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.OpenFileDialog openFileDialogData;
        private System.Windows.Forms.SaveFileDialog saveFileDialogData;
        private System.Windows.Forms.ToolStripMenuItem generateCreationScriptToolStripMenuItem;
    }
}