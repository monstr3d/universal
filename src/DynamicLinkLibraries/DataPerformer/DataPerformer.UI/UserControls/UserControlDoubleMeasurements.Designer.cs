namespace DataPerformer.UI.UserControls
{
    partial class UserControlDoubleMeasurements
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
            panelCenter = new System.Windows.Forms.Panel();
            tabControl = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            userControlMeasurements1 = new UserControlMeasurementCollection();
            tabPage2 = new System.Windows.Forms.TabPage();
            userControlMeasurements2 = new UserControlMeasurementCollection();
            panelRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            panelCenter.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(tabControl);
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(0, 0);
            panelCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(442, 405);
            panelCenter.TabIndex = 20;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.Location = new System.Drawing.Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(442, 405);
            tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(userControlMeasurements1);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(434, 377);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Chart 1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // userControlMeasurements1
            // 
            userControlMeasurements1.AutoScroll = true;
            userControlMeasurements1.DataConsumer = null;
            userControlMeasurements1.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlMeasurements1.Location = new System.Drawing.Point(3, 3);
            userControlMeasurements1.Name = "userControlMeasurements1";
            userControlMeasurements1.Size = new System.Drawing.Size(428, 371);
            userControlMeasurements1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(userControlMeasurements2);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(434, 377);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Chart 2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // userControlMeasurements2
            // 
            userControlMeasurements2.AutoScroll = true;
            userControlMeasurements2.DataConsumer = null;
            userControlMeasurements2.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlMeasurements2.Location = new System.Drawing.Point(3, 3);
            userControlMeasurements2.Name = "userControlMeasurements2";
            userControlMeasurements2.Size = new System.Drawing.Size(428, 371);
            userControlMeasurements2.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(442, 0);
            panelRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(0, 405);
            panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 0);
            panelLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(0, 405);
            panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(442, 0);
            panelTop.TabIndex = 16;
            // 
            // panelBottom
            // 
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 405);
            panelBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(442, 0);
            panelBottom.TabIndex = 19;
            // 
            // UserControlDoubleMeasurements
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelCenter);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Name = "UserControlDoubleMeasurements";
            Size = new System.Drawing.Size(442, 405);
            panelCenter.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private UserControlMeasurementCollection userControlMeasurements1;
        private System.Windows.Forms.TabPage tabPage2;
        private UserControlMeasurementCollection userControlMeasurements2;
    }
}
