import { IDesktop } from "../Interfaces/IDesktop";
import { IMeasurement } from "./Interfaces/IMeasurement";
import { Measurements } from "./Measurements";

export class RandomGenerator extends Measurements implements IMeasurement
{

    a: number = 0;

    value: number = 0;
    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);
        this.measurements.push(this);
        this.types.push("IMeasurement");
        this.types.push("RandomGenerator");
    }
    getType() {
        return this.a;
    }
    getMeasurementValue() {
        return this.value;
    }


    updateMeasurements(): void {
        this.value = Math.random();
    }

}