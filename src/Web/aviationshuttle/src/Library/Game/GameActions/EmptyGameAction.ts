import { AbstractGameAction } from "../../Game/Abstract/AbstractGameAction";
import type { ISceneObject } from "../../Game/Interfaces/ISceneObject";
import type { IAction } from "../../Interfaces/IAction";
import type { IFactory } from "../../Interfaces/IFactory";

export class EmptyGameAction extends AbstractGameAction implements IAction {
    constructor(name: string, factory: IFactory | undefined) {
        super(name, factory)
        this.typeName = "EmptyGameAction"
        this.types.push("EmptyGameAction")
    }

    action(): void {

    }

    isEmptyAction(): boolean {
        return false;
    }

    functT(s: ISceneObject): IAction | undefined {
        this.s = s
        return this;
    }

    protected s !: ISceneObject

}