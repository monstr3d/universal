using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using DataSetService;
using ResourceService;

namespace DataSetService.Forms
{

    /// <summary>
    /// Data set editor form
    /// </summary>
    public partial class FormDataSet : Form
    {
        private IDataSetDesktopFactory factory;
        IDataSetDesktop desktop;
        PanelDataSet panel;
        IDataSetFactory dataFactory;
        string connectionString;
        private FormDataSet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="factory">Desktop facr\tory</param>
        /// <param name="dataFactory">Data set factorty</param>
        /// <param name="connectionString">Connection string</param>
        public FormDataSet(IDataSetDesktop desktop, 
            IDataSetDesktopFactory factory, 
            IDataSetFactory dataFactory, string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.dataFactory = dataFactory;
            ResourceService.Resources.LoadControlResources(this, DataSetService.Forms.Utils.ControlUtilites.Resources);
            this.factory = factory;
            if (desktop == null)
            {
                createDesktop();
            }
            else
            {
                this.desktop = desktop;
            }
            try
            {
                createPanel();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Desktop
        /// </summary>
        public IDataSetDesktop Desktop
        {
            get
            {
                return desktop;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            desktop = factory.Copy(panel);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            panelCenter.Controls.Remove(panel);
            createDesktop();
            createPanel();
        }

        private void createDesktop()
        {
            DbConnection connection = dataFactory.Connection;
            connection.ConnectionString = connectionString + "";
            DataSet dataSet = dataFactory.GetData(connection);
            DataSetSerializable.DataDesktopSerializable desk = new DataSetSerializable.DataDesktopSerializable();
            desktop = desk.Create(dataSet);
        }

        private void createPanel()
        {
            panel = PanelDataSet.Load(desktop);
            panel.BackColor = Color.White;
            panel.Dock = DockStyle.Fill;
            panelCenter.Controls.Add(panel);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogDgm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            Stream stream = File.OpenRead(openFileDialogDgm.FileName);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                object o = bf.Deserialize(stream);
                if (!(o is IDataSetDesktop))
                {
                    return;
                }
                desktop = o as IDataSetDesktop;
                panelCenter.Controls.Clear();
                createPanel();
            }
            catch (Exception)
            {
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialogDgm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            Stream stream = File.OpenWrite(saveFileDialogDgm.FileName);
            BinaryFormatter bf = new BinaryFormatter();
            desktop = factory.Copy(panel);
            bf.Serialize(stream, desktop);
        }

        private void toolStripButtonOpem_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonSaveAs_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void generateScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialogScript.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            Dictionary<string, ITable> t = desktop.Tables;
            StreamWriter stream = new StreamWriter(saveFileDialogScript.FileName);
            foreach (ITable table in t.Values)
            {
                List<string> l = dataFactory.GenerateScript(table);
                foreach (string s in l)
                {
                    stream.WriteLine(s);
                }
                stream.WriteLine("");
            }
            stream.Close();
        }
    }
}