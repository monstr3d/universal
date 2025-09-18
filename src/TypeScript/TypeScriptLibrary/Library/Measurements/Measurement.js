"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Measurement = void 0;
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
class Measurement {
    constructor(name, type) {
        this.name = "";
        this.name = name;
        this.type = type;
    }
    getMeasurementName() {
        return this.name;
    }
    getMeasurementType() {
        return this.type;
    }
    getMeasurementValue() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
        ;
    }
}
exports.Measurement = Measurement;
//# sourceMappingURL=Measurement.js.map