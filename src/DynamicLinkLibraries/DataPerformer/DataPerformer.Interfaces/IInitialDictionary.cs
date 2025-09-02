using System.Collections.Generic;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Initial condition dictonary
    /// </summary>
    public interface IInitialDictionary
    {
        /// <summary>
        /// The dictionary
        /// </summary>
        Dictionary<string, object> Dictionary { get; }
    }
}
