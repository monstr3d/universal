namespace Trading.Library.Forms.UserControls
{
    partial class UserControlChartLeft
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
            panelCenter = new System.Windows.Forms.Panel();
            panelChart = new System.Windows.Forms.Panel();
            splitContainer = new System.Windows.Forms.SplitContainer();
            userControlChartBig = new Chart.UserControls.UserControlChart();
            panelRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            userControlChartLittle = new Chart.UserControls.UserControlChart();
            panelCenter.SuspendLayout();
            panelChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // panelCenter
            // 
             panelCenter.Controls.Add(panelChart);
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(0, 0);
            panelCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(653, 409);
            panelCenter.TabIndex = 20;
            panelCenter.Resize += panelCenter_Resize;
            // 
            // panelChart
            // 
            panelChart.Controls.Add(splitContainer);
            panelChart.Location = new System.Drawing.Point(0, 0);
            panelChart.Name = "panelChart";
            panelChart.Size = new System.Drawing.Size(636, 397);
            panelChart.TabIndex = 0;
            // 
            // splitContainer
            // 
            splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer.Location = new System.Drawing.Point(0, 0);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(userControlChartBig);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(userControlChartLittle);
            splitContainer.Size = new System.Drawing.Size(636, 397);
            splitContainer.SplitterDistance = 295;
            splitContainer.TabIndex = 0;
            // 
            // userControlChartBig
            // 
            userControlChartBig.Coordinator = null;
            userControlChartBig.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlChartBig.IsBlocked = true;
            userControlChartBig.Location = new System.Drawing.Point(0, 0);
            userControlChartBig.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            userControlChartBig.Name = "userControlChartBig";
            userControlChartBig.Size = new System.Drawing.Size(636, 295);
            userControlChartBig.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(653, 0);
            panelRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(0, 409);
            panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 0);
            panelLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(0, 409);
            panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(653, 0);
            panelTop.TabIndex = 16;
            // 
            // panelBottom
            // 
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 409);
            panelBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(653, 0);
            panelBottom.TabIndex = 19;
            // 
            // userControlChartLittle
            // 
            userControlChartLittle.Coordinator = null;
            userControlChartLittle.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlChartLittle.IsBlocked = true;
            userControlChartLittle.Location = new System.Drawing.Point(0, 0);
            userControlChartLittle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            userControlChartLittle.Name = "userControlChartLittle";
            userControlChartLittle.Size = new System.Drawing.Size(636, 98);
            userControlChartLittle.TabIndex = 0;
            // 
            // UserControlChartLeft
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelCenter);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Name = "UserControlChartLeft";
            Size = new System.Drawing.Size(653, 409);
            panelCenter.ResumeLayout(false);
            panelChart.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Chart.UserControls.UserControlChart userControlChartBig;
        private Chart.UserControls.UserControlChart userControlChartLittle;
    }
}
