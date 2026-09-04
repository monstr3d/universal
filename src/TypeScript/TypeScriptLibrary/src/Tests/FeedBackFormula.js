"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FeedBackFormula = void 0;
const AliasName_1 = require("../Library/AliasName");
const Desktop_1 = require("../Library/Desktop");
const DataLink_1 = require("../Library/Measurements/Arrows/DataLink");
const DataConsumer_1 = require("../Library/Measurements/DataConsumer");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
class FeedBackFormula_CategoryObject_0 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
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
        this.aliasName0 = new AliasName_1.AliasName(this.alias, "a");
        this.aliasName1 = new AliasName_1.AliasName(this.alias, "b");
        this.aliasName3 = new AliasName_1.AliasName(this.alias, "c");
        this.aliasName8 = new AliasName_1.AliasName(this.alias, "f");
    }
    aliasName0;
    aliasName1;
    aliasName3;
    aliasName8;
    var_0 = 0;
    var_1 = 0;
    var_2 = 0;
    var_3 = 0;
    var_4 = 0;
    var_5 = 0;
    var_6 = 0;
    var_7 = 0;
    var_8 = 0;
    var_9 = 0;
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
        x0?.setIValue(this.get_7());
        var x1 = v.get("Formula_2");
        x1?.setIValue(this.get_9());
    }
}
class FeedBackFormula_CategoryObject_1 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
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
        this.aliasName0 = new AliasName_1.AliasName(this.alias, "k");
    }
    measurement1;
    measurement3;
    aliasName0;
    var_0 = 0;
    var_1 = 0;
    var_2 = 0;
    var_3 = 0;
    var_4 = 0;
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
        x0?.setIValue(this.get_2());
        var x1 = v.get("Formula_2");
        x1?.setIValue(this.get_4());
    }
    setFeedback() {
        let map = new Map([
            ["Formula_1", "X.a"]
        ]);
    }
}
class FeedBackFormula_CategoryObject_2 extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class FeedBackFormula_CategoryArrow_0 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class FeedBackFormula_CategoryArrow_1 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class FeedBackFormula extends Desktop_1.Desktop {
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
