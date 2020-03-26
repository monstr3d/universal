namespace DataPerformer.UI.UserControls
{
    partial class UserControlKalmanFilter
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
            this.panelCenter = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageParameters = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlComboboxList = new Diagram.UI.UserControls.UserControlComboboxList();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelBottomLeft = new System.Windows.Forms.Panel();
            this.buttonSetPar = new System.Windows.Forms.Button();
            this.tabPageValues = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tabControlState = new System.Windows.Forms.TabControl();
            this.tabPageStateState = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State_difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Measure_difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.tabPageCovariation = new System.Windows.Forms.TabPage();
            this.panel14 = new System.Windows.Forms.Panel();
            this.dataGridViewMatrix = new Diagram.UI.Components.DataGridViewMatrix();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonSetState = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBottomBottom = new System.Windows.Forms.Panel();
            this.panelCenter.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageParameters.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelBottomLeft.SuspendLayout();
            this.tabPageValues.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabControlState.SuspendLayout();
            this.tabPageStateState.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPageCovariation.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatrix)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.tabControlMain);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 26);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(464, 326);
            this.panelCenter.TabIndex = 20;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageParameters);
            this.tabControlMain.Controls.Add(this.tabPageValues);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(464, 326);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageParameters
            // 
            this.tabPageParameters.Controls.Add(this.panel1);
            this.tabPageParameters.Controls.Add(this.panel2);
            this.tabPageParameters.Controls.Add(this.panel3);
            this.tabPageParameters.Controls.Add(this.panel4);
            this.tabPageParameters.Controls.Add(this.panelBottomLeft);
            this.tabPageParameters.Location = new System.Drawing.Point(4, 22);
            this.tabPageParameters.Name = "tabPageParameters";
            this.tabPageParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParameters.Size = new System.Drawing.Size(456, 300);
            this.tabPageParameters.TabIndex = 0;
            this.tabPageParameters.Text = "Parameters";
            this.tabPageParameters.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userControlComboboxList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 270);
            this.panel1.TabIndex = 20;
            // 
            // userControlComboboxList
            // 
            this.userControlComboboxList.Count = 5;
            this.userControlComboboxList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlComboboxList.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userControlComboboxList.Location = new System.Drawing.Point(0, 0);
            this.userControlComboboxList.Name = "userControlComboboxList";
            this.userControlComboboxList.Size = new System.Drawing.Size(450, 270);
            this.userControlComboboxList.TabIndex = 0;
            this.userControlComboboxList.Texts = new string[] {
        "State transformation",
        "Measurement transformation",
        "Measurement source",
        "Covatiation of state",
        "Covatiation of measurements"};
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(453, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 270);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 270);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(450, 0);
            this.panel4.TabIndex = 16;
            // 
            // panelBottomLeft
            // 
            this.panelBottomLeft.Controls.Add(this.buttonSetPar);
            this.panelBottomLeft.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomLeft.Location = new System.Drawing.Point(3, 273);
            this.panelBottomLeft.Name = "panelBottomLeft";
            this.panelBottomLeft.Size = new System.Drawing.Size(450, 24);
            this.panelBottomLeft.TabIndex = 19;
            // 
            // buttonSetPar
            // 
            this.buttonSetPar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetPar.Location = new System.Drawing.Point(0, 0);
            this.buttonSetPar.Name = "buttonSetPar";
            this.buttonSetPar.Size = new System.Drawing.Size(450, 24);
            this.buttonSetPar.TabIndex = 0;
            this.buttonSetPar.Text = "Apply";
            this.buttonSetPar.UseVisualStyleBackColor = true;
            this.buttonSetPar.Click += new System.EventHandler(this.buttonSetPar_Click);
            // 
            // tabPageValues
            // 
            this.tabPageValues.Controls.Add(this.panel5);
            this.tabPageValues.Controls.Add(this.panel6);
            this.tabPageValues.Controls.Add(this.panel7);
            this.tabPageValues.Controls.Add(this.panel8);
            this.tabPageValues.Controls.Add(this.panelBottom);
            this.tabPageValues.Location = new System.Drawing.Point(4, 22);
            this.tabPageValues.Name = "tabPageValues";
            this.tabPageValues.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageValues.Size = new System.Drawing.Size(456, 300);
            this.tabPageValues.TabIndex = 1;
            this.tabPageValues.Text = "Values";
            this.tabPageValues.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tabControlState);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(450, 270);
            this.panel5.TabIndex = 20;
            // 
            // tabControlState
            // 
            this.tabControlState.Controls.Add(this.tabPageStateState);
            this.tabControlState.Controls.Add(this.tabPageCovariation);
            this.tabControlState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlState.Location = new System.Drawing.Point(0, 0);
            this.tabControlState.Name = "tabControlState";
            this.tabControlState.SelectedIndex = 0;
            this.tabControlState.Size = new System.Drawing.Size(450, 270);
            this.tabControlState.TabIndex = 0;
            // 
            // tabPageStateState
            // 
            this.tabPageStateState.Controls.Add(this.panel9);
            this.tabPageStateState.Controls.Add(this.panel10);
            this.tabPageStateState.Controls.Add(this.panel11);
            this.tabPageStateState.Controls.Add(this.panel12);
            this.tabPageStateState.Controls.Add(this.panel13);
            this.tabPageStateState.Location = new System.Drawing.Point(4, 22);
            this.tabPageStateState.Name = "tabPageStateState";
            this.tabPageStateState.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStateState.Size = new System.Drawing.Size(442, 244);
            this.tabPageStateState.TabIndex = 0;
            this.tabPageStateState.Text = "State";
            this.tabPageStateState.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dataGridView);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(436, 238);
            this.panel9.TabIndex = 20;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnN,
            this.ColumnState,
            this.State_difference,
            this.Measure_difference});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(436, 238);
            this.dataGridView.TabIndex = 4;
            // 
            // ColumnN
            // 
            this.ColumnN.HeaderText = "N";
            this.ColumnN.Name = "ColumnN";
            this.ColumnN.ReadOnly = true;
            // 
            // ColumnState
            // 
            this.ColumnState.HeaderText = "State";
            this.ColumnState.Name = "ColumnState";
            // 
            // State_difference
            // 
            this.State_difference.HeaderText = "State difference";
            this.State_difference.Name = "State_difference";
            // 
            // Measure_difference
            // 
            this.Measure_difference.HeaderText = "Measure difference";
            this.Measure_difference.Name = "Measure_difference";
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(439, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(0, 238);
            this.panel10.TabIndex = 18;
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(0, 238);
            this.panel11.TabIndex = 17;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(3, 3);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(436, 0);
            this.panel12.TabIndex = 16;
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(3, 241);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(436, 0);
            this.panel13.TabIndex = 19;
            // 
            // tabPageCovariation
            // 
            this.tabPageCovariation.Controls.Add(this.panel14);
            this.tabPageCovariation.Controls.Add(this.panel15);
            this.tabPageCovariation.Controls.Add(this.panel16);
            this.tabPageCovariation.Controls.Add(this.panel17);
            this.tabPageCovariation.Controls.Add(this.panel18);
            this.tabPageCovariation.Location = new System.Drawing.Point(4, 22);
            this.tabPageCovariation.Name = "tabPageCovariation";
            this.tabPageCovariation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCovariation.Size = new System.Drawing.Size(442, 244);
            this.tabPageCovariation.TabIndex = 1;
            this.tabPageCovariation.Text = "Covariation";
            this.tabPageCovariation.UseVisualStyleBackColor = true;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.dataGridViewMatrix);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(3, 3);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(436, 238);
            this.panel14.TabIndex = 20;
            // 
            // dataGridViewMatrix
            // 
            this.dataGridViewMatrix.AllowUserToAddRows = false;
            this.dataGridViewMatrix.AllowUserToDeleteRows = false;
            this.dataGridViewMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMatrix.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMatrix.Name = "dataGridViewMatrix";
            this.dataGridViewMatrix.Size = new System.Drawing.Size(436, 238);
            this.dataGridViewMatrix.TabIndex = 0;
            this.dataGridViewMatrix.Action += new System.Action<int, int, object>(this.dataGridViewMatrix_Action);
            // 
            // panel15
            // 
            this.panel15.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel15.Location = new System.Drawing.Point(439, 3);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(0, 238);
            this.panel15.TabIndex = 18;
            // 
            // panel16
            // 
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(3, 3);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(0, 238);
            this.panel16.TabIndex = 17;
            // 
            // panel17
            // 
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(3, 3);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(436, 0);
            this.panel17.TabIndex = 16;
            // 
            // panel18
            // 
            this.panel18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel18.Location = new System.Drawing.Point(3, 241);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(436, 0);
            this.panel18.TabIndex = 19;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(453, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(0, 270);
            this.panel6.TabIndex = 18;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(0, 270);
            this.panel7.TabIndex = 17;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(450, 0);
            this.panel8.TabIndex = 16;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.buttonSetState);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(3, 273);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(450, 24);
            this.panelBottom.TabIndex = 19;
            // 
            // buttonSetState
            // 
            this.buttonSetState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetState.Location = new System.Drawing.Point(0, 0);
            this.buttonSetState.Name = "buttonSetState";
            this.buttonSetState.Size = new System.Drawing.Size(450, 24);
            this.buttonSetState.TabIndex = 0;
            this.buttonSetState.Text = "Apply";
            this.buttonSetState.UseVisualStyleBackColor = true;
            this.buttonSetState.Click += new System.EventHandler(this.buttonSetState_Click);
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(464, 26);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(0, 326);
            this.panelRight.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 26);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(0, 326);
            this.panelLeft.TabIndex = 17;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(464, 26);
            this.panelTop.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kalman filter";
            // 
            // panelBottomBottom
            // 
            this.panelBottomBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomBottom.Location = new System.Drawing.Point(0, 352);
            this.panelBottomBottom.Name = "panelBottomBottom";
            this.panelBottomBottom.Size = new System.Drawing.Size(464, 0);
            this.panelBottomBottom.TabIndex = 19;
            // 
            // UserControlKalmanFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottomBottom);
            this.Name = "UserControlKalmanFilter";
            this.Size = new System.Drawing.Size(464, 352);
            this.panelCenter.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageParameters.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelBottomLeft.ResumeLayout(false);
            this.tabPageValues.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tabControlState.ResumeLayout(false);
            this.tabPageStateState.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPageCovariation.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatrix)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottomBottom;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageParameters;
        private System.Windows.Forms.TabPage tabPageValues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private Diagram.UI.UserControls.UserControlComboboxList userControlComboboxList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelBottomLeft;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonSetPar;
        private System.Windows.Forms.Button buttonSetState;
        private System.Windows.Forms.TabControl tabControlState;
        private System.Windows.Forms.TabPage tabPageStateState;
        private System.Windows.Forms.TabPage tabPageCovariation;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnState;
        private System.Windows.Forms.DataGridViewTextBoxColumn State_difference;
        private System.Windows.Forms.DataGridViewTextBoxColumn Measure_difference;
        private System.Windows.Forms.Panel panel14;
        private Diagram.UI.Components.DataGridViewMatrix dataGridViewMatrix;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel18;
    }
}
