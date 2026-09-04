"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Composition = void 0;
const AliasName_1 = require("../Library/AliasName");
const Desktop_1 = require("../Library/Desktop");
const EventLink_1 = require("../Library/Event/Objects/EventLink");
const TimerObject_1 = require("../Library/Event/Objects/TimerObject");
const DataLink_1 = require("../Library/Measurements/Arrows/DataLink");
const DataConsumer_1 = require("../Library/Measurements/DataConsumer");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
const TimeSpan_1 = require("../Library/Utilities/DateTime/TimeSpan");
class Composition_CategoryObject_0 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([
            ["f", 4],
            ["c", 3],
            ["b", 2],
            ["a", 7.1237279830727527],
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", 0, 0);
        this.addVariableValue("Formula_2", 0, 0);
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
class Composition_CategoryObject_1 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([
            ["k", 1]
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", 0, 0);
        this.addVariableValue("Formula_2", 0, 0);
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
}
class Composition_CategoryObject_2 extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Composition_CategoryObject_3 extends TimerObject_1.TimerObject {
    constructor(desktop, name) {
        super(desktop, name);
        this.span = new TimeSpan_1.TimeSpan(100000);
    }
}
class Composition_CategoryArrow_0 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Composition_CategoryArrow_1 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Composition_CategoryArrow_2 extends EventLink_1.EventLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Composition extends Desktop_1.Desktop {
    constructor() {
        super();
        this.name = "Composition";
        this.mapObjects.set("Composition_CategoryObject_0", new Composition_CategoryObject_0(this, "X"));
        this.mapObjects.set("Composition_CategoryObject_1", new Composition_CategoryObject_1(this, "Y"));
        this.mapObjects.set("Composition_CategoryObject_2", new Composition_CategoryObject_2(this, "Chart"));
        this.mapObjects.set("Composition_CategoryObject_3", new Composition_CategoryObject_3(this, "Timer"));
        new Composition_CategoryArrow_0(this, "");
        new Composition_CategoryArrow_1(this, "");
        new Composition_CategoryArrow_2(this, "");
        this.finish();
    }
    finish() {
        let objects = this.getCategoryObjects();
        let arrows = this.getCategoryArrows();
        let s0 = this.mapObjects.get("Composition_CategoryObject_1");
        if (s0 != undefined)
            arrows[0].setSource(s0);
        let t0 = this.mapObjects.get("Composition_CategoryObject_0");
        if (t0 != undefined)
            arrows[0].setTarget(t0);
        let s1 = this.mapObjects.get("Composition_CategoryObject_2");
        if (s1 != undefined)
            arrows[1].setSource(s1);
        let t1 = this.mapObjects.get("Composition_CategoryObject_1");
        if (t1 != undefined)
            arrows[1].setTarget(t1);
        let s2 = this.mapObjects.get("Composition_CategoryObject_2");
        if (s2 != undefined)
            arrows[2].setSource(s2);
        let t2 = this.mapObjects.get("Composition_CategoryObject_3");
        if (t2 != undefined)
            arrows[2].setTarget(t2);
        objects[0].postSetArrow();
        objects[1].postSetArrow();
        objects[2].postSetArrow();
    }
}
exports.Composition = Composition;
