using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Utils;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

using Event.Portable.Events;

namespace Event.UI.UserControls
{
    public partial class UserControlThreshold : UserControl, IPostSet
    {

        internal ThresholdEvent Event
        { get; set; }

        public UserControlThreshold()
        {
            InitializeComponent();
        }


        #region IPostSet Members

        void IPostSet.Post()
        {
            try
            {
                Fill();
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        #endregion

        void Fill()
        {
            ComboBox cb = userControlComboboxList.Boxes[1];
            var m = Event.GetAllMeasurements(Event.Type);
            cb.FillCombo(m);
            var s = Event.Measurement;
            cb.SelectCombo(s);
            Init();
        }

        void Init()
        {
            ComboBox cb = userControlComboboxList.Boxes[1];
            cb.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                if (cb.SelectedItem != null)
                {
                    Event.Measurement = cb.SelectedItem + "";
                    Event.Set();
                }
            };
        }

     }
}
