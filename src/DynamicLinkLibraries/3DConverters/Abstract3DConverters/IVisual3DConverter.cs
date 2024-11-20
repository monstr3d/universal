using System.Reflection;


namespace Abstract3DConverters
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
