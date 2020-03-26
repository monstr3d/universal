using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace Error.UI.Forms
{
    public partial class FormMessages : DockContent
    {
        public FormMessages()
        {
            InitializeComponent();
            Init();
         }

        public void Add(string[] str)
        {
            userControlMessages.Add(str);
        }

        private void Init()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            AllowDrop = true;

             this.DockAreas = (DockAreas)(((((DockAreas.Float |  DockAreas.DockRight)
                | DockAreas.DockTop)
                | DockAreas.DockBottom)));
            this.ClientSize = new System.Drawing.Size(180, 300);
            this.DockPadding.Bottom = 3;
            this.DockPadding.Top = 3;
            this.HideOnClose = true;
            this.Name = "Messages";
            this.ShowHint = DockState.DockBottom;
            this.Text = "Warnings";

        }

    }
}
