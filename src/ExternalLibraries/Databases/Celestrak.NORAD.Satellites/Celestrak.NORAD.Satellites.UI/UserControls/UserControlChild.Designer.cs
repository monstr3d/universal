namespace Celestrak.NORAD.Satellites.UI.UserControls
{
    partial class UserControlChild
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
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageParent = new System.Windows.Forms.TabPage();
            this.tabPageChild = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.elementHost = new System.Windows.Forms.Integration.ElementHost();
            this.userControlCelestrak = new Celestrak.NORAD.Satellites.Wpf.UI.UserControls.UserControlCelestrak();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panelChild = new System.Windows.Forms.Panel();
            this.panelCenter.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageParent.SuspendLayout();
            this.tabPageChild.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControl);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(150, 150);
            this.panelCenter.TabIndex = 20;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(150, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 150);
            this.panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 150);
            this.panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(150, 0);
            this.panelTop.TabIndex = 16;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 150);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(150, 0);
            this.panelBottom.TabIndex = 19;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageParent);
            this.tabControl.Controls.Add(this.tabPageChild);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(150, 150);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageParent
            // 
            this.tabPageParent.Controls.Add(this.panel1);
            this.tabPageParent.Controls.Add(this.panel2);
            this.tabPageParent.Controls.Add(this.panel3);
            this.tabPageParent.Controls.Add(this.panel4);
            this.tabPageParent.Controls.Add(this.panel5);
            this.tabPageParent.Location = new System.Drawing.Point(4, 22);
            this.tabPageParent.Name = "tabPageParent";
            this.tabPageParent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParent.Size = new System.Drawing.Size(142, 124);
            this.tabPageParent.TabIndex = 0;
            this.tabPageParent.Text = "Parent object";
            this.tabPageParent.UseVisualStyleBackColor = true;
            // 
            // tabPageChild
            // 
            this.tabPageChild.Controls.Add(this.panel6);
            this.tabPageChild.Controls.Add(this.panel7);
            this.tabPageChild.Controls.Add(this.panel8);
            this.tabPageChild.Controls.Add(this.panel9);
            this.tabPageChild.Controls.Add(this.panel10);
            this.tabPageChild.Location = new System.Drawing.Point(4, 22);
            this.tabPageChild.Name = "tabPageChild";
            this.tabPageChild.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChild.Size = new System.Drawing.Size(142, 124);
            this.tabPageChild.TabIndex = 1;
            this.tabPageChild.Text = "Child object";
            this.tabPageChild.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.elementHost);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(136, 118);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(139, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 118);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 118);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(136, 0);
            this.panel4.TabIndex = 16;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 121);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(136, 0);
            this.panel5.TabIndex = 19;
            // 
            // elementHost
            // 
            this.elementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost.Location = new System.Drawing.Point(0, 0);
            this.elementHost.Name = "elementHost";
            this.elementHost.Size = new System.Drawing.Size(136, 118);
            this.elementHost.TabIndex = 0;
            this.elementHost.Text = "elementHost1";
            this.elementHost.Child = this.userControlCelestrak;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panelChild);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(136, 118);
            this.panel6.TabIndex = 20;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(139, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(0, 118);
            this.panel7.TabIndex = 18;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(0, 118);
            this.panel8.TabIndex = 17;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(136, 0);
            this.panel9.TabIndex = 16;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(3, 121);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(136, 0);
            this.panel10.TabIndex = 19;
            // 
            // panelChild
            // 
            this.panelChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChild.Location = new System.Drawing.Point(0, 0);
            this.panelChild.Name = "panelChild";
            this.panelChild.Size = new System.Drawing.Size(136, 118);
            this.panelChild.TabIndex = 0;
            // 
            // UserControlChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlChild";
            this.panelCenter.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageParent.ResumeLayout(false);
            this.tabPageChild.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageParent;
        private System.Windows.Forms.TabPage tabPageChild;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Integration.ElementHost elementHost;
        private Celestrak.NORAD.Satellites.Wpf.UI.UserControls.UserControlCelestrak userControlCelestrak;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panelChild;
    }
}
