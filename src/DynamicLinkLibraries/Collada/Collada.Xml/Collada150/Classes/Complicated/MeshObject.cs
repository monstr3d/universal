using System;
using System.Collections.Generic;
using System.Xml;
using System.Windows;
using System.Xml.Linq;
using System.Linq.Expressions;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using Collada;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters;

namespace Collada150.Classes.Complicated
{
    [Tag("mesh")]
    internal class MeshObject : Collada.XmlHolder
    {

        public Triangles Triangles 
        { 
            get; 
            private set; 
        }

        public PolyList Polygon 
        { 
            get; 
            private set; 
        }

        public static IClear Clear => StaticExtensionCollada.GetClear<MeshObject>();

        private MeshObject(XmlElement xmlElement) : base(xmlElement)
        {
            Triangles = xmlElement.Get<Triangles>();
            Polygon = xmlElement.Get<PolyList>();
            if (Triangles != null | Polygon != null)
            {
                return;
            }
            var vert = xmlElement.Get<Vertices>();
          
        }

        static public object Get(XmlElement xmlElement, IMeshCreator meshCreator)
        {
            return new MeshObject(xmlElement);
        }

    }
}