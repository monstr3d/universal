namespace Agriculture.ScadaSample.WindowsForms
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.slider1 = new Scada.Windows.UI.UserControls.Slider();
            this.term1 = new Scada.Windows.UI.UserControls.Term();
            this.SuspendLayout();
            // 
            // slider1
            // 
            this.slider1.Location = new System.Drawing.Point(23, 74);
            this.slider1.Max = 100F;
            this.slider1.Min = 0F;
            this.slider1.Name = "slider1";
            this.slider1.Output = "Forced.X";
            this.slider1.Size = new System.Drawing.Size(90, 140);
            this.slider1.TabIndex = 0;
            // 
            // term1
            // 
            this.term1.Event = "Timer";
            this.term1.Location = new System.Drawing.Point(130, 74);
            this.term1.Max = 100F;
            this.term1.Min = 0F;
            this.term1.Name = "term1";
            this.term1.Output = "F.Formula_1";
            this.term1.Size = new System.Drawing.Size(80, 140);
            this.term1.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 263);
            this.Controls.Add(this.term1);
            this.Controls.Add(this.slider1);
            this.Name = "FormMain";
            this.Text = "Scada Test";
            this.ResumeLayout(false);

        }

        #endregion

        private Scada.Windows.UI.UserControls.Slider slider1;
        private Scada.Windows.UI.UserControls.Term term1;
    }
}

