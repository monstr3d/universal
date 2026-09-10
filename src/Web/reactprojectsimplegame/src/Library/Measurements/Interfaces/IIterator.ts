export interface IIterator {
    /// Next operation
    nextIterator(): boolean;

    /// Reset operation
    resetIterator(): void;

}