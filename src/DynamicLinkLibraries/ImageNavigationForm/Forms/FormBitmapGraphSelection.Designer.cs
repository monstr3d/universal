namespace ImageNavigation.Forms
{
    partial class FormBitmapGraphSelection
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
            this.userControlBitmapGraphSelectionTab = new ImageNavigation.UserControls.UserControlBitmapGraphSelectionTab();
            this.SuspendLayout();
            // 
            // userControlBitmapGraphSelectionTab
            // 
            this.userControlBitmapGraphSelectionTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlBitmapGraphSelectionTab.Location = new System.Drawing.Point(0, 0);
            this.userControlBitmapGraphSelectionTab.Name = "userControlBitmapGraphSelectionTab";
            this.userControlBitmapGraphSelectionTab.Size = new System.Drawing.Size(371, 366);
            this.userControlBitmapGraphSelectionTab.TabIndex = 0;
            // 
            // FormBitmapGraphSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 366);
            this.Controls.Add(this.userControlBitmapGraphSelectionTab);
            this.Name = "FormBitmapGraphSelection";
            this.Text = "FormBitmapGraphSelection";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UserControlBitmapGraphSelectionTab userControlBitmapGraphSelectionTab;
    }
}