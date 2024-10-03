namespace Motion6D.UI.Forms
{
    partial class FormFieldShape
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
            this.userControlFieldShape = new Motion6D.UI.UserControls.UserControlFieldShape();
            this.SuspendLayout();
            // 
            // userControlFieldShape
            // 
            this.userControlFieldShape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlFieldShape.Label = null;
            this.userControlFieldShape.Location = new System.Drawing.Point(0, 0);
            this.userControlFieldShape.Name = "userControlFieldShape";
            this.userControlFieldShape.Size = new System.Drawing.Size(784, 564);
            this.userControlFieldShape.TabIndex = 0;
            this.userControlFieldShape.Close += new System.Action(this.userControlFieldShape_Close);
            // 
            // FormFieldShape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.userControlFieldShape);
            this.Name = "FormFieldShape";
            this.Text = "FormFieldShape";
            this.ResumeLayout(false);

        }

        #endregion

        private Motion6D.UI.UserControls.UserControlFieldShape userControlFieldShape;
    }
}