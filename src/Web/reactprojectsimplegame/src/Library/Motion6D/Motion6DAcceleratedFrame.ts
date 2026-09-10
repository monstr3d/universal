import type { IAcceleration } from "./Interfaces/IAcceleration";
import type { IAngularAcceleration } from "./Interfaces/IAngularAcceleration";
import type { IAngularVelocityMotion6D } from "./Interfaces/IAngularVelocityMotion6D";
import type { IVelocity } from "./Interfaces/IVelocity";
import { Motion6DFrame } from "./Motion6DFrame";
import { ReferenceFrame } from "./ReferenceFrame";

export class Motion6DAcceleratedFrame extends Motion6DFrame implements IAcceleration, IAngularAcceleration {
    protected relativeAcceleration: number[] = [0, 0, 0];

    protected acceleration: number[] = [0, 0, 0];

    protected angularAcceleration: number[] = [0, 0, 0];

    protected temp: number[] = [0, 0, 0];

    protected tempV: number[] = [0, 0, 0]


    constructor() {
        super();
        this.typeName = "Motion6DAcceleratedFrame";
        this.types.push("IAcceleration")
        this.types.push("IAngularAcceleration")
        this.types.push("Motion6DAcceleratedFrame")

    }


    public setReferenceFrame(baseFrame: ReferenceFrame, relative: ReferenceFrame): void {
        super.setReferenceFrame(baseFrame, relative)
        let arn = this.performer.convertObject<IAngularAcceleration, ReferenceFrame>(relative, " IAngularAcceleration")
        let relativeVelocity = this.performer.convertObject<IVelocity, ReferenceFrame>(relative, "IVelocity")
        let baseAngulatVelocity = this.performer.convertObject<IAngularVelocityMotion6D, ReferenceFrame>(baseFrame, "IAngularVelocityMotion6D")
        let relativeAngularVelocity = this.performer.convertObject<IAngularVelocityMotion6D, ReferenceFrame>(relative, "IAngularVelocityMotion6D")
        var rp = this.getPosition();
        let m = this.getMatrix();
        let relativeOmega = relativeAngularVelocity[0].getOmega();
        let baseOmega = baseAngulatVelocity[0].getOmega();
        this.vp.vectorProduct(baseOmega, relativeVelocity[0].getVelocity(), this.tempV);
        let om2 = this.vp.square3d(baseOmega);
        let eps = arn[0].getAngularAcceleration();
        this.vp.vectorProduct(eps, rp, this.temp);
        for (let i = 0; i < 3; i++) {
            this.tempV[i] *= 2;
            this.tempV[i] += om2 * rp[i] + this.relativeAcceleration[i] + this.temp[i];
        }
        this.realMatrix.multiplyRight(m, this.tempV, this.acceleration);
        var relativeOrientation = relative;
        var relativeMatrix = relativeOrientation.getMatrix();
        this.realMatrix.multiplyLeft(baseOmega, relativeMatrix, this.temp);
        this.vp.vectorProduct(this.temp, relativeOmega, this.tempV);
        for (let i = 0; i < 3; i++) {
            this.temp[i] = eps[i] + this.tempV[i];
        }
        this.realMatrix.multiplyLeft(this.temp, m, this.angularAcceleration);

    }


    getAngularAcceleration(): number[] {
        return this.angularAcceleration;
    }
    getLineraAcceleration(): number[] {
        return this.acceleration; ;
    }
    getRelativeAcceleration(): number[] {
        return this.relativeAcceleration;
    }


}