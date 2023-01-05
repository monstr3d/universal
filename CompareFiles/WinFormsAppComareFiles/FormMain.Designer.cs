namespace WinFormsAppComareFiles
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSource = new System.Windows.Forms.Button();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.buttonTarget = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.openFileDialogSource = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogTarget = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // buttonSource
            // 
            this.buttonSource.Location = new System.Drawing.Point(698, 52);
            this.buttonSource.Name = "buttonSource";
            this.buttonSource.Size = new System.Drawing.Size(75, 23);
            this.buttonSource.TabIndex = 0;
            this.buttonSource.Text = "Browse...";
            this.buttonSource.UseVisualStyleBackColor = true;
            this.buttonSource.Click += new System.EventHandler(this.buttonSource_Click);
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(12, 52);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(662, 25);
            this.textBoxSource.TabIndex = 1;
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Location = new System.Drawing.Point(12, 114);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(662, 25);
            this.textBoxDestination.TabIndex = 2;
            // 
            // buttonTarget
            // 
            this.buttonTarget.Location = new System.Drawing.Point(698, 114);
            this.buttonTarget.Name = "buttonTarget";
            this.buttonTarget.Size = new System.Drawing.Size(75, 23);
            this.buttonTarget.TabIndex = 3;
            this.buttonTarget.Text = "Browse...";
            this.buttonTarget.UseVisualStyleBackColor = true;
            this.buttonTarget.Click += new System.EventHandler(this.buttonTarget_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(48, 198);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 17);
            this.labelResult.TabIndex = 4;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(197, 282);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // openFileDialogSource
            // 
            this.openFileDialogSource.FileName = "openFileDialog1";
            // 
            // openFileDialogTarget
            // 
            this.openFileDialogTarget.FileName = "openFileDialog1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonTarget);
            this.Controls.Add(this.textBoxDestination);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.buttonSource);
            this.Name = "FormMain";
            this.Text = "Bytes Comparison";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonSource;
        private TextBox textBoxSource;
        private TextBox textBoxDestination;
        private Button buttonTarget;
        private Label labelResult;
        private Button buttonStart;
        private OpenFileDialog openFileDialogSource;
        private OpenFileDialog openFileDialogTarget;
    }
}