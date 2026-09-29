import type { IVelocity } from "./Interfaces/IVelocity";
import { ReferenceFrame } from "./ReferenceFrame";

export class MovedFrame extends ReferenceFrame implements IVelocity {
    getVelocity(): number[] {
        return this.velocity;
    }
    protected velocity: number[] = [0, 0, 0] 

}