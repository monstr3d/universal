namespace Diagram.UI.UserControls
{
    partial class UserControlListItem
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
            panelRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            labelText = new System.Windows.Forms.Label();
            panelBottom = new System.Windows.Forms.Panel();
            panelCenter = new System.Windows.Forms.Panel();
            comboBox = new System.Windows.Forms.ComboBox();
            panelTop.SuspendLayout();
            panelCenter.SuspendLayout();
            SuspendLayout();
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(180, 23);
            panelRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(12, 28);
            panelRight.TabIndex = 12;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 23);
            panelLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(12, 28);
            panelLeft.TabIndex = 11;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(labelText);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(192, 23);
            panelTop.TabIndex = 10;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Location = new System.Drawing.Point(4, 5);
            labelText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelText.Name = "labelText";
            labelText.Size = new System.Drawing.Size(28, 15);
            labelText.TabIndex = 0;
            labelText.Text = "Text";
            // 
            // panelBottom
            // 
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 51);
            panelBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(192, 0);
            panelBottom.TabIndex = 13;
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(comboBox);
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(12, 23);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(168, 28);
            panelCenter.TabIndex = 14;
            // 
            // comboBox
            // 
            comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(0, 0);
            comboBox.Name = "comboBox";
            comboBox.Size = new System.Drawing.Size(168, 23);
            comboBox.TabIndex = 0;
            // 
            // UserControlListItem
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelCenter);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UserControlListItem";
            Size = new System.Drawing.Size(192, 51);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelCenter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.ComboBox comboBox;
    }
}
