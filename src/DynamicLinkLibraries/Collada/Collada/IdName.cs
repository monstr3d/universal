using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Collada
{
    public class IdName : IEnumerable<IdName>
    {
        #region Fields

        static private Dictionary<XmlElement, IdName> dictionary = new();

        static private Dictionary<string, IdName> keyValuePairs = new();

        static private Dictionary<string, XmlElement> elements = new();

        static private Dictionary<string, IdName> sources = new();

       
      
        string id;

        bool isCombined = false;

 
  
        List<IdName> ids = new();

        XmlElement xmlElement;

        IdName parent = null;

        private object obj;

        string name;

        #endregion



        #region Ctor


        private IdName(XmlElement xmlElement)
        {
            this.xmlElement = xmlElement;
             var nn = xmlElement.Name;
            if (nn.Contains("mater"))
            {

            }
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
            sources[id] = this;
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
            XmlNode p = xmlElement.ParentNode;
            if (p == xmlElement)
            {
                p = p.ParentNode;
            }
            while (true)
            {
                if (p == null) break;
                if (p is XmlElement el)
                {
                    if (dictionary.ContainsKey(el))
                    {
                        var pp = dictionary[el];
                        if (pp != this)
                        {
                            Parent = pp;
                            break;
                        }
                    }
                }
                p = p.ParentNode;
            }
        }


        #endregion


        #region Properties
        public bool IsCombined
        {
            get => isCombined;
            set
            {
                isCombined = value;
                if (value)
                {
                    xmlElement.SetAttribute("IsCombined", "True");
                }
            }
        }


        public object Object
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



        public IdName Source
        {
            get;
            private set;
        }

        public IdName Parent
        {
            get => parent;
            private set
            {
                if (value == null)
                {
                    return;
                }
                if (parent != null) return;
                parent = value;
                if (!parent.ids.Contains(this))
                {
                    parent.ids.Add(this);
                }
            }
        }

        public string Tag => xmlElement.Name;

        public string Id => id;


        #endregion


        public void SetSource()
        {
            var src = xmlElement.GetAttribute("source");
            if (src.Length > 0)
            {
                src = src.Substring(1);
                Source = sources[src];
                var ob = Source.Object;
                ob = ob.Clone();
                obj = ob;
            }
            foreach (var i in this)
            {
                i.SetSource();
            }
        }
        public void Reset(object o)
        {
            if (o != null)
            {
                obj = o;
            }
        }

 
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

   
    }
}
