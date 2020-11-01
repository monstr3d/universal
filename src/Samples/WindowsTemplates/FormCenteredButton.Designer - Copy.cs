namespace WindowsTemplates
{
    partial class FormCenteredButton
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
            this.panelCenterButton = new System.Windows.Forms.Panel();
            this.panelRightButton = new System.Windows.Forms.Panel();
            this.panelLeftButton = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottomButton = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelCenterButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenterButton
            // 
            this.panelCenterButton.Controls.Add(this.button1);
            this.panelCenterButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterButton.Location = new System.Drawing.Point(87, 0);
            this.panelCenterButton.Margin = new System.Windows.Forms.Padding(4);
            this.panelCenterButton.Name = "panelCenterButton";
            this.panelCenterButton.Size = new System.Drawing.Size(100, 25);
            this.panelCenterButton.TabIndex = 20;
            // 
            // panelRightButton
            // 
            this.panelRightButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightButton.Location = new System.Drawing.Point(187, 0);
            this.panelRightButton.Margin = new System.Windows.Forms.Padding(4);
            this.panelRightButton.Name = "panelRightButton";
            this.panelRightButton.Size = new System.Drawing.Size(95, 25);
            this.panelRightButton.TabIndex = 18;
            // 
            // panelLeftButton
            // 
            this.panelLeftButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftButton.Location = new System.Drawing.Point(0, 0);
            this.panelLeftButton.Margin = new System.Windows.Forms.Padding(4);
            this.panelLeftButton.Name = "panelLeftButton";
            this.panelLeftButton.Size = new System.Drawing.Size(87, 25);
            this.panelLeftButton.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(282, 0);
            this.panelTop.TabIndex = 16;
            // 
            // panelBottomButton
            // 
            this.panelBottomButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomButton.Location = new System.Drawing.Point(0, 25);
            this.panelBottomButton.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottomButton.Name = "panelBottomButton";
            this.panelBottomButton.Size = new System.Drawing.Size(282, 0);
            this.panelBottomButton.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormCenteredButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 25);
            this.Controls.Add(this.panelCenterButton);
            this.Controls.Add(this.panelRightButton);
            this.Controls.Add(this.panelLeftButton);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottomButton);
            this.Name = "FormCenteredButton";
            this.Text = "FormCenteredButton";
            this.panelCenterButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenterButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelRightButton;
        private System.Windows.Forms.Panel panelLeftButton;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottomButton;
    }
}