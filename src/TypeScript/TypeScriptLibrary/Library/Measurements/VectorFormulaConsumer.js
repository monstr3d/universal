"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.VectorFormulaConsumer = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
const DataConsumerMeasurements_1 = require("./DataConsumerMeasurements");
class VectorFormulaConsumer extends DataConsumerMeasurements_1.DataConsumerMeasurements {
    //    protected parameters: Map<string, any> = new Map();
    constructor(desktop, name) {
        super(desktop, name);
        this.feedback = new Map();
        this.arguments = [];
        this.operationNames = new Map();
    }
    updateMeasurements() {
        this.calculateTree();
    }
    calculateTree() {
    }
    postSetArrow() {
        try {
            throw new OwnNotImplemented_1.OwnNotImplemented();
        }
        catch (e) { }
    }
}
exports.VectorFormulaConsumer = VectorFormulaConsumer;
//export default VectorFormulaConsumer;
//# sourceMappingURL=VectorFormulaConsumer.js.map