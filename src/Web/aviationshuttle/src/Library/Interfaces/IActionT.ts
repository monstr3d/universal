export interface IActionT<T> {
    actionT(t: T): void;
    isEmptyActionT(): boolean
}