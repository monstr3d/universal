"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RandomGenerator = void 0;
const Measurements_1 = require("./Measurements");
class RandomGenerator extends Measurements_1.Measurements {
    constructor(desktop, name) {
        super(desktop, name);
        this.a = 0;
        this.value = 0;
        this.measurements.push(this);
        this.types.push("IMeasurement");
        this.types.push("RandomGenerator");
        this.measurements.push(this);
    }
    getMeasurementName() {
        return "Random";
    }
    getMeasurementType() {
        return this.a;
    }
    getMeasurementValue() {
        return this.value;
    }
    updateMeasurements() {
        this.value = Math.random();
    }
}
exports.RandomGenerator = RandomGenerator;
//# sourceMappingURL=RandomGenerator.js.map