using System;
using System.Collections.Generic;

using Scada.Interfaces;
using System.ComponentModel;


namespace Scada.Windows.UI.UserControls
{

    public partial class Slider : ScadaForms.Slider, IScadaConsumer
    {


    
        #region Scada Input Fields

  

        string inputString;

        Action<float> input;

        IScadaInterface scada;

        private bool isEnabled;


        #endregion

        #region Ctor

        public Slider()
        {
            Load += Slider_Load;
        }

        private void Slider_Load(object sender, EventArgs e)
        {
            Reset(MinValue, MaxValue, StepValue);
        }

        #endregion


        /*     [DefaultValue("")]
             [Editor(typeof(ListGridComboBox), typeof(UITypeEditor))]
             [DataList("GetInputs")]
             [TypeConverter(typeof(ListExpandableConverter))]
             [Category("SCADA"), Description("Input name"), DisplayName("Input")]*/
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Input
        {
            get
            {
                return inputString;
            }
            set
            {
                inputString = value;
            }
        }

        private List<string> GetInputs()
        {
            return StaticExtensionWindowsUI.Scada.GetRealList(true);
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float MinValue
        { get; set; } = 0;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float MaxValue
        { get; set; } = 100;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float StepValue
        { get; set; } = 1;  
  
/*
        private void Update()
        {
           input(_val);
        }
*/
  
   
        void Slider_ValueChanged(object sender, EventArgs e)
        {
            input(Val);
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
                input = scada.GetFloatInput(inputString);
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
                    this.ValueChanged += Slider_ValueChanged;
                }
                else
                {
                    this.ValueChanged += Slider_ValueChanged;
                }
            }
        }

        #endregion

    }
}