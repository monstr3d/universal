namespace Internet.Meteo.UI.UserControls
{
    partial class UserControlTemperature
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
            sensor.OnValueChange -= Sensor_OnValueChange;
            sensor.OnEnabledChange -= Sensor_OnEnabledChange;
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelT = new System.Windows.Forms.Panel();
            panelCenter = new System.Windows.Forms.Panel();
            textBox = new System.Windows.Forms.TextBox();
            panelRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            panelBottom = new System.Windows.Forms.Panel();
            labelTemperature = new System.Windows.Forms.Label();
            term = new ScadaForms.Term();
            panelT.SuspendLayout();
            panelCenter.SuspendLayout();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelT
            // 
            panelT.Controls.Add(panelCenter);
            panelT.Controls.Add(panelRight);
            panelT.Controls.Add(panelLeft);
            panelT.Controls.Add(panelTop);
            panelT.Controls.Add(panelBottom);
            panelT.Dock = System.Windows.Forms.DockStyle.Top;
            panelT.Location = new System.Drawing.Point(0, 0);
            panelT.Name = "panelT";
            panelT.Size = new System.Drawing.Size(166, 224);
            panelT.TabIndex = 0;
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(textBox);
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(5, 30);
            panelCenter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(156, 23);
            panelCenter.TabIndex = 25;
            // 
            // textBox
            // 
            textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            textBox.Location = new System.Drawing.Point(0, 0);
            textBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox.Name = "textBox";
            textBox.Size = new System.Drawing.Size(156, 23);
            textBox.TabIndex = 0;
            textBox.TextChanged += textBox_TextChanged;
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(161, 30);
            panelRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(5, 23);
            panelRight.TabIndex = 23;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 30);
            panelLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(5, 23);
            panelLeft.TabIndex = 22;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(label1);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(166, 30);
            panelTop.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Position";
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(labelTemperature);
            panelBottom.Controls.Add(term);
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 53);
            panelBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(166, 171);
            panelBottom.TabIndex = 24;
            // 
            // labelTemperature
            // 
            labelTemperature.AutoSize = true;
            labelTemperature.Location = new System.Drawing.Point(8, 2);
            labelTemperature.Name = "labelTemperature";
            labelTemperature.Size = new System.Drawing.Size(73, 15);
            labelTemperature.TabIndex = 1;
            labelTemperature.Text = "Temperature";
            // 
            // term
            // 
            term.Location = new System.Drawing.Point(3, 20);
            term.Name = "term";
            term.Size = new System.Drawing.Size(80, 140);
            term.TabIndex = 0;
            // 
            // UserControlTemperature
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelT);
            Name = "UserControlTemperature";
            Size = new System.Drawing.Size(166, 223);
            panelT.ResumeLayout(false);
            panelCenter.ResumeLayout(false);
            panelCenter.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelT;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private ScadaForms.Term term;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTemperature;
    }
}
