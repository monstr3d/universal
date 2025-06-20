using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Utils;

using DataPerformer.Portable;

namespace SoundService.UI.UserControls
{
    public partial class UserControlMultiSound : UserControl
    {
        #region Fields

        MultiSound sound;

        #endregion


        #region Ctor
        public UserControlMultiSound()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        #endregion

        #region Internal

        internal MultiSound Sound
        {
            get
            {
                return sound;
            }
            set
            {
                sound = value;
                DataPerformer.Interfaces.IDataConsumer c = sound;
                c.OnChangeInput += Fill;
            }
        }

        internal void Post()
        {
            Fill();
        }

        private void Fill()
        {
            List<ComboBox> boxes = userControlComboboxList.Boxes;
            List<string> cond = sound.GetAllMeasurements(sound.GetDesktop(), false);
            boxes[0].FillCombo(cond);
            boxes[0].SelectCombo(sound.Condition);
            List<string> snd = sound.GetAllMeasurements(sound.GetDesktop(), "");
            boxes[1].FillCombo(snd);
            boxes[1].SelectCombo(sound.Sound);
        }


        #endregion

        #region Event Handlers

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            List<ComboBox> boxes = userControlComboboxList.Boxes;
            for (int i = 0; i < 2; i++)
            {
                object o = boxes[i].SelectedItem;
                if (o != null)
                {
                    string s = o + "";
                    if (i == 0)
                    {
                        sound.Condition = s;
                    }
                    else
                    {
                        sound.Sound = s;
                    }
                }
            }
        }

        #endregion
    }
}
