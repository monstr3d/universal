import type { IIterator } from "./IIterator";

export interface IIteratorConsumer {
       /// <summary>
    /// Adds iterator
    /// </summary>
    /// <param name="iterator">The iterator to add</param>
    addIterator(iterator: IIterator): void;

/// <summary>
/// Removes iterator
/// </summary>
/// <param name="iterator">The iterator to remove</param>
    removeIterator(iterator: IIterator) : void;

}