namespace Abstract3DConverters
{
    public class AbstractMeshAC : AbstractMesh
    {

        int count;

        float[] coord;

        List<string> l;

        public AbstractMeshAC(string name, int count, List<string> l) : base(name)
        {
            this.count = count;
            this.l = l;
        }
    }
}
