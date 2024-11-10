using System;
using System.Collections.Generic;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Xml;
using System.Reflection;
using Collada.Wpf.Classes;
using System.IO;
using System.Net.WebSockets;
using System.Windows.Controls;

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

        static public List<string> Tags => elementary;

        static public List<string> AddTags => allTags;

        string filename;

        static public List<string> Nonelementary {  get; private set; }
        string IFunction.Filename { get => filename; set => Set(value); }

        static List<string> tags = new();



        static Dictionary<string, MethodInfo> methods;

        static List<string> allTags;


        static List<string> elementary;

        static public string Directory {  get; internal set; }


        static Function()
        {
            StaticExtensionCollada.Id = "id";
            elementary = new();
            methods = new Dictionary<string, MethodInfo>();
            allTags = new List<string>();
            Assembly assembly = typeof(Function).Assembly;
            try
            {
                assembly.Detect(methods, elementary, allTags);
            }
            catch (Exception ex)
            {

            }


            //  assembly.CreateElementary(methods, elementary, allTags);

            try
            {

                // !!!!!!
                //   string[] finalTypes = ["param", "image", "p", "color", "float_array", "reflectivity", "reflective", "accessor"];
                if (false)
                {

                    /*             Type[] types = [typeof(Source), typeof(MinFilter), typeof(MagFilter), typeof(FloatObject), typeof(Up_Axis),
                                 typeof(UnitDimension),  typeof(VCount), typeof(P), typeof(Param), typeof(Image),  typeof(ColorObject), typeof(Float_Array),
                         typeof(Reflectivity), typeof(Accessor)];
                                 // types = [typeof(BindVertexInput), typeof(MinFilter), typeof(MagFilter), typeof(FloatObject), typeof(Up_Axis), 
                                 //       typeof(UnitDimension),  typeof(VCount), typeof(P), typeof(Param), typeof(Image),  typeof(ColorObject), typeof(Float_Array),
                                 //typeof(Reflectivity), typeof(Accessor)];

                                 //  typeof(Reflective), typeof(Diffuse), typeof(Specular)];


                                 methods = new();

                                 foreach (var type in types)
                                 {
                                     FieldInfo fi = type.GetField("Tag");
                                     var s = fi.GetValue(null) as string;
                                     tags.Add(s);
                                     if (allTags.Contains(s))
                                     {
                                         throw new Exception();
                                     }
                                     allTags.Add(s);
                                     MethodInfo mi = type.GetMethod("Get", new Type[] { typeof(XmlElement) });
                                     if (mi == null)
                                     {
                                         throw new Exception();
                                     }
                                     methods[s] = mi;
                                 }*/
                }
                Type[] types = [typeof(Source), typeof(Vertices), typeof(Input), typeof(Surface), typeof(Sampler2D), typeof(Accessor), typeof(NewParam),  typeof(Texture), typeof(Diffuse),
                typeof(Reflective), typeof(Specular), typeof(Phong),
                typeof(EffectObject),  typeof(MaterialObject), typeof(Instance_Material),  typeof(BindMaterial),  typeof(Technique), typeof(PolyList), typeof(MeshObject), typeof(GeometryObject),
                  typeof(Node), typeof(Scene)
                ];
            

                var nonelementary = new List<string>();
                foreach (var type in types)
                {
                    if (type.IsUknown())
                    {
                        throw new Exception();
                    }
                    TagAttribute tag = type.GetTag();
                    var name = tag.Tag;
                    if (tag.IsElemenary)
                    {
                        throw new Exception();
                    }
                    nonelementary.Add(name);
                }
                Nonelementary = nonelementary;
                return;

                /*  string[] strings = ["transparent", "surface", "sampler2D",  "texture", "diffuse", "specular", "reflective" , "effect",
              Technique.Tag, Instance_Material.Tag, BindVertexInput.Tag, Source.Tag, Input.Tag ];*/
            }
            catch (Exception ex)
            {

            }

        }

        void Set(string filename)
        {
            this.filename = filename;
            var fn = Path.GetFileNameWithoutExtension(filename);
            var dir = Path.GetDirectoryName(filename);
            fn =  Path.Combine( Path.GetDirectoryName(filename), fn + ".mtl");
            if (File.Exists(fn))
            {
                CreateMtl(fn);
            }
        }


        static void CreateMtl(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                do
                {
                    var line = reader.ReadLine();
                    if (line.Contains("newmtl"))
                    {
                        var ss = line.Split(" ".ToCharArray());
                        var name = ss[ss.Length - 1];
                        new MtlWrapper(name, reader);
                    }
                }
                while (!reader.EndOfStream);
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

            materialTypes = new Dictionary<string, Type>()
        {
                 {"diffuse", typeof(DiffuseMaterial)},
            {"specular", typeof(SpecularMaterial)},
{"reflective", typeof(EmissiveMaterial)}
        };




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

/*

            visualDic = new()
       {
 {"mesh", GetMesh}
       };
*/
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
            return null; // GetCombine(xmlElement, obj);
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

    
        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="xmlElement"></param>
        void IFunction.Init(XmlElement xmlElement)
        {
            List<string> tags = new List<string>();
            var s = xmlElement.GetElements();
            foreach (var e in s)
            {
                if (!e.IsUnknown())
                {
                    continue;
                }
                var n = e.Name;

                if (!allTags.Contains(n))
                {
                    if (!tags.Contains(n))
                    {
                        tags.Add(n);
                    }
                }
            }
   /*             var id = e.GetAttribute("id");
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
            if (t.Count != 0)
            {
                using (var writer = new StreamWriter("abscent.txt"))
                {
                    foreach (var str in t)
                    {
                        writer.WriteLine(str);
                    }
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
    
        }

        protected virtual void Clear()
        {
            Sid.Clear();
            Phong.Clear();
            sourceDic.Clear();
      //      EffectObject.Clear();
            NewParam.Clear();
            Surface.Clear();
            Sampler2D.ClearT();
      //      Source.Clear();
        //    MaterialObject.Clear();
            Node.Clear();
            GeometryObject.ClearItSelf();
        }



    }
    #endregion

}

