using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Wpf
{
    internal class Instance_Material : XmlHolder
    {
        public static readonly string Tag = "instance_material";

        private Instance_Material(XmlElement element) : base(element) 
        { 
        
        }

        static internal object Get(XmlElement element)
        {
            return new Instance_Material(element);
        }

    }
}
