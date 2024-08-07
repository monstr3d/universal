using CategoryTheory;
using Diagram.UI.Labels;
using Internet.Meteo.UI.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Internet.Meteo.UI.Labels
{
    [Serializable()]
    public class SensorLabel : UserControlBaseLabel
    {
        /// <summary>

        #region Fields

        Form form;

        Wrapper.Sensor sensor;

        UserControlTemperature uc;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SensorLabel()
            : base(typeof(Wrapper.Serializable.Sensor), "", Properties.Resources.thermometer)
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
            try
            {
                //formula = info.GetString("Formula");
            }
            catch (Exception)
            {
            }
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
        }

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
            get => null;
        }

        /// <summary>
        /// Load operation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected override void Load(SerializationInfo info, StreamingContext context)
        {
            base.Load(info, context);
        }

        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {
                uc = new UserControlTemperature();
                return uc;
            }
        }



        #endregion

        #region Specific Members

        #endregion


    }
}

