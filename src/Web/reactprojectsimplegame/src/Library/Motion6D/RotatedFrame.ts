
import type{ IAngularVelocityMotion6D } from "./Interfaces/IAngularVelocityMotion6D";
import { ReferenceFrame } from "./ReferenceFrame";

export class RotatedFrame extends ReferenceFrame implements IAngularVelocityMotion6D
{
    constructor() {
        super();
        this.typeName = "RotatedFrame";
        this.types.push("IAngularVelocityMotion6D")
        this.types.push("RotatedFrame")

    }

    protected omega: number[] = [0, 0, 0];
    getOmega(): number[] {
        return this.omega;
    }

    public setReferenceFrame(baseFrame: ReferenceFrame, relative: ReferenceFrame): void {
        super.setReferenceFrame(baseFrame, relative);
        let ab = this.performer.convertObject<IAngularVelocityMotion6D, ReferenceFrame>(baseFrame, "IAngularVelocityMotion6D");
        let ar = this.performer.convertObject<IAngularVelocityMotion6D, ReferenceFrame>(relative, "IAngularVelocityMotion6D");
        let matrix = relative.getMatrix();
        let ob = ab[0].getOmega();
        let or = ar[0].getOmega();
        for (let i = 0; i < or.length; i++) {
            this.omega[i] = or[i];
            for (let j = 0; j < 3; j++) {
                this.omega[i] += matrix[i][j] * ob[j];
            }
        }
    }

}
