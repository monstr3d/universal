import { NumberMeasurement } from "../../Measurements/NumberMeasurement";
import { EulerAngles } from "../../Vector3D/EulerAngles";

export class EulerMeasurement extends NumberMeasurement {
    protected angles: EulerAngles = new EulerAngles(0, 0, 0);
    constructor(name: string, angles: EulerAngles) {
        super(name)
        this.angles = angles
    }

    public getRoll(name: string, angles: EulerAngles) {
        return new RollMeasurement(name, angles)
    }

    public getPitch(name: string, angles: EulerAngles) {
        return new PitchMeasurement(name, angles)
    }

    public getYaw(name: string, angles: EulerAngles) {
        return new YawMeasurement(name, angles)
    }

}

class RollMeasurement extends EulerMeasurement {
    constructor(name: string, angles: EulerAngles) {
        super(name, angles)
    }

    getMeasurementValue() {
        return this.angles.getRoll();
    }
}

class PitchMeasurement extends EulerMeasurement {
    constructor(name: string, angles: EulerAngles) {
        super(name, angles)
    }

    getMeasurementValue() {
        return this.angles.getPitch()
    }
}

class YawMeasurement extends EulerMeasurement {
    constructor(name: string, angles: EulerAngles) {
        super(name, angles)
    }

    getMeasurementValue() {
        return this.angles.getYaw();
    }

}