using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Creators
{
    public abstract class LinesMeshCreator : StreamMeshCrearor
    {


        protected List<string> lines = new List<string>();

        protected LinesMeshCreator(string filename, Stream stream) : base(filename, stream)
        {
            CreateAll();
        }

        public override void Load(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                do
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    if (line.Length > 0)
                    {
                        lines.Add(line);
                    }
                }
                while (!reader.EndOfStream);
            }
        }

        protected override void CreateAll()
        {
            CreateFromLines();
        }

        protected abstract void CreateFromLines();

      }
}
