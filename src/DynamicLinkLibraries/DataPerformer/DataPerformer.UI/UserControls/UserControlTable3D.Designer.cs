namespace DataPerformer.UI.UserControls
{
    partial class UserControlTable3D
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlTable3D));
            this.panelCenter = new System.Windows.Forms.Panel();
            this.userControlCommentsFont = new Diagram.UI.UserControls.UserControlCommentsFont();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogXml = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogXml = new System.Windows.Forms.SaveFileDialog();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonXml = new System.Windows.Forms.ToolStripDropDownButton();
            this.exportToXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCenter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.userControlCommentsFont);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 26);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(4);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(422, 278);
            this.panelCenter.TabIndex = 20;
            // 
            // userControlCommentsFont
            // 
            this.userControlCommentsFont.AutoSave = true;
            this.userControlCommentsFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlCommentsFont.Location = new System.Drawing.Point(0, 0);
            this.userControlCommentsFont.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userControlCommentsFont.Name = "userControlCommentsFont";
            this.userControlCommentsFont.Size = new System.Drawing.Size(422, 278);
            this.userControlCommentsFont.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(422, 26);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 278);
            this.panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 26);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 278);
            this.panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStripMain);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(422, 26);
            this.panelTop.TabIndex = 16;
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripDropDownButtonXml});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(422, 25);
            this.toolStripMain.TabIndex = 2;
            this.toolStripMain.Text = "Main";
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 304);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(422, 0);
            this.panelBottom.TabIndex = 19;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Function files |*.xml";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Function files |*.xml";
            // 
            // openFileDialogXml
            // 
            this.openFileDialogXml.Filter = "Xml files |*.xml";
            // 
            // saveFileDialogXml
            // 
            this.saveFileDialogXml.Filter = "Xml files |*.xml";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "Open";
            this.openToolStripButton.Visible = false;
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "Save";
            this.saveToolStripButton.Visible = false;
            // 
            // toolStripDropDownButtonXml
            // 
            this.toolStripDropDownButtonXml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonXml.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToXmlToolStripMenuItem,
            this.importFromXmlToolStripMenuItem});
            this.toolStripDropDownButtonXml.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonXml.Image")));
            this.toolStripDropDownButtonXml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonXml.Name = "toolStripDropDownButtonXml";
            this.toolStripDropDownButtonXml.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButtonXml.Text = "Xml";
            this.toolStripDropDownButtonXml.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripDropDownButtonXml.ToolTipText = "Xml";
            // 
            // exportToXmlToolStripMenuItem
            // 
            this.exportToXmlToolStripMenuItem.Name = "exportToXmlToolStripMenuItem";
            this.exportToXmlToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.exportToXmlToolStripMenuItem.Text = "Export to Xml";
            this.exportToXmlToolStripMenuItem.Click += new System.EventHandler(this.exportToXmlToolStripMenuItem_Click);
            // 
            // importFromXmlToolStripMenuItem
            // 
            this.importFromXmlToolStripMenuItem.Name = "importFromXmlToolStripMenuItem";
            this.importFromXmlToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.importFromXmlToolStripMenuItem.Text = "Import from Xml";
            this.importFromXmlToolStripMenuItem.Click += new System.EventHandler(this.importFromXmlToolStripMenuItem_Click);
            // 
            // UserControlTable3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlTable3D";
            this.Size = new System.Drawing.Size(422, 304);
            this.panelCenter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonXml;
        private System.Windows.Forms.ToolStripMenuItem exportToXmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromXmlToolStripMenuItem;
        private Diagram.UI.UserControls.UserControlCommentsFont userControlCommentsFont;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialogXml;
        private System.Windows.Forms.SaveFileDialog saveFileDialogXml;
    }
}
