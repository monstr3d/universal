using DataWarehouse.Interfaces;

namespace DataWarehouse.Classes
{

    public record class UpdateData
    {
        public byte[] Last { get; init; }
        public byte[] New { get; init; }
        public ILeaf Leaf { get; init; }

        public UpdateData(byte[] last, byte[] New, ILeaf leaf)
        {
            this.Last = last;
            this.New = New;
            this.Leaf = leaf;
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
        IllegalName,
        Database
    }

    public enum OperationType
    {
        AddDirectory,
        DeleteDirectory,
        AddLeaf,
        DeleteLeaf,
        UpdateLeafData
    }
}
