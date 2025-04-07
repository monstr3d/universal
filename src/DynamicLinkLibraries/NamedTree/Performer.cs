using System.Reflection;

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
            return IsParent(p, child);
  
        }

        public bool IsLeaf<T>(INode<T> node) where T : class
        {
            return GetAttribute<LeafAttribute>(node) != null;
        }

        public void AddChildren<T>(INode<T> parent, IEnumerable<INode<T>> children) where T : class
        {
            var arr = children.ToArray();
            foreach (var child in arr)
            {
                AddChild(parent, child);
            }
        }

        public void AddChild<T>(INode<T> parent, INode<T> child) where T : class
        {
            if (IsLeaf<T>(parent))
            {
                throw new Exception("NamedTree.Performer Parent leaf");
            }
            if (child.Parent != null)
            {
                throw new Exception("NamedTree.Performer Parent alredy exists");
            }
            if (IsParent<T>(child, parent))
            {
                throw new Exception("NamedTree.Performer Parent is child");
            }
            child.Parent = parent;
            parent.Add(child);
        }

        public IEnumerable<INode<T>> GetRoots<T>(IEnumerable<INode<T>> nodes) where T : class
        {
            foreach (var node in nodes)
            {
                if (node.Parent == null)
                {
                    yield return node;
                }
            }
        }

        public IEnumerable<T>GetChildren<T>(INode<T> node) where T : class
        {
            foreach (var child in node.Nodes)
            {
                if (child is T)
                {
                    yield return (T)child;
                }
            }
        }

        /// <summary>
        /// Gets attribute
        /// </summary>
        /// <param name="obj">the object</param>
        /// <returns>The arribute</returns>
        public T GetAttribute<T>(object obj) where T : Attribute
        {
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
