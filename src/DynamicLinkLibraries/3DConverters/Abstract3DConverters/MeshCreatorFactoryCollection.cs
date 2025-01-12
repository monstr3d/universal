using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters
{
    public class MeshCreatorFactoryCollection : IMeshCreatorFactory
    {
        List<IMeshCreatorFactory> list = new();

        IMeshCreator IMeshCreatorFactory.this[string extension, Stream stream] => Get(extension, stream);
    
    
        private IMeshCreator Get(string extension, Stream stream)
        {
            foreach (var item in list)
            {
                var f = item[extension, stream];
                if (f != null)
                {
                    return f;
                }
            }
            return null;
        }

        public void Add(IMeshCreatorFactory factory)
        {
            list.Add(factory);
        }
    }
}
