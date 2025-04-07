using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace GeneralNode
{

    /// <summary>
    /// Arbitrary node
    /// </summary>
    public abstract class ArbitraryNode : INode
    {
        #region Fields

        /// <summary>
        /// Associated object
        /// </summary>
        protected object obj;

        /// <summary>
        /// Children nodes
        /// </summary>
        protected List<INode> children = new List<INode>();


        /// <summary>
        /// Parent
        /// </summary>
        protected INode parent;


        /// <summary>
        /// Count of all nodes
        /// </summary>
        private static int commonCount;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="obj">Associated object</param>
        public ArbitraryNode(object obj)
        {
            this.obj = obj;
        }

        #endregion

        #region INode Members

        /// <summary>
        /// Node Id
        /// </summary>
        abstract public object Id
        {
            get;
        }

        /// <summary>
        /// Parent Id
        /// </summary>
        abstract public object ParentId
        {
            get;
        }

        /// <summary>
        /// Adds node
        /// </summary>
        /// <param name="node">Node to add</param>
        public virtual void Add(INode node)
        {
            if (children.Contains(node))
            {
                return;
            }
            if (node is IComparable<INode>)
            {
                IComparable<INode> c = node as IComparable<INode>;
                for (int i = 0; i < children.Count; i++)
                {
                    if (c.CompareTo(children[i]) < 0)
                    {
                        children.Insert(i, node);
                        node.Parent = this;
                        return;
                    }
                }
            }
            children.Add(node);
            node.Parent = this;
        }

        /// <summary>
        /// The contains function
        /// </summary>
        /// <param name="node">Checked node</param>
        /// <returns>True is node is contained in childred and false otherwise</returns>
        public bool Contains(INode node)
        {
            return children.Contains(node);
        }

        /// <summary>
        /// Associated object
        /// </summary>
        public virtual object Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        /// <summary>
        /// Parent node
        /// </summary>
        public virtual INode Parent
        {
            get
            {
                return parent;
            }
            set
            {
                if (parent == value)
                {
                    return;
                }
                if (parent != null)
                {
                    if (parent.Contains(this))
                    {
                        return;
                    }
                    else
                    {
                      //  throw new Exception("Parent already exists");
                    }
                }
                parent = value;
                parent.Add(this);
            }
        }

        /// <summary>
        /// Count of children
        /// </summary>
        public int Count
        {
            get
            {
                return children.Count;
            }
        }

        /// <summary>
        /// Access to n-th child
        /// </summary>
        /// <param name="n">Child number</param>
        /// <returns>The child</returns>
        public INode this[int n]
        {
            get
            {
                return children[n] as INode;
            }
        }

        /// <summary>
        /// Sorts children
        /// </summary>
        /// <param name="comparer">Comparer for sorting</param>
        public void Sort(IComparer<INode> comparer)
        {
            children.Sort(comparer);
        }

        /// <summary>
        /// Sorts all successors nodes
        /// </summary>
        /// <param name="comparer">Comparer for sorting</param>
        public void SortAll(IComparer<INode> comparer)
        {
            Sort(comparer);
            foreach (INode child in children)
            {
                child.SortAll(comparer);
            }
        }

        /// <summary>
        ///  All successors nodes
        /// </summary>
        public ICollection<INode> All
        {
            get
            {
                List<INode> list = new List<INode>();
                getAllChildren(list);
                return list;
            }
        }

        /// <summary>
        /// Children
        /// </summary>
        public virtual ICollection<INode> Children
        {
            get
            {
                return children;
            }
        }

        /// <summary>
        /// Gets order of the child
        /// </summary>
        /// <param name="node">The child</param>
        /// <returns>The order</returns>
        public int GetChildOrder(INode node)
        {
            if (!children.Contains(node))
            {
                return -1;
            }
            return children.IndexOf(node);
        }

        /// <summary>
        /// Order
        /// </summary>
        public int Order
        {
            get
            {
                if (parent == null)
                {
                    return -1;
                }
                return parent.GetChildOrder(this);
            }
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        public virtual void Remove()
        {
            if (parent != null)
            {
                parent.Remove(this);
            }
            ICollection c = new ArrayList(children);
            foreach (INode node in c)
            {
                node.Remove();
            }
        }

        /// <summary>
        /// Removes child node
        /// </summary>
        /// <param name="node">The node to remove</param>
        public virtual void Remove(INode node)
        {
            if (!children.Contains(node))
            {
                return;
            }
            children.Remove(node);
        }

        #endregion

        #region Specific Members


        /// <summary>
        /// Create root node from collection of nodes
        /// </summary>
        /// <param name="objects">Prototypes</param>
        /// <param name="factory">Factory</param>
        /// <returns>Root node</returns>
        public static INode CreateRootNode(ICollection objects, INodeFactory factory)
        {
            INode root = null;
            Hashtable hash = new Hashtable();
            ArrayList nodes = new ArrayList();
            foreach (object o in objects)
            {
                try
                {
                    INode node = factory.CreateNode(o);
                    nodes.Add(node);
                    hash[node.Id] = node;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            foreach (INode node in nodes)
            {
                object p = node.ParentId;
                if (p == null)
                {
                    root = node;
                }
                else if (p.Equals(node.Id))
                {
                    root = node;
                    continue;
                }
                INode parent = hash[p] as INode;
                if (parent != null)
                {
                    node.Parent = parent;
                }
            }
            if (root != null)
            {
                return root;
            }
            if (root == null)
            {
                foreach (INode node in hash.Values)
                {
                    if (node.Parent == null)
                    {
                        root = node;
                        break;
                    }
                }
            }
            return root;
        }


        /// <summary>
        /// Create roots' nodes from collection of nodes
        /// </summary>
        /// <param name="objects">Prototypes</param>
        /// <param name="factory">Factory</param>
        /// <returns>Roots' nodes</returns>
        public static INode[] CreateRoots(ICollection objects, INodeFactory factory)
        {
            //INode root = null;
            Hashtable hash = new Hashtable();
            ArrayList nodes = new ArrayList();
            ArrayList roots = new ArrayList();
            foreach (object o in objects)
            {
                try
                {
                    INode node = factory.CreateNode(o);
                    nodes.Add(node);
                    hash[node.Id] = node;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            foreach (INode node in nodes)
            {
                object p = node.ParentId;
                if (p == null)
                {
                    roots.Add(node);
                }
                else if (p.Equals(node.Id))
                {
                    roots.Add(node);
                    continue;
                }
                INode parent = hash[p] as INode;
                if (parent != null)
                {
                    node.Parent = parent;
                }
            }
            INode[] r = new INode[roots.Count];
            for (int i = 0; i < r.Length; i++)
            {
                r[i] = roots[i] as INode;
            }
            return r;
        }



        /// <summary>
        /// Creates peer tree
        /// </summary>
        /// <param name="prototypeRoot">Root of prototype node</param>
        /// <param name="factory">Node factory</param>
        /// <returns>Root of prototype tree</returns>
        public static INode CreatePeerTree(INode prototypeRoot, INodeFactory factory)
        {
            INode root = factory.CreateNode(prototypeRoot);
            for (int i = 0; i < prototypeRoot.Count; i++)
            {
                INode n = prototypeRoot[i];
                INode node = CreatePeerTree(n, factory);
                node.Parent = root;
            }
            return root;
        }


        /// <summary>
        /// Creates peer tree with existing root
        /// </summary>
        /// <param name="root">Root</param>
        /// <param name="prototypeRoot">Root of prototype node</param>
        /// <param name="factory">Node factory</param>
        public static void CreatePeerTree(INode root, INode prototypeRoot, INodeFactory factory)
        {
            for (int i = 0; i < prototypeRoot.Count; i++)
            {
                INode n = prototypeRoot[i];
                INode node = CreatePeerTree(n, factory);
                node.Parent = root;
            }
        }

        /// <summary>
        /// Creates tree from hierarchy hasthtable
        /// </summary>
        /// <param name="root">Root object</param>
        /// <param name="factory">Factory</param>
        /// <param name="hierarchy">Hierarchy hashtable</param>
        /// <param name="links">Links between nodes and objects</param>
        /// <returns>Root node</returns>
        public static INode CreateTree(object root, INodeFactory factory, Hashtable hierarchy, Hashtable links)
        {
            INode node = factory.CreateNode(root);
            ++commonCount;
            if (hierarchy.ContainsKey(root))
            {
                ArrayList list = hierarchy[root] as ArrayList;
                foreach (object o in list)
                {
                    INode n = CreateTree(o, factory, hierarchy, links);
                    n.Parent = node;
                }
            }
            if (links != null)
            {
                ArrayList l = null;
                if (links.ContainsKey(root))
                {
                    l = links[root] as ArrayList;
                }
                else
                {
                    l = new ArrayList();
                    links[root] = l;
                }
                l.Add(node);
            }
            return node;
        }

        /// <summary>
        /// Gets depth of node
        /// </summary>
        /// <param name="node">The node</param>
        /// <returns>The depth</returns>
        public static int GetDepth(INode node)
        {
            int k = 0;
            if (node.Count > 0)
            {
                for (int i = 0; i < node.Count; i++)
                {
                    INode n = node[i];
                    int m = GetDepth(n);
                    if (m > k)
                    {
                        k = m;
                    }
                }
                return k + 1;
            }
            return 0;
        }

        /// <summary>
        /// Creates tree from hierarchy hasthtable
        /// </summary>
        /// <param name="factory">Factory</param>
        /// <param name="hierarchy">Hierarchy hashtable</param>
        /// <param name="links">Links between nodes and objects</param>
        /// <returns>Root nodes</returns>
        public static INode[] CreateTree(INodeFactory factory, Hashtable hierarchy, Hashtable links)
        {
            commonCount = 0;
            ArrayList l = GetLoop(hierarchy);
            if (l != null)
            {
                Exception e = new TreeException(l);
                throw e;
            }
            ArrayList roots = GetRoots(hierarchy);
            INode[] nodes = new INode[roots.Count];
            for (int i = 0; i < roots.Count; i++)
            {
                nodes[i] = CreateTree(roots[i], factory, hierarchy, links);
            }
            return nodes;
        }

        /// <summary>
        /// Gets loop
        /// </summary>
        /// <param name="parent">Parent object</param>
        /// <param name="hierarchy">Hierarchy</param>
        /// <param name="list">Loop</param>
        /// <param name="ch">Checked objects</param>
        /// <returns>True if hierarchy contains loop and false otherwise</returns>
        public static bool GetLoop(object parent, Hashtable hierarchy, ArrayList list, ArrayList ch)
        {
            if (ch.Contains(parent))
            {
                return false;
            }
            if (list.Contains(parent))
            {
                int i = list.IndexOf(parent);
                if (i > 0)
                {
                    list.RemoveRange(0, i);
                }
                list.Add(parent);
                return true;
            }
            if (!hierarchy.ContainsKey(parent))
            {
                return false;
            }
            list.Add(parent);
            ArrayList l = hierarchy[parent] as ArrayList;
            foreach (object child in l)
            {
                if (GetLoop(child, hierarchy, list, ch))
                {
                    return true;
                }
            }
            ch.Add(parent);
            if (list.IndexOf(parent) != list.Count - 1)
            {
                throw new Exception();
            }
            list.Remove(parent);
            return false;
        }

        /// <summary>
        /// Checks whether hierarchy has loops
        /// </summary>
        /// <param name="hierarchy">Hierarchy</param>
        /// <returns>True if loops exist and false otherwise</returns>
        public static ArrayList GetLoop(Hashtable hierarchy)
        {
            ArrayList loop = new ArrayList();
            ArrayList ch = new ArrayList();
            foreach (object o in hierarchy.Keys)
            {
                if (GetLoop(o, hierarchy, loop, ch))
                {
                    return loop;
                }
            }
            return null;
        }

        /// <summary>
        /// Creates hierarchy from list of objects
        /// </summary>
        /// <param name="list">The list</param>
        /// <returns>The hierarchy</returns>
        public static Hashtable CreateHierarchy(ArrayList list)
        {
            Hashtable table = new Hashtable();
            foreach (object[] o in list)
            {
                ArrayList l = null;
                if (table.ContainsKey(o[0]))
                {
                    l = table[o[0]] as ArrayList;
                }
                else
                {
                    l = new ArrayList();
                    table[o[0]] = l;
                }
                l.Add(o[1]);
            }
            return table;
        }


        /// <summary>
        /// Adds child to hierarchy
        /// </summary>
        /// <param name="hierarchy">Hierarchy</param>
        /// <param name="parent">Parent</param>
        /// <param name="child">Child</param>
        /// <returns>True if child already exists and false otherwise</returns>
        public static bool AddChild(Hashtable hierarchy, object parent, object child)
        {
            if (!hierarchy.ContainsKey(parent))
            {
                ArrayList l = new ArrayList();
                l.Add(child);
                hierarchy[parent] = l;
                return true;
            }
            Hashtable t = new Hashtable();
            foreach (object o in hierarchy.Keys)
            {
                ArrayList l = hierarchy[o] as ArrayList;
                t[o] = new ArrayList(l);
            }
            ArrayList list = t[parent] as ArrayList;
            if (list.Contains(child))
            {
                return false;
            }
            list.Add(child);
            ArrayList loop = GetLoop(t);
            if (loop != null)
            {
                throw new TreeException(loop);
            }
            ArrayList lp = hierarchy[parent] as ArrayList;
            lp.Add(child);
            return true;
        }

        /// <summary>
        /// Gets all roots of hiearchy
        /// </summary>
        /// <param name="hierarchy"></param>
        /// <returns></returns>
        public static ArrayList GetRoots(Hashtable hierarchy)
        {
            ArrayList all = new ArrayList();
            foreach (ArrayList l in hierarchy.Values)
            {
                foreach (object o in l)
                {
                    if (!all.Contains(o))
                    {
                        all.Add(o);
                    }
                }
            }
            ArrayList roots = new ArrayList(hierarchy.Keys);
            foreach (object o in all)
            {
                if (roots.Contains(o))
                {
                    roots.Remove(o);
                }
            }
            return roots;
        }



        /// <summary>
        /// Gets level of node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static int GetLevel(INode node)
        {
            INode p = node.Parent;
            if (p == null)
            {
                return 0;
            }
            return GetLevel(p) + 1;
        }

        /// <summary>
        /// Gets visible expanded nodes
        /// </summary>
        /// <param name="node">Root node</param>
        /// <returns>List of visible nodes</returns>
        static public ArrayList GetExpanded(INode node)
        {
            ArrayList l = new ArrayList();
            getExpanded(node, l);
            return l;
        }

        /// <summary>
        /// Gets all children and writes them to list
        /// </summary>
        /// <param name="list">List to write</param>
        private void getAllChildren(List<INode> list)
        {
            list.Add(this);
            foreach (ArbitraryNode node in children)
            {
                node.getAllChildren(list);
            }
        }


        /// <summary>
        /// Gets visible expanded nodes
        /// </summary>
        /// <param name="node">Root node</param>
        /// <param name="l">List of visible nodes</param>
        private static void getExpanded(INode node, ArrayList l)
        {
            l.Add(node);
            if (!(node is IExpandedNode))
            {
                return;
            }
            IExpandedNode expanded = node as IExpandedNode;
            if (!expanded.IsExpanded)
            {
                return;
            }
            for (int i = 0; i < node.Count; i++)
            {
                getExpanded(node[i], l);
            }
        }


        /// <summary>
        /// Creates subtree
        /// </summary>
        /// <param name="c">Nodes</param>
        /// <param name="factory">Factory</param>
        /// <returns>Root nodes</returns>
        public static INode[] CreateSubTree(ICollection c, INodeFactory factory)
        {
            ArrayList list = new ArrayList();
            ArrayList roots = new ArrayList();
            foreach (INode node in c)
            {
                ICollection path = GetPath(node);
                foreach (INode n in path)
                {
                    if (!list.Contains(n))
                    {
                        list.Add(n);
                        if (n.Parent == null)
                        {
                            roots.Add(n);
                        }
                    }
                }
            }
            INode[] r = new INode[roots.Count];
            for (int i = 0; i < r.Length; i++)
            {
                INode root = roots[i] as INode;
                r[i] = CreateSubTree(root, list, factory);
            }
            return r;
        }

        /// <summary>
        /// Gets node path
        /// </summary>
        /// <param name="node">The node</param>
        /// <param name="list">List of path</param>
        public static void GetPath(INode node, ArrayList list)
        {
            if (list.Count == 0)
            {
                list.Add(node);
            }
            else
            {
                list.Insert(0, node);
            }
            INode parent = node.Parent;
            if (parent == null)
            {
                return;
            }
            GetPath(parent, list);
        }

        /// <summary>
        /// Gets path string representation
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="creator">String creator</param>
        /// <param name="sep">Path separator</param>
        /// <returns>String representation of path</returns>
        public static string GetPathString(ArrayList path, StringCreator creator, string sep)
        {
            string s = "";
            bool first = true;
            foreach (object o in path)
            {
                if (!first)
                {
                    s = s + sep;
                }
                else
                {
                    first = false;
                }
                s = s + creator(o);
            }
            return s;
        }


        /// <summary>
        /// Gets path of node
        /// </summary>
        /// <param name="node">The node</param>
        /// <returns>Path</returns>
        public static ArrayList GetPath(INode node)
        {
            ArrayList list = new ArrayList();
            GetPath(node, list);
            return list;
        }

        /// <summary>
        /// Creates subtree
        /// </summary>
        /// <param name="node">Root</param>
        /// <param name="list">List of nodes</param>
        /// <param name="factory">Factory</param>
        /// <returns>Tree root</returns>
        public static INode CreateSubTree(INode node, ArrayList list, INodeFactory factory)
        {
            INode root = factory.CreateNode(node);
            for (int i = 0; i < node.Count; i++)
            {
                if (list.Contains(node[i]))
                {
                    INode nod = CreateSubTree(node[i], list, factory);
                    nod.Parent = root;
                }
            }
            return root;
        }



        #endregion
    }
}
