"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TimeMeasurementProvider = void 0;
class TimeMeasurementProvider {
    constructor() {
        this.time = 0;
    }
    getMeasurementName() {
        return "Time";
    }
    getMeasurementType() {
        return 0;
    }
    getMeasurementValue() {
        return this.time;
    }
    getTimeMeasurement() {
        return this;
    }
    setTime(time) {
        this.time = time;
    }
    getStep() {
        return 0;
    }
    setStep(time) {
    }
    getTime() {
        return this.time;
    }
}
exports.TimeMeasurementProvider = TimeMeasurementProvider;
//# sourceMappingURL=TimeMeasurementProvider.js.map