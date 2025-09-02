namespace BaseTypes.Interfaces
{
    /// <summary>
    /// Initial value interface
    /// </summary>
    public interface IInitialValue
    {
        object Value { get; set; }

        void Set();
    }
}
