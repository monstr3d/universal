using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Interfaces;
using System.Xml;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// Editor of aliases
    /// </summary>
    public partial class UserControlAliasEdit : UserControl
    {
        #region Fields

        IDesktop desktop;

        Dictionary<string, object> types;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlAliasEdit()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Desktop
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDesktop Desktop
        {
            get
            {
                return desktop;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                desktop = value;
                Fill();
            }
        }

        #endregion

        #region Private Members
        void Fill()
        {
            types = desktop.GetAllAliasTypes();
            dataGridView.ColumnCount = 2;
            dataGridView.Columns[0].Name = "N";
            dataGridView.Columns[1].Name = "Name";
            List<string> l = new List<string>(types.Keys);
            l.Sort();
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Alias";
            cmb.MaxDropDownItems = l.Count;
            foreach (string s in l)
            {
                cmb.Items.Add(s);
            }
            dataGridView.Columns.Add(cmb);
        }


        void FillSample()
        {
            dataGridView.ColumnCount = 3;
            dataGridView.Columns[0].Name = "Product ID";
            dataGridView.Columns[1].Name = "Product Name";
            dataGridView.Columns[2].Name = "Product Price";

            string[] row = new string[] { "1", "Product 1", "1000" };
            dataGridView.Rows.Add(row);
            row = new string[] { "2", "Product 2", "2000" };
            dataGridView.Rows.Add(row);
            row = new string[] { "3", "Product 3", "3000" };
            dataGridView.Rows.Add(row);
            row = new string[] { "4", "Product 4", "4000" };
            dataGridView.Rows.Add(row);

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Select Data";
            cmb.Name = "cmb";
            cmb.MaxDropDownItems = 4;
            cmb.Items.Add("True");
            cmb.Items.Add("False");
            dataGridView.Columns.Add(cmb);

        }

        void Save()
        {
            string[] s = new string[] { "Number", "Name", "Alias" };
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Root/>");
            XmlElement r = doc.DocumentElement;
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                string p = dataGridView[2, i].FormattedValue + "";
                if (!types.ContainsKey(p))
                {
                    continue;
                }
                XmlElement ep = doc.CreateElement("Item");
                r.AppendChild(ep);
                for (int j = 0; j < 3; j++)
                {
                    DataGridViewCell cell = dataGridView[j, i];
                    XmlElement e = doc.CreateElement(s[j]);
                    ep.AppendChild(e);
                    e.InnerText = cell.FormattedValue + "";
                }
                Type ty = types[p].GetType();
                XmlElement et = doc.CreateElement("Type");
                et.InnerText = ty + "";
                ep.AppendChild(et);
            }
            this.SaveXml(doc);
        }



        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        #endregion

    }
}
