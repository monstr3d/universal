using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters.Attributes
{
    public class ExtensionAttribute : Attribute
    {

        public string[] Extensions { get; private set; }

        public ExtensionAttribute(string[] ext)
        {
            Extensions = ext;
        }

    }
}
