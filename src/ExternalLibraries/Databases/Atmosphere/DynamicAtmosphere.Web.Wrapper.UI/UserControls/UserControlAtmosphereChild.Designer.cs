namespace DynamicAtmosphere.Web.Wrapper.UI.UserControls
{
    partial class UserControlAtmosphereChild
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageCurrent = new System.Windows.Forms.TabPage();
            this.webBrowserCurrent = new System.Windows.Forms.WebBrowser();
            this.tabPageAverage = new System.Windows.Forms.TabPage();
            this.webBrowserAverage = new System.Windows.Forms.WebBrowser();
            this.tabPageChild = new System.Windows.Forms.TabPage();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelChild = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.tabPageCurrent.SuspendLayout();
            this.tabPageAverage.SuspendLayout();
            this.tabPageChild.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageCurrent);
            this.tabControl.Controls.Add(this.tabPageAverage);
            this.tabControl.Controls.Add(this.tabPageChild);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(426, 297);
            this.tabControl.TabIndex = 27;
            // 
            // tabPageCurrent
            // 
            this.tabPageCurrent.Controls.Add(this.webBrowserCurrent);
            this.tabPageCurrent.Location = new System.Drawing.Point(4, 22);
            this.tabPageCurrent.Name = "tabPageCurrent";
            this.tabPageCurrent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCurrent.Size = new System.Drawing.Size(418, 271);
            this.tabPageCurrent.TabIndex = 0;
            this.tabPageCurrent.Text = "Current data";
            this.tabPageCurrent.UseVisualStyleBackColor = true;
            // 
            // webBrowserCurrent
            // 
            this.webBrowserCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserCurrent.Location = new System.Drawing.Point(3, 3);
            this.webBrowserCurrent.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserCurrent.Name = "webBrowserCurrent";
            this.webBrowserCurrent.Size = new System.Drawing.Size(412, 265);
            this.webBrowserCurrent.TabIndex = 0;
            this.webBrowserCurrent.Url = new System.Uri("http://www.nwra.com/spawx/env_latest.html", System.UriKind.Absolute);
            // 
            // tabPageAverage
            // 
            this.tabPageAverage.Controls.Add(this.webBrowserAverage);
            this.tabPageAverage.Location = new System.Drawing.Point(4, 22);
            this.tabPageAverage.Name = "tabPageAverage";
            this.tabPageAverage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAverage.Size = new System.Drawing.Size(418, 271);
            this.tabPageAverage.TabIndex = 1;
            this.tabPageAverage.Text = "Three month average";
            this.tabPageAverage.UseVisualStyleBackColor = true;
            // 
            // webBrowserAverage
            // 
            this.webBrowserAverage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserAverage.Location = new System.Drawing.Point(3, 3);
            this.webBrowserAverage.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserAverage.Name = "webBrowserAverage";
            this.webBrowserAverage.Size = new System.Drawing.Size(412, 265);
            this.webBrowserAverage.TabIndex = 0;
            this.webBrowserAverage.Url = new System.Uri("http://www.spaceweather.ca/data-donnee/sol_flux/sx-5-mavg-eng.php", System.UriKind.Absolute);
            // 
            // tabPageChild
            // 
            this.tabPageChild.Controls.Add(this.panelChild);
            this.tabPageChild.Location = new System.Drawing.Point(4, 22);
            this.tabPageChild.Name = "tabPageChild";
            this.tabPageChild.Size = new System.Drawing.Size(418, 271);
            this.tabPageChild.TabIndex = 2;
            this.tabPageChild.Text = "Child";
            this.tabPageChild.UseVisualStyleBackColor = true;
            // 
            // panelCenter
            // 
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(426, 297);
            this.panelCenter.TabIndex = 26;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(426, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 297);
            this.panelRight.TabIndex = 24;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 297);
            this.panelLeft.TabIndex = 23;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(426, 0);
            this.panelTop.TabIndex = 22;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 297);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(426, 0);
            this.panelBottom.TabIndex = 25;
            // 
            // panelChild
            // 
            this.panelChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChild.Location = new System.Drawing.Point(0, 0);
            this.panelChild.Name = "panelChild";
            this.panelChild.Size = new System.Drawing.Size(418, 271);
            this.panelChild.TabIndex = 0;
            // 
            // UserControlAtmosphereChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlAtmosphereChild";
            this.Size = new System.Drawing.Size(426, 297);
            this.tabControl.ResumeLayout(false);
            this.tabPageCurrent.ResumeLayout(false);
            this.tabPageAverage.ResumeLayout(false);
            this.tabPageChild.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageCurrent;
        private System.Windows.Forms.WebBrowser webBrowserCurrent;
        private System.Windows.Forms.TabPage tabPageAverage;
        private System.Windows.Forms.WebBrowser webBrowserAverage;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TabPage tabPageChild;
        private System.Windows.Forms.Panel panelChild;
    }
}
