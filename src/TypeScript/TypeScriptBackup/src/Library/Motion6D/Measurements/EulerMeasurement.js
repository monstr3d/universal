"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EulerMeasurement = void 0;
const NumberMeasurement_1 = require("../../Measurements/NumberMeasurement");
const EulerAngles_1 = require("../../Vector3D/EulerAngles");
class EulerMeasurement extends NumberMeasurement_1.NumberMeasurement {
    constructor(name, angles) {
        super(name);
        this.angles = new EulerAngles_1.EulerAngles(0, 0, 0);
        this.angles = angles;
    }
    getRoll(name, angles) {
        return new RollMeasurement(name, angles);
    }
    getPitch(name, angles) {
        return new PitchMeasurement(name, angles);
    }
    getYaw(name, angles) {
        return new YawMeasurement(name, angles);
    }
}
exports.EulerMeasurement = EulerMeasurement;
class RollMeasurement extends EulerMeasurement {
    constructor(name, angles) {
        super(name, angles);
    }
    getMeasurementValue() {
        return this.angles.getRoll();
    }
}
class PitchMeasurement extends EulerMeasurement {
    constructor(name, angles) {
        super(name, angles);
    }
    getMeasurementValue() {
        return this.angles.getPitch();
    }
}
class YawMeasurement extends EulerMeasurement {
    constructor(name, angles) {
        super(name, angles);
    }
    getMeasurementValue() {
        return this.angles.getYaw();
    }
}
//# sourceMappingURL=EulerMeasurement.js.map