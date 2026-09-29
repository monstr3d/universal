import { EmptyObject } from "../../EmptyObject";
import type { IActionAddRemoveT4 } from "../../Interfaces/IActionAddRemoveT4";
import type { IActionT4 } from "../../Interfaces/IActionT4";


export class ActionArrayT4<T1, T2, T3, T4> extends EmptyObject implements IActionAddRemoveT4<T1, T2, T3, T4> {
    constructor() {
        super("")
        this.types.push("IActionAddRemoveT4")
        this.types.push("ActionArrayT4")
        this.typeName = "ActionArrayT4"
    }

    isEmptyActionT4(): boolean {
        return this.actions.length == 0;
    }

    addActionT4(action: IActionT4<T1, T2, T3, T4> | undefined): void {
        if (this.performer.isEmptyActionT4(action)) return;
        if (action === undefined) return;
        this.actions.push(action)
    }
    removeActionT4(action: IActionT4<T1, T2, T3, T4>): void {
        if (this.performer.isEmptyActionT4(action)) return;
        if (action === undefined) return;
        this.performer.remove(this.actions, action)
    }
    clearActionsT4(): void {
        this.actions = [];
    }
    actionT4(t1: T1, t2: T2, t3: T3, t4: T4): void {
        for (let action of this.actions)
            action.actionT4(t1, t2, t3, t4);
    }
    protected actions: IActionT4<T1, T2, T3, T4>[] = [];

}