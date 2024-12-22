using System.Xml;
using Collada;
using Abstract3DConverters.Interfaces;

namespace Collada150.Classes.Complicated
{
    [Tag("instance_geometry")]
    public class InstanceGeomery : XmlHolder
    {
  
        public static IClear Clear => StaticExtensionCollada.GetClear<InstanceGeomery>();



        public GeometryObject Geometry { get; private set; }



        private InstanceGeomery(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator )
        {
            var url = element.GetAttribute("url").Substring(1);
            Geometry = url.Get<GeometryObject>();

           // Geometry = MeshCreator.Geom[url];
   /*         if (url.Length != 0)
            {
                if (url == "ID126")
                {

                }

                if (url.Length != 0)
                {
                    if (url == "ID126")
                    {

                    }
                    var t = url.Get<GeometryObject>();
                    if (t == null)
                    {
                        return;
                    }
                    Visual3D = t.Visual3D;
                    if (Visual3D == null)
                    {
                        throw new Exception();
                    }
                    if (Visual3D is ModelVisual3D model)
                    {
                        var g = model.Content as GeometryModel3D;
                        g.Material = Material;
                    }
                }
                if (Visual3D == null)
                {
                    throw new Exception();
                }
                if (Visual3D is ModelVisual3D modelVisual)
                {
                    var c = modelVisual.Content;
                    if (c is GeometryModel3D g)
                    {
                        if (g.Material == null)
                        {
                            var b = element.Get<Instance_Material>();
                            if (b != null)
                            {
                                g.Material = b.Material;
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }*/
        }


        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new InstanceGeomery(element,  meshCreator);
            return a.Get();
        }
    }
}