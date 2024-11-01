using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Wpf
{
    public class Parameter
    {
        private  static Dictionary<string, Parameter> parameters = new ();

        public string Name { get; private set; }

        XmlElement xmlElement;

        public XmlElement Element { get => xmlElement; }

        public object Value { get; private set; }

        public Parameter(XmlElement xmlElement)
        {
            this.xmlElement = xmlElement;
            Name = xmlElement.GetAttribute("sid");
            object o = Create();
            if (o != null)
            {
                throw new Exception();
            }
            if (parameters.ContainsKey(Name))
            {
                throw new Exception();
            }
            parameters[Name] = this;
                    
        }
        

        object Create()
        {
            return null;
        }

        public static void Clear()
        {
            parameters.Clear();
        }

    }
}
