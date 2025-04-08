using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Collada.Converters.Classes.Complicated;

using System.Xml;
using Effect = Abstract3DConverters.Materials.Effect;

namespace Collada.Converters.Classes.Abstract
{
    internal abstract class AbstractMaterial : Collada.XmlHolder
    {
        protected NamedTree.Performer performer = new NamedTree.Performer();

        protected Service s = new();

        protected IMeshCreator meshCreator;

        protected XmlElement xmlElement;

        internal Effect Effect { get; set; }

        protected double Transparency
        {
            get;
            set;
        } = 0;

        protected double Shinines
        {
            get;
            set;
        } = 0;

        protected Color Ambient
        {
            get;
            set;
        }

        protected Color Specular
        {
            get;
            set;
        }
        protected Color Emission
        {
            get;
            set;
        }

        private Color Transparent
        {
            get;
            set;
        }

        protected Color Diffuse
        {
            get;
            set;
        }

        protected Color DiffuseColor
        {
            get
            {
                if (Diffuse != null)
                {
                    return Diffuse;
                }
                return Transparent;
            }
        }

        

        protected string Name
        {
            get;
            set;
        }


        protected virtual void Create(XmlElement xmlElement)
        {
            try
            {
                var parent = ParentEffectXml;
                Name = parent.GetAttribute("id");
                var tr = xmlElement.Get<Transparency>();
                if (tr != null)
                {

                    Transparency = tr.Value;
                }
                var sh = xmlElement.Get<Shininess>();
                if (sh != null)
                {
                    Shinines = sh.Value;
                }
                var amb = xmlElement.Get<Ambient>();
                if (amb != null)
                {
                    Ambient = s.GetMinimal(amb.Color);
                }
                else
                {
                    Ambient = new Color();
                }
                var spec = xmlElement.Get<Specular>();
                Specular = s.GetMinimal(spec);
                var emi = xmlElement.Get<Emission>();
                Emission = s.GetMinimal(emi);
                var trans = xmlElement.Get<Transparent>();
                Transparent = s.GetMinimal(trans);
                 var diff = xmlElement.Get<Diffuse>();
                Diffuse = s.GetMinimal(diff);
                var texture = xmlElement.Get<Texture>();
                Image im = null;
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
                Image = im;
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Abstract material create");
            }
        }

        protected XmlElement ParentEffectXml
        {
            get
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
                return parent;
            }
        }

        // internal List<Abstract3DConverters.Materials.Material> Materials { get; private set; }
        protected AbstractMaterial(XmlElement xmlElement, IMeshCreator meshCreator) : base(xmlElement)
        {
            this.xmlElement = xmlElement;
            this.meshCreator = meshCreator;
            Create(xmlElement);
        }

        protected Image Image
        {
            get;
            set;
        }
   
    }
}
