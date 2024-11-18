
using System.Reflection;

namespace Abstract3DConverters
{
    public interface IMaterialCreator
    {

        Assembly Assembly { get; }
        object Create(Image image);


        object Create(Color color);

        object Create(Material material);

        object Create(MaterialGroup material);

        object Create(DiffuseMaterial material);

        object Create(SpecularMaterial material);

        object Create(EmissiveMaterial material);

        void  Add(object group, object value);


        void Set(object material, object color);

        void SetImage(object material, object image);




        void Set(object material, Color color);

        void SetImage(object material, Image image);



    }
}
