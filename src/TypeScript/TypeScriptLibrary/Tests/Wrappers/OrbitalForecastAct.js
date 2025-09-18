"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.OrbitaForecasAct = void 0;
const RungeProcessor_1 = require("../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor");
const PefrormerMeasuremets_1 = require("../../Library/Measurements/PefrormerMeasuremets");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const OrbitalForecast_1 = require("../../Algorithms/OrbitalForecastCalculation/OrbitalForecast");
class OrbitaForecasAct extends OrbitalForecast_1.OrbitalForecast {
    constructor() {
        super();
        var o = this.getCategoryObjects();
        this.dc = this.getCategoryObject("Chart");
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
            var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, processor);
            var p = new PefrormerMeasuremets_1.PefrormerMeasuremets();
            p.peformCondDCFixedStepCalculation(runtime, this.dc, "Recursive.y", this, 0, 1, 18000, this);
        }
        catch (e) {
            let i = 0;
            //    throw new OwnNotImplemented();
        }
    }
}
exports.OrbitaForecasAct = OrbitaForecasAct;
//# sourceMappingURL=OrbitalForecastAct.js.map