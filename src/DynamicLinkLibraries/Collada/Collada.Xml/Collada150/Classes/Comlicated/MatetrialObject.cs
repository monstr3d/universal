using System;
using System.Xml;
using System.Collections.Generic;
using Collada;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Interfaces;

namespace Collada150.Classes.Comlicated
{
    [Tag("material")]
    internal class MaterialObject : XmlHolder, IMeshCreatorHolder
    {

        IMeshCreator meshCreator;


        public Material Material
        {
            get;
            private set;
        }

        void Set(IMeshCreator meshCreator)
        {
            this.meshCreator = meshCreator;
            var materials = meshCreator.Materials;
        }

        public static IClear Clear => StaticExtensionCollada.GetClear<MaterialObject>();

        IMaterialCreator IMeshCreatorHolder.MeshCreator { get => meshCreator; set => Set(value); }

        private MaterialObject(XmlElement element) : base(element)
        {
            var id = element.GetAttribute("id");
            var mtr = StaticExtensionColladaWpf.GetMaterial(id);
            if (mtr != null)
            {
                Material = mtr;
            }
            else
            {
                if (element.ChildNodes.Count != 1)
                {
                    throw new Exception();
                }
                var m = element.FirstElement().Get() as InstanceEffect;
                var o = m.Url.FromCollada();
                if (o is Material mat)
                {
                    Material = mat;
                }
                else
                {

                }
            }
            if (materials.ContainsKey(id))
            {
                throw new Exception();
            }
            materials[id] = Material;
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new MaterialObject(element);
            return a.Get();
        }

        internal static Material Get(string s)
        {
            if (!materials.ContainsKey(s))
            {
                throw new Exception();
            }
            return materials[s];
        }

    }
}
