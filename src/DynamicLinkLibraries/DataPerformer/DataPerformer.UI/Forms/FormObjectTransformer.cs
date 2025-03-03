using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DataPerformer;
using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using DataPerformer.Interfaces;
using Diagram.UI.Interfaces;
using ErrorHandler;

namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// Editor of properties of object transformer
    /// </summary>
    public partial class FormObjectTransformer : Form, IUpdatableForm
    {
        IObjectLabel label;
        ObjectTransformer transformer;
        Panel pCombo;
        private FormObjectTransformer()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Object label</param>
        public FormObjectTransformer(IObjectLabel label) :
            this()
        {
            pCombo = panelCenter;
            this.label = label;
            Text = label.Name;
            transformer = label.Object as ObjectTransformer;
            createCombo();
            fill();
            select();
        }

        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion


        private void createCombo()
        {
            IObjectTransformer t = transformer.Transformer;
            string[] ins = t.Input;
            userControlComboboxList.Count = ins.Length;
            userControlComboboxList.Texts = ins;
     /*       for (int i = 0; i < ins.Length; i++)
            {
                userControlComboboxList.Texts[i] = ins[i];
            }*/
        }

        private void fill()
        {
            List<string> l = transformer.AllMeasurements;
            List<ComboBox> list = userControlComboboxList.Boxes;
            foreach (ComboBox box in list)
            {
                box.FillCombo(l);
            }
        }

        private void accept()
        {
            try
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                string[] t = userControlComboboxList.Texts;
                List<ComboBox> l = userControlComboboxList.Boxes;
                for (int i = 0; i < t.Length; i++)
                {
                    ComboBox box = l[i];
                    string s = box.SelectedItem + "";
                    d[t[i]] = s;
                }
                transformer.Links = d;
            }
            catch (Exception exception)
            {
                exception.HandleException(10);
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            accept();
        }

        private void select()
        {
            Dictionary<string, string> links = transformer.Links;
            string[] t = userControlComboboxList.Texts;
            List<ComboBox> l = userControlComboboxList.Boxes;
            foreach (string key in links.Keys)
            {
                for (int i = 0; i < t.Length; i++)
                {
                    if (t[i].Equals(key))
                    {
                        l[i].SelectCombo(links[key]);
                        break;
                    }
                }
                string name = links[key];
            }
        }
    }
}