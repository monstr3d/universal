using ErrorHandler;
using System.Reflection;
using System.Xml;

namespace NamedTree
{
    public class Performer
    {

        public Performer()
        {
        }

        public IEnumerable<T> GetAllT<T>(INode<T> node) where T : class
        {
            return from n in GetAll(node)  select n.Value;
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

        

    }
}
