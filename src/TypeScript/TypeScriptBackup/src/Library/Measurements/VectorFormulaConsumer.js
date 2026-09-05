"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.VectorFormulaConsumer = void 0;
const DataConsumerVariableMeasurements_1 = require("./DataConsumerVariableMeasurements");
class VectorFormulaConsumer extends DataConsumerVariableMeasurements_1.DataConsumerVariableMeasurements {
    constructor(desktop, name) {
        super(desktop, name);
        this.isRunning = false;
        this.typeName = "VectorFormulaConsumer";
        this.types.push("VectorFormulaConsumer");
        this.types.push("IPostSetArrow");
        this.types.push("IRunning");
        this.types.push("IPrintedObject");
    }
    setRunning(running) {
        this.isRunning = running;
        this.reset();
    }
    getRunning() {
        return this.isRunning;
    }
    updateMeasurements() {
        this.calculateTree();
        this.save();
        this.feedback?.setFeedbacks();
    }
    calculateTree() {
    }
    init() {
    }
    save() {
    }
    reset() {
    }
    setFeedback() {
    }
    postSetArrow() {
        this.init();
        this.setFeedback();
    }
}
exports.VectorFormulaConsumer = VectorFormulaConsumer;
//# sourceMappingURL=VectorFormulaConsumer.js.map