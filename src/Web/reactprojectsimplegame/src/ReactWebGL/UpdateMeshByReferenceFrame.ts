import type { IReferenceFrame } from "../Library/Motion6D/Interfaces/IReferenceFrame";
import type { IUpdateRef } from "./Interfaces/IUpdateRef";
import { Motion6DPerformer } from "../Library/Motion6D/Motion6DPerformer";
import { ReferenceFrame } from "../Library/Motion6D/ReferenceFrame";

export class UpdateMeshByReferenceFrame implements IUpdateRef {

    mp: Motion6DPerformer = new Motion6DPerformer
    frame!: IReferenceFrame
    rf !: ReferenceFrame
    i: number = 0
    constructor(frame: IReferenceFrame) {
        this.frame = frame
        let r = frame.getOwnFrame()
        console.log(r, "F")
        if (r === undefined) return
        this.rf = r
    }
    updateRef(m: React.MutableRefObject<undefined>): void {
        if (m.current === undefined) return
        try {
            let r = this.rf
            let c = r.getPosition()
            m.current.position.x = c[0]
            m.current.position.y = c[1]
            m.current.position.z = c[2]
            if (c[0] != 0) console.log(c)
            let q = r.getQuaternion()
            m.current.quaternion.w = q[3]
            m.current.quaternion.x = q[0]
            m.current.quaternion.y = q[1]
            m.current.quaternion.z = q[2]
        }
        catch (e) {
            if (this.i < 10) {
                console.log(e)
                ++this.i
            }
        }

    }

}