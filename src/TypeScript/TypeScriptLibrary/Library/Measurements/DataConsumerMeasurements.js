"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataConsumerMeasurements = void 0;
const Performer_1 = require("../Performer");
const DataConsumer_1 = require("./DataConsumer");
class DataConsumerMeasurements extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.output = [];
        this.aliasTypes = new Map();
        this.aliasValues = new Map();
        this.aliasNames = [];
        this.performer = new Performer_1.Performer();
        this.alias = this;
        this.typeName = "DataConsumerMeasurements";
        this.types.push("DataConsumerMeasurements");
        this.types.push("IMeasurements");
        this.types.push("IAlias");
    }
    getMeasurementsCount() {
        return this.output.length;
    }
    getMeasurement(i) {
        return this.output[i];
    }
    addMeasurement(measurement) {
        this.output.push(measurement);
    }
    updateMeasurements() {
    }
    getAliasType(name) {
        return this.aliasTypes.get(name);
    }
    getAliasNames() {
        return this.aliasNames;
    }
    getAliasVаlue(name) {
        return this.aliasValues.get(name);
    }
    setAliasValue(name, value) {
        this.performer.setAliasType(name, value, this.aliasTypes, this.aliasNames);
        this.aliasValues.set(name, value);
    }
}
exports.DataConsumerMeasurements = DataConsumerMeasurements;
//# sourceMappingURL=DataConsumerMeasurements.js.map