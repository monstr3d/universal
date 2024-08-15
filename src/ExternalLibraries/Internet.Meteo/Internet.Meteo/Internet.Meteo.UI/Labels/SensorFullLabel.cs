using System;
using System.Windows.Forms;
using System.Runtime.Serialization;

using CategoryTheory;
using Diagram.UI.Labels;
using Internet.Meteo.UI.Forms;
using Internet.Meteo.UI.UserControls;

namespace Internet.Meteo.UI.Labels
{
    [Serializable]
    internal class SensorFullLabel : UserControlBaseLabel
    {
        /// <summary>

        #region Fields

        FormTemperature form;

        Wrapper.Sensor sensor;



        UserControlAll uc = new UserControlAll();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SensorFullLabel()
            : base(typeof(Wrapper.Serializable.Sensor), "", Properties.Resources.AtmosphereWeb.ToBitmap())
        {

        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SensorFullLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        #endregion

        #region ISerializable Members

  
        #endregion

        #region IObjectLabel Members

        /// <summary>
        /// Object
        /// </summary>
        public override ICategoryObject Object
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
        }

        /// <summary>
        /// Associated form
        /// </summary>
        public override object Form
        {
            get => null;
        }

        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control => uc;

        #endregion


    }
}
