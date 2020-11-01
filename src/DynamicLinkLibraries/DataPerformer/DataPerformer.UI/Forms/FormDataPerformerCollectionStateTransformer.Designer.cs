namespace DataPerformer.UI.Forms
{
    partial class FormDataPerformerCollectionStateTransformer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataPerformerCollectionStateTransformer));
            this.userControlComponentCollectionVariablesFull = new DataPerformer.UI.UserControls.UserControlComponentCollectionVariablesFull();
            this.SuspendLayout();
            // 
            // userControlComponentCollectionVariablesFull
            // 
            this.userControlComponentCollectionVariablesFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlComponentCollectionVariablesFull.Location = new System.Drawing.Point(0, 0);
            this.userControlComponentCollectionVariablesFull.Name = "userControlComponentCollectionVariablesFull";
            this.userControlComponentCollectionVariablesFull.Size = new System.Drawing.Size(284, 264);
            this.userControlComponentCollectionVariablesFull.TabIndex = 0;
            this.userControlComponentCollectionVariablesFull.Transformer = null;
            // 
            // FormDataPerformerCollectionStateTransformer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.userControlComponentCollectionVariablesFull);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDataPerformerCollectionStateTransformer";
            this.Text = "FormDataPerformerCollectionStateTransformer";
            this.ResumeLayout(false);

        }

        #endregion

        private DataPerformer.UI.UserControls.UserControlComponentCollectionVariablesFull userControlComponentCollectionVariablesFull;


    }
}