"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Measurement = void 0;
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
class Measurement {
    name = "";
    type;
    constructor(name, type) {
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
        throw new OwnNotImplemented_1.OwnNotImplemented("Measurement");
    }
}
exports.Measurement = Measurement;
