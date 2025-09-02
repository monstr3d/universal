namespace Internet.Meteo.UI.UserControls
{
    partial class UserControlTemperatureFull
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
            userControlListItems = new Diagram.UI.UserControls.UserControlListItems();
            panelRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            radioButtonFahrenheit = new System.Windows.Forms.RadioButton();
            radioButtonCelsius = new System.Windows.Forms.RadioButton();
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
            panelCenter.Size = new System.Drawing.Size(394, 334);
            panelCenter.TabIndex = 20;
            // 
            // userControlListItems
            // 
            userControlListItems.Count = 5;
            userControlListItems.Dock = System.Windows.Forms.DockStyle.Top;
            userControlListItems.Location = new System.Drawing.Point(0, 0);
            userControlListItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            userControlListItems.Name = "userControlListItems";
            userControlListItems.Size = new System.Drawing.Size(394, 267);
            userControlListItems.TabIndex = 0;
            userControlListItems.Texts = new string[]
    {
    "Key",
    "Position",
    "Min",
    "Max",
    "Step"
    };
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(394, 0);
            panelRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(0, 334);
            panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 0);
            panelLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(0, 334);
            panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(394, 0);
            panelTop.TabIndex = 16;
            // 
            // panelBottom
            // 
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 334);
            panelBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(394, 0);
            panelBottom.TabIndex = 19;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButtonCelsius);
            panel1.Controls.Add(radioButtonFahrenheit);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 261);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(394, 73);
            panel1.TabIndex = 1;
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
            // UserControlTemperatureFull
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelCenter);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Name = "UserControlTemperatureFull";
            Size = new System.Drawing.Size(394, 334);
            panelCenter.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private Diagram.UI.UserControls.UserControlListItems userControlListItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonFahrenheit;
        private System.Windows.Forms.RadioButton radioButtonCelsius;
    }
}
