namespace DataPerformer.UI.Forms
{
    partial class FormKalmanFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKalmanFilter));
            this.userControlKalmanFilter = new DataPerformer.UI.UserControls.UserControlKalmanFilter();
            this.SuspendLayout();
            // 
            // userControlKalmanFilter
            // 
            this.userControlKalmanFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlKalmanFilter.Filter = null;
            this.userControlKalmanFilter.Location = new System.Drawing.Point(0, 0);
            this.userControlKalmanFilter.Name = "userControlKalmanFilter";
            this.userControlKalmanFilter.Size = new System.Drawing.Size(447, 346);
            this.userControlKalmanFilter.TabIndex = 0;
            // 
            // FormKalmanFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 346);
            this.Controls.Add(this.userControlKalmanFilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormKalmanFilter";
            this.Text = "FormKalmanFilter";
            this.ResumeLayout(false);

        }

        #endregion

        private DataPerformer.UI.UserControls.UserControlKalmanFilter userControlKalmanFilter;
    }
}