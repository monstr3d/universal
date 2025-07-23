"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Recursive = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
const Measurements_1 = require("./Measurements");
class Recursive extends Measurements_1.Measurements {
    constructor(desktop, name) {
        super(desktop, name);
        this.inputs = [];
    }
    postSetArrow() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    getAllMeasurements() {
        return this.inputs;
    }
    addMeasurements(item) {
        this.inputs.push(item);
    }
    PostSetArrow() {
        try {
            throw new OwnNotImplemented_1.OwnNotImplemented();
        }
        catch (e) { }
    }
}
exports.Recursive = Recursive;
//# sourceMappingURL=Recursive.js.map