namespace Event.UI.UserControls
{
    partial class UserControlWriter
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
            DataPerformer.Interfaces.IDataConsumer cons = writer;
            cons.OnChangeInput -= FillAndSelect;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlWriter));
            this.panelCenterMain = new System.Windows.Forms.Panel();
            this.panelCenter1 = new System.Windows.Forms.Panel();
            this.panelList = new System.Windows.Forms.Panel();
            this.userControlComboboxList = new Diagram.UI.UserControls.UserControlComboboxList();
            this.panelRight1 = new System.Windows.Forms.Panel();
            this.panelLeft1 = new System.Windows.Forms.Panel();
            this.panelTop1 = new System.Windows.Forms.Panel();
            this.panelCenterNum = new System.Windows.Forms.Panel();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panelRightNum = new System.Windows.Forms.Panel();
            this.panelLeftNum = new System.Windows.Forms.Panel();
            this.labelNumber = new System.Windows.Forms.Label();
            this.panelTopNum = new System.Windows.Forms.Panel();
            this.panelBottomNum = new System.Windows.Forms.Panel();
            this.panelBottom1 = new System.Windows.Forms.Panel();
            this.panelRightMain = new System.Windows.Forms.Panel();
            this.panelLeftMain = new System.Windows.Forms.Panel();
            this.panelTopMain = new System.Windows.Forms.Panel();
            this.panelCenterCond = new System.Windows.Forms.Panel();
            this.comboBoxCond = new System.Windows.Forms.ComboBox();
            this.panelRightCond = new System.Windows.Forms.Panel();
            this.panelLeftCond = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTopCond = new System.Windows.Forms.Panel();
            this.panelBottomCond = new System.Windows.Forms.Panel();
            this.panelBottomMain = new System.Windows.Forms.Panel();
            this.panelCenterMain.SuspendLayout();
            this.panelCenter1.SuspendLayout();
            this.panelList.SuspendLayout();
            this.panelTop1.SuspendLayout();
            this.panelCenterNum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.panelLeftNum.SuspendLayout();
            this.panelTopMain.SuspendLayout();
            this.panelCenterCond.SuspendLayout();
            this.panelLeftCond.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenterMain
            // 
            this.panelCenterMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCenterMain.Controls.Add(this.panelCenter1);
            this.panelCenterMain.Controls.Add(this.panelRight1);
            this.panelCenterMain.Controls.Add(this.panelLeft1);
            this.panelCenterMain.Controls.Add(this.panelTop1);
            this.panelCenterMain.Controls.Add(this.panelBottom1);
            this.panelCenterMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterMain.Location = new System.Drawing.Point(0, 23);
            this.panelCenterMain.Name = "panelCenterMain";
            this.panelCenterMain.Size = new System.Drawing.Size(366, 187);
            this.panelCenterMain.TabIndex = 20;
            // 
            // panelCenter1
            // 
            this.panelCenter1.AutoScroll = true;
            this.panelCenter1.Controls.Add(this.panelList);
            this.panelCenter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter1.Location = new System.Drawing.Point(0, 26);
            this.panelCenter1.Name = "panelCenter1";
            this.panelCenter1.Size = new System.Drawing.Size(364, 159);
            this.panelCenter1.TabIndex = 20;
            // 
            // panelList
            // 
            this.panelList.AutoScroll = true;
            this.panelList.Controls.Add(this.userControlComboboxList);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(0, 0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(364, 159);
            this.panelList.TabIndex = 0;
            // 
            // userControlComboboxList
            // 
            this.userControlComboboxList.Count = 1;
            this.userControlComboboxList.Dictionary = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("userControlComboboxList.Dictionary")));
            this.userControlComboboxList.Dock = System.Windows.Forms.DockStyle.Top;
            this.userControlComboboxList.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userControlComboboxList.Location = new System.Drawing.Point(0, 0);
            this.userControlComboboxList.Name = "userControlComboboxList";
            this.userControlComboboxList.Size = new System.Drawing.Size(364, 54);
            this.userControlComboboxList.TabIndex = 0;
            this.userControlComboboxList.Texts = new string[] {
        "Text"};
            // 
            // panelRight1
            // 
            this.panelRight1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight1.Location = new System.Drawing.Point(364, 26);
            this.panelRight1.Name = "panelRight1";
            this.panelRight1.Size = new System.Drawing.Size(0, 159);
            this.panelRight1.TabIndex = 18;
            // 
            // panelLeft1
            // 
            this.panelLeft1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft1.Location = new System.Drawing.Point(0, 26);
            this.panelLeft1.Name = "panelLeft1";
            this.panelLeft1.Size = new System.Drawing.Size(0, 159);
            this.panelLeft1.TabIndex = 17;
            // 
            // panelTop1
            // 
            this.panelTop1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop1.Controls.Add(this.panelCenterNum);
            this.panelTop1.Controls.Add(this.panelRightNum);
            this.panelTop1.Controls.Add(this.panelLeftNum);
            this.panelTop1.Controls.Add(this.panelTopNum);
            this.panelTop1.Controls.Add(this.panelBottomNum);
            this.panelTop1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop1.Location = new System.Drawing.Point(0, 0);
            this.panelTop1.Name = "panelTop1";
            this.panelTop1.Size = new System.Drawing.Size(364, 26);
            this.panelTop1.TabIndex = 16;
            // 
            // panelCenterNum
            // 
            this.panelCenterNum.Controls.Add(this.numericUpDown);
            this.panelCenterNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterNum.Location = new System.Drawing.Point(128, 0);
            this.panelCenterNum.Name = "panelCenterNum";
            this.panelCenterNum.Size = new System.Drawing.Size(234, 24);
            this.panelCenterNum.TabIndex = 20;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown.Location = new System.Drawing.Point(0, 0);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(234, 20);
            this.numericUpDown.TabIndex = 0;
            // 
            // panelRightNum
            // 
            this.panelRightNum.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightNum.Location = new System.Drawing.Point(362, 0);
            this.panelRightNum.Name = "panelRightNum";
            this.panelRightNum.Size = new System.Drawing.Size(0, 24);
            this.panelRightNum.TabIndex = 18;
            // 
            // panelLeftNum
            // 
            this.panelLeftNum.Controls.Add(this.labelNumber);
            this.panelLeftNum.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftNum.Location = new System.Drawing.Point(0, 0);
            this.panelLeftNum.Name = "panelLeftNum";
            this.panelLeftNum.Size = new System.Drawing.Size(128, 24);
            this.panelLeftNum.TabIndex = 17;
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(3, 2);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(111, 13);
            this.labelNumber.TabIndex = 0;
            this.labelNumber.Text = "Number of parameters";
            // 
            // panelTopNum
            // 
            this.panelTopNum.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopNum.Location = new System.Drawing.Point(0, 0);
            this.panelTopNum.Name = "panelTopNum";
            this.panelTopNum.Size = new System.Drawing.Size(362, 0);
            this.panelTopNum.TabIndex = 16;
            // 
            // panelBottomNum
            // 
            this.panelBottomNum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomNum.Location = new System.Drawing.Point(0, 24);
            this.panelBottomNum.Name = "panelBottomNum";
            this.panelBottomNum.Size = new System.Drawing.Size(362, 0);
            this.panelBottomNum.TabIndex = 19;
            // 
            // panelBottom1
            // 
            this.panelBottom1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom1.Location = new System.Drawing.Point(0, 185);
            this.panelBottom1.Name = "panelBottom1";
            this.panelBottom1.Size = new System.Drawing.Size(364, 0);
            this.panelBottom1.TabIndex = 19;
            // 
            // panelRightMain
            // 
            this.panelRightMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightMain.Location = new System.Drawing.Point(366, 23);
            this.panelRightMain.Name = "panelRightMain";
            this.panelRightMain.Size = new System.Drawing.Size(0, 187);
            this.panelRightMain.TabIndex = 18;
            // 
            // panelLeftMain
            // 
            this.panelLeftMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftMain.Location = new System.Drawing.Point(0, 23);
            this.panelLeftMain.Name = "panelLeftMain";
            this.panelLeftMain.Size = new System.Drawing.Size(0, 187);
            this.panelLeftMain.TabIndex = 17;
            // 
            // panelTopMain
            // 
            this.panelTopMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopMain.Controls.Add(this.panelCenterCond);
            this.panelTopMain.Controls.Add(this.panelRightCond);
            this.panelTopMain.Controls.Add(this.panelLeftCond);
            this.panelTopMain.Controls.Add(this.panelTopCond);
            this.panelTopMain.Controls.Add(this.panelBottomCond);
            this.panelTopMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopMain.Location = new System.Drawing.Point(0, 0);
            this.panelTopMain.Name = "panelTopMain";
            this.panelTopMain.Size = new System.Drawing.Size(366, 23);
            this.panelTopMain.TabIndex = 16;
            // 
            // panelCenterCond
            // 
            this.panelCenterCond.Controls.Add(this.comboBoxCond);
            this.panelCenterCond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterCond.Location = new System.Drawing.Point(128, 0);
            this.panelCenterCond.Name = "panelCenterCond";
            this.panelCenterCond.Size = new System.Drawing.Size(226, 21);
            this.panelCenterCond.TabIndex = 20;
            // 
            // comboBoxCond
            // 
            this.comboBoxCond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxCond.FormattingEnabled = true;
            this.comboBoxCond.Location = new System.Drawing.Point(0, 0);
            this.comboBoxCond.Name = "comboBoxCond";
            this.comboBoxCond.Size = new System.Drawing.Size(226, 21);
            this.comboBoxCond.TabIndex = 0;
            // 
            // panelRightCond
            // 
            this.panelRightCond.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightCond.Location = new System.Drawing.Point(354, 0);
            this.panelRightCond.Name = "panelRightCond";
            this.panelRightCond.Size = new System.Drawing.Size(10, 21);
            this.panelRightCond.TabIndex = 18;
            // 
            // panelLeftCond
            // 
            this.panelLeftCond.Controls.Add(this.label1);
            this.panelLeftCond.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftCond.Location = new System.Drawing.Point(0, 0);
            this.panelLeftCond.Name = "panelLeftCond";
            this.panelLeftCond.Size = new System.Drawing.Size(128, 21);
            this.panelLeftCond.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Condition";
            // 
            // panelTopCond
            // 
            this.panelTopCond.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopCond.Location = new System.Drawing.Point(0, 0);
            this.panelTopCond.Name = "panelTopCond";
            this.panelTopCond.Size = new System.Drawing.Size(364, 0);
            this.panelTopCond.TabIndex = 16;
            // 
            // panelBottomCond
            // 
            this.panelBottomCond.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomCond.Location = new System.Drawing.Point(0, 21);
            this.panelBottomCond.Name = "panelBottomCond";
            this.panelBottomCond.Size = new System.Drawing.Size(364, 0);
            this.panelBottomCond.TabIndex = 19;
            // 
            // panelBottomMain
            // 
            this.panelBottomMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomMain.Location = new System.Drawing.Point(0, 210);
            this.panelBottomMain.Name = "panelBottomMain";
            this.panelBottomMain.Size = new System.Drawing.Size(366, 0);
            this.panelBottomMain.TabIndex = 19;
            // 
            // UserControlWriter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenterMain);
            this.Controls.Add(this.panelRightMain);
            this.Controls.Add(this.panelLeftMain);
            this.Controls.Add(this.panelTopMain);
            this.Controls.Add(this.panelBottomMain);
            this.Name = "UserControlWriter";
            this.Size = new System.Drawing.Size(366, 210);
            this.panelCenterMain.ResumeLayout(false);
            this.panelCenter1.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.panelTop1.ResumeLayout(false);
            this.panelCenterNum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.panelLeftNum.ResumeLayout(false);
            this.panelLeftNum.PerformLayout();
            this.panelTopMain.ResumeLayout(false);
            this.panelCenterCond.ResumeLayout(false);
            this.panelLeftCond.ResumeLayout(false);
            this.panelLeftCond.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenterMain;
        private System.Windows.Forms.Panel panelRightMain;
        private System.Windows.Forms.Panel panelLeftMain;
        private System.Windows.Forms.Panel panelTopMain;
        private System.Windows.Forms.Panel panelBottomMain;
        private System.Windows.Forms.Panel panelCenterCond;
        private System.Windows.Forms.ComboBox comboBoxCond;
        private System.Windows.Forms.Panel panelRightCond;
        private System.Windows.Forms.Panel panelLeftCond;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTopCond;
        private System.Windows.Forms.Panel panelBottomCond;
        private System.Windows.Forms.Panel panelCenter1;
        private System.Windows.Forms.Panel panelRight1;
        private System.Windows.Forms.Panel panelLeft1;
        private System.Windows.Forms.Panel panelTop1;
        private System.Windows.Forms.Panel panelBottom1;
        private System.Windows.Forms.Panel panelCenterNum;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Panel panelRightNum;
        private System.Windows.Forms.Panel panelLeftNum;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Panel panelTopNum;
        private System.Windows.Forms.Panel panelBottomNum;
        private System.Windows.Forms.Panel panelList;
        private Diagram.UI.UserControls.UserControlComboboxList userControlComboboxList;
    }
}
