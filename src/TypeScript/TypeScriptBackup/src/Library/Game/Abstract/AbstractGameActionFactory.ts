import { FactoryObject } from "../../FactoryObject";
import type { IGameAction } from "../../Game/Interfaces/IGameAction";
import type { IGameActionFactory } from "../../Game/Interfaces/IGameActionFactory";
import type { IFactory } from "../../Interfaces/IFactory";

export abstract class AbstractGameActionFactory extends FactoryObject implements IGameActionFactory {
    constructor(factory: IFactory | undefined) {
        super("", factory)
        this.types.push("IGameActionFactory")
        this.types.push("AbstractGameActionFactory")
        this.typeName = "AbstractGameActionFactory"
  }

    abstract getGameAction(object: any): IGameAction | undefined


}