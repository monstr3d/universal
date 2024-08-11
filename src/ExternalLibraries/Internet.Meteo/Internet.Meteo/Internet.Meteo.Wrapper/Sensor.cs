using CategoryTheory;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

using Event.Interfaces;

namespace Internet.Meteo.Wrapper
{
    public class Sensor : Meteo.Sensor, ICategoryObject, IMeasurements, IEvent
    {
        #region Fields

        Measurement measurement;
 
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

        IMeasurement IMeasurements.this[int number] => measurement;

        int IMeasurements.Count => 1;

        bool IMeasurements.IsUpdated { get => true; set { } }

        void IMeasurements.UpdateMeasurements()
        {
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
        /// Cretates measurements
        /// </summary>
        protected void Create()
        {
            Func<object> f = () => GetValue();
            measurement = new Measurement(f, kind);
        }

        #endregion

    }
}
