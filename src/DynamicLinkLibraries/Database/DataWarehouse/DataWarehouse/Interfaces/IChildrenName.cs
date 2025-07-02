using NamedTree;

namespace DataWarehouse.Interfaces
{
    public interface IChildrenName
    {
        bool Check(INamed named);

        bool Add(INamed named);

        bool Remove(INamed named);
    }
}
