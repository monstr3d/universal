namespace DataPerformer.UI.UserControls
{
    partial class UserControlFeedBack
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
            this.userControlComboboxList = new Diagram.UI.UserControls.UserControlComboboxList();
            this.SuspendLayout();
            // 
            // userControlComboboxList
            // 
            this.userControlComboboxList.Count = 1;
            this.userControlComboboxList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlComboboxList.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userControlComboboxList.Location = new System.Drawing.Point(0, 0);
            this.userControlComboboxList.Name = "userControlComboboxList";
            this.userControlComboboxList.Size = new System.Drawing.Size(575, 428);
            this.userControlComboboxList.TabIndex = 0;
            this.userControlComboboxList.Texts = new string[] {
        ""};
            // 
            // UserControlFeedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControlComboboxList);
            this.Name = "UserControlFeedBack";
            this.Size = new System.Drawing.Size(575, 428);
            this.ResumeLayout(false);

        }

        #endregion

        private Diagram.UI.UserControls.UserControlComboboxList userControlComboboxList;
    }
}
