namespace Http.Meteo.UI.UserControls
{
    partial class UserControlMeteo
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            panelCenter = new Panel();
            webBrowser = new WebBrowser();
            panelRight = new Panel();
            panelLeft = new Panel();
            panelTop = new Panel();
            labelInt = new Label();
            textBoxInterval = new TextBox();
            panelBottom = new Panel();
            panelCenter.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(webBrowser);
            panelCenter.Dock = DockStyle.Fill;
            panelCenter.Location = new Point(0, 28);
            panelCenter.Margin = new Padding(4, 3, 4, 3);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new Size(547, 354);
            panelCenter.TabIndex = 20;
            // 
            // webBrowser
            // 
            webBrowser.Dock = DockStyle.Fill;
            webBrowser.Location = new Point(0, 0);
            webBrowser.Margin = new Padding(4, 3, 4, 3);
            webBrowser.MinimumSize = new Size(23, 23);
            webBrowser.Name = "webBrowser";
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Size = new Size(547, 354);
            webBrowser.TabIndex = 0;
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            // 
            // panelRight
            // 
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(547, 28);
            panelRight.Margin = new Padding(4, 3, 4, 3);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(0, 354);
            panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 28);
            panelLeft.Margin = new Padding(4, 3, 4, 3);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(0, 354);
            panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(labelInt);
            panelTop.Controls.Add(textBoxInterval);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 3, 4, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(547, 28);
            panelTop.TabIndex = 16;
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
            textBoxInterval.KeyUp += textBoxInterval_KeyUp;
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 382);
            panelBottom.Margin = new Padding(4, 3, 4, 3);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(547, 0);
            panelBottom.TabIndex = 19;
            // 
            // UserControlMeteo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelCenter);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Margin = new Padding(4, 3, 4, 3);
            Name = "UserControlMeteo";
            Size = new Size(547, 382);
            panelCenter.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label labelInt;
        private System.Windows.Forms.TextBox textBoxInterval;
    }
}
