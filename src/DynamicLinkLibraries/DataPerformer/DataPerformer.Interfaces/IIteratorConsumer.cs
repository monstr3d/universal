namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Consumer of iterator
    /// </summary>
    public interface IIteratorConsumer
    {
        /// <summary>
        /// Adds iterator
        /// </summary>
        /// <param name="iterator">The iterator to add</param>
        void Add(IIterator iterator);

        /// <summary>
        /// Removes iterator
        /// </summary>
        /// <param name="iterator">The iterator to remove</param>
        void Remove(IIterator iterator);
    }
}
