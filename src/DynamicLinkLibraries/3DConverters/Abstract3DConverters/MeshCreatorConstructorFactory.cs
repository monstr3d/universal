using Abstract3DConverters.Interfaces;
using System.Reflection;

namespace Abstract3DConverters
{
    public class MeshCreatorConstructorFactory : IMeshCreatorFactory
    {
        Dictionary<string, ConstructorInfo> dictionary;

        object[] obj = new object[0];

        public MeshCreatorConstructorFactory(Dictionary<string, ConstructorInfo> dictionary)
        {
            this.dictionary = dictionary;
        }

        IMeshCreator IMeshCreatorFactory.this[string filename] => Get(filename);

        private IMeshCreator Get(string filename)
        {
            var ext = Path.GetExtension(filename);
            if (!dictionary.ContainsKey(ext))
            {
                return null;
            }
            var c = dictionary[ext];
            return c.Invoke(null) as IMeshCreator;
        }


    }
}
