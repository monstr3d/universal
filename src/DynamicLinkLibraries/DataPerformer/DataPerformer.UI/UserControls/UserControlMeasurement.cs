﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DataPerformer.UI.UserControls
{
    public partial class UserControlMeasurement : UserControl
    {
        public UserControlMeasurement()
        {
            InitializeComponent();
        }

        public Color[] Color
        {
            get => checkBoxName.Checked ? [comboBoxColorPicker.Color] : null;
            set => SetColor(value);
        }

        public string MeasurementName
        {
            set => checkBoxName.Text = value;
        }

        void SetColor(Color[] color)
        {
            if (color == null)
            {
                checkBoxName.Checked = false;
                return;
            }
            checkBoxName.Checked = true;
            comboBoxColorPicker.Color = color[0];
        }
    }

}