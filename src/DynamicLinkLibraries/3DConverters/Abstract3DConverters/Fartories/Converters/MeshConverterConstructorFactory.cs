using System.Reflection;
using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Fartories.Converters
{
    public class MeshConverterConstructorFactory : IMeshConverterFactory
    {

        Dictionary<string, Dictionary<string, ConstructorInfo>> dictionary = null;


        public MeshConverterConstructorFactory(Dictionary<string, Dictionary<string, ConstructorInfo>> dictionary)
        {
            this.dictionary = dictionary;
        }

        IMeshConverter IMeshConverterFactory.this[string extension, string comment] => Get(extension, comment);

        IMeshConverter Get(string extension, string comment)
        {
            var ext = Path.GetExtension(extension);
            ConstructorInfo ci = null;
            var c = comment == null ? "" : comment;
            if (dictionary.ContainsKey(ext))
            {
                var d = dictionary[ext];
                var k = d.Keys;
                if (k.Count == 1)
                {
                    ci = d.Values.ToArray()[0];
                }
                else
                {
                    ci = d[c];
                }
            }
            if (ci != null)
            {
                return ci.Invoke(new object[0]) as IMeshConverter;
            }
            return null;
        }
    }
}
