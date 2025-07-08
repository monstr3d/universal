using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diagram.UI.Interfaces;
using WeifenLuo.WinFormsUI.Docking;

namespace BasicEngineering.UI.Factory.Advanced.Forms
{
    public partial class FormAliasEdit : DockContent
    {
        public FormAliasEdit()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            AllowDrop = true;

            this.DockAreas = ((DockAreas)(((((DockAreas.Float | DockAreas.DockLeft)
                | DockAreas.DockRight)
                | DockAreas.DockTop)
                | DockAreas.DockBottom)));
            this.DockPadding.Bottom = 3;
            this.DockPadding.Top = 3;
            this.HideOnClose = true;
            this.Name = "Objects";
            this.ShowHint = DockState.DockLeft;

        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDesktop Desktop
        {
            get
            {
                return userControlAliasEdit.Desktop;
            }
            set
            {
                userControlAliasEdit.Desktop = value;
            }
        }

    }
}
