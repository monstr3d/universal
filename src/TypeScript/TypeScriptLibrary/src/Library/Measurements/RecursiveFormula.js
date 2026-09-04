"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.RecursiveFormula = void 0;
const DataConsumerVariableMeasurementsStarted_1 = require("./DataConsumerVariableMeasurementsStarted");
const Performer_1 = require("../Performer");
const FeedbackAliasCollection_1 = require("./FeedBack/FeedbackAliasCollection");
class RecursiveFormula extends DataConsumerVariableMeasurementsStarted_1.DataConsumerVariableMeasurementsStarted {
    inputs = [];
    arguments = [];
    running = false;
    //  protected initial: Map<string, any> = new Map();
    operationNames = new Map();
    performer = new Performer_1.Performer();
    constructor(desktop, name) {
        super(desktop, name);
        this.typeName = "RecursiveFormula";
        this.types.push("IPostSetArrow");
        this.types.push("IRunning");
        this.types.push("RecursiveFormula");
    }
    setRunning(running) {
        if (running === this.running)
            return;
        this.running = running;
        if (!running)
            return;
        this.initial.resetInitialValues();
        this.feedback.setFeedbacks();
    }
    getRunning() {
        return this.running;
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
        this.fictiveStart = start;
        this.initial.resetInitialValues();
        this.feedback.setFeedbacks();
    }
    fictiveStart = 0;
    updateMeasurements() {
        //this.performer.updateFeedbackData(this, this.feedback)
        this.calculateTree();
        this.save();
        this.feedback.setFeedbacks();
        this.show?.show(this);
    }
}
exports.RecursiveFormula = RecursiveFormula;
