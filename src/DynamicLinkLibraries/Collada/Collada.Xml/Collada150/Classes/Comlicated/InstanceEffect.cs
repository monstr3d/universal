using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada150.Classes.Comlicated
{
    [Tag("instance_effect")]
    internal class InstanceEffect : XmlHolder
    {


        public static IClear Clear => StaticExtensionCollada.GetClear<InstanceEffect>();

        public string Url { get; private set; }
        private InstanceEffect(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            Url = element.GetAttribute("url").Substring(1);
            // throw new Exception();
            /*          var material = url.FromCollada() as Material;
                      if (material == null)
                      {

                      }
                      else
                      {
                        //  Material = material;
                      }*/

        }
        /*
                Material GetInstanceEffect(XmlElement element)
                {
          /*          var url = element.GetAttribute("url").Substring(1);
                    Material m = url.FromCollada() as Material;
                    if (m == null)
                    {
                        throw new Exception();
                    }
                    if (element.ChildNodes.Count != 0)
                    {
                        throw new Exception();
                    }
                    return m;
                }
        */

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new InstanceEffect(element, meshCreator);
            return a.Get();
        }
    }
}