using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Collada.Converters.Classes.Abstract;
using System.Xml;

namespace Collada.Converters.Classes.Complicated
{

    [Tag("blinn")]
    internal class Blinn : AbstractMaterial
    {
        public static IClear Clear => StaticExtensionCollada.GetClear<Blinn>();


        private Blinn(XmlElement xmlElement, IMeshCreator meshCreator) : base(xmlElement, meshCreator)
        {
  
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Blinn(element, meshCreator);
            return a;
        }

        protected override void Create(XmlElement xmlElement)
        {
            base.Create(xmlElement);
            var l = new List<Abstract3DConverters.Materials.Material>();
            var transparent = s.Maximal(Transparent);
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
            var mat = new BlinnMaterial(Name, xmlElement);
            foreach (var mt in l)
            {
                mat.Children.Add(mt);
            }
            Effect = new Abstract3DConverters.Materials.Effect(meshCreator, Name, mat, Image);
        }

    }

}
