using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("technique_common")]
    internal class Technique : XmlHolder
    {
    
        object[] children;

        private Technique(XmlElement element) : base(element)
        {
            try
            {
                children = element.GetOwnChildren().ToArray();
            }
            catch (Exception e)
            {

            }
        }

        static public object Get(XmlElement element)
        {
            return new Technique(element);
        }
    }
    // "technique_common
}
