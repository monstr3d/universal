import type { IActionAddRemoveT } from "../../Interfaces/IActionAddRemoveT";
import type { IObject } from "../../Interfaces/IObject";
import type { IActionT } from "../../Interfaces/IActionT";
import { Performer } from "../../Performer";

export class ActionArrayT<T> implements IActionAddRemoveT<T>, IObject {

    isEmptyActionT(): boolean {
        return this.actions.length == 0;
    }
    addActionT(action: IActionT<T> | undefined): void {
        if (this.performer.isEmptyActionT(action)) return;
        if (action === undefined) return;
        this.actions.push(action)
    }
    removeActionT(action: IActionT<T>): void {
        if (this.performer.isEmptyActionT(action)) return;
        if (action === undefined) return;
        this.performer.remove(this.actions, action)
    }
    clearActionsT(): void {
        this.actions = [];
    }
    getClassName(): string {
        return this.typeName;
    }
    imlplementsType(type: string): boolean {
        return this.types.indexOf(type) > 0;
    }
    getName(): string {
        return "";
    }
    actionT(t : T): void {
        for (let action of this.actions)
            action.actionT(t);
    }

    

    protected actions: IActionT<T>[] = [];

    protected typeName: string = "ActionArrayT";

    protected types: string[] = ["IActionT", "IActionArrayT", "IObject", "ActionArrayT"];

    protected performer: Performer = new Performer();

}