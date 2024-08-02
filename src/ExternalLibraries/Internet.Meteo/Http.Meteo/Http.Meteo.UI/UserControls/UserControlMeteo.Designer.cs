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
            this.panelCenter = new System.Windows.Forms.Panel();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.labelInt = new System.Windows.Forms.Label();
            this.panelCenter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.webBrowser);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 24);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(469, 307);
            this.panelCenter.TabIndex = 20;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(469, 307);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(469, 24);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 307);
            this.panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 24);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 307);
            this.panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labelInt);
            this.panelTop.Controls.Add(this.textBoxInterval);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(469, 24);
            this.panelTop.TabIndex = 16;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 331);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(469, 0);
            this.panelBottom.TabIndex = 19;
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(103, 3);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(100, 20);
            this.textBoxInterval.TabIndex = 0;
            this.textBoxInterval.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxInterval_KeyUp);
            // 
            // labelInt
            // 
            this.labelInt.AutoSize = true;
            this.labelInt.Location = new System.Drawing.Point(16, 4);
            this.labelInt.Name = "labelInt";
            this.labelInt.Size = new System.Drawing.Size(79, 13);
            this.labelInt.TabIndex = 1;
            this.labelInt.Text = "Update interval";
            // 
            // UserControlMeteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlMeteo";
            this.Size = new System.Drawing.Size(469, 331);
            this.panelCenter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

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
