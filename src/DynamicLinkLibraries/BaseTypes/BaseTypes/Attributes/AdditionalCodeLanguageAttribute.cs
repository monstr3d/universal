using System;

namespace BaseTypes.Attributes
{
    /// <summary>
    /// Language of additional code
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AdditionalCodeLanguageAttribute : Attribute
    {
        /// <summary>
        /// Language
        /// </summary>
        public string Language { get; init; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="language">Language</param>
        public AdditionalCodeLanguageAttribute(string language)
        {
            Language = language;
        }

    }
}
