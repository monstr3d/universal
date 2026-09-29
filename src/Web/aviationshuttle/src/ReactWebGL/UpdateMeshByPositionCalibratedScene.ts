import { IPosition } from "../Library/Motion6D/Interfaces/IPosition";
import { UpdateMeshByPositionCalibrated } from "./UpdateMeshByPositionCalibrated";

export class UpdateMeshByPositionCalibratedScene extends UpdateMeshByPositionCalibrated {
    constructor(postition: IPosition, x: number, y: number, z: number, scale: number) {
        super(postition, x, y, z, scale)
    }


    updateRef(m: React.MutableRefObject<undefined>): void {
        if (!this.preUpdate(m)) return
        if (m.current === undefined) return
        m.current.scene.position.x = this.aux[0]
        m.current.scene.position.y = this.aux[1]
        m.current.scene.position.z = this.aux[2]
        let q = this.r.getQuaternion()
        m.current.scene.quaternion.w = q[0]
        m.current.scene.quaternion.x = q[1]
        m.current.scene.quaternion.y = q[2]
        m.current.scene.quaternion.z = q[3]
    }


}