"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.OrbitaForecasAct = void 0;
const RungeProcessor_1 = require("../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor");
const PerformerMeasuremets_1 = require("../../Library/Measurements/PerformerMeasuremets");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const OrbitalForecast_1 = require("../../ExternalObjects/Algorithms/OrbitalForecastCalculation/OrbitalForecast");
const Motion6DFactory_1 = require("../../Library/Motion6D/Motion6DFactory");
class OrbitaForecasAct extends OrbitalForecast_1.OrbitalForecast {
    dc;
    constructor() {
        super();
        var o = this.getCategoryObjects();
        this.dc = this.getCategoryObject("Chart");
    }
    isEmptyAction() {
        return false;
    }
    action() {
        var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
        var b = k.getMeasurement(1).getMeasurementValue();
        console.log(a, b);
    }
    func() {
        return false;
    }
    test() {
        try {
            let processor = new RungeProcessor_1.RungeProcessor();
            var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, new Motion6DFactory_1.Motion6DFactory());
            var p = new PerformerMeasuremets_1.PerformerMeasuremets();
            p.peformCondDCFixedStepCalculation(runtime, this.dc, "Recursive.y", this, 0, 1, 18000, this);
        }
        catch (e) {
            let i = 0;
            //    throw new OwnNotImplemented();
        }
    }
}
exports.OrbitaForecasAct = OrbitaForecasAct;
