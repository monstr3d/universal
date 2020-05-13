namespace ImageNavigation.UserControls
{
    partial class UserControlBitmapTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlBitmapTable));
            this.openFileDialogScn = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogScn = new System.Windows.Forms.SaveFileDialog();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.ToolTip = new System.Windows.Forms.ToolTip();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.userControlComboboxList = new Diagram.UI.UserControls.UserControlComboboxList();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialogScn
            // 
            this.openFileDialogScn.FileName = "openFileDialogScn";
            this.openFileDialogScn.Filter = "Operand configuration files |*.cfo";
            // 
            // saveFileDialogScn
            // 
            this.saveFileDialogScn.Filter = "Operand configuration files |*.cfo";
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 158);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(132, 0);
            this.panelBottom.TabIndex = 22;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(132, 25);
            this.toolStrip.TabIndex = 18;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // userControlComboboxList
            // 
            this.userControlComboboxList.Count = 2;
            this.userControlComboboxList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlComboboxList.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userControlComboboxList.Location = new System.Drawing.Point(0, 25);
            this.userControlComboboxList.Name = "userControlComboboxList";
            this.userControlComboboxList.Size = new System.Drawing.Size(132, 133);
            this.userControlComboboxList.TabIndex = 23;
            this.userControlComboboxList.Texts = new string[] {
        "X",
        "Y"};
            // 
            // UserControlBitmapTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.userControlComboboxList);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.toolStrip);
            this.Name = "UserControlBitmapTable";
            this.Size = new System.Drawing.Size(132, 158);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogScn;
        private System.Windows.Forms.SaveFileDialog saveFileDialogScn;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private Diagram.UI.UserControls.UserControlComboboxList userControlComboboxList;

    }
}
