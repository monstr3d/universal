using DataWarehouse.Interfaces;
using NamedTree;

namespace DataWarehouse.React.Server.Models
{
    public class Leaf : ILeaf, IData
    {
        public object Id => throw new NotImplementedException();

        public string Extension => throw new NotImplementedException();

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public INode<INode> Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public INode Value => throw new NotImplementedException();

        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        byte[] IData.Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IEnumerable<INode<INode>> INode<INode>.Nodes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action OnDeleteItself;
        public event Action<ILeaf> OnChangeItself;
        public event Action<INode> OnAdd;
        public event Action<INode> OnRemove;

        public void Add(INode<INode> node)
        {
            throw new NotImplementedException();
        }

        public void Remove(INode<INode> node)
        {
            throw new NotImplementedException();
        }

        public void RemoveItself()
        {
            throw new NotImplementedException();
        }
    }
}
