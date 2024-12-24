using System.Net.Http.Headers;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Creators
{
    public abstract class AbstractMeshCreator : IMeshCreator
    {

        protected string directory;

        protected string filename;

        protected Dictionary<string, Material> materials = new();

        protected Dictionary<string, Image> images = new();

        protected Service s = new Service();



        protected AbstractMeshCreator()
        {

        }

        string IMeshCreator.Directory => directory;

        public Dictionary<string, Material> Materials => materials;
        public Dictionary<string, Image> Images => images;

        public void Load(string filename)
        {
            directory = Path.GetDirectoryName(filename);
            this.filename = filename;
            CreateAll();
        }

        public abstract Tuple<object, List<AbstractMesh>> Create();

        public Tuple<object, List<AbstractMesh>> Create(string filename)
        {
            Load(filename);
            return Create();
        }


        

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
