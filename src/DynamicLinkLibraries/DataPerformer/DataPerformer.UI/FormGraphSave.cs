using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Diagram.UI;
using Diagram.UI.Utils;

using ToolBox;

using DataPerformer;

using Chart;
using Chart.Interfaces;
using Chart.Drawing.Interfaces;
using Chart.Panels;

namespace DataPerformer.UI
{
	/// <summary>
	/// Summary description for FormGraphSave.
	/// </summary>
    public class FormGraphSave : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.MenuStrip mainMenuPlot;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveGraph;
        private System.Windows.Forms.ToolStripMenuItem menuItemFormat;
        private System.Windows.Forms.ToolStripMenuItem menuItemFont;
        private System.Windows.Forms.SaveFileDialog saveFileDialogPlot;
        private System.Windows.Forms.SaveFileDialog saveFileDialogGraph;
        private ChartPerformer performer;
        private DataPerformer.Series series = new DataPerformer.Series();
        private ToolStripMenuItem menuItemSaveXML;
        private IContainer components;

        /// <summary>
        /// Default consructor
        /// </summary>
        public FormGraphSave()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="series">Series for saving</param>
        /// <param name="comments">Comments for saving</param>
        public FormGraphSave(DataPerformer.Series series, ArrayList comments)
        {
            InitializeComponent();
            this.LoadResources();
            this.series.CopyFrom(series);
            //this.series.CopyFrom(series);
            PanelChart panel = new PanelChart(new int[,] { { 80, 30 }, { 10, 40 } });
            panel.Width = panelGraph.Width - 100;
            panel.Height = panelGraph.Height - 100;
            panel.Left = 50;
            panel.Top = 50;
            performer = panel.Performer;
            panelGraph.Controls.Add(panel);
            panel.LoadResources();
            SimpleCoordinator coordinator = new SimpleCoordinator(5, 5, performer);
            performer.Coordinator = coordinator;
            EditorReceiver.AddEditorDrag(panelGraph);
            PictureReceiver.AddImageDrag(panelGraph);
            ControlPanel.LoadControls(panelGraph, comments);
            ISeries s = new SeriesGraph(series);
            performer.AddSeries(s, Color.Magenta);
            performer.RefreshAll();
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.mainMenuPlot = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveXML = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFont = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogPlot = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialogGraph = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // panelGraph
            // 
            this.panelGraph.BackColor = System.Drawing.Color.White;
            this.panelGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGraph.Location = new System.Drawing.Point(24, 40);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(900, 500);
            this.panelGraph.TabIndex = 20;
            // 
            // mainMenuPlot
            // 
            this.mainMenuPlot.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.menuItemFile,
            this.menuItemFormat});
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.menuItemSaveGraph,
            this.menuItemSaveXML});
            this.menuItemFile.Text = "File";
            // 
            // menuItemSaveGraph
            // 
            this.menuItemSaveGraph.Text = "Save graph as";
            this.menuItemSaveGraph.Click += new System.EventHandler(this.menuItemSaveGraph_Click);
            // 
            // menuItemSaveXML
            // 
            this.menuItemSaveXML.Text = "Save as XML";
            this.menuItemSaveXML.Click += new System.EventHandler(this.menuItemSaveXML_Click);
            // 
            // menuItemFormat
            // 
            this.menuItemFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.menuItemFont});
            this.menuItemFormat.Text = "Format";
            // 
            // menuItemFont
            // 
            this.menuItemFont.Text = "Font";
            this.menuItemFont.Click += new System.EventHandler(this.menuItemFont_Click);
            // 
            // saveFileDialogPlot
            // 
            this.saveFileDialogPlot.Filter = "XML Function files |*.xml";
            // 
            // saveFileDialogGraph
            // 
            this.saveFileDialogGraph.Filter = "Graph files |*.gra";
            // 
            // FormGraphSave
            // 
            this.ClientSize = new System.Drawing.Size(976, 589);
            this.Controls.Add(this.panelGraph);
            this.MainMenuStrip = this.mainMenuPlot;
            this.Name = "FormGraphSave";
            this.Text = "Save graph";
            this.ResumeLayout(false);

        }
        #endregion

        private void menuItemFont_Click(object sender, System.EventArgs e)
        {
            try
            {
                TextBox box = ControlPanel.GetActiveTextBox(panelGraph);
                if (box == null)
                {
                    return;
                }
                FontDialog dlg = new FontDialog();
                dlg.ShowDialog(this);
                Font font = dlg.Font;
                box.Font = font;
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }

        }

        private void menuItemSaveGraph_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (performer.Count == 0)
                {
                    return;
                }
                saveFileDialogGraph.InitialDirectory = ResourceService.Resources.CurrentDirectory + "Series";
                if (saveFileDialogGraph.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                Stream stream = File.Open(saveFileDialogGraph.FileName, FileMode.Create);
                BinaryFormatter bformatter = new BinaryFormatter();
                ArrayList comments = ControlPanel.GetControls(panelGraph);
                series.Comments = comments;
                bformatter.Serialize(stream, series);
                stream.Close();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        private void menuItemSaveXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (performer.Count == 0)
                {
                    return;
                }
                if (saveFileDialogPlot.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<Root/>");
                XmlElement el = series.ExportToXml(doc);
                doc.DocumentElement.AppendChild(el);
                doc.Save(saveFileDialogPlot.FileName);
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }

        }
    }

}
