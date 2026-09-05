"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EngineTimerProvider = void 0;
const OwnNotImplemented_1 = require("../../ErrorHandler/OwnNotImplemented");
const PerformerEvents_1 = require("../PerformerEvents");
class EngineTimerProvider {
    constructor(playEngine) {
        this.timeScale = 1;
        this.currentTime = 0;
        this.playEngine = playEngine;
        playEngine.getEngineAction().addActionT(this);
        this.timeScale = PerformerEvents_1.PerformerEvents.getTimeScale();
    }
    actionT(t) {
        this.currentTime = t * this.timeScale;
    }
    isEmptyActionT() { return false; }
    getTimeMeasurement() {
        return this;
    }
    getTime() {
        return this.currentTime;
    }
    setTime(time) {
        this.currentTime = time;
    }
    getStep() {
        throw new OwnNotImplemented_1.OwnNotImplemented("getStep ENGINE");
    }
    setStep(time) {
        this.currentTime = time;
    }
    getMeasurementName() {
        return "Time";
    }
    getMeasurementType() {
        return 0;
    }
    getMeasurementValue() {
        return this.currentTime;
    }
}
exports.EngineTimerProvider = EngineTimerProvider;
//# sourceMappingURL=EngineTimerProvider.js.map