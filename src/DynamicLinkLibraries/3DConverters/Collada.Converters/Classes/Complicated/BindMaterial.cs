using System.Xml;
using System;
using Collada;
using Abstract3DConverters.Interfaces;
using ErrorHandler;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("bind_material")]
    public class BindMaterial : XmlHolder
    {
        public static IClear Clear => StaticExtensionCollada.GetClear<BindMaterial>();


        public Abstract3DConverters.Materials.Effect Effect 
        { 
            get; 
            private set; 
        }
        private BindMaterial(XmlElement element) : base(element, null)
        {
            try
            {
                var inst = element.GetAllChildren<Instance_Material>();
                if (inst == null)
                {
                    return;
                }
                foreach (var i in inst)
                {
                    Effect = i.Effect;
                    break;
                }
            }
            catch (Exception ex)
            {
                ex.HandleException("Bind material");
                throw new IncludedException(ex, "Bind material");
            }

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new BindMaterial(element);
            return a.Get();
        }
    }
}