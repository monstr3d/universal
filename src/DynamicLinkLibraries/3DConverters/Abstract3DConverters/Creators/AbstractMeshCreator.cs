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

        protected Service s = new Service();

   
        protected IMeshCreator creator;

    


        protected AbstractMeshCreator()
        {
            creator = this;
        }

        //string IMeshCreator.Extension => ext;

        string IMeshCreator.Directory => directory;
       

        public abstract void Load(byte[] bytes);


        IEnumerable<AbstractMesh> IMeshCreator.Meshes => Meshes;

        Dictionary<string, Effect> IMeshCreator.Effects => Effects;

        protected abstract IEnumerable<AbstractMesh> Meshes { get;  }

   
        protected abstract void CreateAll();

        protected virtual Dictionary<string, Effect> Effects
        {
            get;
        } = new();

        protected virtual Dictionary<string, Image> Images
        {
            get;
        } = new();

        protected virtual Dictionary<string, Material> Materials
        {
            get;
        } = new();




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
