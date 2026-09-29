import { AbstractGameActionFactory } from "../../Game/Abstract/AbstractGameActionFactory";
import { ReferenceFrameGameAction } from "./ReferenceFrameGameAction";
import type { IGameAction } from "../../Game/Interfaces/IGameAction";
import type { IScene } from "../../Game/Interfaces/IScene";
import type { ISceneObject } from "../../Game/Interfaces/ISceneObject";
import type { IAction } from "../../Interfaces/IAction";
import type { IFindFrame } from "../Interfaces/IFindFrame";
import type { IFactory } from "../../Interfaces/IFactory";

export class ReferenceFrameGameActionFactory extends AbstractGameActionFactory
    implements IGameAction {
    constructor(find: IFindFrame, factory: IFactory | undefined) {
        super(factory)
        this.typeName = "ReferenceFrameGameActionFactory"
        this.types.push("IGameAction")
        this.types.push("ReferenceFrameGameActionFactory")
        this.find = find;
    }
    functT(s: ISceneObject): IAction | undefined {
        this.s = s
        return undefined;
    }
    getGameAction(object: any): IGameAction | undefined {
        var sc = object as unknown as IScene
        var fr = this.find.functT(sc)
        if (fr === undefined)
            return this
        return new ReferenceFrameGameAction(fr, "", this.getConsumerFactory())
    }

    find !: IFindFrame

    s !: ISceneObject
}