import type { ISceneObjectActionHolder } from "../../Game/Interfaces/ISceneObejctActionHolder";
import type { ISceneObject } from "../../Game/Interfaces/ISceneObject";
import type { ISceneObjectAction } from "../../Game/Interfaces/ISceneObjectAction";
import type { IAction } from "../../Interfaces/IAction";
import type { IObject } from "../../Interfaces/IObject";
import type { IReferenceFrame } from "../../Motion6D/Interfaces/IReferenceFrame";
import type { IFactory } from "../../Interfaces/IFactory";
import { AbstractGameAction } from "../../Game/Abstract/AbstractGameAction";
import { AbstractSceneGameAction } from "../../Game/GameActions/AbstractSceneGameAction";
import { ReferenceFrame } from "../../Motion6D/ReferenceFrame";
import { Game3DPerformer } from "../Game3DPerformer";

export class ReferenceFrameGameAction extends AbstractGameAction
    implements ISceneObjectActionHolder {
    constructor(frame: IReferenceFrame, name: string, factory: IFactory | undefined) {
        super(name, factory)
        this.typeName = "ReferenceFrameGameAction"
        this.types.push("ISceneObjectActionHolder")
        this.types.push("ReferenceFrameGameAction")
        this.frame = frame
    }
    getSceneObjectAction(): ISceneObjectAction {
        return this.holder
    }

    protected createHolder(obj: ISceneObject) {
        this.holder = new RotationAction(obj, this.frame)
    }
  
    frame !: IReferenceFrame;

    holder !: ISceneObjectAction

    mPerformer: Game3DPerformer = new Game3DPerformer()

    functT(s: ISceneObject): IAction | undefined {
        this.createHolder(s)
        return this.getSceneObjectAction()
    }
}

class RotationAction extends AbstractSceneGameAction  {
    baseFrame !: ReferenceFrame
    target !: ReferenceFrame
    relative: ReferenceFrame = new ReferenceFrame()
    motionPerformer: Game3DPerformer = new Game3DPerformer()
    constructor(object: ISceneObject, frame: IReferenceFrame | undefined) {
        super(object, object.getConsumerFactory())
        this.typeName = "RotationAction"
        this.types.push("RotationAction")
        this.object = object;
        if (frame != undefined) {
            var fr = this.motionPerformer.getOwnFrame(frame)
            if (fr != undefined) this.baseFrame = fr
        }
        var bf = this.motionPerformer.getOwnFrame(object)
        if (bf != undefined) this.target = bf

    }

    action(): void {
        this.motionPerformer.getRelativeFrame(this.baseFrame, this.target, this.relative)
    }

    isEmptyAction(): boolean {
        return (this.baseFrame == undefined) || (this.target == undefined)
    }
    getActionSceneAdditionalObject(): IObject | undefined {
        return this.relative
    }
}
