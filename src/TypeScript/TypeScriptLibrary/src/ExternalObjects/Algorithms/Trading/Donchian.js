"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Donchian = void 0;
const DataLink_1 = require("../../../Library/Measurements/Arrows/DataLink");
const IteratorConsumerLink_1 = require("../../../Library/Measurements/Arrows/IteratorConsumerLink");
const DataConsumer_1 = require("../../../Library/Measurements/DataConsumer");
const RecursiveFormula_1 = require("../../../Library/Measurements/RecursiveFormula");
const SequenserFilterWrapper_1 = require("../../../Library/Measurements/SequenserFilterWrapper");
const VectorFormulaConsumer_1 = require("../../../Library/Measurements/VectorFormulaConsumer");
const SequenceFilterType_1 = require("../../../Library/Utilities/Filters/Interfaces/SequenceFilterType");
const AliasName_1 = require("../../../Library/AliasName");
const Desktop_1 = require("../../../Library/Desktop");
const TradingDataQuery_1 = require("../../Components/Trading/TradingDataQuery");
const TradingOrder_1 = require("../../Components/Trading/TradingOrder");
class Donchian_CategoryObject_0 extends TradingDataQuery_1.TradingDataQuery {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryObject_1 extends RecursiveFormula_1.RecursiveFormula {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([
            ["t", 0],
            ["x", 0],
            ["y", 0],
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("x", 0, 0);
        this.addVariableValue("y", 0, 0);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.value0.getIValue();
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
    }
    init() {
        var all = this.getAllMeasurements();
        this.fic = all;
        this.value0 = this.output[1];
        this.aliasName1 = new AliasName_1.AliasName(this.alias, "t");
    }
    value0;
    aliasName1;
    var_0 = 0;
    var_1 = 0;
    get_0() {
        return this.success ? this.var_0 : undefined;
    }
    get_1() {
        return this.success ? this.var_1 : undefined;
    }
    save() {
        var v = this.variables;
        var x0 = v.get("x");
        x0?.setIValue(this.get_0());
        var x1 = v.get("y");
        x1?.setIValue(this.get_1());
    }
}
class Donchian_CategoryObject_2 extends SequenserFilterWrapper_1.SequenceFilterWrapper {
    constructor(desktop, name) {
        super(desktop, name);
        this.count = 10;
        this.input = "Trading.Close";
        this.type = SequenceFilterType_1.SequenceFilterType.Avarage;
    }
}
class Donchian_CategoryObject_3 extends SequenserFilterWrapper_1.SequenceFilterWrapper {
    constructor(desktop, name) {
        super(desktop, name);
        this.count = 80;
        this.input = "Trading.Close";
        this.type = SequenceFilterType_1.SequenceFilterType.Avarage;
    }
}
class Donchian_CategoryObject_4 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([
            ["b", 90],
            ["a", 120],
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", false, false);
        this.addVariableValue("Formula_2", 0, 0);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.measurement0.getMeasurementValue();
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
        this.variable = (this.var_0) > (this.var_1);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_2 = this.convert(this.variable);
        this.variable = (this.var_0) > (this.var_1);
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
        this.variable = this.aliasName5.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_5 = this.convert(this.variable);
        this.variable = (this.var_3) ? (this.var_4) : (this.var_5);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_6 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.fic = all;
        this.measurement0 = all[1].getMeasurement(0);
        this.measurement1 = all[0].getMeasurement(0);
        this.aliasName4 = new AliasName_1.AliasName(this.alias, "a");
        this.aliasName5 = new AliasName_1.AliasName(this.alias, "b");
    }
    measurement0;
    measurement1;
    aliasName4;
    aliasName5;
    var_0 = 0;
    var_1 = 0;
    var_2 = false;
    var_3 = false;
    var_4 = 0;
    var_5 = 0;
    var_6 = 0;
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
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0?.setIValue(this.get_2());
        var x1 = v.get("Formula_2");
        x1?.setIValue(this.get_6());
    }
}
class Donchian_CategoryObject_5 extends SequenserFilterWrapper_1.SequenceFilterWrapper {
    constructor(desktop, name) {
        super(desktop, name);
        this.count = 20;
        this.input = "Trading.High";
        this.type = SequenceFilterType_1.SequenceFilterType.Donchian;
        this.mimax = true;
    }
}
class Donchian_CategoryObject_6 extends SequenserFilterWrapper_1.SequenceFilterWrapper {
    constructor(desktop, name) {
        super(desktop, name);
        this.count = 20;
        this.input = "Trading.High";
        this.type = SequenceFilterType_1.SequenceFilterType.Donchian;
        this.mimax = true;
    }
}
class Donchian_CategoryObject_7 extends SequenserFilterWrapper_1.SequenceFilterWrapper {
    constructor(desktop, name) {
        super(desktop, name);
        this.count = 20;
        this.input = "Trading.Low";
        this.type = SequenceFilterType_1.SequenceFilterType.Donchian;
        this.mimax = false;
    }
}
class Donchian_CategoryObject_8 extends SequenserFilterWrapper_1.SequenceFilterWrapper {
    constructor(desktop, name) {
        super(desktop, name);
        this.count = 20;
        this.input = "Trading.Low";
        this.type = SequenceFilterType_1.SequenceFilterType.Donchian;
        this.mimax = false;
    }
}
class Donchian_CategoryObject_9 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([
            ["b", 115],
            ["a", 140],
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", false, false);
        this.addVariableValue("Formula_2", false, false);
        this.addVariableValue("Formula_3", 0, 0);
        this.addVariableValue("Formula_4", 0, 0);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.measurement0.getMeasurementValue();
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
        this.variable = (this.var_0) < (this.var_1);
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
        this.variable = (this.var_0) > (this.var_3);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_4 = this.convert(this.variable);
        this.variable = (this.var_0) < (this.var_1);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_5 = this.convert(this.variable);
        this.variable = this.aliasName6.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_6 = this.convert(this.variable);
        this.variable = this.aliasName7.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_7 = this.convert(this.variable);
        this.variable = (this.var_5) ? (this.var_6) : (this.var_7);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_8 = this.convert(this.variable);
        this.variable = (this.var_0) > (this.var_3);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_9 = this.convert(this.variable);
        this.variable = (this.var_9) ? (this.var_6) : (this.var_7);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_10 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.fic = all;
        this.measurement0 = all[0].getMeasurement(4);
        this.measurement1 = all[2].getMeasurement(0);
        this.measurement3 = all[1].getMeasurement(0);
        this.aliasName6 = new AliasName_1.AliasName(this.alias, "a");
        this.aliasName7 = new AliasName_1.AliasName(this.alias, "b");
    }
    measurement0;
    measurement1;
    measurement3;
    aliasName6;
    aliasName7;
    var_0 = 0;
    var_1 = 0;
    var_2 = false;
    var_3 = 0;
    var_4 = false;
    var_5 = false;
    var_6 = 0;
    var_7 = 0;
    var_8 = 0;
    var_9 = false;
    var_10 = 0;
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
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0?.setIValue(this.get_2());
        var x1 = v.get("Formula_2");
        x1?.setIValue(this.get_4());
        var x2 = v.get("Formula_3");
        x2?.setIValue(this.get_8());
        var x3 = v.get("Formula_4");
        x3?.setIValue(this.get_10());
    }
}
class Donchian_CategoryObject_10 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([
            ["b", 125],
            ["a", 145],
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", false, false);
        this.addVariableValue("Formula_2", false, false);
        this.addVariableValue("Formula_3", 0, 0);
        this.addVariableValue("Formula_4", 0, 0);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.measurement0.getMeasurementValue();
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
        this.variable = (this.var_0) < (this.var_1);
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
        this.variable = (this.var_0) > (this.var_3);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_4 = this.convert(this.variable);
        this.variable = (this.var_0) < (this.var_1);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_5 = this.convert(this.variable);
        this.variable = this.aliasName6.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_6 = this.convert(this.variable);
        this.variable = this.aliasName7.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_7 = this.convert(this.variable);
        this.variable = (this.var_5) ? (this.var_6) : (this.var_7);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_8 = this.convert(this.variable);
        this.variable = (this.var_0) > (this.var_3);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_9 = this.convert(this.variable);
        this.variable = (this.var_9) ? (this.var_6) : (this.var_7);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_10 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.fic = all;
        this.measurement0 = all[0].getMeasurement(4);
        this.measurement1 = all[2].getMeasurement(0);
        this.measurement3 = all[1].getMeasurement(0);
        this.aliasName6 = new AliasName_1.AliasName(this.alias, "a");
        this.aliasName7 = new AliasName_1.AliasName(this.alias, "b");
    }
    measurement0;
    measurement1;
    measurement3;
    aliasName6;
    aliasName7;
    var_0 = 0;
    var_1 = 0;
    var_2 = false;
    var_3 = 0;
    var_4 = false;
    var_5 = false;
    var_6 = 0;
    var_7 = 0;
    var_8 = 0;
    var_9 = false;
    var_10 = 0;
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
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0?.setIValue(this.get_2());
        var x1 = v.get("Formula_2");
        x1?.setIValue(this.get_4());
        var x2 = v.get("Formula_3");
        x2?.setIValue(this.get_8());
        var x3 = v.get("Formula_4");
        x3?.setIValue(this.get_10());
    }
}
class Donchian_CategoryObject_11 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", false, false);
        this.addVariableValue("Formula_2", false, false);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.measurement0.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_0 = this.convert(this.variable);
        this.variable = (this.var_0) === (this.var_1);
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
        this.variable = (this.var_2) && (this.var_3);
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
        this.variable = (this.var_4) && (this.var_5);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_6 = this.convert(this.variable);
        this.variable = (this.var_0) === (this.var_7);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_8 = this.convert(this.variable);
        this.variable = !this.var_3;
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_9 = this.convert(this.variable);
        this.variable = (this.var_8) && (this.var_9);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_10 = this.convert(this.variable);
        this.variable = this.measurement11.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_11 = this.convert(this.variable);
        this.variable = (this.var_10) && (this.var_11);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_12 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.fic = all;
        this.measurement0 = all[2].getMeasurement(0);
        this.measurement3 = all[0].getMeasurement(0);
        this.measurement5 = all[1].getMeasurement(0);
        this.measurement11 = all[1].getMeasurement(1);
    }
    measurement0;
    measurement3;
    measurement5;
    measurement11;
    var_0 = 0;
    var_1 = 0;
    var_2 = false;
    var_3 = false;
    var_4 = false;
    var_5 = false;
    var_6 = false;
    var_7 = 1;
    var_8 = false;
    var_9 = false;
    var_10 = false;
    var_11 = false;
    var_12 = false;
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
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0?.setIValue(this.get_6());
        var x1 = v.get("Formula_2");
        x1?.setIValue(this.get_12());
    }
}
class Donchian_CategoryObject_12 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", false, false);
        this.addVariableValue("Formula_2", false, false);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.measurement0.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_0 = this.convert(this.variable);
        this.variable = (this.var_0) === (this.var_1);
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
        this.variable = !this.var_3;
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_4 = this.convert(this.variable);
        this.variable = (this.var_2) && (this.var_4);
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
        this.variable = (this.var_5) && (this.var_6);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_7 = this.convert(this.variable);
        this.variable = (this.var_0) === (this.var_8);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_9 = this.convert(this.variable);
        this.variable = (this.var_9) && (this.var_3);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_10 = this.convert(this.variable);
        this.variable = this.measurement11.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_11 = this.convert(this.variable);
        this.variable = (this.var_10) && (this.var_11);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_12 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.fic = all;
        this.measurement0 = all[1].getMeasurement(0);
        this.measurement3 = all[0].getMeasurement(0);
        this.measurement6 = all[2].getMeasurement(0);
        this.measurement11 = all[2].getMeasurement(1);
    }
    measurement0;
    measurement3;
    measurement6;
    measurement11;
    var_0 = 0;
    var_1 = 0;
    var_2 = false;
    var_3 = false;
    var_4 = false;
    var_5 = false;
    var_6 = false;
    var_7 = false;
    var_8 = 2;
    var_9 = false;
    var_10 = false;
    var_11 = false;
    var_12 = false;
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
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0?.setIValue(this.get_7());
        var x1 = v.get("Formula_2");
        x1?.setIValue(this.get_12());
    }
}
class Donchian_CategoryObject_13 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([
            ["d", 135],
            ["c", 145],
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", false, false);
        this.addVariableValue("Formula_2", 0, 0);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.measurement0.getMeasurementValue();
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
        this.variable = (this.var_0) || (this.var_1);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_2 = this.convert(this.variable);
        this.variable = (this.var_0) || (this.var_1);
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
        this.variable = this.aliasName5.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_5 = this.convert(this.variable);
        this.variable = (this.var_3) ? (this.var_4) : (this.var_5);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_6 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.fic = all;
        this.measurement0 = all[0].getMeasurement(1);
        this.measurement1 = all[1].getMeasurement(1);
        this.aliasName4 = new AliasName_1.AliasName(this.alias, "c");
        this.aliasName5 = new AliasName_1.AliasName(this.alias, "d");
    }
    measurement0;
    measurement1;
    aliasName4;
    aliasName5;
    var_0 = false;
    var_1 = false;
    var_2 = false;
    var_3 = false;
    var_4 = 0;
    var_5 = 0;
    var_6 = 0;
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
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0?.setIValue(this.get_2());
        var x1 = v.get("Formula_2");
        x1?.setIValue(this.get_6());
    }
}
class Donchian_CategoryObject_14 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", 0, 0);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.measurement0.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_0 = this.convert(this.variable);
        this.variable = this.measurement2.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_2 = this.convert(this.variable);
        this.variable = this.measurement4.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_4 = this.convert(this.variable);
        this.variable = this.measurement6.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_6 = this.convert(this.variable);
        this.variable = (this.var_4) ? (this.var_5) : (this.var_6);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_7 = this.convert(this.variable);
        this.variable = (this.var_2) ? (this.var_3) : (this.var_7);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_8 = this.convert(this.variable);
        this.variable = (this.var_0) ? (this.var_1) : (this.var_8);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_9 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.fic = all;
        this.measurement0 = all[4].getMeasurement(0);
        this.measurement2 = all[3].getMeasurement(0);
        this.measurement4 = all[2].getMeasurement(0);
        this.measurement6 = all[0].getMeasurement(1);
    }
    measurement0;
    measurement2;
    measurement4;
    measurement6;
    var_0 = false;
    var_1 = 0;
    var_2 = false;
    var_3 = 2;
    var_4 = false;
    var_5 = 1;
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
        x0?.setIValue(this.get_9());
    }
}
class Donchian_CategoryObject_15 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([
            ["b", 105],
            ["c", 129],
            ["a", 20],
            ["d", 107],
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
        this.variable = this.aliasName3.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_3 = this.convert(this.variable);
        this.variable = (this.var_2) + (this.var_3);
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
        this.variable = this.aliasName6.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_6 = this.convert(this.variable);
        this.variable = this.aliasName7.getAliasNameValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_7 = this.convert(this.variable);
        this.variable = (this.var_5) ? (this.var_6) : (this.var_7);
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_8 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.fic = all;
        this.measurement1 = all[0].getMeasurement(0);
        this.measurement5 = all[3].getMeasurement(0);
        this.aliasName0 = new AliasName_1.AliasName(this.alias, "a");
        this.aliasName3 = new AliasName_1.AliasName(this.alias, "b");
        this.aliasName6 = new AliasName_1.AliasName(this.alias, "c");
        this.aliasName7 = new AliasName_1.AliasName(this.alias, "d");
    }
    measurement1;
    measurement5;
    aliasName0;
    aliasName3;
    aliasName6;
    aliasName7;
    var_0 = 0;
    var_1 = 0;
    var_2 = 0;
    var_3 = 0;
    var_4 = 0;
    var_5 = false;
    var_6 = 0;
    var_7 = 0;
    var_8 = 0;
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
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0?.setIValue(this.get_4());
        var x1 = v.get("Formula_2");
        x1?.setIValue(this.get_8());
    }
}
class Donchian_CategoryObject_16 extends TradingOrder_1.TradingOrder {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryObject_17 extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_0 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_1 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_2 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_3 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_4 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_5 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_6 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_7 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_8 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_9 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_10 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_11 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_12 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_13 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_14 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_15 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_16 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_17 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_18 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_19 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_20 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_21 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_22 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_23 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_24 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_25 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_26 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_27 extends IteratorConsumerLink_1.IteratorConsumerLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_28 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_29 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_30 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_31 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_32 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_33 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_34 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_35 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_36 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_37 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_38 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_39 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_40 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_41 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_42 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_43 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_44 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_45 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_46 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_47 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_48 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_49 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_50 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian_CategoryArrow_51 extends IteratorConsumerLink_1.IteratorConsumerLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Donchian extends Desktop_1.Desktop {
    static async getDesktop(controller, factory) {
        let d = new Donchian(factory);
        await d.loadAsync(controller);
        return d;
    }
    constructor(factory) {
        super(factory);
        this.name = "Donchian";
        this.mapObjects.set("Donchian_CategoryObject_0", new Donchian_CategoryObject_0(this, "Trading"));
        this.mapObjects.set("Donchian_CategoryObject_1", new Donchian_CategoryObject_1(this, "Current Position"));
        this.mapObjects.set("Donchian_CategoryObject_2", new Donchian_CategoryObject_2(this, "Average Short"));
        this.mapObjects.set("Donchian_CategoryObject_3", new Donchian_CategoryObject_3(this, "Averge Long"));
        this.mapObjects.set("Donchian_CategoryObject_4", new Donchian_CategoryObject_4(this, "Condition 1"));
        this.mapObjects.set("Donchian_CategoryObject_5", new Donchian_CategoryObject_5(this, "Donchian maximum long"));
        this.mapObjects.set("Donchian_CategoryObject_6", new Donchian_CategoryObject_6(this, "Donchian maximum short"));
        this.mapObjects.set("Donchian_CategoryObject_7", new Donchian_CategoryObject_7(this, "Donchian minimum long"));
        this.mapObjects.set("Donchian_CategoryObject_8", new Donchian_CategoryObject_8(this, "Donchian minimum short"));
        this.mapObjects.set("Donchian_CategoryObject_9", new Donchian_CategoryObject_9(this, "Long conditions"));
        this.mapObjects.set("Donchian_CategoryObject_10", new Donchian_CategoryObject_10(this, "Short conditions"));
        this.mapObjects.set("Donchian_CategoryObject_11", new Donchian_CategoryObject_11(this, "Enter Exit Short"));
        this.mapObjects.set("Donchian_CategoryObject_12", new Donchian_CategoryObject_12(this, "Enter Exit Long"));
        this.mapObjects.set("Donchian_CategoryObject_13", new Donchian_CategoryObject_13(this, "Exit Condition"));
        this.mapObjects.set("Donchian_CategoryObject_14", new Donchian_CategoryObject_14(this, "Position"));
        this.mapObjects.set("Donchian_CategoryObject_15", new Donchian_CategoryObject_15(this, "Indicator"));
        this.mapObjects.set("Donchian_CategoryObject_16", new Donchian_CategoryObject_16(this, "Order"));
        this.mapObjects.set("Donchian_CategoryObject_17", new Donchian_CategoryObject_17(this, "Chart"));
        new Donchian_CategoryArrow_0(this, "");
        new Donchian_CategoryArrow_1(this, "");
        new Donchian_CategoryArrow_2(this, "");
        new Donchian_CategoryArrow_3(this, "");
        new Donchian_CategoryArrow_4(this, "");
        new Donchian_CategoryArrow_5(this, "");
        new Donchian_CategoryArrow_6(this, "");
        new Donchian_CategoryArrow_7(this, "");
        new Donchian_CategoryArrow_8(this, "");
        new Donchian_CategoryArrow_9(this, "");
        new Donchian_CategoryArrow_10(this, "");
        new Donchian_CategoryArrow_11(this, "");
        new Donchian_CategoryArrow_12(this, "");
        new Donchian_CategoryArrow_13(this, "");
        new Donchian_CategoryArrow_14(this, "");
        new Donchian_CategoryArrow_15(this, "");
        new Donchian_CategoryArrow_16(this, "");
        new Donchian_CategoryArrow_17(this, "");
        new Donchian_CategoryArrow_18(this, "");
        new Donchian_CategoryArrow_19(this, "");
        new Donchian_CategoryArrow_20(this, "");
        new Donchian_CategoryArrow_21(this, "");
        new Donchian_CategoryArrow_22(this, "");
        new Donchian_CategoryArrow_23(this, "");
        new Donchian_CategoryArrow_24(this, "");
        new Donchian_CategoryArrow_25(this, "");
        new Donchian_CategoryArrow_26(this, "");
        new Donchian_CategoryArrow_27(this, "");
        new Donchian_CategoryArrow_28(this, "");
        new Donchian_CategoryArrow_29(this, "");
        new Donchian_CategoryArrow_30(this, "");
        new Donchian_CategoryArrow_31(this, "");
        new Donchian_CategoryArrow_32(this, "");
        new Donchian_CategoryArrow_33(this, "");
        new Donchian_CategoryArrow_34(this, "");
        new Donchian_CategoryArrow_35(this, "");
        new Donchian_CategoryArrow_36(this, "");
        new Donchian_CategoryArrow_37(this, "");
        new Donchian_CategoryArrow_38(this, "");
        new Donchian_CategoryArrow_39(this, "");
        new Donchian_CategoryArrow_40(this, "");
        new Donchian_CategoryArrow_41(this, "");
        new Donchian_CategoryArrow_42(this, "");
        new Donchian_CategoryArrow_43(this, "");
        new Donchian_CategoryArrow_44(this, "");
        new Donchian_CategoryArrow_45(this, "");
        new Donchian_CategoryArrow_46(this, "");
        new Donchian_CategoryArrow_47(this, "");
        new Donchian_CategoryArrow_48(this, "");
        new Donchian_CategoryArrow_49(this, "");
        new Donchian_CategoryArrow_50(this, "");
        new Donchian_CategoryArrow_51(this, "");
    }
    finish() {
        let objects = this.getCategoryObjects();
        let arrows = this.getCategoryArrows();
        let s0 = this.mapObjects.get("Donchian_CategoryObject_2");
        if (s0 != undefined)
            arrows[0].setSource(s0);
        let t0 = this.mapObjects.get("Donchian_CategoryObject_0");
        if (t0 != undefined)
            arrows[0].setTarget(t0);
        let s1 = this.mapObjects.get("Donchian_CategoryObject_3");
        if (s1 != undefined)
            arrows[1].setSource(s1);
        let t1 = this.mapObjects.get("Donchian_CategoryObject_0");
        if (t1 != undefined)
            arrows[1].setTarget(t1);
        let s2 = this.mapObjects.get("Donchian_CategoryObject_4");
        if (s2 != undefined)
            arrows[2].setSource(s2);
        let t2 = this.mapObjects.get("Donchian_CategoryObject_3");
        if (t2 != undefined)
            arrows[2].setTarget(t2);
        let s3 = this.mapObjects.get("Donchian_CategoryObject_4");
        if (s3 != undefined)
            arrows[3].setSource(s3);
        let t3 = this.mapObjects.get("Donchian_CategoryObject_2");
        if (t3 != undefined)
            arrows[3].setTarget(t3);
        let s4 = this.mapObjects.get("Donchian_CategoryObject_5");
        if (s4 != undefined)
            arrows[4].setSource(s4);
        let t4 = this.mapObjects.get("Donchian_CategoryObject_0");
        if (t4 != undefined)
            arrows[4].setTarget(t4);
        let s5 = this.mapObjects.get("Donchian_CategoryObject_6");
        if (s5 != undefined)
            arrows[5].setSource(s5);
        let t5 = this.mapObjects.get("Donchian_CategoryObject_0");
        if (t5 != undefined)
            arrows[5].setTarget(t5);
        let s6 = this.mapObjects.get("Donchian_CategoryObject_7");
        if (s6 != undefined)
            arrows[6].setSource(s6);
        let t6 = this.mapObjects.get("Donchian_CategoryObject_0");
        if (t6 != undefined)
            arrows[6].setTarget(t6);
        let s7 = this.mapObjects.get("Donchian_CategoryObject_8");
        if (s7 != undefined)
            arrows[7].setSource(s7);
        let t7 = this.mapObjects.get("Donchian_CategoryObject_0");
        if (t7 != undefined)
            arrows[7].setTarget(t7);
        let s8 = this.mapObjects.get("Donchian_CategoryObject_9");
        if (s8 != undefined)
            arrows[8].setSource(s8);
        let t8 = this.mapObjects.get("Donchian_CategoryObject_0");
        if (t8 != undefined)
            arrows[8].setTarget(t8);
        let s9 = this.mapObjects.get("Donchian_CategoryObject_9");
        if (s9 != undefined)
            arrows[9].setSource(s9);
        let t9 = this.mapObjects.get("Donchian_CategoryObject_5");
        if (t9 != undefined)
            arrows[9].setTarget(t9);
        let s10 = this.mapObjects.get("Donchian_CategoryObject_9");
        if (s10 != undefined)
            arrows[10].setSource(s10);
        let t10 = this.mapObjects.get("Donchian_CategoryObject_8");
        if (t10 != undefined)
            arrows[10].setTarget(t10);
        let s11 = this.mapObjects.get("Donchian_CategoryObject_10");
        if (s11 != undefined)
            arrows[11].setSource(s11);
        let t11 = this.mapObjects.get("Donchian_CategoryObject_0");
        if (t11 != undefined)
            arrows[11].setTarget(t11);
        let s12 = this.mapObjects.get("Donchian_CategoryObject_10");
        if (s12 != undefined)
            arrows[12].setSource(s12);
        let t12 = this.mapObjects.get("Donchian_CategoryObject_5");
        if (t12 != undefined)
            arrows[12].setTarget(t12);
        let s13 = this.mapObjects.get("Donchian_CategoryObject_10");
        if (s13 != undefined)
            arrows[13].setSource(s13);
        let t13 = this.mapObjects.get("Donchian_CategoryObject_7");
        if (t13 != undefined)
            arrows[13].setTarget(t13);
        let s14 = this.mapObjects.get("Donchian_CategoryObject_14");
        if (s14 != undefined)
            arrows[14].setSource(s14);
        let t14 = this.mapObjects.get("Donchian_CategoryObject_1");
        if (t14 != undefined)
            arrows[14].setTarget(t14);
        let s15 = this.mapObjects.get("Donchian_CategoryObject_14");
        if (s15 != undefined)
            arrows[15].setSource(s15);
        let t15 = this.mapObjects.get("Donchian_CategoryObject_4");
        if (t15 != undefined)
            arrows[15].setTarget(t15);
        let s16 = this.mapObjects.get("Donchian_CategoryObject_15");
        if (s16 != undefined)
            arrows[16].setSource(s16);
        let t16 = this.mapObjects.get("Donchian_CategoryObject_14");
        if (t16 != undefined)
            arrows[16].setTarget(t16);
        let s17 = this.mapObjects.get("Donchian_CategoryObject_11");
        if (s17 != undefined)
            arrows[17].setSource(s17);
        let t17 = this.mapObjects.get("Donchian_CategoryObject_4");
        if (t17 != undefined)
            arrows[17].setTarget(t17);
        let s18 = this.mapObjects.get("Donchian_CategoryObject_11");
        if (s18 != undefined)
            arrows[18].setSource(s18);
        let t18 = this.mapObjects.get("Donchian_CategoryObject_10");
        if (t18 != undefined)
            arrows[18].setTarget(t18);
        let s19 = this.mapObjects.get("Donchian_CategoryObject_11");
        if (s19 != undefined)
            arrows[19].setSource(s19);
        let t19 = this.mapObjects.get("Donchian_CategoryObject_1");
        if (t19 != undefined)
            arrows[19].setTarget(t19);
        let s20 = this.mapObjects.get("Donchian_CategoryObject_12");
        if (s20 != undefined)
            arrows[20].setSource(s20);
        let t20 = this.mapObjects.get("Donchian_CategoryObject_4");
        if (t20 != undefined)
            arrows[20].setTarget(t20);
        let s21 = this.mapObjects.get("Donchian_CategoryObject_12");
        if (s21 != undefined)
            arrows[21].setSource(s21);
        let t21 = this.mapObjects.get("Donchian_CategoryObject_1");
        if (t21 != undefined)
            arrows[21].setTarget(t21);
        let s22 = this.mapObjects.get("Donchian_CategoryObject_12");
        if (s22 != undefined)
            arrows[22].setSource(s22);
        let t22 = this.mapObjects.get("Donchian_CategoryObject_9");
        if (t22 != undefined)
            arrows[22].setTarget(t22);
        let s23 = this.mapObjects.get("Donchian_CategoryObject_14");
        if (s23 != undefined)
            arrows[23].setSource(s23);
        let t23 = this.mapObjects.get("Donchian_CategoryObject_11");
        if (t23 != undefined)
            arrows[23].setTarget(t23);
        let s24 = this.mapObjects.get("Donchian_CategoryObject_14");
        if (s24 != undefined)
            arrows[24].setSource(s24);
        let t24 = this.mapObjects.get("Donchian_CategoryObject_12");
        if (t24 != undefined)
            arrows[24].setTarget(t24);
        let s25 = this.mapObjects.get("Donchian_CategoryObject_16");
        if (s25 != undefined)
            arrows[25].setSource(s25);
        let t25 = this.mapObjects.get("Donchian_CategoryObject_0");
        if (t25 != undefined)
            arrows[25].setTarget(t25);
        let s26 = this.mapObjects.get("Donchian_CategoryObject_16");
        if (s26 != undefined)
            arrows[26].setSource(s26);
        let t26 = this.mapObjects.get("Donchian_CategoryObject_14");
        if (t26 != undefined)
            arrows[26].setTarget(t26);
        let s27 = this.mapObjects.get("Donchian_CategoryObject_16");
        if (s27 != undefined)
            arrows[27].setSource(s27);
        let t27 = this.mapObjects.get("Donchian_CategoryObject_0");
        if (t27 != undefined)
            arrows[27].setTarget(t27);
        let s28 = this.mapObjects.get("Donchian_CategoryObject_16");
        if (s28 != undefined)
            arrows[28].setSource(s28);
        let t28 = this.mapObjects.get("Donchian_CategoryObject_2");
        if (t28 != undefined)
            arrows[28].setTarget(t28);
        let s29 = this.mapObjects.get("Donchian_CategoryObject_16");
        if (s29 != undefined)
            arrows[29].setSource(s29);
        let t29 = this.mapObjects.get("Donchian_CategoryObject_3");
        if (t29 != undefined)
            arrows[29].setTarget(t29);
        let s30 = this.mapObjects.get("Donchian_CategoryObject_16");
        if (s30 != undefined)
            arrows[30].setSource(s30);
        let t30 = this.mapObjects.get("Donchian_CategoryObject_8");
        if (t30 != undefined)
            arrows[30].setTarget(t30);
        let s31 = this.mapObjects.get("Donchian_CategoryObject_16");
        if (s31 != undefined)
            arrows[31].setSource(s31);
        let t31 = this.mapObjects.get("Donchian_CategoryObject_6");
        if (t31 != undefined)
            arrows[31].setTarget(t31);
        let s32 = this.mapObjects.get("Donchian_CategoryObject_15");
        if (s32 != undefined)
            arrows[32].setSource(s32);
        let t32 = this.mapObjects.get("Donchian_CategoryObject_11");
        if (t32 != undefined)
            arrows[32].setTarget(t32);
        let s33 = this.mapObjects.get("Donchian_CategoryObject_16");
        if (s33 != undefined)
            arrows[33].setSource(s33);
        let t33 = this.mapObjects.get("Donchian_CategoryObject_4");
        if (t33 != undefined)
            arrows[33].setTarget(t33);
        let s34 = this.mapObjects.get("Donchian_CategoryObject_15");
        if (s34 != undefined)
            arrows[34].setSource(s34);
        let t34 = this.mapObjects.get("Donchian_CategoryObject_9");
        if (t34 != undefined)
            arrows[34].setTarget(t34);
        let s35 = this.mapObjects.get("Donchian_CategoryObject_15");
        if (s35 != undefined)
            arrows[35].setSource(s35);
        let t35 = this.mapObjects.get("Donchian_CategoryObject_12");
        if (t35 != undefined)
            arrows[35].setTarget(t35);
        let s36 = this.mapObjects.get("Donchian_CategoryObject_16");
        if (s36 != undefined)
            arrows[36].setSource(s36);
        let t36 = this.mapObjects.get("Donchian_CategoryObject_15");
        if (t36 != undefined)
            arrows[36].setTarget(t36);
        let s37 = this.mapObjects.get("Donchian_CategoryObject_13");
        if (s37 != undefined)
            arrows[37].setSource(s37);
        let t37 = this.mapObjects.get("Donchian_CategoryObject_11");
        if (t37 != undefined)
            arrows[37].setTarget(t37);
        let s38 = this.mapObjects.get("Donchian_CategoryObject_13");
        if (s38 != undefined)
            arrows[38].setSource(s38);
        let t38 = this.mapObjects.get("Donchian_CategoryObject_12");
        if (t38 != undefined)
            arrows[38].setTarget(t38);
        let s39 = this.mapObjects.get("Donchian_CategoryObject_14");
        if (s39 != undefined)
            arrows[39].setSource(s39);
        let t39 = this.mapObjects.get("Donchian_CategoryObject_13");
        if (t39 != undefined)
            arrows[39].setTarget(t39);
        let s40 = this.mapObjects.get("Donchian_CategoryObject_16");
        if (s40 != undefined)
            arrows[40].setSource(s40);
        let t40 = this.mapObjects.get("Donchian_CategoryObject_13");
        if (t40 != undefined)
            arrows[40].setTarget(t40);
        let s41 = this.mapObjects.get("Donchian_CategoryObject_16");
        if (s41 != undefined)
            arrows[41].setSource(s41);
        let t41 = this.mapObjects.get("Donchian_CategoryObject_9");
        if (t41 != undefined)
            arrows[41].setTarget(t41);
        let s42 = this.mapObjects.get("Donchian_CategoryObject_16");
        if (s42 != undefined)
            arrows[42].setSource(s42);
        let t42 = this.mapObjects.get("Donchian_CategoryObject_10");
        if (t42 != undefined)
            arrows[42].setTarget(t42);
        let s43 = this.mapObjects.get("Donchian_CategoryObject_17");
        if (s43 != undefined)
            arrows[43].setSource(s43);
        let t43 = this.mapObjects.get("Donchian_CategoryObject_0");
        if (t43 != undefined)
            arrows[43].setTarget(t43);
        let s44 = this.mapObjects.get("Donchian_CategoryObject_17");
        if (s44 != undefined)
            arrows[44].setSource(s44);
        let t44 = this.mapObjects.get("Donchian_CategoryObject_16");
        if (t44 != undefined)
            arrows[44].setTarget(t44);
        let s45 = this.mapObjects.get("Donchian_CategoryObject_17");
        if (s45 != undefined)
            arrows[45].setSource(s45);
        let t45 = this.mapObjects.get("Donchian_CategoryObject_2");
        if (t45 != undefined)
            arrows[45].setTarget(t45);
        let s46 = this.mapObjects.get("Donchian_CategoryObject_17");
        if (s46 != undefined)
            arrows[46].setSource(s46);
        let t46 = this.mapObjects.get("Donchian_CategoryObject_3");
        if (t46 != undefined)
            arrows[46].setTarget(t46);
        let s47 = this.mapObjects.get("Donchian_CategoryObject_17");
        if (s47 != undefined)
            arrows[47].setSource(s47);
        let t47 = this.mapObjects.get("Donchian_CategoryObject_7");
        if (t47 != undefined)
            arrows[47].setTarget(t47);
        let s48 = this.mapObjects.get("Donchian_CategoryObject_17");
        if (s48 != undefined)
            arrows[48].setSource(s48);
        let t48 = this.mapObjects.get("Donchian_CategoryObject_8");
        if (t48 != undefined)
            arrows[48].setTarget(t48);
        let s49 = this.mapObjects.get("Donchian_CategoryObject_17");
        if (s49 != undefined)
            arrows[49].setSource(s49);
        let t49 = this.mapObjects.get("Donchian_CategoryObject_5");
        if (t49 != undefined)
            arrows[49].setTarget(t49);
        let s50 = this.mapObjects.get("Donchian_CategoryObject_17");
        if (s50 != undefined)
            arrows[50].setSource(s50);
        let t50 = this.mapObjects.get("Donchian_CategoryObject_6");
        if (t50 != undefined)
            arrows[50].setTarget(t50);
        let s51 = this.mapObjects.get("Donchian_CategoryObject_17");
        if (s51 != undefined)
            arrows[51].setSource(s51);
        let t51 = this.mapObjects.get("Donchian_CategoryObject_0");
        if (t51 != undefined)
            arrows[51].setTarget(t51);
        objects[1].postSetArrow();
        objects[2].postSetArrow();
        objects[3].postSetArrow();
        objects[4].postSetArrow();
        objects[5].postSetArrow();
        objects[6].postSetArrow();
        objects[7].postSetArrow();
        objects[8].postSetArrow();
        objects[9].postSetArrow();
        objects[10].postSetArrow();
        objects[11].postSetArrow();
        objects[12].postSetArrow();
        objects[13].postSetArrow();
        objects[14].postSetArrow();
        objects[15].postSetArrow();
        objects[16].postSetArrow();
        objects[17].postSetArrow();
    }
}
exports.Donchian = Donchian;
