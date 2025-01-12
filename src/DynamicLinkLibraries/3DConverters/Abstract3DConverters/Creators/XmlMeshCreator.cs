using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Abstract3DConverters.Creators
{
    public abstract class XmlMeshCreator : AbstractMeshCreator
    {
        protected XmlDocument doc;

        protected XmlMeshCreator(XmlDocument doc)
        {
            this.doc = doc;
        }

        public override void Load(Stream stream)
        {
         /*   using (var reader = new StreamReader(stream))
            {
                var s = reader.ReadToEnd();
                doc = new XmlDocument();
                doc.LoadXml(s);
            }*/
        }

    }
}
