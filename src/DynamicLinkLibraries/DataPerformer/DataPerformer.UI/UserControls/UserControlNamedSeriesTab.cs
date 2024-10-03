using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;


using DataPerformer;
using DataPerformer.Interfaces;


using Chart;
using Chart.Utils;
using Chart.Indicators;



namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Tab series control
    /// </summary>
    public partial class UserControlNamedSeriesTab : UserControl
    {
        #region Fields


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlNamedSeriesTab()
        {
            InitializeComponent();
            userControlNamedSeries.SetToolStrip(false);
            userControlNamedSeries.Boxes = new ToolStripComboBox[] { toolStripComboBoxX, toolStripComboBoxY };
            SeriesPainterControlPovider sp =
                new SeriesPainterControlPovider(toolStripButtonType, pic,
                    StaticExtensionDataPerformerUI.DefaultSeriesPaintingArray);
            userControlNamedSeries.PainterProvider = sp;
            userControlNamedSeries.Performer.SetMouseIndicator(toolStripStatusCoord);
            userControlSeriesTable.DisableEdit();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Series
        /// </summary>
        public INamedCoordinates NamedCoordinates
        {
            get
            {
                return userControlNamedSeries.NamedCoordinates;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                userControlNamedSeries.NamedCoordinates = value;
                userControlNamedSeries.Fill();
                userControlSeriesTable.Series = value as Series;
                SetLabel();
            }
        }


        /// <summary>
        /// Shows all UI
        /// </summary>
        public void ShowAll()
        {
            userControlNamedSeries.ShowAll();
            userControlSeriesTable.Show = Array.GetShowTable();
            userControlSeriesTable.ShowTable += (bool b) =>
            {
                Array.SetShowTable(b);
            };
        }


        /// <summary>
        /// Loads itself
        /// </summary>
        new public void Load()
        {
            userControlNamedSeries.Fill();
            userControlNamedSeries.ShowAll();
        }

        #endregion

        #region Private And Internal Members

        internal object[] Array
        {
            get
            {
                return userControlNamedSeries.PainterProvider.Array;
            }
            set
            {
                checkBoxShow.Checked = value.GetShowTable();
                userControlNamedSeries.PainterProvider.Array = value;
            }
        }

        internal void SaveComments()
        {
            //userControlSeries.Sa
        }

        private void SetLabel()
        {
            labelCount.Text = "";
            if (userControlSeriesTable.Series != null)
            {
                labelCount.Text = userControlSeriesTable.Series.Count + "";
            }
        }

        void ExportToXml()
        {
            try
            {
                if (saveFileDialogXml.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
               
                XmlDocument doc = userControlSeriesTable.Series.Xml;
                doc.Save(saveFileDialogXml.FileName);
            }
            catch (Exception e)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }

        void ImportFromXml()
        {
            try
            {
                if (openFileDialogXml.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                XmlDocument doc = new XmlDocument();
                doc.Load(openFileDialogXml.FileName);
                userControlSeriesTable.Series.Xml = doc;
            }
            catch (Exception e)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
       }

        #endregion

        #region Event Handlers

        private void userControlSeriesTable_Update()
        {
            userControlNamedSeries.ShowAll();
            SetLabel();
        }

        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            bool ch = checkBoxShow.Checked;
            object[] array = userControlNamedSeries.Array;
            if (ch != array.GetShowTable())
            {
                array.SetShowTable(ch);
                userControlSeriesTable.Show = ch;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            userControlSeriesTable.UpdateTable();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            userControlNamedSeries.Save();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            userControlNamedSeries.ShowAll();
        }

        private void exportToXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToXml();
        }


        private void importFromXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFromXml();
        }

        #endregion

    }
}
