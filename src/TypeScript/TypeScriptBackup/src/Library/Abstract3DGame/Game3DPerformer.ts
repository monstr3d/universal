import type { IMeshHolder } from "../Abstract3DConverters/Interfaces/IMeshHolder";
import { GamePerformer } from "../Game/GamePerformer";
import type { ISceneObjectAction } from "../Game/Interfaces/ISceneObjectAction";
import type { IAssociatedObject } from "../Interfaces/IAssociatedObject";
import type { IObject } from "../Interfaces/IObject";
import type { IPosition } from "../Motion6D/Interfaces/IPosition";
import type { IPositionObject } from "../Motion6D/Interfaces/IPositionObject";
import { Motion6DPerformer } from "../Motion6D/Motion6DPerformer";
import { ReferenceFrame } from "../Motion6D/ReferenceFrame";
import type { IMeshFrame } from "./Interfaces/IMeshFrame";

export class Game3DPerformer extends GamePerformer
{
    pefrormer: Motion6DPerformer = new Motion6DPerformer()

    public getRelativeFrame(baseFrame: ReferenceFrame, targetFrame: ReferenceFrame, relative: ReferenceFrame) {
        this.pefrormer.getRelativeFrame(baseFrame, targetFrame, relative)
    }

    public detectMeshFrame(obj: IObject): IMeshFrame | undefined {
        let r = obj as unknown as ISceneObjectAction
        if (r === undefined) {
            return undefined
        }
        var o = r.getActionSceneObject()
        var mh = o as unknown as IMeshHolder
        if (mh != undefined) {
            var add = r.getActionSceneAdditionalObject()
            var rf = add as unknown as ReferenceFrame
            if (rf != undefined) {
                return { mesh: mh.getHolderMeshes(), frame: rf }
            }
        }
    }


    public setInvertedCoorfinates(x: number[], z: number[], frame: ReferenceFrame) {
        let m = frame.getMatrix()
        for (var i = 0; i < 3; i++) {
            x[i] = 0
            for (var j = 0; j < 3; j++) {
                x[i] += m[j][i] * z[j]
            }
        }
        let y = frame.getPosition();
        for (var i = 0; i < 3; i++) {
            x[i] -= y[i]
        }
    }


    public setInvertedCoorfinates2(xx: number[][], zz: number[][], frame: ReferenceFrame) {
        let m = frame.getMatrix()
        let y = frame.getPosition();
        for (var k = 0; k < xx.length; k++) {
            let x = xx[k]
            let z = zz[k]
            for (var i = 0; i < 3; i++) {
                x[i] = 0
                for (var j = 0; j < 3; j++) {
                    x[i] += m[j][i] * z[j]
                }
            }
            for (var i = 0; i < 3; i++) {
                x[i] -= y[i]
            }
        }

    }




    public getOwnFrame(object: IObject): ReferenceFrame | undefined {
        var pos = this.convertObject<IPosition, IObject>(object, "IPosition")
        if (pos.length > 0) {
            return this.pefrormer.getOwnFrame(pos[0])
        }
        var po = this.convertObject<IPositionObject, IObject>(object, "IPositionObject")
        if (po.length > 0) {
            var position = po[0].getObjectPosition()
            return this.pefrormer.getOwnFrame(position)
        }
        var ao = this.convertObject<IAssociatedObject, IObject>(object, "IAssociatedObject")
        {
            if (ao.length > 0)
                return this.getOwnFrame(ao[0].getAssociatedObject())
        }
        return undefined

    }


}