"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TwoAct = void 0;
const PefrormerMeasuremets_1 = require("../../Library/Measurements/PefrormerMeasuremets");
const DataRuntimeConsumer_1 = require("../../Library/Runtime/DataRuntimeConsumer");
const Two_1 = require("../Two");
class TwoAct extends Two_1.Two {
    constructor() {
        super();
        this.dc = this.getCategoryObjects()[1];
    }
    action() {
        var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
        var b = k.getMeasurement(1).getMeasurementValue();
        console.log(a, b);
    }
    test() {
        var runtime = new DataRuntimeConsumer_1.DataRuntimeConsumer(this.dc);
        var p = new PefrormerMeasuremets_1.PefrormerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 1, 10, this);
    }
}
exports.TwoAct = TwoAct;
//# sourceMappingURL=TwoAct.js.map