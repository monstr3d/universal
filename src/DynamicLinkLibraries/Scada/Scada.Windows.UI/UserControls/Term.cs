using System;
using System.Collections.Generic;

using Scada.Interfaces;
using System.ComponentModel;


namespace Scada.Windows.UI.UserControls
{

    /// <summary>
    /// Term Control
    /// </summary>
    public partial class Term : ScadaForms.Term, IScadaConsumer
    {
 
        #region Scada Input Fields

        string eventString;

        string outputString;

        Func<float> output;

        IScadaInterface scada;

        IEvent eventObject;
       
        bool isEnabled = false;
  
        #endregion

        public Term()
        {
        }

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
                scada = value;
                eventObject = scada[eventString];
                output = scada.GetFloatOutput(outputString);
                scada.AddEventOutput(eventString, outputString);
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
        /// Event string
        /// </summary>
        /*    [DefaultValue("")]
            [Editor(typeof(ListGridComboBox), typeof(UITypeEditor))]
            [DataList("GetEvents")]
            [TypeConverter(typeof(ListExpandableConverter))]
            [Category("SCADA"), Description("Event name"), DisplayName("Event")]*/
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Event
        {
            get
            {
                return eventString;
            }
            set
            {
                eventString = value;
            }
        }

        /// <summary>
        /// Output string
        /// </summary>
    /*    [DefaultValue("")]
        [Editor(typeof(ListGridComboBox), typeof(UITypeEditor))]
        [DataList("GetOutputs")]
        [TypeConverter(typeof(ListExpandableConverter))]
        [Category("SCADA"), Description("Output name"), DisplayName("Output")]*/
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Output string
        /// </summary>
        /*    [DefaultValue("")]
            [Editor(typeof(ListGridComboBox), typeof(UITypeEditor))]
            [DataList("GetOutputs")]
            [TypeConverter(typeof(ListExpandableConverter))]
            [Category("SCADA"), Description("Output name"), DisplayName("Output")]*/
        public string Output
        {
            get
            {
                return outputString;
            }
            set
            {
                outputString = value;
            }
        }

        #endregion

        private List<string> GetOutputs()
        {
            return StaticExtensionWindowsUI.Scada.GetRealList(false);
        }



        private List<string> GetEvents()
        {
            return StaticExtensionWindowsUI.Scada.Events;
        }

        
  
        void Set()
        {
            Set(output());
        }


     }
}