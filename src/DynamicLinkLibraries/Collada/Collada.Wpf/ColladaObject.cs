using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Xml;
using System.Xml.Linq;


namespace Collada.Wpf
{


    public partial class ColladaObject : ICollada
    {

        #region Fields
   
        public UpDirection Direction
        {
            get;
            private set;
        } = UpDirection.None;

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


        Dictionary<string, List<XmlElement>> elementList;


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
        /// The unknown element
        /// </summary>
        /// <param name="xmlElement">The element</param>
        /// <returns>Thue if it is unknown</returns>
        bool ICollada.IsUnknown(XmlElement xmlElement)
        {
            var n = xmlElement.Name;
        /*    if (n == "newparam")
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
        //    }*/
            return StaticExtensionColladaWpf.Unknown.Contains(xmlElement.Name);
        }


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

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="xmlElement"></param>
        void ICollada.Init(XmlElement xmlElement)
        {
            //  Testtechnique(xmlElement);
        //    Testtecfiltes(xmlElement);


            finalTypes.Get();
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
            foreach (var s in strings)
            {
                var t = new string[] { s };
                t.Get();
            }
        }
 
        string[] strings  = ["transparent", "newparam", "diffuse", "specular", "reflective" , "effect" ];
        string[] finalTypes = ["image", "p", "color", "float_array", "reflectivity", "reflective"];

  
        Dictionary<XmlElement, XmlElement> sourceParam = new Dictionary<XmlElement, XmlElement>();
        Dictionary<XmlElement, XmlElement> paramSource = new Dictionary<XmlElement, XmlElement>();

        Dictionary<string, XmlElement> parametersNew;



        bool IsSource(XmlElement xmlElement)
        {
            return xmlElement.Name == "source";
        }





        #endregion

        public Unit MeterUnit
        { get; private set; } = null;



  
        Dictionary<string, XmlElement> urls = new();

        #region



        #endregion
    }
}
