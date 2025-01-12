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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlLog));
            panelCenter = new System.Windows.Forms.Panel();
            userControlFileDataBaseLog = new UserControlFileDataBaseLog();
            userControlFileLog = new UserControlFileLog();
            panelRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            panel7 = new System.Windows.Forms.Panel();
            toolStripMain = new System.Windows.Forms.ToolStrip();
            openToolStripButton = new System.Windows.Forms.ToolStripButton();
            saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            toolStripLabelBegin = new System.Windows.Forms.ToolStripLabel();
            toolStripTextBoxBegin = new System.Windows.Forms.ToolStripTextBox();
            toolStripLabelEnd = new System.Windows.Forms.ToolStripLabel();
            toolStripTextBoxEnd = new System.Windows.Forms.ToolStripTextBox();
            panel4 = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItemLogDirectory = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemConnectionString = new System.Windows.Forms.ToolStripMenuItem();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            panelCenter.SuspendLayout();
            panelTop.SuspendLayout();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            toolStripMain.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(userControlFileDataBaseLog);
            panelCenter.Controls.Add(userControlFileLog);
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(0, 29);
            panelCenter.Margin = new System.Windows.Forms.Padding(4);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(468, 185);
            panelCenter.TabIndex = 20;
            // 
            // userControlFileDataBaseLog
            // 
            userControlFileDataBaseLog.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlFileDataBaseLog.Location = new System.Drawing.Point(0, 0);
            userControlFileDataBaseLog.Name = "userControlFileDataBaseLog";
            userControlFileDataBaseLog.Size = new System.Drawing.Size(468, 185);
            userControlFileDataBaseLog.TabIndex = 1;
            userControlFileDataBaseLog.Visible = false;
            // 
            // userControlFileLog
            // 
            userControlFileLog.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlFileLog.Location = new System.Drawing.Point(0, 0);
            userControlFileLog.Name = "userControlFileLog";
            userControlFileLog.Size = new System.Drawing.Size(468, 185);
            userControlFileLog.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(468, 29);
            panelRight.Margin = new System.Windows.Forms.Padding(4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(0, 185);
            panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 29);
            panelLeft.Margin = new System.Windows.Forms.Padding(4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(0, 185);
            panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(panel2);
            panelTop.Controls.Add(panel3);
            panelTop.Controls.Add(panel4);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(468, 29);
            panelTop.TabIndex = 16;
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Left;
            panel2.Location = new System.Drawing.Point(0, 34);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(0, 0);
            panel2.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel7);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Margin = new System.Windows.Forms.Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(468, 34);
            panel3.TabIndex = 10;
            // 
            // panel7
            // 
            panel7.Controls.Add(toolStripMain);
            panel7.Dock = System.Windows.Forms.DockStyle.Top;
            panel7.Location = new System.Drawing.Point(0, 0);
            panel7.Margin = new System.Windows.Forms.Padding(4);
            panel7.Name = "panel7";
            panel7.Size = new System.Drawing.Size(468, 35);
            panel7.TabIndex = 10;
            // 
            // toolStripMain
            // 
            toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { openToolStripButton, saveToolStripButton, toolStripLabelBegin, toolStripTextBoxBegin, toolStripLabelEnd, toolStripTextBoxEnd });
            toolStripMain.Location = new System.Drawing.Point(0, 0);
            toolStripMain.Name = "toolStripMain";
            toolStripMain.Size = new System.Drawing.Size(468, 27);
            toolStripMain.TabIndex = 6;
            toolStripMain.Text = "Main";
            // 
            // openToolStripButton
            // 
            openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            openToolStripButton.Image = (System.Drawing.Image)resources.GetObject("openToolStripButton.Image");
            openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            openToolStripButton.Name = "openToolStripButton";
            openToolStripButton.Size = new System.Drawing.Size(24, 24);
            openToolStripButton.Text = "&Open";
            openToolStripButton.Visible = false;
            // 
            // saveToolStripButton
            // 
            saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            saveToolStripButton.Image = (System.Drawing.Image)resources.GetObject("saveToolStripButton.Image");
            saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveToolStripButton.Name = "saveToolStripButton";
            saveToolStripButton.Size = new System.Drawing.Size(24, 24);
            saveToolStripButton.Text = "&Save";
            saveToolStripButton.Click += saveToolStripButton_Click;
            // 
            // toolStripLabelBegin
            // 
            toolStripLabelBegin.Name = "toolStripLabelBegin";
            toolStripLabelBegin.Size = new System.Drawing.Size(37, 24);
            toolStripLabelBegin.Text = "Begin";
            // 
            // toolStripTextBoxBegin
            // 
            toolStripTextBoxBegin.Name = "toolStripTextBoxBegin";
            toolStripTextBoxBegin.Size = new System.Drawing.Size(116, 27);
            // 
            // toolStripLabelEnd
            // 
            toolStripLabelEnd.Name = "toolStripLabelEnd";
            toolStripLabelEnd.Size = new System.Drawing.Size(27, 24);
            toolStripLabelEnd.Text = "End";
            // 
            // toolStripTextBoxEnd
            // 
            toolStripTextBoxEnd.Name = "toolStripTextBoxEnd";
            toolStripTextBoxEnd.Size = new System.Drawing.Size(116, 27);
            // 
            // panel4
            // 
            panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel4.Location = new System.Drawing.Point(0, 29);
            panel4.Margin = new System.Windows.Forms.Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(468, 0);
            panel4.TabIndex = 13;
            // 
            // panelBottom
            // 
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 214);
            panelBottom.Margin = new System.Windows.Forms.Padding(4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(468, 0);
            panelBottom.TabIndex = 19;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Serialiable files |*.serializable;*.zip";
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemLogDirectory, toolStripMenuItemConnectionString });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new System.Drawing.Size(174, 48);
            // 
            // toolStripMenuItemLogDirectory
            // 
            toolStripMenuItemLogDirectory.Name = "toolStripMenuItemLogDirectory";
            toolStripMenuItemLogDirectory.Size = new System.Drawing.Size(173, 22);
            toolStripMenuItemLogDirectory.Text = "Open log directory";
            // 
            // toolStripMenuItemConnectionString
            // 
            toolStripMenuItemConnectionString.Name = "toolStripMenuItemConnectionString";
            toolStripMenuItemConnectionString.Size = new System.Drawing.Size(173, 22);
            toolStripMenuItemConnectionString.Text = "Connection string";
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "Serialiable files |*.filelog;";
            // 
            // UserControlLog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ContextMenuStrip = contextMenuStrip;
            Controls.Add(panelCenter);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "UserControlLog";
            Size = new System.Drawing.Size(468, 214);
            Load += UserControlLog_Load;
            panelCenter.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            toolStripMain.ResumeLayout(false);
            toolStripMain.PerformLayout();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
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
