using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf
{
    partial class ColladaObject
    {
        Dictionary<Type, Func<XmlElement, object, object>> combined;

        #region Combined functions

        #region Combine Members


        object GetBlur(XmlElement element, object o)
        {
            return null;
        }

        object GetArray(XmlElement element, object o)
        {
            Array arr = o as Array;
            return o;
        }

        object GetScene(XmlElement element, object o)
        {
            var scene = o as Scene;
            var xml = scene.Xml;

            return o;
        }



        object GetVisual3D(XmlElement element, object o)
        {
            var visual3D = o as Visual3D;
            if (visual3D is ModelVisual3D mod)
            {
                var c = mod.Content;
                if (c is GeometryModel3D g3d)
                {
                    var g = g3d.Geometry;
                    if (g is MeshGeometry3D m3d)
                    {
                        element.Set(m3d);
                    }
                }
            }

            return visual3D;
        }


        #endregion

        #endregion

    }
}
