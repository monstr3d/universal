using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class InstanceEffect : XmlHolder
    {
        static public readonly string Tag = "instance_effect";

        private InstanceEffect(XmlElement element) : base(element)
        {

        }

        Material GetInstanceEffect(XmlElement element)
        {
            var m = element.Get();
            if (m is Material mat)
            {
                return mat;
            }
            var url = element.GetAttribute("url").Substring(1);
            var c = url.ToIdName();
            var xml = c.Xml;
            List<Material> l = new List<Material>();
            var nl = xml.GetElementsByTagName("phong")[0];
            Material material = null;
            foreach (XmlElement e in nl.ChildNodes)
            {
                var nm = e.Name;
                material = Function.MaterialFromName(nm);
                if (material == null)
                {
                    continue;
                }
                Type t = material.GetType();
                l.Add(material);
                foreach (XmlElement ee in e.ChildNodes)
                {
                    var sn = ee.Name;
                    if (sn == "color")
                    {
                        var color = ee.GetColor();
                        var cp = t.GetProperty("Color") as PropertyInfo;
                        cp.SetValue(material, color);
                    }
                    else if (sn == "reflectivity")
                    {
                        var d = ee.ToDouble();
                        var cr = t.GetProperty("SpecularPower");
                        cr.SetValue(material, d);

                    }
                    else if (sn == "texture")
                    {
                        var coord = ee.GetAttribute("texcoord");
                        var cg = coord.ToIdName();


                        var txtr = ee.GetAttribute("texture");
                        var ttxt = txtr.GetObject();
                    }
                }
            }
            return l.SimplifyMaterial();
        }

        object Get()
        {
            return GetInstanceEffect(Xml);
        }

        public static object Get(XmlElement element)
        {
            var a = new InstanceEffect(element);
            return a.Get();
        }
    }
}