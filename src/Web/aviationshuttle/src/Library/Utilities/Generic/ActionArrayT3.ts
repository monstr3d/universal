import { EmptyObject } from "../../EmptyObject";
import type { IActionAddRemoveT3 } from "../../Interfaces/IActionAddRemoveT3";
import type { IActionT3 } from "../../Interfaces/IActionT3";


export class ActionArrayT3<T1, T2, T3> extends EmptyObject implements IActionAddRemoveT3<T1, T2, T3> {
    constructor() {
        super("")
        this.types.push("IActionAddRemoveT3")
        this.types.push("ActionArrayT3")
        this.typeName = "ActionArrayT3"
    }

    isEmptyActionT3(): boolean {
        return this.actions.length == 0;
    }

    addActionT3(action: IActionT3<T1, T2, T3> | undefined): void {
        if (this.performer.isEmptyActionT3(action)) return;
        if (action === undefined) return;
        this.actions.push(action)
    }
    removeActionT3(action: IActionT3<T1, T2, T3>): void {
        if (this.performer.isEmptyActionT3(action)) return;
        if (action === undefined) return;
        this.performer.remove(this.actions, action)
    }
    clearActionsT3(): void {
        this.actions = [];
    }
    actionT3(t1: T1, t2: T2, t3 : T3): void {
        for (let action of this.actions)
            action.actionT3(t1, t2, t3);
    }
    protected actions: IActionT3<T1, T2, T3>[] = [];

}