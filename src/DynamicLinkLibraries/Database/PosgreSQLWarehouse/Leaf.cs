using DataWarehouse.Interfaces;
using ErrorHandler;
using NamedTree;

namespace PosgreSQLWarehouse
{
    internal class Leaf : DataWarehouse.Classes.Abstract.Leaf
    {
        PosgreSQLWarehouseInterface PosgreSQLWarehouseInterface { get; init; } 

        public Leaf(ILeafData data, IDirectory directory, Guid id, PosgreSQLWarehouseInterface posgreSQLWarehouseInterface) : base(data, directory)
        {
            Id = id;
            PosgreSQLWarehouseInterface = posgreSQLWarehouseInterface;
        }
    
        protected override void Add(INode<INode> node)
        {
            throw new OwnNotImplemented("Leaf");
        }

        protected override void Remove(INode<INode> node)
        {
            throw new OwnNotImplemented("Leaf");
        }

        protected override void RemoveItself()
        {
            throw new OwnNotImplemented("Leaf");
        }
    }
}
