using System.Text;

using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Converters
{
    public abstract class LinesConverter : IMeshConverter, IStringRepresentation, ISaveToStream
    {
        protected string directory;

        protected Dictionary<string, Material> materials;

        protected Dictionary<string, Image> images;

        protected IMaterialCreator materialCreator;

        protected IMeshConverter converter;

        protected List<string> lines = new();
        

        string IMeshConverter.Directory { get => directory; set => directory = value; }
        Dictionary<string, Material> IMeshConverter.Materials { set => materials = value; }
        Dictionary<string, Image> IMeshConverter.Images { set => images = value; }

        protected LinesConverter()
        {
            converter = this;
        }

        IMaterialCreator IMeshConverter.MaterialCreator => materialCreator;

        void IMeshConverter.Add(object parent, object child)
        {
            Add(parent, child);
        }

        object IMeshConverter.Combine(IEnumerable<object> meshes)
        {
            return Combine(meshes);
        }

        object IMeshConverter.Create(AbstractMesh mesh)
        {
            return Create(mesh);
        }

        void IMeshConverter.SetMaterial(object mesh, object material)
        {
            SetMaterial(mesh, material);
        }



        void IMeshConverter.SetTransformation(object mesh, float[] transformation)
        {
            SetTransformation(mesh, transformation);
        }


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

        void ISaveToStream.Save(object obj, Stream stream)
        {
            var lines = obj as List<string>;
            using var writer = new StreamWriter(stream);
            foreach (var line in lines)
            {
                writer.WriteLine(line);
            }

        }


        #region Abstract


        protected virtual void Add(object parent, object child)
        {
            var m = parent as List<string>;
            var c = child as List<string>;
            m.AddRange(c);
        }

        protected virtual object Combine(IEnumerable<object> meshes)
        {
            foreach (var mesh in meshes)
            {
                var lm = mesh as List<string>;
                lines.AddRange(lm);
            }
            return lines;
        }

        protected abstract object Create(AbstractMesh mesh);

        protected abstract void SetMaterial(object mesh, object material);

        protected abstract void SetTransformation(object mesh, float[] transformation);

        #endregion
    }
}
