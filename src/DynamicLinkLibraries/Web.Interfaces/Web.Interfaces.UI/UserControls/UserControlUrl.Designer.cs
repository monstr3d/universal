namespace Web.Interfaces.UI.UserControls
{
    partial class UserControlUrl
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
            this.components = new System.ComponentModel.Container();
            this.webBrowserSearch = new System.Windows.Forms.WebBrowser();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSearch = new System.Windows.Forms.TabPage();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.webBrowserResult = new System.Windows.Forms.WebBrowser();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyUrlToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabPageSearch.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowserSearch
            // 
            this.webBrowserSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserSearch.Location = new System.Drawing.Point(3, 3);
            this.webBrowserSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserSearch.Name = "webBrowserSearch";
            this.webBrowserSearch.Size = new System.Drawing.Size(239, 195);
            this.webBrowserSearch.TabIndex = 0;
            this.webBrowserSearch.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowserSearch.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserSearch_DocumentCompleted);
            // 
            // tabControl
            // 
            this.tabControl.ContextMenuStrip = this.contextMenuStrip;
            this.tabControl.Controls.Add(this.tabPageSearch);
            this.tabControl.Controls.Add(this.tabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(253, 227);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageSearch
            // 
            this.tabPageSearch.Controls.Add(this.webBrowserSearch);
            this.tabPageSearch.Location = new System.Drawing.Point(4, 22);
            this.tabPageSearch.Name = "tabPageSearch";
            this.tabPageSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSearch.Size = new System.Drawing.Size(245, 201);
            this.tabPageSearch.TabIndex = 0;
            this.tabPageSearch.Text = "Search";
            this.tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.webBrowserResult);
            this.tabPage.Location = new System.Drawing.Point(4, 22);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(245, 201);
            this.tabPage.TabIndex = 1;
            this.tabPage.Text = "Result";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // webBrowserResult
            // 
            this.webBrowserResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserResult.Location = new System.Drawing.Point(3, 3);
            this.webBrowserResult.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserResult.Name = "webBrowserResult";
            this.webBrowserResult.Size = new System.Drawing.Size(239, 195);
            this.webBrowserResult.TabIndex = 0;
            this.webBrowserResult.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControl);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(253, 227);
            this.panelCenter.TabIndex = 25;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(253, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 227);
            this.panelRight.TabIndex = 23;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 227);
            this.panelLeft.TabIndex = 22;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(253, 0);
            this.panelTop.TabIndex = 21;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 227);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(253, 0);
            this.panelBottom.TabIndex = 24;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyUrlToClipboardToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(194, 26);
            // 
            // copyUrlToClipboardToolStripMenuItem
            // 
            this.copyUrlToClipboardToolStripMenuItem.Name = "copyUrlToClipboardToolStripMenuItem";
            this.copyUrlToClipboardToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.copyUrlToClipboardToolStripMenuItem.Text = "Copy URL to clipboard";
            this.copyUrlToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyUrlToClipboardToolStripMenuItem_Click);
            // 
            // UserControlUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlUrl";
            this.Size = new System.Drawing.Size(253, 227);
            this.tabControl.ResumeLayout(false);
            this.tabPageSearch.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserSearch;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSearch;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.WebBrowser webBrowserResult;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyUrlToClipboardToolStripMenuItem;
    }
}
