using System;
using System.Collections;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace DataWarehouse
{
    public class DatabaseNode : TreeNode, IComparer
    {
        private int id;
        private string guid;
        private XmlElement e;
        private ArrayList children = new ArrayList();
        private string description;
        private string textOut;
        private ArrayList childNodes;
        public DatabaseNode(XmlElement e, string tagName, string idAttr, string nameAttr, string childTag)
        {
            if (nameAttr != null)
            {
                this.e = e;
                string s = e.Attributes[idAttr].Value;
                Text = e.Attributes[nameAttr].Value;
                textOut = Text;
                description = e.GetElementsByTagName("Description")[0].InnerText;
                try
                {
                    id = Int32.Parse(s);
                }
                catch (Exception)
                {
                    guid = s;
                }
            }
            XmlNodeList list = e.GetElementsByTagName(childTag);
            foreach (XmlElement node in list)
            {
                if (node.ParentNode == e)
                {
                    children.Add(node);
                }
            }
            XmlNodeList ch = e.GetElementsByTagName(tagName);
            childNodes = new ArrayList();
            foreach (XmlElement node in ch)
            {
                if (node.ParentNode != e)
                {
                    continue;
                }
                TreeNode child = new DatabaseNode(node, tagName, idAttr, nameAttr, childTag);
                childNodes.Add(child);
            }
            childNodes.Sort(this);
            foreach (TreeNode child in childNodes)
            {
                Nodes.Add(child);
            }
        }

        public DatabaseNode(DatabaseNode parent, string id, string name, string description)
        {
            guid = id;
            Text = name + "";
            this.description = description + "";
            for (int i = 0; i < parent.Nodes.Count; i++)
            {
                if (name.CompareTo(parent.Nodes[i].Text) < 0)
                {
                    parent.Nodes.Insert(i, (this));
                    return;
                }
            }
            parent.Nodes.Add(this);
        }
 
        public void AddChild(string id, string name, string description, string ext, string length)
        {
            XmlDocument doc = e.OwnerDocument;
            XmlElement ep = doc.CreateElement("Binary");
            XmlAttribute aid = doc.CreateAttribute("BinaryId");
            aid.Value = id;
            ep.Attributes.Append(aid);
            XmlAttribute aName = doc.CreateAttribute("BinaryName");
            aName.Value = name;
            ep.Attributes.Append(aName);
            XmlElement d = doc.CreateElement("Description");
            d.InnerText = description;
            ep.AppendChild(d);
            XmlAttribute aParent = doc.CreateAttribute("ParentId");
            aParent.Value = UID + "";
            ep.Attributes.Append(aParent);
            XmlAttribute aExt = doc.CreateAttribute("Ext");
            aExt.Value = ext;
            ep.Attributes.Append(aExt);
            e.AppendChild(ep);

        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string UID
        {
            get
            {
                return guid;
            }
        }

        public int Count
        {
            get
            {
                return children.Count;
            }
        }

        public XmlElement Element
        {
            get
            {
                return e;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value + "";
            }
        }

        public int ChildrenCount
        {
            get
            {
                return children.Count;
            }
        }

        public XmlElement GetChild(int i)
        {
            return children[i] as XmlElement;
        }

        public DatabaseNode this[int i]
        {
            get
            {
                if (i >= Count | i < 0)
                {
                    return null;
                }
                return childNodes[i] as DatabaseNode;
            }
        }

        public void RemoveChild(XmlElement e)
        {
            children.Remove(e);
        }

        public int Compare(object o1, object o2)
        {
            DatabaseNode n1 = o1 as DatabaseNode;
            DatabaseNode n2 = o2 as DatabaseNode;
            return n1.Text.CompareTo(n2.Text);
        }

        public string GetChildName(int i)
        {
            XmlElement el = children[i] as XmlElement;
            return el.Attributes["BinaryName"].Value;
        }

        public string GetChildUID(int i)
        {
            XmlElement el = children[i] as XmlElement;
            return el.Attributes["BinaryID"].Value;
        }

        public ArrayList List
        {
            get
            {
                ArrayList l = new ArrayList();
                getList(l, 0);
                return l;
            }
        }



        static public implicit operator XmlElement(DatabaseNode node)
        {
            return node.e;
        }

        private void getList(ArrayList list, int level)
        {
            list.Add(new object[] { this, level });
            for (int i = 0; i < Count; i++)
            {
                this[i].getList(list, level + 1);
            }
        }

        public void Remove(XmlElement e)
        {
            children.Remove(e);
        }

    }
}
