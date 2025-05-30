﻿namespace Internet.Meteo.UI.UserControls
{
    partial class UserControlAll
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
            panel1 = new System.Windows.Forms.Panel();
            radioButtonCelsius = new System.Windows.Forms.RadioButton();
            radioButtonFahrenheit = new System.Windows.Forms.RadioButton();
            userControlListItems = new Diagram.UI.UserControls.UserControlListItems();
            panelRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            panelCenter.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(panel1);
            panelCenter.Controls.Add(userControlListItems);
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(0, 0);
            panelCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(384, 175);
            panelCenter.TabIndex = 25;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButtonCelsius);
            panel1.Controls.Add(radioButtonFahrenheit);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 102);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(384, 73);
            panel1.TabIndex = 1;
            // 
            // radioButtonCelsius
            // 
            radioButtonCelsius.AutoSize = true;
            radioButtonCelsius.Location = new System.Drawing.Point(21, 42);
            radioButtonCelsius.Name = "radioButtonCelsius";
            radioButtonCelsius.Size = new System.Drawing.Size(62, 19);
            radioButtonCelsius.TabIndex = 1;
            radioButtonCelsius.TabStop = true;
            radioButtonCelsius.Text = "Celsius";
            radioButtonCelsius.UseVisualStyleBackColor = true;
            // 
            // radioButtonFahrenheit
            // 
            radioButtonFahrenheit.AutoSize = true;
            radioButtonFahrenheit.Location = new System.Drawing.Point(21, 17);
            radioButtonFahrenheit.Name = "radioButtonFahrenheit";
            radioButtonFahrenheit.Size = new System.Drawing.Size(81, 19);
            radioButtonFahrenheit.TabIndex = 0;
            radioButtonFahrenheit.TabStop = true;
            radioButtonFahrenheit.Text = "Fahrenheit";
            radioButtonFahrenheit.UseVisualStyleBackColor = true;
            // 
            // userControlListItems
            // 
            userControlListItems.Count = 2;
            userControlListItems.Dock = System.Windows.Forms.DockStyle.Top;
            userControlListItems.Location = new System.Drawing.Point(0, 0);
            userControlListItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            userControlListItems.Name = "userControlListItems";
            userControlListItems.Size = new System.Drawing.Size(384, 103);
            userControlListItems.TabIndex = 0;
            userControlListItems.Texts = new string[]
    {
    "Key",
    "Position"
    };
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(384, 0);
            panelRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(0, 175);
            panelRight.TabIndex = 23;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 0);
            panelLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(0, 175);
            panelLeft.TabIndex = 22;
            // 
            // panelTop
            // 
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(384, 0);
            panelTop.TabIndex = 21;
            // 
            // panelBottom
            // 
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 175);
            panelBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(384, 0);
            panelBottom.TabIndex = 24;
            // 
            // UserControlAll
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelCenter);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Name = "UserControlAll";
            Size = new System.Drawing.Size(384, 175);
            panelCenter.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonCelsius;
        private System.Windows.Forms.RadioButton radioButtonFahrenheit;
        private Diagram.UI.UserControls.UserControlListItems userControlListItems;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
    }
}
