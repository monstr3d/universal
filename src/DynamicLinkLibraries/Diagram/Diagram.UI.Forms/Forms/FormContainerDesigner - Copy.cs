using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



using CategoryTheory;
using ResourceService;
using Diagram.UI.Labels;

using Diagram.UI.Interfaces;


namespace Diagram.UI.Forms
{
    /// <summary>
    /// Designer of containers
    /// </summary>
    public partial class FormContainerDesigner : Form
    {
        #region Fields

        #endregion

        #region Ctor

        private FormContainerDesigner()
        {
            InitializeComponent();
        }

        private FormContainerDesigner(IDesktop desktop)
            : this()
        {
            this.LoadControlResources(
                new Dictionary<string, object>[]
                {
                Resources.ControlResources
                }
                );
            userControlContainerDesigner.Desktop = desktop;
        }

        #endregion

        /// <summary>
        /// Shows designer
        /// </summary>
        /// <param name="active">Active desktop</param>
        /// <param name="formContainer">Container form</param>
        static public void Show(IDesktop active, ref FormContainerDesigner formContainer)
        {

            if (formContainer == null)
            {
                formContainer = new FormContainerDesigner(active);
            }
            else
            {
                if (formContainer.IsDisposed)
                {
                    formContainer = new FormContainerDesigner(active);
                }
            }
            formContainer.Show();
        }

    }
}
