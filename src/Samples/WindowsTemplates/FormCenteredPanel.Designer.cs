namespace WindowsTemplates
{
    partial class FormCenteredPanel
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
            panelBottom = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            panelRight = new System.Windows.Forms.Panel();
            panelCenter = new System.Windows.Forms.Panel();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 462);
            panelBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(368, 11);
            panelBottom.TabIndex = 9;
            // 
            // panelTop
            // 
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(368, 11);
            panelTop.TabIndex = 6;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 11);
            panelLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(11, 451);
            panelLeft.TabIndex = 7;
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(357, 11);
            panelRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(11, 451);
            panelRight.TabIndex = 8;
            // 
            // panelCenter
            // 
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(11, 11);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(346, 451);
            panelCenter.TabIndex = 10;
            // 
            // FormCenteredPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(368, 473);
            Controls.Add(panelCenter);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "FormCenteredPanel";
            Text = "FormMain";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelCenter;
    }
}

