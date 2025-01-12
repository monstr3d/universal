namespace WpfInterface.UI.Forms
{
    partial class FormDeformed
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
            this.userControlDeformed = new WpfInterface.UI.UserControls.UserControlDeformed();
            this.SuspendLayout();
            // 
            // userControlDeformed
            // 
            this.userControlDeformed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlDeformed.Location = new System.Drawing.Point(0, 0);
            this.userControlDeformed.Name = "userControlDeformed";
            this.userControlDeformed.Size = new System.Drawing.Size(773, 452);
            this.userControlDeformed.TabIndex = 0;
            // 
            // FormDeformed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 452);
            this.Controls.Add(this.userControlDeformed);
            this.Name = "FormDeformed";
            this.Text = "FormDeformed";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UserControlDeformed userControlDeformed;
    }
}