namespace Motion6D.UI
{
    partial class FormAggregateLink
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAggregateLink));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxParent = new System.Windows.Forms.PictureBox();
            this.pictureBoxChild = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownParent = new System.Windows.Forms.NumericUpDown();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.numericUpDownChild = new System.Windows.Forms.NumericUpDown();
            this.labelP = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChild)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Child";
            // 
            // pictureBoxParent
            // 
            this.pictureBoxParent.Location = new System.Drawing.Point(45, 63);
            this.pictureBoxParent.Name = "pictureBoxParent";
            this.pictureBoxParent.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxParent.TabIndex = 2;
            this.pictureBoxParent.TabStop = false;
            // 
            // pictureBoxChild
            // 
            this.pictureBoxChild.Location = new System.Drawing.Point(45, 165);
            this.pictureBoxChild.Name = "pictureBoxChild";
            this.pictureBoxChild.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxChild.TabIndex = 3;
            this.pictureBoxChild.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Connection number";
            // 
            // numericUpDownParent
            // 
            this.numericUpDownParent.Location = new System.Drawing.Point(222, 63);
            this.numericUpDownParent.Name = "numericUpDownParent";
            this.numericUpDownParent.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownParent.TabIndex = 5;
            this.numericUpDownParent.ValueChanged += new System.EventHandler(this.numericUpDownParent_ValueChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // numericUpDownChild
            // 
            this.numericUpDownChild.Location = new System.Drawing.Point(222, 165);
            this.numericUpDownChild.Name = "numericUpDownChild";
            this.numericUpDownChild.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownChild.TabIndex = 6;
            this.numericUpDownChild.ValueChanged += new System.EventHandler(this.numericUpDownChild_ValueChanged);
            // 
            // labelP
            // 
            this.labelP.AutoSize = true;
            this.labelP.Location = new System.Drawing.Point(45, 47);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(35, 13);
            this.labelP.TabIndex = 7;
            this.labelP.Text = "label4";
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(45, 149);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(35, 13);
            this.labelC.TabIndex = 8;
            this.labelC.Text = "label4";
            // 
            // FormAggregateLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 254);
            this.Controls.Add(this.labelC);
            this.Controls.Add(this.labelP);
            this.Controls.Add(this.numericUpDownChild);
            this.Controls.Add(this.numericUpDownParent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBoxChild);
            this.Controls.Add(this.pictureBoxParent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAggregateLink";
            this.Text = "FormAggregateLink";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChild)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxParent;
        private System.Windows.Forms.PictureBox pictureBoxChild;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownParent;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.NumericUpDown numericUpDownChild;
        private System.Windows.Forms.Label labelP;
        private System.Windows.Forms.Label labelC;
    }
}