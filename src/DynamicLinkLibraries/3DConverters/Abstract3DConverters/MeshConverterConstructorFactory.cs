using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters
{
    public class MeshConverterConstructorFactory : IMeshConverterFactory
    {

        Dictionary<string, Dictionary<string, ConstructorInfo>> dictionary = null;


        public MeshConverterConstructorFactory(Dictionary<string, Dictionary<string, ConstructorInfo>> dictionary)
        {
            this.dictionary = dictionary;
        }

        IMeshConverter IMeshConverterFactory.this[string extension, string comment] => Get(extension, comment);

        IMeshConverter Get(string extension, string comment)
        {
            ConstructorInfo ci = null;
            if (dictionary.ContainsKey(extension))
            {
                var d = dictionary[extension];
                var k = d.Keys;
                if (k.Count == 0)
                {
                    ci = d.Values.ToArray()[0];
                }
                else
                {
                    ci = d[comment];
                }
            }
            if (ci != null)
            {
                return ci.Invoke(new object[0]) as IMeshConverter;
            }
            return null;
        }
    }
}
