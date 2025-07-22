"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Measurement = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
class Measurement {
    constructor(name, type) {
        this.name = "";
        this.name = name;
        this.type = type;
    }
    getName() {
        return this.name;
    }
    getType() {
        return this.type;
    }
    getMeasurementValue() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
        ;
    }
}
exports.Measurement = Measurement;
//# sourceMappingURL=Measurement.js.map