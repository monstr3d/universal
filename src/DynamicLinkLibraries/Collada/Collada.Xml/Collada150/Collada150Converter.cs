using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;

namespace Collada150
{
    public class Collada150Converter : Collada.Base.ColladaMeshConverter
    {
        #region Fields


        Dictionary<string, int> dm = new();


        #endregion

        #region Constructor

        public Collada150Converter(string directory = null) : base(directory)
        {
            converter = this;
            doc.LoadXml(Properties.Resources.etalon);
            var r = doc.GetElementsByTagName("library_visual_scenes")[0];
            library_visual_scenes = doc.GetElementsByTagName("library_visual_scenes")[0] as XmlElement;
        }

        #endregion

    }
}
