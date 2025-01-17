using System.Reflection;
using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Interfaces
{
    public interface IMaterialCreator
    {

        Assembly Assembly { get; }

        object Create(string key, Image image);


        object Create(Color color);

        object Create(string key, Material material);

        object Create(string key, MaterialGroup material);

        object Create(DiffuseMaterial material);

        object Create(SpecularMaterial material);

        object Create(EmissiveMaterial material);

        void Add(object group, object value);


        void Set(object material, object color);

        void SetImage(object material, object image);

        void Set(object material, Color color);

        void SetImage(object material, Image image);

    }
}
