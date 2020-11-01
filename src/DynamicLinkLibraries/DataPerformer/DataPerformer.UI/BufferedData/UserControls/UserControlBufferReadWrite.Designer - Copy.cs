using DataPerformer.Interfaces;

namespace DataPerformer.UI.BufferedData.UserControls
{
    partial class UserControlBufferReadWrite
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (buffer != null)
            {
                (buffer as IDataConsumer).OnChangeInput -= Fill;
                buffer = null;
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlBufferReadWrite));
            this.panelCenter = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageInput = new System.Windows.Forms.TabPage();
            this.panelСomboList = new System.Windows.Forms.Panel();
            this.panelCombointernal = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnMeasurement = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.checkBoxDirectory = new System.Windows.Forms.CheckBox();
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.panelBottomMeasurements = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelData = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabPageCadr = new System.Windows.Forms.TabPage();
            this.panelCadr = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showIndicatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCenter.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageInput.SuspendLayout();
            this.panelСomboList.SuspendLayout();
            this.panelCombointernal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panelBottomMeasurements.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageCadr.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControl);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 27);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(4);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(328, 233);
            this.panelCenter.TabIndex = 20;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageInput);
            this.tabControl.Controls.Add(this.tabPageData);
            this.tabControl.Controls.Add(this.tabPageCadr);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(328, 233);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageInput
            // 
            this.tabPageInput.Controls.Add(this.panelСomboList);
            this.tabPageInput.Controls.Add(this.panel10);
            this.tabPageInput.Controls.Add(this.panel11);
            this.tabPageInput.Controls.Add(this.panel12);
            this.tabPageInput.Controls.Add(this.panelBottomMeasurements);
            this.tabPageInput.Location = new System.Drawing.Point(4, 25);
            this.tabPageInput.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageInput.Name = "tabPageInput";
            this.tabPageInput.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageInput.Size = new System.Drawing.Size(320, 204);
            this.tabPageInput.TabIndex = 0;
            this.tabPageInput.Text = "Input";
            this.tabPageInput.UseVisualStyleBackColor = true;
            // 
            // panelСomboList
            // 
            this.panelСomboList.AutoScroll = true;
            this.panelСomboList.Controls.Add(this.panelCombointernal);
            this.panelСomboList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelСomboList.Location = new System.Drawing.Point(11, 32);
            this.panelСomboList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelСomboList.Name = "panelСomboList";
            this.panelСomboList.Size = new System.Drawing.Size(298, 162);
            this.panelСomboList.TabIndex = 15;
            // 
            // panelCombointernal
            // 
            this.panelCombointernal.AutoSize = true;
            this.panelCombointernal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelCombointernal.Controls.Add(this.dataGridView);
            this.panelCombointernal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCombointernal.Location = new System.Drawing.Point(0, 0);
            this.panelCombointernal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCombointernal.Name = "panelCombointernal";
            this.panelCombointernal.Size = new System.Drawing.Size(298, 162);
            this.panelCombointernal.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMeasurement});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(298, 162);
            this.dataGridView.TabIndex = 0;
            // 
            // ColumnMeasurement
            // 
            this.ColumnMeasurement.HeaderText = "Measurements";
            this.ColumnMeasurement.Name = "ColumnMeasurement";
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(309, 32);
            this.panel10.Margin = new System.Windows.Forms.Padding(4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(7, 162);
            this.panel10.TabIndex = 13;
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(4, 32);
            this.panel11.Margin = new System.Windows.Forms.Padding(4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(7, 162);
            this.panel11.TabIndex = 12;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel19);
            this.panel12.Controls.Add(this.panel20);
            this.panel12.Controls.Add(this.panel21);
            this.panel12.Controls.Add(this.panel22);
            this.panel12.Controls.Add(this.panel23);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(4, 4);
            this.panel12.Margin = new System.Windows.Forms.Padding(4);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(312, 28);
            this.panel12.TabIndex = 11;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.checkBoxDirectory);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel19.Location = new System.Drawing.Point(13, 0);
            this.panel19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(286, 28);
            this.panel19.TabIndex = 15;
            // 
            // checkBoxDirectory
            // 
            this.checkBoxDirectory.AutoSize = true;
            this.checkBoxDirectory.Location = new System.Drawing.Point(7, 2);
            this.checkBoxDirectory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxDirectory.Name = "checkBoxDirectory";
            this.checkBoxDirectory.Size = new System.Drawing.Size(87, 21);
            this.checkBoxDirectory.TabIndex = 1;
            this.checkBoxDirectory.Text = "Directory";
            this.checkBoxDirectory.UseVisualStyleBackColor = true;
            // 
            // panel20
            // 
            this.panel20.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel20.Location = new System.Drawing.Point(299, 0);
            this.panel20.Margin = new System.Windows.Forms.Padding(4);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(13, 28);
            this.panel20.TabIndex = 13;
            // 
            // panel21
            // 
            this.panel21.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel21.Location = new System.Drawing.Point(0, 0);
            this.panel21.Margin = new System.Windows.Forms.Padding(4);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(13, 28);
            this.panel21.TabIndex = 12;
            // 
            // panel22
            // 
            this.panel22.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel22.Location = new System.Drawing.Point(0, 0);
            this.panel22.Margin = new System.Windows.Forms.Padding(4);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(312, 0);
            this.panel22.TabIndex = 11;
            // 
            // panel23
            // 
            this.panel23.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel23.Location = new System.Drawing.Point(0, 28);
            this.panel23.Margin = new System.Windows.Forms.Padding(4);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(312, 0);
            this.panel23.TabIndex = 14;
            // 
            // panelBottomMeasurements
            // 
            this.panelBottomMeasurements.Controls.Add(this.panel14);
            this.panelBottomMeasurements.Controls.Add(this.panel15);
            this.panelBottomMeasurements.Controls.Add(this.panel16);
            this.panelBottomMeasurements.Controls.Add(this.panel17);
            this.panelBottomMeasurements.Controls.Add(this.panel18);
            this.panelBottomMeasurements.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomMeasurements.Location = new System.Drawing.Point(4, 194);
            this.panelBottomMeasurements.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottomMeasurements.Name = "panelBottomMeasurements";
            this.panelBottomMeasurements.Size = new System.Drawing.Size(312, 6);
            this.panelBottomMeasurements.TabIndex = 14;
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(76, 0);
            this.panel14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(151, 6);
            this.panel14.TabIndex = 15;
            // 
            // panel15
            // 
            this.panel15.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel15.Location = new System.Drawing.Point(227, 0);
            this.panel15.Margin = new System.Windows.Forms.Padding(4);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(85, 6);
            this.panel15.TabIndex = 13;
            // 
            // panel16
            // 
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(0, 0);
            this.panel16.Margin = new System.Windows.Forms.Padding(4);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(76, 6);
            this.panel16.TabIndex = 12;
            // 
            // panel17
            // 
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Margin = new System.Windows.Forms.Padding(4);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(312, 0);
            this.panel17.TabIndex = 11;
            // 
            // panel18
            // 
            this.panel18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel18.Location = new System.Drawing.Point(0, 6);
            this.panel18.Margin = new System.Windows.Forms.Padding(4);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(312, 0);
            this.panel18.TabIndex = 14;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.panel1);
            this.tabPageData.Controls.Add(this.panel2);
            this.tabPageData.Controls.Add(this.panel3);
            this.tabPageData.Controls.Add(this.panelTop);
            this.tabPageData.Controls.Add(this.panel4);
            this.tabPageData.Location = new System.Drawing.Point(4, 25);
            this.tabPageData.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageData.Size = new System.Drawing.Size(320, 204);
            this.tabPageData.TabIndex = 1;
            this.tabPageData.Text = "Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelData);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 196);
            this.panel1.TabIndex = 20;
            // 
            // panelData
            // 
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 0);
            this.panelData.Margin = new System.Windows.Forms.Padding(4);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(312, 196);
            this.panelData.TabIndex = 20;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(312, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(0, 196);
            this.panel6.TabIndex = 18;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(0, 196);
            this.panel7.TabIndex = 17;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(312, 0);
            this.panel8.TabIndex = 16;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 196);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(312, 0);
            this.panel9.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(316, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 196);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 196);
            this.panel3.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(4, 4);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(312, 0);
            this.panelTop.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(4, 200);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(312, 0);
            this.panel4.TabIndex = 19;
            // 
            // tabPageCadr
            // 
            this.tabPageCadr.Controls.Add(this.panelCadr);
            this.tabPageCadr.Location = new System.Drawing.Point(4, 25);
            this.tabPageCadr.Name = "tabPageCadr";
            this.tabPageCadr.Size = new System.Drawing.Size(320, 204);
            this.tabPageCadr.TabIndex = 2;
            this.tabPageCadr.Text = "Cadr";
            this.tabPageCadr.UseVisualStyleBackColor = true;
            // 
            // panelCadr
            // 
            this.panelCadr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCadr.Location = new System.Drawing.Point(0, 0);
            this.panelCadr.Margin = new System.Windows.Forms.Padding(4);
            this.panelCadr.Name = "panelCadr";
            this.panelCadr.Size = new System.Drawing.Size(320, 204);
            this.panelCadr.TabIndex = 26;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(328, 27);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 233);
            this.panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 27);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 233);
            this.panelLeft.TabIndex = 17;
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStart});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(328, 27);
            this.toolStrip.TabIndex = 16;
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStart.Image")));
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonStart.Text = "Start";
            this.toolStripButtonStart.Click += new System.EventHandler(this.toolStripButtonStart_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 260);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(328, 0);
            this.panelBottom.TabIndex = 19;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showIndicatorsToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(190, 30);
            // 
            // showIndicatorsToolStripMenuItem
            // 
            this.showIndicatorsToolStripMenuItem.Name = "showIndicatorsToolStripMenuItem";
            this.showIndicatorsToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.showIndicatorsToolStripMenuItem.Text = "Show indicators";
            this.showIndicatorsToolStripMenuItem.Click += new System.EventHandler(this.showIndicatorsToolStripMenuItem_Click);
            // 
            // UserControlBufferReadWrite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.panelBottom);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlBufferReadWrite";
            this.Size = new System.Drawing.Size(328, 260);
            this.Load += new System.EventHandler(this.UserControlBufferReadWrite_Load);
            this.panelCenter.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageInput.ResumeLayout(false);
            this.panelСomboList.ResumeLayout(false);
            this.panelСomboList.PerformLayout();
            this.panelCombointernal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panelBottomMeasurements.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPageCadr.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageInput;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panelСomboList;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panelBottomMeasurements;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.Panel panelCombointernal;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.CheckBox checkBoxDirectory;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnMeasurement;
        private System.Windows.Forms.TabPage tabPageCadr;
        private System.Windows.Forms.Panel panelCadr;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showIndicatorsToolStripMenuItem;
    }
}
