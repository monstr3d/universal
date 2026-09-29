import type { IActionT3 } from "./IActionT3"

export interface IActionAddRemoveT3<T1, T2, T3> extends IActionT3<T1, T2, T3> {
    addActionT3(action: IActionT3<T1, T2, T3> | undefined): void
    removeActionT3(action: IActionT3<T1, T2, T3> | undefined): void
    clearActionsT3(): void
}