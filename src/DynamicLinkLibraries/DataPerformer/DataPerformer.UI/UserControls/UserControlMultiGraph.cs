﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPerformer.UI.UserControls
{
    public partial class UserControlMultiGraph : UserControl
    {

        private List<Dictionary<string, Color>> dictionary = null;
        public UserControlMultiGraph()
        {
            InitializeComponent();
        }
    }
}