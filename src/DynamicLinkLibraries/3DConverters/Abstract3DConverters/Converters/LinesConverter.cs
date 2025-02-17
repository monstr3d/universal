using System.Text;

using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Converters
{
    public abstract class LinesConverter : IMeshConverter, IStringRepresentation, ISaveToStream
    {
        #region Fields

        protected string directory;

        protected Dictionary<string, Material> materials;

        protected Dictionary<string, Image> images;

        protected IMaterialCreator materialCreator;

        protected IMeshConverter converter;

        protected List<string> lines = new();

        protected Service s = new();
        

        string IMeshConverter.Directory { get => directory; set => directory = value; }

        #endregion

        #region Ctor

        protected LinesConverter()
        {
            converter = this;
        }

        #endregion

        #region IMeshConverter Members

        IMaterialCreator IMeshConverter.MaterialCreator => materialCreator;

        Dictionary<string, Effect> IMeshConverter.Effects { set => throw new NotImplementedException(); }

        void IMeshConverter.Add(object parent, object child)
        {
            Add(parent as List<string>, child as List<string>);
        }

        object IMeshConverter.Combine(IEnumerable<object> meshes)
        {
            return Combine(meshes);
        }

        object IMeshConverter.Create(AbstractMesh mesh)
        {
            return Create(mesh);
        }

        void IMeshConverter.SetEffect(object mesh, object effect)
        {
            SetEffect(mesh, effect);
        }



        void IMeshConverter.SetTransformation(object mesh, float[] transformation)
        {
            SetTransformation(mesh, transformation);
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

        protected abstract void Set(Dictionary<string, Image> images);

        protected virtual void Set(Dictionary<string, Material> materials)
        {
            this.materials = materials;
        }

        protected virtual void Add(List<string> parent, List<string> child)
        {
            var m = parent;
            var c = child;
            m.AddRange(c);
        }

        protected virtual List<string> Combine(IEnumerable<object> meshes)
        {
            foreach (var mesh in meshes)
            {
                var lm = mesh as List<string>;
                lines.AddRange(lm);
            }
            return lines;
        }

        protected abstract List<string> Create(AbstractMesh mesh);

        protected virtual void SetEffect(object mesh, object material)
        {

        }

        protected virtual void SetTransformation(object mesh, float[] transformation)
        {

        }

 
        #endregion
    }
}
