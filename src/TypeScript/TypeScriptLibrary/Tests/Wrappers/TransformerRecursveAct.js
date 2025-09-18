"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TransformerRecursveAct = void 0;
const PefrormerMeasuremets_1 = require("../../Library/Measurements/PefrormerMeasuremets");
const DataRuntimeConsumer_1 = require("../../Library/Runtime/DataRuntimeConsumer");
const TransformerRecursive_1 = require("../TransformerRecursive");
class TransformerRecursveAct extends TransformerRecursive_1.TransformerRecursive {
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
        p.performFixedStepCalculation(runtime, 0, 1, 60, this, this);
    }
}
exports.TransformerRecursveAct = TransformerRecursveAct;
//# sourceMappingURL=TransformerRecursveAct.js.map