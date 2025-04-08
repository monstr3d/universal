using System.Xml;

using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

using Collada.Converters.Classes.Abstract;



namespace Collada.Converters.Classes.Complicated
{
    [Tag("phong")]
    internal class Phong : AbstractMaterial
    {
        public static IClear Clear => StaticExtensionCollada.GetClear<Phong>();


        private Phong(XmlElement xmlElement, IMeshCreator meshCreator) : base(xmlElement, meshCreator)
        {

        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Phong(element, meshCreator);
            return a;
        }

        protected override void Create(XmlElement xmlElement)
        {
            try
            {
                base.Create(xmlElement);
                var l = new List<Abstract3DConverters.Materials.SimpleMaterial>();
                var diffuse = new DiffuseMaterial(DiffuseColor, Ambient, 1f - (float)Transparency);
                l.Add(diffuse);
                var emis = new EmissiveMaterial(Emission);
                l.Add(emis);
                var specu = new SpecularMaterial(Specular, (float)Shinines);
                l.Add(specu);
                var mat = new PhongMaterial(Name, xmlElement);
                performer.AddChildren<SimpleMaterial>(mat, l);
                Effect = new Abstract3DConverters.Materials.Effect(meshCreator, Name, mat, Image);
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Phong error");
            }
        }
    }
}