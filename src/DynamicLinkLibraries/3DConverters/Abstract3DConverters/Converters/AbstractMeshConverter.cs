using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Converters
{
    public abstract class AbstractMeshConverter : IMeshConverter
    {
        #region Fields

        protected IMeshConverter converter;

        IMaterialCreator materialCreator;

        protected virtual IMaterialCreator MaterialCreator => materialCreator;

        protected Service s = new();


        string directory;


        #endregion

        protected AbstractMeshConverter(IMaterialCreator materialCreator)
        {
            converter = this;
            this.materialCreator = materialCreator;
        }

        #region 


        string IMeshConverter.Directory { get => directory; set => directory = value; }
        Dictionary<string, Material> IMeshConverter.Materials { set => Materials = value; }
        Dictionary<string, Image> IMeshConverter.Images { set => Images = value; }
        Dictionary<string, Effect> IMeshConverter.Effects { set => Effects = value; }

        IMaterialCreator IMeshConverter.MaterialCreator => MaterialCreator;

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

        void IMeshConverter.SetEffect(object mesh, object effect)
        {
            SetEffect(mesh, effect);
        }

        void IMeshConverter.SetTransformation(object mesh, float[] transformation)
        {
            SetTransformation(mesh, transformation);
        }

        #endregion

        #region Protected
        protected virtual Dictionary<string, Material> Materials
        {
            get;
            set;
        }

        protected virtual Dictionary<string, Image> Images
        {
            get;
            set;
        }

        protected virtual Dictionary<string, Effect> Effects
        {
            get;
            set;
        }

        protected abstract void Add(object parent, object child);

        protected abstract object Combine(IEnumerable<object> meshes);

        protected abstract object Create(AbstractMesh mesh);

        protected abstract void SetEffect(object mesh, object effect);

        protected abstract void SetTransformation(object mesh, float[] transformation);
  

        #endregion
    }
}
