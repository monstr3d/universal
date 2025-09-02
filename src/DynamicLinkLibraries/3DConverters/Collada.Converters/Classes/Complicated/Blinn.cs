using System.Xml;

using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

using Collada.Converters.Classes.Abstract;
using NamedTree;


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
                var blinn = new BlinnMaterial(Name, xmlElement);
                IChildren<SimpleMaterial> mat = blinn; 
                foreach (var mt in l)
                {
                    mat.AddChild(mt);
                }
                Effect = new Abstract3DConverters.Materials.Effect(meshCreator, 
                    Name, blinn, Image);
            }
            catch (Exception ex)
            {
                ex.HandleExceptionDouble("Blinn error");
            }
        }
    }
}
 