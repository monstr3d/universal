"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RecursiveFormula = void 0;
const DataConsumerVariableMeasurementsStarted_1 = require("./DataConsumerVariableMeasurementsStarted");
class RecursiveFormula extends DataConsumerVariableMeasurementsStarted_1.DataConsumerVariableMeasurementsStarted {
    constructor(desktop, name) {
        super(desktop, name);
        this.inputs = [];
        this.arguments = [];
        //  protected initial: Map<string, any> = new Map();
        this.operationNames = new Map();
        this.typeName = "RecursiveFormula";
        this.types.push("IPostSetArrow");
        this.types.push("RecursiveFormula");
    }
    init() {
    }
    postSetArrow() {
        this.init();
        this.setInitial();
        this.setFeedback();
    }
    getAllMeasurements() {
        return this.inputs;
    }
    addMeasurements(item) {
        this.inputs.push(item);
    }
    calculateTree() {
    }
    save() {
    }
    startedStart(start) {
        this.initial.resetInitialValues();
        this.feedback.setFeedbacks();
    }
    updateMeasurements() {
        this.feedback.setFeedbacks();
        this.calculateTree();
        this.save();
    }
}
exports.RecursiveFormula = RecursiveFormula;
//# sourceMappingURL=RecursiveFormula.js.map