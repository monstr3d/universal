import { FactoryObject } from "../../FactorytObject";
import type { IGameAction } from "../../Game/Interfaces/IGameAction";
import type { IGameActionFactory } from "../../Game/Interfaces/IGameActionFactory";
import type { IFactory } from "../../Interfaces/IFactory";
export declare abstract class AbstractGameActionFactory extends FactoryObject implements IGameActionFactory {
    constructor(factory: IFactory | undefined);
    abstract getGameAction(object: any): IGameAction | undefined;
}
//# sourceMappingURL=AbstractGameActionFactory.d.ts.map