using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Globalization;

namespace ResourceService
{
    /// <summary>
    /// Localizator of resource manager
    /// </summary>
    public class ResourceManagerLocalizator : ILocalizator
    {
        #region Fields

        Dictionary<string, ResourceManager> dictionary;

        #endregion


        #region Ctor

        private ResourceManagerLocalizator(Dictionary<string, ResourceManager> dictionary)
        {
            this.dictionary = dictionary;
        }

        #endregion

        #region ILocalizator Members

        Dictionary<string, object> ILocalizator.CreateDictionary(CultureInfo culture)
        {
            string lan = culture.ThreeLetterISOLanguageName;
            if (dictionary.ContainsKey(lan))
            {
                return Resources.CreateLocalizationDictionary(dictionary[lan]);
            }
            return new Dictionary<string, object>();
        }

        #endregion

        #region Members

        /// <summary>
        /// Creates localizator
        /// </summary>
        /// <param name="dictionary">Dictionary</param>
        /// <returns>Localizator</returns>
        public static ILocalizator Create(Dictionary<string, ResourceManager> dictionary)
        {
            return new ResourceManagerLocalizator(dictionary);
        }

        /// <summary>
        /// Creates Localizator from arrays
        /// </summary>
        /// <param name="languages">Array of languages</param>
        /// <param name="managers">Array of managers</param>
        /// <returns>Localizator</returns>
        public static ILocalizator Create(string[] languages, ResourceManager[] managers)
        {
            Dictionary<string, ResourceManager> d = new Dictionary<string, ResourceManager>();
            for (int i = 0; i < languages.Length; i++)
            {
                d[languages[i]] = managers[i];
            }
            return Create(d);
        }

        #endregion
    }
}
