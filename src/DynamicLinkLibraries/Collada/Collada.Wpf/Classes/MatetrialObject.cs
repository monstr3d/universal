using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class MaterialObject : XmlHolder
    {
        static public readonly string Tag = "material";

        Material m;

        private MaterialObject(XmlElement element) : base(element)
        {
            if (element.ChildNodes.Count != 1)
            {
                throw new Exception();
            }
            m = element.FirstElement().Get() as Material;
            if (m == null)
            {
                throw new Exception();
            }  
        }

        object Get()
        {
            return m;
        }

        public static object Get(XmlElement element)
        {
            var a = new MaterialObject(element);
            return a.Get();
        }
    }
}