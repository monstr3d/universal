using System;
using NamedTree;


namespace CategoryTheory
{
    public class Performer
    {
        public Performer() { }

        public string GetAssociatedName(IAssociatedObject associated)
        {
            if (associated.Object is INamed named)
            {
                return named.Name;
            }
            return null;
        }

        public string GetName(object obj)
        {
            if (obj is INamed named)
            {
                return named.Name;
            }
            return null;
        }
    }
}
