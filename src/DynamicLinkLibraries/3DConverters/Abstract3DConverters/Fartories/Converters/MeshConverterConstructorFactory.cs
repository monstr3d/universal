using System.Reflection;
using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Fartories.Converters
{
    public class MeshConverterConstructorFactory : IMeshConverterFactory
    {

        Dictionary<string, ConstructorInfo> dictionary = null;


        public MeshConverterConstructorFactory(Dictionary<string, ConstructorInfo> dictionary)
        {
            this.dictionary = dictionary;
        }

        IMeshConverter IMeshConverterFactory.this[string extension, params object[] objects] => Get(extension, objects);

        IMeshConverter Get(string extension, params object[] objects)
        {
            var ext = Path.GetExtension(extension);
            ConstructorInfo ci = null;
            if (dictionary.ContainsKey(ext))
            {
                ci = dictionary[ext];   
            }
            if (ci != null)
            {
                return ci.Invoke(objects) as IMeshConverter;
            }
            return null;
        }
    }
}
