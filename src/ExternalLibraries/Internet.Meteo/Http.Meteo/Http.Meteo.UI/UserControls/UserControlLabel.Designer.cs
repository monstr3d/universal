namespace Http.Meteo.UI.UserControls
{
    partial class UserControlLabel
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
            panelCenter = new Panel();
            panelRight = new Panel();
            panelLeft = new Panel();
            panelTop = new Panel();
            labelInt = new Label();
            textBoxInterval = new TextBox();
            panelBottom = new Panel();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelCenter
            // 
            panelCenter.Dock = DockStyle.Fill;
            panelCenter.Location = new Point(0, 28);
            panelCenter.Margin = new Padding(4, 3, 4, 3);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new Size(365, 18);
            panelCenter.TabIndex = 25;
            // 
            // panelRight
            // 
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(365, 28);
            panelRight.Margin = new Padding(4, 3, 4, 3);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(0, 18);
            panelRight.TabIndex = 23;
            // 
            // panelLeft
            // 
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 28);
            panelLeft.Margin = new Padding(4, 3, 4, 3);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(0, 18);
            panelLeft.TabIndex = 22;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(labelInt);
            panelTop.Controls.Add(textBoxInterval);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 3, 4, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(365, 28);
            panelTop.TabIndex = 21;
            // 
            // labelInt
            // 
            labelInt.AutoSize = true;
            labelInt.Location = new Point(19, 5);
            labelInt.Margin = new Padding(4, 0, 4, 0);
            labelInt.Name = "labelInt";
            labelInt.Size = new Size(87, 15);
            labelInt.TabIndex = 1;
            labelInt.Text = "Update interval";
            // 
            // textBoxInterval
            // 
            textBoxInterval.Location = new Point(120, 3);
            textBoxInterval.Margin = new Padding(4, 3, 4, 3);
            textBoxInterval.Name = "textBoxInterval";
            textBoxInterval.Size = new Size(116, 23);
            textBoxInterval.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 46);
            panelBottom.Margin = new Padding(4, 3, 4, 3);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(365, 0);
            panelBottom.TabIndex = 24;
            // 
            // UserControlLabel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelCenter);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Name = "UserControlLabel";
            Size = new Size(365, 46);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelCenter;
        private Panel panelRight;
        private Panel panelLeft;
        private Panel panelTop;
        private Label labelInt;
        private TextBox textBoxInterval;
        private Panel panelBottom;
    }
}
