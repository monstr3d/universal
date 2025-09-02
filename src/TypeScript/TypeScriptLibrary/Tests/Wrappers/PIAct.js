"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PIAct = void 0;
const FictiveDataConsumer_1 = require("../../Library/Fiction/FictiveDataConsumer");
const PefrormerMeasuremets_1 = require("../../Library/Measurements/PefrormerMeasuremets");
const DataRuntimeConsumer_1 = require("../../Library/Runtime/DataRuntimeConsumer");
const PI_1 = require("../PI");
class PIAct extends PI_1.PI {
    constructor() {
        super();
        this.dc = new FictiveDataConsumer_1.FictiveDataConsumer();
        var co = this.getCategoryObject("Chart");
        this.dc = co;
    }
    action() {
        var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
        console.log(a);
    }
    test() {
        var runtime = new DataRuntimeConsumer_1.DataRuntimeConsumer(this.dc);
        var p = new PefrormerMeasuremets_1.PefrormerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 0.001, 1000, this);
    }
}
exports.PIAct = PIAct;
//# sourceMappingURL=PIAct.js.map