using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Creators
{
    public abstract class LinesMeshCreator : AbstractMeshCreator
    {


        protected List<string> lines = new List<string>();

        protected LinesMeshCreator()
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

      }
}
