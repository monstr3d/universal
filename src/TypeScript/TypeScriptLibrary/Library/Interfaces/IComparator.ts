export interface IComparator<T> {
    compare(x: T, y: T): number;

}