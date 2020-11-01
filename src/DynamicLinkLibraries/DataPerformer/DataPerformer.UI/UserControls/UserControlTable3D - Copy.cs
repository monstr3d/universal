using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;


using DataPerformer;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Editor of 3D table
    /// </summary>
    public partial class UserControlTable3D : UserControl
    {
        #region Fields

        Table3D table = null;

        #endregion

        #region Ctor
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlTable3D()
        {
            InitializeComponent();
        }

        #endregion

        internal Table3D Table
        {
            set
            {
                table = value;
               ///!!! COMMENTS userControlCommentsFont.Comments = value.Comments;
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

                XElement doc = table.Xml;
                using (TextWriter w = new StreamWriter(saveFileDialogXml.FileName))
                {
                    w.Write(doc + "");
                }
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
                using (TextReader r = new StreamReader(openFileDialogXml.FileName))
                {
                    string s = r.ReadToEnd();
                    table.Xml = XElement.Parse(s);
                }
            }
            catch (Exception e)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }


        private void userControlCommentsFont_AcceptComments(System.Collections.ICollection comments)
        {
            table.Comments = comments;
        }

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
