using CategoryTheory;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;
using Diagram.UI;
using Event.Interfaces;

namespace Internet.Meteo.Wrapper
{
    public class Sensor : Meteo.Sensor, ICategoryObject, IMeasurements, IEvent
    {
        #region Fields

        bool isUpdated = false;

        IMeasurement[] measurements;

    
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

        #region IEvent members

        bool IEvent.IsEnabled 
        { 
            get => base.IsEnabled; 
            set => base.IsEnabled = value; 
        }

        event Action IEvent.Event
        {
            add
            {
            }

            remove
            {
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
                measurements[i] = new Measurement(Types[currentNames[i]], f,
                    currentNames[i]);
            }      
        }

        #endregion

    }
}
