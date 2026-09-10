import { AbstractGameActionFactory } from "../../Game/Abstract/AbstractGameActionFactory";
import type { IGameAction } from "../../Game/Interfaces/IGameAction";
import type { ISceneObject } from "../../Game/Interfaces/ISceneObject";
import type { IAction } from "../../Interfaces/IAction";
import type { IFindFrame } from "../Interfaces/IFindFrame";
import type { IFactory } from "../../Interfaces/IFactory";
export declare class ReferenceFrameGameActionFactory extends AbstractGameActionFactory implements IGameAction {
    constructor(find: IFindFrame, factory: IFactory | undefined);
    functT(s: ISceneObject): IAction | undefined;
    getGameAction(object: any): IGameAction | undefined;
    find: IFindFrame;
    s: ISceneObject;
}
//# sourceMappingURL=ReferenceFrameGameActionFactory.d.ts.map