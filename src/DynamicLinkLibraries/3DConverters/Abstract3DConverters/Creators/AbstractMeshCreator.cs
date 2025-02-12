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

        Dictionary<string, Material> materials = new();

        Dictionary<string, Image> images = new();
  
        protected Service s = new Service();

        Dictionary<string, Effect> effects = new();

        protected IMeshCreator creator;
  


        protected AbstractMeshCreator()
        {
            creator = this;
        }

        //string IMeshCreator.Extension => ext;

        string IMeshCreator.Directory => directory;

        Dictionary<string, Material> IMeshCreator.Materials
        {
            get => materials;
        }
       

        Dictionary<string, Image> IMeshCreator.Images => images;

       

        public abstract void Load(byte[] bytes);


        IEnumerable<AbstractMesh> IMeshCreator.Meshes => Get();

        Dictionary<string, Effect> IMeshCreator.Effects => GetEffects();

        protected abstract IEnumerable<AbstractMesh> Get();

   
        protected abstract void CreateAll();

        protected virtual Dictionary<string, Effect>  GetEffects()
        {
            return effects;
        }

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
