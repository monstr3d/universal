namespace Abstract3DConverters
{
    public abstract class AbstractMeshCreator : IAbstractMeshCreator
    {
        string extension;


        string IAbstractMeshCreator.Extension => extension;

        Tuple<object, List<AbstractMesh>> IAbstractMeshCreator.Create(string filename)
        {
            return Create(filename);
        }

        protected AbstractMeshCreator(string extension)
        {
            this.extension = extension;
        }


        protected abstract Tuple<object, List<AbstractMesh>> Create(string filename);

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
