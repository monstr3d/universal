"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataConsumerVariableMeasurementsStarted = void 0;
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
const AliasInitialValueCollection_1 = require("../AliasInitialValueCollection.");
const DataConsumerVariableMeasurements_1 = require("./DataConsumerVariableMeasurements");
const FeedbackAliasCollection_1 = require("./FeedBack/FeedbackAliasCollection");
class DataConsumerVariableMeasurementsStarted extends DataConsumerVariableMeasurements_1.DataConsumerVariableMeasurements {
    initial;
    constructor(desktop, name) {
        super(desktop, name);
        this.typeName = "DataConsumerVariadbleMeasurementsStarted";
        this.types.push("IStarted");
        this.types.push("DataConsumerVariadbleMeasurementsStarted");
        this.alias = this;
    }
    getFeedbackCollection() {
        return this.feedback;
    }
    startedStart(start) {
        this.fictiveStart = start;
        this.initial.resetInitialValues();
    }
    fictiveStart = 0;
    setInitial() {
        this.initial = new AliasInitialValueCollection_1.AliasInitialValueCollection(this, this);
    }
    setFeedback() {
        let map = new Map();
        this.feedback = new FeedbackAliasCollection_1.FeedbackAliasCollection(map, this, this);
    }
    feedback;
}
exports.DataConsumerVariableMeasurementsStarted = DataConsumerVariableMeasurementsStarted;
