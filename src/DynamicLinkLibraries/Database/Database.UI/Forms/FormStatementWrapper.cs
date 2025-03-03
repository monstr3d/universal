using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



using DataSetService;
using Diagram.UI.Labels;
using Diagram.UI;
using DataSetService.Forms;
using DataPerformer.UI.UserControls;
//using DataSetWeb;
using ResourceService;
using Database.UI.UserControls;
using DataPerformer.UI;
using Diagram.UI.Interfaces;
using Database.UI.Labels;
using ErrorHandler;

namespace Database.UI.Forms
{
    public partial class FormStatementWrapper : Form, IUpdatableForm
    {
        IObjectLabel label;

        StatementWrapper provider;

        UserControlControlDatabaseDriver udd;
      //!!!TEMP  UserControlControlDatabaseDriverWeb uddw;

        Action showNumberDelegate;

        Action<bool> showTableDelegate;

        private bool show;

        private FormStatementWrapper()
        {
            InitializeComponent();
        }

        public FormStatementWrapper(IObjectLabel label, bool show, 
            Action showNumber, Action<bool> showTable)
            : this()
        {
            ResourceService.Resources.LoadControlResources(this, Database.UI.Utils.ControlUtilites.Resources);
            this.label = label;
            provider = label.Object as StatementWrapper;
            this.showNumberDelegate = showNumber;
            this.showTableDelegate = showTable;
            this.show = show;
            if (provider.GetType().Equals(typeof(StatementWrapper)))
            {
                udd = new UserControlControlDatabaseDriver();
                udd.Dock = DockStyle.Fill;
                ResourceService.Resources.LoadControlResources(udd, Database.UI.Utils.ControlUtilites.Resources);
                udd.Wrapper = provider;
                panelDriver.Controls.Add(udd);
            }
            UpdateFormUI();
            setProvider();
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

        private void setProvider()
        {
            string st = provider.Statement;
            if (st != null)
            {
                textBoxStatement.Text = st;
            }
            Dictionary<string, string> dic = provider.Parameters;
            List<string> keys = new List<string>(dic.Keys);
            keys.Sort();
            foreach (string key in keys)
            {
                object[] o = new object[] { key, dic[key] };
                dataTableParameters.Rows.Add(o);
            }
            accept();
            checkBoxShowData.Checked = show;
        }


        private void setParametres()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (DataRow row in dataTableParameters.Rows)
            {
                d[row[0] + ""] = row[1] + "";
            }
            provider.Parameters = d;
        }

        private void accept()
        {
            DataSet dataSet = provider.DataSet;
            if (dataSet == null)
            {
                return;
            }
            if (dataSet.Tables.Count == 0)
            {
                return;
            }
            int n = dataSet.Tables[0].Rows.Count;
            labelNumber.Text = ResourceService.Resources.GetControlResource("Number of rows: ",
                Database.UI.Utils.ControlUtilites.Resources) + n;
            if (showNumberDelegate != null)
            {
                showNumberDelegate();
            }
            showTable();
            
        }

        private void showTable()
        {
            if (showTableDelegate != null)
            {
                showTableDelegate(checkBoxShowData.Checked);
            }

            DataSet dataSet = provider.DataSet;
            if (!checkBoxShowData.Checked)
            {
                dataGridViewTable.DataSource = null;
                return;
            }
            if (dataSet != null)
            {
                if (dataSet.Tables.Count > 0)
                {
                    dataGridViewTable.DataSource = dataSet.Tables[0];
                }
                else
                {
                    dataGridViewTable.DataSource = null;
                }
            }
        }

