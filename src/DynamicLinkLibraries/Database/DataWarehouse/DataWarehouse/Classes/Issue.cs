namespace DataWarehouse.Classes
{
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
        AddDirectory
    }
}
