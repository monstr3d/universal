"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FictiveTimeMeasurementProvider = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
class FictiveTimeMeasurementProvider {
    getTimeMeasurement() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    getTime() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    setTime(time) {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    getStep() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    setStep(time) {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
}
exports.FictiveTimeMeasurementProvider = FictiveTimeMeasurementProvider;
//# sourceMappingURL=FictiveTimeMeasurementProvider.js.map