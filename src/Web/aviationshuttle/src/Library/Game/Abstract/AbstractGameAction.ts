import type { IGameAction } from "../../Game/Interfaces/IGameAction";
import type { ISceneObject } from "../../Game/Interfaces/ISceneObject";
import type { IAction } from "../../Interfaces/IAction";
import type { IFactory } from "../../Interfaces/IFactory";
import { AbstractGameObject } from "./AbstractGameObject";

export abstract class AbstractGameAction extends AbstractGameObject implements IGameAction {

    constructor(name: string, factory: IFactory | undefined) {
        super(name, factory)
        this.types.push("IGameAction")
        this.types.push("AbstractGameAction")
        this.typeName = "AbstractGameAction"
    }
    abstract functT(s: ISceneObject): IAction | undefined
}