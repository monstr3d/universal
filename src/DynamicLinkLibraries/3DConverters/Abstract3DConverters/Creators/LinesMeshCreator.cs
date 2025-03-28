


namespace Abstract3DConverters.Creators
{
    public abstract class LinesMeshCreator : StreamMeshCrearor
    {


        protected List<string> lines = new List<string>();


        protected LinesMeshCreator(string filename, string directory, params object[] objects) : base(filename, directory, objects)
        {
            try
            {
                if (Objects.Length == 1)
                {
                    CreateAll();
                    return;
                }
                CreateAdditional(Objects[1]);
            }
            catch (Exception ex)
            {
                ex.HandleExceptionDouble("LinesMeshCreator constructor " + GetType().Name);
           }
        }

        abstract protected void CreateAdditional(object additional);

        public override void Load(byte[] bytes)
        {
            using var stream = new MemoryStream(bytes);
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
