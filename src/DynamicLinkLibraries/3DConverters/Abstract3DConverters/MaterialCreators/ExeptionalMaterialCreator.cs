using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

namespace Abstract3DConverters.MaterialCreators
{
    public  class ExeptionalMaterialCreator : IMaterialCreator
    {
        public virtual void Add(object group, object value)
        {
            throw new NotImplementedException();
        }

        public virtual object Create(Image image)
        {
            throw new NotImplementedException();
        }

        public virtual object Create(Color color)
        {
            throw new NotImplementedException();
        }

        public virtual object Create(MaterialGroup material)
        {
            throw new NotImplementedException();
        }

        public virtual object Create(DiffuseMaterial material)
        {
            throw new NotImplementedException();
        }

        public virtual object Create(SpecularMaterial material)
        {
            throw new NotImplementedException();
        }

        public virtual object Create(EmissiveMaterial material)
        {
            throw new NotImplementedException();
        }

        public virtual object Create(Material material)
        {
            throw new NotImplementedException();
        }

        public virtual void SetImage(object material, object image)
        {
            throw new NotImplementedException();
        }

        public virtual void SetOpacity(object material, float opacity)
        {
            throw new NotImplementedException();
        }
    }
}
