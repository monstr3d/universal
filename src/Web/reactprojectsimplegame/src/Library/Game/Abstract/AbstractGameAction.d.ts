import type { IGameAction } from "../../Game/Interfaces/IGameAction";
import type { ISceneObject } from "../../Game/Interfaces/ISceneObject";
import type { IAction } from "../../Interfaces/IAction";
import type { IFactory } from "../../Interfaces/IFactory";
import { AbstractGameObject } from "./AbstractGameObject";
export declare abstract class AbstractGameAction extends AbstractGameObject implements IGameAction {
    constructor(name: string, factory: IFactory | undefined);
    abstract functT(s: ISceneObject): IAction | undefined;
}
//# sourceMappingURL=AbstractGameAction.d.ts.map