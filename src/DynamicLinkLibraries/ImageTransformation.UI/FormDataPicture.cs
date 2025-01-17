using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CategoryTheory;
using Diagram.UI;
using DataPerformer;
using ColorUI;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;
using ErrorHandler;

namespace ImageTransformations
{
    public partial class FormDataPicture : Form, IUpdatableForm, IBoxArray
    {
        private IObjectLabel label;
        private DataPicture data;
        PanelBitmap p = new PanelBitmap();
        private ComboBox[] inb;
        private IBoxArray ba;
        private Control pb;

        private FormDataPicture() 
        {
            InitializeComponent();
        }

        public FormDataPicture(IObjectLabel label)
        {
            InitializeComponent();
            ResourceService.Resources.LoadControlResources(this, ControlUtilites.Resources);
            this.label = label;
            Text = label.Name;
            data = label.Object as DataPicture;
            p.Drawing = data;
            panelDraw.Controls.Add(p);
            p.Dock = DockStyle.Fill;
            inb = new ComboBox[] { comboBoxX, comboBoxY };
            pb = panelDesktopCenter;
            change();
            checkBoxEQ.Checked = data.EqualSize;
            checkBoxProp.Checked = data.Proportional;
            checkBoxC.Checked = data.Colored;
            select();
        }


        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        #region IBoxArray Members

        ComboBox[] IBoxArray.Boxes
        {
            get { return inb; }
        }

        #endregion


        void fill()
        {
            List<string> al = data.AllAliases;
            ControlUtilites.FillCombo(this, al);
            List<string> m = data.AllMeasures;
            ControlUtilites.FillCombo(ba, m);
        }

        void select()
        {
            List<string> al = data.Aliases;
            ControlUtilites.SelectCombo(this, al);
            List<string> m = data.Measures;
            ControlUtilites.SelectCombo(ba, m);
        }

        void setBox()
        {
            if (data.Colored)
            {
                ba = new ColoredChooser();
            }
            else
            {
                ba = new SimpleIntesity();
            }
            Control c = ba as Control;
            c.Left = 0;
            c.Top = 0;
            pb.Controls.Add(c);
            fill();
        }

        void change()
        {
            if (ba == null)
            {
                setBox();
                return;
            }
            if (correspond)
            {
                return;
            }
            Control c = ba as Control;
            pb.Controls.Remove(c);
            setBox();
        }



        bool correspond
        {
            get
            {
                return ((data.Colored & ba is ColoredChooser) |
                    (!data.Colored & ba is SimpleIntesity));
            }
        }

        void accept()
        {
            try
            {
                List<string> al = ControlUtilites.GetSelected(inb);
                List<string> mea = ControlUtilites.GetSelected(ba);
                data.Set(mea, al);
                p.ForceRefresh();
            }
            catch (Exception e)
            {
                e.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            accept();
        }

        private void checkBoxProp_CheckedChanged(object sender, EventArgs e)
        {
            data.Proportional = checkBoxProp.Checked;
            p.ForceRefresh();
        }

        private void checkBoxEQ_CheckedChanged(object sender, EventArgs e)
        {
            data.EqualSize = checkBoxEQ.Checked;
            p.ForceRefresh();
        }

        private void checkBoxC_CheckedChanged(object sender, EventArgs e)
        {
            data.Colored = checkBoxC.Checked;
            change();
            p.ForceRefresh();
        }

        private void checkBoxRainBow_CheckedChanged(object sender, EventArgs e)
        {
            data.RainBow = checkBoxRainBow.Checked;
            change();
            p.ForceRefresh();
        }

    }
}