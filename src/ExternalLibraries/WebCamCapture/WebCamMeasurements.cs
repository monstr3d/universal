using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI;

using DataPerformer.Interfaces;

using Event.Interfaces;


namespace WebCamCapture
{
    [Serializable]
    public class WebCamMeasurements : SuperWebCamMeasurements,
        ICalculationReason,  IMeasurement, IMeasurements,
        IReplacedMeasurementParameter, IRealTimeStartStop
      
    {
        #region Fields

        #region Object variables

        Func<object> parameter;

        Func<object> own;

        Bitmap bitmap;

 
        bool isUpdated = false;

        Action update = () => { };

        event Action onStart = () => { };

        event Action onStop = () => { };

        event Action ev = () => { };

        List<IEvent> events = new List<IEvent>();

        

        bool isEnabled;

        #endregion


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public WebCamMeasurements()
        {
            parameter = Get;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected WebCamMeasurements(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            parameter = Get;
        }

        #endregion

        #region ICalculationReason Members

        string ICalculationReason.CalculationReason
        {
            get
            {
                return calculationReason;
            }

            set
            {
                calculationReason = value;
                if (value.Equals(StaticExtensionEventInterfaces.Realtime))
                {
                    update = Update;
                }
                else
                {
                    update = () => { };
                }
            }
        }

        #endregion

        #region IMeasurement Members

        string IMeasurement.Name
        {
            get
            {
                return "Image";
            }
        }

        Func<object> IMeasurement.Parameter
        {
            get
            {
                return parameter;
            }
        }

        object IMeasurement.Type
        {
            get
            {
                return typeof(Bitmap);
            }
        }

        #endregion

        #region  IMeasurements Members

        IMeasurement IMeasurements.this[int number]
        {
            get
            {
                return this;
            }
        }

        int IMeasurements.Count
        {
            get
            {
                return 1;
            }
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return isUpdated;
            }

            set
            {
                isUpdated = value;
            }
        }

        void IMeasurements.UpdateMeasurements()
        {
            if (!isUpdated)
            {
                update();
                isUpdated = true;
            }
        }

        #endregion

        #region IReplacedMeasurementParameter Members

        void IReplacedMeasurementParameter.Replace(Func<object> parameter)
        {
            if (own != null)
            {
                throw new Exception();
            }
            own = this.parameter;
            this.parameter = parameter;
        }

        void IReplacedMeasurementParameter.Reset()
        {
            if (own == null)
            {
                throw new Exception();
            }
            parameter = own;
            own = null;
        }

        #endregion

        #region  IRealTimeStartStop Members

        event Action IRealTimeStartStop.OnStart
        {
            add
            {
                onStart += value;
            }

            remove
            {
                onStart -= value;
            }
        }

        event Action IRealTimeStartStop.OnStop
        {
            add
            {
                onStop += value;
            }

            remove
            {
                onStop -= value;
            }
        }

        void IRealTimeStartStop.Start()
        {
            Start();
            onStart();
        }

        void IRealTimeStartStop.Stop()
        {
            Stop();
            onStop();
        }

        #endregion

       /*
                #region  INativeReader Members

                void INativeReader.Read(object[] o)
                {

                }

                #endregion*/

  

        #region ISerializable Members


        #endregion



        #region Protected Members

        /// <summary>
        /// Sets calculation reason
        /// </summary>
        protected override void SetCalculationReason()
        {
            if (calculationReason.Equals(StaticExtensionEventInterfaces.Realtime))
            {
                update = Update;
            }
            else
            {
                update = () => { };
            }
        }

        #endregion

        #region Private Members

 

        #endregion

    }
}

