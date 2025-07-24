"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Complicated = void 0;
const AliasName_1 = require("../Library/AliasName");
const Desktop_1 = require("../Library/Desktop");
const DataLink_1 = require("../Library/Measurements/DataLink");
const Measurement_1 = require("../Library/Measurements/Measurement");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
class Complicated_CategoryObject_0_Measurement_2 extends Measurement_1.Measurement {
    constructor(o, name, type) {
        super(name, type);
        this.obj = o;
    }
    getMeasurementValue() {
        return this.obj.var_2;
    }
}
class Complicated_CategoryObject_0_Measurement_9 extends Measurement_1.Measurement {
    constructor(o, name, type) {
        super(name, type);
        this.obj = o;
    }
    getMeasurementValue() {
        return this.obj.var_9;
    }
}
class Complicated_CategoryObject_0 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
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
            ["b", 1],
            ["a", 5]
        ]);
        this.performer.setAliasMap(map, this);
        let feed = new Map([]);
        this.performer.copyMap(feed, this.feedback);
        this.arguments.push("t = Time");
        let ops = new Map([]);
        this.performer.copyMap(ops, this.operationNames);
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
        this.addMeasurement(new Complicated_CategoryObject_0_Measurement_2(this, "Formula_1", 0));
        this.addMeasurement(new Complicated_CategoryObject_0_Measurement_9(this, "Formula_2", 0));
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
class Complicated_CategoryObject_1_Measurement_2 extends Measurement_1.Measurement {
    constructor(o, name, type) {
        super(name, type);
        this.obj = o;
    }
    getMeasurementValue() {
        return this.obj.var_2;
    }
}
class Complicated_CategoryObject_1_Measurement_4 extends Measurement_1.Measurement {
    constructor(o, name, type) {
        super(name, type);
        this.obj = o;
    }
    getMeasurementValue() {
        return this.obj.var_4;
    }
}
class Complicated_CategoryObject_1_Measurement_7 extends Measurement_1.Measurement {
    constructor(o, name, type) {
        super(name, type);
        this.obj = o;
    }
    getMeasurementValue() {
        return this.obj.var_7;
    }
}
class Complicated_CategoryObject_1 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
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
            ["a", 7]
        ]);
        this.performer.setAliasMap(map, this);
        let feed = new Map([]);
        this.performer.copyMap(feed, this.feedback);
        this.arguments.push("b = input.Formula_2");
        this.arguments.push("l = Time");
        let ops = new Map([]);
        this.performer.copyMap(ops, this.operationNames);
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
        this.variable = this.measurement3.getMeasurementValue();
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
        this.addMeasurement(new Complicated_CategoryObject_1_Measurement_2(this, "Formula_1", 0));
        this.addMeasurement(new Complicated_CategoryObject_1_Measurement_4(this, "Formula_2", 0));
        this.addMeasurement(new Complicated_CategoryObject_1_Measurement_7(this, "Formula_3", 0));
        this.measurement3 = this.dataConsumer.getAllMeasurements()[0].getMeasurement(1);
        this.aliasName0 = new AliasName_1.AliasName(this.alias, "a");
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
    postSetArrow() {
        this.init();
    }
}
class Complicated_CategoryObject_2_Measurement_2 extends Measurement_1.Measurement {
    constructor(o, name, type) {
        super(name, type);
        this.obj = o;
    }
    getMeasurementValue() {
        return this.obj.var_2;
    }
}
class Complicated_CategoryObject_2_Measurement_4 extends Measurement_1.Measurement {
    constructor(o, name, type) {
        super(name, type);
        this.obj = o;
    }
    getMeasurementValue() {
        return this.obj.var_4;
    }
}
class Complicated_CategoryObject_2 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        this.var_1 = 3;
        this.var_2 = 0;
        this.var_3 = 0;
        this.var_4 = 0;
        let map = new Map([]);
        this.performer.setAliasMap(map, this);
        let feed = new Map([]);
        this.performer.copyMap(feed, this.feedback);
        this.arguments.push("a = input.Formula_2");
        this.arguments.push("b = Output.Formula_3");
        let ops = new Map([]);
        this.performer.copyMap(ops, this.operationNames);
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
        this.variable = Math.cos(this.var_3);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_4 = this.convert(this.variable);
    }
    init() {
        this.addMeasurement(new Complicated_CategoryObject_2_Measurement_2(this, "Formula_1", 0));
        this.addMeasurement(new Complicated_CategoryObject_2_Measurement_4(this, "Formula_2", 0));
        this.measurement0 = this.dataConsumer.getAllMeasurements()[0].getMeasurement(1);
        this.measurement3 = this.dataConsumer.getAllMeasurements()[1].getMeasurement(2);
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
    postSetArrow() {
        this.init();
    }
}
class Complicated_CategoryObject_3_Measurement_2 extends Measurement_1.Measurement {
    constructor(o, name, type) {
        super(name, type);
        this.obj = o;
    }
    getMeasurementValue() {
        return this.obj.var_2;
    }
}
class Complicated_CategoryObject_3_Measurement_5 extends Measurement_1.Measurement {
    constructor(o, name, type) {
        super(name, type);
        this.obj = o;
    }
    getMeasurementValue() {
        return this.obj.var_5;
    }
}
class Complicated_CategoryObject_3_Measurement_7 extends Measurement_1.Measurement {
    constructor(o, name, type) {
        super(name, type);
        this.obj = o;
    }
    getMeasurementValue() {
        return this.obj.var_7;
    }
}
class Complicated_CategoryObject_3 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        this.var_1 = 0;
        this.var_2 = 0;
        this.var_3 = 0;
        this.var_4 = 2;
        this.var_5 = 0;
        this.var_6 = 0;
        this.var_7 = 0;
        let map = new Map([]);
        this.performer.setAliasMap(map, this);
        let feed = new Map([]);
        this.performer.copyMap(feed, this.feedback);
        this.arguments.push("f = input.Formula_2");
        this.arguments.push("a = Consumer.Formula_1");
        this.arguments.push("c = Output.Formula_1");
        this.arguments.push("t = Time");
        let ops = new Map([]);
        this.performer.copyMap(ops, this.operationNames);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.measurement0.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_0 = this.convert(this.variable);
        this.var_1 = this.getInternalTime();
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
        this.variable = Math.pow(this.var_3, this.var_4);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_5 = this.convert(this.variable);
        this.variable = this.measurement6.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_6 = this.convert(this.variable);
        this.variable = Math.cos(this.var_6);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_7 = this.convert(this.variable);
    }
    init() {
        this.addMeasurement(new Complicated_CategoryObject_3_Measurement_2(this, "Formula_1", 0));
        this.addMeasurement(new Complicated_CategoryObject_3_Measurement_5(this, "Formula_2", 0));
        this.addMeasurement(new Complicated_CategoryObject_3_Measurement_7(this, "Formula_3", 0));
        this.measurement0 = this.dataConsumer.getAllMeasurements()[0].getMeasurement(1);
        this.measurement3 = this.dataConsumer.getAllMeasurements()[1].getMeasurement(0);
        this.measurement6 = this.dataConsumer.getAllMeasurements()[2].getMeasurement(0);
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
    postSetArrow() {
        this.init();
    }
}
class Complicated_CategoryArrow_0 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Complicated_CategoryArrow_1 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Complicated_CategoryArrow_2 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Complicated_CategoryArrow_3 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Complicated_CategoryArrow_4 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Complicated_CategoryArrow_5 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Complicated extends Desktop_1.Desktop {
    constructor() {
        super();
        this.name = "Complicated";
        new Complicated_CategoryObject_0(this, "input");
        new Complicated_CategoryObject_1(this, "Output");
        new Complicated_CategoryObject_2(this, "Consumer");
        new Complicated_CategoryObject_3(this, "Finish");
        new Complicated_CategoryArrow_0(this, "22");
        new Complicated_CategoryArrow_1(this, "6");
        new Complicated_CategoryArrow_2(this, "4");
        new Complicated_CategoryArrow_3(this, "");
        new Complicated_CategoryArrow_4(this, "66");
        new Complicated_CategoryArrow_5(this, "10");
        let objects = this.getCategoryObjects();
        let arrows = this.getCategoryArrows();
        arrows[0].setSource(objects[1]);
        arrows[0].setTarget(objects[0]);
        arrows[1].setSource(objects[2]);
        arrows[1].setTarget(objects[0]);
        arrows[2].setSource(objects[2]);
        arrows[2].setTarget(objects[1]);
        arrows[3].setSource(objects[3]);
        arrows[3].setTarget(objects[0]);
        arrows[4].setSource(objects[3]);
        arrows[4].setTarget(objects[2]);
        arrows[5].setSource(objects[3]);
        arrows[5].setTarget(objects[1]);
        objects[0].postSetArrow();
        objects[1].postSetArrow();
        objects[2].postSetArrow();
        objects[3].postSetArrow();
    }
}
exports.Complicated = Complicated;
//# sourceMappingURL=Complicated.js.map