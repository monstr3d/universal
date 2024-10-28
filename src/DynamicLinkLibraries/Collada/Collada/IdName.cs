using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml;

namespace Collada
{
    public class IdName : IEnumerable<IdName>
    {
        #region Fields

        static private Dictionary<XmlElement, IdName> dictionary = new();

        static private Dictionary<string, IdName> keyValuePairs = new();

        static private Dictionary<string, XmlElement> elements = new();


        static public Dictionary<XmlElement, IdName> Dictionary
        {
            get => dictionary;
        }


        static private Dictionary<IdName, XmlElement> inverse = new();

        public static List<IdName> All
        {
            get
            {
                var list = new List<IdName>();
                foreach (var x in inverse.Keys)
                {
                    if (list.Contains(x))
                    {
                        throw new Exception();
                    }
                    list.Add(x);
                }
                return list;
            }
        }

 
        string id;

        string name;

        List<IdName> ids = new();

        XmlElement xmlElement;

        IdName parent = null;

        public IdName Parent
        {
            get => parent;
            private set
            {
                if (parent != null) return;
                parent = value;
                parent.ids.Add(this);
            }
        }

        public string Tag => xmlElement.Name;

        private object obj;

        public Object Object
        {
            get => obj;
            set
            {
                if (obj != null)
                {
                    throw new Exception();
                }
                obj = value;
            }
        }

        #endregion

        #region Ctor

        private IdName(XmlElement xmlElement)
        {
            this.xmlElement = xmlElement;
            string att = xmlElement.GetAttribute("id");
            if (att.Length > 0)
            {
                id = att;
                name = xmlElement.GetAttribute("name");
            }
            else
            {

                id = Guid.NewGuid() + "";
                name = xmlElement.GetAttribute("name");
                xmlElement.SetAttribute("id", id);
            }
            if (keyValuePairs.ContainsKey(id))
            {
                throw new Exception();
            }
            keyValuePairs[id] = this;
            elements[id] = xmlElement;
            this.xmlElement = xmlElement;
            dictionary[xmlElement] = this;
            if (inverse.ContainsKey(this))
            {
                throw new Exception();
            }
            inverse[this] = xmlElement;
            var nl = xmlElement.ChildNodes;
            foreach (XmlNode n in nl)
            {
                Process(n);
            }
            var p = xmlElement.ParentNode;
            while (true)
            {
                if (p == null) break;
                if (p is XmlElement e)
                {
                    if (dictionary.ContainsKey(e))
                    {
                        Parent = dictionary[e];
                        break;
                    }
                }
                p = p.ParentNode;
            }
        }

        internal string Id => id;

        private void Process(XmlNode node)
        {
            if (node is XmlElement e)
            {
                new IdName(e);
                return;
            }
            XmlNodeList nl = node.ChildNodes;
            foreach (XmlNode item in nl)
            {
                Process(item);
            }
        }

        #endregion
        public static IdName GetIdName(string name)
        {
            return keyValuePairs[name];
        }


        

        public static IdName ToIdName(XmlElement xmlElement)
        {
            if (dictionary.ContainsKey(xmlElement))
            {
                return dictionary[xmlElement];
            }
           return new IdName(xmlElement);
        }

        public XmlElement Xml => xmlElement;

        public static XmlElement Get(string id)
        {
            return elements[id];
        }
  

        #region Overriden


        public override bool Equals(object obj)
        {
            return obj == this;
        }

        IEnumerator<IdName> IEnumerable<IdName>.GetEnumerator()
        {
            return ids.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ids.GetEnumerator();
        }

        #endregion

        #region Own Members
        /*
                internal IdName Double()
                {
                    if (name.Length != 0)
                    {
                        return null;
                    }
                    return new IdName(id, id);
                }
        */


        #endregion
    }
}
