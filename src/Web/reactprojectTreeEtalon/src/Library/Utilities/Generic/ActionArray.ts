import  { type IAction } from "../../Interfaces/IAction";
import type { IActionAddRemove } from "../../Interfaces/IActionAddRemove";
import type { IObject } from "../../Interfaces/IObject";
import { Performer } from "../../Performer";

export class ActionArray implements IActionAddRemove, IObject {
    isEmptyAction(): boolean {
        return this.actions.length == 0
    }
    addAction(action: IAction | undefined): void {
        if (this.performer.isEmptyAction(action)) return;
        if (action === undefined) return;
        this.actions.push(action)
    }
    removeAction(action: IAction): void {
        if (this.performer.isEmptyAction(action)) return;
        if (action === undefined) return;
         this.performer.remove(this.actions, action)
    }
    clearActions(): void {
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
    action(): void {
        for (let action of this.actions)
            action.action();
    }

    addActionArray(actions: IAction[]): void {
        for (let action of actions) {
            this.addAction(action)
        }
    }


    protected actions: IAction[] = [];

    protected typeName: string = "ActionArray";

    protected types: string[] = ["IAction", "IObject", "ActionArray"];

    protected performer: Performer = new Performer();

}
