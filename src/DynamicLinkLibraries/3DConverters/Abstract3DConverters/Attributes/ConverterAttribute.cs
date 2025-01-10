using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters.Attributes
{
    public class ConverterAttribute : Attribute
    {
        public string Extention { get; private set; }

        public string Comment { get; private set; }

        public ConverterAttribute(string extention, string comment = null)
        {
            Extention = extention;
            Comment = comment;
        }
    }
}
