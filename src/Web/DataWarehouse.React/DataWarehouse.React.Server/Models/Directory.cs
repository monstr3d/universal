using DataWarehouse.Interfaces;
using NamedTree;

namespace DataWarehouse.React.Server.Models
{
    public class Directory : IDirectory
    {
        public object Id => throw new NotImplementedException();

        public string Extension => throw new NotImplementedException();

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public INode<INode> Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public INode Value => throw new NotImplementedException();

        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<IDirectory> Children => throw new NotImplementedException();

        IEnumerable<ILeaf> IChildren<ILeaf>.Children => throw new NotImplementedException();

        IEnumerable<IDirectory> IChildren<IDirectory>.Children => throw new NotImplementedException();

        object INode.Id => throw new NotImplementedException();

        string INode.Extension => throw new NotImplementedException();

        string INamed.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        INode<INode> INode<INode>.Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IEnumerable<INode<INode>> INode<INode>.Nodes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        INode INode<INode>.Value => throw new NotImplementedException();

        string IDescription.Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action<IDirectory> OnAddDirectory;
        public event Action OnDeleteItself;
        public event Action<IDirectory> OnChangeItself;
        public event Action<ILeaf> OnAddLeaf;
        public event Action<INode> OnAdd;
        public event Action<INode> OnRemove;

        event Action<IDirectory> IChildren<IDirectory>.OnAdd
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event Action<ILeaf> IChildren<ILeaf>.OnAdd
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event Action<INode> INode<INode>.OnAdd
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event Action<IDirectory> IChildren<IDirectory>.OnRemove
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event Action<ILeaf> IChildren<ILeaf>.OnRemove
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event Action<INode> INode<INode>.OnRemove
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event Action<IDirectory> IDirectory.OnAddDirectory
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event Action IDirectory.OnDeleteItself
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event Action<IDirectory> IDirectory.OnChangeItself
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event Action<ILeaf> IDirectory.OnAddLeaf
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public IDirectory Add(IDirectory directory)
        {
            throw new NotImplementedException();
        }

        public ILeaf Add(ILeaf leaf)
        {
            throw new NotImplementedException();
        }

        public void Add(INode<INode> node)
        {
            throw new NotImplementedException();
        }

        public void AddChild(IDirectory child)
        {
            throw new NotImplementedException();
        }

        public void AddChild(ILeaf child)
        {
            throw new NotImplementedException();
        }

        public void Remove(INode<INode> node)
        {
            throw new NotImplementedException();
        }

        public void RemoveChild(IDirectory child)
        {
            throw new NotImplementedException();
        }

        public void RemoveChild(ILeaf child)
        {
            throw new NotImplementedException();
        }

        public void RemoveItself()
        {
            throw new NotImplementedException();
        }

        IDirectory IDirectory.Add(IDirectory directory)
        {
            throw new NotImplementedException();
        }

        ILeaf IDirectory.Add(ILeaf leaf)
        {
            throw new NotImplementedException();
        }

        void INode<INode>.Add(INode<INode> node)
        {
            throw new NotImplementedException();
        }

        void IChildren<IDirectory>.AddChild(IDirectory child)
        {
            throw new NotImplementedException();
        }

        void IChildren<ILeaf>.AddChild(ILeaf child)
        {
            throw new NotImplementedException();
        }

        void INode<INode>.Remove(INode<INode> node)
        {
            throw new NotImplementedException();
        }

        void IChildren<IDirectory>.RemoveChild(IDirectory child)
        {
            throw new NotImplementedException();
        }

        void IChildren<ILeaf>.RemoveChild(ILeaf child)
        {
            throw new NotImplementedException();
        }

        void INode.RemoveItself()
        {
            throw new NotImplementedException();
        }
    }
}
