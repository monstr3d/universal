using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Creators
{
    public abstract class LinesMeshCreator : AbstractMeshCreator
    {

        protected Dictionary<string, Material> materials = new();

        protected Dictionary<string, Image> images = new();

        protected List<string> lines = new List<string>();

        protected LinesMeshCreator(string extension) : base(extension)
        {

        }

        protected override void CreateAll()
        {
            using (var reader = new StreamReader(filename))
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
            CreateFromLines();
        }

        protected abstract void CreateFromLines();

        public override Dictionary<string, Material> Materials => materials;

        public override Dictionary<string, Image> Images => images;
    }
}
