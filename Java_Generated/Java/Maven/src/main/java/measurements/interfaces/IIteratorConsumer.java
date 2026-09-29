package measurements.interfaces;

public interface IIteratorConsumer {
    /// <summary>
    /// Adds iterator
    /// </summary>
    /// <param name="iterator">The iterator to add</param>
    void addIterator(IIterator iterator);

    /// <summary>
    /// Removes iterator
    /// </summary>
    /// <param name="iterator">The iterator to remove</param>
    void removeIterator(IIterator iterator);

}
