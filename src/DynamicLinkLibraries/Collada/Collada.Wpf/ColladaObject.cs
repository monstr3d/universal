using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Xml;


namespace Collada.Wpf
{
    public partial class ColladaObject : ICollada, IFunction
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

        public static ColladaObject Instance = new ColladaObject();

        #endregion

        private ColladaObject()
        {
            elementList = new();
            materials = new();
            parametersNew = new();
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
                {"instance_effect", GetInstanceEffect },
                               {"up_axis", SetUpAxis },
                               {"unit", SetUnit }, { "effect",  GetEffectMaterialObject }, { "color", GetColorObject }
 
                // */
  };
            visualDic = new()
       {
 {"mesh", GetMesh}
       };
            StaticExtensionCollada.Collada = this;
            StaticExtensionCollada.Function = this;

        }

        

    
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

        Dictionary<string, XmlElement> parametersNew;


        Dictionary<string, XmlElement> urls = new();

        #region


        Func<XmlElement, object> Get(XmlElement xmlElement)
        {
            if (functions.ContainsKey(xmlElement.Name))
            {
                return functions[xmlElement.Name];
            }
            return null;

        }

        Func<XmlElement, object, object>  GetCombine(XmlElement xmlElement, object obj)
        {
            var type = obj.GetType();
            foreach (var t in combined)
            {
                if (t.Key.IsBase(type))
                {
                    return t.Value;
                }
            }
            return null;
        }

        #region IFunction Members

            Func<XmlElement, object> IFunction.this[XmlElement xmlElement] => Get(xmlElement);

            void IFunction.Clear()
            {
            Clear();
            }

            object IFunction.Clone(object obj)
            {
            return obj;
            }

            Func<XmlElement, object, object> IFunction.Combine(XmlElement xmlElement, object obj)
            {
                return GetCombine(xmlElement, obj);
            }

        #region

        private void Clear()
        {
            materials.Clear();
            elementList.Clear();
        }

        #region ICollada Members

   /*     /// <summary>
        /// Creation functions
        /// </summary>
        Dictionary<string, Func<XmlElement, object>> ICollada.Functions => functions;

        /// <summary>
        /// Combination function
        /// </summary>
        Dictionary<Type, Func<XmlElement, object, object>> ICollada.Combined => combined;
   */

        /// <summary>
        /// Clears itself
        /// </summary>
        void ICollada.Clear()
        {
            materials.Clear();
            elementList.Clear();
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
                var url = xmlElement.GetAttribute("url");
                if( url.Length > 0)
                {
                    if (urls.ContainsKey(url))
                    {
                        throw new Exception();
                    }
                    urls[url] = xmlElement;
                    return url;
                }
                return null;
            }
            var name = xmlElement.GetAttribute("name");
            return id + "@" + name;
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
            if (n == "newparam")
            {
                parametersNew[xmlElement.GetAttribute("sid")] = xmlElement;
            }
            if (n == "source")
            {
      /*          var t = xmlElement.InnerText;
                if (sources.ContainsKey(t))
                {
                    throw new Exception();
                }
                sources[t] = xmlElement;*/
            }
            return unknown.Contains(xmlElement.Name);
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="xmlElement"></param>
        void ICollada.Init(XmlElement xmlElement)
        {
            var s = xmlElement.GetElements();
            foreach (XmlElement e in s)
            {
                if (finalTypes.Contains(e.Name))
                {
                    e.Get();
                }
            }
            s =  xmlElement.GetElements(IsSource);
            foreach (XmlElement e in s) 
            {
      //          sources[e.InnerText] = e;
                var param = e.ParentNode.ParentNode as XmlElement;
                sourceParam[e] = param;
                paramSource[param] = e;
            }
        }

        string[] finalTypes = ["image","p", "color"];

        Dictionary<XmlElement, XmlElement> sourceParam = new Dictionary<XmlElement, XmlElement>();
        Dictionary<XmlElement, XmlElement> paramSource = new Dictionary<XmlElement, XmlElement>();


        bool first = false;
        List<string> unknown = new()
        {
            "author", "authoring_tool", "comments", "copyright", "contributor",
            "created", "modified", "asset", "library_materials"
        };


        Dictionary<string, XmlElement> sources = new();

  
        bool IsSource(XmlElement xmlElement)
        {
            return xmlElement.Name == "source";
        }




        #endregion

        public void Load(string fileName)
        {
            StaticExtensionCollada.Load(fileName);
        }

        #endregion

    }
    #endregion

    #endregion
}
