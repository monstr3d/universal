using System.Windows.Media.Media3D;
using System.Xml;
using System;
using System.Collections.Generic;

namespace Collada.Wpf.Classes
{
    [Tag("geometry")]
    public class GeometryObject : Collada.XmlHolder
    {
        static public readonly string Tag = "geometry";

        public Visual3D Visual3D { get; private set; }


        public static IClear Clear => StaticExtensionCollada.GetClear<GeometryObject>();

        static Dictionary<string, GeometryObject> byName = new ();

        static public GeometryObject Get(string name)
        {
            if (byName.ContainsKey(name))
            {
                return byName[name];
            }
            return null;

        }

        static internal void ClearItSelf()
        {
            byName.Clear();
        }

        private GeometryObject(XmlElement element) : base(element)
        {
            var name = element.GetAttribute("name");
            if (name.Length > 0)
            {
                if (byName.ContainsKey(name))
                {
                    throw new Exception();
                }
                byName[name] = this;
            }
            var mesh = element.Get<MeshObject>();
            if (mesh == null)
            {
                throw new Exception();
            }
            var geom = new GeometryModel3D();
            geom.Geometry = mesh.MeshGeometry3D;
            geom.Material = mesh.Material;
            var mod = new ModelVisual3D();
            mod.Content = geom;
            Visual3D = mod;
            if (geom.Material == null)
            {
                var id = element.GetAttribute("id");
            }
        }

        object Get()
        {
            return Visual3D;
        }

        public static object Get(XmlElement element)
        {
            var a = new GeometryObject(element);
            return a.Get();
        }
    }
}