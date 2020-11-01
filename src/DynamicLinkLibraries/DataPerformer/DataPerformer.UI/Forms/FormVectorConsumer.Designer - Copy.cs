namespace DataPerformer.UI.Forms
{
    partial class FormVectorConsumer
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
            this.userControlFormulaEditor = new DataPerformer.UI.UserControls.UserControlFormulaEditor();
            this.SuspendLayout();
            // 
            // userControlFormulaEditor
            // 
            this.userControlFormulaEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlFormulaEditor.Location = new System.Drawing.Point(0, 0);
            this.userControlFormulaEditor.Name = "userControlFormulaEditor";
            this.userControlFormulaEditor.Size = new System.Drawing.Size(782, 570);
            this.userControlFormulaEditor.TabIndex = 0;
            // 
            // FormVectorConsumer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 570);
            this.Controls.Add(this.userControlFormulaEditor);
            this.Name = "FormVectorConsumer";
            this.Text = "FormVectorConsumer";
            this.Load += new System.EventHandler(this.FormVectorConsumer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DataPerformer.UI.UserControls.UserControlFormulaEditor userControlFormulaEditor;
    }
}