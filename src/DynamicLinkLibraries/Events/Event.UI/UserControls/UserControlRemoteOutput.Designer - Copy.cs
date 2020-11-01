namespace Event.UI.UserControls
{
    partial class UserControlRemoteOutput
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
            this.panelCenterMain = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageInput = new System.Windows.Forms.TabPage();
            this.tabPageParameters = new System.Windows.Forms.TabPage();
            this.panelCenterPar = new System.Windows.Forms.Panel();
            this.panelPar = new System.Windows.Forms.Panel();
            this.panelRightPar = new System.Windows.Forms.Panel();
            this.panelLeftPar = new System.Windows.Forms.Panel();
            this.panelTopPar = new System.Windows.Forms.Panel();
            this.panelBottomPar = new System.Windows.Forms.Panel();
            this.panelRightMain = new System.Windows.Forms.Panel();
            this.panelLeftMain = new System.Windows.Forms.Panel();
            this.panelTopMain = new System.Windows.Forms.Panel();
            this.panelBottomMain = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.userControlWriter = new Event.UI.UserControls.UserControlWriter();
            this.panelCenterMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageInput.SuspendLayout();
            this.tabPageParameters.SuspendLayout();
            this.panelCenterPar.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenterMain
            // 
            this.panelCenterMain.Controls.Add(this.tabControl);
            this.panelCenterMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterMain.Location = new System.Drawing.Point(0, 0);
            this.panelCenterMain.Name = "panelCenterMain";
            this.panelCenterMain.Size = new System.Drawing.Size(239, 228);
            this.panelCenterMain.TabIndex = 20;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageInput);
            this.tabControl.Controls.Add(this.tabPageParameters);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(239, 228);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageInput
            // 
            this.tabPageInput.Controls.Add(this.panelCenter);
            this.tabPageInput.Controls.Add(this.panelRight);
            this.tabPageInput.Controls.Add(this.panelLeft);
            this.tabPageInput.Controls.Add(this.panelTop);
            this.tabPageInput.Controls.Add(this.panelBottom);
            this.tabPageInput.Location = new System.Drawing.Point(4, 22);
            this.tabPageInput.Name = "tabPageInput";
            this.tabPageInput.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInput.Size = new System.Drawing.Size(231, 202);
            this.tabPageInput.TabIndex = 0;
            this.tabPageInput.Text = "Input";
            this.tabPageInput.UseVisualStyleBackColor = true;
            // 
            // tabPageParameters
            // 
            this.tabPageParameters.Controls.Add(this.panelCenterPar);
            this.tabPageParameters.Controls.Add(this.panelRightPar);
            this.tabPageParameters.Controls.Add(this.panelLeftPar);
            this.tabPageParameters.Controls.Add(this.panelTopPar);
            this.tabPageParameters.Controls.Add(this.panelBottomPar);
            this.tabPageParameters.Location = new System.Drawing.Point(4, 22);
            this.tabPageParameters.Name = "tabPageParameters";
            this.tabPageParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParameters.Size = new System.Drawing.Size(142, 124);
            this.tabPageParameters.TabIndex = 1;
            this.tabPageParameters.Text = "Parameters";
            this.tabPageParameters.UseVisualStyleBackColor = true;
            // 
            // panelCenterPar
            // 
            this.panelCenterPar.Controls.Add(this.panelPar);
            this.panelCenterPar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterPar.Location = new System.Drawing.Point(3, 3);
            this.panelCenterPar.Name = "panelCenterPar";
            this.panelCenterPar.Size = new System.Drawing.Size(136, 118);
            this.panelCenterPar.TabIndex = 20;
            // 
            // panelPar
            // 
            this.panelPar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPar.Location = new System.Drawing.Point(0, 0);
            this.panelPar.Name = "panelPar";
            this.panelPar.Size = new System.Drawing.Size(136, 118);
            this.panelPar.TabIndex = 0;
            // 
            // panelRightPar
            // 
            this.panelRightPar.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightPar.Location = new System.Drawing.Point(139, 3);
            this.panelRightPar.Name = "panelRightPar";
            this.panelRightPar.Size = new System.Drawing.Size(0, 118);
            this.panelRightPar.TabIndex = 18;
            // 
            // panelLeftPar
            // 
            this.panelLeftPar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftPar.Location = new System.Drawing.Point(3, 3);
            this.panelLeftPar.Name = "panelLeftPar";
            this.panelLeftPar.Size = new System.Drawing.Size(0, 118);
            this.panelLeftPar.TabIndex = 17;
            // 
            // panelTopPar
            // 
            this.panelTopPar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopPar.Location = new System.Drawing.Point(3, 3);
            this.panelTopPar.Name = "panelTopPar";
            this.panelTopPar.Size = new System.Drawing.Size(136, 0);
            this.panelTopPar.TabIndex = 16;
            // 
            // panelBottomPar
            // 
            this.panelBottomPar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomPar.Location = new System.Drawing.Point(3, 121);
            this.panelBottomPar.Name = "panelBottomPar";
            this.panelBottomPar.Size = new System.Drawing.Size(136, 0);
            this.panelBottomPar.TabIndex = 19;
            // 
            // panelRightMain
            // 
            this.panelRightMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightMain.Location = new System.Drawing.Point(239, 0);
            this.panelRightMain.Name = "panelRightMain";
            this.panelRightMain.Size = new System.Drawing.Size(0, 228);
            this.panelRightMain.TabIndex = 18;
            // 
            // panelLeftMain
            // 
            this.panelLeftMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftMain.Location = new System.Drawing.Point(0, 0);
            this.panelLeftMain.Name = "panelLeftMain";
            this.panelLeftMain.Size = new System.Drawing.Size(0, 228);
            this.panelLeftMain.TabIndex = 17;
            // 
            // panelTopMain
            // 
            this.panelTopMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopMain.Location = new System.Drawing.Point(0, 0);
            this.panelTopMain.Name = "panelTopMain";
            this.panelTopMain.Size = new System.Drawing.Size(239, 0);
            this.panelTopMain.TabIndex = 16;
            // 
            // panelBottomMain
            // 
            this.panelBottomMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomMain.Location = new System.Drawing.Point(0, 228);
            this.panelBottomMain.Name = "panelBottomMain";
            this.panelBottomMain.Size = new System.Drawing.Size(239, 0);
            this.panelBottomMain.TabIndex = 19;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.userControlWriter);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(3, 3);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(225, 196);
            this.panelCenter.TabIndex = 20;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(228, 3);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 196);
            this.panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(3, 3);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 196);
            this.panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(225, 0);
            this.panelTop.TabIndex = 16;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(3, 199);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(225, 0);
            this.panelBottom.TabIndex = 19;
            // 
            // userControlWriter
            // 
            this.userControlWriter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlWriter.Location = new System.Drawing.Point(0, 0);
            this.userControlWriter.Name = "userControlWriter";
            this.userControlWriter.Size = new System.Drawing.Size(225, 196);
            this.userControlWriter.TabIndex = 0;
            // 
            // UserControlRemoteOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenterMain);
            this.Controls.Add(this.panelRightMain);
            this.Controls.Add(this.panelLeftMain);
            this.Controls.Add(this.panelTopMain);
            this.Controls.Add(this.panelBottomMain);
            this.Name = "UserControlRemoteOutput";
            this.Size = new System.Drawing.Size(239, 228);
            this.panelCenterMain.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageInput.ResumeLayout(false);
            this.tabPageParameters.ResumeLayout(false);
            this.panelCenterPar.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenterMain;
        private System.Windows.Forms.Panel panelRightMain;
        private System.Windows.Forms.Panel panelLeftMain;
        private System.Windows.Forms.Panel panelTopMain;
        private System.Windows.Forms.Panel panelBottomMain;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageInput;
        private System.Windows.Forms.TabPage tabPageParameters;
        private System.Windows.Forms.Panel panelCenterPar;
        private System.Windows.Forms.Panel panelPar;
        private System.Windows.Forms.Panel panelRightPar;
        private System.Windows.Forms.Panel panelLeftPar;
        private System.Windows.Forms.Panel panelTopPar;
        private System.Windows.Forms.Panel panelBottomPar;
        private System.Windows.Forms.Panel panelCenter;
        private UserControlWriter userControlWriter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
    }
}
