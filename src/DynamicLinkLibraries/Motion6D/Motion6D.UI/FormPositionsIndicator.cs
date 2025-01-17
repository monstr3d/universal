using System;
using System.Windows.Forms;


using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using Motion6D.Drawing.Interfaces;

using ErrorHandler;

namespace Motion6D.UI
{
    /// <summary>
    /// Editor of position indicator properties
    /// </summary>
    public partial class FormPositionsIndicator : Form, IUpdatableForm, IRedraw
    {
        private PositionCollectionIndicator indicator;
        private IPointsIndicator pIndicator;
        private IObjectLabel label;


        private FormPositionsIndicator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Object label</param>
        public FormPositionsIndicator(IObjectLabel label)
        {
            InitializeComponent();
            this.label = label;
            indicator = label.Object as PositionCollectionIndicator;
            string[] s = SimplePointsIdicator.Indicator[indicator];
            comboBoxType.FillCombo(s);
            Text = label.Name;
        }

        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string s = comboBoxType.SelectedItem + "";
                if (s.Length == 0)
                {
                    return;
                }
                if (pIndicator != null)
                {
                    Control cont = pIndicator as Control;
                    panelChart.Controls.Remove(cont);
                }
                pIndicator = SimplePointsIdicator.Indicator[s];
                pIndicator.Positions = indicator;
                Control c = pIndicator as Control;
                panelChart.Controls.Add(c);
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }

        #region IRedraw Members

        void IRedraw.Redraw()
        {
            if (pIndicator != null)
            {
                if (pIndicator is IRedraw)
                {
                    IRedraw r = pIndicator as IRedraw;
                    r.Redraw();
                }
            }
        }

        #endregion
    }
}