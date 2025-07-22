import { CategoryObject } from "../CategoryObject";
import { IDesktop } from "../IDesktop";
import { IMeasurement } from "./IMeasurement";
import { IMeasurements } from "./IMeasurements";

export class Measurements extends CategoryObject  implements IMeasurements
{
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);

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