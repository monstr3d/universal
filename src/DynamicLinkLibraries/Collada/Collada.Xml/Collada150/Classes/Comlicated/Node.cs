
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Xml;
using Collada;

namespace Collada150.Classes.Comlicated
{
    [Tag("node")]
    public class Node : XmlHolder
    {
        /*       static public readonly string Tag = "node";

               public List<Node> Chidren => childern;

               public static List<XmlElement> Roots => roots;

               public List<Visual3D> Visual3Ds => visual3Ds;

               static Dictionary<XmlElement, Node> dic = new();

               List<Node> childern = new();

               public Node Parent { get; private set; }

               public GeometryObject Geometry { get; private set; }

               public Visual3D Visual3D { get; private set; }

               public Material Material { get; private set; }

               public static List<XmlElement> roots = new();

               bool isCombined = false;

               public string Name { get; private set; }

               public string Id { get; private set; }

               public InstanceGeomery InstanceGeomery { get; private set; }

               List<Visual3D> visual3Ds = new();

               internal static void Clear()
               {
                   dic.Clear();
                   roots.Clear();
               }


               static List<ModelVisual3D> lm = new();
               List<Visual3D> GetVisual3D()
               {
                   var vis = Visual3D as ModelVisual3D;
                   if (vis != null)
                   {
                       if (childern.Count == 0)
                       {
                           return new() { vis };
                       }
                   }
                   var l = new List<Visual3D>();
                   foreach (var child in childern)
                   {
                       var c = child.GetVisual3D();
                       if (c == null)
                       {
                           continue;
                       }
                       foreach (var v3 in c)
                       {
                           ModelVisual3D modelVisual3D = v3 as ModelVisual3D;
                           var cnt = modelVisual3D.Content as GeometryModel3D;
                           var mat = cnt.Material;
                           if (mat != null)
                           {
                               EmissiveMaterial emi = null; ;
                               SpecularMaterial spec = null;
                               var color = new System.Windows.Media.Color { A = 0, R = 0, G = 0, B = 0 };
                               if (mat is MaterialGroup group)
                               {
                                   foreach (var mm in group.Children)
                                   {
                                       if (mm is DiffuseMaterial material)
                                       {
                                           if (material.Brush != null)
                                           {
                                               l.Add(v3);
                                               emi = null;
                                               spec = null;
                                               break;
                                           }
                                           else
                                           {
                                               System.Windows.Media.Brush brush =
                                                   new SolidColorBrush(color);
                                               material.Brush = brush;
                                               material.Color = color;
                                           }
                                       }
                                       if (mm is EmissiveMaterial e)
                                       {
                                           emi = e;
                                       }
                                       if (mm is SpecularMaterial ss)
                                       {
                                           spec = ss;
                                       }
                                   }
                               }
                               if (spec != null)
                               {
                                   spec.SpecularPower = 0;
                                   spec.Color = color;
                               }
                               if (emi != null)
                               {
                                   emi.Color = color;
                               }

                           }
                           if (vis == null)
                           {
                           }
                       }
                   }
                   return l;

               }



       *./

               private Node(XmlElement element) : base(element)
               {
                   Id = element.GetAttribute("id");
                   Name = element.GetAttribute("name");
                   //var ig = element.Get<InstanceGeomery>();
                   var cn = element.GetOwnChildren<InstanceGeomery>().ToArray();
                   if (cn.Length == 1)
                   {
                       var ig = cn[0];
                       Visual3D = ig.Visual3D;
                       if (Visual3D == null)
                       {

                       }
                       try
                       {
                           Visual3D.Check();
                       }
                       catch (Exception ex)
                       {
                           throw ex;
                       }
                       var mat = element.Get<Matrix>();
                       if (mat != null)
                       {
                           var mm = mat.Matrix3D;
                           if (mm != null)
                           {
                               Visual3D.Transform = new MatrixTransform3D(mm);
                           }
                       }
                       var bind_mat = element.Get<BindMaterial>();
                       if (bind_mat != null)
                       {
                           var material = bind_mat.Material;
                           if (material != null)
                           {
                               ModelVisual3D modelVisual3D = Visual3D as ModelVisual3D;
                               if (modelVisual3D.Content is GeometryModel3D g)
                               {
                                   if (g.Material != material)
                                   {
                                       g.Material = material;
                                   }
                                   if (g.Geometry is MeshGeometry3D meshGeometry)
                                   {

                                   }
                               }
                           }
                       }

                   }
                   //          Geometry = GeometryObject.Get(Name);
                   if (Geometry != null)
                   {
                       // Visual3D = Geometry.Visual3D;
                   }
                   var p = element.ParentNode.Name;
                   if (p != Tag)
                   {
                       if (!roots.Contains(element))
                       {
                           roots.Add(element);
                       }
                   }
                   if (Visual3D == null)
                   {
                       Visual3D = new ModelVisual3D();
                   }

                   var nk = element.GetElements().Where(e => e.ParentNode == element & e.Name == Tag);
                   foreach (XmlElement xmlElement in nk)
                   {
                       if (roots.Contains(xmlElement))
                       {
                           roots.Remove(xmlElement);
                       }
                       var child = new Node(xmlElement);
                       dic[xmlElement] = child;
                       child.Parent = this;
                       childern.Add(child);
                       var v3d = child.Visual3D;
                       if (v3d == null)
                       {

                       }
                       if (v3d != null)
                       {
                           if (Visual3D == null)
                           {
                               continue;
                           }
                           if (Visual3D is ModelVisual3D model)
                           {
                               if (!model.Children.Contains(v3d))
                               {
                                   model.Children.Add(v3d);
                               }
                           }
                       }
                   }
               }

               void Combine()
               {
                   if (isCombined)
                   {
                       return;
                   }
                   foreach (var child in childern)
                   {
                       //   child.Combine();
                   }
                   CombineItself();
                   isCombined = true;
               }


               void CombineItself()
               {

                   var x = Xml;
                   if (Chidren.Count == 0)
                   {
                       InstanceGeomery = x.Get<InstanceGeomery>();
                       if (InstanceGeomery == null)
                       {
                           throw new Exception();
                       }
                       InstanceGeomery.Combine();
                   }
                   else
                   {
                       return;
                       foreach (var node in Chidren)
                       {
                           var v3d = node.Visual3D;
                           if (v3d != null)
                           {
                               visual3Ds.Add(v3d);
                           }
                           else
                           {
                               visual3Ds.AddRange(node.Visual3Ds);
                           }
                       }
                   }
                   if (Visual3D != null)
                   {
                       if (visual3Ds.Count > 0)
                       {
                       }
                   }
               }

               static public object Get(XmlElement element)
               {
                   if (dic.ContainsKey(element))
                   {
                       return dic[element];
                   }
                   var a = new Node(element);
                  // a.Combine();
                   return a.Get();
               }

               public static ModelVisual3D GetAll()
               {
                   ModelVisual3D mod;
                   if (roots.Count == 1)
                   {
                       var o = roots[0].Get() as Node;
                       mod = o.Visual3D as ModelVisual3D;
                       mod.SetLight();
                       return mod;
                   }
                   else
                   {
                       mod = new ModelVisual3D();
                       var children = mod.Children;
                       foreach (var root in roots)
                       {
                           var r = root.Get() as Node;
                           var p = r.Visual3D as ModelVisual3D;
                           if (p == null)
                           {
                               continue;
                           }
                           if (!children.Contains(p))
                           {
                               children.Add(p);
                               p.SetLight();
                           }
                       }
                   }
                   mod.SetLight();
                   return mod;
               }*/
    }
}