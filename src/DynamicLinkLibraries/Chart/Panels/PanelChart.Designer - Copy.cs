using System.Windows.Forms;

namespace Chart.Panels
{
    partial class PanelChart : Panel
    {

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


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStripChart = new System.Windows.Forms.ContextMenu();
            this.copyToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.copySeriesToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.MenuItem();
             this.SuspendLayout();
            // 
            // contextMenuStripChart
            // 
            this.contextMenuStripChart.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.copyToolStripMenuItem,
            this.copySeriesToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.formatToolStripMenuItem});
            this.contextMenuStripChart.Name = "contextMenuStripChart";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Text = "Copy image";
            // 
            // copySeriesToolStripMenuItem
            // 
            this.copySeriesToolStripMenuItem.Name = "copySeriesToolStripMenuItem";
            this.copySeriesToolStripMenuItem.Text = "Copy series";
            this.copySeriesToolStripMenuItem.Visible = false;
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Visible = false;
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // PanelChart
            // 
            this.ContextMenu = this.contextMenuStripChart;
            this.ResumeLayout(false);

        }

  
        private ContextMenu contextMenuStripChart;
        private MenuItem copyToolStripMenuItem;
        private MenuItem copySeriesToolStripMenuItem;
        private MenuItem pasteToolStripMenuItem;
        private MenuItem formatToolStripMenuItem;
    }
}