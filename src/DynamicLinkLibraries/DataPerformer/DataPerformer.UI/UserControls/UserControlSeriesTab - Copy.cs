using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

using BaseTypes.Interfaces;

using Chart;
using Chart.Utils;

using DataPerformer.Formula;

using FormulaEditor.Interfaces;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Tab series control
    /// </summary>
    public partial class UserControlSeriesTab : UserControl, IObjectOperation,
        IVariableDetector, 
       IOperationAcceptor, IPowered
    {
        #region Fields

        private Series series;

        private double currentTime;

        private event Action<string> setFormula = (string formula) => { };

        FormulaEditor.ObjectFormulaTree tree;

        private FormulaEditor.Interfaces.IFormulaObjectCreator creator = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlSeriesTab()
        {
            InitializeComponent();
            userControlSeries.ShowStrip(false);
            SeriesPainterControlPovider sp =
                new SeriesPainterControlPovider(toolStripButtonType, pic,
                    StaticExtensionDataPerformerUI.DefaultSeriesPaintingArray);
            userControlSeries.PainterProvider = sp;
            userControlSeries.Performer.SetMouseIndicator(
               toolStripStatusCoord);
            creator = VariableDetector.GetCreator(this);
            
        }

        #endregion

        #region IObjectOperation Members

        object[] IObjectOperation.InputTypes
        {
            get { return new object[0]; }
        }

        object IObjectOperation.this[object[] x]
        {
            get { return currentTime; }
        }

        object IObjectOperation.ReturnType
        {
            get { return (double)0; }
        }

        #endregion

        #region IVariableDetector Members

        IOperationAcceptor 
            FormulaEditor.Interfaces.IVariableDetector.Detect(FormulaEditor.Symbols.MathSymbol sym)
        {
            if (sym.Symbol == 't')
            {
                return this;
            }
            return null;
        }

        #endregion

        #region IOperationAcceptor Members

        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            return this;
        }

        #endregion

        #region IPowered Members

        bool IPowered.IsPowered
        {
            get { return true; }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Series
        /// </summary>
        public Series Series
        {
            get
            {
                return series;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                series = value;
                userControlSeries.Series = value;
                userControlSeriesTable.Series = value;
                SetLabel();
            }
        }


        /// <summary>
        /// Shows chart and all UI
        /// </summary>
        public void ShowAll()
        {
            userFormulaEditor.PreparePoly(new int[] { 15, 11 }, 't', new string[0]);
            userControlSeries.ShowAll();
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
            userControlSeries.Post();
        }

        /// <summary>
        /// Set formula event
        /// </summary>
        public event Action<string> SetFormula
        {
            add { setFormula += value; }
            remove { setFormula -= value; }
        }

        #endregion

        #region Private And Internal Members

        internal object[] Array
        {
            get
            {
                return userControlSeries.PainterProvider.Array;
            }
            set
            {
                checkBoxShow.Checked = value.GetShowTable();
                userControlSeries.PainterProvider.Array = value;
            }
        }


        private void SetLabel()
        {
            labelCount.Text = "";
            if (userControlSeriesTable.Series != null)
            {
                labelCount.Text = userControlSeriesTable.Series.Count + "";
            }
            if (series != null)
            {
                if (series.Count >= 2)
                {
                    textBoxStart.Text = series[0, 0] + "";
                    textBoxStep.Text = (series[1, 0] - series[0, 0]) + "";
                    textBoxStepCount.Text = series.Count + "";
                }
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
                userControlSeries.ShowAll();
            }
            catch (Exception e)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }

        void CreateTree()
        {
            tree = FormulaEditor.ObjectFormulaTree.CreateTree(
                FormulaEditor.MathFormula.FromString(new int[4], userFormulaEditor.Formula).FullTransform(null), 
                creator);
            Double a = 0;
            if (!tree.ReturnType.Equals(a))
            {
                throw new Exception();
            }
            setFormula(userFormulaEditor.Formula);
        }

        void Generate()
        {
            try
            {
                CreateTree();
                double start = Double.Parse(textBoxStart.Text);
                double step = Double.Parse(textBoxStep.Text);
                int stepCount = Int32.Parse(textBoxStepCount.Text);
                double[,] xy = new double[stepCount, 2];
                for (int i = 0; i < stepCount; i++)
                {
                    currentTime = start + (i * step);
                    xy[i, 0] = currentTime;
                    xy[i, 1] = (double)tree.Result;
                }
                series.Clear();
                for (int i = 0; i < stepCount; i++)
                {
                    series.AddXY(xy[i, 0], xy[i, 1]);
                }
                userControlSeries.ShowAll();
                userControlSeriesTable.FillTable(checkBoxShow.Checked);
                labelCount.Text = series.Count + "";
            }
            catch (Exception e)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }

        internal string Formula
        {
            set
            {
                userFormulaEditor.Formula = value;
            }
        }

        #endregion

        #region Event Handlers

        private void userControlSeriesTable_Update()
        {
            userControlSeries.ShowAll();
            SetLabel();
        }

        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            bool ch = checkBoxShow.Checked;
            object[] array = userControlSeries.Array;
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

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            userControlSeries.Open();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            userControlSeries.Save();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            userControlSeries.ShowAll();
        }


        private void exportToXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToXml();
        }

        private void importFromXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFromXml();
        }

 
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            Generate();
        }
        #endregion

    }
}
