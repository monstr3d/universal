using System;
using System.Collections.Generic;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Xml;


namespace Collada.Wpf
{
    internal partial class ColladaObject : ICollada
    {

        #region Fields

        #region Fields

        Dictionary<XmlElement, Material> materials = new();


        #endregion


        Dictionary<string, Func<XmlElement, object>> functions;

  
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
               materialCalc  =       new()
         { 
               { "phong", GetPhong},
                {"instance_effect", GetInstanceEffect}
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
            materials.Clear();
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

        #region 

        #endregion


        #region Functions Methods


        #endregion    
    }
}
