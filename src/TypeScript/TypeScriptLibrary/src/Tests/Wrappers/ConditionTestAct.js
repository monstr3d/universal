"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ConditionTestAct = void 0;
const PerformerMeasuremets_1 = require("../../Library/Measurements/PerformerMeasuremets");
const Motion6DFactory_1 = require("../../Library/Motion6D/Motion6DFactory");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const ConditionTest_1 = require("../ConditionTest");
class ConditionTestAct extends ConditionTest_1.ConditionTest {
    dc;
    factory = new Motion6DFactory_1.Motion6DFactory;
    constructor() {
        super();
        var o = this.getCategoryObjects();
        this.dc = o[2];
    }
    func() {
        return false;
    }
    action() {
        var k = this.dc.getAllMeasurements()[1];
        var a = k.getMeasurement(0).getMeasurementValue();
        console.log(a);
    }
    isEmptyAction() {
        return false;
    }
    test() {
        var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, this.factory);
        var p = new PerformerMeasuremets_1.PerformerMeasuremets();
        p.peformCondDCFixedStepCalculation(runtime, this.dc, "Condition.Formula_1", this, 0, 0.01, 500, this);
    }
}
exports.ConditionTestAct = ConditionTestAct;
