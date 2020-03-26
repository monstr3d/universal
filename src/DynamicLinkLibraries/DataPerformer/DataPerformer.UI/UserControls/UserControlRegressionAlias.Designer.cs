namespace DataPerformer.UI.UserControls
{
    partial class UserControlRegressionAlias
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
            this.comboBoxParameter = new System.Windows.Forms.ComboBox();
            this.LabelDelta = new System.Windows.Forms.Label();
            this.textBoxDelta = new System.Windows.Forms.TextBox();
            this.labelSigma = new System.Windows.Forms.Label();
            this.labelParameter = new System.Windows.Forms.Label();
            this.textBoxSigma = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxParameter
            // 
            this.comboBoxParameter.FormattingEnabled = true;
            this.comboBoxParameter.Location = new System.Drawing.Point(18, 25);
            this.comboBoxParameter.Name = "comboBoxParameter";
            this.comboBoxParameter.Size = new System.Drawing.Size(252, 21);
            this.comboBoxParameter.TabIndex = 0;
            // 
            // LabelDelta
            // 
            this.LabelDelta.AutoSize = true;
            this.LabelDelta.Location = new System.Drawing.Point(15, 49);
            this.LabelDelta.Name = "LabelDelta";
            this.LabelDelta.Size = new System.Drawing.Size(32, 13);
            this.LabelDelta.TabIndex = 1;
            this.LabelDelta.Text = "Delta";
            // 
            // textBoxDelta
            // 
            this.textBoxDelta.Location = new System.Drawing.Point(18, 65);
            this.textBoxDelta.Name = "textBoxDelta";
            this.textBoxDelta.Size = new System.Drawing.Size(100, 20);
            this.textBoxDelta.TabIndex = 2;
            // 
            // labelSigma
            // 
            this.labelSigma.AutoSize = true;
            this.labelSigma.Location = new System.Drawing.Point(15, 88);
            this.labelSigma.Name = "labelSigma";
            this.labelSigma.Size = new System.Drawing.Size(36, 13);
            this.labelSigma.TabIndex = 3;
            this.labelSigma.Text = "Sigma";
            // 
            // labelParameter
            // 
            this.labelParameter.AutoSize = true;
            this.labelParameter.Location = new System.Drawing.Point(15, 9);
            this.labelParameter.Name = "labelParameter";
            this.labelParameter.Size = new System.Drawing.Size(55, 13);
            this.labelParameter.TabIndex = 4;
            this.labelParameter.Text = "Parameter";
            // 
            // textBoxSigma
            // 
            this.textBoxSigma.Location = new System.Drawing.Point(18, 104);
            this.textBoxSigma.Name = "textBoxSigma";
            this.textBoxSigma.Size = new System.Drawing.Size(100, 20);
            this.textBoxSigma.TabIndex = 5;
            // 
            // UserControlRegressionAlias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxSigma);
            this.Controls.Add(this.labelParameter);
            this.Controls.Add(this.labelSigma);
            this.Controls.Add(this.textBoxDelta);
            this.Controls.Add(this.LabelDelta);
            this.Controls.Add(this.comboBoxParameter);
            this.Name = "UserControlRegressionAlias";
            this.Size = new System.Drawing.Size(305, 139);
            this.Resize += new System.EventHandler(this.UserControlRegressionAlias_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxParameter;
        private System.Windows.Forms.Label LabelDelta;
        private System.Windows.Forms.TextBox textBoxDelta;
        private System.Windows.Forms.Label labelSigma;
        private System.Windows.Forms.Label labelParameter;
        private System.Windows.Forms.TextBox textBoxSigma;
    }
}
