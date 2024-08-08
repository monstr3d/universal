using CategoryTheory;

namespace Internet.Meteo.Wrapper
{
    public class Sensor : Meteo.Sensor, ICategoryObject
    {
        #region Fields

 
        #endregion

        #region IAssociatedObject members

        object IAssociatedObject.Object
        { get; set; }

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kind">Kind</param>
        public Sensor(string kind): base(kind) 
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected Sensor()
        {

        }



        #endregion

    }
}
