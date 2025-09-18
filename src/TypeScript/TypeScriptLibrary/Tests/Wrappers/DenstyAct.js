"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DensityAct = void 0;
const Density_1 = require("../Density");
const RungeProcessor_1 = require("../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor");
const PefrormerMeasuremets_1 = require("../../Library/Measurements/PefrormerMeasuremets");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
class DensityAct extends Density_1.Density {
    constructor() {
        super();
        var o = this.getCategoryObjects();
        this.dc = this.getCategoryObject("Chart");
        let m = this.getCategoryObject("A-transformation");
        this.measurement = m.getMeasurement(0);
    }
    action() {
        /*       var k = this.dc.getAllMeasurements()[0];
               var a = k.getMeasurement(0).getMeasurementValue();
               var b = k.getMeasurement(1).getMeasurementValue();*/
        const a = this.measurement.getMeasurementValue();
        console.log(a);
    }
    func() {
        return false;
    }
    test() {
        try {
            let processor = new RungeProcessor_1.RungeProcessor();
            var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, processor);
            var p = new PefrormerMeasuremets_1.PefrormerMeasuremets();
            p.performFixedStepCalculation(runtime, 1770457504, 1, 18000, this, this);
        }
        catch (e) {
            let i = 0;
            //    throw new OwnNotImplemented();
        }
    }
}
exports.DensityAct = DensityAct;
//# sourceMappingURL=DenstyAct.js.map