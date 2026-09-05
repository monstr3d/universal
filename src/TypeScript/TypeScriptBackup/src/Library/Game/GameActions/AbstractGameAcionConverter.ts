import type { IAction } from "../../Interfaces/IAction";
import { AbstractGameObject } from "../Abstract/AbstractGameObject";
import type { IGameActionConverter } from "../Interfaces/IGameActionConverter";

export abstract class AbstractGameAcionConverter extends AbstractGameObject implements IGameActionConverter {

    abstract functT(s: IAction): IAction | undefined

    constructor() {
        super("", undefined)
        this.typeName = "AbstractGameAcionConverter"
        this.types.push("IGameAcionConverter")
        this.types.push("AbstractGameAcionConverter")
    }
}