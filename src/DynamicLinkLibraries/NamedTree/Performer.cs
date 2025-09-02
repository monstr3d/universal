using System.Reflection;

using System.Xml;

using ErrorHandler;

namespace NamedTree
{
    public class Performer
    {

        /// <summary>
        /// Converts to string
        /// </summary>
        /// <param name="a">Double value</param>
        /// <returns>String</returns>
        public string DoubleToString(double a)
        {
            return a.ToString("G17", System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets strings from double array
        /// </summary>
        /// <param name="x">The array</param>
        /// <returns>The strings</returns>
        public List<string> GetStrings(double[] x)
        {
            var l = new List<string>();
            var n = x.Length;
            var m = n - 1;
            for (var i = 0; i < x.Length; i++)
            {
                var s = i < m ? "," : "";
                s = DoubleToString(x[i]) + s;
                l.Add(s);
            }
            return l;
        }

        /// <summary>
        /// Adding list with shift
        /// </summary>
        /// <param name="list">The list</param>
        /// <param name="l">The added list</param>
        /// <param name="shift">The shift</param>
        public void Add(List<string> list, List<string> l, int shift)
        {
            var s = "";
            for (int i = 0; i < shift; i++)
            {
                s += "\t";
            }
            foreach (var item in l)
            {
                list.Add(s + item);
            }
        }

        public IEnumerable<T> Convert<T, S>(IEnumerable<S> values) where T : class where S : class
        {
          return from value in values where value is T select value as T;

        }


        /// <summary>
        /// Sorts py name
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="nameds">collection</param>
        /// <returns>Sorted</returns>
        public IEnumerable<T> SotByName<T>(IEnumerable<INamed> nameds) where T : class 
        {
            var d = new Dictionary<string, INamed>();
            Func<INamed, string> f = (INamed named) =>
            {
                var name = named.Name;
                d[name] = named;
                return name;
            };

            var l = (from n in nameds select f(n)).ToList();
            l.Sort();
            foreach (var n in l)
            {
                yield return d[n] as T;
            }
        }

        public IEnumerable<T> GetAllT<T>(INode<T> node) where T : class
        {
            return from n in GetAll(node)  select n.Value;
        }

        public void Perform<T>(INode<T> node, Action<T> action) where T : class
        {
            var nodes = node.Nodes;
            foreach (var child in nodes)
            {
                Perform(child, action);
            }
            action(node.Value);
        }


        public IEnumerable<INode<T>> GetAll<T>(INode<T> node) where T : class
        {
            yield return node;
            foreach (var child in node.Nodes)
            {
                var result = GetAll(child);
                foreach (var res in result)
                {
                    yield return res;
                }
            }
        }

        public bool IsParent<T>(INode<T> parent, INode<T> child) where T : class 
        {
            INode<T> p = child.Parent;
            if (p == null)
            {
                return false;
            }
            if (p == parent)
            {
                return true;
            }
            return IsParent(parent, p);
  
        }

        public bool IsLeaf<T>(INode<T> node) where T : class
        {
            return GetAttribute<LeafAttribute<T>>(node) != null;
        }



        public void AddChildrenNodes<T>(INode<T> parent, IEnumerable<INode<T>> children) where T : class
        {
            var arr = children.ToArray();
            foreach (var child in arr)
            {
                AddChildNode(parent, child);
            }
        }

        public void AddChild<T>(IChildren<T> parent, T child) where T : class
        {
            parent.AddChild(child);
        }

        public IEnumerable<T> Get<T>(IChildren<T> children) where T : class
        {
            return children.Children;
        }

        public IEnumerable<T> Get<T>(INode<T> node) where T : class
        {
            return from n in node.Nodes select n.Value;
        }


        public void AddChildren<T>(IChildren<T> parent, IEnumerable<T> children) where T : class
        {
            var arr = children.ToArray();
            foreach (var child in arr)
            {
                AddChild(parent, child);
            }

        }

        /// <summary>
        /// Sets parents for the Dictionary
        /// </summary>
        /// <param name="nodes">The dictionary</param>
        public void SetParents<T>(Dictionary<XmlElement, T> nodes) where T : class
        {
            foreach (var node in nodes)
            {
                var a = node.Key;
                var p = a.ParentNode;
                while (p != null)
                {
                    if (p is XmlElement e)
                    {
                        if (nodes.ContainsKey(e))
                        {
                            var b = nodes[e];
                            (node.Value as INode<T>).Parent = b as INode<T>;
                            break;
                        }
                    }
                    p = p.ParentNode;
                }
            }
        }

        

        public INode<T> GetParent<T>(INode<T> node, Func<INode<T>, INode<T>> findParent) where T : class
        {
            if (node.Parent != null)
            {
                throw new InvalidOperationException("Patent exist");
            }
            var parent = findParent(node);
            if (parent != null)
            {
                node.Parent = parent;
                parent.Add(node);
            }
            else
            {
                return null;
            }
            return parent;
        }


        public IEnumerable<INode<T>> GetRoots<T>(IEnumerable<INode<T>> nodes, Func<INode<T>, INode<T>> findParent) where T : class
        {
            var parents = from node in nodes select GetParent(node, findParent);
            parents.ToList();
            return from node in nodes where node.Parent == null select node;
        }

        public IEnumerable<T> GetRootsT<T>(IEnumerable<INode<T>> nodes, Func<INode<T>, INode<T>> findParent) where T : class
        {
            return from node in GetRoots(nodes, findParent) select node.Value;
        }


        public Dictionary<T, S> Inverse<T, S>(Dictionary<S, T> dictionray)
        {
            var d = new Dictionary<T, S>();
            foreach (var p in dictionray) d[p.Value] = p.Key;
            return d;
        }

      public IEnumerable<T> GetRoots<T, S>(Dictionary<INode<T>, S> childParent, Dictionary<S, INode<T>> id) 
            where T : class where S : class
        {

            var f = (INode<T> node) =>
            {
                if (!childParent.ContainsKey(node))
                {
                    return null;
                }
                var p = childParent[node];
                return id.ContainsKey(p) ? id[p] : null;
            };
            return GetRootsT(id.Values, f);
        }


        public IEnumerable<T> GetRoots<T>(Dictionary<XmlElement, INode<T>> dictionary) where T : class
        {
            var dd = new Dictionary<INode<T>, XmlElement>();
            foreach (var x in dictionary)
            {
                var p = x.Key.ParentNode;
                if (p is XmlElement e)
                {
                    if (dictionary.ContainsKey(e))
                    {
                        var parent = dictionary[e];
                        dd[x.Value] = e;
                    }
                }
            }
            return GetRoots(dd, dictionary);
        }

        /// <summary>
        /// Sets parents for the Dictionary
        /// </summary>
        /// <param name="nodes">The dictionary</param>
        public void SetParents<T>(Dictionary<XmlElement, INode<T>> nodes) where T : class
        {
            foreach (var node in nodes)
            {
                var a = node.Key;
                var p = a.ParentNode;
                while (p != null)
                {
                    if (p is XmlElement e)
                    {
                        if (nodes.ContainsKey(e))
                        {
                            var b = nodes[e];
                            node.Value.Parent = b;
                            break;
                        }
                    }
                    p = p.ParentNode;
                }
            }
        }

        public void AddChildNode<T>(INode<T> parent, INode<T> child, bool change = true) where T : class
        {
            if (parent == null)
            {
                return;
            }
            if (child.Parent == parent)
            {
                return;
            }
            if (IsLeaf<T>(parent))
            {
                throw new OwnException("NamedTree.Performer Parent leaf");
            }
            if (child.Parent != null)
            {
                if (!change)
                {
                    throw new OwnException("NamedTree.Performer Parent alredy exists");
                }
                child.Parent.Remove(child);
                child.Parent = null;
            }
            if (child.Parent == parent)
            {
                return;
            }
            if (IsParent<T>(child, parent))
            {
                throw new OwnException("NamedTree.Performer Parent is child");
            }
            parent.Add(child);
            child.Parent = parent;
        }

        public IEnumerable<INode<T>> GetRoots<T>(IEnumerable<INode<T>> nodes) where T : class
        {
           return  from node in nodes where node.Parent == null select node;
        }

        public IEnumerable<T> GetRootsT<T>(IEnumerable<INode<T>> nodes) where T : class
        {
            return from node in nodes where node.Parent == null select node.Value;
        }

        public IEnumerable<T> GetChildren<T>(INode<T> node) where T : class
        {
            return from n in node.Nodes select n.Value;
        }

        /// <summary>
        /// Gets path
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="node">Bode</param>
        /// <returns>The path</returns>
        public IEnumerable<INode<T>> GetPath<T>(INode<T> node) where T : class
        {
            if (node == null)
            {
                yield break;
            }
            yield return node;
            var p = GetPath(node.Parent);
            foreach (var item in p)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Gets path
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="node">Bode</param>
        /// <returns>The path</returns>
        public IEnumerable<T> GetPath<T>(T node) where T : class, INode<T>
        {
            var enu = GetPath<T>(node as INode<T>);
            return from t in enu select t.Value;
        }

        /// <summary>
        /// Gets common root pf node1 and node2
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="node1">node1</param>
        /// <param name="node2">node2</param>
        /// <returns>The common root</returns>
        public T GetRoot<T>(T node1, T node2) where T : class, INode<T>
        {
            var l = GetPath<T>(node1).ToArray();
            var p2 = GetPath<T>(node2);
            foreach (var item in p2)
            {
                if (!l.Contains(item))
                {
                    return item;
                }
            }
            return null;
        }

        


        /// <summary>
        /// Gets attribute
        /// </summary>
        /// <param name="obj">the object</param>
        /// <returns>The arribute</returns>
        public T GetAttribute<T>(object obj) where T : Attribute
        {
            if (obj == null)
            {
                return null;
            }
            Type type = (obj is Type) ? obj as Type : obj.GetType();
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8604 // Possible null reference argument.
            return CustomAttributeExtensions
                 .GetCustomAttribute<T>(IntrospectionExtensions.GetTypeInfo(type));
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8603 // Possible null reference return.
        }

        class FindParent<T> where T : class
        {
            internal FindParent(INode<T> node, Func<INode<T>, INode<T>> findParent)
            {
                var parent = findParent(node);
                if (parent != null)
                {
                    node.Parent = parent;
                    parent.Add(node);
                }
            }
        }

    }
}
