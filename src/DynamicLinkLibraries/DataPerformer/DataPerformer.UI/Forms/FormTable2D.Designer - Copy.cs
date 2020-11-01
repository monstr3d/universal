namespace DataPerformer.UI.Forms
{
    partial class FormTable2D
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTable2D));
            this.userControlTable2DTab = new DataPerformer.UI.UserControls.UserControlTable2DTab();
            this.SuspendLayout();
            // 
            // userControlTable2DTab
            // 
            this.userControlTable2DTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlTable2DTab.Location = new System.Drawing.Point(0, 0);
            this.userControlTable2DTab.Name = "userControlTable2DTab";
            this.userControlTable2DTab.Size = new System.Drawing.Size(361, 300);
            this.userControlTable2DTab.TabIndex = 0;
            // 
            // FormTable2D
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(361, 300);
            this.Controls.Add(this.userControlTable2DTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTable2D";
            this.Text = "FormTable2D";
            this.Load += new System.EventHandler(this.FormTable2D_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UserControlTable2DTab userControlTable2DTab;





    }
}