namespace DataPerformer.Portable.Filters
{
    public interface IFilter
    {
        int Count
        { get; set; }

        double? this[double? a] { get; }

        void Reset();
    }
}
