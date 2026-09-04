"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.RandomGenerator = void 0;
const Measurements_1 = require("./Measurements");
class RandomGenerator extends Measurements_1.Measurements {
    a = 0;
    value = 0;
    constructor(desktop, name) {
        super(desktop, name);
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
