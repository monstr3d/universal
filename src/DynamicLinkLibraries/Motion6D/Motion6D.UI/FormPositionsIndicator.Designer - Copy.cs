namespace Motion6D.UI
{
    partial class FormPositionsIndicator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPositionsIndicator));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelLeftLeft = new System.Windows.Forms.Panel();
            this.panelTopTop = new System.Windows.Forms.Panel();
            this.panelBottomBottom = new System.Windows.Forms.Panel();
            this.panelRightRight = new System.Windows.Forms.Panel();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.panelChart = new System.Windows.Forms.Panel();
            this.panelBottom.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.comboBoxType);
            this.panelBottom.Controls.Add(this.buttonAccept);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(10, 468);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(907, 50);
            this.panelBottom.TabIndex = 14;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(639, 15);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 0;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(917, 49);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(10, 469);
            this.panelRight.TabIndex = 13;
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonClear});
            this.toolStripMain.Location = new System.Drawing.Point(10, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(917, 25);
            this.toolStripMain.TabIndex = 10;
            this.toolStripMain.Text = "Main";
            // 
            // toolStripButtonClear
            // 
            this.toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClear.Image")));
            this.toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClear.Name = "toolStripButtonClear";
            this.toolStripButtonClear.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClear.Text = "Clear";
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 24);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(10, 494);
            this.panelLeft.TabIndex = 11;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(927, 24);
            this.menuStripMain.TabIndex = 9;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.panelChart);
            this.panelCenter.Controls.Add(this.panelRightRight);
            this.panelCenter.Controls.Add(this.panelBottomBottom);
            this.panelCenter.Controls.Add(this.panelTopTop);
            this.panelCenter.Controls.Add(this.panelLeftLeft);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(10, 49);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(907, 419);
            this.panelCenter.TabIndex = 15;
            // 
            // panelLeftLeft
            // 
            this.panelLeftLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeftLeft.Name = "panelLeftLeft";
            this.panelLeftLeft.Size = new System.Drawing.Size(10, 419);
            this.panelLeftLeft.TabIndex = 0;
            // 
            // panelTopTop
            // 
            this.panelTopTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopTop.Location = new System.Drawing.Point(10, 0);
            this.panelTopTop.Name = "panelTopTop";
            this.panelTopTop.Size = new System.Drawing.Size(897, 8);
            this.panelTopTop.TabIndex = 1;
            // 
            // panelBottomBottom
            // 
            this.panelBottomBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomBottom.Location = new System.Drawing.Point(10, 411);
            this.panelBottomBottom.Name = "panelBottomBottom";
            this.panelBottomBottom.Size = new System.Drawing.Size(897, 8);
            this.panelBottomBottom.TabIndex = 2;
            // 
            // panelRightRight
            // 
            this.panelRightRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightRight.Location = new System.Drawing.Point(897, 8);
            this.panelRightRight.Name = "panelRightRight";
            this.panelRightRight.Size = new System.Drawing.Size(10, 403);
            this.panelRightRight.TabIndex = 3;
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(72, 15);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(444, 21);
            this.comboBoxType.TabIndex = 1;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // panelChart
            // 
            this.panelChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChart.Location = new System.Drawing.Point(10, 8);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(887, 403);
            this.panelChart.TabIndex = 4;
            // 
            // FormPositionsIndicatror
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 518);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.menuStripMain);
            this.Name = "FormPositionsIndicatror";
            this.Text = "FormPositionsIndicatror";
            this.panelBottom.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonClear;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRightRight;
        private System.Windows.Forms.Panel panelBottomBottom;
        private System.Windows.Forms.Panel panelTopTop;
        private System.Windows.Forms.Panel panelLeftLeft;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Panel panelChart;

    }
}