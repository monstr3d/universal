using NamedTree;


namespace CategoryTheory
{
    public class Performer
    {
        public Performer() 
        { 
        
        }

        /// <summary>
        /// Checks whether the type is base type
        /// </summary>
        /// <param name="baseType">The base type</param>
        /// <param name="type">The type</param>
        /// <returns>True is base type and false otherwise</returns>
        public bool IsBase(object baseType, object type)
        {
            return baseType.GetType().IsBase(type.GetType());
        }


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
