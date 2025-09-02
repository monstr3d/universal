"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FictiveMeasurement = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
class FictiveMeasurement {
    getMeasurementName() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    getMeasurementType() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    getMeasurementValue() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
}
exports.FictiveMeasurement = FictiveMeasurement;
//# sourceMappingURL=FictiveMeasurement.js.map