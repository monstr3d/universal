namespace BaseTypes.Interfaces
{
    /// <summary>
    /// Operation which returns an object
    /// </summary>
    public interface IObjectOperation
    {

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] InputTypes
        {
            get;
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        /// <param name="arguments">Array of arguments</param>
        /// <returns>Operation result</returns>
        object this[object[] arguments]
        {
            get;
        }

        /// <summary>
        /// Return type
        /// </summary>
        object ReturnType
        {
            get;
        }

     }
}
