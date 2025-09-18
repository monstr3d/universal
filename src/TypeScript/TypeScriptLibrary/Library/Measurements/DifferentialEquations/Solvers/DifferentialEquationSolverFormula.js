"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DifferentialEquationSolverFormula = void 0;
const DataConsumerVariableMeasurementsStarted_1 = require("../../DataConsumerVariableMeasurementsStarted");
const Variable_1 = require("../../Variables/Variable");
class DifferentialEquationSolverFormula extends DataConsumerVariableMeasurementsStarted_1.DataConsumerVariableMeasurementsStarted {
    constructor(desktop, name) {
        super(desktop, name);
        this.derivations = new Map();
        this.deri = [];
        this.typeName = "DifferentialEquationSolverFormula";
        this.types.push("IDifferentialEquationSolver");
        this.types.push("IPostSetArrow");
        this.types.push("DifferentrialEquationSolverFormula");
    }
    setDifferentialEquationSolverTimeProvider(time) {
        this.time = time;
    }
    getDifferentialEquationSolverTimeProvider() {
        return this.time;
    }
    startedStart(start) {
        this.initial.resetInitialValues();
        this.feedback.setFeedbacks();
    }
    calculateDerivations() {
        this.feedback.setFeedbacks();
        this.performer.updateChildrenData(this);
        this.calculateTree();
        this.save();
    }
    copyVariablesToSolver(offset, variables) {
        let n = this.output.length;
        for (var i = 0; i < n; i++) {
            this.output[i].setIValue(variables[i + offset]);
        }
    }
    calculateTree() {
    }
    save() {
    }
    init() {
    }
    addVariableValue(name, type, value) {
        let variable = new Variable_1.Variable(name, type, value);
        let derivation = new Variable_1.Variable("D" + name, 0, 0);
        variable.setDerivation(derivation);
        this.derivations.set(name, derivation);
        this.addVariable(variable);
        this.deri.push(derivation);
    }
    postSetArrow() {
        this.init();
        this.setInitial();
        this.setFeedback();
    }
}
exports.DifferentialEquationSolverFormula = DifferentialEquationSolverFormula;
//# sourceMappingURL=DifferentialEquationSolverFormula.js.map