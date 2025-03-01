
using System.Xml;

using Abstract3DConverters.Interfaces;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("surface")]
    public class Surface : XmlHolder
    {
        public static IClear Clear => StaticExtensionCollada.GetClear<Surface>();

        internal Abstract3DConverters.Image Image { get; private set; }

        static Surface()
        {
        }


        public Surface(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            var i = element.Get<Init_From>();
            if (i == null)
            {
                return;
            }
            var iff = i.Text;
            var imm = MeshCreator.ImageIds;
            if (imm.ContainsKey(iff))
            {
                Image = imm[iff];
            }
            else
            {

            }
        }

  
        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            return new Surface(element, meshCreator);

        }

    }
}