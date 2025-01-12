using System.Reflection;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;


namespace Abstract3DConverters.Interfaces
{
    public interface IVisual3DConverter
    {
        Assembly Assembly { get; }

        object Get(Image image);

        object Get(Material material);

        object Get(Color color);

        object Get(AbstractMesh mesh);

        Dictionary<string, Material> MaterialDictionary { get; set; }


    }
}
