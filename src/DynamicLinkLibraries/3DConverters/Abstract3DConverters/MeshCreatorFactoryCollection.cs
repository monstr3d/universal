using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters
{
    public class MeshCreatorFactoryCollection : IMeshCreatorFactory
    {
        List<IMeshCreatorFactory> list = new();

        IMeshCreator IMeshCreatorFactory.this[string extension, byte[] bytes]=> Get(extension, bytes);
    
    
        private IMeshCreator Get(string extension, byte[] bytes)
        {
            foreach (var item in list)
            {
                var f = item[extension, bytes];
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
