"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.RecursiveFormula = void 0;
const DataConsumerVariableMeasurementsStarted_1 = require("./DataConsumerVariableMeasurementsStarted");
const FeedbackAliasCollection_1 = require("../FeedbackAliasCollection");
const Performer_1 = require("../Performer");
class RecursiveFormula extends DataConsumerVariableMeasurementsStarted_1.DataConsumerVariableMeasurementsStarted {
    constructor(desktop, name) {
        super(desktop, name);
        this.inputs = [];
        this.arguments = [];
        //  protected initial: Map<string, any> = new Map();
        this.operationNames = new Map();
        this.performer = new Performer_1.Performer();
        this.typeName = "RecursiveFormula";
        this.types.push("IPostSetArrow");
        this.types.push("RecursiveFormula");
    }
    init() {
    }
    setFeedback() {
        let map = new Map();
        this.feedback = new FeedbackAliasCollection_1.FeedbackAliasCollection(map, this, this);
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
        //this.performer.updateFeedbackData(this, this.feedback)
        this.calculateTree();
        this.save();
        this.feedback.setFeedbacks();
    }
}
exports.RecursiveFormula = RecursiveFormula;
//# sourceMappingURL=RecursiveFormula.js.map