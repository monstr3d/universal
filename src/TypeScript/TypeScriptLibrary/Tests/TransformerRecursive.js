"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TransformerRecursive = void 0;
const TestObjectTransformer_1 = require("../Test_Obects/TestObjectTransformer");
const AliasName_1 = require("../Library/AliasName");
const Desktop_1 = require("../Library/Desktop");
const DataLink_1 = require("../Library/Measurements/Arrows/DataLink");
const ObjectTransformerLink_1 = require("../Library/Measurements/Arrows/ObjectTransformerLink");
const DataConsumer_1 = require("../Library/Measurements/DataConsumer");
const ObjectTransformer_1 = require("../Library/Measurements/ObjectTransformer");
const RecursiveFormula_1 = require("../Library/Measurements/RecursiveFormula");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
class TransformerRecursive_CategoryObject_0 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        this.var_1 = 0;
        this.var_2 = 0;
        this.var_3 = 0;
        let map = new Map([
            ["a", 0.19290093047446638],
            ["d", 9],
            ["b", 0.0021041577613234159],
            ["c", 0.52807761014574284],
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", 0, 0.19290093047446638);
        this.addVariableValue("Formula_2", 0, 0.0021041577613234159);
        this.addVariableValue("Formula_3", 0, 0.52807761014574284);
        this.addVariableValue("Formula_4", 0, 9);
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
        this.variable = this.aliasName2.getAliasNameValue();
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
    }
    init() {
        var all = this.getAllMeasurements();
        this.aliasName0 = new AliasName_1.AliasName(this.alias, "a");
        this.aliasName1 = new AliasName_1.AliasName(this.alias, "b");
        this.aliasName2 = new AliasName_1.AliasName(this.alias, "c");
        this.aliasName3 = new AliasName_1.AliasName(this.alias, "d");
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
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0 === null || x0 === void 0 ? void 0 : x0.setIValue(this.get_0());
        var x1 = v.get("Formula_2");
        x1 === null || x1 === void 0 ? void 0 : x1.setIValue(this.get_1());
        var x2 = v.get("Formula_3");
        x2 === null || x2 === void 0 ? void 0 : x2.setIValue(this.get_2());
        var x3 = v.get("Formula_4");
        x3 === null || x3 === void 0 ? void 0 : x3.setIValue(this.get_3());
    }
}
class TransformerRecursive_CategoryObject_1 extends TestObjectTransformer_1.TestObjectTransformer {
    constructor(desktop, name) {
        super(desktop, name);
        this.coefficient = 0.24;
    }
}
class TransformerRecursive_CategoryObject_2 extends ObjectTransformer_1.ObjectTransformer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([
            ["a", "Vector.Formula_1"],
            ["b", "Vector.Formula_2"],
            ["c", "Vector.Formula_3"],
            ["d", "Vector.Formula_4"]
        ]);
        this.setLinks(map);
    }
}
class TransformerRecursive_CategoryObject_3 extends RecursiveFormula_1.RecursiveFormula {
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
        this.var_12 = 0;
        this.var_13 = 0;
        this.var_14 = 0;
        this.var_15 = 0;
        this.var_16 = 0;
        let map = new Map([
            ["k", 0.69999999999999996],
            ["l", 0.01],
            ["a", 1],
            ["b", 3],
            ["c", 5],
            ["d", 4],
            ["f", 1],
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("a", 0, 1);
        this.addVariableValue("b", 0, 3);
        this.addVariableValue("c", 0, 5);
        this.addVariableValue("d", 0, 4);
        this.addVariableValue("f", 0, 1);
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
        this.variable = (this.var_0) * (this.var_3);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_4 = this.convert(this.variable);
        this.variable = this.measurement5.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_5 = this.convert(this.variable);
        this.variable = this.value6.getIValue();
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
        this.variable = (this.var_0) * (this.var_7);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_8 = this.convert(this.variable);
        this.variable = this.measurement9.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_9 = this.convert(this.variable);
        this.variable = this.value10.getIValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_10 = this.convert(this.variable);
        this.variable = (this.var_9) + (this.var_10);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_11 = this.convert(this.variable);
        this.variable = (this.var_0) * (this.var_11);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_12 = this.convert(this.variable);
        this.variable = (this.var_0) * (this.var_1);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_13 = this.convert(this.variable);
        this.variable = this.aliasName14.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_14 = this.convert(this.variable);
        this.var_15 = this.getInternalTime();
        this.variable = (this.var_14) * (this.var_15);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_16 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.measurement1 = all[0].getMeasurement(0);
        this.value2 = this.output[0];
        this.measurement5 = all[0].getMeasurement(1);
        this.value6 = this.output[1];
        this.measurement9 = all[0].getMeasurement(2);
        this.value10 = this.output[2];
        this.aliasName0 = new AliasName_1.AliasName(this.alias, "k");
        this.aliasName14 = new AliasName_1.AliasName(this.alias, "l");
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
    get_12() {
        return this.success ? this.var_12 : undefined;
    }
    get_13() {
        return this.success ? this.var_13 : undefined;
    }
    get_14() {
        return this.success ? this.var_14 : undefined;
    }
    get_15() {
        return this.success ? this.var_15 : undefined;
    }
    get_16() {
        return this.success ? this.var_16 : undefined;
    }
    save() {
        var v = this.variables;
        var x0 = v.get("a");
        x0 === null || x0 === void 0 ? void 0 : x0.setIValue(this.get_4());
        var x1 = v.get("b");
        x1 === null || x1 === void 0 ? void 0 : x1.setIValue(this.get_8());
        var x2 = v.get("c");
        x2 === null || x2 === void 0 ? void 0 : x2.setIValue(this.get_12());
        var x3 = v.get("d");
        x3 === null || x3 === void 0 ? void 0 : x3.setIValue(this.get_13());
        var x4 = v.get("f");
        x4 === null || x4 === void 0 ? void 0 : x4.setIValue(this.get_16());
    }
    setFeedback() {
        let map = new Map([
            ["a", "Vector.a"],
            ["c", "Vector.c"],
            ["b", "Vector.b"]
        ]);
    }
}
class TransformerRecursive_CategoryObject_4 extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class TransformerRecursive_CategoryArrow_0 extends ObjectTransformerLink_1.ObjectTransformerLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class TransformerRecursive_CategoryArrow_1 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class TransformerRecursive_CategoryArrow_2 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class TransformerRecursive_CategoryArrow_3 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class TransformerRecursive_CategoryArrow_4 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class TransformerRecursive_CategoryArrow_5 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class TransformerRecursive extends Desktop_1.Desktop {
    constructor() {
        super();
        this.name = "TransformerRecursive";
        new TransformerRecursive_CategoryObject_0(this, "Vector");
        new TransformerRecursive_CategoryObject_1(this, "Source");
        new TransformerRecursive_CategoryObject_2(this, "Transformer");
        new TransformerRecursive_CategoryObject_3(this, "Recursive");
        new TransformerRecursive_CategoryObject_4(this, "Chart");
        new TransformerRecursive_CategoryArrow_0(this, "");
        new TransformerRecursive_CategoryArrow_1(this, "");
        new TransformerRecursive_CategoryArrow_2(this, "");
        new TransformerRecursive_CategoryArrow_3(this, "");
        new TransformerRecursive_CategoryArrow_4(this, "");
        new TransformerRecursive_CategoryArrow_5(this, "");
        let objects = this.getCategoryObjects();
        let arrows = this.getCategoryArrows();
        arrows[0].setSource(objects[2]);
        arrows[0].setTarget(objects[1]);
        arrows[1].setSource(objects[2]);
        arrows[1].setTarget(objects[0]);
        arrows[2].setSource(objects[3]);
        arrows[2].setTarget(objects[2]);
        arrows[3].setSource(objects[3]);
        arrows[3].setTarget(objects[0]);
        arrows[4].setSource(objects[4]);
        arrows[4].setTarget(objects[3]);
        arrows[5].setSource(objects[4]);
        arrows[5].setTarget(objects[2]);
        objects[0].postSetArrow();
        objects[2].postSetArrow();
        objects[3].postSetArrow();
    }
}
exports.TransformerRecursive = TransformerRecursive;
//# sourceMappingURL=TransformerRecursive.js.map