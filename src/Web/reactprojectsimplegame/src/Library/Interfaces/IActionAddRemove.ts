import type { IAction } from "./IAction";

export interface IActionAddRemove extends IAction {
    addAction(action: IAction | undefined): void
    removeAction(action: IAction | undefined): void
    clearActions(): void
}