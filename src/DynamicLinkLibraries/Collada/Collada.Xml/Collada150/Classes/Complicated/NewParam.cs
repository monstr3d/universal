using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;
using Collada150.Creators;

namespace Collada150.Classes.Complicated
{
    [Tag("newparam")]
    internal class NewParam : Collada.XmlHolder
    {
        public static IClear Clear => StaticExtensionCollada.GetClear<NewParam>();

        internal Surface Surface { get; private set; }

        internal Sampler2D Sampler2D { get; private set; }

        internal NewParam(XmlElement xmlElement, IMeshCreator meshCreator) : base(xmlElement)
        {
            Collada15MeshCreator creator = meshCreator as Collada15MeshCreator;
            var sid = xmlElement.GetAttribute("sid");
            Surface = xmlElement.Get<Surface>();
            if (Surface == null)
            {
                Sampler2D = xmlElement.Get<Sampler2D>();
                if (Sampler2D == null)
                {
                    throw new Exception();
                }
                creator.Samples2D[sid] = this;
                return;

            }
            creator.Surfaces[sid] = this;
        }


        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            return new NewParam(element, meshCreator);
        }
    }
}