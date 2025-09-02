"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SimpleFeed = void 0;
const AliasName_1 = require("../Library/AliasName");
const Desktop_1 = require("../Library/Desktop");
const FeedbackAliasCollection_1 = require("../Library/FeedbackAliasCollection");
const FictiveAliasName_1 = require("../Library/Fiction/FictiveAliasName");
const FictiveMeasurement_1 = require("../Library/Fiction/FictiveMeasurement");
const DataLink_1 = require("../Library/Measurements/Arrows/DataLink");
const DataConsumer_1 = require("../Library/Measurements/DataConsumer");
const Variable_1 = require("../Library/Measurements/Variables/Variable");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
class SimpleFeed_CategoryObject_0 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.aliasName0 = new FictiveAliasName_1.FictiveAliasName();
        this.aliasName1 = new FictiveAliasName_1.FictiveAliasName();
        this.aliasName3 = new FictiveAliasName_1.FictiveAliasName();
        this.aliasName4 = new FictiveAliasName_1.FictiveAliasName();
        this.var_0 = 0;
        this.var_1 = 0;
        this.var_2 = 0;
        this.var_3 = 0;
        this.var_4 = 0;
        let map = new Map([
            ["a", 0.0089878549198011051],
            ["b", 0.0089878549198011051],
            ["c", 0],
            ["k", 0.69999999999999996]
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
        this.variable = this.aliasName4.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_4 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.aliasName0 = new AliasName_1.AliasName(this.alias, "a");
        this.aliasName1 = new AliasName_1.AliasName(this.alias, "k");
        this.aliasName3 = new AliasName_1.AliasName(this.alias, "b");
        this.aliasName4 = new AliasName_1.AliasName(this.alias, "c");
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
        x1 === null || x1 === void 0 ? void 0 : x1.setIValue(this.get_3());
        var x2 = v.get("Formula_3");
        x2 === null || x2 === void 0 ? void 0 : x2.setIValue(this.get_4());
    }
    setFeedback() {
        let map = new Map([]);
        this.feedback = new FeedbackAliasCollection_1.FeedbackAliasCollection(map, this, this);
    }
}
class SimpleFeed_CategoryObject_1 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.measurement4 = new FictiveMeasurement_1.FictiveMeasurement();
        this.aliasName0 = new FictiveAliasName_1.FictiveAliasName();
        this.var_0 = 0;
        this.var_1 = 0;
        this.var_2 = 0;
        this.var_3 = 0;
        this.var_4 = 0;
        let map = new Map([
            ["k", 0.10000000000000001]
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariable(new Variable_1.Variable("Formula_1", 0, 0));
        this.addVariable(new Variable_1.Variable("Formula_2", 0, 0));
    }
    calculateTree() {
        this.success = true;
        this.variable = this.aliasName0.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_0 = this.convert(this.variable);
        this.var_1 = this.getInternalTime();
        this.variable = Math.sin(this.var_1);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_2 = this.convert(this.variable);
        this.variable = (this.var_0) * (this.var_2);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_3 = this.convert(this.variable);
        this.variable = this.measurement4.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_4 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.measurement4 = all[0].getMeasurement(0);
        this.aliasName0 = new AliasName_1.AliasName(this.alias, "k");
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
        x0 === null || x0 === void 0 ? void 0 : x0.setIValue(this.get_3());
        var x1 = v.get("Formula_2");
        x1 === null || x1 === void 0 ? void 0 : x1.setIValue(this.get_4());
    }
    setFeedback() {
        let map = new Map([
            ["Formula_1", "A.a"]
        ]);
        this.feedback = new FeedbackAliasCollection_1.FeedbackAliasCollection(map, this, this);
    }
}
class SimpleFeed_CategoryObject_2 extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class SimpleFeed_CategoryArrow_0 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class SimpleFeed_CategoryArrow_1 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class SimpleFeed extends Desktop_1.Desktop {
    constructor() {
        super();
        this.name = "SimpleFeed";
        new SimpleFeed_CategoryObject_0(this, "A");
        new SimpleFeed_CategoryObject_1(this, "Output");
        new SimpleFeed_CategoryObject_2(this, "Chart");
        new SimpleFeed_CategoryArrow_0(this, "");
        new SimpleFeed_CategoryArrow_1(this, "");
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
exports.SimpleFeed = SimpleFeed;
//# sourceMappingURL=SimpleFeed.js.map