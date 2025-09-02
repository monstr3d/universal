using System;

namespace BaseTypes.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LanguageAttribute : Attribute
    {
        public string Language { get; init; }

        public string Extension { get; init; } = "";

        public LanguageAttribute(string language)
        {
            Language = language;
        }

        public LanguageAttribute(string language, string extension)
        {
            Language = language;
            Extension = extension;
        }

    }
}
