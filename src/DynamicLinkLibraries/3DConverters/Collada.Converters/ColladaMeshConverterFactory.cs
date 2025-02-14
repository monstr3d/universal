using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;
using Collada.Converters.MeshConverters;

namespace Collada.Converters
{
    
    [Converter(".dae")]
    public class ColladaMeshConverterFactory : IMeshConverterFactory
    {

        public ColladaMeshConverterFactory()
        {

        }

        IMeshConverter IMeshConverterFactory.this[string extension, string comment] => Get(extension, comment);


        IMeshConverter Get(string extension, string comment)
        {
            var ext = Path.GetExtension(extension).ToLower();
            if (ext != ".dae")
            {
                return null;
            }
            switch (comment)
            {
                case "1.5.0":
                    return new ConverterolladaMeshConverter2008();
                    break;
                case "1.4.1":
                    return new ConverterolladaMeshConverter2005();
                    break;
            }
            return null;
        }
    }
}
