using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Xml;


namespace Collada.Wpf
{
    public partial class ColladaObject : ICollada
    {

        #region Fields
        public enum UpDirection
        {
            None,
            X, Y, Z
        };

        public UpDirection Direction 
        { 
            get; 
            private set; 
        }= UpDirection.None;

        Dictionary<string, List<XmlElement>> elementList;

        #endregion

        public ColladaObject()
        {
            elementList = new();
            materials = new();
          sourceDic  = new()
       {
 {"float_array", GetFloatArray}
       };

            combined = new()
        {
            { typeof(BlurEffect), GetBlur },
            {typeof(Array), GetArray },
            {typeof(Visual3D), GetVisual3D},
            {typeof(Scene), GetScene}
            };
         

        materialCalc    = new()
                {
               { "phong", GetPhong},
                {"effect", GeEffectMaterial}
                };

        materialTypes    = new Dictionary<string, Type>()
        {
                 {"diffuse", typeof(DiffuseMaterial)},
            {"specular", typeof(SpecularMaterial)},
            {"reflective", typeof(EmissiveMaterial)}
        };
            functions = new()           {
{"float_array",  StaticExtensionCollada.GetArray<float>},
{"geometry", GetGeometry },
{"phong", GetPhongObject },             

{"material", GetMaterial},
{"image", GetImage},
{"source", GetSource},
{"vertices", GetVetrices<float>},
{"p",GetP},
         { "library_visual_scenes", GetScenes },
                {"instance_effect", CalculateMaterialObject },
                               {"up_axis", SetUpAxis },
                               {"unit", SetUnit }
 
                // */
  };
            visualDic = new()
       {
 {"mesh", GetMesh}
       };
            StaticExtensionCollada.Collada = this;

        }

        #region Temp

        public Unit MeterUnit 
        { get; private set; } = null;

        object SetUpAxis(XmlElement element)
        {
            var up = UpDirection.None;
            if (element.InnerText == "Y_UP")
            {
                up = UpDirection.Y;
            }
            Direction = up;
            return up;
        }

        object SetUnit(XmlElement xmlElement)
        {
            var unit = new Unit { Text = xmlElement.InnerXml };
            MeterUnit = unit;
            return unit;
        }

        public class Unit
        {
            public string Text { get; set; }
        }


        #region

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
        /// The unique of element
        /// </summary>
        /// <param name="xmlElement">TheElement</param>
        /// <returns>The id</returns>
        string ICollada.UniqueId(XmlElement xmlElement)
        {
            var id = xmlElement.GetAttribute("id");
            if (id.Length == 0)
            {
                return null;
            }
            var name = xmlElement.GetAttribute("name");
            return id + "@" + name;
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

        /// <summary>
        /// Puts Xml element
        /// </summary>
        /// <param name="xmlElement"></param>
        void ICollada.Put(XmlElement xmlElement)
        {
            var id = xmlElement.GetAttribute("id");
            if (id.Length == 0)
            {
                return;
            }
            List<XmlElement> l = null;
            if (elementList.ContainsKey(id))
            {
                l = elementList[id];
            }
            else
            {
                l = new List<XmlElement>();
                elementList[id] = l;
            }
            l.Add(xmlElement);
         }

        /// <summary>
        /// The unknown element
        /// </summary>
        /// <param name="xmlElement">The element</param>
        /// <returns>Thue if it is unknown</returns>
        bool ICollada.IsUnknown(XmlElement xmlElement)
        {
            var n = xmlElement.Name;
            return unknown.Contains(xmlElement.Name);
        }

        List<string> unknown = new()
        {
            "author", "authoring_tool", "comments", "copyright", "contributor",
            "created", "modified", "asset"
        };


        #endregion

        public void Load(string fileName)
        {
            StaticExtensionCollada.Load(fileName);
        }

        #endregion

    }
    #endregion
}
