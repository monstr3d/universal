namespace Error.UI.Forms
{
    partial class FormMessages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessages));
            this.userControlMessages = new Error.UI.UserControls.UserControlMessages();
            this.SuspendLayout();
            // 
            // userControlMessages
            // 
            this.userControlMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlMessages.Location = new System.Drawing.Point(0, 0);
            this.userControlMessages.Name = "userControlMessages";
            this.userControlMessages.Size = new System.Drawing.Size(284, 262);
            this.userControlMessages.TabIndex = 0;
            // 
            // FormMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.userControlMessages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMessages";
            this.Text = "Messages";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UserControlMessages userControlMessages;
    }
}