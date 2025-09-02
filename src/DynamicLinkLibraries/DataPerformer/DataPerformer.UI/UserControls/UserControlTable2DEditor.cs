using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

using CategoryTheory;

using Diagram.UI.Utils;


using DataPerformer.Portable;

using ErrorHandler;

namespace DataPerformer.UI.UserControls
{

    /// <summary>
    /// Editor of label
    /// </summary>
    public partial class UserControlTable2DEditor : UserControl
    {

        #region Fields

        private ComboBox[] boxes;

        private Action action;

        #endregion


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlTable2DEditor()
        {
            InitializeComponent();
            boxes = userControlComboboxList.Boxes.ToArray();
        }

        #endregion

        #region Members

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Action Action
        {
            set
            {
                action = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Table2D Table
        {
            get
            {
                return userControlTable2D.Table;
            }
            set
            {
                userControlTable2D.Table = value;
                fill();
                select();
                checkBoxBound.Checked = value.ThrowsOutOfRangeException;
                checkBoxBound.CheckedChanged += checkBoxBound_CheckedChanged;
            }
        }

        void accept()
        {
            try
            {
                string[] s = boxes.GetSelectedStringArray();
                Array.Copy(s, Table.Arguments, 2);
                IPostSetArrow p = Table;
                p.PostSetArrow();
                action();
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }

        }

        void fill()
        {
            Double a = 0;
            IList<string> s = Table.GetAllMeasurementsType(a);
            boxes.FillCombo(s);
        }

        void select()
        {
            boxes.SelectCombo(Table.Arguments);
        }

        void open()
        {
            userControlTable2D.Open();
        }

        void save()
        {
            userControlTable2D.Save();
        }

        void ExportToXml()
        {
            try
            {
                if (saveFileDialogXml.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                /*
                XmlDocument doc = Table.Xml;
                doc.Save(saveFileDialogXml.FileName);
                */
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
                using (TextReader r = new StreamReader(openFileDialog.FileName))
                {

                    Table.Xml = XElement.Parse(r.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }

        #endregion

        #region Event Handlers

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            open();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            save();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            accept();
        }


        private void checkBoxBound_CheckedChanged(object sender, EventArgs e)
        {
            Table.ThrowsOutOfRangeException = checkBoxBound.Checked;
        }
 
        #endregion

        private void exportToXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToXml();
        }

        private void importFromXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFromXml();
        }

    }
}
