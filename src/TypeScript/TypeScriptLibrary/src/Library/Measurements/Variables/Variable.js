"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Variable = void 0;
const Performer_1 = require("../../Performer");
class Variable {
    value = new Object();
    type = new Object();
    name = "";
    className = "Variable";
    types = ["Variable", "IMeasurement", "IObject", "IValue", "IDerivation"];
    performer = new Performer_1.Performer();
    measurement;
    derivation;
    constructor(name, type, value) {
        this.name = name;
        this.type = type;
        this.value = value;
    }
    getIValue() {
        return this.value;
    }
    setIValue(value) {
        this.value = value;
    }
    getClassName() {
        return this.className;
    }
    imlplementsType(type) {
        return this.types.includes(type);
    }
    getName() {
        return this.name;
    }
    getMeasurementName() {
        return this.name;
    }
    getMeasurementType() {
        return this.type;
    }
    getMeasurementValue() {
        return this.value;
    }
    getDerivation() {
        return this.measurement;
    }
    setDerivation(derivation) {
        this.measurement = derivation;
    }
    setDerivationVarible(variable) {
        this.derivation = variable;
    }
}
exports.Variable = Variable;
