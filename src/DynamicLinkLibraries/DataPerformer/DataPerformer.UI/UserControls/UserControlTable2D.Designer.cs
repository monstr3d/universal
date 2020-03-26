namespace DataPerformer.UI.UserControls
{
    partial class UserControlTable2D
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveFileDialogTable2D = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogTable2D = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // UserControlTable2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UserControlTable2D";
            this.Size = new System.Drawing.Size(390, 298);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControlTable2D_Paint);
            this.Resize += new System.EventHandler(this.UserControlTable2D_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialogTable2D;
        private System.Windows.Forms.OpenFileDialog openFileDialogTable2D;

    }
}
