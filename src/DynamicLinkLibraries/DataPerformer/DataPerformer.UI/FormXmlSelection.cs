using System;
using System.Drawing;

using System.Windows.Forms;
using System.Xml;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using Regression.Portable;
using ErrorHandler;


namespace DataPerformer.UI
{
    /// <summary>
    /// Editor of properties of Xml selection
    /// </summary>
    public partial class FormXmlSelection : Form, IUpdatableForm
    {
        private XmlSelectionCollection selection;
        
        private IObjectLabel label;

        private FormXmlSelection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Corresponding label</param>
        public FormXmlSelection(IObjectLabel label)
            : this()
        {
            this.LoadResources();
            this.label = label;
            selection = label.Object as XmlSelectionCollection;
            UpdateFormUI();
            updateButtons();

        }

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        private void buttonDoc_Click(object sender, EventArgs e)
        {
            if (openFileDialogXml.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            XmlDocument doc = new XmlDocument();
            XmlReader reader = new XmlTextReader(openFileDialogXml.FileName);
            doc.Load(reader);
            reader.Close();
            try
            {
                if (sender == buttonDoc)
                {
                    selection.Document = doc.OuterXml;
                }
                else
                {
                    selection.Scheme = doc.OuterXml;
                }

            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
            updateButtons();

        }

        private void updateButtons()
        {
            if (selection.Document == null)
            {
                buttonDoc.ForeColor = Color.Red;
            }
            else
            {
                buttonDoc.ForeColor = Color.Green;
            }
            if (selection.Scheme == null)
            {
                buttonScheme.ForeColor = Color.Red;
            }
            else
            {
                buttonScheme.ForeColor = Color.Green;
            }
        }

        bool prepSave()
        {
            return saveFileDialogXml.ShowDialog(this) != DialogResult.OK;
        }

        void save(string s)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(s);
            doc.Save(saveFileDialogXml.FileName);
        }

        private void buttonSaveDoc_Click(object sender, EventArgs e)
        {
            if (prepSave())
            {
                return;
            }
            string s = selection.Document;
            save(s);

        }

        private void buttonSaveScheme_Click(object sender, EventArgs e)
        {
            if (prepSave())
            {
                return;
            }
            string s = selection.Document;
            save(s);

        }

    }
}