import type { IActionT } from "./IActionT";

export interface IActionAddRemoveT<T> extends IActionT<T>{
    addActionT(action: IActionT<T> | undefined): void
    removeActionT(action: IActionT<T> | undefined): void
    clearActionsT(): void
}