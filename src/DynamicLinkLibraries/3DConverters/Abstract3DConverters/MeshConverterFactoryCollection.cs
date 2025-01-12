using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters
{
    internal class MeshConverterFactoryCollection : IMeshConverterFactory
    {
        IMeshConverter IMeshConverterFactory.this[string extension, string comment] => Get(extension, comment);

        List<IMeshConverterFactory> list = new();



        private IMeshConverter Get(string extension, string comment)
        {
            foreach (var item in list)
            {
                var f = item[extension, comment];
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

