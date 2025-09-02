namespace Chart.UserControls
{
    partial class UserControlFilledChart
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
            userControlChart = new UserControlChart();
            SuspendLayout();
            // 
            // userControlChart
            // 
            userControlChart.Coordinator = null;
            userControlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlChart.IsBlocked = true;
            userControlChart.Location = new System.Drawing.Point(0, 0);
            userControlChart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            userControlChart.Name = "userControlChart";
            userControlChart.Size = new System.Drawing.Size(316, 251);
            userControlChart.TabIndex = 0;
            // 
            // UserControlFilledChart
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(userControlChart);
            Name = "UserControlFilledChart";
            Size = new System.Drawing.Size(316, 251);
            ResumeLayout(false);
        }

        #endregion

        private UserControlChart userControlChart;
    }
}
