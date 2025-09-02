using System;

namespace Collada
{
    public class TagAttribute : Attribute
    {

        public bool IsElemenary { get; private set; }

        public string Tag { get; private set; }

        public TagAttribute(string tag, bool isElemenary = false)
        {
            Tag = tag;
            IsElemenary = isElemenary;
        }
    }
}
