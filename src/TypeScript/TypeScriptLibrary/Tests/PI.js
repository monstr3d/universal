"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PI = void 0;
const AliasName_1 = require("../Library/AliasName");
const Desktop_1 = require("../Library/Desktop");
const DataLink_1 = require("../Library/Measurements/Arrows/DataLink");
const DataConsumer_1 = require("../Library/Measurements/DataConsumer");
const RandomGenerator_1 = require("../Library/Measurements/RandomGenerator");
const RecursiveFormula_1 = require("../Library/Measurements/RecursiveFormula");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
class PI_CategoryObject_0 extends RandomGenerator_1.RandomGenerator {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class PI_CategoryObject_1 extends RandomGenerator_1.RandomGenerator {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class PI_CategoryObject_2 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        this.var_1 = 2;
        this.var_2 = 0;
        this.var_3 = 0;
        this.var_4 = 2;
        this.var_5 = 0;
        this.var_6 = 0;
        this.var_7 = 1;
        this.var_8 = false;
        this.var_9 = 0;
        this.var_10 = 0;
        this.var_11 = 0;
        let map = new Map([
            ["f", 0.0040000000000000001]
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", 0, 0.0040000000000000001);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.measurement0.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_0 = this.convert(this.variable);
        this.variable = Math.pow(this.var_0, this.var_1);
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
        this.variable = Math.pow(this.var_3, this.var_4);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_5 = this.convert(this.variable);
        this.variable = (this.var_2) + (this.var_5);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_6 = this.convert(this.variable);
        this.variable = (this.var_6) > (this.var_7);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_8 = this.convert(this.variable);
        this.variable = this.aliasName10.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_10 = this.convert(this.variable);
        this.variable = (this.var_8) ? (this.var_9) : (this.var_10);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_11 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.measurement0 = all[0].getMeasurement(0);
        this.measurement3 = all[1].getMeasurement(0);
        this.aliasName10 = new AliasName_1.AliasName(this.alias, "f");
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
    }
}
class PI_CategoryObject_3 extends RecursiveFormula_1.RecursiveFormula {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        this.var_1 = 0;
        this.var_2 = 0;
        let map = new Map([
            ["d", 0],
            ["c", 0],
            ["a", 0],
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("a", 0, 0);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.value0.getIValue();
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
        this.variable = (this.var_0) + (this.var_1);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_2 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.value0 = this.output[0];
        this.measurement1 = all[0].getMeasurement(0);
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
        var x0 = v.get("a");
        x0 === null || x0 === void 0 ? void 0 : x0.setIValue(this.get_2());
    }
}
class PI_CategoryObject_4 extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class PI_CategoryArrow_0 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class PI_CategoryArrow_1 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class PI_CategoryArrow_2 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class PI_CategoryArrow_3 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class PI extends Desktop_1.Desktop {
    constructor() {
        super();
        this.name = "PI";
        new PI_CategoryObject_0(this, "X");
        new PI_CategoryObject_1(this, "Y");
        new PI_CategoryObject_2(this, "Data");
        new PI_CategoryObject_3(this, "Recursive");
        new PI_CategoryObject_4(this, "Chart");
        new PI_CategoryArrow_0(this, "2");
        new PI_CategoryArrow_1(this, "1");
        new PI_CategoryArrow_2(this, "3");
        new PI_CategoryArrow_3(this, "4");
        let objects = this.getCategoryObjects();
        let arrows = this.getCategoryArrows();
        arrows[0].setSource(objects[2]);
        arrows[0].setTarget(objects[1]);
        arrows[1].setSource(objects[2]);
        arrows[1].setTarget(objects[0]);
        arrows[2].setSource(objects[3]);
        arrows[2].setTarget(objects[2]);
        arrows[3].setSource(objects[4]);
        arrows[3].setTarget(objects[3]);
        objects[2].postSetArrow();
        objects[3].postSetArrow();
    }
}
exports.PI = PI;
//# sourceMappingURL=PI.js.map