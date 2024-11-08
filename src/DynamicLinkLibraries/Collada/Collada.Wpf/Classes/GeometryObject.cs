using System.Windows.Media.Media3D;
using System.Xml;
using System;

namespace Collada.Wpf.Classes
{
    [Tag("geometry")]
    internal class GeometryObject : Collada.XmlHolder
    {
        static public readonly string Tag = "geometry";

        public Visual3D Visual3D { get; private set; }

        private GeometryObject(XmlElement element) : base(element)
        {
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