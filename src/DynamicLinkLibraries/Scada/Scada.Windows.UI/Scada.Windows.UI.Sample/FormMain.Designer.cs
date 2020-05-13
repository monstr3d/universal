namespace Scada.Windows.UI.Sample
{
    partial class FormMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.slider1 = new Scada.Windows.UI.UserControls.Slider();
            this.term = new Scada.Windows.UI.UserControls.Term();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Required value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Actual value";
            // 
            // slider1
            // 
            this.slider1.Location = new System.Drawing.Point(2, 17);
            this.slider1.Max = 100F;
            this.slider1.Min = 0F;
            this.slider1.Name = "slider1";
            this.slider1.Output = "Forced.Value";
            this.slider1.Size = new System.Drawing.Size(90, 140);
            this.slider1.TabIndex = 1;
            // 
            // term
            // 
            this.term.Event = "Timer";
            this.term.Location = new System.Drawing.Point(98, 17);
            this.term.Max = 100F;
            this.term.Min = 0F;
            this.term.Name = "term";
            this.term.Output = "Equation.x";
            this.term.Size = new System.Drawing.Size(80, 140);
            this.term.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 166);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.slider1);
            this.Controls.Add(this.term);
            this.Name = "FormMain";
            this.Text = "Temperature control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Term term;
        private UserControls.Slider slider1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;



    }
}

