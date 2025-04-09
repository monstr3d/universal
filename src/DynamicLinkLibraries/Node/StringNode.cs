using ErrorHandler;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GeneralNode
{

    /// <summary>
    /// String Node
    /// </summary>
    public class StringNode : ArbitraryNode, IComparable<StringNode>
    {
        string p;
        string sep;
        string th;
        string name;
        private StringNode(string s, string sep, List<StringNode> list) : base(null)
        {
           th = s + "";
           this.sep = sep;
           int n = s.LastIndexOf(sep);
           if (n < 0)
           {
               p = "";
           }
           else
           {
               p = th.Substring(0, n);
           }
           if (list.Contains(this))
           {
               throw new OwnException();
           }
           if (n < 0)
           {
               name = s;
           }
           else
           {
               name = s.Substring(n + sep.Length);
           }
           list.Add(this);
        }

        /// <summary>
        /// Node Id
        /// </summary>
        public override object Id
        {
            get
            {
                return th;
            }
        }

        /// <summary>
        /// Parent Id
        /// </summary>
        public override object ParentId
        {
            get
            {
                return p;
            }
        }

        #region IComparable<StringNode> Members

        int IComparable<StringNode>.CompareTo(StringNode other)
        {
            return th.Length - other.th.Length;
        }

        #endregion

        /// <summary>
        /// Gets hash code
        /// </summary>
        /// <returns>The hash code</returns>
        public override int GetHashCode()
        {
            return th.GetHashCode();
        }

 
        /// <summary>
        /// Overriden equals
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns>True if equals and false otherwise</returns>
        public override bool Equals(object obj)
        {
            StringNode n = obj as StringNode;
            return th.Equals(n.th);
        }

        #region Specific members

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Gets root node
        /// </summary>
        /// <param name="list">List of nodes</param>
        /// <param name="sep">Separator</param>
        /// <returns>Root node</returns>
        static public StringNode GetRoot(List<string> list, string sep)
        {
            List<StringNode> l = new List<StringNode>();
            Dictionary<string, StringNode> table = new Dictionary<string,StringNode>();

            foreach (string str in list)
            {
                StringNode sn = new StringNode(str, sep, l);
                table[str] = sn;
            }
            l.Sort();
            List<StringNode> li = new List<StringNode>(l);
            foreach (StringNode node in li)
            {
                node.split(l, table);
            }

            StringNode root = new StringNode("", sep, l);
            table[""] = root;
            root.p = null;
            foreach (StringNode node in table.Values)
            {
                if (node.p != null)
                {
                    node.Parent = table[node.p];
                }
            }
            return root;
        }

        /// <summary>
        /// Path
        /// </summary>
        public string Path
        {
            get
            {
                return th;
            }
        }




        private void split(List<StringNode> list, Dictionary<string, StringNode> table)
        {
            int n = th.LastIndexOf(sep);
            if (n < 0)
            {
                return;
            }
            string str = th.Substring(0, n);
            try
            {
                StringNode sn = new StringNode(str, sep, list);
                table[str] = sn;
                sn.split(list, table);
            }
            catch (Exception)
            {
                
            }

        }
        #endregion
    }
}
