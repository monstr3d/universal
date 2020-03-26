namespace DataPerformer.UI.Forms
{
    partial class FormTable3D
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTable3D));
            this.userControlTable3D = new DataPerformer.UI.UserControls.UserControlTable3D();
            this.SuspendLayout();
            // 
            // userControlTable3D
            // 
            this.userControlTable3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlTable3D.Location = new System.Drawing.Point(0, 0);
            this.userControlTable3D.Name = "userControlTable3D";
            this.userControlTable3D.Size = new System.Drawing.Size(292, 268);
            this.userControlTable3D.TabIndex = 0;
            // 
            // FormTable3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 268);
            this.Controls.Add(this.userControlTable3D);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTable3D";
            this.Text = "FormTable3D";
            this.Load += new System.EventHandler(this.FormTable3D_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UserControlTable3D userControlTable3D;
    }
}