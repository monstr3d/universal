using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Xml;


namespace Collada.Wpf
{
    internal partial class ColladaObject : ICollada
    {

        #region Fields

        Dictionary<string, Func<XmlElement, object>> functions;

        Dictionary<Type, Func<XmlElement, object, object>> combined;

        #endregion
        public ColladaObject()
        {
            combined = new()
        {
            { typeof(BlurEffect), GetBlur },
            {typeof(Array), GetArray },
            {typeof(Visual3D), GetVisual3D},
            {typeof(Scene), GetScene}
        };
        }

        #region ICollada Members

        /// <summary>
        /// Creation functions
        /// </summary>
        Dictionary<string, Func<XmlElement, object>> ICollada.Functions => functions;

        /// <summary>
        /// Combination function
        /// </summary>
        Dictionary<Type, Func<XmlElement, object, object>> ICollada.Combined => combined;


        /// <summary>
        /// Clears itself
        /// </summary>
        void ICollada.Clear()
        {

        }

        /// <summary>
        /// Clones object
        /// </summary>
        /// <param name="obj">The object to clone</param>
        /// <returns>CCloned object</returns>
        object ICollada.Clone(object obj)
        {
            return obj;
        }

        #endregion

        #region Combine Members

        static object GetBlur(XmlElement element, object o)
        {
            return null;
        }

        static object GetArray(XmlElement element, object o)
        {
            Array arr = o as Array;
            return o;
        }

        static object GetScene(XmlElement element, object o)
        {
            var scene = o as Scene;
            var xml = scene.Xml;

            return o;
        }

     
  
        static object GetVisual3D(XmlElement element, object o)
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

        #region Functions Methods


        #endregion    
    }
}
