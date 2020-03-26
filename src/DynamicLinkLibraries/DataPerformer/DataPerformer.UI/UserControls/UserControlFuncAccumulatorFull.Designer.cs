namespace DataPerformer.UI.UserControls
{
    partial class UserControlFuncAccumulatorFull
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
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageParameters = new System.Windows.Forms.TabPage();
            this.tabPageBlocked = new System.Windows.Forms.TabPage();
            this.userControlEventBlock = new global::Event.UI.UserControls.UserControlEventBlock();
            this.userControlFuncAccumulator = new DataPerformer.UI.UserControls.UserControlFuncAccumulator();
            this.panelCenter.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageParameters.SuspendLayout();
            this.tabPageBlocked.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControl);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(150, 150);
            this.panelCenter.TabIndex = 20;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(150, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 150);
            this.panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 150);
            this.panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(150, 0);
            this.panelTop.TabIndex = 16;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 150);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(150, 0);
            this.panelBottom.TabIndex = 19;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageParameters);
            this.tabControl.Controls.Add(this.tabPageBlocked);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(150, 150);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageParameters
            // 
            this.tabPageParameters.Controls.Add(this.userControlFuncAccumulator);
            this.tabPageParameters.Location = new System.Drawing.Point(4, 22);
            this.tabPageParameters.Name = "tabPageParameters";
            this.tabPageParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParameters.Size = new System.Drawing.Size(142, 124);
            this.tabPageParameters.TabIndex = 0;
            this.tabPageParameters.Text = "Parameterts";
            this.tabPageParameters.UseVisualStyleBackColor = true;
            // 
            // tabPageBlocked
            // 
            this.tabPageBlocked.Controls.Add(this.userControlEventBlock);
            this.tabPageBlocked.Location = new System.Drawing.Point(4, 22);
            this.tabPageBlocked.Name = "tabPageBlocked";
            this.tabPageBlocked.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBlocked.Size = new System.Drawing.Size(142, 124);
            this.tabPageBlocked.TabIndex = 1;
            this.tabPageBlocked.Text = "Blocked events";
            this.tabPageBlocked.UseVisualStyleBackColor = true;
            // 
            // userControlEventBlock
            // 
            this.userControlEventBlock.Block = null;
            this.userControlEventBlock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlEventBlock.Location = new System.Drawing.Point(3, 3);
            this.userControlEventBlock.Name = "userControlEventBlock";
            this.userControlEventBlock.Size = new System.Drawing.Size(136, 118);
            this.userControlEventBlock.TabIndex = 0;
            // 
            // userControlFuncAccumulator
            // 
            this.userControlFuncAccumulator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlFuncAccumulator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlFuncAccumulator.Function = null;
            this.userControlFuncAccumulator.Location = new System.Drawing.Point(3, 3);
            this.userControlFuncAccumulator.Name = "userControlFuncAccumulator";
            this.userControlFuncAccumulator.Size = new System.Drawing.Size(136, 118);
            this.userControlFuncAccumulator.TabIndex = 0;
            // 
            // UserControlFuncAccumulatorFull
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlFuncAccumulatorFull";
            this.panelCenter.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageParameters.ResumeLayout(false);
            this.tabPageBlocked.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageParameters;
        private UserControlFuncAccumulator userControlFuncAccumulator;
        private System.Windows.Forms.TabPage tabPageBlocked;
        private global::Event.UI.UserControls.UserControlEventBlock userControlEventBlock;
    }
}
