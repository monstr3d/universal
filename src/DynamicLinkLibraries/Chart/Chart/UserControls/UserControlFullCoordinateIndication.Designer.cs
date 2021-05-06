namespace Chart.UserControls
{
    partial class UserControlFullCoordinateIndication
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userControlCoordinateIndicationHorizontal = new Chart.UserControls.UserControlCoordinateIndication();
            this.userControlCoordinateIndicationVertical = new Chart.UserControls.UserControlCoordinateIndication();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X - axis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y - axis";
            // 
            // userControlCoordinateIndicationHorizontal
            // 
            this.userControlCoordinateIndicationHorizontal.Horizontal = true;
            this.userControlCoordinateIndicationHorizontal.Location = new System.Drawing.Point(3, 35);
            this.userControlCoordinateIndicationHorizontal.Name = "userControlCoordinateIndicationHorizontal";
            this.userControlCoordinateIndicationHorizontal.Performer = null;
            this.userControlCoordinateIndicationHorizontal.Size = new System.Drawing.Size(233, 238);
            this.userControlCoordinateIndicationHorizontal.TabIndex = 4;
            // 
            // userControlCoordinateIndicationVertical
            // 
            this.userControlCoordinateIndicationVertical.Horizontal = false;
            this.userControlCoordinateIndicationVertical.Location = new System.Drawing.Point(259, 35);
            this.userControlCoordinateIndicationVertical.Name = "userControlCoordinateIndicationVertical";
            this.userControlCoordinateIndicationVertical.Performer = null;
            this.userControlCoordinateIndicationVertical.Size = new System.Drawing.Size(233, 238);
            this.userControlCoordinateIndicationVertical.TabIndex = 5;
            // 
            // UserControlFullCoordinateIndication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControlCoordinateIndicationVertical);
            this.Controls.Add(this.userControlCoordinateIndicationHorizontal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UserControlFullCoordinateIndication";
            this.Size = new System.Drawing.Size(495, 286);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private UserControlCoordinateIndication userControlCoordinateIndicationHorizontal;
        private UserControlCoordinateIndication userControlCoordinateIndicationVertical;
    }
}
