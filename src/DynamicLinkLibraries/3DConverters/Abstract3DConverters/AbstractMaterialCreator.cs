using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public abstract class AbstractMaterialCreator : IMaterialCreator
    {
        public abstract Assembly Assembly {get;}
        public abstract void Add(object group, object value);

        public abstract object Create(Image image);

        public abstract object Create(Color color);

        public virtual object Create(Material material)
        {
           object result = null;
           switch (material)
            {
                case DiffuseMaterial diffuseMaterial:
                    result =  Create(diffuseMaterial);
                    SetImage(result, diffuseMaterial.Image);
                    break;
                case EmissiveMaterial emissiveMaterial:
                    result = Create(emissiveMaterial);
                    break;   
                    case SpecularMaterial specularMaterial:
                    result = Create(specularMaterial);
                    SetPower(result, specularMaterial.SpecularPower);
                    break;
                case MaterialGroup group:
                        return Create(group);
                    break;
                default:
                    break;
            }
            //var simple = material as SimpleMaterial;
            //Set(result, simple.Color);
            return result;
        }

        public abstract object CreateGroup(MaterialGroup materialGroup);

        public virtual object Create(MaterialGroup material)
        {
            var o = CreateGroup(material);
            var childern = material.Children;
            foreach (var child in childern)
            {
                var childMaterial = Create(child);
                Add(o, childMaterial);
            }
            return o;
        }
        
        public abstract object Create(DiffuseMaterial material);

        public abstract object Create(SpecularMaterial material);

        public abstract object Create(EmissiveMaterial material);

        public abstract void Set(object material, object color);

        public abstract void SetImage(object material, object image);

        public abstract void SetOpacicty(object material, float opacity);

        public abstract void SetPower(object material, float power);


        public virtual void Set(object material, Color color)
        {
            var c = Create(color);
            Set(material, c);
        }

        public virtual void SetImage(object material, Image image)
        {
            if (image == null)
            {
                return;
            }
            var im = Create(image); 
            if (im == null)
            {
                return;
            }
            
            SetImage(material, im);
        }



    }
}
