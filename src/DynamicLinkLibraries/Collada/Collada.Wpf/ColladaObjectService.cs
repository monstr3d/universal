using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Media3D;

namespace Collada.Wpf
{
    partial class ColladaObject
    {


        public static Func<int, Material> GetDefaultMaterial
        {
            get;
            set;
        }

        public List<Visual3D> Visual3DRoots
        {
            get
            {
                var l = StaticExtensionCollada.GetElements<Visual3D>().ToList();
                var children = new List<Visual3D>();
                foreach (var child in l)
                {
                    if (child  is ModelVisual3D model3)
                    {
                        var c = model3.Children;
                        foreach (var ch in c)
                        {
                            if (!children.Contains(ch))
                            {
                                throw new Exception();
                            }
                            children.Add(ch);
                        }
                    }
                }
                var parents = new List<Visual3D>();
                foreach (var item in l)
                {
                    if (!children.Contains(item))
                    {
                        parents.Add(item);
                    }
                }
                return parents;
            }
        }
    }
}