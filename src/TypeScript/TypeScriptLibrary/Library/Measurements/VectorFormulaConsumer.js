"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.VectorFormulaConsumer = void 0;
const DataConsumerVariableMeasurements_1 = require("./DataConsumerVariableMeasurements");
class VectorFormulaConsumer extends DataConsumerVariableMeasurements_1.DataConsumerVariableMeasurements {
    //  protected arguments: string[] = [];
    //   protected operationNames: Map<number, string> = new Map();
    constructor(desktop, name) {
        super(desktop, name);
        this.typeName = "VectorFormulaConsumer";
        this.types.push("VectorFormulaConsumer");
        this.types.push("IPostSetArrow");
    }
    updateMeasurements() {
        this.feedback.setFeedbacks();
        this.calculateTree();
        this.save();
    }
    calculateTree() {
    }
    init() {
    }
    save() {
    }
    postSetArrow() {
        this.init();
        this.setFeedback();
    }
}
exports.VectorFormulaConsumer = VectorFormulaConsumer;
//# sourceMappingURL=VectorFormulaConsumer.js.map