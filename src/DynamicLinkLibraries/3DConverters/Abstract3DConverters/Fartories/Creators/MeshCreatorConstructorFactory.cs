using System.Reflection;

using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Fartories.Creators
{
    public class MeshCreatorConstructorFactory : AbstractMeshCreatorFactory
    {
        Dictionary<string, ConstructorInfo> dictionary;



        public MeshCreatorConstructorFactory(Dictionary<string, ConstructorInfo> dictionary)
        {
            this.dictionary = dictionary;
            foreach (var key in dictionary.Keys)
            {
                Extensions.Add(key);
            }
        }


        protected override IMeshCreator this[string filename, byte[] bytes, object additional]
        {
            get
            {
                var ext = Path.GetExtension(filename);
                if (!dictionary.ContainsKey(ext))
                {
                    return null;
                }
                var c = dictionary[ext];
                var arg = c.GetParameters();
                if (arg.Length == 2)
                {
                    return c.Invoke([filename, bytes]) as IMeshCreator;
                }
                return c.Invoke([filename, bytes, additional]) as IMeshCreator;
            }
        }
    }
}