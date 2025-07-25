﻿using DataPerformer.Event.Portable.Objects.BufferedData;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DataPerformer.UI.BufferedData.UserControls
{
    public partial class UserControlBufferReadWriteFull : UserControl
    {
        UserControlBufferReadWrite uc = null;

        BufferReadWrite buffer;

        public UserControlBufferReadWriteFull()
        {
            InitializeComponent();
            tabControlMain.SelectedIndex = 1;
        }

        private void UserControlBufferReadWriteFull_Load(object sender, EventArgs e)
        {
            uc = new UserControlBufferReadWrite();
            uc.Dock = DockStyle.Fill;
            panelSelect.Controls.Add(uc);
            UserControlEditDatadase edit = new UserControlEditDatadase();
            panelEdit.Controls.Add(edit);
            if (buffer != null)
            {
                uc.Buffer = buffer;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal BufferReadWrite Buffer
        {
            set
            {
                buffer = value;
                if (uc != null)
                {
                    uc.Buffer = value;
                }
            }
        }

    }
}
