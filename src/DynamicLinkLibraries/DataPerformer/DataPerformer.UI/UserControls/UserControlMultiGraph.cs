using Animation.Interfaces.Enums;
using Chart.UserControls;
using DataPerformer.UI.Labels;
using Diagram.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsExtensions;

namespace DataPerformer.UI.UserControls
{
    public partial class UserControlMultiGraph : UserControl
    {

        private List<Dictionary<string, Color[]>> dictionary = null;

        private GraphLabel label;
        DataConsumer consumer;

        UserControlFilledChart[] charts;

        UserControlMeasurements[] measurements;


        public UserControlMultiGraph()
        {
            InitializeComponent();
        }

        internal GraphLabel Label
        {
            set
            {
                label = value;
                consumer = label.Object as DataConsumer;
                var l = this.FindChildren<UserControlMeasurements>();
                foreach ( var c in l )
                {
                    c.DataConsumer = consumer;
                }
                Dictionary = label.MultiSeries;
            }
        }

        private void ActParent(ActionType actionType, object obj)
        {
            Action<ActionType> act = (ActionType at) =>
            {
              /*!!!  if (label != null)
                {
                    label.Action(obj, at);
                }
                if (!StaticExtensionDataPerformerUI.IsRunning)
                {
                    actionType.EnableDisableButtons(startStopPauseButtons);
                }
                if (actionType == ActionType.Start)
                {
                    if (obj != null)
                    {
                        toolStripButtonPause.Enabled = false;
                    }
                }
                else if (actionType == ActionType.Stop)
                {
                    StaticExtensionDataPerformerUI.StopCurrentCalculation();
                }*/
            };
            this.InvokeIfNeeded(act, actionType);
        }

        private void StartControl(object type, ActionType actionType)
        {
           // actionType.EnableDisableButtons(startStopPauseButtons);
           // !!! StaticExtensionDiagramUIForms.Action(form, type, actionType);
        }



        internal List<Dictionary<string, Color[]>> Dictionary
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                dictionary = value;
                SetFirst();
            }
        }

        void SetFirst()
        {
            toolStripComboBoxNumber.SelectedIndex = dictionary.Count;
            toolStripComboBoxNumber.SelectedIndexChanged += ToolStripComboBoxNumber_SelectedIndexChanged;
            Set();
        }

        private void ToolStripComboBoxNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n =  toolStripComboBoxNumber.SelectedIndex;
            var m = dictionary.Count;
            if (m == n)
            {
                return;
            }
            if (m > n)
            {
                dictionary.Add(new());
            }
            else
            {
                dictionary.RemoveAt(1);
            }
            Set();
            
        }

        void Set()
        {
            var one = dictionary.Count == 1;
            userControlChartDouble.Visible = !one;
            userControlFilledChart.Visible = one;
            userControlDoubleMeasurements.Visible = !one;
            userControlMeasurements.Visible = one;
            if (one)
            {
                charts = [userControlFilledChart];
                measurements = [userControlMeasurements];

            }
            else
            {
                charts = userControlChartDouble.FindChildren<UserControlFilledChart>().ToArray();
                measurements = 
                    userControlDoubleMeasurements.FindChildren<UserControlMeasurements>().ToArray();
            }
            for (int i = 0; i < charts.Length; i++)
            {
                measurements[i].Dictionary = dictionary[i].Convert();
            }
        }
    }
}
