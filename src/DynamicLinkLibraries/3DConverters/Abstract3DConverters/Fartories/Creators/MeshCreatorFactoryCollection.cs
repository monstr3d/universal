using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Fartories.Creators
{
    public class MeshCreatorFactoryCollection : AbstractMeshCreatorFactory
    {
        List<IMeshCreatorFactory> list = new();

    
        protected override  IMeshCreator this[string extension, string directory, params object[] objects]
        {
            get
            {
                foreach (var item in list)
                {
                    var f = item[extension, directory, objects];
                    if (f != null)
                    {
                        return f;
                    }
                }
                return null;
            }
        }

        public void Add(IMeshCreatorFactory factory)
        {
            list.Add(factory);
            Extensions.AddRange(factory.Extensions);
        }
    }
}
