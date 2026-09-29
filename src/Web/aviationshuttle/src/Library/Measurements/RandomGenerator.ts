/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

import type { IDesktop } from "../Interfaces/IDesktop";
import type { IMeasurement } from "./Interfaces/IMeasurement";
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
        this.measurements.push(this);
    }
    getMeasurementName(): string {
        return "Random";
    }
    getMeasurementType() : any {
        return this.a;
    }
  
    getMeasurementValue() : any {
        return this.value;
    }


    updateMeasurements(): void {
        this.value = Math.random();
    }

}