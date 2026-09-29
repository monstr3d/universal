import { Measurement } from "./Measurement";
import type { IDerivation } from "./Interfaces/IDerivation";
import type { IMeasurement } from "./Interfaces/IMeasurement";

export class MeasurementDerivation extends Measurement implements IDerivation
{
    measurement !: IMeasurement 
    derivation !: IMeasurement 

    constructor(measurement: IMeasurement, derivation: IMeasurement) {
        super(measurement.getMeasurementName(), measurement.getMeasurementType())
        this.measurement = measurement
        this.derivation = derivation;
    }
    getDerivation(): IMeasurement {
        return this.derivation;
    }

    setDerivation(derivation: IMeasurement): void {
        this.fderivation = derivation
    }

    fderivation!: IMeasurement

    getMeasurementValue() {
        return this.measurement.getMeasurementValue();
    }

}