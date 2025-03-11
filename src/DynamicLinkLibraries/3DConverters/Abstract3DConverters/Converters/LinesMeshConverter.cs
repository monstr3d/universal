using System.Text;

using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Converters
{
    public abstract class LinesMeshConverter : AbstractMeshConverter, IStringRepresentation, ISaveToStream
    {
        #region Fields

        protected string directory;

        protected List<string> lines = new();


        #endregion

        #region Ctor

        protected LinesMeshConverter(IMaterialCreator materialCreator) : base(materialCreator)
        {

        }

        #endregion

        #region Overriden Members

        protected override void Add(object parent, object child)
        {
            Add(parent as List<string>, child as List<string>);
        }

        protected override object Combine(IEnumerable<object> meshes)
        {
            foreach (var mesh in meshes)
            {
                var lm = mesh as List<string>;
                lines.AddRange(lm);
            }
            return lines;
        }

        #endregion


        #region IStringRepresentation Members

        string IStringRepresentation.ToString(object obj)
        {
            var l = obj as List<string>;
            var sb = new StringBuilder();
            foreach (var str in l)
            {
                sb.Append(str + '\n');
            }
            return sb.ToString();
        }

        #endregion


        #region ISaveToStream Members


        void ISaveToStream.Save(object obj, Stream stream)
        {
            var lines = obj as List<string>;
            using var writer = new StreamWriter(stream);
            foreach (var line in lines)
            {
                writer.WriteLine(line);
            }

        }

        #endregion


        #region Abstract and virtual membres

        protected override object Create(IMesh mesh)
        {
            base.Create(mesh);
            return CreateLines(mesh);
        }

        protected virtual void Add(List<string> parent, List<string> child)
        {
            var m = parent;
            var c = child;
            m.AddRange(c);
        }

        protected abstract List<string> CreateLines(IMesh mesh);

        #endregion
    }
}
