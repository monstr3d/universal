namespace Diagram.UI.UserControls
{
    partial class UserControlHeteroContainer
    {
        /// <summary> 
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelText = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelRightControl = new System.Windows.Forms.Panel();
            this.panelLeftControl = new System.Windows.Forms.Panel();
            this.panelTopControl = new System.Windows.Forms.Panel();
            this.panelBottomControl = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelComponent = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelTopControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(4, 4);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(28, 13);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "Text";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelComponent);
            this.panelTop.Controls.Add(this.panelRightControl);
            this.panelTop.Controls.Add(this.panelLeftControl);
            this.panelTop.Controls.Add(this.panelTopControl);
            this.panelTop.Controls.Add(this.panelBottomControl);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(202, 101);
            this.panelTop.TabIndex = 21;
            // 
            // panelRightControl
            // 
            this.panelRightControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightControl.Location = new System.Drawing.Point(198, 26);
            this.panelRightControl.Name = "panelRightControl";
            this.panelRightControl.Size = new System.Drawing.Size(4, 74);
            this.panelRightControl.TabIndex = 18;
            // 
            // panelLeftControl
            // 
            this.panelLeftControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftControl.Location = new System.Drawing.Point(0, 26);
            this.panelLeftControl.Name = "panelLeftControl";
            this.panelLeftControl.Size = new System.Drawing.Size(4, 74);
            this.panelLeftControl.TabIndex = 17;
            // 
            // panelTopControl
            // 
            this.panelTopControl.Controls.Add(this.labelText);
            this.panelTopControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopControl.Location = new System.Drawing.Point(0, 0);
            this.panelTopControl.Name = "panelTopControl";
            this.panelTopControl.Size = new System.Drawing.Size(202, 26);
            this.panelTopControl.TabIndex = 16;
            // 
            // panelBottomControl
            // 
            this.panelBottomControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomControl.Location = new System.Drawing.Point(0, 100);
            this.panelBottomControl.Name = "panelBottomControl";
            this.panelBottomControl.Size = new System.Drawing.Size(202, 1);
            this.panelBottomControl.TabIndex = 19;
            // 
            // panelCenter
            // 
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(202, 104);
            this.panelCenter.TabIndex = 25;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(202, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 104);
            this.panelRight.TabIndex = 23;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 104);
            this.panelLeft.TabIndex = 22;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 104);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(202, 0);
            this.panelBottom.TabIndex = 24;
            // 
            // panelComponent
            // 
            this.panelComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelComponent.Location = new System.Drawing.Point(4, 26);
            this.panelComponent.Name = "panelComponent";
            this.panelComponent.Size = new System.Drawing.Size(194, 74);
            this.panelComponent.TabIndex = 20;
            // 
            // UserControlHeteroContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlHeteroContainer";
            this.Size = new System.Drawing.Size(202, 104);
            this.panelTop.ResumeLayout(false);
            this.panelTopControl.ResumeLayout(false);
            this.panelTopControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelRightControl;
        private System.Windows.Forms.Panel panelLeftControl;
        private System.Windows.Forms.Panel panelTopControl;
        private System.Windows.Forms.Panel panelBottomControl;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelComponent;
    }
}
