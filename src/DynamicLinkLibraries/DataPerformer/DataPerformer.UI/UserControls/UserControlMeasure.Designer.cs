namespace DataPerformer.UI.UserControls
{
    partial class UserControlMeasure
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
            this.components = new System.ComponentModel.Container();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxColorPicker = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel6 = new System.Windows.Forms.Panel();
            this.checkBoxStep = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxMeasure = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelTopTop = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelCenter.SuspendLayout();
            this.panel4.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.panel4);
            this.panelCenter.Controls.Add(this.panel6);
            this.panelCenter.Controls.Add(this.panel7);
            this.panelCenter.Controls.Add(this.panel8);
            this.panelCenter.Controls.Add(this.panel9);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 23);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(215, 31);
            this.panelCenter.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.comboBoxColorPicker);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(161, 31);
            this.panel4.TabIndex = 15;
            // 
            // comboBoxColorPicker
            // 
            this.comboBoxColorPicker.Color = System.Drawing.Color.Black;
            this.comboBoxColorPicker.ContextMenuStrip = this.contextMenuStrip;
            this.comboBoxColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxColorPicker.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxColorPicker.DropDownHeight = 1;
            this.comboBoxColorPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorPicker.DropDownWidth = 1;
            this.comboBoxColorPicker.FormattingEnabled = true;
            this.comboBoxColorPicker.IntegralHeight = false;
            this.comboBoxColorPicker.ItemHeight = 16;
            this.comboBoxColorPicker.Items.AddRange(new object[] {
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color"});
            this.comboBoxColorPicker.Location = new System.Drawing.Point(0, 0);
            this.comboBoxColorPicker.Name = "comboBoxColorPicker";
            this.comboBoxColorPicker.Size = new System.Drawing.Size(161, 22);
            this.comboBoxColorPicker.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(170, 48);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.checkBoxStep);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(165, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(50, 31);
            this.panel6.TabIndex = 13;
            // 
            // checkBoxStep
            // 
            this.checkBoxStep.AutoSize = true;
            this.checkBoxStep.Location = new System.Drawing.Point(3, 6);
            this.checkBoxStep.Name = "checkBoxStep";
            this.checkBoxStep.Size = new System.Drawing.Size(48, 17);
            this.checkBoxStep.TabIndex = 0;
            this.checkBoxStep.Text = "Step";
            this.checkBoxStep.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(4, 31);
            this.panel7.TabIndex = 12;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(215, 0);
            this.panel8.TabIndex = 11;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 31);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(215, 0);
            this.panel9.TabIndex = 14;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(215, 23);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 31);
            this.panelRight.TabIndex = 13;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 23);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 31);
            this.panelLeft.TabIndex = 12;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panel1);
            this.panelTop.Controls.Add(this.panel2);
            this.panelTop.Controls.Add(this.panel3);
            this.panelTop.Controls.Add(this.panelTopTop);
            this.panelTop.Controls.Add(this.panel5);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(215, 23);
            this.panelTop.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxMeasure);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 23);
            this.panel1.TabIndex = 15;
            // 
            // checkBoxMeasure
            // 
            this.checkBoxMeasure.AutoSize = true;
            this.checkBoxMeasure.ContextMenuStrip = this.contextMenuStrip;
            this.checkBoxMeasure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxMeasure.Location = new System.Drawing.Point(0, 0);
            this.checkBoxMeasure.Name = "checkBoxMeasure";
            this.checkBoxMeasure.Size = new System.Drawing.Size(210, 23);
            this.checkBoxMeasure.TabIndex = 0;
            this.checkBoxMeasure.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(215, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 23);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 23);
            this.panel3.TabIndex = 12;
            // 
            // panelTopTop
            // 
            this.panelTopTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopTop.Location = new System.Drawing.Point(0, 0);
            this.panelTopTop.Name = "panelTopTop";
            this.panelTopTop.Size = new System.Drawing.Size(215, 0);
            this.panelTopTop.TabIndex = 11;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 23);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(215, 0);
            this.panel5.TabIndex = 14;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 54);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(215, 0);
            this.panelBottom.TabIndex = 14;
            // 
            // UserControlMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlMeasure";
            this.Size = new System.Drawing.Size(215, 54);
            this.panelCenter.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelTopTop;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox checkBoxMeasure;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private OfficePickers.ColorPicker.ComboBoxColorPicker comboBoxColorPicker;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxStep;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}
