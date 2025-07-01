using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chart.Drawing.Interfaces;
using Chart.UserControls;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.UI.Interfaces;
using DataPerformer.UI.Labels;

using Diagram.UI;
using Diagram.UI.Interfaces;

using WindowsExtensions;
using System.ComponentModel;

namespace DataPerformer.UI.UserControls
{
    public partial class UserControlMultiGraph : UserControl, IStartStop
    {

        #region Fields

        object type;

        private List<Dictionary<string, Dictionary<string, Color>>> dictionary = null;

        private GraphLabel label;

        DataConsumer consumer;

        UserControlFilledChart[] charts;

        UserControlMeasurementCollection[] measurements;
        
        string arg = null;

        string[] variables = null;

        CancellationTokenSource ctx;

        Task<Dictionary<string, object>> pFixed;

        ToolStripButton[][] startStopPauseButtons;

        IStartStop ss;

        #endregion

        #region Cror

        public UserControlMultiGraph()
        {
            InitializeComponent();
            startStopPauseButtons = [[toolStripButtonStart], [toolStripButtonStop]];
        }

        #endregion

        #region Members

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        #endregion

        #region Members

        internal GraphLabel Label
        {
            set
            {
                label = value;
                ss = label;
                consumer = label.Object as DataConsumer;
                var l = this.FindChildren<UserControlMeasurementCollection>();
                var m = consumer.GetDataConsumerMeasurements();
                foreach (var c in l)
                {
                    c.DataConsumer = consumer;
                    c.Measurements = m;
                }
                Dictionary = label.MultiSeries;
                calculatorBoxStart.Text = consumer.StartTime + "";
                calculatorBoxStep.Text = consumer.Step + "";
                numericUpDownStepCount.Value = consumer.Steps;

            }
        }

        void SetValues()
        {
            double a = 0;

            if (double.TryParse(calculatorBoxStart.Text, out a))
            {
                consumer.StartTime = a;
            }
            if (double.TryParse(calculatorBoxStep.Text, out a))
            {
                consumer.Step = a;
            }
            consumer.Steps = (int)numericUpDownStepCount.Value;

        }

        private void ActParent(ActionType actionType, object obj)
        {
            Action<ActionType> act = (ActionType at) =>
            {
                if (label != null)
                {
                    ss.Action(obj, at);
                }
                if (!StaticExtensionDataPerformerUI.IsRunning)
                {
                    actionType.EnableDisableButtons(startStopPauseButtons);
                }
                if (actionType == ActionType.Pause)
                {
                    if (obj != null)
                    {
                        toolStripButtonPause.Enabled = false;
                    }
                }
                else if (actionType == ActionType.Stop)
                {
                    StaticExtensionDataPerformerUI.StopCurrentCalculation();
                }
            };
            this.InvokeIfNeeded(act, actionType);
        }

        private bool stop()
        {
            return ctx.Token.IsCancellationRequested;
        }

        private void StartControl(object type, ActionType actionType)
        {
            actionType.EnableDisableButtons(startStopPauseButtons);
            StaticExtensionDiagramUIForms.Action(null, type, actionType);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal List<Dictionary<string, Dictionary<string, Color>>> Dictionary
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
            if (dictionary.Count > 2)
            {
                while (dictionary.Count > 2)
                {
                    dictionary.RemoveAt(dictionary.Count - 1);
                }
            }
            toolStripComboBoxNumber.SelectedIndex = dictionary.Count -1;
            toolStripComboBoxNumber.SelectedIndexChanged += ToolStripComboBoxNumber_SelectedIndexChanged;
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
                    userControlDoubleMeasurements.FindChildren<UserControlMeasurementCollection>().ToArray();
            }
            for (int i = 0; i < charts.Length; i++)
            {
                var m = measurements[i];
                (measurements[i] as IColorDictionary).ColorDictionary = dictionary[i];
            }
        }

        void Start()
        {
            ctx = new();
            ActParent(ActionType.Start, global::Animation.Interfaces.Enums.ActionType.Calculation);
            SetValues();
            PefrormFixed();
        }

        Dictionary<string, object> FixedWork()
        {
            return consumer.PerformFixed(arg, variables, stop);
        }

        void FixedCompleted()
        {
            var p = pFixed.Result;
            Dictionary<IMeasurement, ISeries> dic = null;
            var dmea = consumer.GetMeasurementsInverseDictionary();
            Action action = () =>
            {
                for (int i = 0; i < charts.Length; i++)
                {
                    var chart = charts[i];
                    var m = measurements[i];
                    chart.Set(m, p, dmea, out dic);
                    measurements[i].Series = dic;
                }

            };
            this.InvokeIfNeeded(action);
            ActParent(ActionType.Stop, null);
        }

        void PefrormFixed()
        {
            dictionary.Clear();
            foreach (IColorDictionary item in measurements)
            {
                dictionary.Add(item.ColorDictionary);
            }
            var l = new List<string>();
            foreach (var item in dictionary)
            {
                foreach (var key in item.Keys)
                {
                    var a = item[key];
                    foreach (var value in a.Keys)
                    {
                        var s = key + "." + value;
                        if (!l.Contains(s))
                        {
                            l.Add(s);
                        }
                    }
                }
            }
            variables = l.ToArray();
            object o = comboBoxArg.SelectedItem;
            arg = "Time";
            if (o != null)
            {
                arg = o.ToString();
            }
            pFixed = new Task<Dictionary<string, object>>(FixedWork);
            pFixed.GetAwaiter().OnCompleted(FixedCompleted);
            try
            {
                pFixed.Start();
            }
            catch (Exception ex) 
            { 
            
            }

        }

        #endregion

        #region Event Handlers

        private void ToolStripComboBoxNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = toolStripComboBoxNumber.SelectedIndex + 1;
            var m = dictionary.Count;
            if (m == n)
            {
                return;
            }
            if (m < n)
            {
                dictionary.Add(new());
            }
            else
            {
                dictionary.RemoveAt(1);
            }
            Set();

        }


        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            ctx.Cancel();
        }

        #endregion

        #region IStartStop Members

        void IStartStop.Action(object type, ActionType actionType)
        {
            if (actionType == ActionType.Start)
            {
                this.type = type;
            }
            this.InvokeIfNeeded<object, ActionType>(StartControl, type, actionType);
        }

        #endregion

    }
}
