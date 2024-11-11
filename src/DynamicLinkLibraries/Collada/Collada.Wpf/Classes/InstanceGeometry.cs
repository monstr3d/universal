using System.Windows.Media.Media3D;
using System.Xml;
using System;

namespace Collada.Wpf.Classes
{
    [Tag("instance_geometry")]
    public class InstanceGeomery : XmlHolder
    {
        static public readonly string Tag = "instance_geometry";

        public Material Material { get; private set; }

        public Visual3D Visual3D { get; private set; }

        public void Combine()
        {
            /*
            if (isCombined)
            {
                return;
            }
            var x = Xml;
            var b = x.Get<BindMaterial>();
            if (b != null)
            {
                Material = b.Material;
            }
            else
            {
                throw new Exception();
            }

            isCombined = true;*/
        }


        private InstanceGeomery(XmlElement element) : base(element)
        {
            var url = element.GetAttribute("url").Substring(1);
            if (url.Length != 0)
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
            }
        }


        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new InstanceGeomery(element);
            return a.Get();
        }
    }
}