namespace Http.Meteo.UI.Forms
{
    partial class FormMeteo
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
            this.userControlMeteo = new Http.Meteo.UI.UserControls.UserControlMeteo();
            this.SuspendLayout();
            // 
            // userControlMeteo
            // 
            this.userControlMeteo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlMeteo.Location = new System.Drawing.Point(0, 0);
            this.userControlMeteo.Name = "userControlMeteo";
            this.userControlMeteo.Size = new System.Drawing.Size(284, 262);
            this.userControlMeteo.TabIndex = 0;
            // 
            // FormMeteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.userControlMeteo);
            this.Name = "FormMeteo";
            this.Text = "FormMeteo";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UserControlMeteo userControlMeteo;
    }
}