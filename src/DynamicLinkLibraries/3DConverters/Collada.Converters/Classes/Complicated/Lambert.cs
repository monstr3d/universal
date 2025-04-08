using System.Xml;

using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

using Collada.Converters.Classes.Abstract;
using NamedTree;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("lambert")]
    internal class Lambert : AbstractMaterial
    {
        public static IClear Clear => StaticExtensionCollada.GetClear<Lambert>();


        private Lambert(XmlElement xmlElement, IMeshCreator meshCreator) : base(xmlElement, meshCreator)
        {
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Lambert(element, meshCreator);
            return a;
        }

        protected override void Create(XmlElement xmlElement)
        {
            base.Create(xmlElement);
            base.Create(xmlElement);
            var l = new List<Abstract3DConverters.Materials.SimpleMaterial>();
            var transparent = s.Maximal(DiffuseColor);
            var ambient = s.Maximal(Ambient);
            float tr = (float)Transparency;
            if (tr < 0)
            {
                tr = 0;
            }
            var diffuse = new DiffuseMaterial(transparent, ambient, 1f - tr);
            l.Add(diffuse);
            if (Emission != null)
            {
                var emis = new EmissiveMaterial(Emission);
                l.Add(emis);
            }
            if (Specular != null)
            {
                var specu = new SpecularMaterial(Specular, (float)Shinines);
                l.Add(specu);
            }
            var mat = new LambertMaterial(Name, xmlElement);
            IChildren<SimpleMaterial> c = mat;
            foreach (var mt in l)
            {
                c.AddChild(mt);
            }
            Effect = new Abstract3DConverters.Materials.Effect(meshCreator, Name, mat, Image);

         }

    }
}