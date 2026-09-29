import { RealMatrix } from "../RealMatrixProcessor/RealMatrix";

export class Vector3Double {

    constructor(x: number[]) {
        this.copyFromArray(x, 0);
    }



    protected realMatrix: RealMatrix = new RealMatrix();


    protected x: number[] = [0, 0, 0];

    public copyFromArray(array: number[], offset: number): void {
        for (let i = 0; i < 3; i++) {
            this.x[i] = array[i + offset];
        }
    }

    public copyFrom(vector: Vector3Double): void {
        this.copyFromArray(vector.x, 0);
    }

    public getNorm(): number {
        return this.realMatrix.getNorm(this.x);
    }


}
