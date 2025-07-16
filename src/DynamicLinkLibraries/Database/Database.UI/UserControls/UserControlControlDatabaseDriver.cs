using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using DataSetService;

namespace Database.UI.UserControls
{
    public partial class UserControlControlDatabaseDriver : UserControl
    {

        #region Fields

        StatementWrapper wrapper;

        #endregion

        #region Ctor
        
        public UserControlControlDatabaseDriver()
        {
            InitializeComponent();
        }

        #endregion


         [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal StatementWrapper Wrapper
        {
            get
            {
                return wrapper;
            }
            set
            {
                wrapper = value;
                setProvider();
            }
        }

        internal void Set()
        {
            wrapper.ConnecionString = textBoxConnection.Text;
            if (comboBoxDatabaseDriver.SelectedItem != null)
            {
                string s = comboBoxDatabaseDriver.SelectedItem + "";
                wrapper.FactoryName = s;
            }
        }

        private void setProvider()
        {
            ///string st = provider.Statement;
            string conn = wrapper.ConnecionString;
            if (conn != null)
            {
                textBoxConnection.Text = conn;
            }

            string driver = wrapper.FactoryName;
            string[] d = DataSetFactoryChooser.Chooser.Names;
            foreach (string sd in d)
            {
                comboBoxDatabaseDriver.Items.Add(sd);
            }
            if (driver != null)
            {
                for (int i = 0; i < d.Length; i++)
                {
                    if (driver.Equals(d[i]))
                    {
                        comboBoxDatabaseDriver.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }
}