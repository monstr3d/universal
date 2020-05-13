using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Scada.Interfaces;


namespace Scada.Windows.UI.Sample
{
    public partial class FormMain : Form, IErrorHandler
    {

        #region Fields

        IScadaInterface scada;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void FormMain_Load(object sender, EventArgs e)
        {
            /* !!! TEST OF SCADA string p = @"D:\AUsers\1MySoft\CSharp\src\DynamicLinkLibraries\Scada\Scada.Windows.UI\Scada.Windows.UI.Sample\Resources\scada.xml";
            new EmptyScadaInterface(p);*/
            try
            {
                CreateScada();
                scada.ErrorHandler = this;
                this.Set(scada);
                scada.IsEnabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message);
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            scada.IsEnabled = false;
        }

        #endregion

        #region IErrorHandler Members

        void IErrorHandler.ShowError(Exception exception, object obj)
        {
            MessageBox.Show(this, exception.Message);
        }

        void IErrorHandler.ShowMessage(string message, object obj)
        {
            MessageBox.Show(this, message);
        }

        #endregion
    }
}
