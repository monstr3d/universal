using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Diagram.UI.Utils;

using DataPerformer.Portable;
using DataPerformer.Interfaces;

namespace SoundService.UI.UserControls
{
    public partial class UserControlObject2SoundName : UserControl
    {
        #region Fields

        Object2SoundName conv;

        #endregion

        #region Ctor

        public UserControlObject2SoundName()
        {
            InitializeComponent();
        }

        #endregion

        #region Members

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        #endregion

        #region Members

        internal Object2SoundName Converter
        {
            set
            {
                conv = value;
            }
        }

        internal void Post()
        {
            if (conv == null)
            {
                return;
            }
            string[] inp = conv.Inputs;
            if (inp == null)
            {
                conv.OnChangeInput += SetNumber;
                return;
            }
            if (inp.Length == 0)
            {
                conv.OnChangeInput += SetNumber;
                return;
            }
            int n = inp.Length;
            numericUpDown.Value = n;
            for (int i = 0; i < n; i++)
            {
                userControlComboboxList.Boxes[i].SelectCombo(inp[i]);
            }
            conv.OnChangeInput += SetNumber;
        }

   
        void SetNumber()
        {
            int n = (int)numericUpDown.Value;
            userControlComboboxList.Count = n;
            string[] t = new string[n];
            for (int i = 0; i < n; i++)
            {
               t[i] = "Input " + (i + 1);
            }
            userControlComboboxList.Texts = t;
            if (conv == null)
            {
                return;
            }
            IDataConsumer dc = conv;
            ICollection<string> m = dc.GetAllMeasurementsType().Keys;
            for (int i = 0; i < n; i++)
            {
                userControlComboboxList.Boxes[i].FillCombo(m);
            }
        }

        #endregion

        #region Event Handlres

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            string[] s = userControlComboboxList.Strings;
            if (s == null)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal("Fill all items, plaese");
                return;
            }
            conv.Inputs = s;
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetNumber();
        }

        #endregion

    }
}
