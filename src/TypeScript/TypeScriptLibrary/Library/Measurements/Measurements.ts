import { CategoryObject } from "../CategoryObject";
import { IDesktop } from "../Interfaces/IDesktop";
import { IMeasurement } from "./Interfaces/IMeasurement";
import { IMeasurements } from "./Interfaces/IMeasurements";

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