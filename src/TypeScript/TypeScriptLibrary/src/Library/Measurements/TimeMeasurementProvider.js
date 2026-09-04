"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TimeMeasurementProvider = void 0;
class TimeMeasurementProvider {
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
        this.step = time;
    }
    getTime() {
        return this.time;
    }
    time = 0;
    step = 0;
}
exports.TimeMeasurementProvider = TimeMeasurementProvider;
