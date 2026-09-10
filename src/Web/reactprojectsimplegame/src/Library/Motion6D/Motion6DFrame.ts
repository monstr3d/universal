import type { IAngularVelocityMotion6D } from "./Interfaces/IAngularVelocityMotion6D";
import type { IVelocity } from "./Interfaces/IVelocity";
import { ReferenceFrame } from "./ReferenceFrame";
import { RotatedFrame } from "./RotatedFrame";

export class Motion6DFrame extends RotatedFrame implements IVelocity
{

    protected velocity: number[] = [0, 0, 0] 
    protected hv: number[] = [0, 0, 0] 

        //protected double[] relativeVelocity = new double[] { 0, 0, 0 };

        /// <summary>
        /// Derivation
        /// </summary>
    protected der: number[] = [0, 0, 0, 0] 

        /// <summary>
        /// Quaternion derivation
        /// </summary>
    protected qd: number[] = [0, 0, 0, 0] 





    constructor() {
        super();
        this.typeName = "Motion6DFrame";
        this.types.push("IVelocity")
        this.types.push("Motion6DFrame")

    }


    getVelocity(): number[] {
        return this.velocity;
    }

    //         let ab = this.performer.convertObject<IAngularVelocityMotion6D, ReferenceFrame>(baseFrame, "IAngularVelocityMotion6D");


    public setReferenceFrame(baseFrame: ReferenceFrame, relative: ReferenceFrame): void {
        super.setReferenceFrame(baseFrame, relative);
        let baseOrientation = baseFrame;
        let baseVelocity = this.performer.convertObject<IVelocity, ReferenceFrame>(baseFrame, "IVelocity")
        let relativeVelocity = this.performer.convertObject<IVelocity, ReferenceFrame>(relative, "IVelocity")
        let baseAngular = this.performer.convertObject<IAngularVelocityMotion6D, ReferenceFrame>(baseFrame, "IAngularVelocityMotion6D")
       // let ra = this.performer.convertObject<IAngularVelocityMotion6D, ReferenceFrame>(relative, "IAngularVelocityMotion6D")
        let velocityBase = baseVelocity[0].getVelocity();
        let velocityRelative = relativeVelocity[0].getVelocity();
        let mb = baseOrientation.getMatrix();
        let om = baseAngular[0].getOmega();
        let pos = relative.getPosition();
        this.vp.vectorProduct(om, pos, this.hv);
        for (let i = 0; i < 3; i++)
        {
            this.velocity[i] = velocityBase[i];
            for (let j = 0; j < 3; j++)
            {
                this.velocity[i] += mb[i][ j] * (velocityRelative[j] + this.hv[j]);
            }
        }

    }



}