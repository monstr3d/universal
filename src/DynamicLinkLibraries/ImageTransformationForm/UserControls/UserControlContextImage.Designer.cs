namespace ImageTransformations.UserControls
{
    partial class UserControlContextImage
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
            this.tabPageFullPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlUrlPage = new ImageTransformations.UserControls.UserControlUrl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxFull = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tabPageContext = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.userControlUrlCtx = new ImageTransformations.UserControls.UserControlUrl();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.textBoxContext = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelCenter.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageFullPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPageContext.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControl);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(288, 242);
            this.panelCenter.TabIndex = 20;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageFullPage);
            this.tabControl.Controls.Add(this.tabPageContext);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(288, 242);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageFullPage
            // 
            this.tabPageFullPage.Controls.Add(this.panel1);
            this.tabPageFullPage.Controls.Add(this.panel2);
            this.tabPageFullPage.Controls.Add(this.panel3);
            this.tabPageFullPage.Controls.Add(this.panel4);
            this.tabPageFullPage.Controls.Add(this.panel5);
            this.tabPageFullPage.Location = new System.Drawing.Point(4, 22);
            this.tabPageFullPage.Name = "tabPageFullPage";
            this.tabPageFullPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFullPage.Size = new System.Drawing.Size(280, 216);
            this.tabPageFullPage.TabIndex = 0;
            this.tabPageFullPage.Text = "Web page";
            this.tabPageFullPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userControlUrlPage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 188);
            this.panel1.TabIndex = 20;
            // 
            // userControlUrlPage
            // 
            this.userControlUrlPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlUrlPage.Location = new System.Drawing.Point(0, 0);
            this.userControlUrlPage.Name = "userControlUrlPage";
            this.userControlUrlPage.Size = new System.Drawing.Size(274, 188);
            this.userControlUrlPage.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(277, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 188);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 188);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBoxFull);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(274, 22);
            this.panel4.TabIndex = 16;
            // 
            // textBoxFull
            // 
            this.textBoxFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFull.Location = new System.Drawing.Point(0, 0);
            this.textBoxFull.Name = "textBoxFull";
            this.textBoxFull.Size = new System.Drawing.Size(274, 20);
            this.textBoxFull.TabIndex = 0;
            this.textBoxFull.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 213);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(274, 0);
            this.panel5.TabIndex = 19;
            // 
            // tabPageContext
            // 
            this.tabPageContext.Controls.Add(this.panel6);
            this.tabPageContext.Controls.Add(this.panel7);
            this.tabPageContext.Controls.Add(this.panel8);
            this.tabPageContext.Controls.Add(this.panel9);
            this.tabPageContext.Controls.Add(this.panel10);
            this.tabPageContext.Location = new System.Drawing.Point(4, 22);
            this.tabPageContext.Name = "tabPageContext";
            this.tabPageContext.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageContext.Size = new System.Drawing.Size(280, 216);
            this.tabPageContext.TabIndex = 1;
            this.tabPageContext.Text = "Context";
            this.tabPageContext.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.userControlUrlCtx);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 27);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(274, 186);
            this.panel6.TabIndex = 20;
            // 
            // userControlUrlCtx
            // 
            this.userControlUrlCtx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlUrlCtx.Location = new System.Drawing.Point(0, 0);
            this.userControlUrlCtx.Name = "userControlUrlCtx";
            this.userControlUrlCtx.Size = new System.Drawing.Size(274, 186);
            this.userControlUrlCtx.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(277, 27);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(0, 186);
            this.panel7.TabIndex = 18;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(3, 27);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(0, 186);
            this.panel8.TabIndex = 17;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.textBoxContext);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(274, 24);
            this.panel9.TabIndex = 16;
            // 
            // textBoxContext
            // 
            this.textBoxContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxContext.Location = new System.Drawing.Point(0, 0);
            this.textBoxContext.Name = "textBoxContext";
            this.textBoxContext.Size = new System.Drawing.Size(274, 20);
            this.textBoxContext.TabIndex = 0;
            this.textBoxContext.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(3, 213);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(274, 0);
            this.panel10.TabIndex = 19;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(288, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 242);
            this.panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 242);
            this.panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(288, 0);
            this.panelTop.TabIndex = 16;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 242);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(288, 0);
            this.panelBottom.TabIndex = 19;
            // 
            // UserControlContextImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlContextImage";
            this.Size = new System.Drawing.Size(288, 242);
            this.panelCenter.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageFullPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPageContext.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageFullPage;
        private System.Windows.Forms.TabPage tabPageContext;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxFull;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox textBoxContext;
        private UserControlUrl userControlUrlPage;
        private UserControlUrl userControlUrlCtx;
    }
}
