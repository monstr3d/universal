namespace Trading.Library.Forms.UserControls
{
    partial class UserControlOrderChart
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
            splitContainerLeft = new System.Windows.Forms.SplitContainer();
            panelChartParent = new System.Windows.Forms.Panel();
            panelChartChild = new WindowsExtensions.WheelessPanel();
            userControlChartLeft = new UserControlChartLeft();
            panelLeftCenter = new System.Windows.Forms.Panel();
            userControlMeasurementCollection = new DataPerformer.UI.UserControls.UserControlMeasurementCollection();
            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            panelLeftTop = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            panel5 = new System.Windows.Forms.Panel();
            panelRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerLeft).BeginInit();
            splitContainerLeft.Panel1.SuspendLayout();
            splitContainerLeft.Panel2.SuspendLayout();
            splitContainerLeft.SuspendLayout();
            panelChartParent.SuspendLayout();
            panelChartChild.SuspendLayout();
            panelLeftCenter.SuspendLayout();
            panelLeftTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(splitContainerLeft);
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(0, 0);
            panelCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(580, 442);
            panelCenter.TabIndex = 20;
            // 
            // splitContainerLeft
            // 
            splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerLeft.Location = new System.Drawing.Point(0, 0);
            splitContainerLeft.Name = "splitContainerLeft";
            // 
            // splitContainerLeft.Panel1
            // 
            splitContainerLeft.Panel1.Controls.Add(panelChartParent);
            // 
            // splitContainerLeft.Panel2
            // 
            splitContainerLeft.Panel2.Controls.Add(panelLeftCenter);
            splitContainerLeft.Panel2.Controls.Add(panel2);
            splitContainerLeft.Panel2.Controls.Add(panel3);
            splitContainerLeft.Panel2.Controls.Add(panelLeftTop);
            splitContainerLeft.Panel2.Controls.Add(panel5);
            splitContainerLeft.Size = new System.Drawing.Size(580, 442);
            splitContainerLeft.SplitterDistance = 429;
            splitContainerLeft.TabIndex = 0;
            // 
            // panelChartParent
            // 
            panelChartParent.Controls.Add(panelChartChild);
            panelChartParent.Dock = System.Windows.Forms.DockStyle.Fill;
            panelChartParent.Location = new System.Drawing.Point(0, 0);
            panelChartParent.Name = "panelChartParent";
            panelChartParent.Size = new System.Drawing.Size(429, 442);
            panelChartParent.TabIndex = 0;
            panelChartParent.Resize += panelChartParent_Resize;
            // 
            // panelChartChild
            // 
            panelChartChild.AutoScroll = true;
            panelChartChild.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelChartChild.Controls.Add(userControlChartLeft);
            panelChartChild.Location = new System.Drawing.Point(0, 0);
            panelChartChild.MaximumSize = new System.Drawing.Size(50000, 50000);
            panelChartChild.Name = "panelChartChild";
            panelChartChild.ResizeType = WindowsExtensions.ResizeType.Horizontal;
            panelChartChild.Size = new System.Drawing.Size(371, 0);
            panelChartChild.Step = 0.5F;
            panelChartChild.TabIndex = 0;
            // 
            // userControlChartLeft
            // 
            userControlChartLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlChartLeft.Location = new System.Drawing.Point(0, 0);
            userControlChartLeft.MaximumSize = new System.Drawing.Size(10000, 10000);
            userControlChartLeft.Name = "userControlChartLeft";
            userControlChartLeft.Size = new System.Drawing.Size(371, 0);
            userControlChartLeft.TabIndex = 0;
            // 
            // panelLeftCenter
            // 
            panelLeftCenter.Controls.Add(userControlMeasurementCollection);
            panelLeftCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelLeftCenter.Location = new System.Drawing.Point(0, 38);
            panelLeftCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelLeftCenter.Name = "panelLeftCenter";
            panelLeftCenter.Size = new System.Drawing.Size(147, 404);
            panelLeftCenter.TabIndex = 20;
            // 
            // userControlMeasurementCollection
            // 
            userControlMeasurementCollection.AutoScroll = true;
            userControlMeasurementCollection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            userControlMeasurementCollection.DataConsumer = null;
            userControlMeasurementCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlMeasurementCollection.Location = new System.Drawing.Point(0, 0);
            userControlMeasurementCollection.Name = "userControlMeasurementCollection";
            userControlMeasurementCollection.Size = new System.Drawing.Size(147, 404);
            userControlMeasurementCollection.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Right;
            panel2.Location = new System.Drawing.Point(147, 38);
            panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(0, 404);
            panel2.TabIndex = 18;
            // 
            // panel3
            // 
            panel3.Dock = System.Windows.Forms.DockStyle.Left;
            panel3.Location = new System.Drawing.Point(0, 38);
            panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(0, 404);
            panel3.TabIndex = 17;
            // 
            // panelLeftTop
            // 
            panelLeftTop.Controls.Add(label1);
            panelLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelLeftTop.Location = new System.Drawing.Point(0, 0);
            panelLeftTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelLeftTop.Name = "panelLeftTop";
            panelLeftTop.Size = new System.Drawing.Size(147, 38);
            panelLeftTop.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(24, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Input Data";
            // 
            // panel5
            // 
            panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel5.Location = new System.Drawing.Point(0, 442);
            panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(147, 0);
            panel5.TabIndex = 19;
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(580, 0);
            panelRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(0, 442);
            panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 0);
            panelLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(0, 442);
            panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(580, 0);
            panelTop.TabIndex = 16;
            // 
            // panelBottom
            // 
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 442);
            panelBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(580, 0);
            panelBottom.TabIndex = 19;
            // 
            // UserControlOrderChart
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelCenter);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Name = "UserControlOrderChart";
            Size = new System.Drawing.Size(580, 442);
            panelCenter.ResumeLayout(false);
            splitContainerLeft.Panel1.ResumeLayout(false);
            splitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerLeft).EndInit();
            splitContainerLeft.ResumeLayout(false);
            panelChartParent.ResumeLayout(false);
            panelChartChild.ResumeLayout(false);
            panelLeftCenter.ResumeLayout(false);
            panelLeftTop.ResumeLayout(false);
            panelLeftTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelLeftCenter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelLeftTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private DataPerformer.UI.UserControls.UserControlMeasurementCollection userControlMeasurementCollection;
        private System.Windows.Forms.SplitContainer splitContainerLeft;
        private System.Windows.Forms.Panel panelChartParent;
        private WindowsExtensions.WheelessPanel panelChartChild;
        private UserControlChartLeft userControlChartLeft;
    }
}
