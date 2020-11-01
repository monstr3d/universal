namespace Event.UI.UserControls
{
    partial class UserControlFileDataBaseLog
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
            this.panelCenter = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageFile = new System.Windows.Forms.TabPage();
            this.userControlFileLog = new Event.UI.UserControls.UserControlFileLog();
            this.tabPageDatabase = new System.Windows.Forms.TabPage();
            this.panelDataBase = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelCenter.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageFile.SuspendLayout();
            this.tabPageDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControl);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(4);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(298, 219);
            this.panelCenter.TabIndex = 20;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageFile);
            this.tabControl.Controls.Add(this.tabPageDatabase);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(298, 219);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageFile
            // 
            this.tabPageFile.Controls.Add(this.userControlFileLog);
            this.tabPageFile.Location = new System.Drawing.Point(4, 25);
            this.tabPageFile.Name = "tabPageFile";
            this.tabPageFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFile.Size = new System.Drawing.Size(290, 190);
            this.tabPageFile.TabIndex = 0;
            this.tabPageFile.Text = "File log";
            this.tabPageFile.UseVisualStyleBackColor = true;
            // 
            // userControlFileLog
            // 
            this.userControlFileLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlFileLog.Location = new System.Drawing.Point(3, 3);
            this.userControlFileLog.Name = "userControlFileLog";
            this.userControlFileLog.Size = new System.Drawing.Size(284, 184);
            this.userControlFileLog.TabIndex = 0;
            // 
            // tabPageDatabase
            // 
            this.tabPageDatabase.Controls.Add(this.panelDataBase);
            this.tabPageDatabase.Location = new System.Drawing.Point(4, 25);
            this.tabPageDatabase.Name = "tabPageDatabase";
            this.tabPageDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDatabase.Size = new System.Drawing.Size(290, 190);
            this.tabPageDatabase.TabIndex = 1;
            this.tabPageDatabase.Text = "Database log";
            this.tabPageDatabase.UseVisualStyleBackColor = true;
            // 
            // panelDataBase
            // 
            this.panelDataBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDataBase.Location = new System.Drawing.Point(3, 3);
            this.panelDataBase.Name = "panelDataBase";
            this.panelDataBase.Size = new System.Drawing.Size(284, 184);
            this.panelDataBase.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(298, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 219);
            this.panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 219);
            this.panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(298, 0);
            this.panelTop.TabIndex = 16;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 219);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(298, 0);
            this.panelBottom.TabIndex = 19;
            // 
            // UserControlFileDataBaseLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlFileDataBaseLog";
            this.Size = new System.Drawing.Size(298, 219);
            this.Load += new System.EventHandler(this.UserControlFileDataBaseLog_Load);
            this.panelCenter.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageFile.ResumeLayout(false);
            this.tabPageDatabase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageFile;
        private System.Windows.Forms.TabPage tabPageDatabase;
        private UserControlFileLog userControlFileLog;
        private System.Windows.Forms.Panel panelDataBase;
    }
}
