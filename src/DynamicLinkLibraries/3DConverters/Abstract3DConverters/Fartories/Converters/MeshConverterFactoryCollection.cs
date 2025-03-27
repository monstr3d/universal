using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Fartories.Converters
{
    public class MeshConverterFactoryCollection : IMeshConverterFactory
    {
        IMeshConverter IMeshConverterFactory.this[string extension, params object[] objects] => Get(extension, objects);

        List<IMeshConverterFactory> list = new();



        private IMeshConverter Get(string extension, params object[] objects)
        {
            foreach (var item in list)
            {
                var f = item[extension, objects];
                if (f != null)
                {
                    return f;
                }
            }
            return null;
        }

        public void Add(IMeshConverterFactory factory)
        {
            list.Add(factory);
        }
    }
}

