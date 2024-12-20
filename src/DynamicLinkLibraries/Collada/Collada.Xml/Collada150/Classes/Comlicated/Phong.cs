using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Documents;
using System.Windows.Media.Media3D;
using System.Xml;
using Collada;


namespace Collada150.Classes.Comlicated
{
    [Tag("phong")]
    internal class Phong : XmlHolder
    {
        /*
                public Material Material { get; private set; }
                static Dictionary<Material, List<object>> keyValuePairs = new();
                static List<SpecularMaterial> speculars = new();
                static List<Material> phong = new List<Material>();

                public DiffuseMaterial DiffuseMaterial { get; private set; } = null;

                public SpecularMaterial SpecularMaterial { get; private set; } = null;

                public EmissiveMaterial EmissiveMaterial { get; private set; } = null;

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
                     var l = new List<Material>();
                    foreach (XmlNode n in Xml.ChildNodes)
                    {
                        if (n is XmlElement el)
                        {
                            var nm = el.Name;
                            if (Function.IsMaterial(nm))
                            {
                                Material mat = el.Get() as Material;
                                if (mat != null)
                                {
                                    l.Add(mat);
                                    switch (mat)
                                    {
                                        case DiffuseMaterial diffuse:
                                            DiffuseMaterial = diffuse;
                                            break;
                                        case SpecularMaterial specular:
                                            SpecularMaterial = specular;
                                            SpecularMaterial.SpecularPower = 1;
                                            break;
                                        case EmissiveMaterial emissive:
                                            EmissiveMaterial = emissive;
                                            break;
                                    }
                                    continue;
                                }
                                throw new Exception();
                            }
                        }
                    }
                    SpecularMaterial.Set(element);
                    EmissiveMaterial.Set(element);
                    Material = l.SimplifyMaterial();
                }

                public static List<object> GetList(Material material)
                {
                    if (keyValuePairs.ContainsKey(material))
                    {
                        return keyValuePairs[material];
                    }
                    return null;
                }

                protected override object Get()
                {
                    return Material;
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
                                    switch (mat)
                                    {
                                        case DiffuseMaterial diffuse:
                                            DiffuseMaterial = diffuse;
                                            break;
                                        case SpecularMaterial specular:
                                            SpecularMaterial = specular;
                                            break;
                                        case EmissiveMaterial emissive:
                                            EmissiveMaterial = emissive;
                                            break;
                                    }
                                    continue;
                                }
                                throw new Exception();
                            }
                        }
                    }
                    reflectivity = e.GetAllChildren<Reflectivity>().ToArray();
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
                            sp.SpecularPower =  reflectivity.NumberToDouble();
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
        */

    }
}
