using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using Event.Basic;
using Event.Log.Database;

namespace Event.UI.UserControls
{
    public partial class UserControlLog : UserControl, IPreparation
    {
        Portable.LogHolder log;

        List<string> history;

       
        Log.Database.UI.UserControls.UserControlDataBaseTreeSelect
                    select;

        public UserControlLog()
        {
            InitializeComponent();
            this.ForEach((Control control) =>
            {
                control.AllowDrop = true;
                control.DragDrop += UserControlLog_DragDrop;
                control.DragEnter += UserControlLog_DragEnter;
                control.DragLeave += UserControlLog_DragLeave;
            });
            toolStripMenuItemLogDirectory.Click += (object sender, EventArgs e) =>
            {
                StaticExtensionDiagramUIForms.OpenLogDirectory();
            };
            toolStripMenuItemConnectionString.Click += (object sender, EventArgs e) =>
            {
                StaticExtensionEventUI.EditConnectionSrtring(); 
            };

        }


        internal string FileName
        {
            set
            {
                userControlFileLog.FileName = value;
                userControlFileDataBaseLog.FileName = value;
            }
        }
  
        internal UserControlLog(List<string> history) : this()
        {
            this.history = history;
        }

        internal Portable.LogHolder Log
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                log = value;
                select = this.FindChild<Event.Log.Database.UI.UserControls.UserControlDataBaseTreeSelect>();
                if (select != null)
                {
                    select.Log = value;
                }
            /*    if (log.Length == 0)
                {
                    if (history.Contains(log.Url))
                    {
                        history.Remove(log.Url);
                    }
                }*/
                uint a = log.Begin + 1;
                toolStripTextBoxBegin.Text = a + "";
                a = log.End;
                if (a == 0)
                {
                    a = 1;
                }
                toolStripTextBoxEnd.Text = a + "";
                ShowLogName();
            }
        }


        private void Set()
        {
            try
            {
                uint a = (uint)int.Parse(toolStripTextBoxBegin.Text) - 1;
                log.Begin = a;
                a = (uint)int.Parse(toolStripTextBoxEnd.Text);
                if (a == 1)
                {
                    a = 0;
                }
                log.End = a;
                log.Prepare();
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }



        private void ShowSize()
        {
        }

        void ShowLogName()
        {
            FileName = log.Url;
            ShowSize();
            /*
            if (log.Log.Count == 0)
            {
                if (history.Contains(log.Url))
                {
                    history.Remove(log.Url);
                }
            }*/
 
        
         /*   if (log.Log.Count > 0)
            {
                if (!history.Contains(log.Url))
                {
                    history.Add(log.Url);
                    history.Sort();
                    comboBoxUrl.Items.Add(log.Url);
                    comboBoxUrl.SelectedIndex = comboBoxUrl.Items.Count - 1;
                }
            }*/
        }

        

   
        private string Url
        {
            get
            {
                return log.Url;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                if (Url.Equals(value))
                {
                    return;
                }
                log.Url = value;
            }
        }

        private string DetectUrl(DragEventArgs args)
        {
            IDataObject d = args.Data;
            if (d.GetDataPresent("FileDrop"))
            {
                string[] s = d.GetData("FileDrop") as string[];
                if (s.Length == 1)
                {
                    string str = s[0];
                    string ext = Path.GetExtension(str).ToLower();
                    if (ext.Equals(".zip") | ext.Equals(".serializable") | ext.Equals(".filelog"))
                    {
                        return str;
                    }
                }
            }
            return null;
        }

        private void UserControlLog_DragDrop(object sender, DragEventArgs e)
        {
            string s = DetectUrl(e);
            if (s != null)
            {
                Url = s;
                ShowLogName();
                ShowSize();
            }
        }


        private void UserControlLog_DragEnter(object sender, DragEventArgs e)
        {
            if (DetectUrl(e) != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void UserControlLog_DragLeave(object sender, EventArgs e)
        {

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        void SaveToFile()
        {
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            IPreparation p = this;
            p.Prepare();
            string fn = saveFileDialog.FileName;
            using (Stream stream = File.OpenWrite(fn))
            {
                
               // log.Reader.ToStream(stream, log.Begin, log.End);
            }
        }

        void IPreparation.Prepare()
        {
            Set();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {

        }

        private void UserControlLog_Load(object sender, EventArgs e)
        {
            if (StaticExtensionEventLogDatabase.ConnectionString.Length > 0)
            {
                userControlFileLog.Visible = false;
                userControlFileDataBaseLog.Visible = true;
            }
            if (log != null)
            {
                FileName = log.Url;
            }

            if (select == null)
            {
                select = 
                    this.FindChild<Log.Database.UI.UserControls.UserControlDataBaseTreeSelect>();
                if (select != null)
                {
                    select.Log = log;
                }

            }
        }
    }
}
