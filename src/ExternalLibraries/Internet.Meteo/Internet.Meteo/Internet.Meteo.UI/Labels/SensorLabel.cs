using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

using CategoryTheory;
using Diagram.UI.Labels;
using Internet.Meteo.UI.Forms;
using Internet.Meteo.UI.UserControls;
using System.ComponentModel;

namespace Internet.Meteo.UI.Labels
{
    [Serializable()]
    public class SensorLabel : UserControlBaseLabel
    {
        /// <summary>

        #region Fields

        FormTemperature form;

        Wrapper.Sensor sensor;

        

        UserControlTemperature uc;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SensorLabel()
            : base(typeof(Wrapper.Serializable.Sensor), "thermometer", Properties.Resources.thermometerp)
        {

        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SensorLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Min", Min);
            info.AddValue("Max", Max);
            info.AddValue("Step", Step);
        }

        #endregion

        #region IObjectLabel Members

        /// <summary>
        /// Object
        /// </summary>
        protected override ICategoryObject Object
        {
            get
            {
                return sensor;
            }
            set
            {
                if (!(value is Sensor))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                sensor = value as Wrapper.Sensor;
                value.Object = this;
                uc.Sensor = sensor;
            }
        }

        #endregion

        #region Overriden Members

       


        /// <summary>
        /// Post operation
        /// </summary>
        public override void Post()
        {
            try
            {
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Associated form
        /// </summary>
        public override object Form
        {
            get => CreareForm();
        }

        /// <summary>
        /// Load operation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected override void Load(SerializationInfo info, StreamingContext context)
        {
            base.Load(info, context);
            Min = info.GetSingle("Min");
            Max = info.GetSingle("Max");
            Step = info.GetSingle("Step");
        }

        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {
                uc = new UserControlTemperature(Min, Max, Step);
                return uc;
            }
        }



        #endregion

        #region Specific Members

        #region Public

        // Minimum
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float Min
        { get; set; } = 0;

        /// <summary>
        /// Maximum
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float Max
        { get; set; } = 100;

        /// <summary>
        /// Step
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float Step
        { get; set; } = 1;


        #endregion

        #region Private

        FormTemperature CreareForm()
        {
            if (form != null)
            {
                if (!form.IsDisposed)
                {
                    return form;
                }
            }
            form = new FormTemperature(this);
            return form;
        }

        #endregion

        #endregion


    }
}

