using NamedTree;

namespace DataWarehouse.Interfaces
{
    public interface IChildrenName
    {
        bool Check(INamed named);

        bool Check(string name);

        bool Add(INamed named);

        bool Remove(INamed named);

        bool Change(INamed named, string newname);

    }
}
