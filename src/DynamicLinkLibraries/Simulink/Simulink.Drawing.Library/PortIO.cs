using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Simulink.Drawing.Library
{
    class PortIO
    {
        string port;
        bool input;

        XElement element;

        internal PortIO(XElement element, string port, bool input, 
            Dictionary<XElement, Dictionary<bool, Dictionary<string, PortIO>>> dictionary)
        {
            this.port = port;
            this.input = input;
            this.element = element;
            Dictionary<bool, Dictionary<string, PortIO>> d = null;
            if (dictionary.ContainsKey(element))
            {
                d = dictionary[element];
            }
            else
            {
                d = new Dictionary<bool, Dictionary<string, PortIO>>();
                dictionary[element] = d;
            }
            Dictionary<string, PortIO> dd = null;
            if (d.ContainsKey(input))
            {
                dd = d[input];
            }
            else
            {
                dd = new Dictionary<string, PortIO>();
                d[input] = dd;
            }
            dd[port] = this;
        }

        internal XElement Element
        {
            get
            {
                return element;
            }
        }

        internal string Port
        {
            get
            {
                return port;
            }
        }
    }
}
