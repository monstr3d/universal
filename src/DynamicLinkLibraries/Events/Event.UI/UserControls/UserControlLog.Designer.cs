namespace Event.UI.UserControls
{
    partial class UserControlLog
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlLog));
            this.panelCenter = new System.Windows.Forms.Panel();
            this.userControlFileDataBaseLog = new Event.UI.UserControls.UserControlFileDataBaseLog();
            this.userControlFileLog = new Event.UI.UserControls.UserControlFileLog();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelBegin = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxBegin = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabelEnd = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxEnd = new System.Windows.Forms.ToolStripTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemLogDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemConnectionString = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panelCenter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.userControlFileDataBaseLog);
            this.panelCenter.Controls.Add(this.userControlFileLog);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 31);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(4);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(535, 197);
            this.panelCenter.TabIndex = 20;
            // 
            // userControlFileDataBaseLog
            // 
            this.userControlFileDataBaseLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlFileDataBaseLog.Location = new System.Drawing.Point(0, 0);
            this.userControlFileDataBaseLog.Name = "userControlFileDataBaseLog";
            this.userControlFileDataBaseLog.Size = new System.Drawing.Size(535, 197);
            this.userControlFileDataBaseLog.TabIndex = 1;
            this.userControlFileDataBaseLog.Visible = false;
            // 
            // userControlFileLog
            // 
            this.userControlFileLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlFileLog.Location = new System.Drawing.Point(0, 0);
            this.userControlFileLog.Name = "userControlFileLog";
            this.userControlFileLog.Size = new System.Drawing.Size(535, 197);
            this.userControlFileLog.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(535, 31);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 197);
            this.panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 31);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 197);
            this.panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panel2);
            this.panelTop.Controls.Add(this.panel3);
            this.panelTop.Controls.Add(this.panel4);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(535, 31);
            this.panelTop.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 0);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(535, 36);
            this.panel3.TabIndex = 10;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.toolStripMain);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(535, 37);
            this.panel7.TabIndex = 10;
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripLabelBegin,
            this.toolStripTextBoxBegin,
            this.toolStripLabelEnd,
            this.toolStripTextBoxEnd});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(535, 27);
            this.toolStripMain.TabIndex = 6;
            this.toolStripMain.Text = "Main";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Visible = false;
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripLabelBegin
            // 
            this.toolStripLabelBegin.Name = "toolStripLabelBegin";
            this.toolStripLabelBegin.Size = new System.Drawing.Size(47, 24);
            this.toolStripLabelBegin.Text = "Begin";
            // 
            // toolStripTextBoxBegin
            // 
            this.toolStripTextBoxBegin.Name = "toolStripTextBoxBegin";
            this.toolStripTextBoxBegin.Size = new System.Drawing.Size(132, 27);
            // 
            // toolStripLabelEnd
            // 
            this.toolStripLabelEnd.Name = "toolStripLabelEnd";
            this.toolStripLabelEnd.Size = new System.Drawing.Size(34, 24);
            this.toolStripLabelEnd.Text = "End";
            // 
            // toolStripTextBoxEnd
            // 
            this.toolStripTextBoxEnd.Name = "toolStripTextBoxEnd";
            this.toolStripTextBoxEnd.Size = new System.Drawing.Size(132, 27);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 31);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(535, 0);
            this.panel4.TabIndex = 13;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 228);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(535, 0);
            this.panelBottom.TabIndex = 19;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Serialiable files |*.serializable;*.zip";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLogDirectory,
            this.toolStripMenuItemConnectionString});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(210, 56);
            // 
            // toolStripMenuItemLogDirectory
            // 
            this.toolStripMenuItemLogDirectory.Name = "toolStripMenuItemLogDirectory";
            this.toolStripMenuItemLogDirectory.Size = new System.Drawing.Size(209, 26);
            this.toolStripMenuItemLogDirectory.Text = "Open log directory";
            // 
            // toolStripMenuItemConnectionString
            // 
            this.toolStripMenuItemConnectionString.Name = "toolStripMenuItemConnectionString";
            this.toolStripMenuItemConnectionString.Size = new System.Drawing.Size(209, 26);
            this.toolStripMenuItemConnectionString.Text = "Connection string";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Serialiable files |*.filelog;";
            // 
            // UserControlLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlLog";
            this.Size = new System.Drawing.Size(535, 228);
            this.Load += new System.EventHandler(this.UserControlLog_Load);
            this.panelCenter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLogDirectory;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConnectionString;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabelBegin;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxBegin;
        private System.Windows.Forms.ToolStripLabel toolStripLabelEnd;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxEnd;
        private UserControlFileLog userControlFileLog;
        private UserControlFileDataBaseLog userControlFileDataBaseLog;
    }
}
