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
        this.typeName = "VectorFormulaConsumer";
        this.types.push("VectorFormulaConsumer");
        this.types.push("IPostSetArrow");
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
    setFeedback() {
    }
    postSetArrow() {
        this.init();
        this.setFeedback();
    }
    feedback;
}
exports.VectorFormulaConsumer = VectorFormulaConsumer;
