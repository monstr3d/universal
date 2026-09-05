import type { ISceneObjectActionHolder } from "../../Game/Interfaces/ISceneObejctActionHolder";
import type { ISceneObject } from "../../Game/Interfaces/ISceneObject";
import type { ISceneObjectAction } from "../../Game/Interfaces/ISceneObjectAction";
import type { IAction } from "../../Interfaces/IAction";
import type { IReferenceFrame } from "../../Motion6D/Interfaces/IReferenceFrame";
import type { IFactory } from "../../Interfaces/IFactory";
import { AbstractGameAction } from "../../Game/Abstract/AbstractGameAction";
import { Game3DPerformer } from "../Game3DPerformer";
export declare class ReferenceFrameGameAction extends AbstractGameAction implements ISceneObjectActionHolder {
    constructor(frame: IReferenceFrame, name: string, factory: IFactory | undefined);
    getSceneObjectAction(): ISceneObjectAction;
    protected createHolder(obj: ISceneObject): void;
    frame: IReferenceFrame;
    holder: ISceneObjectAction;
    mPerformer: Game3DPerformer;
    functT(s: ISceneObject): IAction | undefined;
}
//# sourceMappingURL=ReferenceFrameGameAction.d.ts.map