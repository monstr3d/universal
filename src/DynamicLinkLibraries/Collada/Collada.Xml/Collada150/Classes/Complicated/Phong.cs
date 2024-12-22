using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Collada;

namespace Collada150.Classes.Complicated
{
    [Tag("phong")]
    internal class Phong : Collada.XmlHolder
    {
        public static IClear Clear => StaticExtensionCollada.GetClear<Phong>();

        internal List<Abstract3DConverters.Materials.Material> Materials { get; private set; }
        private Phong(XmlElement xmlElement) : base(xmlElement)
        {
            var transparency = xmlElement.Get<Transparency>().Value;
            var shinines = xmlElement.Get<Shininess>().Value;
            var ambient = xmlElement.Get<Ambient>().Color;
            var specular = xmlElement.Get<Specular>().Color;
            var emission = xmlElement.Get<Emission>().Color;
            var transparent = xmlElement.Get<Transparent>().Color;
            var texture = xmlElement.Get<Texture>();
            var s2d = texture.Sampler2D;
            var su = s2d.Surface;
            var im = su.Image;
            var l = new List<Abstract3DConverters.Materials.Material>();
            var diffuse = new DiffuseMaterial(transparent, ambient, im, 1f - (float)transparency);
            l.Add(diffuse);
            var emis = new EmissiveMaterial(emission);
            l.Add(emis);
            var specu = new SpecularMaterial(specular, (float)shinines);
            l.Add(specu);
            Materials = l;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Phong(element);
            return a; ;
        }
    }
}
