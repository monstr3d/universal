"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RandomAct = void 0;
const FictiveDataConsumer_1 = require("../../Library/Fiction/FictiveDataConsumer");
const PefrormerMeasuremets_1 = require("../../Library/Measurements/PefrormerMeasuremets");
const DataRuntimeConsumer_1 = require("../../Library/Runtime/DataRuntimeConsumer");
const Random_1 = require("../Random");
class RandomAct extends Random_1.Random {
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
        p.performFixedStepCalculation(runtime, 0, 1, 1000, this);
    }
}
exports.RandomAct = RandomAct;
//# sourceMappingURL=RandomAcr.js.map