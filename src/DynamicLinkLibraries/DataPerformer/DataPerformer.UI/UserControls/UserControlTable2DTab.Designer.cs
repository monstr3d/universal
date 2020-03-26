namespace DataPerformer.UI.UserControls
{
    partial class UserControlTable2DTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlTable2DTab));
            this.panelCenter = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageProperties = new System.Windows.Forms.TabPage();
            this.tabPageComments = new System.Windows.Forms.TabPage();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.userControlTable2DEditor = new DataPerformer.UI.UserControls.UserControlTable2DEditor();
            this.userControlCommentsFont = new Diagram.UI.UserControls.UserControlCommentsFont();
            this.panelCenter.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageProperties.SuspendLayout();
            this.tabPageComments.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControlMain);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(4);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(433, 352);
            this.panelCenter.TabIndex = 20;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageProperties);
            this.tabControlMain.Controls.Add(this.tabPageComments);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(433, 352);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.userControlTable2DEditor);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 25);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProperties.Size = new System.Drawing.Size(425, 323);
            this.tabPageProperties.TabIndex = 0;
            this.tabPageProperties.Text = "Properties";
            this.tabPageProperties.UseVisualStyleBackColor = true;
            // 
            // tabPageComments
            // 
            this.tabPageComments.Controls.Add(this.userControlCommentsFont);
            this.tabPageComments.Location = new System.Drawing.Point(4, 25);
            this.tabPageComments.Name = "tabPageComments";
            this.tabPageComments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageComments.Size = new System.Drawing.Size(425, 323);
            this.tabPageComments.TabIndex = 1;
            this.tabPageComments.Text = "Comments";
            this.tabPageComments.UseVisualStyleBackColor = true;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(433, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 352);
            this.panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 352);
            this.panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(433, 0);
            this.panelTop.TabIndex = 16;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 352);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(433, 0);
            this.panelBottom.TabIndex = 19;
            // 
            // userControlTable2DEditor
            // 
            this.userControlTable2DEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlTable2DEditor.Location = new System.Drawing.Point(3, 3);
            this.userControlTable2DEditor.Margin = new System.Windows.Forms.Padding(4);
            this.userControlTable2DEditor.Name = "userControlTable2DEditor";
            this.userControlTable2DEditor.Size = new System.Drawing.Size(419, 317);
            this.userControlTable2DEditor.TabIndex = 0;
            // 
            // userControlCommentsFont
            // 
            this.userControlCommentsFont.AutoSave = true;
            this.userControlCommentsFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlCommentsFont.Location = new System.Drawing.Point(3, 3);
            this.userControlCommentsFont.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userControlCommentsFont.Name = "userControlCommentsFont";
            this.userControlCommentsFont.Size = new System.Drawing.Size(419, 317);
            this.userControlCommentsFont.TabIndex = 0;
            // 
            // UserControlTable2DTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlTable2DTab";
            this.Size = new System.Drawing.Size(433, 352);
            this.panelCenter.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageProperties.ResumeLayout(false);
            this.tabPageComments.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageProperties;
        private System.Windows.Forms.TabPage tabPageComments;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private UserControlTable2DEditor userControlTable2DEditor;
        private Diagram.UI.UserControls.UserControlCommentsFont userControlCommentsFont;
    }
}
