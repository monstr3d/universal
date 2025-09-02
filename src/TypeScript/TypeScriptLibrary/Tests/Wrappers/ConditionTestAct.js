"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ConditionTestAct = void 0;
const FictiveDataConsumer_1 = require("../../Library/Fiction/FictiveDataConsumer");
const PefrormerMeasuremets_1 = require("../../Library/Measurements/PefrormerMeasuremets");
const DataRuntimeConsumer_1 = require("../../Library/Runtime/DataRuntimeConsumer");
const ConditionTest_1 = require("../ConditionTest");
class ConditionTestAct extends ConditionTest_1.ConditionTest {
    constructor() {
        super();
        this.dc = new FictiveDataConsumer_1.FictiveDataConsumer();
        var o = this.getCategoryObjects();
        this.dc = o[2];
    }
    action() {
        var k = this.dc.getAllMeasurements()[1];
        var a = k.getMeasurement(0).getMeasurementValue();
        console.log(a);
    }
    test() {
        var runtime = new DataRuntimeConsumer_1.DataRuntimeConsumer(this.dc);
        var p = new PefrormerMeasuremets_1.PefrormerMeasuremets();
        p.peformCondDCFixedStepCalculation(runtime, this.dc, "Condition.Formula_1", 0, 0.01, 500, this);
    }
}
exports.ConditionTestAct = ConditionTestAct;
//# sourceMappingURL=ConditionTestAct.js.map