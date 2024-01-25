namespace Trading.Library.Forms.UserControls
{
    partial class UserControlOrderTable
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
            components = new System.ComponentModel.Container();
            panelBottom = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            panel4 = new System.Windows.Forms.Panel();
            panel5 = new System.Windows.Forms.Panel();
            panelCenter = new System.Windows.Forms.Panel();
            dataGridView = new System.Windows.Forms.DataGridView();
            panelRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            bindingSource = new System.Windows.Forms.BindingSource(components);
            DateEnter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Exit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            EnterPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ExitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Income = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Long = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            panelBottom.SuspendLayout();
            panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(panel1);
            panelBottom.Controls.Add(panel2);
            panelBottom.Controls.Add(panel3);
            panelBottom.Controls.Add(panel4);
            panelBottom.Controls.Add(panel5);
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(11, 396);
            panelBottom.Margin = new System.Windows.Forms.Padding(4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(643, 11);
            panelBottom.TabIndex = 14;
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(643, 11);
            panel1.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Right;
            panel2.Location = new System.Drawing.Point(643, 0);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(0, 11);
            panel2.TabIndex = 18;
            // 
            // panel3
            // 
            panel3.Dock = System.Windows.Forms.DockStyle.Left;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Margin = new System.Windows.Forms.Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(0, 11);
            panel3.TabIndex = 17;
            // 
            // panel4
            // 
            panel4.Dock = System.Windows.Forms.DockStyle.Top;
            panel4.Location = new System.Drawing.Point(0, 0);
            panel4.Margin = new System.Windows.Forms.Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(643, 0);
            panel4.TabIndex = 16;
            // 
            // panel5
            // 
            panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel5.Location = new System.Drawing.Point(0, 11);
            panel5.Margin = new System.Windows.Forms.Padding(4);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(643, 0);
            panel5.TabIndex = 19;
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(dataGridView);
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(11, 11);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(643, 396);
            panelCenter.TabIndex = 15;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { DateEnter, Exit, EnterPrice, ExitPrice, Income, Long });
            dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView.Location = new System.Drawing.Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.Size = new System.Drawing.Size(643, 396);
            dataGridView.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(654, 11);
            panelRight.Margin = new System.Windows.Forms.Padding(4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(11, 396);
            panelRight.TabIndex = 13;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 11);
            panelLeft.Margin = new System.Windows.Forms.Padding(4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(11, 396);
            panelLeft.TabIndex = 12;
            // 
            // panelTop
            // 
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(665, 11);
            panelTop.TabIndex = 11;
            // 
            // DateEnter
            // 
            DateEnter.HeaderText = "Enter Date";
            DateEnter.Name = "DateEnter";
            DateEnter.ReadOnly = true;
            // 
            // Exit
            // 
            Exit.HeaderText = "Exit date";
            Exit.Name = "Exit";
            Exit.ReadOnly = true;
            // 
            // EnterPrice
            // 
            EnterPrice.HeaderText = "Enter Price";
            EnterPrice.Name = "EnterPrice";
            EnterPrice.ReadOnly = true;
            // 
            // ExitPrice
            // 
            ExitPrice.HeaderText = "Exit Price";
            ExitPrice.Name = "ExitPrice";
            ExitPrice.ReadOnly = true;
            // 
            // Income
            // 
            Income.HeaderText = "Income";
            Income.Name = "Income";
            Income.ReadOnly = true;
            // 
            // Long
            // 
            Long.HeaderText = "Long Position";
            Long.Name = "Long";
            Long.ReadOnly = true;
            // 
            // UserControlOrderTable
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelBottom);
            Controls.Add(panelCenter);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Name = "UserControlOrderTable";
            Size = new System.Drawing.Size(665, 407);
            panelBottom.ResumeLayout(false);
            panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateEnter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exit;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnterPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Income;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Long;
    }
}
