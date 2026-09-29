import type { IUpdateRef } from "./Interfaces/IUpdateRef";
import type { IPosition } from "../Library/Motion6D/Interfaces/IPosition";
import { Motion6DPerformer } from "../Library/Motion6D/Motion6DPerformer";
import { ReferenceFrame } from "../Library/Motion6D/ReferenceFrame";
import { RealMatrix } from "../Library/RealMatrixProcessor/RealMatrix";
import { Vector3DProcessor } from "../Library/Vector3D/Vector3DProcessor";

export class UpdateMeshByPositionCalibrated implements IUpdateRef {

    protected rmat: RealMatrix = new RealMatrix()
    protected  mp: Motion6DPerformer = new Motion6DPerformer
    protected postition !: IPosition
    protected i: number = 0
    protected aux: number[] = [0, 0, 0]
    protected a: number[] = [0, 0, 0]
    protected x: number = 0;
    protected y: number = 0;
    protected z: number = 0;
    protected scale: number = 0;
    protected r !: ReferenceFrame

    protected processor: Vector3DProcessor = new Vector3DProcessor
    constructor(postition: IPosition, x: number, y: number, z: number, scale: number) {
        this.x = x
        this.y = y
        this.z = z
        this.a = [x, y, z]
        this.scale = scale
        this.postition = postition
    }

    protected preUpdate(m: React.MutableRefObject<undefined>): boolean
    {
        if (m.current === undefined) return false
        let r = this.mp.getOwnFrame(this.postition)
        if (r === undefined) return false
        this.r = r
        let x = r.getPosition()
        for (let i = 0; i < 3; i++) {
            this.aux[i] = this.scale * x[i]
            this.aux[i] += this.a[i]
        }
        return true

    }


    updateRef(m: React.MutableRefObject<undefined>): void {
        if (!this.preUpdate(m)) return
        if (m.current === undefined) return
        m.current.position.x = this.aux[0]
        m.current.position.y = this.aux[1]
        m.current.position.z = this.aux[2]
        let q = this.r.getQuaternion()
        m.current.quaternion.w = q[0]
        m.current.quaternion.x = q[1]
        m.current.quaternion.y = q[2]
        m.current.quaternion.z = q[3]
    }

}