using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Creators
{
    public abstract class AbstractMeshCreator : IMeshCreator
    {

        protected string directory;

        protected string filename;

        protected string ext;

        protected Dictionary<string, Material> materials = new();

        protected Dictionary<string, Image> images = new();

        protected Service s = new Service();



        protected AbstractMeshCreator()
        {

        }

        string IMeshCreator.Extension => ext;

        string IMeshCreator.Directory => directory;

        public Dictionary<string, Material> Materials => materials;

        public Dictionary<string, Image> Images => images;

        public abstract void Load(byte[] bytes);


        IEnumerable<AbstractMesh> IMeshCreator.Meshes => Get();


        protected abstract IEnumerable<AbstractMesh> Get();

        protected abstract void CreateAll();

        protected virtual void Perform(AbstractMesh mesh, Action<AbstractMesh> action)
        {
            var children = mesh.Children;
            foreach (var child in children)
            {
                Perform(child, action);
            }
            action(mesh);
        }

    }
}
