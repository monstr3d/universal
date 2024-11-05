using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;
using System.Xml;


namespace Collada.Wpf.Classes
{
    [Tag("phong")]
    internal class Phong : Collada.Wpf.Classes.XmlHolder
    {
        static Dictionary<Material, List<object>> keyValuePairs = new();
        static List<SpecularMaterial> speculars = new();
        static List<Material> phong = new List<Material>();

        public static bool IsReflexive(SpecularMaterial sp)
        {
            return speculars.Contains(sp);
        }

        public static bool IsPhong(SpecularMaterial sp)
        {
            return phong.Contains(sp);
        }


        static Phong()
        {
            keyValuePairs = new();
            speculars = new();
            phong = new();
        }
        static internal void Clear()
        {
            keyValuePairs.Clear();
            speculars.Clear();
            phong.Clear();
        }


        private Phong(XmlElement element) : base(element)
        {

        }

        public static List<object> GetList(Material material)
        {
            if (keyValuePairs.ContainsKey(material))
            {
                return keyValuePairs[material];
            }
            return null;
        }

        object Get()
        {
            return GetPhong(Xml);
        }

        public static object Get(XmlElement element)
        {
            var a = new Phong(element);
            return a.Get();
        }

        private Material GetPhong(XmlElement e)
        {
            var list = new List<object>();
            List<Material> l = new List<Material>();
            Transparent transparent = null;
            object reflectivity = null;
            foreach (XmlNode n in e.ChildNodes)
            {
                if (n is XmlElement el)
                {
                    var nm = el.Name;
                    if (Function.IsMaterial(nm))
                    {
                        Material mat = el.Get() as Material;
                        if (mat != null)
                        {
                            keyValuePairs[mat] = list;
                            l.Add(mat);
                            phong.Add(mat);
                            continue;
                        }
                        throw new Exception();
                    }
                    if (nm == "transparent")
                    {
                        transparent = el.Get() as Transparent;
                        if (transparent == null)
                        {
                            throw new Exception();
                        }
                        list.Add(transparent);
                        continue;
                    }
                    if (nm == "reflectivity")
                    {
                        reflectivity = el.Get();
                        if (reflectivity == null)
                        {
                            throw new Exception();
                        }
                        list.Add(reflectivity);
                        continue;
                    }
                    throw new Exception();


                }

            }
            var res = l.SimplifyMaterial();
            phong.Add(res);
            keyValuePairs[res] = list;
            if (reflectivity == null)
            {
                return res;
            }
            foreach (var m in l)
            {

                if (m is SpecularMaterial sp)
                {
                    speculars.Add(sp);
                    sp.SpecularPower = 100 * reflectivity.NumberToDouble();
                }
                if (transparent != null)
                {
                    if (m is DiffuseMaterial dm)
                    {
                        var br = dm.Brush;
                        //            br.Opacity = transparent.
                    }
                }
            }
            return res;
        }


    }
}
