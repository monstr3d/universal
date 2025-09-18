/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { CategoryObject } from "../CategoryObject";
import type { IDesktop } from "../Interfaces/IDesktop";
import type { IMeasurement } from "./Interfaces/IMeasurement";
import type { IMeasurements } from "./Interfaces/IMeasurements";

export class Measurements extends CategoryObject  implements IMeasurements
{
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.types.push("IMeasurements");
        this.types.push("Measurements");

    }
    addMeasurement(measurement: IMeasurement): void {
        this.measurements.push(measurement);
    }
    protected measurements: IMeasurement[] = [];
    getMeasurementsCount(): number
    {
        return this.measurements.length;
    }
    getMeasurement(i: number): IMeasurement
    {
        return this.measurements[i];
    }

    updateMeasurements(): void
    {
    }

}