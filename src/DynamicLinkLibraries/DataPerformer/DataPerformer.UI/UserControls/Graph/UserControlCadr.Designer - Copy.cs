namespace DataPerformer.UI.UserControls.Graph
{
    partial class UserControlCadr
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelTableTop = new System.Windows.Forms.Panel();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTableRight = new System.Windows.Forms.Panel();
            this.panelTableLeft = new System.Windows.Forms.Panel();
            this.panelTableCenter = new System.Windows.Forms.Panel();
            this.panelTableBottom = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelTopDigital = new System.Windows.Forms.Panel();
            this.numericUpDownCadr = new System.Windows.Forms.NumericUpDown();
            this.panelTableTop.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.panelTopDigital.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCadr)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 401);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(627, 0);
            this.panelBottom.TabIndex = 24;
            // 
            // panelTableTop
            // 
            this.panelTableTop.Controls.Add(this.listView);
            this.panelTableTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTableTop.Location = new System.Drawing.Point(0, 33);
            this.panelTableTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTableTop.Name = "panelTableTop";
            this.panelTableTop.Size = new System.Drawing.Size(627, 368);
            this.panelTableTop.TabIndex = 25;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderValue});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(627, 368);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 128;
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "Value";
            this.columnHeaderValue.Width = 91;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(627, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 401);
            this.panelRight.TabIndex = 23;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 401);
            this.panelLeft.TabIndex = 22;
            // 
            // panelTableRight
            // 
            this.panelTableRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTableRight.Location = new System.Drawing.Point(627, 33);
            this.panelTableRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTableRight.Name = "panelTableRight";
            this.panelTableRight.Size = new System.Drawing.Size(0, 368);
            this.panelTableRight.TabIndex = 23;
            // 
            // panelTableLeft
            // 
            this.panelTableLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTableLeft.Location = new System.Drawing.Point(0, 33);
            this.panelTableLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTableLeft.Name = "panelTableLeft";
            this.panelTableLeft.Size = new System.Drawing.Size(0, 368);
            this.panelTableLeft.TabIndex = 22;
            // 
            // panelTableCenter
            // 
            this.panelTableCenter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTableCenter.Location = new System.Drawing.Point(0, 33);
            this.panelTableCenter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTableCenter.Name = "panelTableCenter";
            this.panelTableCenter.Size = new System.Drawing.Size(627, 0);
            this.panelTableCenter.TabIndex = 21;
            // 
            // panelTableBottom
            // 
            this.panelTableBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTableBottom.Location = new System.Drawing.Point(0, 401);
            this.panelTableBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTableBottom.Name = "panelTableBottom";
            this.panelTableBottom.Size = new System.Drawing.Size(627, 0);
            this.panelTableBottom.TabIndex = 24;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.panelTableTop);
            this.panelCenter.Controls.Add(this.panelTableRight);
            this.panelCenter.Controls.Add(this.panelTableLeft);
            this.panelCenter.Controls.Add(this.panelTableCenter);
            this.panelCenter.Controls.Add(this.panelTableBottom);
            this.panelCenter.Controls.Add(this.panelTopDigital);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(627, 401);
            this.panelCenter.TabIndex = 25;
            // 
            // panelTopDigital
            // 
            this.panelTopDigital.Controls.Add(this.numericUpDownCadr);
            this.panelTopDigital.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopDigital.Location = new System.Drawing.Point(0, 0);
            this.panelTopDigital.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTopDigital.Name = "panelTopDigital";
            this.panelTopDigital.Size = new System.Drawing.Size(627, 33);
            this.panelTopDigital.TabIndex = 18;
            // 
            // numericUpDownCadr
            // 
            this.numericUpDownCadr.Location = new System.Drawing.Point(17, 5);
            this.numericUpDownCadr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownCadr.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownCadr.Name = "numericUpDownCadr";
            this.numericUpDownCadr.Size = new System.Drawing.Size(160, 22);
            this.numericUpDownCadr.TabIndex = 0;
            this.numericUpDownCadr.ValueChanged += new System.EventHandler(this.numericUpDownCadr_ValueChanged);
            // 
            // UserControlCadr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelCenter);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserControlCadr";
            this.Size = new System.Drawing.Size(627, 401);
            this.panelTableTop.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.panelTopDigital.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCadr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTableTop;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTableRight;
        private System.Windows.Forms.Panel panelTableLeft;
        private System.Windows.Forms.Panel panelTableCenter;
        private System.Windows.Forms.Panel panelTableBottom;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelTopDigital;
        private System.Windows.Forms.NumericUpDown numericUpDownCadr;
    }
}
