using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

using Scada.Interfaces;
using Scada.Wpf.Common.Convertes;

namespace Scada.WPF.UI.ScadaControls
{
    /// <summary>
    /// Text output for grid
    /// </summary>
    public class GridTextOutput : Grid, IScadaConsumer
    {
        #region Fields

        object[] ob;
   
        Func<object[]> output;

        Action action;

   
        IEvent eventObject;

        IScadaInterface scada;

        bool isEnabled;

        #endregion

        #region IScadaConsumer Members

        IScadaInterface IScadaConsumer.Scada
        {
            get
            {
                return scada;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                if (scada == null)
                {
                    CreateUI();
                }
                scada = value;
                if (eventObject != null)
                {
                    if (isEnabled)
                    {
                        eventObject.Event -= Set;
                    }
                }
                eventObject = scada[Event];
                List<string> n = new List<string>();
                foreach (Tuple<string, string> t in Output)
                {
                    n.Add(t.Item2);
                }
                output = scada.GetOutput(n.ToArray());
                foreach (string s in n)
                {
                    scada.AddEventOutput(Event, s);
                }
            }
        }

        bool IScadaConsumer.IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled == value)
                {
                    return;
                }
                isEnabled = value;
                if (value)
                {
                    eventObject.Event += Set;
                }
                else
                {
                    eventObject.Event -= Set;
                }
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Event
        /// </summary>
        [Browsable(true)]
        [TypeConverter(typeof(EventConverter))]
        [Category("SCADA"), Description("Event name"), DisplayName("Event")]
        public string Event
        {
            get;
            set;
        }

        /// <summary>
        /// Output
        /// </summary>
        [Browsable(true)]
        [Category("SCADA"), Description("Output"), DisplayName("Output")]
        public List<Tuple<string, string>> Output
        {
            get;
            set;
        }

        #endregion

        #region Private Methods

        void Set()
        {
            ob = output();
            action();
        }

        void CreateUI()
        {
            ColumnDefinition cc = new ColumnDefinition();
            base.ColumnDefinitions.Add(cc);
            cc.Width = System.Windows.GridLength.Auto;
            base.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < Output.Count; i++)
            {
                base.RowDefinitions.Add(new RowDefinition());
            }
            List<Action> labs = new List<Action>();
            for (int i = 0; i < Output.Count; i++)
            {
                Border b = new Border();
                b.BorderThickness = new System.Windows.Thickness(1);
                b.BorderBrush = new SolidColorBrush(Color.FromRgb(0x0, 0x0, 0x0));
                this.Children.Add(b);
                SetColumn(b, 0);
                SetRow(b, i);
                Label l = new Label();
                b.Child = l;
                Tuple<string, string> t = Output[i];
                l.Content = t.Item1;
                b = new Border();
                b.BorderThickness = new System.Windows.Thickness(1);
                b.BorderBrush = new SolidColorBrush(Color.FromRgb(0x0, 0x0, 0x0));
                Children.Add(b);
                SetColumn(b, 1);
                SetRow(b, i);
                l = new Label();
                b.Child = l;
                int[] k = new int[] { i };
                Action a = () =>
                {
                    l.Content = ob[k[0]];
                };
                Action act = () =>
                {
                    l.Dispatcher.Invoke(a);
                };
                labs.Add(act);
            }
            action = (labs.Count == 0) ? () => { } : labs[0];
            if (labs.Count > 1)
            {
                for (int i = 1; i < labs.Count; i++)
                {
                    action += labs[i];
                }
            }
        }

        #endregion

    }
}
