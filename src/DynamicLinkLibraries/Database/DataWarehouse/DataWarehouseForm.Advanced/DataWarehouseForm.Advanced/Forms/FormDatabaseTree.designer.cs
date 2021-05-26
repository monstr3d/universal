namespace DataWarehouse.Advanced.Forms
{
    
    partial class FormDatabaseTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatabaseTree));
            this.userControlTree = new DataWarehouse.UserControls.UserControlTree();
            this.SuspendLayout();
            // 
            // userControlTree
            // 
            this.userControlTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlTree.Location = new System.Drawing.Point(0, 0);
            this.userControlTree.Name = "userControlTree";
            this.userControlTree.Size = new System.Drawing.Size(401, 415);
            this.userControlTree.TabIndex = 0;
            this.userControlTree.OnRemove += new System.Action<System.Windows.Forms.TreeNode>(this.userControlTree_OnRemove);
            this.userControlTree.OnSearch += new System.Action<string>(this.Search);
            // 
            // FormDatabaseTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 415);
            this.Controls.Add(this.userControlTree);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDatabaseTree";
            this.Text = "Database";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UserControlTree userControlTree;

    }
}