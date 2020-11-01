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
    public class Localizator : IResourceHolder
    {

        #region Fields

        Dictionary<string, object> resources;

        GetDictionary dict;

        ILocalizator localizator;

        #endregion

        #region Ctor

        private Localizator(ILocalizator localizator)
        {
            this.localizator = localizator;
            dict = First;
        }

        #endregion

        #region Members

        /// <summary>
        /// Creates Resource Holder from localizator
        /// </summary>
        /// <param name="localizator">Localizator</param>
        /// <returns></returns>
        public static IResourceHolder Create(ILocalizator localizator)
        {
            return new Localizator(localizator);
        }

        /// <summary>
        /// Creates holder from dictionary
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <returns>The holder</returns>
        public static IResourceHolder Create(Dictionary<string, ResourceManager> dictionary)
        {
            return Create(ResourceManagerLocalizator.Create(dictionary));
        }

        
        /// <summary>
        /// Creates holder from array
        /// </summary>
        /// <param name="languages">Array of languages</param>
        /// <param name="managers">Managers</param>
        /// <returns>The holder</returns>
        public static IResourceHolder Create(string[] languages, ResourceManager[] managers)
        {
            return Create(ResourceManagerLocalizator.Create(languages, managers));
        }


        /// <summary>
        /// Creates resources
        /// </summary>
        /// <param name="dictionaries">Dictionaries</param>
        /// <returns>Resources</returns>
        public static Dictionary<string, object>[] CreateResources(Dictionary<string, object>[][] dictionaries)
        {
            List<Dictionary<string, object>> res = new List<Dictionary<string, object>>();
            foreach (Dictionary<string, object>[] r in dictionaries)
            {
                if (r != null)
                {
                    res.AddRange(r);
                }
            }
            return res.ToArray();
        }

        /// <summary>
        /// Creates resources from arrays
        /// </summary>
        /// <param name="languages">Array of languages</param>
        /// <param name="managers">Managers</param>
        /// <returns>Resources</returns>
        public static Dictionary<string, object>[] CreateResources(string[] languages, ResourceManager[] managers)
        {
            return new Dictionary<string, object>[]
            {
                Create(languages, managers).Dictionary
            };
        }

        Dictionary<string, object> First(CultureInfo culture)
        {
            resources = localizator.CreateDictionary(culture);
            dict = Last;
            return resources;
        }
        
        Dictionary<string, object> Last(CultureInfo culture)
        {
            return resources;
        }

        #endregion

        #region IResourceHolder Members

        Dictionary<string, object> IResourceHolder.Dictionary
        {
            get { return dict(CultureInfo.CurrentCulture); }
        }

        #endregion
    }
}
