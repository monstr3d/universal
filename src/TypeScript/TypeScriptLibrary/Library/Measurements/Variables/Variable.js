"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Variable = void 0;
const Performer_1 = require("../../Performer");
class Variable {
    constructor(name, type, value) {
        this.value = new Object();
        this.type = new Object();
        this.name = "";
        this.className = "Variable";
        this.types = ["Variable", "IMeasurement", "IObject", "IValue", "IDerivation"];
        this.performer = new Performer_1.Performer();
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
        return this.types.indexOf(type) >= 0;
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
//# sourceMappingURL=Variable.js.map