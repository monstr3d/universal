using CategoryTheory;

using Diagram.UI;


using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

using Event.Interfaces;

namespace Internet.Meteo.Wrapper
{
    public class Sensor : Meteo.Sensor, ICategoryObject, IMeasurements, ICalculationReason,
        IRealTimeStartStop, IStarted

    {
        #region Fields

        bool isUpdated = false;

        IMeasurement[] measurements;

        string calculationReason = "";

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kind">Kind</param>
        public Sensor(string kind) : base(kind)
        {
            Create();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected Sensor()
        {

        }


        #endregion

        #region IAssociatedObject members

        object IAssociatedObject.Object
        { get; set; }

        #endregion

        #region IMeasurements members

        IMeasurement IMeasurements.this[int number] => measurements[number];

        int IMeasurements.Count => measurements.Length;

        bool IMeasurements.IsUpdated { get => isUpdated; set => isUpdated = value; }

        void IMeasurements.UpdateMeasurements()
        {
            Update();
        }

        #endregion

        #region IRealTimeStartStop Members

        /// <summary>
        /// On start event
        /// </summary>
        event Action IRealTimeStartStop.OnStart
        {
            add
            {

            }

            remove
            {

            }
        }

        /// <summary>
        /// On stop event
        /// </summary>
        event Action IRealTimeStartStop.OnStop
        {
            add
            {
            }

            remove
            {

            }
        }

        /// <summary>
        /// Starts itself
        /// </summary>
        void IRealTimeStartStop.Start()
        {
            if (calculationReason == StaticExtensionEventInterfaces.Realtime)
            {
                IsEnabled = true;
            }
        }

        /// <summary>
        /// Stops itself
        /// </summary>
        void IRealTimeStartStop.Stop()
        {
            if (calculationReason == StaticExtensionEventInterfaces.Realtime)
            {
                IsEnabled = false;
                calculationReason = "";
            }
        }

        #endregion

        #region IStarted Members

        /// <summary>
        /// Starts itself
        /// </summary>
        /// <param name="time">The start time</param>
        void IStarted.Start(double time)
        {
            if (calculationReason != StaticExtensionEventInterfaces.Realtime)
            {

                Start();
            }
        }

        #endregion

        #region ICalculationReason Members

        /// <summary>
        /// CalculationReason
        /// </summary>
        string ICalculationReason.CalculationReason
        {
            get
            {
                return calculationReason;
            }

            set
            {
                calculationReason = value;
            }
        }

        #endregion
  
        #region Protected members

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message</param>
        protected override void ShowMessage(string message)
        {
            message.Show();
        }

        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="exception">The exception</param>
        protected override void ShowError(Exception exception)
        {
            exception.ShowError();
        }

        /// <summary>
        /// Creates measurements
        /// </summary>
        protected void Create()
        {
            measurements = new IMeasurement[currentNames.Length];
            for (int i = 0; i < currentNames.Length; i++)
            {
                var k = i;
                Func<object> f = () =>
                    values[k];
                measurements[i] = new ReplacedParameterMeasurement(Types[currentNames[i]], f,
                    currentNames[i], this);
            }
        }

        #endregion


    }
}
