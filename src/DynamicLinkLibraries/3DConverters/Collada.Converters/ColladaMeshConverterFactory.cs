using Abstract3DConverters;
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

        IMeshConverter IMeshConverterFactory.this[string extension, params object[] objects] => Get(extension, objects);


        IMeshConverter Get(string extension, params object[] objects)
        {
            try
            {
                var ext = Path.GetExtension(extension).ToLower();
                if (ext != ".dae")
                {
                    return null;
                }
                var comment = objects[0] + "";
                switch (comment)
                {
                    case "1.5.0":
                        return new ConverterolladaMeshConverter2008();
                        break;
                    case "1.4.1":
                        return new ConverterolladaMeshConverter2005();
                        break;
                }
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("ColladaMeshConverterFactory");
            }
            return null;
        }
    }
}
