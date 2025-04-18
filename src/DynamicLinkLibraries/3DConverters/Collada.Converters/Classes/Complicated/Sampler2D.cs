﻿
using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;
using Collada.Converters.MeshCreators;
namespace Collada.Converters.Classes.Complicated
{

    [Tag("sampler2D")]
    public class Sampler2D :  Collada.XmlHolder
    {
 
   

        public static IClear Clear => StaticExtensionCollada.GetClear<Sampler2D>();


        internal string SourceName { get; private set; }
    
   

        public Surface Surface { get;  set; }


        public Sampler2D(XmlElement element, IMeshCreator meshCreator) : base(element)
        {
            SourceName = element.Get<Source>().Text;
            ColladaMeshCreator creator = meshCreator as ColladaMeshCreator;
            if (!creator.Samplers.ContainsKey(SourceName))
            {
                creator.Samplers[SourceName] = this;
            }
            else
            {
            //    throw new Except ion();
            }
        }

  

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
  
            return new Sampler2D(element, meshCreator);

        }

    }
}