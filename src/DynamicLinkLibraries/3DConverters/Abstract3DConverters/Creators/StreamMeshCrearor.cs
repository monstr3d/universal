namespace Abstract3DConverters.Creators
{
    public abstract class StreamMeshCrearor : AbstractMeshCreator
    {

        protected StreamMeshCrearor(string filename, string directory, params object[] objects) : base(filename, directory, objects)
        {
            Load(Objects[0] as byte[]);
        }
     }
}
