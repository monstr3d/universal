﻿namespace DataPerformer.UI.Forms
{
    partial class FormFuncAccumulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFuncAccumulator));
            this.userControlFuncAccumulatorFull = new DataPerformer.UI.UserControls.UserControlFuncAccumulatorFull();
            this.SuspendLayout();
            // 
            // userControlFuncAccumulatorFull
            // 
            this.userControlFuncAccumulatorFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlFuncAccumulatorFull.Location = new System.Drawing.Point(0, 0);
            this.userControlFuncAccumulatorFull.Name = "userControlFuncAccumulatorFull";
            this.userControlFuncAccumulatorFull.Size = new System.Drawing.Size(239, 291);
            this.userControlFuncAccumulatorFull.TabIndex = 0;
            // 
            // FormFuncAccumulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 291);
            this.Controls.Add(this.userControlFuncAccumulatorFull);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFuncAccumulator";
            this.Text = "FormFuncAccumulator";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UserControlFuncAccumulatorFull userControlFuncAccumulatorFull;


    }
}