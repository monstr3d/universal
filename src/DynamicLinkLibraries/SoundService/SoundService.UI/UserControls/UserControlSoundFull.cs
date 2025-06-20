using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoundService.UI.UserControls
{
    public partial class UserControlSoundFull : UserControl
    {

        #region Fields


        event Action<double, double, int> acceptTest = (double x, double y, int z) => {};

        #endregion

        #region Ctor

        public UserControlSoundFull()
        {
            InitializeComponent();
            userControlSoundCollection.OnAccept += () =>
            {
                acceptTest(Double.Parse(textBoxStart.Text), Double.Parse(textBoxStep.Text), Int32.Parse(textBoxStepCount.Text));
            };
        }

        #endregion

        #region Members

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        #endregion

        #region Members

        internal SoundCollection SoundCollection
        {
            set
            {
                userControlSoundCollection.SoundCollection = value;
            }
        }

        internal void Set(double start, double step, int stepCount)
        {
            textBoxStart.Text = start + "";
            textBoxStep.Text = step + "";
            textBoxStepCount.Text = stepCount + "";
            userControlSoundCollection.Post();
        }

        internal event Action<double, double, int> AcceptTest
        {
            add { acceptTest += value; }
            remove { acceptTest -= value; }
        }

        #endregion

    }
}
