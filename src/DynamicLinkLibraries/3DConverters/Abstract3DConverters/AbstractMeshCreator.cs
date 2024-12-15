namespace Abstract3DConverters
{
    public abstract class AbstractMeshCreator : IAbstractMeshCreator
    {
        string extension;

        protected string directory;

        protected string filename;



        public AbstractMeshCreator(string extension)
        {
            this.extension = extension;
        }


        string IAbstractMeshCreator.Extension => extension;

        string IAbstractMeshCreator.Directory => directory;

        public abstract Dictionary<string, Material> Materials { get; }
        public abstract Dictionary<string, Image> Images { get; }

        public  void Load(string filename)
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
