"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataConsumerVariableMeasurementsStarted = void 0;
const AliasInitialValueCollection_1 = require("../AliasInitialValueCollection.");
const FictionInitialValueCollection_1 = require("../Fiction/FictionInitialValueCollection");
const FictiveAlias_1 = require("../Fiction/FictiveAlias");
const DataConsumerVariableMeasurements_1 = require("./DataConsumerVariableMeasurements");
class DataConsumerVariableMeasurementsStarted extends DataConsumerVariableMeasurements_1.DataConsumerVariableMeasurements {
    constructor(desktop, name) {
        super(desktop, name);
        this.initial = new FictionInitialValueCollection_1.FictionInitialValueCollection();
        this.alias = new FictiveAlias_1.FictiveAlias();
        this.typeName = "DataConsumerVariadbleMeasurementsStarted";
        this.types.push("IStarted");
        this.types.push("DataConsumerVariadbleMeasurementsStarted");
        this.alias = this;
    }
    startedStart(start) {
        this.initial.resetInitialValues();
    }
    setInitial() {
        this.initial = new AliasInitialValueCollection_1.AliasInitialValueCollection(this, this);
    }
}
exports.DataConsumerVariableMeasurementsStarted = DataConsumerVariableMeasurementsStarted;
//# sourceMappingURL=DataConsumerVariableMeasurementsStarted.js.map