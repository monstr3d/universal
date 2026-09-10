import type { IUpdateRef } from "./Interfaces/IUpdateRef";
import type { IPosition } from "../Library/Motion6D/Interfaces/IPosition";
import { Motion6DPerformer } from "../Library/Motion6D/Motion6DPerformer";
import { ReferenceFrame } from "../Library/Motion6D/ReferenceFrame";
import { RealMatrix } from "../Library/RealMatrixProcessor/RealMatrix";

export class UpdateMeshByPositionCalibrated implements IUpdateRef {
    rmat: RealMatrix = new RealMatrix()
    mp: Motion6DPerformer = new Motion6DPerformer
    postition !: IPosition
    i: number = 0
    aux: number[] = [0, 0, 0]
    a: number[] = [0, 0, 0]
    x: number = 0;
    y: number = 0;
    z: number = 0;
    scale: number = 0;
    constructor(postition: IPosition, x: number, y: number, z: number, scale: number) {
        this.x = x
        this.y = y
        this.z = z
        this.a = [x, y, z]
        this.scale = scale
        this.postition = postition
    }

    updateRef(m: React.MutableRefObject<undefined>): void {
        if (m.current === undefined) return
        try {
            let r = this.mp.getOwnFrame(this.postition)
            if (r === undefined) return
            let x = r.getPosition()
            for (let i = 0; i < 3; i++) {
                this.aux[i] = this.scale * x[i]
                this.aux[i] += this.a[i]
            }
            m.current.position.x = this.aux[0]
            m.current.position.y = this.aux[1]
            m.current.position.z = this.aux[2]
            let q = r.getQuaternion()
            m.current.quaternion.w = q[3]
            m.current.quaternion.x = q[0]
            m.current.quaternion.y = q[1]
            m.current.quaternion.z = q[2]
        }
        catch (e) {
        }
    }

}