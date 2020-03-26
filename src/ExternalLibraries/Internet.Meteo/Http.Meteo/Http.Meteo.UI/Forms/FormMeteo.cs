using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;


namespace Http.Meteo.UI.Forms
{
    public partial class FormMeteo : Form, IUpdatableForm
    {
        #region Fields

        object service;

        #endregion

        #region Ctor

        private FormMeteo()
        {
            InitializeComponent();
        }

        public FormMeteo(object obj)
            : this()
        {
            service = obj;
            userControlMeteo.Object = obj;
        }

        #endregion

        public void UpdateFormUI()
        {
            IAssociatedObject ao = service as IAssociatedObject;
            object o = ao.Object;
            if (o == null)
            {
                return;
            }
            IObjectLabel l = o as IObjectLabel;
            Text = l.Name;
        }
  
    }
}
