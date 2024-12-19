using Abstract3DConverters.Interfaces;
using Collada.Converter.Creators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Converter
{
    [Abstract3DConverters.Attributes.Extension([".dae"])]
    public class ColladaMeshCreatorFactory : IMeshCreatorFactory
    {
        public IMeshCreator this[string filename] => Get(filename);

        IMeshCreator Get(string filename)
        {
            var doc = new XmlDocument();
            doc.Load(filename);
            return new Collada14MeshCreator();
        }
    }
}
