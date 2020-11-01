using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Resources;

namespace ResourceService
{
    /// <summary>
    /// Localizator
    /// </summary>
    public interface ILocalizator
    {
        /// <summary>
        /// Creates dictionary
        /// </summary>
        /// <param name="culture">Culture</param>
        /// <returns>Dictionarry</returns>
        Dictionary<string, object> CreateDictionary(CultureInfo culture);
    }


    /// <summary>
    /// Resource Manager Holder
    /// </summary>
    public interface IResourceManager
    {
        /// <summary>
        /// Gets resource manager
        /// </summary>
        /// <param name="culture">Culture</param>
        /// <returns>Resource manager</returns>
        ResourceManager GetResourceManager(CultureInfo culture);
    }

    /// <summary>
    /// Gets dictionary
    /// </summary>
    /// <param name="culture">Culture</param>
    /// <returns>Dictionary</returns>
    public delegate Dictionary<string, object> GetDictionary(CultureInfo culture);


    /// <summary>
    /// Holder of resouces
    /// </summary>
    public interface IResourceHolder
    {
        /// <summary>
        /// Dictionary
        /// </summary>
        Dictionary<string, object> Dictionary
        {
            get;
        }
    }

    /// <summary>
    /// Collection of Resource holders
    /// </summary>
    public interface IResourceHolderCollection
    {
        /// <summary>
        /// Collection of dictionaries
        /// </summary>
        Dictionary<string, object>[] DictionaryCollection
        {
            get;
        }
    }
}
