"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Two = void 0;
const AliasName_1 = require("../Library/AliasName");
const Desktop_1 = require("../Library/Desktop");
const DataLink_1 = require("../Library/Measurements/Arrows/DataLink");
const Variable_1 = require("../Library/Measurements/Variables/Variable");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
class Two_CategoryObject_0 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
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
        this.performer.setAliasMap(map, this);
        this.addVariable(new Variable_1.Variable("Formula_1", 0, 0));
        this.addVariable(new Variable_1.Variable("Formula_2", 0, 0));
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
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0 === null || x0 === void 0 ? void 0 : x0.setIValue(this.get_2());
        var x1 = v.get("Formula_2");
        x1 === null || x1 === void 0 ? void 0 : x1.setIValue(this.get_9());
    }
}
class Two_CategoryObject_1 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        this.var_1 = 2;
        this.var_2 = 0;
        this.var_3 = 0;
        this.var_4 = 0;
        this.var_5 = 0;
        this.var_6 = 0;
        this.var_7 = 0;
        let map = new Map([
            ["a", 7],
            ["b", 8]
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariable(new Variable_1.Variable("Formula_1", 0, 0));
        this.addVariable(new Variable_1.Variable("Formula_2", 0, 0));
        this.addVariable(new Variable_1.Variable("Formula_3", 0, 0));
    }
    calculateTree() {
        this.success = true;
        this.variable = this.aliasName0.getAliasNameValue();
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
        this.variable = this.aliasName3.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_3 = this.convert(this.variable);
        this.variable = Math.cos(this.var_3);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_4 = this.convert(this.variable);
        this.variable = this.aliasName5.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_5 = this.convert(this.variable);
        this.var_6 = this.getInternalTime();
        this.variable = (this.var_5) * (this.var_6);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_7 = this.convert(this.variable);
    }
    init() {
        this.aliasName0 = new AliasName_1.AliasName(this.alias, "a");
        this.aliasName3 = new AliasName_1.AliasName(this.alias, "b");
        this.aliasName5 = new AliasName_1.AliasName(this.alias, "a");
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
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0 === null || x0 === void 0 ? void 0 : x0.setIValue(this.get_2());
        var x1 = v.get("Formula_2");
        x1 === null || x1 === void 0 ? void 0 : x1.setIValue(this.get_4());
        var x2 = v.get("Formula_3");
        x2 === null || x2 === void 0 ? void 0 : x2.setIValue(this.get_7());
    }
}
class Two_CategoryArrow_0 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Two extends Desktop_1.Desktop {
    constructor() {
        super();
        this.name = "Two";
        new Two_CategoryObject_0(this, "input");
        new Two_CategoryObject_1(this, "Output");
        new Two_CategoryArrow_0(this, "22");
        let objects = this.getCategoryObjects();
        let arrows = this.getCategoryArrows();
        arrows[0].setSource(objects[1]);
        arrows[0].setTarget(objects[0]);
        objects[0].postSetArrow();
        objects[1].postSetArrow();
    }
}
exports.Two = Two;
//# sourceMappingURL=Two.js.map