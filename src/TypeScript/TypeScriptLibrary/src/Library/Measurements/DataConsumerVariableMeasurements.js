"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataConsumerVariableMeasurements = void 0;
const DataConsumer_1 = require("./DataConsumer");
const PerformerMeasuremets_1 = require("./PerformerMeasuremets");
const Variable_1 = require("./Variables/Variable");
class DataConsumerVariableMeasurements extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.alias = this;
        this.typeName = "DataConsumerVariadbleMeasurements";
        this.types.push("DataConsumerVariadbleMeasurements");
        this.types.push("IMeasurements");
        this.types.push("IAlias");
        this.types.push("ISetFeedback");
    }
    output = [];
    variables = new Map();
    aliasTypes = new Map();
    aliasValues = new Map();
    aliasNames = [];
    dataVariable;
    alias;
    pMeasurements = new PerformerMeasuremets_1.PerformerMeasuremets();
    getMeasurementsCount() {
        return this.output.length;
    }
    getMeasurement(i) {
        return this.output[i];
    }
    fict;
    addMeasurement(measurement) {
        this.fict = measurement;
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
}
exports.DataConsumerVariableMeasurements = DataConsumerVariableMeasurements;
