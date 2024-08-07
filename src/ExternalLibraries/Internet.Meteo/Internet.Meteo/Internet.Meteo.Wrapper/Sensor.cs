using CategoryTheory;

namespace Internet.Meteo.Wrapper
{
    public class Sensor : Meteo.Sensor, ICategoryObject
    {

        object obj;

        object IAssociatedObject.Object
        { get => obj; set => obj = value; }

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
