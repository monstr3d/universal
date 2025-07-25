"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Measurements = void 0;
const CategoryObject_1 = require("../CategoryObject");
class Measurements extends CategoryObject_1.CategoryObject {
    constructor(desktop, name) {
        super(desktop, name);
        this.measurements = [];
        this.types.push("IMeasurements");
        this.types.push("Measurements");
    }
    addMeasurement(measurement) {
        this.measurements.push(measurement);
    }
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
//# sourceMappingURL=Measurements.js.map