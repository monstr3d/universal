using System.Xml;

using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

using ErrorHandler;

namespace Collada.Converters.Classes.Complicated
{
    internal abstract class AbstractMaterial : Collada.XmlHolder
    {

        protected IMeshCreator meshCreator;

        internal Abstract3DConverters.Materials.Effect Effect { get; private set; }

        // internal List<Abstract3DConverters.Materials.Material> Materials { get; private set; }
        protected AbstractMaterial(XmlElement xmlElement, IMeshCreator meshCreator) : base(xmlElement)
        {
            this.meshCreator = meshCreator;
            try
            {
                XmlElement parent = xmlElement.ParentNode as XmlElement;
                while (true)
                {
                    if (parent.Name == "effect")
                    {
                        break;
                    }
                    parent = parent.ParentNode as XmlElement;
                }
                var name = parent.GetAttribute("id");
                double transparency = 0;
                var tr = xmlElement.Get<Transparency>();
                if (tr != null)
                {

                    transparency = tr.Value;
                }
                double shinines = 0;
                var sh = xmlElement.Get<Shininess>();
                if (sh != null)
                {
                    shinines = sh.Value;
                }
                Abstract3DConverters.Color ambient = null;
                var amb = xmlElement.Get<Ambient>();
                if (amb != null)
                {
                    ambient = amb.Color;
                }
                Abstract3DConverters.Color specular = null;
                var spec = xmlElement.Get<Specular>();
                if (spec != null)
                {
                    specular = spec.Color;
                }
                Abstract3DConverters.Color emission = null;
                var emi = xmlElement.Get<Emission>();
                if (amb != null)
                {
                    emission = emi.Color;
                }
                Abstract3DConverters.Color transparent = null;
                var trans = xmlElement.Get<Transparent>();
                if (trans != null)
                {
                    transparent = trans.Color;
                }
                var texture = xmlElement.Get<Texture>();
                Abstract3DConverters.Image im = null;
                if (texture != null)
                {
                    var s2d = texture.Sampler2D;
                    if (s2d != null)
                    {
                        var su = s2d.Surface;
                        if (su != null)
                        {
                            im = su.Image;
                        }
                    }
                }
                if (im == null)
                {
                    if (texture != null)
                    {
                        im = texture.Image;
                    }
                }
                var l = new List<Abstract3DConverters.Materials.Material>();
                var diffuse = new DiffuseMaterial(transparent, ambient, 1f - (float)transparency);
                l.Add(diffuse);
                var emis = new EmissiveMaterial(emission);
                l.Add(emis);
                var specu = new SpecularMaterial(specular, (float)shinines);
                l.Add(specu);
                var mat = new MaterialGroup(name);
                foreach (var mt in l)
                {
                    mat.Children.Add(mt);
                }
                Effect = new Abstract3DConverters.Materials.Effect(meshCreator, name, mat, im);
            }
            catch (Exception ex)
            {
                ex.ShowError();
                throw new IncludedException(ex, "BASE MATERIAL");
            }
        }

        protected abstract void Abstract();

   
    }
}
