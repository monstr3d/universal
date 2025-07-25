"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Recursive = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
const DataConsumerMeasurements_1 = require("./DataConsumerMeasurements");
class Recursive extends DataConsumerMeasurements_1.DataConsumerMeasurements {
    constructor(desktop, name) {
        super(desktop, name);
        this.inputs = [];
        this.typeName = "Recursive";
        this.types.push("ISarted");
        this.types.push("IPostSetArrow");
        this.types.push("Recursive");
    }
    startedStart(start) {
        throw new OwnNotImplemented_1.OwnNotImplemented();
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
}
exports.Recursive = Recursive;
//# sourceMappingURL=Recursive.js.map