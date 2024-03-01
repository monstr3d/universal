namespace DataPerformer.UI.Forms
{
    partial class FormMultiGraph
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
            panelCenter = new System.Windows.Forms.Panel();
            userControlMultiGraph = new UserControls.UserControlMultiGraph();
            panelRight = new System.Windows.Forms.Panel();
            panelLeft = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            panelCenter.SuspendLayout();
            SuspendLayout();
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(userControlMultiGraph);
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(0, 0);
            panelCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(800, 450);
            panelCenter.TabIndex = 20;
            // 
            // userControlMultiGraph
            // 
            userControlMultiGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            userControlMultiGraph.Location = new System.Drawing.Point(0, 0);
            userControlMultiGraph.Name = "userControlMultiGraph";
            userControlMultiGraph.Size = new System.Drawing.Size(800, 450);
            userControlMultiGraph.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(800, 0);
            panelRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(0, 450);
            panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 0);
            panelLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(0, 450);
            panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(800, 0);
            panelTop.TabIndex = 16;
            // 
            // panelBottom
            // 
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 450);
            panelBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(800, 0);
            panelBottom.TabIndex = 19;
            // 
            // FormMultiGraph
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(panelCenter);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Name = "FormMultiGraph";
            Text = "FormMultiGraph";
            Load += FormMultiGraph_Load;
            panelCenter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private UserControls.UserControlMultiGraph userControlMultiGraph;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
    }
}