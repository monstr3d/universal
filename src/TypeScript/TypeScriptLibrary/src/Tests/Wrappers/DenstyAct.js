"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DensityAct = void 0;
const Density_1 = require("../Density");
const RungeProcessor_1 = require("../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor");
const PerformerMeasuremets_1 = require("../../Library/Measurements/PerformerMeasuremets");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const Motion6DFactory_1 = require("../../Library/Motion6D/Motion6DFactory");
class DensityAct extends Density_1.Density {
    dc;
    factory = new Motion6DFactory_1.Motion6DFactory;
    measurement;
    constructor() {
        super();
        var o = this.getCategoryObjects();
        this.dc = this.getCategoryObject("Chart");
        let m = this.getCategoryObject("A-transformation");
        this.measurement = m.getMeasurement(0);
    }
    isEmptyAction() {
        return false;
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
            var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, new Motion6DFactory_1.Motion6DFactory());
            var p = new PerformerMeasuremets_1.PerformerMeasuremets();
            p.performFixedStepCalculation(runtime, 1770457504, 1, 18000, this, this);
        }
        catch (e) {
            let i = 0;
            //    throw new OwnNotImplemented();
        }
    }
}
exports.DensityAct = DensityAct;
