"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Orbital1 = void 0;
const AliasName_1 = require("../Library/AliasName");
const Desktop_1 = require("../Library/Desktop");
const Measurement_1 = require("../Library/Measurements/Measurement");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
class Orbital_CategoryObject_0 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        this.var_1 = 0;
        this.var_2 = 0;
        this.var_3 = 0;
        this.var_4 = 0;
        this.var_5 = 0;
        this.var_6 = 2;
        this.var_7 = 0;
        this.var_8 = 0;
        this.var_9 = 0;
        let map = new Map([
            ["a", 5],
            ["b", 1]
        ]);
        this.performer.SetAliasMap(map, this);
        let feed = new Map([]);
        this.performer.copyMap(feed, this.feedback);
        this.arguments.push("t = Time");
        let ops = new Map([]);
        this.performer.copyMap(ops, this.operationNames);
        this.init();
    }
    calculateTree() {
        this.success = true;
        this.var_0 = this.getInternalTime();
        this.variable = this.aliasName1.getAliasNameValue();
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
        this.variable = this.aliasName3.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_3 = this.convert(this.variable);
        this.variable = (this.var_3) * (this.var_0);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_4 = this.convert(this.variable);
        this.var_5 = this.getInternalTime();
        this.variable = Math.pow(this.var_5, this.var_6);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_7 = this.convert(this.variable);
        this.variable = Math.sin(this.var_7);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_8 = this.convert(this.variable);
        this.variable = (this.var_4) + (this.var_8);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_9 = this.convert(this.variable);
    }
    init() {
        this.addMeasurement(new Measurement_1.Measurement("Formula_1", 0, this.get_2));
        this.addMeasurement(new Measurement_1.Measurement("Formula_2", 0, this.get_9));
        this.aliasName1 = new AliasName_1.AliasName(this.alias, "b");
        this.aliasName3 = new AliasName_1.AliasName(this.alias, "a");
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
    postSetArrow() {
        this.init();
    }
}
class Orbital1 extends Desktop_1.Desktop {
    constructor() {
        super();
        this.name = "Orbital";
        new Orbital_CategoryObject_0(this, "input");
        let arrows = this.getArrows();
        let objects = this.getObjects();
        objects[0].postSetArrow();
    }
}
exports.Orbital1 = Orbital1;
//# sourceMappingURL=Orbital1.js.map