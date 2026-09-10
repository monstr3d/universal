import type { IAction } from "./IAction";

export interface IAddAction {
    addAction(action: IAction, add: boolean): void
}