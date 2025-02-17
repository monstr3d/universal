
using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Collada.Converters.Classes.Complicated;

namespace Collada.Converters.Classes.Elementary
{
    [Tag("image", true)]
    internal class Image : XmlHolder
    {

        Service s = new ();


        public static IClear Clear => StaticExtensionCollada.GetClear<Image>();


        public Abstract3DConverters.Image ImageSource { get; private set; }

        private Image(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            var ifr = element.Get<Init_From>().Text;
            ImageSource = new Abstract3DConverters.Image(ifr, meshCreator.Directory);
            if (ImageSource.Name != null)
            {
                throw new Exception("YYYYYYYYYYYYYYYYYY");
             /*   if (!meshCreator.Images.ContainsKey(ImageSource.Name))
                {
                    meshCreator.Images[ImageSource.Name] = ImageSource;
                }*/
                MeshCreator.ImageIds[element.GetAttribute("id")] = ImageSource;
            }
            else
            {

            }
        }


        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Image(element, meshCreator);
            return a.Get();
        }
    }
}