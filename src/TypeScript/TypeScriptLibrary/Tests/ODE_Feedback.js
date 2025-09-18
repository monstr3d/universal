"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ODE_Feedback = void 0;
const AliasName_1 = require("../Library/AliasName");
const Desktop_1 = require("../Library/Desktop");
const DataLink_1 = require("../Library/Measurements/Arrows/DataLink");
const DataConsumer_1 = require("../Library/Measurements/DataConsumer");
const DifferentialEquationSolverFormula_1 = require("../Library/Measurements/DifferentialEquations/Solvers/DifferentialEquationSolverFormula");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
class ODE_Feedback_CategoryObject_0 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        this.var_1 = 0;
        this.var_2 = 0;
        this.var_3 = 0;
        this.var_4 = 0;
        this.var_5 = 0;
        this.var_6 = 0;
        this.var_7 = 0;
        this.var_8 = 0;
        this.var_9 = 0;
        this.var_10 = 0;
        this.var_11 = 0;
        let map = new Map([
            ["a", 1],
            ["k", 2],
            ["d", -0.17015052092374328],
            ["b", 1],
            ["c", 0.31314560830292659],
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", 0, 0.017747760535215762);
        this.addVariableValue("Formula_2", 0, 0.31314560830292659);
        this.addVariableValue("Formula_3", 0, -0.17015052092374328);
        this.addVariableValue("Formula_4", 0, 2);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.aliasName0.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_0 = this.convert(this.variable);
        this.variable = this.aliasName1.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_1 = this.convert(this.variable);
        this.var_2 = this.getInternalTime();
        this.variable = (this.var_1) * (this.var_2);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_3 = this.convert(this.variable);
        this.variable = Math.sin(this.var_3);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_4 = this.convert(this.variable);
        this.variable = (this.var_0) * (this.var_4);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_5 = this.convert(this.variable);
        this.variable = this.aliasName6.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_6 = this.convert(this.variable);
        this.variable = this.aliasName7.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_7 = this.convert(this.variable);
        this.variable = this.aliasName8.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_8 = this.convert(this.variable);
        this.variable = (this.var_7) - (this.var_8);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_9 = this.convert(this.variable);
        this.variable = (this.var_6) * (this.var_9);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_10 = this.convert(this.variable);
        this.variable = (this.var_5) + (this.var_10);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_11 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.aliasName0 = new AliasName_1.AliasName(this.alias, "a");
        this.aliasName1 = new AliasName_1.AliasName(this.alias, "b");
        this.aliasName6 = new AliasName_1.AliasName(this.alias, "k");
        this.aliasName7 = new AliasName_1.AliasName(this.alias, "c");
        this.aliasName8 = new AliasName_1.AliasName(this.alias, "d");
    }
    get_0() {
        return this.success ? this.var_0 : undefined;
    }
    get_1() {
        return this.success ? this.var_1 : undefined;
    }
    get_2() {
        return this.success ? this.var_2 : undefined;
    }
    get_3() {
        return this.success ? this.var_3 : undefined;
    }
    get_4() {
        return this.success ? this.var_4 : undefined;
    }
    get_5() {
        return this.success ? this.var_5 : undefined;
    }
    get_6() {
        return this.success ? this.var_6 : undefined;
    }
    get_7() {
        return this.success ? this.var_7 : undefined;
    }
    get_8() {
        return this.success ? this.var_8 : undefined;
    }
    get_9() {
        return this.success ? this.var_9 : undefined;
    }
    get_10() {
        return this.success ? this.var_10 : undefined;
    }
    get_11() {
        return this.success ? this.var_11 : undefined;
    }
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0 === null || x0 === void 0 ? void 0 : x0.setIValue(this.get_11());
        var x1 = v.get("Formula_2");
        x1 === null || x1 === void 0 ? void 0 : x1.setIValue(this.get_7());
        var x2 = v.get("Formula_3");
        x2 === null || x2 === void 0 ? void 0 : x2.setIValue(this.get_8());
        var x3 = v.get("Formula_4");
        x3 === null || x3 === void 0 ? void 0 : x3.setIValue(this.get_6());
    }
}
class ODE_Feedback_CategoryObject_1 extends DifferentialEquationSolverFormula_1.DifferentialEquationSolverFormula {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        this.var_1 = 0;
        this.var_2 = 0;
        this.var_3 = 0;
        this.var_4 = 0;
        this.var_5 = 0;
        this.var_6 = 0;
        this.var_7 = 0;
        let map = new Map([
            ["a", 1],
            ["y", 1],
            ["x", 0],
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("x", 0, 0);
        this.addVariableValue("y", 0, 1);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.aliasName0.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_0 = this.convert(this.variable);
        this.variable = -(this.var_0);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_1 = this.convert(this.variable);
        this.variable = this.value2.getIValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_2 = this.convert(this.variable);
        this.variable = (this.var_1) * (this.var_2);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_3 = this.convert(this.variable);
        this.variable = this.value4.getIValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_4 = this.convert(this.variable);
        this.variable = (this.var_0) * (this.var_4);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_5 = this.convert(this.variable);
        this.variable = this.measurement6.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_6 = this.convert(this.variable);
        this.variable = (this.var_5) + (this.var_6);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_7 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.value2 = this.output[1];
        this.value4 = this.output[0];
        this.measurement6 = all[0].getMeasurement(0);
        this.aliasName0 = new AliasName_1.AliasName(this.alias, "a");
    }
    get_0() {
        return this.success ? this.var_0 : undefined;
    }
    get_1() {
        return this.success ? this.var_1 : undefined;
    }
    get_2() {
        return this.success ? this.var_2 : undefined;
    }
    get_3() {
        return this.success ? this.var_3 : undefined;
    }
    get_4() {
        return this.success ? this.var_4 : undefined;
    }
    get_5() {
        return this.success ? this.var_5 : undefined;
    }
    get_6() {
        return this.success ? this.var_6 : undefined;
    }
    get_7() {
        return this.success ? this.var_7 : undefined;
    }
    save() {
        var v = this.derivations;
        var x0 = v.get("y");
        x0 === null || x0 === void 0 ? void 0 : x0.setIValue(this.get_7());
        var x1 = v.get("x");
        x1 === null || x1 === void 0 ? void 0 : x1.setIValue(this.get_3());
    }
}
class ODE_Feedback_CategoryObject_2 extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class ODE_Feedback_CategoryArrow_0 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class ODE_Feedback_CategoryArrow_1 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class ODE_Feedback extends Desktop_1.Desktop {
    constructor() {
        super();
        this.name = "ODE_Feedback";
        new ODE_Feedback_CategoryObject_0(this, "Init");
        new ODE_Feedback_CategoryObject_1(this, "ODE");
        new ODE_Feedback_CategoryObject_2(this, "Chart");
        new ODE_Feedback_CategoryArrow_0(this, "1");
        new ODE_Feedback_CategoryArrow_1(this, "");
        let objects = this.getCategoryObjects();
        let arrows = this.getCategoryArrows();
        arrows[0].setSource(objects[1]);
        arrows[0].setTarget(objects[0]);
        arrows[1].setSource(objects[2]);
        arrows[1].setTarget(objects[1]);
        objects[0].postSetArrow();
        objects[1].postSetArrow();
    }
}
exports.ODE_Feedback = ODE_Feedback;
//# sourceMappingURL=ODE_Feedback.js.map