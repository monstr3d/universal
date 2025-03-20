using System.Xml;

using Abstract3DConverters;
using Abstract3DConverters.Interfaces;

using Collada.Converters.Classes.Abstract;
using Collada.Converters.MeshCreators;


namespace Collada.Converters.Classes.Complicated
{
    [Tag("effect")]
    internal class Effect : Collada.XmlHolder
    {



        internal Abstract3DConverters.Materials.Effect EffectP { get; private set; }

        public static IClear Clear => StaticExtensionCollada.GetClear<Effect>();



        private Effect(XmlElement element, IMeshCreator meshCreator) : base(element)
        {
            try
            {
                AbstractMaterial mat = null;
                ColladaMeshCreator creator = meshCreator as ColladaMeshCreator;
                bool success = false;
                var phong = element.Get<Phong>();
                if (phong != null)
                {
                    mat = phong;
                }
                else
                {
                    var blinn = element.Get<Blinn>();
                    mat = blinn;
                    if (blinn == null)
                    {
                        var lambert = element.Get<Lambert>();
                        mat = lambert;
                    }    
                }
                if (mat == null)
                {
                    throw new Exception("NULL ABSTRACT MATERIAL");
                }
                EffectP = mat.Effect;
                creator.Eff[EffectP.Name] = this;
            }
            catch (Exception e)
            {
                e.HandleExceptionDouble("Collada Effect");
            }
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Effect(element, meshCreator);
            return a;
        }
    } 
}