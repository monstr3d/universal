"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DonchianDesktop = void 0;
const AliasName_1 = require("../Library/AliasName");
const Desktop_1 = require("../Library/Desktop");
const DataLink_1 = require("../Library/Measurements/Arrows/DataLink");
const DataConsumer_1 = require("../Library/Measurements/DataConsumer");
const FeedbackAliasCollection_1 = require("../Library/Measurements/FeedBack/FeedbackAliasCollection");
const RecursiveFormula_1 = require("../Library/Measurements/RecursiveFormula");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
class DonchianDesktop_CategoryObject_0 extends RecursiveFormula_1.RecursiveFormula {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([
            ["t", -0.058407839907797091],
            ["x", 2],
            ["y", 3],
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("x", 0, 2);
        this.addVariableValue("y", 0, 3);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.aliasName0.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_0 = this.convert(this.variable);
        this.variable = this.value1.getIValue();
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
        this.variable = (this.var_1) + (this.var_2);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_3 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.fic = all;
        this.value1 = this.output[0];
        this.value2 = this.output[1];
        this.aliasName0 = new AliasName_1.AliasName(this.alias, "t");
    }
    aliasName0;
    value1;
    value2;
    var_0 = 0;
    var_1 = 0;
    var_2 = 0;
    var_3 = 0;
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
    save() {
        var v = this.variables;
        var x0 = v.get("x");
        x0?.setIValue(this.get_0());
        var x1 = v.get("y");
        x1?.setIValue(this.get_3());
    }
}
class DonchianDesktop_CategoryObject_1 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([
            ["a", -0.10000000000000001]
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", 0, 0);
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
    }
    init() {
        var all = this.getAllMeasurements();
        this.fic = all;
        this.measurement1 = all[0].getMeasurement(1);
        this.aliasName0 = new AliasName_1.AliasName(this.alias, "a");
    }
    measurement1;
    aliasName0;
    var_0 = 0;
    var_1 = 0;
    var_2 = 0;
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
        x0?.setIValue(this.get_2());
    }
    setFeedback() {
        let map = new Map([
            ["Formula_1", "R.t"]
        ]);
        this.feedback = new FeedbackAliasCollection_1.FeedbackAliasCollection(map, this, this);
    }
}
class DonchianDesktop_CategoryObject_2 extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class DonchianDesktop_CategoryArrow_0 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class DonchianDesktop_CategoryArrow_1 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class DonchianDesktop_CategoryArrow_2 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class DonchianDesktop extends Desktop_1.Desktop {
    static async getDesktopAsync(controller, factory) {
        let d = new DonchianDesktop(factory);
        await d.loadAsync(controller);
        return d;
    }
    constructor(factory) {
        super(factory);
        this.name = "DonchianDesktop";
        this.mapObjects.set("DonchianDesktop_CategoryObject_0", new DonchianDesktop_CategoryObject_0(this, "R"));
        this.mapObjects.set("DonchianDesktop_CategoryObject_1", new DonchianDesktop_CategoryObject_1(this, "F"));
        this.mapObjects.set("DonchianDesktop_CategoryObject_2", new DonchianDesktop_CategoryObject_2(this, "Chart"));
        new DonchianDesktop_CategoryArrow_0(this, "");
        new DonchianDesktop_CategoryArrow_1(this, "");
        new DonchianDesktop_CategoryArrow_2(this, "");
        this.finish();
    }
    finish() {
        let objects = this.getCategoryObjects();
        let arrows = this.getCategoryArrows();
        let s0 = this.mapObjects.get("DonchianDesktop_CategoryObject_1");
        if (s0 != undefined)
            arrows[0].setSource(s0);
        let t0 = this.mapObjects.get("DonchianDesktop_CategoryObject_0");
        if (t0 != undefined)
            arrows[0].setTarget(t0);
        let s1 = this.mapObjects.get("DonchianDesktop_CategoryObject_2");
        if (s1 != undefined)
            arrows[1].setSource(s1);
        let t1 = this.mapObjects.get("DonchianDesktop_CategoryObject_0");
        if (t1 != undefined)
            arrows[1].setTarget(t1);
        let s2 = this.mapObjects.get("DonchianDesktop_CategoryObject_2");
        if (s2 != undefined)
            arrows[2].setSource(s2);
        let t2 = this.mapObjects.get("DonchianDesktop_CategoryObject_1");
        if (t2 != undefined)
            arrows[2].setTarget(t2);
        objects[0].postSetArrow();
        objects[1].postSetArrow();
        objects[2].postSetArrow();
    }
}
exports.DonchianDesktop = DonchianDesktop;
