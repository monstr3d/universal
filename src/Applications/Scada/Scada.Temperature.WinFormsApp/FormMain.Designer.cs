namespace Scada.Temperature.WinFormsApp
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
            termometer = new Windows.UI.UserControls.Term();
            control = new Windows.UI.UserControls.Slider();
            SuspendLayout();
            // 
            // termometer
            // 
            termometer.Event = "Combination";
            termometer.Location = new Point(165, 46);
            termometer.Max = 100F;
            termometer.Min = 0F;
            termometer.Name = "termometer";
            termometer.Output = "ODE.x";
            termometer.Size = new Size(80, 140);
            termometer.TabIndex = 3;
            // 
            // control
            // 
            control.Input = "Control.Value";
            control.Location = new Point(31, 46);
            control.Max = 100F;
            control.Min = 0F;
            control.Name = "control";
            control.Size = new Size(90, 140);
            control.TabIndex = 2;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 233);
            Controls.Add(termometer);
            Controls.Add(control);
            Name = "FormMain";
            Text = "FormMain";
            ResumeLayout(false);
        }

        #endregion

        private Windows.UI.UserControls.Term termometer;
        private Windows.UI.UserControls.Slider control;
    }
}