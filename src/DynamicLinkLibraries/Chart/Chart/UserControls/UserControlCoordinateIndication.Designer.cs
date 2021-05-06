namespace Chart.UserControls
{
    /// <summary>
    /// Indicator of coordinates
    /// </summary>
    partial class UserControlCoordinateIndication
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
            this.radioButtonNumber = new System.Windows.Forms.RadioButton();
            this.radioButtonDateTime = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonDate = new System.Windows.Forms.RadioButton();
            this.radioButtonTime = new System.Windows.Forms.RadioButton();
            this.radioButtonTimeUTC = new System.Windows.Forms.RadioButton();
            this.radioButtonDateUTC = new System.Windows.Forms.RadioButton();
            this.radioButtonDateTimeUTC = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radioButtonNumber
            // 
            this.radioButtonNumber.AutoSize = true;
            this.radioButtonNumber.Checked = true;
            this.radioButtonNumber.Location = new System.Drawing.Point(18, 17);
            this.radioButtonNumber.Name = "radioButtonNumber";
            this.radioButtonNumber.Size = new System.Drawing.Size(64, 17);
            this.radioButtonNumber.TabIndex = 0;
            this.radioButtonNumber.TabStop = true;
            this.radioButtonNumber.Text = "Numeric";
            this.radioButtonNumber.UseVisualStyleBackColor = true;
            this.radioButtonNumber.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonDateTime
            // 
            this.radioButtonDateTime.AutoSize = true;
            this.radioButtonDateTime.Location = new System.Drawing.Point(18, 40);
            this.radioButtonDateTime.Name = "radioButtonDateTime";
            this.radioButtonDateTime.Size = new System.Drawing.Size(74, 17);
            this.radioButtonDateTime.TabIndex = 1;
            this.radioButtonDateTime.Text = "Date Time";
            this.radioButtonDateTime.UseVisualStyleBackColor = true;
            this.radioButtonDateTime.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 202);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Format";
            // 
            // radioButtonDate
            // 
            this.radioButtonDate.AutoSize = true;
            this.radioButtonDate.Location = new System.Drawing.Point(18, 63);
            this.radioButtonDate.Name = "radioButtonDate";
            this.radioButtonDate.Size = new System.Drawing.Size(48, 17);
            this.radioButtonDate.TabIndex = 4;
            this.radioButtonDate.TabStop = true;
            this.radioButtonDate.Text = "Date";
            this.radioButtonDate.UseVisualStyleBackColor = true;
            this.radioButtonDate.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonTime
            // 
            this.radioButtonTime.AutoSize = true;
            this.radioButtonTime.Location = new System.Drawing.Point(18, 86);
            this.radioButtonTime.Name = "radioButtonTime";
            this.radioButtonTime.Size = new System.Drawing.Size(48, 17);
            this.radioButtonTime.TabIndex = 5;
            this.radioButtonTime.TabStop = true;
            this.radioButtonTime.Text = "Time";
            this.radioButtonTime.UseVisualStyleBackColor = true;
            this.radioButtonTime.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonTimeUTC
            // 
            this.radioButtonTimeUTC.AutoSize = true;
            this.radioButtonTimeUTC.Location = new System.Drawing.Point(18, 155);
            this.radioButtonTimeUTC.Name = "radioButtonTimeUTC";
            this.radioButtonTimeUTC.Size = new System.Drawing.Size(79, 17);
            this.radioButtonTimeUTC.TabIndex = 8;
            this.radioButtonTimeUTC.TabStop = true;
            this.radioButtonTimeUTC.Text = "Time (UTC)";
            this.radioButtonTimeUTC.UseVisualStyleBackColor = true;
            this.radioButtonTimeUTC.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonDateUTC
            // 
            this.radioButtonDateUTC.AutoSize = true;
            this.radioButtonDateUTC.Location = new System.Drawing.Point(18, 132);
            this.radioButtonDateUTC.Name = "radioButtonDateUTC";
            this.radioButtonDateUTC.Size = new System.Drawing.Size(79, 17);
            this.radioButtonDateUTC.TabIndex = 7;
            this.radioButtonDateUTC.TabStop = true;
            this.radioButtonDateUTC.Text = "Date (UTC)";
            this.radioButtonDateUTC.UseVisualStyleBackColor = true;
            this.radioButtonDateUTC.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonDateTimeUTC
            // 
            this.radioButtonDateTimeUTC.AutoSize = true;
            this.radioButtonDateTimeUTC.Location = new System.Drawing.Point(18, 109);
            this.radioButtonDateTimeUTC.Name = "radioButtonDateTimeUTC";
            this.radioButtonDateTimeUTC.Size = new System.Drawing.Size(105, 17);
            this.radioButtonDateTimeUTC.TabIndex = 6;
            this.radioButtonDateTimeUTC.Text = "Date Time (UTC)";
            this.radioButtonDateTimeUTC.UseVisualStyleBackColor = true;
            this.radioButtonDateTimeUTC.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // UserControlCoordinateIndication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioButtonTimeUTC);
            this.Controls.Add(this.radioButtonDateUTC);
            this.Controls.Add(this.radioButtonDateTimeUTC);
            this.Controls.Add(this.radioButtonTime);
            this.Controls.Add(this.radioButtonDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.radioButtonDateTime);
            this.Controls.Add(this.radioButtonNumber);
            this.Name = "UserControlCoordinateIndication";
            this.Size = new System.Drawing.Size(233, 241);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonNumber;
        private System.Windows.Forms.RadioButton radioButtonDateTime;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonDate;
        private System.Windows.Forms.RadioButton radioButtonTime;
        private System.Windows.Forms.RadioButton radioButtonTimeUTC;
        private System.Windows.Forms.RadioButton radioButtonDateUTC;
        private System.Windows.Forms.RadioButton radioButtonDateTimeUTC;
    }
}
