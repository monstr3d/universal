using System.Reflection;
using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Interfaces
{
    public interface IMaterialCreator
    {


        object Create(Image image);
        

        object Create(Color color);


        object Create(MaterialGroup material);

        object Create(DiffuseMaterial material);

        object Create(SpecularMaterial material);

        object Create(EmissiveMaterial material);


        object Create(Material material);



        void Add(object group, object value);


        void SetImage(object material, object image);

        void AddImageToDictionary(string key, object image);

        void SetOpacity(object material, float opacity);

    }
}