        private void showDiagram()
        {
            try
            {
                if (provider == null)
                {
                    return;
                }
                IDataSetDesktop desktop = provider.Desktop;
                IDataSetFactory factory = DataSetFactoryChooser.Chooser[provider.FactoryName];
                DataSetService.Forms.FormDataSet form = 
                    new DataSetService.Forms.FormDataSet(desktop, 
                    new DataSetSerializable.DataDesktopSerializable(), factory, provider.ConnecionString);
                form.ShowDialog(this);
                desktop = form.Desktop;
                if (desktop != null)
                {
                    provider.Desktop = desktop;
                    string st = factory.GenerateStatement(desktop);
                    textBoxStatement.Text = st;
                }
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }

        private void saveData()
        {
            DataSet ds = provider.DataSet;
            this.SaveDataSet(ds);
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (udd != null)
            {
                udd.Set();
            }
            provider.Statement = textBoxStatement.Text;
            setParametres();
            provider.Update();
            accept();
            showNumberDelegate();
            showTableDelegate(checkBoxShowData.Checked);
        }

        private void buttonDiagram_Click(object sender, EventArgs e)
        {
            showDiagram();
        }

        private void checkBoxShowData_Click(object sender, EventArgs e)
        {
            showTable();
            showTableDelegate(checkBoxShowData.Checked);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ResourceService.Resources.ShowDialog(this, Database.UI.Utils.ControlUtilites.Resources,
                openFileDialogData) != DialogResult.OK)
            {
                return;
            }
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(openFileDialogData.FileName);
                XmlElement el = doc.DocumentElement;
                string driver = el.Attributes["driver"].Value;
                string connection = el.Attributes["connection"].Value;
                string query = el.Attributes["query"].Value;
                IDataSetFactory factory = DataSetFactoryChooser.Chooser[driver];
                provider.Factory = factory;
                provider.FactoryName = driver;
                provider.ConnecionString = connection;
                provider.Statement = query;
              //  setProvider();
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, ex.Message);
            }
        }

        

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ResourceService.Resources.ShowDialog(this,
               Database.UI.Utils.ControlUtilites.Resources, saveFileDialogData) != DialogResult.OK)
            {
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<?xml version=\"1.0\"?><Root></Root>");
            XmlElement el = doc.DocumentElement;
            XmlAttribute attr = doc.CreateAttribute("driver");
            attr.Value = provider.FactoryName;
            el.Attributes.Append(attr);
            attr = doc.CreateAttribute("connection");
            attr.Value = provider.ConnecionString;
            el.Attributes.Append(attr);
            attr = doc.CreateAttribute("query");
            attr.Value = provider.Statement;
            el.Attributes.Append(attr);
            doc.Save(saveFileDialogData.FileName);
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
           // saveasToolStripMenuItem_Click(sender, e);
            saveData();
        }

        private void generateCreationScriptToolStripMenuItem_Click(object sender, EventArgs e)
       {
  /*          DataSet data = provider.Factory.GetData(provider.ConnecionString);
            //XmlDataDocument doc = new XmlDataDocument(data);
           // doc.Save("data.xml");
            List<string> l = GenerateScript(data);
            System.IO.StreamWriter wr = new System.IO.StreamWriter("1.sql");
            foreach (string s in l)
            {
                wr.WriteLine(s);
            }
            wr.Close();*/
           saveData();
        }

        private List<string> GenerateScript(DataSet dataSet)
        {
            DataTable table = dataSet.Tables[0];
            Dictionary<string, Dictionary<int, DataRow>> dictionary = new Dictionary<string, Dictionary<int, DataRow>>();
            foreach (DataRow row in table.Rows)
            {
                string tableName = "[" + row["TABLE_SCHEMA"] + "].[" + row["TABLE_NAME"] + "]";
                Dictionary<int, DataRow> dic = null;
                if (dictionary.ContainsKey(tableName))
                {
                    dic = dictionary[tableName];
                }
                else
                {
                    dic = new Dictionary<int, DataRow>();
                    dictionary[tableName] = dic;
                }
                int num = (int)row["ORDINAL_POSITION"];
                dic[num] = row;
            }
            List<string> list = new List<string>();
            foreach (string key in dictionary.Keys)
            {
                Dictionary<int, DataRow> rows = dictionary[key];
                list.Add("CREATE TABLE " + key);
                list.Add("(");
                int n = rows.Count;
                int i = 0;
                List<int> ld = new List<int>(rows.Keys);
                ld.Sort();
                foreach (int k in ld)
                {
                    ++i;
                    DataRow row = rows[k];
                    string s = row["COLUMN_NAME"] + " ";
                    string type = row["DATA_TYPE"] + "";
                    if (type.Equals("char") | type.Equals("nchar"))
                    {
                        s += "char(" + row["CHARACTER_MAXIMUM_LENGTH"] + ")";
                    }
                    if (type.Equals("int"))
                    {
                        s += "int";
                    }
                    if (type.Equals("float"))
                    {
                        s += "float(" + row["NUMERIC_PRECISION"] + ")";
                    }
                    if (type.Equals("uniqueidentifier"))
                    {
                        s += "uniqueidentifier";
                    }
                    if (type.Equals("image"))
                    {
                        s += "image";
                    }
                    string nu = row["IS_NULLABLE"] + "";
                    if (nu.Equals("NO"))
                    {
                        s += " NOT NULL";
                    }
                    if (i < n)
                    {
                        s += ",";
                    }
                    list.Add(s);
                }
                list.Add(");");
                list.Add("");
            }
            return list;
        }

        private void exportTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveData();
        }

     }
}