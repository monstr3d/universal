using System;
using System.Collections.Generic;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Xml;
using System.Reflection;
using Collada.Wpf.Classes;

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

        static public List<string> Tags => tags;

        static public List<string> AddTags => addTags;


        static List<string> tags = new();

        static List<string> addTags = new();

        static Dictionary<string, MethodInfo> methods;

        static Function()
        {
            try
            {
                // !!!!!!
                //   string[] finalTypes = ["param", "image", "p", "color", "float_array", "reflectivity", "reflective", "accessor"];


                Type[] types = [typeof(BindVertexInput), typeof(Source), typeof(MinFilter), typeof(MagFilter), typeof(FloatObject), typeof(Up_Axis), typeof(UnitDimension),  typeof(VCount), typeof(P), typeof(Param), typeof(Image),  typeof(ColorObject), typeof(Float_Array),
            typeof(Reflectivity), typeof(Accessor)];

                //  typeof(Reflective), typeof(Diffuse), typeof(Specular)];

                methods = new();

                foreach (var type in types)
                {
                    FieldInfo fi = type.GetField("Tag");
                    var s = fi.GetValue(null) as string;
                    tags.Add(s);
                    MethodInfo mi = type.GetMethod("Get", new Type[] { typeof(XmlElement) });
                    if (mi == null)
                    {
                        throw new Exception();
                    }
                    methods[s] = mi;
                }

                types = [typeof(Transparent), typeof(Surface), typeof(Sampler2D), typeof(NewParam), typeof(Texture), typeof(Diffuse),
                typeof(Reflective), typeof(Specular), typeof(Phong),
                typeof(EffectObject), typeof(InstanceEffect), typeof(MaterialObject), typeof(Instance_Material), typeof(Technique)];
                foreach (var type in types)
                {
                    string s = null;
                    FieldInfo fi = type.GetField("Tag");
                    if (fi == null)
                    {
                        throw new Exception();
                    }
                    try
                    {
                        s = fi.GetValue(null) as string;
                    }
                    catch (Exception ex)
                    {

                    }
                    addTags.Add(s);
                    MethodInfo mi = type.GetMethod("Get", new Type[] { typeof(XmlElement) });
                    if (mi == null)
                    {
                        throw new Exception();
                    }
                    methods[s] = mi;
                }


              /*  string[] strings = ["transparent", "surface", "sampler2D",  "texture", "diffuse", "specular", "reflective" , "effect",
            Technique.Tag, Instance_Material.Tag, BindVertexInput.Tag, Source.Tag, Input.Tag ];*/
            }
            catch (Exception ex)
            {

            }

        }




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

 
          
            try
            {
 /*               functions = new()           {
{"float_array",  StaticExtensionCollada.GetArray<float>},
{"geometry", GetGeometry },
{"phong", GetPhongObject },

{"material", GetMaterial},
{"image", GetImage},

{Vertices.Tag, Vertices.Get},
{"p",GetP},
         { "library_visual_scenes", GetScenes },
                {"instance_effect", GetInstanceEffect },
                               {"up_axis", SetUpAxis },
                               {"unit", SetUnit }, { "effect",  GetEffectMaterialObject },
                { "color", GetColorObject }, {"float", GetFloat}, {"reflectivity",
                StaticExtensionCollada.GetFirstChild}, 
         {"diffuse" ,  GetMaterialColor },
  {"specular" ,  GetMaterialColor },
{ "reflective" ,  GetMaterialColor }, 
                    //{ "transparent" , GetTransparent} , 
               //     { "surface", GetSurface }, 
                    {"sampler2D", GetSample2D },{ "texture", GetTexture },
  //{"param", GetParam }, 
                    
                   // {"accessor", Accessor.GetAccessor}, 
                    {Technique.Tag, Technique.Get}, {Instance_Material.Tag, Instance_Material.Get},
                    {BindVertexInput.Tag, BindVertexInput.Get }, {Input.Tag, Input.Get }, {Source.Tag, Source.Get }
  }; */
           
    
            }
            catch(Exception ex)
            {
                throw ex;
            }
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

        private static Dictionary<string, Type> matTypes = new()
            {
            {"diffuse", typeof(DiffuseMaterial) },
                        {"specular", typeof(SpecularMaterial) },

                        {"reflective", typeof(EmissiveMaterial) } };

        internal static bool IsMaterial(string s)
        {
            return matTypes.ContainsKey(s);
        }
        internal static Material MaterialFromName(string s)
        {
            if (matTypes.ContainsKey(s))
            {
                var t = matTypes[s];
                var ct = t.GetConstructor([]);
                return  ct.Invoke(null) as Material;
            }
            return null;
        }

        List<string> t = new();
    
        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="xmlElement"></param>
        void IFunction.Init(XmlElement xmlElement)
        {
            var s = xmlElement.GetElements();
            foreach (var e in s)
            {
                if (StaticExtensionColladaWpf.IsUnknown(e))
                {
                    continue;
                }
                var n = e.Name;
                if (!t.Contains(n))
                {
                    t.Add(n);
                }
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


        public Dictionary<string, List<XmlElement>> KeyValuePairs
        {
            get => elementList;
        }


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
            /* if (functions.ContainsKey(xmlElement.Name))
             {
                 Put(xmlElement);
                 return functions[xmlElement.Name];
             }*/
            var tag = xmlElement.Name;
            if (methods.ContainsKey(tag))
            {
                Put(xmlElement);
                var mi = methods[tag];
                return (e) => mi.Invoke(null, new object[] { e });
            }
            return null;
        }

        protected virtual void Clear()
        {
            Sid.Clear();
            Phong.Clear();
            sourceDic.Clear();
            EffectObject.Clear();
            NewParam.Clear();
            Surface.Clear();
            Sampler2D.Clear();
        }



    }
    #endregion

}

