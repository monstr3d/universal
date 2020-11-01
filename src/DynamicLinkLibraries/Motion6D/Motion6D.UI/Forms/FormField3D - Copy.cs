using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Diagram.UI;


using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using DataPerformer.Portable;
using DataPerformer.Interfaces;
using Motion6D.Portable;

namespace Motion6D.UI.Forms
{
    /// <summary>
    /// Editor of properties of 3D field
    /// </summary>
    public partial class FormField3D : Form, IUpdatableForm
    {
        #region Fields

        private static readonly string[] cl = new string[] { "X", "Y", "Z" };

        private static readonly Double a = 0;

        private IObjectLabel label;

        private PhysicalFieldBase field;

        private IDataConsumer consumer;

        private ComboBox[] coord;

        private List<ComboBox> outcoming = new List<ComboBox>();

        private Dictionary<ComboBox, CheckBox> cov = new Dictionary<ComboBox, CheckBox>();


        #endregion


        #region Ctor


        private FormField3D()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="label">Object label</param>
        /// <param name="field">Field</param>
        public FormField3D(IObjectLabel label, PhysicalFieldBase field)
            : this()
        {
            if (field is PhysicalField3D)
            {
                Control p = userControlFacet.Parent;
                p.Controls.Remove(userControlFacet);
                UserControls.UserControlCoordinatAliases uc =
                    new UserControls.UserControlCoordinatAliases();
                coord = uc.Coord;
                uc.Dock = DockStyle.Top;
                p.Controls.Add(uc);
            }
            this.label = label;
            this.field = field;
            consumer = field;
            UpdateFormUI();
            fillCoord();
            if (field.Output != null)
            {
                numericUpDownParameters.Value = field.Output.Length;
            }
        }

        #endregion


        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        void fillCoord()
        {
            List<string> l = consumer.GetAliases(a);
            foreach (ComboBox cb in coord)
            {
                cb.FillCombo(l);
            }
            selectCoord();
        }

        void selectCoord()
        {
            string[] s = field.Input;
            if (s == null)
            {
                return;
            }
            for (int i = 0; i < coord.Length; i++)
            {
                ComboBox cb = coord[i];
                if (s.Length <= i)
                {
                    break;
                }
                cb.SelectCombo(s[i]);
            }
        }

        void acceptFieldNumb()
        {
            int n = (int)numericUpDownParameters.Value;
            if (n == 0)
            {
                return;
            }
            IList<string> list = field.GetAllMeasurements();
            Panel p = panelFieldParameters;
            p.Controls.Clear();
            outcoming.Clear();
            cov.Clear();
            int y = 20;
            string[] outc = field.Output;
            for (int i = 0; i < n; i++)
            {
                Label l = new Label();
                l.Text = ResourceService.Resources.GetControlResource("Parameter", Motion6D.UI.Utils.ControlUtilites.Resources) + " " + (i + 1);
                l.Top = y;
                l.Left = 20;
                p.Controls.Add(l);
                CheckBox cb = new CheckBox();
                cb.Text = ResourceService.Resources.GetControlResource("Covariant", Motion6D.UI.Utils.ControlUtilites.Resources);
                cb.Top = y;
                cb.Left = l.Right + 40;
                p.Controls.Add(cb);
                ComboBox co = new ComboBox();
                outcoming.Add(co);
                cov[co] = cb;
                co.FillCombo(list);
                co.Top = l.Bottom + 5;
                co.Left = 20;
                co.Width = p.Width - co.Left - 20;
                p.Controls.Add(co);
                y = co.Bottom + 10;
            }
            fillOutc();
        }

        void fillOutc()
        {
            PhysicalField.Interfaces.IPhysicalField ph = field;
            string[] so = field.Output;
            if (so == null)
            {
                return;
            }
            for (int i = 0; i < outcoming.Count; i++)
            {
                ComboBox co = outcoming[i];
                if (i >= so.Length)
                {
                    break;
                }
                co.SelectCombo(so[i]);
                CheckBox cb = cov[co];
                cb.Checked = ph.GetTransformationType(i).Equals(Field3D_Types.CovariantVector);
            }
        }

        bool setAliases()
        {
            string[] s = new string[3];
            for (int i = 0; i < 3; i++)
            {
                ComboBox cb = coord[i];
                object it = cb.SelectedItem;
                if (it == null)
                {
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ResourceService.Resources.GetControlResource("Coorditate", Motion6D.UI.Utils.ControlUtilites.Resources) +
                        " " + cl[i] + " " + ResourceService.Resources.GetControlResource(" is not defined", Motion6D.UI.Utils.ControlUtilites.Resources));
                    return false;
                }
                s[i] = it + "";
            }
            field.Input = s;
            return true;
        }

        void setOut()
        {
            string[] s = new string[outcoming.Count];
            object[] o = new object[s.Length];
            for (int i = 0; i < outcoming.Count; i++)
            {
                ComboBox co = outcoming[i];
                object it = co.SelectedItem;
                if (it == null)
                {
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ResourceService.Resources.GetControlResource("Parameter", Motion6D.UI.Utils.ControlUtilites.Resources) +
                        " " + (i + 1) + " " + ResourceService.Resources.GetControlResource(" is not defined", Motion6D.UI.Utils.ControlUtilites.Resources));
                    return;
                }
                s[i] = it + "";
                CheckBox cb = cov[co];
                o[i] = cb.Checked ? Field3D_Types.CovariantVector : Field3D_Types.Invariant;
            }
            field.Output = s;
            field.TransformationTypes = o;
        }

        void apply()
        {
            try
            {
                if (setAliases())
                {
                    setOut();
                }
            }
            catch (Exception e)
            {
                e.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }

        private void numericUpDownParameters_ValueChanged(object sender, EventArgs e)
        {
            acceptFieldNumb();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            apply();
        }
    }
}