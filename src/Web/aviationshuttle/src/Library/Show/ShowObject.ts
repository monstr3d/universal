import type { IActionAddRemoveT } from "../Interfaces/IActionAddRemoveT";
import type { IActionT } from "../Interfaces/IActionT";
import type { IFactory } from "../Interfaces/IFactory";
import type { IShowObject } from "./Interfaces/IShowObject";
import type { IShowData } from "./Interfaces/IShowData";
import { FactoryObject } from "../FactoryObject";
import { ActionArrayT } from "../Utilities/Generic/ActionArrayT";

export class ShowObject extends FactoryObject implements IShowObject, IActionAddRemoveT<IShowData> {
    constructor(factory: IFactory) {
        super("", factory)
        this.types.push("IShowObject")
        this.types.push("EmptyShowObject")
        this.typeName = "EmptyShowObject"

    }

    show(sender: any, show: any, name?: string | undefined): boolean {
        const data: IShowData = { sender: sender, show: show, name: name }
        this.actionT(data)
        return true
    }

    addActionT(action: IActionT<IShowData> | undefined): void {
        this.action.addActionT(action)
    }
    removeActionT(action: IActionT<IShowData> | undefined): void {
        this.action.removeActionT(action)
    }
    clearActionsT(): void {
        this.action.clearActionsT()
    }
    actionT(t: IShowData): void {
        this.action.actionT(t)
    }
    isEmptyActionT(): boolean {
        return this.action.isEmptyActionT()
    }



    protected object: any

    protected str: string | undefined = undefined

    protected action: IActionAddRemoveT<IShowData> = new ActionArrayT()
}