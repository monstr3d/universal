using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

namespace Diagram.UI.Forms
{
    /// <summary>
    /// Container form
    /// </summary>
    public partial class FormContainer : Form, IUpdatableForm
    {
        IObjectLabel label;

        ObjectContainer container;

        private FormContainer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Label</param>
        public FormContainer(IObjectLabel label)
            : this()
        {
            this.label = label;
            container = label.Object as ObjectContainer;
            this.UpdateFormUI();
        }

        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        void Save()
        {
            using (Stream stream = File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + label.Kind))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, container);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
