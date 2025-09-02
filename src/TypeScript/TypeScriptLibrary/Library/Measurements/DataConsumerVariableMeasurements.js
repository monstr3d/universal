"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataConsumerVariableMeasurements = void 0;
const FictiveFeedbackCollection_1 = require("../Fiction/FictiveFeedbackCollection");
const DataConsumer_1 = require("./DataConsumer");
const PefrormerMeasuremets_1 = require("./PefrormerMeasuremets");
const Variable_1 = require("./Variables/Variable");
class DataConsumerVariableMeasurements extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.output = [];
        this.variables = new Map();
        this.aliasTypes = new Map();
        this.aliasValues = new Map();
        this.aliasNames = [];
        this.pMeasurements = new PefrormerMeasuremets_1.PefrormerMeasuremets();
        this.feedback = new FictiveFeedbackCollection_1.FictiveFeedbackCollection();
        this.alias = this;
        this.typeName = "DataConsumerVariadbleMeasurements";
        this.types.push("DataConsumerVariadbleMeasurements");
        this.types.push("IMeasurements");
        this.types.push("IAlias");
        this.types.push("ISetFeedback");
    }
    getMeasurementsCount() {
        return this.output.length;
    }
    getMeasurement(i) {
        return this.output[i];
    }
    addMeasurement(measurement) {
    }
    updateMeasurements() {
    }
    getAliasType(name) {
        return this.aliasTypes.get(name);
    }
    getAliasNames() {
        return this.aliasNames;
    }
    getAliasValue(name) {
        return this.aliasValues.get(name);
    }
    setAliasValue(name, value) {
        if (!this.aliasTypes.has(name)) {
            this.performer.setAliasType(name, value, this.aliasTypes, this.aliasNames);
        }
        else {
            var i = 0;
        }
        this.aliasValues.set(name, value);
    }
    addVariableValue(name, type, value) {
        let variable = new Variable_1.Variable(name, type, value);
        this.addVariable(variable);
    }
    addVariable(variable) {
        this.output.push(variable);
        this.variables.set(variable.getMeasurementName(), variable);
    }
    setFeedback() { }
}
exports.DataConsumerVariableMeasurements = DataConsumerVariableMeasurements;
//# sourceMappingURL=DataConsumerVariableMeasurements.js.map