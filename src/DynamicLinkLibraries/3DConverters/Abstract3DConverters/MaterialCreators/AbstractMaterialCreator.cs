using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using NamedTree;

namespace Abstract3DConverters.MaterialCreators
{
    public abstract class AbstractMaterialCreator : IMaterialCreator
    {

        #region Fields


        protected Service s = new();


        protected Dictionary<string, object> Images
        {
            get;

            private set;
        }

        protected IMaterialCreator creator;


        #endregion

        #region Ctor

        protected AbstractMaterialCreator(IMeshConverter meshConcerter, Dictionary<string, object> images = null)
        {
            Images = images;
            creator = this;
            MeshConverter = meshConcerter;
        }


        #endregion

        public abstract void Add(object group, object value);

        public abstract object Create(Image image);

        public abstract object Create(Color color);

        protected virtual IMeshConverter MeshConverter { get; set; }

        IMeshConverter IMaterialCreator.MeshConverter => MeshConverter;

        public virtual object Create(Material material)
        {
            object result = null;
            switch (material)
            {
                case DiffuseMaterial diffuseMaterial:
                    result = Create(diffuseMaterial);
                    Set(result, diffuseMaterial.Color);
                    SetOpacity(result, diffuseMaterial.Opacity);
                    break;
                case EmissiveMaterial emissiveMaterial:
                    result = Create(emissiveMaterial);
                    Set(result, emissiveMaterial.Color);
                    break;
                case SpecularMaterial specularMaterial:
                    result = Create(specularMaterial);
                    Set(result, specularMaterial.Color);
                    SetPower(result, specularMaterial.SpecularPower);
                    break;
                case MaterialGroup group:
                    return Create(group);
                    break;
                default:
                    break;
            }
            //var simple = material as SimpleMaterial;
            //Set(result, simple.Color);
            return result;
        }

        public virtual object Create(Effect effect)
        {
            var mat = Create(effect.Material);
            var image = Create(effect.Image);
            return SetImage(mat, image);
        }

        public abstract object CreateGroup(MaterialGroup materialGroup);


        public virtual object Create(MaterialGroup material)
        {
            IChildren<SimpleMaterial> ch = material;
            var o = CreateGroup(material);
            var children = ch.Children;
            foreach (var child in children)
            {
                var childMaterial = Create(child);
                Add(o, childMaterial);
            }
            return o;
        }

        public abstract object Create(DiffuseMaterial material);

        public abstract object Create(SpecularMaterial material);

        public abstract object Create(EmissiveMaterial material);

        public abstract void Set(object material, object color);

  
        public abstract void SetOpacity(object material, float opacity);

        public abstract void SetPower(object material, float power);


        public virtual void Set(object material, Color color)
        {
            if (color != null)
            {
                var c = Create(color);
                Set(material, c);
            }
        }

        public virtual object SetImage(object material, object image)
        {
            /*  if (image == null)
              {
                  return;
              }
              var im = Create(image);
              return SetImage(material,  im);*/
            return null;

        }

        protected virtual string GetImagePath(Image image)
        {
            return image.FullPath;
        }

        object IMaterialCreator.SetImage(object material, object image)
        {
            return SetImage(material, image as Image);
        }
    }
}