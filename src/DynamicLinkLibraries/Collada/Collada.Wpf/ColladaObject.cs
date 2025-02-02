﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Xml;
using System.Xml.Linq;
using Collada.Wpf.Classes;


namespace Collada.Wpf
{


    public partial class ColladaObject : ICollada
    {

        #region Fields

        string filename;

        void Set(string filename)
        {
            this.filename = filename;
        }

        public UpDirection Direction
        {
            get;
            private set;
        } = UpDirection.None;
        string ICollada.Filename { get => filename; set => Set(value); }

        public static ColladaObject Instance = new ColladaObject();

        #endregion

        private ColladaObject()
        {
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
        
        }
        /// <summary>
        /// Gets object from string
        /// </summary>
        /// <param name="s">The string</param>
        /// <returns>The object</returns>
        object ICollada.Get(string s)
        {
            return Function.FromCollada(s); ;
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
                if (url.Length > 0)
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
     /*       var id = xmlElement.GetAttribute("id");
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
            l.Add(xmlElement);*/
        }




        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="xmlElement"></param>
        void ICollada.Init(XmlElement xmlElement)
        {
            var l = new List<string>();

            var x = xmlElement.GetElements().Where(e => !e.IsUnknown());
            foreach (var e in x)
            {
                if (!l.Contains(e.Name))
                {
                    var s = e.OuterXml;

                    if (s.Contains("source"))
                    {
                        l.Add(e.Name);
                    }
                }
            }
            l.Sort();
            using (var writer = new StreamWriter("source.txt"))
            {
                foreach (var e in l)
                {
                    writer.WriteLine(e);
                }
            }
            l = null;  
           //  Testtechnique(xmlElement);
            //    Testtecfiltes(xmlElement);

            var t = Function.Tags;
            t.GetAll();
            t = Function.Nonelementary;
            t.Get();
            return;
            t = Function.AddTags;
            t.Get();
            int i = 0;
    
            /*          var s = xmlElement.GetElements();
                      foreach (XmlElement e in s)
                      {
                          if (finalTypes.Contains(e.Name))
                          {
                              e.Get();
                          }
                      }
                      s = xmlElement.GetElements(IsSource);
                      foreach (XmlElement e in s)
                      {
                          //          sources[e.InnerText] = e;
                          var param = e.ParentNode.ParentNode as XmlElement;
                          sourceParam[e] = param;
                          paramSource[param] = e;
                      }*/
            // newparam.Get();
        }


        #endregion


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
                    if (child is ModelVisual3D model3)
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


        #region

        void Testtecfiltes(XmlElement xmlElement)
        {
            Func<XmlElement, bool> func = (e) => { return (e.Name == "minfilter" | e.Name == "magfilter"); };
            var enu = xmlElement.GetElements(func);
            foreach (var e in enu)
            {
                if (e.ParentNode.Name != "sampler2D")
                {
                    throw new Exception();
                }
            }
        }


        void Testtechnique(XmlElement xmlElement)
        {
            Func<XmlElement, bool> func = (e) => { return e.Name == "technique"; };
            var enu = xmlElement.GetElements(func);
            foreach (var e in enu)
            {
                if (e.ChildNodes.Count != 1)
                {
                    throw new Exception();
                }
                if (e.GetAttribute("sid") != "common")
                {
                    throw new Exception();
                }
                if (e.FirstChild.Name != "phong")
                {
                    throw new Exception();
                }
            }

        }
     //    !!!!!!
 
    
  
        Dictionary<XmlElement, XmlElement> sourceParam = new Dictionary<XmlElement, XmlElement>();
        Dictionary<XmlElement, XmlElement> paramSource = new Dictionary<XmlElement, XmlElement>();

        Dictionary<string, XmlElement> parametersNew;



        bool IsSource(XmlElement xmlElement)
        {
            return xmlElement.Name == "source";
        }





        #endregion




  
        Dictionary<string, XmlElement> urls = new();

        #region



        #endregion
    }
}
