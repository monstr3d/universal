using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters
{
    public class MeshCreatorFactoryCollection : IMeshCreatorFactory
    {
        List<IMeshCreatorFactory> list = new();

        IMeshCreator IMeshCreatorFactory.this[string filename] => Get(filename);
    
    
        private IMeshCreator Get(string filename)
        {
            foreach (var item in list)
            {
                var f = item[filename];
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
