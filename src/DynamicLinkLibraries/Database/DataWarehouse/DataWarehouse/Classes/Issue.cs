using DataWarehouse.Interfaces;

namespace DataWarehouse.Classes
{

    public record class UpdateData<T, S> where T : class where S : class
    {
        public T Last { get; init; }
        public T New { get; init; }
        public S Node { get; init; }
        public UpdateData(T last, T New, S node)
        {
            this.Last = last;
            this.New = New;
            Node = node;
        }
    }
 

    public record class Issue
    {



        public Issue(object obj, ErrorType errorType, OperationType operationType)
        {
            Object = obj;
            ErrorType = errorType;
            OperationType = operationType;
        }

        public object Object { get; init; }

        public ErrorType ErrorType { get; init; }

        public OperationType OperationType { get; init; }
    }

    public enum ErrorType
    {
        None,
        AlreadyExecuted,
        IllegalName,
        Database
    }

    public enum OperationType
    {
        AddDirectory,
        DeleteDirectory,
        AddLeaf,
        DeleteLeaf,
        UpdateLeafData,
        UpdateDirectoryName,
        LoadDirectories,
        LoadLeaves
    }
}
