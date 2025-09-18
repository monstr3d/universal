"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ConditionTest = void 0;
const AliasName_1 = require("../Library/AliasName");
const Desktop_1 = require("../Library/Desktop");
const DataLink_1 = require("../Library/Measurements/Arrows/DataLink");
const DataConsumer_1 = require("../Library/Measurements/DataConsumer");
const Variable_1 = require("../Library/Measurements/Variables/Variable");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
class ConditionTest_CategoryObject_0 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        this.var_1 = 0;
        let map = new Map([]);
        this.performer.setAliasMap(map, this);
        this.addVariable(new Variable_1.Variable("Formula_1", 0, 0));
    }
    calculateTree() {
        this.success = true;
        this.var_0 = this.getInternalTime();
        this.variable = Math.sin(this.var_0);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_1 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
    }
    get_0() {
        return this.success ? this.var_0 : undefined;
    }
    get_1() {
        return this.success ? this.var_1 : undefined;
    }
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0 === null || x0 === void 0 ? void 0 : x0.setIValue(this.get_1());
    }
    setFeedback() {
        let map = new Map([]);
    }
}
class ConditionTest_CategoryObject_1 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        this.var_1 = 0;
        this.var_2 = false;
        let map = new Map([
            ["a", 0.995]
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariable(new Variable_1.Variable("Formula_1", false, false));
    }
    calculateTree() {
        this.success = true;
        this.variable = this.measurement0.getMeasurementValue();
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
        this.variable = (this.var_0) > (this.var_1);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_2 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.measurement0 = all[0].getMeasurement(0);
        this.aliasName1 = new AliasName_1.AliasName(this.alias, "a");
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
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0 === null || x0 === void 0 ? void 0 : x0.setIValue(this.get_2());
    }
    setFeedback() {
        let map = new Map([]);
    }
}
class ConditionTest_CategoryObject_2 extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class ConditionTest_CategoryArrow_0 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class ConditionTest_CategoryArrow_1 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class ConditionTest_CategoryArrow_2 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class ConditionTest extends Desktop_1.Desktop {
    constructor() {
        super();
        this.name = "ConditionTest";
        new ConditionTest_CategoryObject_0(this, "Input");
        new ConditionTest_CategoryObject_1(this, "Condition");
        new ConditionTest_CategoryObject_2(this, "Chart");
        new ConditionTest_CategoryArrow_0(this, "");
        new ConditionTest_CategoryArrow_1(this, "");
        new ConditionTest_CategoryArrow_2(this, "");
        let objects = this.getCategoryObjects();
        let arrows = this.getCategoryArrows();
        arrows[0].setSource(objects[1]);
        arrows[0].setTarget(objects[0]);
        arrows[1].setSource(objects[2]);
        arrows[1].setTarget(objects[1]);
        arrows[2].setSource(objects[2]);
        arrows[2].setTarget(objects[0]);
        objects[0].postSetArrow();
        objects[1].postSetArrow();
    }
}
exports.ConditionTest = ConditionTest;
//# sourceMappingURL=ConditionTest.js.map