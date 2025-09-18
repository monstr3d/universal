"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SimpleFeedAct = void 0;
const PefrormerMeasuremets_1 = require("../../Library/Measurements/PefrormerMeasuremets");
const DataRuntimeConsumer_1 = require("../../Library/Runtime/DataRuntimeConsumer");
const SimpleFeed_1 = require("../SimpleFeed");
class SimpleFeedAct extends SimpleFeed_1.SimpleFeed {
    constructor() {
        super();
        var co = this.getCategoryObject("Chart");
        this.dc = co;
    }
    action() {
        var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
        var b = k.getMeasurement(1).getMeasurementValue();
        console.log(a, b);
        ;
    }
    func() {
        return false;
    }
    test() {
        var runtime = new DataRuntimeConsumer_1.DataRuntimeConsumer(this.dc);
        var p = new PefrormerMeasuremets_1.PefrormerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 0.001, 1000, this, this);
    }
}
exports.SimpleFeedAct = SimpleFeedAct;
//# sourceMappingURL=SimpleFeedAct.js.map