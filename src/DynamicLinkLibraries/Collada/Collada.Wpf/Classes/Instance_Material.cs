using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("instance_material")]
    public class Instance_Material : XmlHolder
    {

        private Instance_Material(XmlElement element) : base(element)
        {
            var target = element.GetAttribute("target");
            target = target.Substring(1);
            Material mm = StaticExtensionColladaWpf.GetMaterial(target);
            if (mm != null)
            {
                Material = mm;
                return;
            }
            var m = target.Get<MaterialObject>();
            Material = m.Material;
            var url = element.GetAttribute("url");
            if (url.Length > 0)
            {

            }
            else
            {

            }

            

        }

        public Material Material { get; private set; }

        static public object Get(XmlElement element)
        {
            return new Instance_Material(element);
        }

    }
}
