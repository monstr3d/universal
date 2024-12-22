using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;

namespace Collada150
{
    public class Collada150Converter : Collada.Base.ColladaMeshConverter
    {
        #region Fields

        XmlDocument doc = new ();

        Service s = new();

        MaterialCreator materialCreator = new MaterialCreator();


        List<float[]> vertices;

        List<float[]> textures;

        List<float[]> normals;

        List<string> materials = new();

        Dictionary<string, int> dm = new();

        IMeshConverter converter;

        #endregion

        #region Constructor

        public Collada150Converter(string directory = null) : base(directory)
        {
            converter = this;
            doc.LoadXml(Properties.Resources.etalon);
        }

        #endregion

    }
}
