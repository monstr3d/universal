"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Measurements = void 0;
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
const CategoryObject_1 = require("../CategoryObject");
class Measurements extends CategoryObject_1.CategoryObject {
    constructor(desktop, name) {
        super(desktop, name);
        this.types.push("IMeasurements");
        this.types.push("Measurements");
    }
    addMeasurement(measurement) {
        this.measurements.push(measurement);
    }
    measurements = [];
    getMeasurementsCount() {
        return this.measurements.length;
    }
    getMeasurement(i) {
        return this.measurements[i];
    }
    updateMeasurements() {
    }
}
exports.Measurements = Measurements;
