namespace DataPerformer.WebGenerator.UserControls
{
    partial class UserControlOutput
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
            dataGridView = new System.Windows.Forms.DataGridView();
            ColumnParameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ColumnAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panelCenter = new System.Windows.Forms.Panel();
            panelRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            panelBottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panelCenter.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ColumnParameter, ColumnAlias });
            dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView.Location = new System.Drawing.Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new System.Drawing.Size(392, 240);
            dataGridView.TabIndex = 0;
            // 
            // ColumnParameter
            // 
            ColumnParameter.HeaderText = "Parameter";
            ColumnParameter.Name = "ColumnParameter";
            ColumnParameter.ReadOnly = true;
            // 
            // ColumnAlias
            // 
            ColumnAlias.HeaderText = "Alias";
            ColumnAlias.Name = "ColumnAlias";
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(dataGridView);
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(0, 46);
            panelCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(392, 240);
            panelCenter.TabIndex = 25;
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(392, 46);
            panelRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(0, 240);
            panelRight.TabIndex = 23;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 46);
            panelLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(0, 240);
            panelLeft.TabIndex = 22;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(label1);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(392, 46);
            panelTop.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(74, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(107, 15);
            label1.TabIndex = 0;
            label1.Text = "Output parameters";
            // 
            // panelBottom
            // 
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 286);
            panelBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(392, 0);
            panelBottom.TabIndex = 24;
            // 
            // UserControlOutput
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelCenter);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Name = "UserControlOutput";
            Size = new System.Drawing.Size(392, 286);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panelCenter.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAlias;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelBottom;
    }
}
