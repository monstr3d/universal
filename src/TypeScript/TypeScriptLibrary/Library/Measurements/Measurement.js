"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Measurement = void 0;
class Measurement {
    constructor(name, type, operation) {
        this.name = "";
        this.type = undefined;
        this.name = name;
        this.type = type;
        this.operation = operation;
    }
    getName() {
        return this.name;
    }
    getType() {
        return this.type;
    }
    getOperation() {
        return this.operation;
    }
}
exports.Measurement = Measurement;
//# sourceMappingURL=Measurement.js.map