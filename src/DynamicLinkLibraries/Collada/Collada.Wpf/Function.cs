﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf
{
    public class Unit
    {
        public string Text { get; set; }
    }


    public enum UpDirection
    {
        None,
        X, Y, Z
    };

    internal partial class Function : IFunction
    {
        internal static readonly Function Instance = new Function();

        protected Function()
        {
            combined = new()
        {
            { typeof(BlurEffect), GetBlur },
            {typeof(Array), GetArray },
            {typeof(Visual3D), GetVisual3D},
            {typeof(Scene), GetScene}
            };


            materialCalc = new()
                {
               { "phong", GetPhong},
                {"effect", GeEffectMaterial}
                };

            materialTypes = new Dictionary<string, Type>()
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
                               {"unit", SetUnit }, { "effect",  GetEffectMaterialObject }, 
                { "color", GetColorObject }, {"float", GetFloat}, {"reflectivity",
                StaticExtensionCollada.GetFirstChild}, {"reflective",
                StaticExtensionCollada.GetFirstChild}, {"newparam", GetParameter}
 
                // */
  };
            visualDic = new()
       {
 {"mesh", GetMesh}
       };

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

        public Dictionary<string, List<XmlElement>> KeyValuePairs
        {
            get => elementList;
        }


        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="xmlElement"></param>
        void IFunction.Init(XmlElement xmlElement)
        {
            var s = xmlElement.GetElements();
            foreach (var e in s)
            {
                var id = e.GetAttribute("id");
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
        }


            #region

            #endregion

            Func<XmlElement, object, object> GetCombine(XmlElement xmlElement, object obj)
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

        void Put(XmlElement xmlElement)
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



        Func<XmlElement, object> Get(XmlElement xmlElement)
        {
            if (functions.ContainsKey(xmlElement.Name))
            {
                Put(xmlElement);
                return functions[xmlElement.Name];
            }
            return null;
        }

        protected virtual void Clear()
        {
            Parameter.Clear();
        }



    }
    #endregion

}
