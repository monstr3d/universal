import type { ISceneObject } from "../../Game/Interfaces/ISceneObject"
import type { ISceneObjectAction } from "../../Game/Interfaces/ISceneObjectAction"
import type { IFactory } from "../../Interfaces/IFactory"
import type { IObject } from "../../Interfaces/IObject"
import { AbstractGameObject } from "../Abstract/AbstractGameObject"

export abstract class AbstractSceneGameAction extends AbstractGameObject implements ISceneObjectAction {
    object!: ISceneObject
    add !: IObject
    constructor(object: ISceneObject, factory: IFactory | undefined) {
        super("", factory)
        this.typeName = "AbstractSceneGameAction"
        this.types.push("ISceneObjectAction")
        this.types.push("IAction")
        this.types.push("AbstractSceneGameAction")
        this.object = object;
    }

    getActionSceneObject(): ISceneObject {
        return this.object;
    }

    abstract getActionSceneAdditionalObject(): IObject | undefined
  
    abstract action(): void 

    isEmptyAction(): boolean {
        return false;
    }
}

