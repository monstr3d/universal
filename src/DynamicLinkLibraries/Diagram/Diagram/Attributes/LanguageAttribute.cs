using System;

namespace Diagram.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LanguageAttribute : Attribute
    {
        public string Language { get; init; }

        public LanguageAttribute(string language)
        {
            Language = language;
        }
    }
}
