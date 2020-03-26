namespace Diagram.UI.UserControls
{
    partial class UserControlComboboxListLeft
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
            this.panelRightCombo = new System.Windows.Forms.Panel();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelBottomCombo = new System.Windows.Forms.Panel();
            this.panelLeftCombo = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.labelText = new System.Windows.Forms.Label();
            this.panelTopCombo = new System.Windows.Forms.Panel();
            this.panelLeftCombo.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRightCombo
            // 
            this.panelRightCombo.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightCombo.Location = new System.Drawing.Point(256, 1);
            this.panelRightCombo.Name = "panelRightCombo";
            this.panelRightCombo.Size = new System.Drawing.Size(4, 25);
            this.panelRightCombo.TabIndex = 18;
            // 
            // comboBox
            // 
            this.comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(41, 1);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(215, 21);
            this.comboBox.TabIndex = 20;
            // 
            // panelCenter
            // 
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 27);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(260, 5);
            this.panelCenter.TabIndex = 25;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(260, 27);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 5);
            this.panelRight.TabIndex = 23;
            // 
            // panelBottomCombo
            // 
            this.panelBottomCombo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomCombo.Location = new System.Drawing.Point(0, 26);
            this.panelBottomCombo.Name = "panelBottomCombo";
            this.panelBottomCombo.Size = new System.Drawing.Size(260, 1);
            this.panelBottomCombo.TabIndex = 19;
            // 
            // panelLeftCombo
            // 
            this.panelLeftCombo.Controls.Add(this.labelText);
            this.panelLeftCombo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftCombo.Location = new System.Drawing.Point(0, 1);
            this.panelLeftCombo.Name = "panelLeftCombo";
            this.panelLeftCombo.Size = new System.Drawing.Size(41, 25);
            this.panelLeftCombo.TabIndex = 17;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 27);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 5);
            this.panelLeft.TabIndex = 22;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.comboBox);
            this.panelTop.Controls.Add(this.panelRightCombo);
            this.panelTop.Controls.Add(this.panelLeftCombo);
            this.panelTop.Controls.Add(this.panelTopCombo);
            this.panelTop.Controls.Add(this.panelBottomCombo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(260, 27);
            this.panelTop.TabIndex = 21;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 32);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(260, 0);
            this.panelBottom.TabIndex = 24;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(3, 8);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(28, 13);
            this.labelText.TabIndex = 1;
            this.labelText.Text = "Text";
            // 
            // panelTopCombo
            // 
            this.panelTopCombo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopCombo.Location = new System.Drawing.Point(0, 0);
            this.panelTopCombo.Name = "panelTopCombo";
            this.panelTopCombo.Size = new System.Drawing.Size(260, 1);
            this.panelTopCombo.TabIndex = 16;
            // 
            // UserControlComboboxListLeft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlComboboxListLeft";
            this.Size = new System.Drawing.Size(260, 32);
            this.panelLeftCombo.ResumeLayout(false);
            this.panelLeftCombo.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRightCombo;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelBottomCombo;
        private System.Windows.Forms.Panel panelLeftCombo;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Panel panelTopCombo;

    }
}
