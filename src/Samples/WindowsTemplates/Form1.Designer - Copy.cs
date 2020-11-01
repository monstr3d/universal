namespace WindowsTemplates
{
    partial class Form1
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
            this.panelLabel = new System.Windows.Forms.Panel();
            this.buttonAlignment = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.panelDrawing = new System.Windows.Forms.Panel();
            this.panelLabelPeer = new System.Windows.Forms.Panel();
            this.panelLabel.SuspendLayout();
            this.panelDrawing.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLabel
            // 
            this.panelLabel.Controls.Add(this.buttonAlignment);
            this.panelLabel.Controls.Add(this.label3);
            this.panelLabel.Controls.Add(this.textBoxComment);
            this.panelLabel.Controls.Add(this.panelDrawing);
            this.panelLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLabel.Location = new System.Drawing.Point(0, 46);
            this.panelLabel.Name = "panelLabel";
            this.panelLabel.Size = new System.Drawing.Size(433, 401);
            this.panelLabel.TabIndex = 5;
            // 
            // buttonAlignment
            // 
            this.buttonAlignment.Location = new System.Drawing.Point(24, 320);
            this.buttonAlignment.Name = "buttonAlignment";
            this.buttonAlignment.Size = new System.Drawing.Size(224, 23);
            this.buttonAlignment.TabIndex = 4;
            this.buttonAlignment.Text = "Alignment";
            this.buttonAlignment.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(29, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Comment";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(24, 277);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(224, 20);
            this.textBoxComment.TabIndex = 2;
            // 
            // panelDrawing
            // 
            this.panelDrawing.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelDrawing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDrawing.Controls.Add(this.panelLabelPeer);
            this.panelDrawing.Location = new System.Drawing.Point(24, 48);
            this.panelDrawing.Name = "panelDrawing";
            this.panelDrawing.Size = new System.Drawing.Size(224, 200);
            this.panelDrawing.TabIndex = 1;
            // 
            // panelLabelPeer
            // 
            this.panelLabelPeer.BackColor = System.Drawing.SystemColors.Control;
            this.panelLabelPeer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLabelPeer.Location = new System.Drawing.Point(56, 48);
            this.panelLabelPeer.Name = "panelLabelPeer";
            this.panelLabelPeer.Size = new System.Drawing.Size(100, 100);
            this.panelLabelPeer.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 447);
            this.Controls.Add(this.panelLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelLabel.ResumeLayout(false);
            this.panelLabel.PerformLayout();
            this.panelDrawing.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLabel;
        private System.Windows.Forms.Button buttonAlignment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Panel panelDrawing;
        private System.Windows.Forms.Panel panelLabelPeer;
    }
}