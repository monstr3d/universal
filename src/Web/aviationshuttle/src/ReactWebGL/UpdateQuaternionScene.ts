import { Quaternion } from "../Library/Vector3D/Quaternion";
import { Vector3DProcessor } from "../Library/Vector3D/Vector3DProcessor";
import { UpdateMeshByPositionCalibrated } from "./UpdateMeshByPositionCalibrated";
import type { IPosition } from "../Library/Motion6D/Interfaces/IPosition";

export class UpdateQuaternionScene extends UpdateMeshByPositionCalibrated { 

    protected auxQuaternion: Quaternion = new Quaternion

    protected quaternion: Quaternion = new Quaternion

    protected qq: Quaternion = new Quaternion


    constructor(postition: IPosition, x: number, y: number, z: number, scale: number, quaternion: Quaternion) {
        super(postition, x, y, z, scale)
        this.quaternion = quaternion;
        this.processor.quaternionNormalizeQ(this.quaternion)
    }

    b: boolean = true

    protected preUpdate(m: React.MutableRefObject<undefined>): boolean {
        if (m.current === undefined) return false
        let r = this.mp.getOwnFrame(this.postition)
        if (r === undefined) return false
        this.r = r
        let x = r.getPosition()
        for (let i = 0; i < 3; i++) {
            this.aux[i] = this.scale * x[i]
            this.aux[i] += this.a[i]
        }
        let q = r.getQuaternion()
        this.qq.W = q[0]
        this.qq.X = q[1]
        this.qq.Y = q[2]
        this.qq.Z = q[3]
        this.processor.quaternionMultiplyQ(this.qq, this.quaternion, this.auxQuaternion)
        return true
    }


    updateRef(m: React.MutableRefObject<undefined>): void {

        if (!this.preUpdate(m)) return
        if (m.current === undefined) return
        m.current.position.x = this.aux[0]
        m.current.position.y = this.aux[1]
        m.current.position.z = this.aux[2]
        let q = this.auxQuaternion
        m.current.quaternion.w = q.W
        m.current.quaternion.x = q.Z
        m.current.quaternion.y = q.Y
        m.current.quaternion.z = q.X
    }

}
