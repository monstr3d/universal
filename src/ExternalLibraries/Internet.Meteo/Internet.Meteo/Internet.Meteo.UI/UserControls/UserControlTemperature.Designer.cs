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
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelCenter = new System.Windows.Forms.Panel();
            panelRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            textBox = new System.Windows.Forms.TextBox();
            panel2 = new System.Windows.Forms.Panel();
            Interval = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            panel4 = new System.Windows.Forms.Panel();
            panel5 = new System.Windows.Forms.Panel();
            panel6 = new System.Windows.Forms.Panel();
            labelT = new System.Windows.Forms.Label();
            panel7 = new System.Windows.Forms.Panel();
            panel8 = new System.Windows.Forms.Panel();
            panel9 = new System.Windows.Forms.Panel();
            panel10 = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            labelValue = new System.Windows.Forms.Label();
            term = new ScadaForms.Term();
            panelTop.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelCenter
            // 
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(0, 106);
            panelCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(270, 0);
            panelCenter.TabIndex = 20;
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(270, 106);
            panelRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(0, 0);
            panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 106);
            panelLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(0, 0);
            panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(panel1);
            panelTop.Controls.Add(panel2);
            panelTop.Controls.Add(panel3);
            panelTop.Controls.Add(panel4);
            panelTop.Controls.Add(panel5);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(270, 106);
            panelTop.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(5, 32);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(260, 29);
            panel1.TabIndex = 25;
            // 
            // textBox
            // 
            textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            textBox.Location = new System.Drawing.Point(0, 0);
            textBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox.Name = "textBox";
            textBox.Size = new System.Drawing.Size(260, 23);
            textBox.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(Interval);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(5, 0);
            panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(260, 32);
            panel2.TabIndex = 21;
            // 
            // Interval
            // 
            Interval.AutoSize = true;
            Interval.Location = new System.Drawing.Point(28, 10);
            Interval.Name = "Interval";
            Interval.Size = new System.Drawing.Size(118, 15);
            Interval.TabIndex = 0;
            Interval.Text = "Update interval, hour";
            // 
            // panel3
            // 
            panel3.Dock = System.Windows.Forms.DockStyle.Right;
            panel3.Location = new System.Drawing.Point(265, 0);
            panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(5, 61);
            panel3.TabIndex = 23;
            // 
            // panel4
            // 
            panel4.Dock = System.Windows.Forms.DockStyle.Left;
            panel4.Location = new System.Drawing.Point(0, 0);
            panel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(5, 61);
            panel4.TabIndex = 22;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(panel8);
            panel5.Controls.Add(panel9);
            panel5.Controls.Add(panel10);
            panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel5.Location = new System.Drawing.Point(0, 61);
            panel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(270, 45);
            panel5.TabIndex = 24;
            // 
            // panel6
            // 
            panel6.Controls.Add(labelT);
            panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            panel6.Location = new System.Drawing.Point(10, 10);
            panel6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(211, 29);
            panel6.TabIndex = 25;
            // 
            // labelT
            // 
            labelT.Dock = System.Windows.Forms.DockStyle.Fill;
            labelT.Location = new System.Drawing.Point(0, 0);
            labelT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            labelT.Name = "labelT";
            labelT.Size = new System.Drawing.Size(211, 29);
            labelT.TabIndex = 0;
            labelT.Text = "Temperature";
            // 
            // panel7
            // 
            panel7.Dock = System.Windows.Forms.DockStyle.Right;
            panel7.Location = new System.Drawing.Point(221, 10);
            panel7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel7.Name = "panel7";
            panel7.Size = new System.Drawing.Size(49, 29);
            panel7.TabIndex = 23;
            // 
            // panel8
            // 
            panel8.Dock = System.Windows.Forms.DockStyle.Left;
            panel8.Location = new System.Drawing.Point(0, 10);
            panel8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel8.Name = "panel8";
            panel8.Size = new System.Drawing.Size(10, 29);
            panel8.TabIndex = 22;
            // 
            // panel9
            // 
            panel9.Dock = System.Windows.Forms.DockStyle.Top;
            panel9.Location = new System.Drawing.Point(0, 0);
            panel9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel9.Name = "panel9";
            panel9.Size = new System.Drawing.Size(270, 10);
            panel9.TabIndex = 21;
            // 
            // panel10
            // 
            panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel10.Location = new System.Drawing.Point(0, 39);
            panel10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel10.Name = "panel10";
            panel10.Size = new System.Drawing.Size(270, 6);
            panel10.TabIndex = 24;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(labelValue);
            panelBottom.Controls.Add(term);
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 106);
            panelBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(270, 181);
            panelBottom.TabIndex = 19;
            // 
            // labelValue
            // 
            labelValue.AutoSize = true;
            labelValue.Location = new System.Drawing.Point(99, 14);
            labelValue.Name = "labelValue";
            labelValue.Size = new System.Drawing.Size(0, 15);
            labelValue.TabIndex = 1;
            // 
            // term
            // 
            term.Dock = System.Windows.Forms.DockStyle.Left;
            term.Location = new System.Drawing.Point(0, 0);
            term.Name = "term";
            term.Size = new System.Drawing.Size(80, 181);
            term.TabIndex = 0;
            // 
            // UserControlTemperature
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelCenter);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Name = "UserControlTemperature";
            Size = new System.Drawing.Size(270, 287);
            panelTop.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label Interval;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label labelT;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label labelValue;
        private ScadaForms.Term term;
    }
}
