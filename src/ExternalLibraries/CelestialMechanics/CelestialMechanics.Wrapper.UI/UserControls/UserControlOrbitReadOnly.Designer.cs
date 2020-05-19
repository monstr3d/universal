namespace CelestialMechanics.Wrapper.UI.UserControls
{
    partial class UserControlOrbitReadOnly
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
            if (orbit != null)
            {
                (orbit as Diagram.UI.Interfaces.IAlias).OnChange -=
                    UserControlOrbitReadOnly_OnChange;
                (orbit as Diagram.UI.Interfaces.IAddRemove).AddAction -= UserControlOrbit_AddRemoveAction;
                (orbit as Diagram.UI.Interfaces.IAddRemove).RemoveAction -= UserControlOrbit_AddRemoveAction;
                orbit = null;
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlOrbit));
            this.panelCenter = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageOsc = new System.Windows.Forms.TabPage();
            this.propertyGridOcsulating = new System.Windows.Forms.PropertyGrid();
            this.tabPageVector = new System.Windows.Forms.TabPage();
            this.propertyGridVector = new System.Windows.Forms.PropertyGrid();
            this.tabPageUnits = new System.Windows.Forms.TabPage();
            this.userControlPhysicalUnit = new Diagram.UI.UserControls.UserControlPhysicalUnit();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelTrans = new System.Windows.Forms.Panel();
            this.comboBoxTransformationType = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tabPageExport = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.userControlComboboxListExpot = new Diagram.UI.UserControls.UserControlComboboxList();
            this.panelCenter.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageOsc.SuspendLayout();
            this.tabPageVector.SuspendLayout();
            this.tabPageUnits.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelTrans.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPageExport.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControl);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(382, 341);
            this.panelCenter.TabIndex = 20;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageOsc);
            this.tabControl.Controls.Add(this.tabPageVector);
            this.tabControl.Controls.Add(this.tabPageUnits);
            this.tabControl.Controls.Add(this.tabPageExport);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(382, 341);
            this.tabControl.TabIndex = 0;
            this.tabControl.TabIndexChanged += new System.EventHandler(this.tabControl_TabIndexChanged);
            // 
            // tabPageOsc
            // 
            this.tabPageOsc.Controls.Add(this.propertyGridOcsulating);
            this.tabPageOsc.Location = new System.Drawing.Point(4, 22);
            this.tabPageOsc.Name = "tabPageOsc";
            this.tabPageOsc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOsc.Size = new System.Drawing.Size(374, 315);
            this.tabPageOsc.TabIndex = 0;
            this.tabPageOsc.Text = "Osculating Elements";
            this.tabPageOsc.UseVisualStyleBackColor = true;
            // 
            // propertyGridOcsulating
            // 
            this.propertyGridOcsulating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridOcsulating.Location = new System.Drawing.Point(3, 3);
            this.propertyGridOcsulating.Name = "propertyGridOcsulating";
            this.propertyGridOcsulating.Size = new System.Drawing.Size(368, 309);
            this.propertyGridOcsulating.TabIndex = 0;
            // 
            // tabPageVector
            // 
            this.tabPageVector.Controls.Add(this.propertyGridVector);
            this.tabPageVector.Location = new System.Drawing.Point(4, 22);
            this.tabPageVector.Name = "tabPageVector";
            this.tabPageVector.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVector.Size = new System.Drawing.Size(374, 315);
            this.tabPageVector.TabIndex = 1;
            this.tabPageVector.Text = "Vector";
            this.tabPageVector.UseVisualStyleBackColor = true;
            // 
            // propertyGridVector
            // 
            this.propertyGridVector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridVector.Location = new System.Drawing.Point(3, 3);
            this.propertyGridVector.Name = "propertyGridVector";
            this.propertyGridVector.Size = new System.Drawing.Size(368, 309);
            this.propertyGridVector.TabIndex = 0;
            // 
            // tabPageUnits
            // 
            this.tabPageUnits.Controls.Add(this.userControlPhysicalUnit);
            this.tabPageUnits.Location = new System.Drawing.Point(4, 22);
            this.tabPageUnits.Name = "tabPageUnits";
            this.tabPageUnits.Size = new System.Drawing.Size(348, 254);
            this.tabPageUnits.TabIndex = 2;
            this.tabPageUnits.Text = "Units";
            this.tabPageUnits.UseVisualStyleBackColor = true;
            // 
            // userControlPhysicalUnit
            // 
            this.userControlPhysicalUnit.Attribute = null;
            this.userControlPhysicalUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlPhysicalUnit.Location = new System.Drawing.Point(0, 0);
            this.userControlPhysicalUnit.Name = "userControlPhysicalUnit";
            this.userControlPhysicalUnit.PhysicalUnitObject = null;
            this.userControlPhysicalUnit.Size = new System.Drawing.Size(348, 254);
            this.userControlPhysicalUnit.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(382, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 341);
            this.panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 341);
            this.panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(382, 0);
            this.panelTop.TabIndex = 16;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelTrans);
            this.panelBottom.Controls.Add(this.panel2);
            this.panelBottom.Controls.Add(this.panel3);
            this.panelBottom.Controls.Add(this.panel4);
            this.panelBottom.Controls.Add(this.panel5);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 341);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(382, 26);
            this.panelBottom.TabIndex = 19;
            // 
            // panelTrans
            // 
            this.panelTrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTrans.Controls.Add(this.comboBoxTransformationType);
            this.panelTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTrans.Location = new System.Drawing.Point(128, 0);
            this.panelTrans.Name = "panelTrans";
            this.panelTrans.Size = new System.Drawing.Size(254, 26);
            this.panelTrans.TabIndex = 20;
            // 
            // comboBoxTransformationType
            // 
            this.comboBoxTransformationType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTransformationType.FormattingEnabled = true;
            this.comboBoxTransformationType.Location = new System.Drawing.Point(0, 0);
            this.comboBoxTransformationType.Name = "comboBoxTransformationType";
            this.comboBoxTransformationType.Size = new System.Drawing.Size(252, 21);
            this.comboBoxTransformationType.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(382, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 26);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(128, 26);
            this.panel3.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transformation type";
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(382, 0);
            this.panel4.TabIndex = 16;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(382, 0);
            this.panel5.TabIndex = 19;
            // 
            // tabPageExport
            // 
            this.tabPageExport.Controls.Add(this.panel1);
            this.tabPageExport.Controls.Add(this.panel6);
            this.tabPageExport.Controls.Add(this.panel7);
            this.tabPageExport.Controls.Add(this.panel8);
            this.tabPageExport.Controls.Add(this.panel9);
            this.tabPageExport.Location = new System.Drawing.Point(4, 22);
            this.tabPageExport.Name = "tabPageExport";
            this.tabPageExport.Size = new System.Drawing.Size(374, 315);
            this.tabPageExport.TabIndex = 3;
            this.tabPageExport.Text = "Export";
            this.tabPageExport.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userControlComboboxListExpot);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 315);
            this.panel1.TabIndex = 20;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(374, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(0, 315);
            this.panel6.TabIndex = 18;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(0, 315);
            this.panel7.TabIndex = 17;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(374, 0);
            this.panel8.TabIndex = 16;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 315);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(374, 0);
            this.panel9.TabIndex = 19;
            // 
            // userControlComboboxListExpot
            // 
            this.userControlComboboxListExpot.Count = 6;
            this.userControlComboboxListExpot.Dictionary = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("userControlComboboxListExpot.Dictionary")));
            this.userControlComboboxListExpot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlComboboxListExpot.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userControlComboboxListExpot.Location = new System.Drawing.Point(0, 0);
            this.userControlComboboxListExpot.Name = "userControlComboboxListExpot";
            this.userControlComboboxListExpot.Size = new System.Drawing.Size(374, 315);
            this.userControlComboboxListExpot.TabIndex = 0;
            this.userControlComboboxListExpot.Texts = new string[] {
        "X",
        "Y",
        "Z",
        "Vx",
        "Vy",
        "Vz"};
            // 
            // UserControlOrbit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "UserControlOrbit";
            this.Size = new System.Drawing.Size(382, 367);
            this.panelCenter.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageOsc.ResumeLayout(false);
            this.tabPageVector.ResumeLayout(false);
            this.tabPageUnits.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelTrans.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPageExport.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageOsc;
        private System.Windows.Forms.TabPage tabPageVector;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TabPage tabPageUnits;
        private System.Windows.Forms.PropertyGrid propertyGridOcsulating;
        private System.Windows.Forms.PropertyGrid propertyGridVector;
        private System.Windows.Forms.Panel panelTrans;
        private System.Windows.Forms.ComboBox comboBoxTransformationType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private Diagram.UI.UserControls.UserControlPhysicalUnit userControlPhysicalUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageExport;
        private System.Windows.Forms.Panel panel1;
        private Diagram.UI.UserControls.UserControlComboboxList userControlComboboxListExpot;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;

    }
}