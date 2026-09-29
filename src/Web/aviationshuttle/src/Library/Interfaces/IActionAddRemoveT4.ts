import type { IActionT4 } from "./IActionT4"

export interface IActionAddRemoveT4<T1, T2, T3, T4> extends IActionT4<T1, T2, T3, T4> {
    addActionT4(action: IActionT4<T1, T2, T3, T4> | undefined): void
    removeActionT4(action: IActionT4<T1, T2, T3, T4> | undefined): void
    clearActionsT4(): void
}