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
using Event.UI.Labels;
using ErrorHandler;

namespace Event.UI.UserControls
{
    public partial class UserControlThreshold : UserControl, IPostSet
    {

         ThresholdEvent ev;


        internal ThresholdEvent Event
        {
            set
            {
                ev = value;
                dc = value;
                ThresholdEventLabel l = this.FindParent<ThresholdEventLabel>();
                if (l !=null)
                {
                    if (!l.isSerialized)
                    {
                        dc.OnChangeInput += Fill;
                    }
                }
            }
        }

        IDataConsumer dc;

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
                dc.OnChangeInput += Fill;
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
            var m = ev.GetAllMeasurements(ev.Type);
            cb.FillCombo(m);
            var s = ev.Measurement;
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
                    ev.Measurement = cb.SelectedItem + "";
                    ev.Set();
                }
            };
        }
     }
}
