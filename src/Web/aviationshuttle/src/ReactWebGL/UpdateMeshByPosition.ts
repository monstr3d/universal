import type { IUpdateRef } from "./Interfaces/IUpdateRef";
import type { IPosition } from "../Library/Motion6D/Interfaces/IPosition";
import { Motion6DPerformer } from "../Library/Motion6D/Motion6DPerformer";
import { ReferenceFrame } from "../Library/Motion6D/ReferenceFrame";
import { RealMatrix } from "../Library/RealMatrixProcessor/RealMatrix";

export class UpdateMeshByPosition implements IUpdateRef {
    rmat: RealMatrix = new RealMatrix()
    mp: Motion6DPerformer = new Motion6DPerformer
    postition !: IPosition
    rf !: ReferenceFrame
    rb: ReferenceFrame = new ReferenceFrame()
    rr: ReferenceFrame = new ReferenceFrame()
    i: number = 0
    aux: number[] = [0, 0, 0]
    constructor(postition: IPosition) {
        this.postition = postition
        let r = this.mp.getOwnFrame(postition)
        if (r === undefined) return
        this.rf = r
    }

    updateRef(m: React.MutableRefObject<undefined>): void {
        if (m.current === undefined) return
        try {
            this.rr.setReferenceFrame(this.rb, this.rf)
            let mt = this.rr.getMatrix();
            let c = this.postition.getPosition();
            this.rmat.multiplyRight(mt, c, this.aux)
            let d = this.rr.getPosition()
            for (let i = 0; i < 3; i++) {
                this.aux[i] += d[i]
            }
            m.current.position.x = this.aux[0]
            m.current.position.y = this.aux[1]
            m.current.position.z = this.aux[2]
            let q = this.rr.getQuaternion()
            m.current.quaternion.w = q[3]
            m.current.quaternion.x = q[0]
            m.current.quaternion.y = q[1]
            m.current.quaternion.z = q[2]
        }
        catch (e) {
        }
    }

}