"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FeedBackFormula = void 0;
const AliasName_js_1 = require("../Library/AliasName.js");
const Desktop_js_1 = require("../Library/Desktop.js");
const DataLink_js_1 = require("../Library/Measurements/Arrows/DataLink.js");
const DataConsumer_js_1 = require("../Library/Measurements/DataConsumer.js");
const VectorFormulaConsumer_js_1 = require("../Library/Measurements/VectorFormulaConsumer.js");
class FeedBackFormula_CategoryObject_0 extends VectorFormulaConsumer_js_1.VectorFormulaConsumer {
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
        let map = new Map([
            ["c", 3],
            ["a", 7.1237279830727527],
            ["f", 4],
            ["b", 2],
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", 0, 6.0487509164170019);
        this.addVariableValue("Formula_2", 0, 11.600000000000001);
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
        this.variable = (this.var_0) + (this.var_1);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_2 = this.convert(this.variable);
        this.variable = this.aliasName3.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_3 = this.convert(this.variable);
        this.var_4 = this.getInternalTime();
        this.variable = (this.var_3) * (this.var_4);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_5 = this.convert(this.variable);
        this.variable = Math.sin(this.var_5);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_6 = this.convert(this.variable);
        this.variable = (this.var_2) * (this.var_6);
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
        this.variable = (this.var_8) * (this.var_4);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_9 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.aliasName0 = new AliasName_js_1.AliasName(this.alias, "a");
        this.aliasName1 = new AliasName_js_1.AliasName(this.alias, "b");
        this.aliasName3 = new AliasName_js_1.AliasName(this.alias, "c");
        this.aliasName8 = new AliasName_js_1.AliasName(this.alias, "f");
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
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0 === null || x0 === void 0 ? void 0 : x0.setIValue(this.get_7());
        var x1 = v.get("Formula_2");
        x1 === null || x1 === void 0 ? void 0 : x1.setIValue(this.get_9());
    }
}
class FeedBackFormula_CategoryObject_1 extends VectorFormulaConsumer_js_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        this.var_1 = 0;
        this.var_2 = 0;
        this.var_3 = 0;
        this.var_4 = 0;
        let map = new Map([
            ["k", 1]
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", 0, 6.0487509164170019);
        this.addVariableValue("Formula_2", 0, 11.600000000000001);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.aliasName0.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_0 = this.convert(this.variable);
        this.variable = this.measurement1.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_1 = this.convert(this.variable);
        this.variable = (this.var_0) * (this.var_1);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_2 = this.convert(this.variable);
        this.variable = this.measurement3.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_3 = this.convert(this.variable);
        this.variable = (this.var_0) * (this.var_3);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_4 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.measurement1 = all[0].getMeasurement(0);
        this.measurement3 = all[0].getMeasurement(1);
        this.aliasName0 = new AliasName_js_1.AliasName(this.alias, "k");
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
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0 === null || x0 === void 0 ? void 0 : x0.setIValue(this.get_2());
        var x1 = v.get("Formula_2");
        x1 === null || x1 === void 0 ? void 0 : x1.setIValue(this.get_4());
    }
    setFeedback() {
        let map = new Map([
            ["Formula_1", "X.a"]
        ]);
    }
}
class FeedBackFormula_CategoryObject_2 extends DataConsumer_js_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class FeedBackFormula_CategoryArrow_0 extends DataLink_js_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class FeedBackFormula_CategoryArrow_1 extends DataLink_js_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class FeedBackFormula extends Desktop_js_1.Desktop {
    constructor() {
        super();
        this.name = "FeedBackFormula";
        new FeedBackFormula_CategoryObject_0(this, "X");
        new FeedBackFormula_CategoryObject_1(this, "Y");
        new FeedBackFormula_CategoryObject_2(this, "Chart");
        new FeedBackFormula_CategoryArrow_0(this, "");
        new FeedBackFormula_CategoryArrow_1(this, "");
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
exports.FeedBackFormula = FeedBackFormula;
//# sourceMappingURL=FeedBackFormula.js.map