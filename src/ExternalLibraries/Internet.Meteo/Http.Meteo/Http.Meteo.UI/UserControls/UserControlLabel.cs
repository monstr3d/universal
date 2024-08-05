using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Http.Meteo.UI.UserControls
{
    public partial class UserControlLabel : UserControl
    {

        #region Fields

        object obj;

        PropertyInfo pi;

        PropertyInfo pin;

        PropertyInfo pt;

        string html;

        static private readonly DateTime baseTime = new DateTime(2000, 1, 1);

        #endregion


        public UserControlLabel()
        {
            InitializeComponent();
        }

        internal object Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
                pi = obj.GetType().GetProperty("Url");
                pin = obj.GetType().GetProperty("Html");
                pt = obj.GetType().GetProperty("TimeSpan");
                TimeSpan ts = (TimeSpan)pt.GetValue(obj);
                textBoxInterval.Text = ts + "";

            }
        }

        private void textBoxInterval_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    pt.SetValue(obj, TimeSpan.Parse(textBoxInterval.Text));
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

    }
}
