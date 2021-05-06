namespace Chart.UserControls
{
    partial class UserControlExternalChart
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
            this.SuspendLayout();
            // 
            // userControlControlInternalChart
            // 
            this.userControlControlInternalChart = new UserControlControlInternalChart();
            this.userControlControlInternalChart.Location = new System.Drawing.Point(18, 3);
            this.userControlControlInternalChart.Name = "userControlControlInternalChart";
            this.userControlControlInternalChart.Size = new System.Drawing.Size(124, 118);
            this.userControlControlInternalChart.TabIndex = 0;
            // 
            // UserControlExternalChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControlControlInternalChart);
            this.Name = "UserControlExternalChart";
            this.Size = new System.Drawing.Size(165, 140);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlControlInternalChart userControlControlInternalChart;

    }
}
