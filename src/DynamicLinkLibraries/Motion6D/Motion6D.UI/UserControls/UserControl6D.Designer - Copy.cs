namespace Motion6D.UI.UserControls
{
    partial class UserControl6D
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
            this.panelTopMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlQuaternion = new Motion6D.UI.UserControls.UserControlQuaternion();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.userControlCoordinates = new Motion6D.UI.UserControls.UserControlCoordinates();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelTopMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 271);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(118, 6);
            this.panelCenter.TabIndex = 20;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(118, 271);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 6);
            this.panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 271);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 6);
            this.panelLeft.TabIndex = 17;
            // 
            // panelTopMain
            // 
            this.panelTopMain.Controls.Add(this.panel1);
            this.panelTopMain.Controls.Add(this.panel2);
            this.panelTopMain.Controls.Add(this.panel3);
            this.panelTopMain.Controls.Add(this.panelTop);
            this.panelTopMain.Controls.Add(this.panel4);
            this.panelTopMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopMain.Location = new System.Drawing.Point(0, 0);
            this.panelTopMain.Name = "panelTopMain";
            this.panelTopMain.Size = new System.Drawing.Size(118, 271);
            this.panelTopMain.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userControlQuaternion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 142);
            this.panel1.TabIndex = 20;
            // 
            // userControlQuaternion
            // 
            this.userControlQuaternion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQuaternion.Location = new System.Drawing.Point(0, 0);
            this.userControlQuaternion.Name = "userControlQuaternion";
            this.userControlQuaternion.Size = new System.Drawing.Size(118, 142);
            this.userControlQuaternion.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(118, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 142);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 128);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 142);
            this.panel3.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.userControlCoordinates);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(118, 128);
            this.panelTop.TabIndex = 16;
            // 
            // userControlCoordinates
            // 
            this.userControlCoordinates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlCoordinates.Location = new System.Drawing.Point(0, 0);
            this.userControlCoordinates.Name = "userControlCoordinates";
            this.userControlCoordinates.Size = new System.Drawing.Size(118, 128);
            this.userControlCoordinates.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 270);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(118, 1);
            this.panel4.TabIndex = 19;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 277);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(118, 0);
            this.panelBottom.TabIndex = 19;
            // 
            // UserControl6D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTopMain);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControl6D";
            this.Size = new System.Drawing.Size(118, 277);
            this.panelTopMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTopMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelTop;
        /// <summary>
        /// Coordinates UI
        /// </summary>
        protected UserControlCoordinates userControlCoordinates;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelBottom;
        /// <summary>
        /// Quaternion UI
        /// </summary>
        protected UserControlQuaternion userControlQuaternion;
    }
}
